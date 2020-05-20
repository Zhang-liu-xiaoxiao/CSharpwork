using Homework12.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController:ControllerBase
    {
        private readonly MyContext myContext;

        public OrderController(MyContext context)
        {
            this.myContext = context;
        }


        [HttpPost]
        [Route("addOrder")]
        public ResultBody AddOrder(Order order)
        {
            ResultBody resultBody = new ResultBody();
            Order order1 = new Order();
            try
            { 
                order1.CreateTime = order.CreateTime;
                order1.CustomerName = order.CustomerName;
                order1.Items = order.Items;
                order1.OrderId = order.OrderId;

                myContext.Orders.Add(order1);
                myContext.SaveChanges();
                resultBody.Result = "success";
            }
            catch (Exception)
            {
                resultBody.Result = "fail";
                throw;
            }

            return resultBody;
        }

        [HttpPost]
        [Route("getOrderById")]
        public ActionResult<List<Order>> GetOrderById(string Id)
        {
            var query = myContext.Orders.Where(o => o.OrderId == Id);
            return query.ToList();
        }

        [HttpGet]
        [Route("getAllOrders")]
        public ActionResult<List<Order>> GetAllOrder()
        {
            return myContext.Orders.ToList();
        }


        [HttpPost]
        [Route("getOrderByGoodsName")]
        public ActionResult<List<Order>> GetOrderByGoodsName(string goodsName)
        {
            var query =  myContext.Orders.Where(o => o.Items.Count(i => i.GoodsName == goodsName)>0);
            return query.ToList();
        }

        [HttpPost]
        [Route("getOrderByCustomerName")]
        public ActionResult<List<Order>> GetOrderByCustomerName(string customerName)
        {
            var query = myContext.Orders.Where(o => o.CustomerName == customerName);
            return query.ToList();
        }

        [HttpPost]
        [Route("updateOrder")]
        public ResultBody UpdateOrder(Order order)
        {
            ResultBody resultBody = new ResultBody();
            try
            {
                Order order1 = new Order();
                order1 = order;
                RemoveOrder(order1.OrderId);
                myContext.Orders.Add(order1);
                resultBody.Result = "update success";
            }
            catch (Exception)
            {
                resultBody.Result = "update failed";
                throw;
            }
            return resultBody;
        }

        [HttpPost]
        [Route("removeOrder")]
        public ResultBody RemoveOrder(string Id)
        {
            ResultBody resultBody = new ResultBody();
            try
            {
                var query = myContext.Orders.Where(o => o.OrderId == Id);
                myContext.Orders.RemoveRange(query);
                myContext.SaveChanges();
                resultBody.Result = "delete success";
            }
            catch (Exception)
            {
                resultBody.Result = "delete failed";
                throw;
            }
            return resultBody;
        }

    }
}
