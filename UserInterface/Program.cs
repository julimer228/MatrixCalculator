/* ------Projekt jêzyki assemblerowe--------------------------------------------
 Rok akademicki 2021/2022
 Prowadz¹cy: mgr.in¿.Krzysztof Hanzel
 Autorka: Julia Merta
 Grupa: 5
 Sekcja: 1
 Temat projektu: Kalkulator macierzy
 Program ma realizowaæ podstawowe operacje takie jak dodawanie macierzy,
 odejmowanie macierzy oraz mno¿enie macierzy. 
; -----------------------------------------------------------------------------
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 

        
        [STAThread]
        static void Main()
        {
            MatrixOprerationsControler matrixOprerationsControler = new MatrixOprerationsControler();
            
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MatrixCalculator());
        }
    }
}
