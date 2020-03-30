using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework7
{
    public partial class GeyleyTree : Form
    {
        double th1 = 30 * Math.PI / 180;
        double th2 = 30 * Math.PI / 180;
        double per1 = 0.6;
        double per2 = 0.7;
        private Graphics graphics;
        Pen pen = Pens.Black;
        public GeyleyTree()
        {
            InitializeComponent();
        }
        void DrawCayleyTree(int n, double x0, double y0, double length, double th)
        {
            if (n == 0) return;

            double x1 = x0 + length * Math.Cos(th);
            double y1 = y0 + length * Math.Sin(th);

            drawLine(x0, y0, x1, y1);

            DrawCayleyTree(n - 1, x1, y1, per1 * length, th + th1);
            DrawCayleyTree(n - 1, x1, y1, per2 * length, th - th2);
        }

        void drawLine(double x0, double y0, double x1, double y1)
        {
            graphics.DrawLine(pen, (int)x0, (int)y0, (int)x1, (int)y1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = this.CreateGraphics();
            try
            {
                int n = Int32.Parse(textBox1.Text);
                double leng = Double.Parse(textBox2.Text);
                this.per1 = Double.Parse(textBox3.Text);
                this.per2 = Double.Parse(textBox4.Text);
                this.th1 = Double.Parse(textBox5.Text);
                this.th2 = Double.Parse(textBox6.Text);
                switch (comboBox1.SelectedItem)
                {
                    case ("黑色"):this.pen = Pens.Black;break;
                    case ("蓝色"): this.pen = Pens.Blue; break;
                    case ("红色"): this.pen = Pens.Red; break;
                    case ("绿色"): this.pen = Pens.Green; break;
                    default:
                        break;
                }

                DrawCayleyTree(n, 200, 410, leng, -Math.PI / 2);
            }
            catch (Exception)
            {
                MessageBox.Show("请输入正确的值");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "10";
            textBox2.Text = "100";
            textBox3.Text = "0.5";
            textBox4.Text = "0.5";
            textBox5.Text = "0.5";
            textBox6.Text = "0.5";
            comboBox1.Items.Add("黑色");
            comboBox1.Items.Add("蓝色");
            comboBox1.Items.Add("红色");
            comboBox1.Items.Add("绿色");

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            graphics.Clear(Color.White);
        }
    }
}
