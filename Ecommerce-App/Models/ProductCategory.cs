using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce_App.Models
{
    internal class ProductCategory
    {
        public int ProductCategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Product> Products { get; set; }
    }
}
