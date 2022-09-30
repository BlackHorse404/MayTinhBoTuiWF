using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NguyenDucPhat_2001207025_BTVN
{
    public partial class MayTinhBoTui : Form
    {
        public MayTinhBoTui()
        {
            InitializeComponent();
        }
        //variable
        int numClick = 0, numClickControl = 0;
        double num = 0;
        double prev = 0;
        //function
        internal void exeResultWhenControlNext()
        {
            if (numClickControl >= 1)
            {
                string text = txtResult.Text.Length > 0 ? txtResult.Text : "0";
                try
                {
                    //process
                    if (txtShowInput.Text.Length > 0 && txtShowInput.Text[txtShowInput.Text.Length - 1].Equals('+'))
                    {
                        num += double.Parse(text);
                    }
                    else if (txtShowInput.Text.Length > 0 && txtShowInput.Text[txtShowInput.Text.Length - 1].Equals('-'))
                    {
                        num -= double.Parse(text);
                    }
                    else if (txtShowInput.Text.Length > 0 && txtShowInput.Text[txtShowInput.Text.Length - 1].Equals('x'))
                    {
                        num *= double.Parse(text);
                    }
                    else if (txtShowInput.Text.Length > 0 && txtShowInput.Text[txtShowInput.Text.Length - 1].Equals('/'))
                    {
                        num /= double.Parse(text);
                    }
                    if (!txtShowInput.Text.Contains("="))
                        txtShowInput.Text = text + "=";
                }
                catch
                {
                    MessageBox.Show("Vui lòng kiểm tra lại phép tính !", "Không thể tính", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    txtResult.Text = num.ToString();
                    txtShowInput.Text = "";
                    txtShowInput.Text += num.ToString() + "+";
                    numClickControl = numClickControl > 999 ? 1 : numClickControl;
                }
            }
        }
        internal bool isControl(char text)
        {
            bool res = false;
            switch(text)
            {
                case '+': 
                case '-': 
                case 'x': 
                case '/':
                    res = true;
                    break;
            }
            return res;
        }
        internal void InputNumberIsValid(string num)
        {
            if (txtShowInput.Text.Length > 0 && isControl(txtShowInput.Text[txtShowInput.Text.Length - 1]) && numClick == 0 && !txtResult.Text.Equals(num))
            {
                txtResult.Text = "";

            }
            else if (txtShowInput.Text.Length > 0 && isControl(txtShowInput.Text[txtShowInput.Text.Length - 1]) && numClick == 0 && txtResult.Text.Equals(num))
            {
                txtResult.Text = "";
            }
            numClick++;
        }//button
        internal void isDifference(string text)
        {
            if (txtShowInput.Text.Length > 0
                && isControl(txtShowInput.Text[txtShowInput.Text.Length - 1])
                && txtResult.Text.Equals(num))
            {
                txtResult.Text = "";

            }
        }
        internal void updateNum(string text)
        {
            if(txtResult.Text.Length > 0)
            {
                prev = double.Parse(txtResult.Text)*1.0;
                num = double.Parse(txtResult.Text)*1.0;
                txtShowInput.Text = txtResult.Text + text;
                txtResult.Text = num.ToString();
                numClick = 0;
            }
        }

        //close caculator
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult temp = MessageBox.Show("Bạn chắc chắn muốn thoát ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (temp == DialogResult.No)
                e.Cancel = true;
        }
        //input number
        #region input number
        private void btn0_Click(object sender, EventArgs e)
        {
            InputNumberIsValid("0");
            txtResult.Text += "0";
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            InputNumberIsValid("1");
            txtResult.Text += "1";
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            InputNumberIsValid("2");
            txtResult.Text += "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            InputNumberIsValid("3");
            txtResult.Text += "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            InputNumberIsValid("4");
            txtResult.Text += "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            InputNumberIsValid("5");
            txtResult.Text += "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            InputNumberIsValid("6");
            txtResult.Text += "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            InputNumberIsValid("7");
            txtResult.Text += "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            InputNumberIsValid("8");
            txtResult.Text += "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            InputNumberIsValid("9");
            txtResult.Text += "9";
        }
        #endregion
        //input control
        private void btnPlus_Click(object sender, EventArgs e)
        {
            exeResultWhenControlNext();
            updateNum("+");
            numClick = 0;
            numClickControl++;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            exeResultWhenControlNext();
            updateNum("-");
            numClick = 0;
            numClickControl++;
        }

        private void btnMulti_Click(object sender, EventArgs e)
        {
            exeResultWhenControlNext();
            updateNum("x");
            numClick = 0;
            numClickControl++;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            exeResultWhenControlNext();
            updateNum("/");
            numClick = 0;
            numClickControl++;
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            prev = double.Parse(txtResult.Text);
            double temp = double.Parse(txtResult.Text) / 100;
            txtResult.Text = temp.ToString();
        }

        private void btnFactorial_Click(object sender, EventArgs e)
        {
            double rs = 1;
            try
            {
                long temp = long.Parse(txtResult.Text);
                for (int i = 2; i <= temp; i++)
                {
                    rs *= i;
                }
                txtShowInput.Text = temp +"! "+"=";
            }
            catch {
                MessageBox.Show("Giai thừa phải là số nguyên !", "Lỗi",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                txtResult.Text = rs.ToString();
            }
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            txtResult.Text += ".";
        }
        //show input
        private void txtShowInput_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            string text = txtResult.Text;
            if(text.Length > 0)
            {
                txtResult.Text = text.Substring(0, text.Length - 1);
            }
            numClick = 0;
        }

        private void btnAC_Click(object sender, EventArgs e)
        {
            txtShowInput.Text = string.Empty;
            txtResult.Text = string.Empty;
            numClick = 0;
            num = 0;
            prev = 0;
            numClick = 0;
            numClickControl = 0;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            numClick = 0;
            string text = txtResult.Text.Length > 0 ? txtResult.Text : "0";
            try
            {
                //process
                if (txtShowInput.Text.Length > 0 && txtShowInput.Text[txtShowInput.Text.Length - 1].Equals('+'))
                {
                    num += double.Parse(text);
                }
                else if (txtShowInput.Text.Length > 0 && txtShowInput.Text[txtShowInput.Text.Length - 1].Equals('-'))
                {
                    num -= double.Parse(text);
                }else if(txtShowInput.Text.Length > 0 && txtShowInput.Text[txtShowInput.Text.Length - 1].Equals('x'))
                {
                    num *= double.Parse(text);
                }
                else if(txtShowInput.Text.Length > 0 && txtShowInput.Text[txtShowInput.Text.Length - 1].Equals('/'))
                {
                    num /= double.Parse(text);
                }
                if(!txtShowInput.Text.Contains("="))
                    txtShowInput.Text += text + "=";
            }
            catch
            {
                MessageBox.Show("Vui lòng kiểm tra lại phép tính !", "Không thể tính", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                txtResult.Text = num.ToString();
            }
        }

        //hide focus
        private void txtShowInput_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        private void txtResult_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        //check change number
        private void txtResult_TextChanged(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            isDifference(c.Text);
        }

        
        
    }
}
