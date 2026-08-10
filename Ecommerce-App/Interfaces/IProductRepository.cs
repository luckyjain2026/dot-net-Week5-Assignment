using Ecommerce_App.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce_App.Interfaces
{
    internal interface IProductRepository
    {
        List<Product> GetAll();
        Product GetById(int id);
        List<Product> GetByCategory(int categoryId);
        List<Product> GetProductsByPrice(decimal minPrice, decimal maxPrice);
        List<Product> GetMostPopularProducts();
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}
