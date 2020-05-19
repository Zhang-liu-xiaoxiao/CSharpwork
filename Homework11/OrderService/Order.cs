using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace OrderApp {

  /**
   **/
  public class Order:IComparable<Order>{

    public List<OrderItem> items { get; set; }


    [Key]
    public String OrderId { get; set; }

    public Customer Customer { get; set; }

    [ForeignKey("CustomerId")]
    public String CustomerId { get; set; }
    public string CustomerName { get=> (Customer!=null)? Customer.Name:""; }

    public DateTime CreateTime { get; set; }


    public Order() { OrderId = Guid.NewGuid().ToString();; CreateTime = DateTime.Now; items = new List<OrderItem>(); }
    public Order(String Id, Customer customer, List<OrderItem> orderItems)
        {
            OrderId = Id;
            Customer = customer;
            items = orderItems;
        }
        public Order(Customer customer, List<OrderItem> items) : this()
        {
            this.Customer = customer;
            this.CreateTime = DateTime.Now;
            if (items != null) this.items = items;
        }

        public List<OrderItem> Items {
      get { return items; }
    }

    public double TotalPrice {
      get => items.Sum(item => item.TotalPrice);
    }

    public void AddItem(OrderItem orderItem) {
      if(Items.Contains(orderItem))
        throw new ApplicationException($"添加错误：订单项{orderItem.GoodsName} 已经存在!");
      Items.Add(orderItem);
    }

    public void RemoveItem(OrderItem orderItem) {
      Items.Remove(orderItem);
    }

    public override string ToString() {
      StringBuilder strBuilder = new StringBuilder();
      strBuilder.Append($"Id:{OrderId}, customer:{Customer},orderTime:{CreateTime},totalPrice：{TotalPrice}");
      items.ForEach(od => strBuilder.Append("\n\t" + od));
      return strBuilder.ToString() ;
    }

    public override bool Equals(object obj) {
      var order = obj as Order;
      return order != null &&
             OrderId == order.OrderId;
    }

    public override int GetHashCode() {
      var hashCode = -531220479;
      hashCode = hashCode * -1521134295 + OrderId.GetHashCode();
      hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CustomerName);
      hashCode = hashCode * -1521134295 + CreateTime.GetHashCode();
      return hashCode;
    }

    public int CompareTo(Order other) {
      if (other == null) return 1;
      return this.OrderId.CompareTo(other.OrderId);
    }
  }
}
