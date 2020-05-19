using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework8
{
    public partial class MainForm : Form
    {
        OrderService orderService = new OrderService();
        AddOrderForm addForm = new AddOrderForm();
        SaveFileDialog save = new SaveFileDialog();
        OpenFileDialog openFileDialog = new OpenFileDialog();
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            addForm.FormClosed += AddFormClosed;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addForm.ShowDialog();
            
        }
        private void AddFormClosed(Object sender, EventArgs e)
        {
            orderService.Add(addForm.order);
        }

        private void selectButton_Click(object sender, EventArgs e)
        {

            if (orderService.SelectByNumber(Int32.Parse(selectText.Text)) != null)
                richTextBox1.Text = orderService.SelectByNumber(Int32.Parse(selectText.Text)).ToString();
            else
                richTextBox1.Text = "无此订单";
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            orderService.Delete();
            richTextBox1.Text = "删除成功";
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            if(save.ShowDialog() == DialogResult.OK)
            {
                orderService.Export(save.FileName);
            }

        }

        private void importButton_Click(object sender, EventArgs e)
        {
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                orderService.Import(openFileDialog.FileName);
            }
        }
    }
}
