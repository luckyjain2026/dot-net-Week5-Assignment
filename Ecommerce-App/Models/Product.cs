using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce_App.Models
{
    internal class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int ProductCategoryId { get; set; }
        public int stock  { get; set;  }
        public ProductCategory Category{ get; set; }
        }
}
