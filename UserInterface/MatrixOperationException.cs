using System;
using System.Collections.Generic;
using System.Text;

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

namespace UserInterface
{
    /// <summary>
    /// The exception
    /// </summary>
    class MatrixOperationException : Exception
    {
        public MatrixOperationException(string message) : base(message)
        {
        }
    }
}
