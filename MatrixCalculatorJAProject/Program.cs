using System;

namespace MatrixCalculatorJAProject
{
    class Program
    {
        [System.Runtime.InteropServices.DllImport(@"C:\Users\julia\source\repos\MatrixCalculatorJAProject\x64\Debug\LibraryAsm.dll")]
        public static extern int MyProc1(int x, int y);
        static void Main(string[] args)
        {
            int z = MyProc1(40, 40);
            System.Console.WriteLine(z);
        }
    }
}
