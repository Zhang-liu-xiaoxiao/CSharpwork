using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp
{
    public class MyContext : DbContext
    {
        public MyContext() : base("OrderDatabase")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MyContext>());
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Goods> Goods { get; set; }
    }

}
