using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace MultibaseCalculator
{
    public partial class Form1 : Form
    {
        private readonly MultibaseEvaluator _multibaseEvaluator = new MultibaseEvaluator();
        private string _memory;
        private bool _memoryUsed;

        public Form1()
        {
            InitializeComponent();
            labelBaseNumber.Text = _multibaseEvaluator.Radix.ToString(CultureInfo.InvariantCulture);
            DisableExceedButtons();
        }

        private string Memory
        {
            get { return _memory; }
            set
            {
                if (value.Equals("0"))
                {
                    labelMemEnabled.Text = @"M0";
                }
                _memory = value;
            }
        }

        private bool MemoryUsed
        {
            get { return _memoryUsed; }
            set
            {
                labelMemEnabled.Text = value ? "M" : "";
                _memoryUsed = value;
            }
        }

        private void DisableExceedButtons()
        {
            var buttons = new List<Button>(new[] {btn0, btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9});
            for (int i = 0; i < 10; i++)
            {
                if (i < _multibaseEvaluator.Radix) continue;
                buttons[i].Enabled = false;
            }
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (!IsEmptyInput())
            {
                inputBox.Text += @"0";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!IsEmptyInput())
                WriteToBox("1");
            else
                inputBox.Text = @"1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (!IsEmptyInput())
                WriteToBox("2");
            else
                inputBox.Text = @"2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (!IsEmptyInput())
                WriteToBox("3");
            else
                inputBox.Text = @"3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (!IsEmptyInput())
                WriteToBox("4");
            else
                inputBox.Text = @"4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (!IsEmptyInput())
                WriteToBox("5");
            else
                inputBox.Text = @"5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (!IsEmptyInput())
                WriteToBox("6");
            else
                inputBox.Text = @"6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (!IsEmptyInput())
                WriteToBox("7");
            else
                inputBox.Text = @"7";
        }

        private bool IsEmptyInput()
        {
            return inputBox.Text.Equals("0");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (!inputBox.Text.Equals("0"))
                WriteToBox("8");
            else inputBox.Text = @"8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (!inputBox.Text.Equals("0"))
                WriteToBox("9");
            else inputBox.Text = @"9";
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            if (inputBox.TextLength > 1)
            {
                inputBox.Text = inputBox.Text.Substring(0, inputBox.TextLength - 1);
            }
            else
            {
                ClearInput();
            }
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        private void btnMemAdd_Click(object sender, EventArgs e)
        {
            if (MemoryUsed)
            {
                Memory = _multibaseEvaluator.EvaluateWithBrackets(string.Concat(Memory, "+", EvaluateInput()));
            }
            else
            {
                Memory = EvaluateInput();
                MemoryUsed = true;
            }
        }

        private void btnMemMin_Click(object sender, EventArgs e)
        {
            if (MemoryUsed)
            {
                Memory = _multibaseEvaluator.EvaluateWithBrackets(string.Concat(Memory, "-", EvaluateInput()));
            }
            else
            {
                Memory = EvaluateInput();
                MemoryUsed = true;
            }
        }

        private void btnMemRestore_Click(object sender, EventArgs e)
        {
            if (MemoryUsed)
            {
                inputBox.Text = Memory;
            }
            else
            {
                ClearInput();
            }
        }

        private void ClearInput()
        {
            inputBox.Text = @"0";
        }

        private string EvaluateInput()
        {
            return _multibaseEvaluator.EvaluateWithBrackets(inputBox.Text);
        }

        private void btnEvaluate_Click(object sender, EventArgs e)
        {
            inputBox.Text = EvaluateInput();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            WriteToBox("+");
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            WriteToBox("*");
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            WriteToBox("-");
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            WriteToBox("/");
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            SurroundWith("-(", ")");
        }

        private void btnPower_Click(object sender, EventArgs e)
        {
            WriteToBox("^");
        }

        private void btnOpenBracket_Click(object sender, EventArgs e)
        {
            if (!IsEmptyInput())
                WriteToBox("(");
            else
                inputBox.Text = @"(";
        }

        private void btnCloseBracket_Click(object sender, EventArgs e)
        {
            if (!IsEmptyInput())
                WriteToBox(")");
        }

        private void btnFlip_Click(object sender, EventArgs e)
        {
            if (inputBox.Text.IndexOfAny(_multibaseEvaluator.AllOperators) < 0)
            {
                inputBox.Text = @"1/" + inputBox.Text;
            }
            else
            {
                SurroundWith("1/(", ")");
            }
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            SurroundWith("(", ")^(0.5)");
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            MemoryUsed = false;
            ClearInput();
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            WriteToBox(".");
        }

        private void WriteToBox(string text)
        {
            inputBox.Text += text;
        }

        private void SurroundWith(string prefix, string postfix)
        {
            inputBox.Text = string.Concat(prefix, inputBox.Text, postfix);
        }

        private void btnMemClear_Click(object sender, EventArgs e)
        {
            MemoryUsed = false;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '0':
                    btn0_Click(sender, e);
                    break;
                case '1':
                    btn0_Click(sender, e);
                    break;
                case '2':
                    btn0_Click(sender, e);
                    break;
                case '3':
                    btn0_Click(sender, e);
                    break;
                case '4':
                    btn0_Click(sender, e);
                    break;
                case '5':
                    btn0_Click(sender, e);
                    break;
                case '6':
                    btn0_Click(sender, e);
                    break;
                case '7':
                    btn0_Click(sender, e);
                    break;
                case '8':
                    btn0_Click(sender, e);
                    break;
                case '9':
                    btn0_Click(sender, e);
                    break;
                
            }
        }


    }
}