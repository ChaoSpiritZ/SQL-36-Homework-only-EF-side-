using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_36_Homework
{
    interface IDAOProvider
    {
        List<Customer> GetAllCustomers();
        List<Order> GetAllOrders();
        List<Order> GetAllOrdersByCustomerId(int customerId);
        Order GetOrderById(int orderId);
        Customer GetCustomerById(int customerId);
        bool AddCustomer(Customer customer);
        bool RemoveCustomer(int customerId);
        bool UpdateCustomer(int customerId, Customer customer);
        bool AddOrder(Order order);
        bool RemoveOrder(int orderId);
        bool UpdateOrder(int orderId, Order order);
        List<OrderCustomer> GetAllOrderCustomer();
    }
}
