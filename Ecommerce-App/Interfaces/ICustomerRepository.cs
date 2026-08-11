using Ecommerce_App.Models;
using System.Collections.Generic;

namespace Ecommerce_App.Interfaces
{
    internal interface ICustomerRepository
    {
        List<Customer> GetAll();
        Customer GetById(int id);
        List<Customer> GetByCity(string city);
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(int id);
    }
}