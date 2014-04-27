using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace MultibaseCalculator
{
    public partial class CalculatorForm : Form
    {
        private string _memory;
        private bool _memoryUsed;

        public CalculatorForm(int radix)
        {   InitializeComponent();
            domainRadix.DownButton();
            ReEnableDigitButtons();
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

        public static int Radix { get; set; }

        private void ReEnableDigitButtons()
        {
            var buttons = new List<Button>(new[] {btn0, btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9});
            for (int i = 0; i < 10; i++)
            {
                buttons[i].Enabled = i < Radix;
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
                Memory = ReversePolishComputer.ComputeRaw(string.Concat(Memory, "+", EvaluateInput())).ToString();
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
                Memory = ReversePolishComputer.ComputeRaw(string.Concat(Memory, "-", EvaluateInput())).ToString();
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
            try
            {
                return ReversePolishComputer.ComputeRaw(inputBox.Text).ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return "0";
            }
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
            if (inputBox.Text.IndexOfAny(new []{'^', '+', '-', '*', '/'}) != -1)
            {
                SurroundWith("-(", ")");
            }
            else
            {
                inputBox.Text = string.Concat("-", inputBox.Text);
            }
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
            if (inputBox.Text.IndexOfAny(new[] { '^', '+', '-', '*', '/' }) < 0)
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

        private void inputBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void domainRadix_SelectedItemChanged(object sender, EventArgs e)
        {
            if("".Equals(domainRadix.Text))
            return;
            int newRadix = int.Parse(domainRadix.Text);
            if (newRadix > 1 && newRadix < 11)
            {
                inputBox.Text = ConvertAllNumbers(inputBox.Text, Radix, newRadix);
                Radix = newRadix;
                ReEnableDigitButtons();
            }
        }

        public static string ConvertAllNumbers(string expression, int from, int to)
        {
            var output = new StringBuilder();
            var  number = new StringBuilder();
            foreach (char c in expression)
            {
                if (char.IsDigit(c))
                {
                    number.Append(c);
                }
                else
                {
                    if (number.Length == 0)
                    {
                        output.Append(c);
                    }
                    else
                    {
                        output.Append(BaseConverter.ConvertFromTo(number.ToString(), from, to));
                        number.Clear();
                        output.Append(c);
                    }
                }
            }
            if (number.Length > 0) output.Append(BaseConverter.ConvertFromTo(number.ToString(), from, to));
            return output.ToString();
        }


    }
}