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
using System.Text;
using System.Threading;

namespace UserInterface
{
    /// <summary>
    /// Matrix
    /// </summary>
    class Matrix
    {
        /// <summary>
        /// Number of rows
        /// </summary>
        public int rowNumber { get; set; }
        /// <summary>
        /// Number of colums
        /// </summary>
        public int columnNumber { get; set; }
        /// <summary>
        /// Matrix array
        /// </summary>
        double[,] matrixArray;
        /// <summary>
        /// default constructor
        /// </summary>
        Matrix() { }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="row">number of rows</param>
        /// <param name="column">number of colums</param>
        public Matrix(int row, int column)
        {
            rowNumber = row;
            columnNumber = column;
            matrixArray = new double[row, column];
        }
        /// <summary>
        /// Gets the column
        /// </summary>
        /// <param name="i">number of a column to get</param>
        /// <returns>the array</returns>
        public double[] GetColumn(int i)
        {
           double[] res = new double[rowNumber];
            for (int j = 0; j < rowNumber; j++)
                res[j] = matrixArray[j, i];
            return res;
        }

        /// <summary>
        /// Gets the row
        /// </summary>
        /// <param name="i">number of the row</param>
        /// <returns>the array</returns>
        public double[] GetRow(int i)
        {
            double[] res = new double[columnNumber];
            for (int j = 0; j < columnNumber; j++)
                res[j] = matrixArray[i, j];
            return res;
        }
        /// <summary>
        /// Gets the element in row i and column j
        /// </summary>
        /// <param name="i">row index</param>
        /// <param name="j">column index</param>
        /// <returns>the element</returns>
        public double this[int i, int j]
        {
            get { return matrixArray[i, j]; }
            set { matrixArray[i, j] = value; }
        }

        /// <summary>
        /// Set the matrix array
        /// </summary>
        /// <param name="array">array</param>
        public void setMatrixArray(double[,] array)
        {
            this.matrixArray = array;
        }
     
        /// <summary>
        /// Gets matrix array
        /// </summary>
        /// <returns>array</returns>
        public double[,] getMatrixArray()
        {
            return this.matrixArray;
        }
        
        /// <summary>
        /// Method to print the matrix
        /// </summary>
        /// <returns>matrix as a string</returns>
        public String Print()
        {
            String result = "";
            for (int i = 0; i < rowNumber; i++)
            {
                for (int j = 0; j <columnNumber; j++)
                    result=String.Concat(result,matrixArray[i, j] + " ");
                result = String.Concat(result, "\n");
            }
            return result;
        }

        /// <summary>
        /// Method to generate random matrix (to create data for the raport)
        /// </summary>
        public void generateRandomMatrix()
        {
            var rand = new Random();

            for(int i=0; i<rowNumber; i++)
            {
                for(int j=0; j<columnNumber; j++)
                {
                    this[i, j] = rand.NextDouble()*1000;
                }
            }
        }

    }
}

