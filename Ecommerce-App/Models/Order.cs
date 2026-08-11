using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce_App.Models
{
    internal class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public Customer Customer { get; set; }
        public List<OrderDetails> OrderItems { get; set; }
    }
}
