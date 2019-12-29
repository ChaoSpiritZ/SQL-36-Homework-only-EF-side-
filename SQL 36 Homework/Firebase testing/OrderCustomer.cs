using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_36_Homework
{
    public class OrderCustomer
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public float Price { get; set; }
        public DateTime Date { get; set; }
        public string CustomerName { get; set; }
    }
}
