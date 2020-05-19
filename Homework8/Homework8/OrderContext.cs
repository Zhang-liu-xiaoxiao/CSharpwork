using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework8
{
    public class OrderContext : DbContext
    {
        public OrderContext () : base("OrderContext")
        {
            Database.SetInitializer(
                new DropCreateDatabaseAlways<OrderContext>());
        }

    }
}
