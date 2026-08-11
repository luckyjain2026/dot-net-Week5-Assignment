using Ecommerce_App.DataContext;
using Ecommerce_App.Interfaces;
using Ecommerce_App.Repositories;

namespace Ecommerce_App
{
    internal class UnitOfWork
    {
        private readonly EcommerceContext _context;
        public ICustomerRepository Customers { get; }
        public IProductRepository Products { get; }
        public IOrderRepository Orders { get; }
        public UnitOfWork(EcommerceContext context)
        {
            _context = context;
            Customers = new CustomerRepository(_context);
            Products = new ProductRepository(_context);
            Orders = new OrderRepository(_context);
        }
        public int Save()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}