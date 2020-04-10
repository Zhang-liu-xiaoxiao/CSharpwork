using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework8
{
    public class Order : IComparable<Order>
    {

        public int OrderNumber { get; set; }
        public String ClientName { get; set; }

        public String DateTime { get; set; }
        public Double OrderAmount
        { get; set; }
        public List<OrderItem> OrderItems { get; set; }//gaicheng List

        public Order()
        {
        }

        public Order(int orderNumber, string clientName, String datetime, List<OrderItem> tempOrderItems)
        {
            this.OrderNumber = orderNumber;
            this.ClientName = clientName;
            this.DateTime = datetime;
            OrderItems = tempOrderItems;
            double sumAmount = 0;
            foreach (OrderItem orderItem in tempOrderItems)
                sumAmount += orderItem.OrderAmount;
            OrderAmount = sumAmount;
        }


        public override string ToString()
        {
            String orderItemString = "";
            OrderItems.ForEach(s => orderItemString += s.ToString());
            return " orderNumber: " + OrderNumber + "\r\n" +
                 " clientName: " + ClientName + "\r\n" +  " orerItems: " + orderItemString 
                 +"\r\n" + " 订单时间:" + DateTime;
        }

        public override bool Equals(object obj)
        {
            Order order = obj as Order;
            return order != null && order.OrderNumber == OrderNumber;
        }

        public int CompareTo( Order other)
        {

            return (OrderAmount > other.OrderAmount) ? 1 : -1;
        }

        public override int GetHashCode()
        {
            var hashCode = 370739583;
            hashCode = hashCode * -1521134295 + OrderNumber.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ClientName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DateTime);
            hashCode = hashCode * -1521134295 + OrderAmount.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<OrderItem>>.Default.GetHashCode(OrderItems);
            return hashCode;
        }
    }
}
