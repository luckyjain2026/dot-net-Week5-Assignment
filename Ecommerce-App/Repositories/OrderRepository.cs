using Ecommerce_App.DataContext;
using Ecommerce_App.Interfaces;
using Ecommerce_App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce_App.Repositories
{
    internal class OrderRepository : IOrderRepository
    {
        private readonly EcommerceContext _context;
        public OrderRepository(EcommerceContext context)
        {
            _context = context;
        }

        // Get all orders
        public List<Order> GetAll()
        {
            return _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                .ToList();
        }

        // Get order by ID
        public Order GetById(int id)
        {
            return _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                .FirstOrDefault(o => o.OrderId == id);
        }

        // Get orders of a specific customer
        public List<Order> GetOrdersByCustomer(int customerId)
        {
            return _context.Orders
                .Where(o => o.CustomerId == customerId)
                .OrderByDescending(o => o.OrderDate)
                .ToList();
        }

        // Get orders between two dates
        public List<Order> GetOrdersByDateRange(
            DateTime startDate,
            DateTime endDate)
        {
            return _context.Orders
                .Where(o => o.OrderDate >= startDate &&
                            o.OrderDate <= endDate)
                .OrderByDescending(o => o.OrderDate)
                .ToList();
        }

        // Count orders of a customer
        public int GetOrderCountByCustomer(int customerId)
        {
            return _context.Orders
                .Count(o => o.CustomerId == customerId);
        }

        // Calculate total sales
        public decimal GetTotalSales(DateTime startDate,DateTime endDate)
        {
            return _context.OrderItems
                .Where(od => od.Order.OrderDate >= startDate &&
                             od.Order.OrderDate <= endDate)
                .Sum(od => od.Quantity * od.UnitPrice);
        }

        // Add order
        public void Add(Order order)
        {
            _context.Orders.Add(order);
        }

        // Update order
        public void Update(Order order)
        {
            _context.Orders.Update(order);
        }

        // Delete order
        public void Delete(int id)
        {
            Order order = GetById(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
            }
        }
    }
}
