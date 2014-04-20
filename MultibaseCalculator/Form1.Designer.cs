using System.Security.AccessControl;
using System.Windows.Forms;

namespace MultibaseCalculator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.inputBox = new System.Windows.Forms.TextBox();
            this.btnBackspace = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btn7 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btnMemClear = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btnFlip = new System.Windows.Forms.Button();
            this.btnMemAdd = new System.Windows.Forms.Button();
            this.btnMemMin = new System.Windows.Forms.Button();
            this.btnMemRestore = new System.Windows.Forms.Button();
            this.btn0 = new System.Windows.Forms.Button();
            this.btnEvaluate = new System.Windows.Forms.Button();
            this.btnDot = new System.Windows.Forms.Button();
            this.btnCE = new System.Windows.Forms.Button();
            this.btnSign = new System.Windows.Forms.Button();
            this.btnPower = new System.Windows.Forms.Button();
            this.btnSqrt = new System.Windows.Forms.Button();
            this.btnC = new System.Windows.Forms.Button();
            this.btnDivide = new System.Windows.Forms.Button();
            this.btnMultiply = new System.Windows.Forms.Button();
            this.btnMinus = new System.Windows.Forms.Button();
            this.btnPlus = new System.Windows.Forms.Button();
            this.btnCloseBracket = new System.Windows.Forms.Button();
            this.btnOpenBracket = new System.Windows.Forms.Button();
            this.labelMemEnabled = new System.Windows.Forms.Label();
            this.labelBaseNumber = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // inputBox
            // 
            this.inputBox.AccessibleName = "Input";
            this.inputBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.inputBox.Enabled = false;
            this.inputBox.Font = new System.Drawing.Font("Arial Caps", 10.25F);
            this.inputBox.Location = new System.Drawing.Point(58, 9);
            this.inputBox.Name = "inputBox";
            this.inputBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.inputBox.Size = new System.Drawing.Size(178, 23);
            this.inputBox.TabIndex = 0;
            this.inputBox.Text = "0";
            this.inputBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.inputBox.WordWrap = false;
            // 
            // btnBackspace
            // 
            this.btnBackspace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackspace.ForeColor = System.Drawing.Color.Red;
            this.btnBackspace.Location = new System.Drawing.Point(242, 9);
            this.btnBackspace.Name = "btnBackspace";
            this.btnBackspace.Size = new System.Drawing.Size(40, 23);
            this.btnBackspace.TabIndex = 1;
            this.btnBackspace.TabStop = false;
            this.btnBackspace.Text = "BSPC";
            this.btnBackspace.UseVisualStyleBackColor = true;
            this.btnBackspace.Click += new System.EventHandler(this.btnBackspace_Click);
            // 
            // btn1
            // 
            this.btn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btn1.Location = new System.Drawing.Point(58, 125);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(40, 23);
            this.btn1.TabIndex = 17;
            this.btn1.TabStop = false;
            this.btn1.Text = "1";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn2
            // 
            this.btn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btn2.Location = new System.Drawing.Point(104, 125);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(40, 23);
            this.btn2.TabIndex = 18;
            this.btn2.TabStop = false;
            this.btn2.Text = "2";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // btn3
            // 
            this.btn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btn3.Location = new System.Drawing.Point(150, 125);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(40, 23);
            this.btn3.TabIndex = 19;
            this.btn3.TabStop = false;
            this.btn3.Text = "3";
            this.btn3.UseVisualStyleBackColor = true;
            this.btn3.Click += new System.EventHandler(this.btn3_Click);
            // 
            // btn4
            // 
            this.btn4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn4.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btn4.Location = new System.Drawing.Point(58, 96);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(40, 23);
            this.btn4.TabIndex = 20;
            this.btn4.TabStop = false;
            this.btn4.Text = "4";
            this.btn4.UseVisualStyleBackColor = true;
            this.btn4.Click += new System.EventHandler(this.btn4_Click);
            // 
            // btn5
            // 
            this.btn5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btn5.Location = new System.Drawing.Point(104, 96);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(40, 23);
            this.btn5.TabIndex = 21;
            this.btn5.TabStop = false;
            this.btn5.Text = "5";
            this.btn5.UseVisualStyleBackColor = true;
            this.btn5.Click += new System.EventHandler(this.btn5_Click);
            // 
            // btn6
            // 
            this.btn6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn6.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btn6.Location = new System.Drawing.Point(150, 96);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(40, 23);
            this.btn6.TabIndex = 22;
            this.btn6.TabStop = false;
            this.btn6.Text = "6";
            this.btn6.UseVisualStyleBackColor = true;
            this.btn6.Click += new System.EventHandler(this.btn6_Click);
            // 
            // btn7
            // 
            this.btn7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn7.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btn7.Location = new System.Drawing.Point(58, 67);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(40, 23);
            this.btn7.TabIndex = 23;
            this.btn7.TabStop = false;
            this.btn7.Text = "7";
            this.btn7.UseVisualStyleBackColor = true;
            this.btn7.Click += new System.EventHandler(this.btn7_Click);
            // 
            // btn8
            // 
            this.btn8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn8.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btn8.Location = new System.Drawing.Point(104, 67);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(40, 23);
            this.btn8.TabIndex = 24;
            this.btn8.TabStop = false;
            this.btn8.Text = "8";
            this.btn8.UseVisualStyleBackColor = true;
            this.btn8.Click += new System.EventHandler(this.btn8_Click);
            // 
            // btnMemClear
            // 
            this.btnMemClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMemClear.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnMemClear.Location = new System.Drawing.Point(12, 154);
            this.btnMemClear.Name = "btnMemClear";
            this.btnMemClear.Size = new System.Drawing.Size(40, 23);
            this.btnMemClear.TabIndex = 15;
            this.btnMemClear.TabStop = false;
            this.btnMemClear.Text = "MC";
            this.btnMemClear.UseVisualStyleBackColor = true;
            this.btnMemClear.Click += new System.EventHandler(this.btnMemClear_Click);
            // 
            // btn9
            // 
            this.btn9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn9.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btn9.Location = new System.Drawing.Point(150, 67);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(40, 23);
            this.btn9.TabIndex = 25;
            this.btn9.TabStop = false;
            this.btn9.Text = "9";
            this.btn9.UseVisualStyleBackColor = true;
            this.btn9.Click += new System.EventHandler(this.btn9_Click);
            // 
            // btnFlip
            // 
            this.btnFlip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFlip.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnFlip.Location = new System.Drawing.Point(150, 38);
            this.btnFlip.Name = "btnFlip";
            this.btnFlip.Size = new System.Drawing.Size(40, 23);
            this.btnFlip.TabIndex = 5;
            this.btnFlip.TabStop = false;
            this.btnFlip.Text = "1/x";
            this.btnFlip.UseVisualStyleBackColor = true;
            this.btnFlip.Click += new System.EventHandler(this.btnFlip_Click);
            // 
            // btnMemAdd
            // 
            this.btnMemAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMemAdd.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnMemAdd.Location = new System.Drawing.Point(12, 67);
            this.btnMemAdd.Name = "btnMemAdd";
            this.btnMemAdd.Size = new System.Drawing.Size(40, 23);
            this.btnMemAdd.TabIndex = 12;
            this.btnMemAdd.TabStop = false;
            this.btnMemAdd.Text = "M+";
            this.btnMemAdd.UseVisualStyleBackColor = true;
            this.btnMemAdd.Click += new System.EventHandler(this.btnMemAdd_Click);
            // 
            // btnMemMin
            // 
            this.btnMemMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMemMin.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnMemMin.Location = new System.Drawing.Point(12, 96);
            this.btnMemMin.Name = "btnMemMin";
            this.btnMemMin.Size = new System.Drawing.Size(40, 23);
            this.btnMemMin.TabIndex = 13;
            this.btnMemMin.TabStop = false;
            this.btnMemMin.Text = "M-";
            this.btnMemMin.UseVisualStyleBackColor = true;
            this.btnMemMin.Click += new System.EventHandler(this.btnMemMin_Click);
            // 
            // btnMemRestore
            // 
            this.btnMemRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMemRestore.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnMemRestore.Location = new System.Drawing.Point(12, 125);
            this.btnMemRestore.Name = "btnMemRestore";
            this.btnMemRestore.Size = new System.Drawing.Size(40, 23);
            this.btnMemRestore.TabIndex = 14;
            this.btnMemRestore.TabStop = false;
            this.btnMemRestore.Text = "MR";
            this.btnMemRestore.UseVisualStyleBackColor = true;
            this.btnMemRestore.Click += new System.EventHandler(this.btnMemRestore_Click);
            // 
            // btn0
            // 
            this.btn0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn0.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btn0.Location = new System.Drawing.Point(58, 154);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(40, 23);
            this.btn0.TabIndex = 16;
            this.btn0.TabStop = false;
            this.btn0.Text = "0";
            this.btn0.UseVisualStyleBackColor = true;
            this.btn0.Click += new System.EventHandler(this.btn0_Click);
            // 
            // btnEvaluate
            // 
            this.btnEvaluate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEvaluate.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnEvaluate.Location = new System.Drawing.Point(150, 154);
            this.btnEvaluate.Name = "btnEvaluate";
            this.btnEvaluate.Size = new System.Drawing.Size(132, 23);
            this.btnEvaluate.TabIndex = 27;
            this.btnEvaluate.TabStop = false;
            this.btnEvaluate.Text = "=";
            this.btnEvaluate.UseVisualStyleBackColor = true;
            this.btnEvaluate.Click += new System.EventHandler(this.btnEvaluate_Click);
            // 
            // btnDot
            // 
            this.btnDot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDot.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnDot.Location = new System.Drawing.Point(104, 154);
            this.btnDot.Name = "btnDot";
            this.btnDot.Size = new System.Drawing.Size(40, 23);
            this.btnDot.TabIndex = 26;
            this.btnDot.TabStop = false;
            this.btnDot.Text = ".";
            this.btnDot.UseVisualStyleBackColor = true;
            this.btnDot.Click += new System.EventHandler(this.btnDot_Click);
            // 
            // btnCE
            // 
            this.btnCE.Enabled = false;
            this.btnCE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCE.ForeColor = System.Drawing.Color.Red;
            this.btnCE.Location = new System.Drawing.Point(58, 38);
            this.btnCE.Name = "btnCE";
            this.btnCE.Size = new System.Drawing.Size(40, 23);
            this.btnCE.TabIndex = 3;
            this.btnCE.TabStop = false;
            this.btnCE.Text = "CE";
            this.btnCE.UseVisualStyleBackColor = true;
            this.btnCE.Click += new System.EventHandler(this.btnCE_Click);
            // 
            // btnSign
            // 
            this.btnSign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSign.ForeColor = System.Drawing.Color.Magenta;
            this.btnSign.Location = new System.Drawing.Point(242, 125);
            this.btnSign.Name = "btnSign";
            this.btnSign.Size = new System.Drawing.Size(40, 23);
            this.btnSign.TabIndex = 7;
            this.btnSign.TabStop = false;
            this.btnSign.Text = "+/-";
            this.btnSign.UseVisualStyleBackColor = true;
            this.btnSign.Click += new System.EventHandler(this.btnSign_Click);
            // 
            // btnPower
            // 
            this.btnPower.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPower.ForeColor = System.Drawing.Color.Magenta;
            this.btnPower.Location = new System.Drawing.Point(242, 96);
            this.btnPower.Name = "btnPower";
            this.btnPower.Size = new System.Drawing.Size(40, 23);
            this.btnPower.TabIndex = 6;
            this.btnPower.TabStop = false;
            this.btnPower.Text = "^";
            this.btnPower.UseVisualStyleBackColor = true;
            this.btnPower.Click += new System.EventHandler(this.btnPower_Click);
            // 
            // btnSqrt
            // 
            this.btnSqrt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSqrt.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnSqrt.Location = new System.Drawing.Point(104, 38);
            this.btnSqrt.Name = "btnSqrt";
            this.btnSqrt.Size = new System.Drawing.Size(40, 23);
            this.btnSqrt.TabIndex = 4;
            this.btnSqrt.TabStop = false;
            this.btnSqrt.Text = "sqrt";
            this.btnSqrt.UseVisualStyleBackColor = true;
            this.btnSqrt.Click += new System.EventHandler(this.btnSqrt_Click);
            // 
            // btnC
            // 
            this.btnC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnC.ForeColor = System.Drawing.Color.Red;
            this.btnC.Location = new System.Drawing.Point(12, 38);
            this.btnC.Name = "btnC";
            this.btnC.Size = new System.Drawing.Size(40, 23);
            this.btnC.TabIndex = 2;
            this.btnC.TabStop = false;
            this.btnC.Text = "C";
            this.btnC.UseVisualStyleBackColor = true;
            this.btnC.Click += new System.EventHandler(this.btnC_Click);
            // 
            // btnDivide
            // 
            this.btnDivide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDivide.ForeColor = System.Drawing.Color.Magenta;
            this.btnDivide.Location = new System.Drawing.Point(196, 125);
            this.btnDivide.Name = "btnDivide";
            this.btnDivide.Size = new System.Drawing.Size(40, 23);
            this.btnDivide.TabIndex = 11;
            this.btnDivide.TabStop = false;
            this.btnDivide.Text = "/";
            this.btnDivide.UseVisualStyleBackColor = true;
            this.btnDivide.Click += new System.EventHandler(this.btnDivide_Click);
            // 
            // btnMultiply
            // 
            this.btnMultiply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMultiply.ForeColor = System.Drawing.Color.Magenta;
            this.btnMultiply.Location = new System.Drawing.Point(196, 67);
            this.btnMultiply.Name = "btnMultiply";
            this.btnMultiply.Size = new System.Drawing.Size(40, 23);
            this.btnMultiply.TabIndex = 9;
            this.btnMultiply.TabStop = false;
            this.btnMultiply.Text = "*";
            this.btnMultiply.UseVisualStyleBackColor = true;
            this.btnMultiply.Click += new System.EventHandler(this.btnMultiply_Click);
            // 
            // btnMinus
            // 
            this.btnMinus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinus.ForeColor = System.Drawing.Color.Magenta;
            this.btnMinus.Location = new System.Drawing.Point(196, 96);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(40, 23);
            this.btnMinus.TabIndex = 10;
            this.btnMinus.TabStop = false;
            this.btnMinus.Text = "-";
            this.btnMinus.UseVisualStyleBackColor = true;
            this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // btnPlus
            // 
            this.btnPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlus.ForeColor = System.Drawing.Color.Magenta;
            this.btnPlus.Location = new System.Drawing.Point(196, 38);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(40, 23);
            this.btnPlus.TabIndex = 8;
            this.btnPlus.TabStop = false;
            this.btnPlus.Text = "+";
            this.btnPlus.UseVisualStyleBackColor = true;
            this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // btnCloseBracket
            // 
            this.btnCloseBracket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseBracket.ForeColor = System.Drawing.Color.Magenta;
            this.btnCloseBracket.Location = new System.Drawing.Point(242, 67);
            this.btnCloseBracket.Name = "btnCloseBracket";
            this.btnCloseBracket.Size = new System.Drawing.Size(40, 23);
            this.btnCloseBracket.TabIndex = 28;
            this.btnCloseBracket.TabStop = false;
            this.btnCloseBracket.Text = ")";
            this.btnCloseBracket.UseVisualStyleBackColor = true;
            this.btnCloseBracket.Click += new System.EventHandler(this.btnCloseBracket_Click);
            // 
            // btnOpenBracket
            // 
            this.btnOpenBracket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenBracket.ForeColor = System.Drawing.Color.Magenta;
            this.btnOpenBracket.Location = new System.Drawing.Point(242, 38);
            this.btnOpenBracket.Name = "btnOpenBracket";
            this.btnOpenBracket.Size = new System.Drawing.Size(40, 23);
            this.btnOpenBracket.TabIndex = 29;
            this.btnOpenBracket.TabStop = false;
            this.btnOpenBracket.Text = "(";
            this.btnOpenBracket.UseVisualStyleBackColor = true;
            this.btnOpenBracket.Click += new System.EventHandler(this.btnOpenBracket_Click);
            // 
            // labelMemEnabled
            // 
            this.labelMemEnabled.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelMemEnabled.Location = new System.Drawing.Point(12, 14);
            this.labelMemEnabled.MinimumSize = new System.Drawing.Size(24, 15);
            this.labelMemEnabled.Name = "labelMemEnabled";
            this.labelMemEnabled.Size = new System.Drawing.Size(24, 15);
            this.labelMemEnabled.TabIndex = 30;
            this.labelMemEnabled.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelBaseNumber
            // 
            this.labelBaseNumber.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelBaseNumber.Location = new System.Drawing.Point(33, 14);
            this.labelBaseNumber.MinimumSize = new System.Drawing.Size(21, 15);
            this.labelBaseNumber.Name = "labelBaseNumber";
            this.labelBaseNumber.Size = new System.Drawing.Size(21, 15);
            this.labelBaseNumber.TabIndex = 31;
            this.labelBaseNumber.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 187);
            this.Controls.Add(this.labelBaseNumber);
            this.Controls.Add(this.labelMemEnabled);
            this.Controls.Add(this.btnOpenBracket);
            this.Controls.Add(this.btnCloseBracket);
            this.Controls.Add(this.btnPlus);
            this.Controls.Add(this.btnMinus);
            this.Controls.Add(this.btnMultiply);
            this.Controls.Add(this.btnDivide);
            this.Controls.Add(this.btnC);
            this.Controls.Add(this.btnSqrt);
            this.Controls.Add(this.btnPower);
            this.Controls.Add(this.btnSign);
            this.Controls.Add(this.btnCE);
            this.Controls.Add(this.btnDot);
            this.Controls.Add(this.btnEvaluate);
            this.Controls.Add(this.btn0);
            this.Controls.Add(this.btnMemRestore);
            this.Controls.Add(this.btnMemMin);
            this.Controls.Add(this.btnMemAdd);
            this.Controls.Add(this.btnFlip);
            this.Controls.Add(this.btn9);
            this.Controls.Add(this.btnMemClear);
            this.Controls.Add(this.btn8);
            this.Controls.Add(this.btn7);
            this.Controls.Add(this.btn6);
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.btnBackspace);
            this.Controls.Add(this.inputBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyPress += new KeyPressEventHandler(this.Form1_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputBox;
        private System.Windows.Forms.Button btnBackspace;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn6;
        private System.Windows.Forms.Button btn7;
        private System.Windows.Forms.Button btn8;
        private System.Windows.Forms.Button btnMemClear;
        private System.Windows.Forms.Button btn9;
        private System.Windows.Forms.Button btnFlip;
        private System.Windows.Forms.Button btnMemAdd;
        private System.Windows.Forms.Button btnMemMin;
        private System.Windows.Forms.Button btnMemRestore;
        private System.Windows.Forms.Button btn0;
        private System.Windows.Forms.Button btnEvaluate;
        private System.Windows.Forms.Button btnDot;
        private System.Windows.Forms.Button btnCE;
        private System.Windows.Forms.Button btnSign;
        private System.Windows.Forms.Button btnPower;
        private System.Windows.Forms.Button btnSqrt;
        private System.Windows.Forms.Button btnC;
        private System.Windows.Forms.Button btnDivide;
        private System.Windows.Forms.Button btnMultiply;
        private System.Windows.Forms.Button btnMinus;
        private System.Windows.Forms.Button btnPlus;
        private Button btnCloseBracket;
        private Button btnOpenBracket;
        private Label labelMemEnabled;
        private Label labelBaseNumber;
    }
}