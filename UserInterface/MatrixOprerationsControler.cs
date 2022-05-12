/* ------Projekt języki assemblerowe--------------------------------------------
 Rok akademicki 2021/2022
 Prowadzący: mgr.inż.Krzysztof Hanzel
 Autorka: Julia Merta
 Grupa: 5
 Sekcja: 1
 Temat projektu: Kalkulator macierzy
 Program ma realizować podstawowe operacje takie jak dodawanie macierzy,
 odejmowanie macierzy oraz mnożenie macierzy. 
; -----------------------------------------------------------------------------
*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using MatrixCSharpLibrary;

/// <summary>
/// Class to handle operations, check data, create threads, sets parameters, loading matrices and saving results to the file.
/// </summary>
namespace UserInterface
{


    /// <summary>
    /// Type of operation
    /// </summary>
    enum Operation
    {
        addition,
        substraction,
        multiplication,
    }


    /// <summary>
    /// The class responsible for setting data 
    /// </summary>
    class MatrixOprerationsControler
    {
        /// <summary>
        /// Import assembly addition procedure
        /// </summary>
        /// <param name="length">length of the row</param>
        /// <param name="ptrA">pointer to matrix A row</param>
        /// <param name="ptrB">pointer to matrix B row</param>
        /// <param name="Result">pointer to the result row</param>
        /// <returns>pointer to the result row</returns>
        [DllImport(@"C:\Users\julia\source\repos\MatrixCalculatorJAProject\x64\Debug\LibraryAsm.dll")]
        public static unsafe extern IntPtr AsmAddProc(int length, IntPtr ptrA, IntPtr ptrB, IntPtr Result);

        /// <summary>
        /// Import assembly addition procedure
        /// </summary>
        /// <param name="length">length of the row</param>
        /// <param name="ptrA">pointer to matrix A row</param>
        /// <param name="ptrB">pointer to matrix B row</param>
        /// <param name="Result">pointer to the result row</param>
        /// <returns>pointer to the result row</returns>

        [DllImport(@"C:\Users\julia\source\repos\MatrixCalculatorJAProject\x64\Debug\LibraryAsm.dll")]
        public static extern unsafe IntPtr AsmSubProc(int length, IntPtr ptrA, IntPtr ptrB, IntPtr Result);

        /// <summary>
        /// Import assembly addition procedure
        /// </summary>
        /// <param name="length">length of the row</param>
        /// <param name="ptrA">pointer to matrix A row</param>
        /// <param name="ptrB">pointer to matrix B row</param>
        /// <returns>result of the multiplication (double) </returns>
        [DllImport(@"C:\Users\julia\source\repos\MatrixCalculatorJAProject\x64\Debug\LibraryAsm.dll")]
        public static extern unsafe double AsmMultiplyProc(int length, IntPtr ptrA, IntPtr ptrB);


        /// <summary>
        /// String form of the result matrix from assembly operations
        /// </summary>
        private String resArrayStringToSave;
        /// <summary>
        /// String value of elapsed time in miliseconds
        /// </summary>
        private String time;
        /// <summary>
        /// Filepaths 
        /// </summary>
        private String filepathB, filepathA, filepathResult;
        /// <summary>
        /// Number of threads
        /// </summary>
        private int numberOfThreads;
        /// <summary>
        /// Matrices rows and colums numbers
        /// </summary>
        private int numberOfRowsA, numberOfRowsB, numberOfColumsA, numberOfColumsB;
        /// <summary>
        /// matrix A
        /// </summary>
        private Matrix matrixA;
        /// <summary>
        /// Matrix B
        /// </summary>
        private Matrix matrixB;
        /// <summary>
        /// Matrix result
        /// </summary>
        private Matrix matrixResult;
        /// <summary>
        /// Type of operation
        /// </summary>
        private Operation operation;
        /// <summary>
        /// programming language
        /// </summary>
        private bool asm, csharp;

        /// <summary>
        /// The constructor
        /// </summary>
        public MatrixOprerationsControler() { asm = false; csharp = false; }

        /// <summary>
        /// Set the asm language state
        /// </summary>
        /// <param name="isChecked">the state of the checkbox</param>
        public void SetAsm(bool isChecked)
        {
            asm = isChecked;
        }

        /// <summary>
        /// Set the C Sharp language state
        /// </summary>
        /// <param name="isChecked">the state of the checkbox</param>
        public void SetCsharp(bool isChecked)
        {
            csharp = isChecked;
        }

        /// <summary>
        /// Filepath setter
        /// </summary>
        /// <param name="filepathB">the filepath</param>
        public void SetfilepathB(String filepathB)
        {
            this.filepathB = filepathB;
        }
        /// <summary>
        /// Filepath setter
        /// </summary>
        /// <param name="filepathB">the filepath</param>
        public void SetfilepathResult(String filepathResult)
        {
            this.filepathResult = filepathResult;
        }
        /// <summary>
        /// Filepath setter
        /// </summary>
        /// <param name="filepathB">the filepath</param>
        public void SetfilepathA(String filepathA)
        {
            this.filepathA = filepathA;
        }
        /// <summary>
        /// Set the number of threads
        /// </summary>
        /// <param name="numberOfThreads">the number of threads</param>
        public void SetNumberOfThreads(int numberOfThreads)
        {
            this.numberOfThreads = numberOfThreads;
        }

        /// <summary>
        /// Set the operation
        /// </summary>
        /// <param name="operationString">the name of the operation</param>
        public void LoadStringToOperation(string operationString)
        {

            if (operationString.Equals("Addition"))
                this.operation = Operation.addition;
            else if (operationString.Equals("Substraction"))
                this.operation = Operation.substraction;
            else if (operationString.Equals("Multiplication"))
                this.operation = Operation.multiplication;
            else throw new MatrixOperationException("You must choose the operation!");
        }

        /// <summary>
        /// The method to load matrices
        /// </summary>
        public void LoadMatrices()
        {

            
                        String[] textMatrixA = System.IO.File.ReadAllLines(filepathA);
                        String[] textMatrixB = System.IO.File.ReadAllLines(filepathB);

                        numberOfRowsA = int.Parse(textMatrixA[0]);
                        numberOfRowsB = int.Parse(textMatrixB[0]);
                        numberOfColumsB = int.Parse(textMatrixB[1]);
                        numberOfColumsA = int.Parse(textMatrixA[1]);
                        this.matrixA = new Matrix(numberOfRowsA, numberOfColumsA);
                        this.matrixB = new Matrix(numberOfRowsB, numberOfColumsB);


                        for (int i = 0; i < numberOfRowsA; i++)
                        {
                            String[] numbers = textMatrixA[i + 2].Split(" ");
                            for (int j = 0; j < numberOfColumsA; j++)
                            {

                                matrixA[i, j] = double.Parse(numbers[j]);
                            }
                        }

                        for (int i = 0; i < numberOfRowsB; i++)
                        {
                            String[] numbers = textMatrixB[i + 2].Split(" ");
                            for (int j = 0; j < numberOfColumsB; j++)
                            {

                                matrixB[i, j] = double.Parse(numbers[j]);
                            }
                        }

           

        }

        /// <summary>
        /// The method to check if the operation is possible
        /// </summary>
        /// <returns>if the operation is possible returns true, if not returns false</returns>
        public bool IsOperationPossible()
        {
            bool isPossible = true;
            switch (operation)
            {
                case Operation.multiplication:
                    isPossible = (matrixA.columnNumber == matrixB.rowNumber);
                    break;
                case Operation.substraction:
                case Operation.addition:
                    isPossible = ((matrixB.rowNumber == matrixA.rowNumber) && (matrixB.columnNumber == matrixA.columnNumber));
                    break;
                default:
                    isPossible = false;
                    break;
            }
            if (isPossible)
                return isPossible;
            throw new MatrixOperationException("The operation is invalid!");
        }

        /// <summary>
        /// The method to save results to the file
        /// </summary>
        /// <returns>Task</returns>
        public void SaveResultMatrix()
        {
            String text = "";
            String language = "";
            if (csharp)
            {
                language = "C#";

                language = "C#";
                text = "Calculation results:\n" + "Matrix A:\n" + matrixA.Print()
            + "Matrix B:\n" +
                matrixB.Print() + "Operation: " + operation.ToString() + "\nResult:\n" + matrixResult.Print() +
                "Language:" + language + "\n" + "Time: " + this.getTime() + "\nNumber of threads :" + numberOfThreads + "\n";

            }
            if (asm)
            {
                language = "ASM";

                text = "Calculation results:\n" + "Matrix A:\n" + matrixA.Print()
       + "Matrix B:\n" +
       matrixB.Print() + "Operation: " + operation.ToString() + "\nResult:\n" + resArrayStringToSave + "\n" +
       "Language:" + language + "\n" + "Time: " + this.getTime() + "\nNumber of threads :" + numberOfThreads + "\n";

            }



            File.WriteAllTextAsync(this.filepathResult, text);
        }

        /// <summary>
        /// Function to run the calculation in chosen language
        /// </summary>
        public void RunOperation()
        {
            if (csharp)
            {
                switch (operation)
                {
                    case Operation.substraction:
                        this.RunSubstractionCSharp();
                        break;
                    case Operation.addition:
                        this.RunAdditionCSharp();
                        break;
                    case Operation.multiplication:
                        this.RunMultiplicationCSharp();
                        break;
                    default:
                        throw new MatrixOperationException("Something went wrong. Check the input files and try again. " +
                            "Select the language and operation. Then try again.");

                }
            }
            else if (asm)
            {
                switch (operation)
                {
                    case Operation.substraction:
                        RunSubstractionAsm();
                        break;
                    case Operation.addition:
                        RunAdditionAsm();

                        break;
                    case Operation.multiplication:
                        RunMultiplicationAsm();

                        break;
                    default:
                        throw new MatrixOperationException("Something went wrong. Check the input files and try again. " +
                            "Select the language and operation. Then try again.");

                }
            }
        }


        /// <summary>
        /// Method to check if the assembly is the language of operation
        /// </summary>
        /// <returns></returns>
        public bool getAsmState()
        {
            return asm;
        }

        /// <summary>
        /// Method to check if the C# is the language of operation
        /// </summary>
        /// <returns></returns>
        public bool getCSharpState()
        {
            return csharp;
        }
        /// <summary>
        /// Run addition operation in C#
        /// </summary>
        public void RunAdditionCSharp()
        {
            matrixResult = new Matrix(matrixA.rowNumber, matrixA.columnNumber);
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();


            //List<Thread> threads = new List<Thread>();
            Thread[] threads = new Thread[numberOfThreads];

            double[,] array = new double[matrixA.rowNumber, matrixA.columnNumber];


            if (matrixA.rowNumber == numberOfThreads)
            {
                for (int i = 0; i < matrixA.rowNumber; i++)
                {
                    int i2 = i;
                    double[] x = matrixA.GetRow(i2);
                    double[] y = matrixB.GetRow(i2);
                    Thread thread = new Thread(() => Functions.VectorAddition(i2, x, y, ref array));
                    thread.Start();
                    threads[i] = thread;
                }

                foreach (Thread t in threads)
                    t.Join();

                matrixResult.setMatrixArray(array);
                stopWatch.Stop();
            }
            else if (matrixA.rowNumber > numberOfThreads)
            {
                for (int i = 0; i < matrixA.rowNumber; i++)
                {
                    int i2 = i;
                    double[] x = matrixA.GetRow(i2);
                    double[] y = matrixB.GetRow(i2);
                    Thread thread = new Thread(() => Functions.VectorAddition(i2, x, y, ref array));
                    thread.Start();
                    threads[i % numberOfThreads] = thread;
                }




                foreach (Thread t in threads)
                    t.Join();

                matrixResult.setMatrixArray(array);
                stopWatch.Stop();
            }
            else if (matrixA.rowNumber < numberOfThreads)
            {

                for (int i = 0; i < matrixA.rowNumber; i++)
                {
                    int i2 = i;
                    double[] x = matrixA.GetRow(i2);
                    double[] y = matrixB.GetRow(i2);
                    Thread thread = new Thread(() => Functions.VectorAddition(i2, x, y, ref array));
                    thread.Start();
                    threads[i] = thread;
                }

                double[] zeroRow = new double[matrixA.columnNumber];
                for (int i = matrixA.rowNumber; i < numberOfThreads; i++)
                {

                    Thread thread = new Thread(() => Functions.VectorAddition(0, zeroRow, zeroRow, ref array));
                    thread.Start();
                    threads[i] = thread;
                }

                foreach (Thread t in threads)
                    t.Join();

                matrixResult.setMatrixArray(array);
                stopWatch.Stop();
            }
            time = getTime(stopWatch);

        }
        /// <summary>
        /// Run substraction operation in C#
        /// </summary>
        public void RunSubstractionCSharp()
        {
            matrixResult = new Matrix(matrixA.rowNumber, matrixA.columnNumber);
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();


            //List<Thread> threads = new List<Thread>();
            Thread[] threads = new Thread[numberOfThreads];

            double[,] array = new double[matrixA.rowNumber, matrixA.columnNumber];


            if (matrixA.rowNumber == numberOfThreads)
            {
                for (int i = 0; i < matrixA.rowNumber; i++)
                {
                    int i2 = i;
                    double[] x = matrixA.GetRow(i2);
                    double[] y = matrixB.GetRow(i2);
                    Thread thread = new Thread(() => Functions.VectorAddition(i2, x, y, ref array));
                    thread.Start();
                    threads[i] = thread;
                }

                foreach (Thread t in threads)
                    t.Join();

                matrixResult.setMatrixArray(array);
                stopWatch.Stop();
            }
            else if (matrixA.rowNumber > numberOfThreads)
            {
                for (int i = 0; i < matrixA.rowNumber; i++)
                {
                    int i2 = i;
                    double[] x = matrixA.GetRow(i2);
                    double[] y = matrixB.GetRow(i2);
                    Thread thread = new Thread(() => Functions.VectorAddition(i2, x, y, ref array));
                    thread.Start();
                    threads[i % numberOfThreads] = thread;
                }

                foreach (Thread t in threads)
                    t.Join();

                matrixResult.setMatrixArray(array);
                stopWatch.Stop();
            }
            else if (matrixA.rowNumber < numberOfThreads)
            {

                for (int i = 0; i < matrixA.rowNumber; i++)
                {
                    int i2 = i;
                    double[] x = matrixA.GetRow(i2);
                    double[] y = matrixB.GetRow(i2);
                    Thread thread = new Thread(() => Functions.VectorSubstraction(i2, x, y, ref array));
                    thread.Start();
                    threads[i] = thread;
                }

                double[] zeroRow = new double[matrixA.columnNumber];
                for (int i = matrixA.rowNumber; i < numberOfThreads; i++)
                {

                    Thread thread = new Thread(() => Functions.VectorSubstraction(0, zeroRow, zeroRow, ref array));
                    thread.Start();
                    threads[i] = thread;
                }

                foreach (Thread t in threads)
                    t.Join();

                matrixResult.setMatrixArray(array);
                stopWatch.Stop();
            }
            time = getTime(stopWatch);

        }
        /// <summary>
        /// Run multiplication operation in C#
        /// </summary>
        public void RunMultiplicationCSharp()
        {

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            matrixResult = new Matrix(matrixA.rowNumber, matrixB.columnNumber);

            //List<Thread> threads = new List<Thread>();
            Thread[] threads = new Thread[numberOfThreads];

            double[,] array = new double[matrixA.rowNumber, matrixB.columnNumber];
            double[,] array2 = new double[matrixA.rowNumber, matrixB.columnNumber];

            if (matrixA.rowNumber * matrixB.columnNumber == numberOfThreads)
            {
                for (int i2 = 0; i2 < matrixA.rowNumber * matrixB.columnNumber; i2++)
                {
                    int i = i2 / matrixB.columnNumber;
                    int j = i2 % matrixB.columnNumber;
                    double[] x = matrixA.GetRow(i);
                    double[] y = matrixB.GetColumn(j);
                    Thread thread = new Thread(() => Functions.VectorMultiplication(i, j, x, y, ref array));
                    thread.Start();
                    threads[i2] = thread;
                }

                foreach (Thread t in threads)
                    t.Join();

                matrixResult.setMatrixArray(array);
                stopWatch.Stop();
            }
            else if (matrixA.rowNumber * matrixB.columnNumber > numberOfThreads)
            {
                for (int i2 = 0; i2 < matrixA.rowNumber * matrixB.columnNumber; i2++)
                {
                    int i = i2 / matrixB.columnNumber;
                    int j = i2 % matrixB.columnNumber;
                    double[] x = matrixA.GetRow(i);
                    double[] y = matrixB.GetColumn(j);
                    Thread thread = new Thread(() => Functions.VectorMultiplication(i, j, x, y, ref array));
                    thread.Start();
                    threads[i2 % numberOfThreads] = thread;
                }

                foreach (Thread t in threads)
                    t.Join();

                matrixResult.setMatrixArray(array);
                stopWatch.Stop();

            }
            else if (matrixA.rowNumber * matrixB.columnNumber < numberOfThreads)
            {

                for (int i2 = 0; i2 < matrixA.rowNumber * matrixB.columnNumber; i2++)
                {
                    int i = i2 / matrixB.columnNumber;
                    int j = i2 % matrixB.columnNumber;
                    double[] x = matrixA.GetRow(i);
                    double[] y = matrixB.GetColumn(j);
                    Thread thread = new Thread(() => Functions.VectorMultiplication(i, j, x, y, ref array));
                    thread.Start();
                    threads[i2] = thread;
                }

                for (int i = matrixA.rowNumber * matrixB.columnNumber; i < numberOfThreads; i++)
                {

                    Thread thread = new Thread(() => Functions.VectorMultiplication(0, 0, matrixA.GetRow(0), matrixB.GetColumn(0), ref array2));
                    thread.Start();
                    threads[i] = thread;
                }

                foreach (Thread t in threads)
                    t.Join();

                matrixResult.setMatrixArray(array);
                stopWatch.Stop();
            }


            time = getTime(stopWatch);


        }
        /// <summary>
        /// Method to get String with time
        /// </summary>
        /// <returns>time string value</returns>
        public String getTime()
        {
            return time;
        }

        /// <summary>
        /// Method to count the result of the multipliction in assembly
        /// </summary>
        public void RunMultiplicationAsm()
        {
           
            double[,] resultArray = new double[matrixA.rowNumber,matrixB.columnNumber]; //array for the result matrix

            Stopwatch stopwatch = new Stopwatch(); //timer to count time
            stopwatch.Start(); //  start timer

           Parallel.For(0, matrixA.rowNumber * matrixB.columnNumber, new ParallelOptions { MaxDegreeOfParallelism = numberOfThreads }, index =>
                 {
                 
                     int i = index % matrixB.columnNumber; //count index for matrix A
                     int j = index / matrixB.columnNumber; //count index form matrix B
                     Double[] matrixAArray = matrixA.GetRow(i); //  get row from matrix A
                     Double[] matrixBArray = matrixB.GetColumn(j); // get column from matrix B
                     IntPtr ptrA = Marshal.AllocHGlobal(sizeof(Double) * matrixAArray.Length); //alloc memory for matrix A row
                     IntPtr ptrB = Marshal.AllocHGlobal(sizeof(Double) * matrixBArray.Length); //alloc memory for matrix B row
                     Marshal.Copy(matrixAArray, 0, ptrA, matrixAArray.Length); // copy matrix A row
                     Marshal.Copy(matrixBArray, 0, ptrB, matrixBArray.Length); // copy matrix B row
                     resultArray[i,j] = AsmMultiplyProc(matrixAArray.Length, ptrA, ptrB); // multiply matrix A row and matrix B row
                     //save result to the array
                 });
            stopwatch.Stop(); //stop timer
            String result = " "; //prepare string for result matrix;

            for (int i = 0; i < matrixA.rowNumber; i++)
            {
               for(int j=0; j<matrixB.columnNumber; j++)
                result =result+resultArray[i,j].ToString() + " ";
                result = result + "\n";
            }
            resArrayStringToSave = result; // save result
            time = getTime(stopwatch); // get elapsed time from the stopwatch
        }

      

        /// <summary>
        /// Method to count substraction result in assembly
        /// </summary>
        public void RunSubstractionAsm()
        {
            double[][] results = new double[matrixA.rowNumber][];
            IntPtr[] resultPtrArray = new IntPtr[matrixA.rowNumber];
            String resultStringToSend = "";
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Parallel.For(0, matrixA.rowNumber, new ParallelOptions { MaxDegreeOfParallelism = numberOfThreads }, index =>
            {

                int i = index; //row number
                results[i] = new double[matrixA.columnNumber];
                Double[] matrixAArray = matrixA.GetRow(i); //get row from matrix A
                Double[] matrixBArray = matrixB.GetRow(i); //get row from matrix B
                IntPtr ptrA = Marshal.AllocHGlobal(sizeof(Double) * matrixAArray.Length); //alloc memory for row A
                IntPtr ptrB = Marshal.AllocHGlobal(sizeof(Double) * matrixBArray.Length); //alloc memory for row B
                resultPtrArray[i] = Marshal.AllocHGlobal(sizeof(Double) * matrixAArray.Length); //alloc memory for result
                Marshal.Copy(matrixAArray, 0, ptrA, matrixAArray.Length); //copy row A
                Marshal.Copy(matrixBArray, 0, ptrB, matrixBArray.Length); //copy row B   
                AsmSubProc(matrixA.columnNumber * sizeof(double), ptrA, ptrB, resultPtrArray[i]); //table of pointers to rows with results
                Marshal.Copy(resultPtrArray[i], results[i], 0, matrixAArray.Length);

            });
            stopwatch.Stop();
            for (int i = 0; i < matrixA.rowNumber; i++)
            {
                String rowResultString = "";
                for (int j = 0; j < results[i].Length; j++)
                {
                    rowResultString = rowResultString + results[i][j].ToString() + " ";
                }
                resultStringToSend = resultStringToSend + rowResultString + "\n";
            }
            resArrayStringToSave = resultStringToSend;
            time = getTime(stopwatch);
        }
        /// <summary>
        /// Method to count addition result in assembly
        /// </summary>
        public void RunAdditionAsm()
        {
            double[][] results = new double[matrixA.rowNumber][]; //Create array of result rows
            IntPtr[] resultPtrArray = new IntPtr[matrixA.rowNumber]; // pointers to rows
            String resultStringToSend = ""; // string for the result matrix to save to the file
            Stopwatch stopwatch = new Stopwatch(); 
            stopwatch.Start(); //start counting time of the operation
            Parallel.For(0, matrixA.rowNumber, new ParallelOptions { MaxDegreeOfParallelism = numberOfThreads }, index =>
            {

                int i = index; //row number
                results[i] = new double[matrixA.columnNumber]; // prepare array for the result row
                Double[] matrixAArray = matrixA.GetRow(i); //get row from matrix A
                Double[] matrixBArray = matrixB.GetRow(i); //get row from matrix B
                IntPtr ptrA = Marshal.AllocHGlobal(sizeof(Double) * matrixAArray.Length); //alloc memory for row A
                IntPtr ptrB = Marshal.AllocHGlobal(sizeof(Double) * matrixBArray.Length); //alloc memory for row B
                resultPtrArray[i] = Marshal.AllocHGlobal(sizeof(Double) * matrixAArray.Length); //alloc memory for result
                Marshal.Copy(matrixAArray, 0, ptrA, matrixAArray.Length); //copy row A
                Marshal.Copy(matrixBArray, 0, ptrB, matrixBArray.Length); //copy row B   
                AsmAddProc(matrixA.columnNumber * sizeof(double), ptrA, ptrB, resultPtrArray[i]); //table of pointers to rows with results
                Marshal.Copy(resultPtrArray[i], results[i], 0, matrixAArray.Length); //copy result to the array
            });
            stopwatch.Stop(); //stop time

            //Prepare matrix result to send it to the file
            for (int i = 0; i < matrixA.rowNumber; i++)
            {
                String rowResultString = "";
                for (int j = 0; j < results[i].Length; j++)
                {
                    rowResultString = rowResultString + results[i][j].ToString() + " ";
                }
                resultStringToSend = resultStringToSend + rowResultString + "\n";
            }

            resArrayStringToSave = resultStringToSend; //resArrayStringToSave will be send to the file in the last step
            time = getTime(stopwatch); //get elapsed time as a string
        }

  
        /// <summary>
        /// Method to get time in String format from the StopWatch
        /// </summary>
        /// <param name="stopWatch">StopWatch</param>
        /// <returns></returns>
        public String getTime(Stopwatch stopWatch)
        {
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = ts.Milliseconds.ToString();
            if (asm)
            {
                elapsedTime = ts.Ticks.ToString() + " ticks\n";
                elapsedTime = elapsedTime+ts.Milliseconds.ToString() + " miliseconds";
            }
            if (csharp)
            {
                elapsedTime = ts.Milliseconds.ToString();
                elapsedTime = elapsedTime + " miliseconds";
            }
                return elapsedTime;
        }

      
        /// <summary>
        /// Method to generate random matrices
        /// </summary>
        /// <param name="rowsA">number of rows (matrix A)</param>
        /// <param name="colA">number of colums (matrix A)</param>
        /// <param name="rowsB">number of rows (matrix B)</param>
        /// <param name="colB">number of colums (matrix B)</param>
        public void GenerateRandomMatrices(int rowsA, int colA, int rowsB, int colB)
        {
            matrixA = new Matrix(rowsA, colA);
            matrixA.generateRandomMatrix();
            matrixB = new Matrix(rowsB, colB);
            matrixB.generateRandomMatrix();
     
        }









        /// <summary>
        /// Method to test dll
        /// </summary>
        public void TestDll()
        {
            double[] test = { 0 };
            IntPtr ptrTest1 = Marshal.AllocHGlobal(sizeof(Double));
            IntPtr ptrTest2 = Marshal.AllocHGlobal(sizeof(Double));
            IntPtr ptrTest3 = Marshal.AllocHGlobal(sizeof(Double));
            Marshal.Copy(test, 0, ptrTest1,test.Length); 
            Marshal.Copy(test, 0, ptrTest2,test.Length); 
            Marshal.Copy(test, 0, ptrTest2,test.Length); 
            AsmAddProc(sizeof(Double), ptrTest1, ptrTest2, ptrTest3);
            Marshal.FreeHGlobal(ptrTest1);
            Marshal.FreeHGlobal(ptrTest2);
            Marshal.FreeHGlobal(ptrTest3);


        }



    }
    }  
