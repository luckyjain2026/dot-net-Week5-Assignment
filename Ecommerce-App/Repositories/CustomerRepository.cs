using Ecommerce_App.DataContext;
using Ecommerce_App.Interfaces;
using Ecommerce_App.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce_App.Repositories
{
    internal class CustomerRepository : ICustomerRepository
    {
        private readonly EcommerceContext _context;
        public CustomerRepository(EcommerceContext context)
        {
            _context = context;
        }

        // Get all customers
        public List<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        // Get customer by ID
        public Customer GetById(int id)
        {
            return _context.Customers.FirstOrDefault(c => c.CustomerId == id);
        }

        // Get customers by city
        public List<Customer> GetByCity(string city)
        {
            return _context.Customers.Where(c => c.City == city).ToList();
        }

        // Add customer
        public void Add(Customer customer)
        {
            _context.Customers.Add(customer);
        }

        // Update customer
        public void Update(Customer customer)
        {
            _context.Customers.Update(customer);
        }

        // Delete customer
        public void Delete(int id)
        {
            Customer customer = GetById(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
            }
        }
    }
}
