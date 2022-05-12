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

    partial class MatrixCalculator
    {

       /// <summary>
       /// Controler to handle operations
       /// </summary>
        MatrixOprerationsControler matrixOprerationsControler = new MatrixOprerationsControler();

        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MatrixCalculator));
            this.checkBoxAsm = new System.Windows.Forms.CheckBox();
            this.checkBoxCSharp = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.resultFilepathBox = new System.Windows.Forms.TextBox();
            this.matrixAfilepathBox = new System.Windows.Forms.TextBox();
            this.matrixBfilepathBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.opertionBox = new System.Windows.Forms.ComboBox();
            this.Operation = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.calculateButton = new System.Windows.Forms.Button();
            this.numberOfthreadsTrackBar = new System.Windows.Forms.TrackBar();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.ColB = new System.Windows.Forms.NumericUpDown();
            this.RowsB = new System.Windows.Forms.NumericUpDown();
            this.RowsA = new System.Windows.Forms.NumericUpDown();
            this.ColA = new System.Windows.Forms.NumericUpDown();
            this.generateButton = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.timeCSharpLabel = new System.Windows.Forms.Label();
            this.timeAsmLabel = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfthreadsTrackBar)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ColB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RowsB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RowsA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColA)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxAsm
            // 
            this.checkBoxAsm.AutoSize = true;
            this.checkBoxAsm.Location = new System.Drawing.Point(590, 183);
            this.checkBoxAsm.Name = "checkBoxAsm";
            this.checkBoxAsm.Size = new System.Drawing.Size(94, 24);
            this.checkBoxAsm.TabIndex = 0;
            this.checkBoxAsm.Text = "Assembly";
            this.checkBoxAsm.UseVisualStyleBackColor = true;
            this.checkBoxAsm.CheckedChanged += new System.EventHandler(this.checkBoxAsm_CheckedChanged);
            // 
            // checkBoxCSharp
            // 
            this.checkBoxCSharp.AutoSize = true;
            this.checkBoxCSharp.Location = new System.Drawing.Point(590, 216);
            this.checkBoxCSharp.Name = "checkBoxCSharp";
            this.checkBoxCSharp.Size = new System.Drawing.Size(49, 24);
            this.checkBoxCSharp.TabIndex = 1;
            this.checkBoxCSharp.Text = "C#";
            this.checkBoxCSharp.UseVisualStyleBackColor = true;
            this.checkBoxCSharp.CheckedChanged += new System.EventHandler(this.checkBoxCSharp_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Matrix A:";
            // 
            // resultFilepathBox
            // 
            this.resultFilepathBox.Location = new System.Drawing.Point(111, 189);
            this.resultFilepathBox.Name = "resultFilepathBox";
            this.resultFilepathBox.Size = new System.Drawing.Size(427, 27);
            this.resultFilepathBox.TabIndex = 4;
            this.resultFilepathBox.TextChanged += new System.EventHandler(this.resultFilepathBox_TextChanged);
            // 
            // matrixAfilepathBox
            // 
            this.matrixAfilepathBox.Location = new System.Drawing.Point(111, 123);
            this.matrixAfilepathBox.Name = "matrixAfilepathBox";
            this.matrixAfilepathBox.Size = new System.Drawing.Size(427, 27);
            this.matrixAfilepathBox.TabIndex = 5;
            this.matrixAfilepathBox.Text = "\r\n";
            this.matrixAfilepathBox.TextChanged += new System.EventHandler(this.matrixAfilepathBox_TextChanged);
            // 
            // matrixBfilepathBox
            // 
            this.matrixBfilepathBox.Location = new System.Drawing.Point(111, 156);
            this.matrixBfilepathBox.Name = "matrixBfilepathBox";
            this.matrixBfilepathBox.Size = new System.Drawing.Size(427, 27);
            this.matrixBfilepathBox.TabIndex = 6;
            this.matrixBfilepathBox.Text = "\r\n";
            this.matrixBfilepathBox.TextChanged += new System.EventHandler(this.matrixBfilepathBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Matrix B:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Result:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.MenuBar;
            this.label5.Font = new System.Drawing.Font("Arial Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(446, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(231, 32);
            this.label5.TabIndex = 9;
            this.label5.Text = "Matrix Calculator";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(481, 320);
            this.label6.TabIndex = 10;
            this.label6.Text = resources.GetString("label6.Text");
            // 
            // opertionBox
            // 
            this.opertionBox.FormattingEnabled = true;
            this.opertionBox.Items.AddRange(new object[] {
            "Addition",
            "Substraction",
            "Multiplication"});
            this.opertionBox.Location = new System.Drawing.Point(111, 222);
            this.opertionBox.Name = "opertionBox";
            this.opertionBox.Size = new System.Drawing.Size(427, 28);
            this.opertionBox.TabIndex = 11;
            this.opertionBox.SelectedIndexChanged += new System.EventHandler(this.opertionBox_SelectedIndexChanged);
            // 
            // Operation
            // 
            this.Operation.AutoSize = true;
            this.Operation.Location = new System.Drawing.Point(27, 225);
            this.Operation.Name = "Operation";
            this.Operation.Size = new System.Drawing.Size(79, 20);
            this.Operation.TabIndex = 12;
            this.Operation.Text = "Operation:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(910, 412);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 20);
            this.label7.TabIndex = 13;
            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(59, 273);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(282, 29);
            this.calculateButton.TabIndex = 14;
            this.calculateButton.Text = "Calculate";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
            // 
            // numberOfthreadsTrackBar
            // 
            this.numberOfthreadsTrackBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.numberOfthreadsTrackBar.Location = new System.Drawing.Point(111, 60);
            this.numberOfthreadsTrackBar.Maximum = 64;
            this.numberOfthreadsTrackBar.Minimum = 1;
            this.numberOfthreadsTrackBar.Name = "numberOfthreadsTrackBar";
            this.numberOfthreadsTrackBar.Size = new System.Drawing.Size(374, 56);
            this.numberOfthreadsTrackBar.TabIndex = 20;
            this.numberOfthreadsTrackBar.Value = 1;
            this.numberOfthreadsTrackBar.Scroll += new System.EventHandler(this.numberOfthreadsTrackBar_Scroll);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(236, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(134, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "Number of threads";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.ColB);
            this.groupBox1.Controls.Add(this.RowsB);
            this.groupBox1.Controls.Add(this.RowsA);
            this.groupBox1.Controls.Add(this.ColA);
            this.groupBox1.Controls.Add(this.generateButton);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numberOfthreadsTrackBar);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.resultFilepathBox);
            this.groupBox1.Controls.Add(this.calculateButton);
            this.groupBox1.Controls.Add(this.checkBoxCSharp);
            this.groupBox1.Controls.Add(this.Operation);
            this.groupBox1.Controls.Add(this.checkBoxAsm);
            this.groupBox1.Controls.Add(this.matrixAfilepathBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.matrixBfilepathBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.opertionBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(592, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(697, 381);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Setup";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(572, 273);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(58, 20);
            this.label18.TabIndex = 34;
            this.label18.Text = "Colums";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(466, 273);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(44, 20);
            this.label17.TabIndex = 33;
            this.label17.Text = "Rows";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(371, 338);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(67, 20);
            this.label16.TabIndex = 32;
            this.label16.Text = "Matrix B:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(371, 298);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(68, 20);
            this.label15.TabIndex = 31;
            this.label15.Text = "Matrix A:";
            // 
            // ColB
            // 
            this.ColB.Location = new System.Drawing.Point(553, 336);
            this.ColB.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ColB.Name = "ColB";
            this.ColB.Size = new System.Drawing.Size(102, 27);
            this.ColB.TabIndex = 30;
            this.ColB.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // RowsB
            // 
            this.RowsB.Location = new System.Drawing.Point(445, 336);
            this.RowsB.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RowsB.Name = "RowsB";
            this.RowsB.Size = new System.Drawing.Size(102, 27);
            this.RowsB.TabIndex = 29;
            this.RowsB.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // RowsA
            // 
            this.RowsA.Location = new System.Drawing.Point(445, 296);
            this.RowsA.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RowsA.Name = "RowsA";
            this.RowsA.Size = new System.Drawing.Size(102, 27);
            this.RowsA.TabIndex = 28;
            this.RowsA.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ColA
            // 
            this.ColA.Location = new System.Drawing.Point(553, 294);
            this.ColA.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ColA.Name = "ColA";
            this.ColA.Size = new System.Drawing.Size(102, 27);
            this.ColA.TabIndex = 27;
            this.ColA.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(62, 312);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(279, 56);
            this.generateButton.TabIndex = 26;
            this.generateButton.Text = "Generate \r\nand calculate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(368, 96);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(25, 20);
            this.label12.TabIndex = 25;
            this.label12.Text = "48";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(193, 96);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 20);
            this.label11.TabIndex = 24;
            this.label11.Text = "16";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(277, 96);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 20);
            this.label10.TabIndex = 23;
            this.label10.Text = "32";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(454, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(25, 20);
            this.label9.TabIndex = 22;
            this.label9.Text = "64";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(21, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(554, 471);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Instruction";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.timeCSharpLabel);
            this.groupBox3.Controls.Add(this.timeAsmLabel);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Location = new System.Drawing.Point(595, 451);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(694, 84);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Time";
            // 
            // timeCSharpLabel
            // 
            this.timeCSharpLabel.AutoSize = true;
            this.timeCSharpLabel.Location = new System.Drawing.Point(500, 43);
            this.timeCSharpLabel.Name = "timeCSharpLabel";
            this.timeCSharpLabel.Size = new System.Drawing.Size(93, 20);
            this.timeCSharpLabel.TabIndex = 3;
            this.timeCSharpLabel.Text = "Not selected";
            // 
            // timeAsmLabel
            // 
            this.timeAsmLabel.AutoSize = true;
            this.timeAsmLabel.Location = new System.Drawing.Point(207, 43);
            this.timeAsmLabel.Name = "timeAsmLabel";
            this.timeAsmLabel.Size = new System.Drawing.Size(93, 20);
            this.timeAsmLabel.TabIndex = 2;
            this.timeAsmLabel.Text = "Not selected";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(427, 43);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 20);
            this.label14.TabIndex = 1;
            this.label14.Text = "Time C#:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(85, 43);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(110, 20);
            this.label13.TabIndex = 0;
            this.label13.Text = "Time assembly:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(21, -1);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1599, 66);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            // 
            // MatrixCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1311, 555);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.Name = "MatrixCalculator";
            this.Text = "Matrix Calculator";
            ((System.ComponentModel.ISupportInitialize)(this.numberOfthreadsTrackBar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ColB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RowsB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RowsA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColA)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxAsm;
        private System.Windows.Forms.CheckBox checkBoxCSharp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox resultFilepathBox;
        private System.Windows.Forms.TextBox matrixAfilepathBox;
        private System.Windows.Forms.TextBox matrixBfilepathBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox opertionBox;
        private System.Windows.Forms.Label Operation;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.TrackBar numberOfthreadsTrackBar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label timeCSharpLabel;
        private System.Windows.Forms.Label timeAsmLabel;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown ColB;
        private System.Windows.Forms.NumericUpDown RowsB;
        private System.Windows.Forms.NumericUpDown RowsA;
        private System.Windows.Forms.NumericUpDown ColA;
        private System.Windows.Forms.Label label18;
        //private System.Windows.Forms.Button button1;
        //private System.Windows.Forms.Button AsmTestButton;
        //private System.Windows.Forms.Label AsmTestLabel;
    }
}

