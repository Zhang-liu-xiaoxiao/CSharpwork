using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Internal;
using OrderProgram;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderProgram.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {

        [TestMethod()]
        public void OrderSortTest()
        {
            OrderService orderService1 = new OrderService();
            OrderService orderService2 = new OrderService();
            List<OrderItem> orderItems1 = new List<OrderItem>
            {
                new OrderItem(200,"apple1",100,1),
            };
            List<OrderItem> orderItems2 = new List<OrderItem>
            {
                new OrderItem(100,"apple1",100,1),
            };
            orderService1.Add(new Order(1, "zhangsan", "20000316", orderItems1));
            orderService1.Add(new Order(1, "zhangsan", "20000316", orderItems2));
            orderService1.OrderSort();
            orderService2.Add(new Order(1, "zhangsan", "20000316", orderItems2));
            orderService2.Add(new Order(1, "zhangsan", "20000316", orderItems1));
            orderService1.Equals(orderService2);
            //Assert.Fail();
        }

        [TestMethod()]
        public void OrderSortByOrderAmountTest()
        {
            OrderService orderService1 = new OrderService();
            OrderService orderService2 = new OrderService();
            List<OrderItem> orderItems1 = new List<OrderItem>
            {
                new OrderItem(200,"apple1",100,1),
            };
            List<OrderItem> orderItems2 = new List<OrderItem>
            {
                new OrderItem(100,"apple1",100,1),
            };
            orderService1.Add(new Order(1, "zhangsan", "20000316", orderItems1));
            orderService1.Add(new Order(1, "zhangsan", "20000316", orderItems2));
            orderService1.OrderSort();
            orderService2.Add(new Order(1, "zhangsan", "20000316", orderItems2));
            orderService2.Add(new Order(1, "zhangsan", "20000316", orderItems1));
            orderService1.Equals(orderService2);
            // Assert.Fail();
        }

        [TestMethod()]
        public void AddTest()
        {
            OrderService orderService1 = new OrderService();
            List<OrderItem> orderItems1 = new List<OrderItem>
            {
                new OrderItem(200,"apple1",100,1),
            };
            List<OrderItem> orderItems2 = new List<OrderItem>
            {
                new OrderItem(100,"apple1",100,1),
            };
            orderService1.Add(new Order(1, "zhangsan", "20000316", orderItems1));
            orderService1.Add(new Order(1, "zhangsan", "20000316", orderItems2));
            //Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            OrderService orderService1 = new OrderService();
            List<OrderItem> orderItems1 = new List<OrderItem>
            {
                new OrderItem(200,"apple1",100,1),
            };
            List<OrderItem> orderItems2 = new List<OrderItem>
            {
                new OrderItem(100,"apple1",100,1),
            };
            orderService1.Add(new Order(1, "zhangsan", "20000316", orderItems1));
            orderService1.Add(new Order(1, "zhangsan", "20000316", orderItems2));
            orderService1.Delete();
            //Assert.Fail();
        }

        [TestMethod()]
        public void ExportTest()
        {
            OrderService orderService1 = new OrderService();
            List<OrderItem> orderItems1 = new List<OrderItem>
            {
                new OrderItem(200,"apple1",100,1),
            };
            List<OrderItem> orderItems2 = new List<OrderItem>
            {
                new OrderItem(100,"apple1",100,1),
            };
            orderService1.Add(new Order(1, "zhangsan", "20000316", orderItems1));
            orderService1.Add(new Order(1, "zhangsan", "20000316", orderItems2));
            orderService1.Export("c:/temp/3.xml");
            //Assert.Fail();
        }

        [TestMethod()]
        public void ImportTest()
        {
            OrderService orderService = new OrderService();
            orderService.Import("c:/temp/2.xml");
            Console.WriteLine(orderService);
            //Assert.Fail();
        }

        [TestMethod()]
        public void SelectAllOrderTest()
        {
            OrderService orderService1 = new OrderService();
            List<OrderItem> orderItems1 = new List<OrderItem>
            {
                new OrderItem(200,"apple1",100,1),
            };
            List<OrderItem> orderItems2 = new List<OrderItem>
            {
                new OrderItem(100,"apple1",100,1),
            };
            orderService1.Add(new Order(1, "zhangsan", "20000316", orderItems1));
            orderService1.Add(new Order(1, "zhangsan", "20000316", orderItems2));
            orderService1.SelectAllOrder();
        }

        [TestMethod()]
        public void SelectOrderNumberLessThanIDTest()
        {
            OrderService orderService1 = new OrderService();
            List<OrderItem> orderItems1 = new List<OrderItem>
            {
                new OrderItem(200,"apple1",100,1),
            };
            List<OrderItem> orderItems2 = new List<OrderItem>
            {
                new OrderItem(100,"apple1",100,1),
            };
            orderService1.Add(new Order(1, "zhangsan", "20000316", orderItems1));
            orderService1.Add(new Order(1, "zhangsan", "20000316", orderItems2));
            orderService1.SelectOrderNumberLessThanID(10);
        }

        [TestMethod()]
        public void SelectByNumberTest()
        {
            OrderService orderService1 = new OrderService();
            List<OrderItem> orderItems1 = new List<OrderItem>
            {
                new OrderItem(200,"apple1",100,1),
            };
            List<OrderItem> orderItems2 = new List<OrderItem>
            {
                new OrderItem(100,"apple1",100,1),
            };
            orderService1.Add(new Order(1, "zhangsan", "20000316", orderItems1));
            orderService1.Add(new Order(1, "zhangsan", "20000316", orderItems2));
            orderService1.SelectByNumber(1);
        }

        [TestMethod()]
        public void OrderServiceTest()
        {
            //Assert.Fail();

        }

        [TestMethod()]
        public void OrderServiceTest1()
        {
           // Assert.Fail();
        }
    }
}