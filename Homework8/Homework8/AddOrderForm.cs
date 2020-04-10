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
    public partial class AddOrderForm : Form
    {
        public List<OrderItem> orderItems = new List<OrderItem> () ;
        public Order order = new Order();
       
        public AddOrderForm()
        {
            InitializeComponent();
            richTextBox1.DataBindings.Add("Text", order, "ClientName");
            richTextBox2.DataBindings.Add("Text", order, "OrderNumber");
            richTextBox3.DataBindings.Add("Text", order, "DateTime");
        }

        

        private void AddOrderForm_Load(object sender, EventArgs e)
        {
            orderItems.Add(new OrderItem(1,"1",1,1));
            orderItemBindingSource1.DataSource = orderItems;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            order.OrderItems = orderItems;
            this.Close();
        }


    }
}
