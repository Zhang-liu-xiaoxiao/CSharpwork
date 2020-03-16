using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace OrderProgram 
{
    class Order:IComparable<Order>
    {
        public int OrderNumber { get; set; }
        public String ClientName { get; set; }

        public String DateTime { get; set; }
        public Double OrderAmount
        {
            get
            {
                return OrderAmount;
            }
            set {
                double sum=0;
                OrderItems.ForEach(s => sum += s.OrderAmount);
                OrderAmount = sum;
            }
        }
        public List<OrderItem> OrderItems { get; set; }//gaicheng List

        public Order(int orderNumber, string clientName,String datetime,List<OrderItem> tempOrderItems)
        {
            this.OrderNumber = orderNumber;
            this.ClientName = clientName;
            this.DateTime = datetime;
            OrderItems = tempOrderItems;

        }


        public override string ToString()
        {
            String orderItemString = "";
            OrderItems.ForEach(s => orderItemString += s.ToString());
            return " orderNumber: " + OrderNumber + 
                 " clientName: " + ClientName + " orerItems: " + orderItemString;
        }

        public override bool Equals(object obj)
        {
            Order order = obj as Order;
            return order != null && order.OrderNumber == OrderNumber;
        }

        public int CompareTo([AllowNull] Order other)
        {

            return (OrderAmount > other.OrderAmount) ? 1 : -1;
        }
    }

    class OrderItem
    {
        public Double OrderAmount { get; set; }

        public String MerchandiseName { get; set; }
        public int MerchandiseAmount { get; set; }
        public int OrderItemNumber { get; set; }

        public override string ToString()
        {
            return " 商品名: " + MerchandiseName + " 商品金额: " + OrderAmount +  " 商品数量: " + MerchandiseAmount + " 详情号: " + OrderItemNumber;
        }

        public override bool Equals(object obj)
        {
            return obj is OrderItem item &&
                   OrderAmount == item.OrderAmount &&
                   MerchandiseAmount == item.MerchandiseAmount &&
                   OrderItemNumber == item.OrderItemNumber;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(OrderAmount, MerchandiseAmount, OrderItemNumber);
        }

        public OrderItem(double orderAmount, string merchandiseName, int merchandiseAmount, int orderItemNumber)
        {
            OrderAmount = orderAmount;
            MerchandiseName = merchandiseName;
            MerchandiseAmount = merchandiseAmount;
            OrderItemNumber = orderItemNumber;
        }

    }

    class OrderService
    {
        List<Order> orderList = new List<Order>();

        public void OrderSort()
        {
            orderList.Sort();
        }

        public void OrderSortByOrderAmount()
        {
            orderList.Sort((r1, r2) => { return Convert.ToInt32(r1.OrderAmount - r2.OrderAmount); });
        }
        public void Add(Order order)
        {
            try{ orderList.Add(order); }
            catch
            {
                Console.WriteLine("添加失败");
            }
        }
        public void Delete()
        {
            orderList.Clear();
        }

        public IEnumerable<Order> SelectAllOrder()
        {
            return orderList;
        }
        public List<Order> SelectOrderNumberLessThanID(int id)
        {
            var query = orderList.Where(o => o.OrderNumber < id).OrderBy(o=>o.OrderAmount);
            List < Order > tempList = query.ToList();
            tempList.ForEach(o => Console.WriteLine(o.ToString()));
            return tempList;
        }

        public Order SelectByNumber(int number)
        {
            var query = from o in orderList
                        where o.OrderNumber == number
                        select o;
            List<Order> orders= query.ToList();
            return orders[0];
        }

        public OrderService(List<Order> orders)
        {
            orderList = orders;
        }
        public OrderService() { }
    }
    class Program
    {
        static void Main(string[] args)
        {
            OrderService orderService = new OrderService();
            List<OrderItem> orderItems = new List<OrderItem>
            {
                new OrderItem(100,"apple1",100,1),
                new OrderItem(200,"apple2",200,2),
                new OrderItem(300,"apple3",300,3),
                new OrderItem(400,"apple4",400,4),
            };

            orderService.Add(new Order(1, "zhangsan", "20000316", orderItems));

            Order order1 = orderService.SelectByNumber(1);
            Console.WriteLine(order1.ToString());

        }
    }
}
