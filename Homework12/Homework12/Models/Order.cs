using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework12.Models
{
    public class Order
    {
        [Key]
        public string OrderId { get; set; }
        public DateTime CreateTime { get; set; }

        
        public List<OrderItem> Items { get; set; }
        public string CustomerName { get; set; }

        public Order()
        {
            OrderId = Guid.NewGuid().ToString();
            Items = new List<OrderItem>();
            CreateTime = DateTime.Now;
        }

        public Order(string customerName, List<OrderItem> items) : this()
        {
            this.CreateTime = DateTime.Now;
            this.CustomerName = customerName;
            if (items != null) Items = items;
        }

        public double TotalPrice
        {
            get => Items == null ? 0 : Items.Sum(item => item.TotalPrice);
        }

        public void AddItem(OrderItem orderItem)
        {
            if (Items.Contains(orderItem))
                throw new ApplicationException($"添加错误：订单项已经存在!");
            Items.Add(orderItem);
        }

        public void RemoveItem(OrderItem orderItem)
        {
            Items.Remove(orderItem);
        }

        public override string ToString()
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append($"Id:{OrderId},orderTime:{CreateTime},totalPrice：{TotalPrice}");
            Items.ForEach(od => strBuilder.Append("\n\t" + od));
            return strBuilder.ToString();
        }

        public override bool Equals(object obj)
        {
            var order = obj as Order;
            return order != null &&
                   OrderId == order.OrderId;
        }

        public override int GetHashCode()
        {
            var hashCode = -531220479;
            hashCode = hashCode * -1521134295 + OrderId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CustomerName);
            hashCode = hashCode * -1521134295 + CreateTime.GetHashCode();
            return hashCode;
        }

        public int CompareTo(Order other)
        {
            if (other == null) return 1;
            return this.OrderId.CompareTo(other.OrderId);
        }
    }
}
