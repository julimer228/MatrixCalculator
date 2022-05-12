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
using System.Windows.Forms;

namespace UserInterface
{
    public partial class MatrixCalculator : Form
    {
        /// <summary>
        /// Method to set up the matrix calclulator controller
        /// </summary>
        public MatrixCalculator()
        {
            InitializeComponent();


            numberOfthreadsTrackBar.Value = Environment.ProcessorCount;
            matrixOprerationsControler.SetNumberOfThreads(numberOfthreadsTrackBar.Value);
            matrixOprerationsControler.SetfilepathA(matrixAfilepathBox.Text);
            matrixOprerationsControler.SetfilepathB(matrixBfilepathBox.Text);
            matrixOprerationsControler.SetfilepathResult(resultFilepathBox.Text);
        }

        /// <summary>
        /// Function to set number of threads
        /// </summary>
        /// <param name="sender"> sender</param>
        /// <param name="e">event</param>
        private void numberOfthreadsTrackBar_Scroll(object sender, EventArgs e)
        {
            matrixOprerationsControler.SetNumberOfThreads(numberOfthreadsTrackBar.Value);
        }



        /// <summary>
        /// Function to update the filepath
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
      
        private void matrixAfilepathBox_TextChanged(object sender, EventArgs e)
        {
            matrixOprerationsControler.SetfilepathA(matrixAfilepathBox.Text);
        }

        /// <summary>
        /// Function to update the filepath
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        private void resultFilepathBox_TextChanged(object sender, EventArgs e)
        {
            matrixOprerationsControler.SetfilepathResult(resultFilepathBox.Text);
        }

        /// <summary>
        /// Function to update the filepath
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        private void matrixBfilepathBox_TextChanged(object sender, EventArgs e)
        {
            matrixOprerationsControler.SetfilepathB(matrixBfilepathBox.Text);
        }

        /// <summary>
        /// Function to update the operation 
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        private void opertionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            matrixOprerationsControler.LoadStringToOperation(opertionBox.Text);
        }

        /// <summary>
        /// Function to prepare data and perform an operation
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        private void calculateButton_Click(object sender, EventArgs e)
        {
          


            try
            {
                matrixOprerationsControler.LoadMatrices();
                matrixOprerationsControler.IsOperationPossible();

                  if (checkBoxCSharp.Checked && matrixOprerationsControler.getCSharpState())
                  {
                      matrixOprerationsControler.RunOperation();
                      timeCSharpLabel.Text = matrixOprerationsControler.getTime();
                      matrixOprerationsControler.SaveResultMatrix();
                  }
                  if (checkBoxAsm.Checked && matrixOprerationsControler.getAsmState())
                  {
                      matrixOprerationsControler.RunOperation();
                      timeAsmLabel.Text = matrixOprerationsControler.getTime();
                      matrixOprerationsControler.SaveResultMatrix();
                  }

            }catch(MatrixOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }



        }

        /// <summary>
        /// Function to set language option
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void checkBoxAsm_CheckedChanged(object sender, EventArgs e)
        {
            matrixOprerationsControler.SetAsm(checkBoxAsm.Checked);

            if (checkBoxAsm.Checked)
            {
                timeAsmLabel.Text = "Selected";
                if (this.checkBoxCSharp.Checked)
                    this.checkBoxCSharp.Checked = false;
            }
            else timeAsmLabel.Text = "Not selected";
        }

        /// <summary>
        /// Function to set language option
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void checkBoxCSharp_CheckedChanged(object sender, EventArgs e)
        {
            matrixOprerationsControler.SetCsharp(checkBoxCSharp.Checked);
            if (checkBoxCSharp.Checked)
            {
                timeCSharpLabel.Text = "Selected";
                if (this.checkBoxAsm.Checked)
                    this.checkBoxAsm.Checked = false;
            }
            else timeCSharpLabel.Text = "Not selected";
        }

       
        /// <summary>
        /// Generate random matrices
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                int rowA = Convert.ToInt32(Math.Round(RowsA.Value, 0));
                int rowB = Convert.ToInt32(Math.Round(RowsB.Value, 0));
                int colA = Convert.ToInt32(Math.Round(ColA.Value, 0));
                int colB = Convert.ToInt32(Math.Round(ColB.Value, 0));
                matrixOprerationsControler.GenerateRandomMatrices(rowA, colA, rowB, colB);

                matrixOprerationsControler.IsOperationPossible();

                if (checkBoxCSharp.Checked && matrixOprerationsControler.getCSharpState())
                {
                    matrixOprerationsControler.RunOperation();
                    timeCSharpLabel.Text = matrixOprerationsControler.getTime();
                    matrixOprerationsControler.SaveResultMatrix();
                }
                if (checkBoxAsm.Checked && matrixOprerationsControler.getAsmState())
                {
                    matrixOprerationsControler.RunOperation();
                    timeAsmLabel.Text = matrixOprerationsControler.getTime();
                    matrixOprerationsControler.SaveResultMatrix();
                }
            }catch(MatrixOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }

        }

      
    }
}
