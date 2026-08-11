using Ecommerce_App.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce_App.Interfaces
{
    internal interface IOrderRepository
    {
        List<Order> GetAll();
        Order GetById(int id);
        List<Order> GetOrdersByCustomer(int customerId);
        List<Order> GetOrdersByDateRange(DateTime startDate, DateTime endDate);
        int GetOrderCountByCustomer(int customerId);
        decimal GetTotalSales(DateTime startDate, DateTime endDate);
        void Add(Order order);
        void Update(Order order);
        void Delete(int id);
    }
}
