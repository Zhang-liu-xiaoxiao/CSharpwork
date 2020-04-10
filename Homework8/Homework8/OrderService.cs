using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Homework8
{
    public class OrderService
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
            try { orderList.Add(order); }
            catch
            {
                Console.WriteLine("添加失败");
            }
        }
        public void Delete()
        {
            orderList.Clear();
        }

        public void Export(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                xmlSerializer.Serialize(fileStream, orderList);
            }
        }


        public void Import(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                orderList = (List<Order>)xmlSerializer.Deserialize(fileStream);
            }
        }
        public IEnumerable<Order> SelectAllOrder()
        {
            return orderList;
        }
        public List<Order> SelectOrderNumberLessThanID(int id)
        {
            var query = orderList.Where(o => o.OrderNumber < id).OrderBy(o => o.OrderAmount);
            List<Order> tempList = query.ToList();
            tempList.ForEach(o => Console.WriteLine(o.ToString()));
            return tempList;
        }

        public Order SelectByNumber(int number)
        {
            var query = from o in orderList
                        where o.OrderNumber == number
                        select o;
            List<Order> orders = query.ToList();
            return orders[0];
        }

        public OrderService(List<Order> orders)
        {
            orderList = orders;
        }
        public OrderService() { }
    }
}
