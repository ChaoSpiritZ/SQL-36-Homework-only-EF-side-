using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_36_Homework
{
    public class DAOMSSQLProvider : IDAOProvider
    {
        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            using (sql36Entities entities = new sql36Entities())
            {
                customers = entities.Customers.ToList();
            }
            return customers;
        }

        public List<Order> GetAllOrders()
        {
            List<Order> orders = new List<Order>();
            using (sql36Entities entities = new sql36Entities())
            {
                orders = entities.Orders.ToList();
            }
            return orders;
        }

        public List<Order> GetAllOrdersByCustomerId(int customerId)
        {
            List<Order> orders = new List<Order>();
            using (sql36Entities entities = new sql36Entities())
            {
                orders = entities.Orders.Where(o => o.Customer_Id == customerId).ToList();
            }
            return orders;
        }

        public Order GetOrderById(int orderId)
        {
            Order order = new Order();
            using (sql36Entities entities = new sql36Entities())
            {
                order = entities.Orders.Where(o => o.Id == orderId).Take(1).FirstOrDefault();
            }
            return order;
        }

        public Customer GetCustomerById(int customerId)
        {
            Customer customer = new Customer();
            using (sql36Entities entities = new sql36Entities())
            {
                customer = entities.Customers.Where(c => c.Id == customerId).Take(1).FirstOrDefault();
            }
            return customer;
        }

        public bool AddCustomer(Customer customer)
        {
            if (customer != null)
            {
                using (sql36Entities entities = new sql36Entities())
                {
                    entities.Customers.Add(customer);
                    entities.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public bool RemoveCustomer(int customerId)
        {
            if (customerId > 0)
            {
                using (sql36Entities entities = new sql36Entities())
                {
                    entities.Customers.Remove(entities.Customers.Where(c => c.Id == customerId).Take(1).FirstOrDefault());
                    entities.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public bool UpdateCustomer(int customerId, Customer customer)
        {
            if (customerId > 0 && customer != null)
            {
                using (sql36Entities entities = new sql36Entities())
                {
                    var selectedCustomer = entities.Customers.Where(c => c.Id == customerId).Take(1).FirstOrDefault();
                    selectedCustomer.Id = customer.Id;
                    selectedCustomer.Name = customer.Name;
                    selectedCustomer.Country = customer.Country;
                    selectedCustomer.Age = customer.Age;
                    entities.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public bool AddOrder(Order order)
        {
            if (order != null)
            {
                using (sql36Entities entities = new sql36Entities())
                {
                    entities.Orders.Add(order);
                    entities.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public bool RemoveOrder(int orderId)
        {
            using (sql36Entities entities = new sql36Entities())
            {
                if (entities.Orders.Where(o => o.Id == orderId).FirstOrDefault() != null)
                {
                    entities.Orders.Remove(entities.Orders.Where(o => o.Id == orderId).Take(1).FirstOrDefault());
                    entities.SaveChanges();
                    Console.WriteLine("removed successfully!");
                    return true;
                }
                Console.WriteLine("no order with this id was found!");
                return false;
            }

        }

        public bool UpdateOrder(int orderId, Order order)
        {
            using (sql36Entities entities = new sql36Entities())
            {
                if (entities.Orders.Where(o => o.Id == orderId).FirstOrDefault() != null && order != null)
                {
                    var selectedOrder = entities.Orders.Where(o => o.Id == orderId).Take(1).FirstOrDefault();
                    selectedOrder.Id = order.Id;
                    selectedOrder.Customer_Id = order.Customer_Id;
                    selectedOrder.Price = order.Price;
                    selectedOrder.Date = order.Date;
                    entities.SaveChanges();

                    return true;
                }
                return false;
            }
        }

        public List<OrderCustomer> GetAllOrderCustomer()
        {
            List<OrderCustomer> orderCustomer = new List<OrderCustomer>();
            using (sql36Entities entities = new sql36Entities())
            {
                orderCustomer = entities.Orders.Join(entities.Customers, o => o.Customer_Id, c => c.Id, (o, c) => new OrderCustomer
                {
                    Id = o.Id,
                    Price = o.Price,
                    Date = o.Date,
                    CustomerId = o.Customer_Id,
                    CustomerName = c.Name
                }).ToList();
            }
            return orderCustomer;
        }

        //public int Id { get; set; }
        //public int CustomerId { get; set; }
        //public int Price { get; set; }
        //public int Date { get; set; }
        //public int CustomerName { get; set; }
    }
}
