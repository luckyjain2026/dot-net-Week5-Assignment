using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce_App.Models
{
    internal class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string City { get; set;  }
        public List<Order> Orders { get; set; }
    }
}
