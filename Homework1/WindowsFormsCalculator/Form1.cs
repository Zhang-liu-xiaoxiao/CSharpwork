using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void button5_Click(object sender, EventArgs e)
        {
            string num1 = textBox4.Text;
            string num2 = textBox5.Text;
            int firstNum;
            int secondeNum;
            int result=0;
            try
            {
                firstNum = Convert.ToInt32(num1);
                secondeNum = Convert.ToInt32(num2);
                result = firstNum + secondeNum;
            }
            catch (Exception)
            {
                MessageBox.Show("you should input number");
            }
            textBox6.Text = Convert.ToString(result);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string num1 = textBox4.Text;
            string num2 = textBox5.Text;
            int firstNum;
            int secondeNum;
            int result = 0;
            try
            {
                firstNum = Convert.ToInt32(num1);
                secondeNum = Convert.ToInt32(num2);
                result = firstNum - secondeNum;
            }
            catch (Exception)
            {
                MessageBox.Show("you should input number");
            }
            textBox6.Text = Convert.ToString(result);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string num1 = textBox4.Text;
            string num2 = textBox5.Text;
            int firstNum;
            int secondeNum;
            int result = 0;
            try
            {
                firstNum = Convert.ToInt32(num1);
                secondeNum = Convert.ToInt32(num2);
                result = firstNum * secondeNum;
            }
            catch (Exception)
            {
                MessageBox.Show("you should input number");
            }
            textBox6.Text = Convert.ToString(result);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string num1 = textBox4.Text;
            string num2 = textBox5.Text;
            int firstNum;
            int secondeNum;
            int result = 0;
            try
            {
                firstNum = Convert.ToInt32(num1);
                secondeNum = Convert.ToInt32(num2);
                try
                {
                    result = firstNum / secondeNum;
                }
                catch (ArithmeticException)
                {
                    MessageBox.Show("the second number can't be 0");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("you should input number");
            }
                textBox6.Text = Convert.ToString(result);

        }
    }

}
