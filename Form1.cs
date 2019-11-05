using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_Desktop
{
    public partial class Form1 : Form
    {
        public string PreviousValue = "";
        public string Op = "";
        public string ExceptionMessage = "";
        public Form1()
        {
            InitializeComponent();
        }

        public string GetBinary(string inputNumber)
        {
            int number = Convert.ToInt32(inputNumber);
            string value = "";
            while (number > 0)
            {
                value += number % 2;
                number /= 2;
            }
            var valueSeq = value.Reverse().ToList();
            string ot = "";
            valueSeq.ForEach(v =>
            {
                ot += v;
            });
            return ot;
        }

        public string GetDecimal(string inputNumber)
        {
            int number = Convert.ToInt32(inputNumber, 2);
            var v = number.ToString();
            return v;
        }

        public string GetBinary(double inputNumber)
        {
            int number = Convert.ToInt32(inputNumber);
            string value = "";
            while (number > 0)
            {
                value += number % 2;
                number /= 2;
            }
            var valueSeq = value.Reverse().ToList();
            string ot = "";
            valueSeq.ForEach(v =>
            {
                ot += v;
            });
            return ot;
        }

        public double GetDecimal(double inputNumber)
        {
            int number = Convert.ToInt32(inputNumber.ToString(), 2);
            return number;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += '7';
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

            if (System.Text.RegularExpressions.Regex.IsMatch(richTextBox1.Text, "[^0-9][-]"))
            {
                MessageBox.Show("Please enter only numbers.");
                richTextBox1.Text = richTextBox1.Text.Remove(richTextBox1.Text.Length - 1);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += '8';
        }

        private void button11_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += '9';

        }

        private void button13_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += '4';

        }

        private void button14_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += '5';

        }

        private void button15_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += '6';

        }

        private void button17_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += '1';
        }

        private void button18_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += '2';

        }

        private void button19_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += '3';

        }

        private void button22_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += '0';

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length > 0)
            {
                richTextBox1.Text = richTextBox1.Text.Substring(0, richTextBox1.Text.Length - 1);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";

        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length > 0 && richTextBox1.Text[0] == '-')
            {
                richTextBox1.Text = richTextBox1.Text.Substring(1, richTextBox1.Text.Length - 1);
            }
            else
            {
                richTextBox1.Text = '-' + richTextBox1.Text;
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (!richTextBox1.Text.Contains("."))
            {
                if (richTextBox1.Text.Length == 0)
                {
                    richTextBox1.Text = "0";
                }
                richTextBox1.Text += '.';
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "" && !richTextBox1.Text.Contains('.'))
            {
                if (richTextBox1.Text.Contains("-"))
                {
                    string removedSt = richTextBox1.Text.Remove(0, 1);
                    string ot = GetBinary(removedSt);
                    richTextBox1.Text = "1:" + ot;
                }
                else
                {
                    string ot = GetBinary(richTextBox1.Text);
                    richTextBox1.Text = "0:" + ot;
                }
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "" && richTextBox1.Text.Contains(":") && !richTextBox1.Text.Contains('.'))
            {
                if (richTextBox1.Text[0] == '1')
                {
                    richTextBox1.Text = "-" + GetDecimal(richTextBox1.Text.Substring(2));
                }
                else
                {
                    richTextBox1.Text = GetDecimal(richTextBox1.Text.Substring(2));

                }
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "" && (richTextBox1.Text.Length == 1 && richTextBox1.Text[0] != '-'))
            {
                PreviousValue = richTextBox1.Text;
            }
        }

        public double GetNumberFromInputDecimal(string input)
        {

            if (input.Contains("-"))
            {
                double value = Convert.ToDouble(input.Substring(1));
                return value;
            }
            else
            {
                return Convert.ToDouble(input);
            }
        }
        public double GetNumberFromInputBinary(string input)
        {

            if (input.Contains(":"))
            {
                double value = Convert.ToDouble(input.Substring(2));
                return value;
            }
            else
            {
                return 0;
            }
        }

        private void SetAnsToTextBoxes(string answer)
        {
            richTextBox2.Text += answer;
        }

        private void SetTextBoxValues(string Op)
        {
            PreviousValue = richTextBox1.Text;
            richTextBox2.Text = richTextBox2.Text + "\n" + richTextBox1.Text + " " + Op + " ";
            richTextBox1.Text = "";
        }
        private void button20_Click(object sender, EventArgs e)
        {
            Op = "+";
            SetTextBoxValues(Op);


        }

        private void button24_Click(object sender, EventArgs e)
        {
            bool exceptionAccured = false;
            double value3 = 0;
            double value1 = 0;
            double value2 = 0;

            bool IsItBinary = false;
            try
            {
                if (richTextBox1.Text.Contains(":"))
                {
                    IsItBinary = true;
                    value2 = GetDecimal(GetNumberFromInputBinary(richTextBox1.Text));
                    if (richTextBox1.Text[0] == '1')
                    {
                        var changedNegative = "-" + value1;
                        value2 = Convert.ToDouble(changedNegative);
                    }
                }
                else
                {
                    value2 = GetNumberFromInputDecimal(richTextBox1.Text);
                    if (richTextBox1.Text.Contains('-'))
                    {
                        var changedNegative = "-" + value1;
                        value2 = Convert.ToDouble(changedNegative);

                    }
                }
                if (PreviousValue.Contains(":"))
                {
                    value1 = GetDecimal(GetNumberFromInputBinary(PreviousValue));
                    if (PreviousValue[0] == '1')
                    {
                        var changedNegative = "-" + value2;
                        value1 = Convert.ToDouble(changedNegative);
                    }
                }
                else
                {
                    value1 = GetNumberFromInputDecimal(PreviousValue);
                    if (PreviousValue.Contains('-'))
                    {
                        var changedNegative = "-" + value2;
                        value1 = Convert.ToDouble(changedNegative);
                    }
                }
            }
            catch (Exception ex)
            {
                exceptionAccured = true;
                ExceptionMessage = ex.Message;
            }

            string tempValue2 = richTextBox1.Text;

            switch (Op)
            {
                case "+":
                    try
                    {
                        value3 = value1 + value2;
                    }
                    catch (Exception ex)
                    {
                        exceptionAccured = true;
                        ExceptionMessage = ex.Message;
                    }
                    break;
                case "-":
                    try
                    {
                        value3 = value1 - value2;
                    }
                    catch (Exception ex)
                    {
                        exceptionAccured = true;
                        ExceptionMessage = ex.Message;
                    }
                    break;
                case "*":
                    value3 = value1 * value2;
                    break;
                case "/":
                    if (value2 == 0)
                    {
                        value3 = 0;
                        break;
                    }
                    try
                    {
                        value3 = value1 / value2;
                    }
                    catch (Exception ex)
                    {
                        exceptionAccured = true;
                        ExceptionMessage = ex.Message;
                    }

                    break;
                case "x^Pow":
                    if (value2 == 0 || value2 == 1)
                    {
                        value3 = value1;
                        break;
                    }
                    else if (value2 < 0)
                    {
                        value3 = value1;
                        while (value2 < 0)
                        {

                            try
                            {
                                value3 /= value1;
                            }
                            catch (Exception ex)
                            {
                                exceptionAccured = true;
                                ExceptionMessage = ex.Message;
                            }

                            value2++;
                        }
                    }
                    else if (value2 > 1)
                    {
                        value3 = 1;
                        while (value2 > 0)
                        {
                            try
                            {
                                value3 *= value1;
                            }
                            catch (Exception ex)
                            {
                                exceptionAccured = true;
                                ExceptionMessage = ex.Message;
                            }

                            value2--;
                        }

                    }
                    break;
                case "1/x":
                    try
                    {
                        value3 = 1 / value1;
                    }
                    catch (Exception ex)
                    {
                        exceptionAccured = true;
                        ExceptionMessage = ex.Message;
                    }

                    break;
                case "x^2":
                    try
                    {
                        value3 = value1 * value1;
                    }
                    catch (Exception ex)
                    {
                        exceptionAccured = true;
                        ExceptionMessage = ex.Message;
                    }

                    break;
                case "sqrt":
                    try
                    {
                        value3 = 1;
                        while (value3 * value3 <= value1)
                        {
                            value3++;
                        }
                        if (value3 * value3 <= value1)
                        {
                            value3++;
                        }
                    }
                    catch (Exception ex)
                    {
                        exceptionAccured = true;
                        ExceptionMessage = ex.Message;
                    }

                    break;
                case "%":
                    try
                    {
                        value3 = value1 % value2;
                    }
                    catch (Exception ex)
                    {
                        exceptionAccured = true;
                        ExceptionMessage = ex.Message;
                    }
                    break;
                case "&&":
                    break;
                case "||":
                    break;
                case "^":
                    break;

            }
            richTextBox1.Text = value3.ToString();
            SetAnsToTextBoxes(tempValue2 + "=" + value3.ToString());


        }

        private void button16_Click(object sender, EventArgs e)
        {
            Op = "-";
            SetTextBoxValues(Op);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Op = "*";
            SetTextBoxValues(Op);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Op = "/";
            SetTextBoxValues(Op);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Op = "x^Pow";
            SetTextBoxValues(Op);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Op = "1/x";
            SetTextBoxValues(Op);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Op = "x^2";
            SetTextBoxValues(Op);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Op = "sqrt";
            SetTextBoxValues(Op);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Op = "%";
            SetTextBoxValues(Op);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            Op = "&&";
            SetTextBoxValues(Op);
        }

        private void button28_Click(object sender, EventArgs e)
        {
            Op = "||";
            SetTextBoxValues(Op);
        }

        private void button29_Click(object sender, EventArgs e)
        {
            Op = "^";
            SetTextBoxValues(Op);
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
