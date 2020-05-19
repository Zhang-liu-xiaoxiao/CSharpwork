using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace OrderApp {

  /**
   * The service class to manage orders
   * */
  public class OrderService {

    //the order list


    public OrderService() {
    }


    public List<Order> GetOrders()
    {
        using(var db = new MyContext())
        {
            return AllOrders(db).ToList();
        }
    }
    public Order GetOrder(String id)
    {
        using (var db = new MyContext())
        {
            return AllOrders(db).FirstOrDefault(o => o.OrderId == id);
        }
    }

    public void AddOrder(Order order) {
        try
        {
            using (var db = new MyContext())
            {
                db.Orders.Add(order);
                db.SaveChanges();
            }
        }
        catch (Exception)
        {
            Console.WriteLine("添加错误");
        }
    }

    public void RemoveOrder(String orderId) {
        try
        {
            using (var db = new MyContext())
            {
                var order = db.Orders.FirstOrDefault(o => o.OrderId == orderId);
                if (order != null)
                    db.Orders.Remove(order);
                else
                    Console.WriteLine("无此订单");

                db.SaveChanges();
            }
        }
        catch (Exception)
        {

            Console.WriteLine("删除订单错误");
        }
    }   

    public List<Order> QueryOrdersByGoodsName(string goodsName) {
            using (var db = new MyContext())
            {
                var query = db.Orders
                      .Where(order => order.Items.Exists(item => item.GoodsName == goodsName))
                      .OrderBy(o => o.TotalPrice);
                return query.ToList(); 
            }
    }

    public List<Order> QueryOrdersByCustomerName(string customerName) {
            using (var db = new MyContext())
            {
                return db.Orders
                  .Where(order => order.CustomerName == customerName)
                  .OrderBy(o => o.TotalPrice)
                  .ToList();
            } 
    }

    public void UpdateOrder(Order newOrder) {
      Order oldOrder = GetOrder(newOrder.OrderId);
      if(oldOrder==null)
        Console.WriteLine("修改错误，订单不存在");
      else
        {
            using(var db = new MyContext())
            {
            db.Orders.Remove(oldOrder);
            var entity = db.Entry(newOrder);
            entity.State = EntityState.Modified;
            db.OrderItems.AddRange(newOrder.Items);

            }
        }
    }



    public void Sort(Func<Order, Order, int> func) {
            
            using (var db = new MyContext())
            {
               
            }    
    }

    private static IQueryable<Order> AllOrders(MyContext db)
        {
            return db.Orders.Include(o => o.Items.Select(i => i.GoodsItem))
                      .Include("Customer");
        }

    public void Export(String fileName) {
      XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
      using (FileStream fs = new FileStream(fileName, FileMode.Create)) {
        xs.Serialize(fs, GetOrders());
      }
    }

    public void Import(string path) {
      XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
      using (FileStream fs = new FileStream(path, FileMode.Open)) {
        List<Order> temp = (List<Order>)xs.Deserialize(fs);
                using (var db = new MyContext())
                {
                    temp.ForEach(order =>
                    {
                        if (!db.Orders.Contains(order))
                        {
                            db.Orders.Add(order);
                        }
                    });
                    db.SaveChanges();
                }
      }
    }

    public object QueryByTotalAmount(float amout) {
        using (var db = new MyContext())
        {
             return db.Orders
            .Where(order => order.TotalPrice >= amout)
            .OrderByDescending(o => o.TotalPrice)
            .ToList(); 
        }
    }
  }
}
