using Ecommerce_App.DataContext;
using Ecommerce_App.Interfaces;
using Ecommerce_App.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce_App.Repositories
{
    internal class ProductRepository : IProductRepository
    {
        private readonly EcommerceContext _context;

        public ProductRepository(EcommerceContext context)
        {
            _context = context;
        }

        // Get all products
        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        // Get product by ID
        public Product GetById(int id)
        {
            return _context.Products
                .FirstOrDefault(p => p.ProductId == id);
        }

        // Get products by category
        public List<Product> GetByCategory(int categoryId)
        {
            return _context.Products
                .Where(p => p.ProductCategoryId == categoryId)
                .ToList();
        }

        // Get products within price range
        public List<Product> GetProductsByPrice(decimal minPrice,decimal maxPrice)
        {
            return _context.Products
                .Where(p => p.Price >= minPrice &&
                            p.Price <= maxPrice)
                .OrderBy(p => p.Price)
                .ToList();
        }

        // Get most popular products
        public List<Product> GetMostPopularProducts()
        {
            return _context.OrderItems
                .GroupBy(od => od.ProductId)
                .OrderByDescending(g => g.Sum(od => od.Quantity))
                .Select(g => g.First().Product)
                .ToList();
        }

        // Add product
        public void Add(Product product)
        {
            _context.Products.Add(product);
        }

        // Update product
        public void Update(Product product)
        {
            _context.Products.Update(product);
        }

        // Delete product
        public void Delete(int id)
        {
            Product product = GetById(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
        }
    }
}
