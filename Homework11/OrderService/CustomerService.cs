using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp
{
    public class CustomerService
    {
        public static void Add(Customer customer)
        {
            using (var db = new MyContext())
            {
                db.Customers.Add(customer);
                db.SaveChanges();

            }
        }

    public static List<Customer> GetAll()
        {
            using (var db = new MyContext())
            {
                return db.Customers.ToList();
            }
        }
    }
}
