using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixCSharpLibrary
{
    /// <summary>
    /// Class with functions to add, substract and multiply matrices 
    /// </summary>
    public class Functions
    {

        /// <summary>
        /// Function to add two vectors
        /// </summary>
        /// <param name="i">number of row</param>
        /// <param name="aRow">row from matrix A</param>
        /// <param name="bRow">row from matrix B</param>
        /// <param name="result">result matrix</param>
        public static void VectorAddition(int i, double[] aRow, double[] bRow, ref double[,] result)
        {
            for (int j = 0; j < aRow.Length; j++)
                result[i, j] += aRow[j] + bRow[j];
        }

        /// <summary>
        /// Function to substract two vectors
        /// </summary>
        /// <param name="i">number of row</param>
        /// <param name="aRow">row from matrix A</param>
        /// <param name="bRow">row from matrix B</param>
        /// <param name="result">result matrix</param>
        public static void VectorSubstraction(int i, double[] aRow, double[] bRow, ref double[,] result)
        {
            for (int j = 0; j < aRow.Length; j++)
                result[i, j] += aRow[j] - bRow[j];
        }

        /// <summary>
        /// Multipication of two vectors
        /// </summary>
        /// <param name="i">row index</param>
        /// <param name="j">column index</param>
        /// <param name="aRow">row from matrix A</param>
        /// <param name="bColumn">column from matrix B</param>
        /// <param name="result">result matrix</param>
            public static void VectorMultiplication(int i, int j, double[] aRow, double[] bColumn, ref double[,] result)
        {   
            for (int k = 0; k < aRow.Length; k++)
                result[i, j] += aRow[k] * bColumn[k];
        }
  
    }
}
