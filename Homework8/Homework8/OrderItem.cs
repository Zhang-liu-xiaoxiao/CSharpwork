using iText.IO.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework8
{
    public class OrderItem
    {
        public Double OrderAmount { get; set; }

        public String MerchandiseName { get; set; }
        public int MerchandiseAmount { get; set; }
        public int OrderItemNumber { get; set; }

        public OrderItem()
        {
        }

        public override string ToString()
        {
            return " 商品名: " + MerchandiseName + " 商品金额: " + OrderAmount + " 商品数量: " + MerchandiseAmount + " 详情号: " + OrderItemNumber;
        }

        public override bool Equals(object obj)
        {
            return obj is OrderItem item &&
                   OrderAmount == item.OrderAmount &&
                   MerchandiseAmount == item.MerchandiseAmount &&
                   OrderItemNumber == item.OrderItemNumber;
        }



        public OrderItem(double orderAmount, string merchandiseName, int merchandiseAmount, int orderItemNumber)
        {
            OrderAmount = orderAmount;
            MerchandiseName = merchandiseName;
            MerchandiseAmount = merchandiseAmount;
            OrderItemNumber = orderItemNumber;
        }

    }
}
