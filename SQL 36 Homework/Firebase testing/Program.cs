using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SQL_36_Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CUSTOMERS:");
            DAOMSSQLProvider daoms = new DAOMSSQLProvider();
            List<Customer> customers = daoms.GetAllCustomers();
            customers.ForEach(c => Console.WriteLine(JsonConvert.SerializeObject(c)));

            //daoms.UpdateCustomer(4, new Customer() { Id = 4, Name = "hello4", Age = 59 });

            Console.WriteLine("ORDERS:");
            List<Order> orders = daoms.GetAllOrders();
            orders.ForEach(o => Console.WriteLine(JsonConvert.SerializeObject(o)));

            Console.WriteLine("ORDERS + CUSTOMERS:");
            List<OrderCustomer> ordercustomers = daoms.GetAllOrderCustomer();
            ordercustomers.ForEach(oc => Console.WriteLine(JsonConvert.SerializeObject(oc)));

            //daoms.RemoveOrder(14);
        }
    }
}
