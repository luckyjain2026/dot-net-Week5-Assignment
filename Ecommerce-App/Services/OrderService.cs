
using Ecommerce_App.Models;
using System.Globalization;

namespace Ecommerce_App.Services
{
    internal class OrderService
    {
        private readonly UnitOfWork _unitOfWork;
        public OrderService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void GetAllOrders()
        {
            var orders = _unitOfWork.Orders.GetAll();
            Console.WriteLine("===== ALL ORDERS =====");
            if (orders.Count == 0)
            {
                Console.WriteLine("No orders found.");
                return;
            }
            foreach (var order in orders)
            {
                Console.WriteLine(
                    $"Order ID: {order.OrderId}, " +
                    $"Customer ID: {order.CustomerId}, " +
                    $"Date: {order.OrderDate:yyyy-MM-dd}, " +
                    $"Total: {order.TotalAmount:C}");
            }
        }

        public void GetOrderById()
        {
            Console.Write("Enter Order ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid Order ID. Please enter a valid number.");
                return;
            }
            var order = _unitOfWork.Orders.GetById(id);
            if (order == null)
            {
                Console.WriteLine("Order not found.");
                return;
            }
            Console.WriteLine($"Order ID: {order.OrderId}");
            Console.WriteLine($"Customer ID: {order.CustomerId}");
            Console.WriteLine($"Order Date: {order.OrderDate:yyyy-MM-dd}");
            Console.WriteLine($"Total Amount: {order.TotalAmount:C}");
        }

        public void GetOrdersByCustomer()
        {
            Console.Write("Enter Customer ID: ");
            if (!int.TryParse(Console.ReadLine(), out int customerId))
            {
                Console.WriteLine("Invalid Customer ID. Please enter a valid number.");
                return;
            }
            var orders = _unitOfWork.Orders.GetOrdersByCustomer(customerId);
            if (orders.Count == 0)
            {
                Console.WriteLine("No orders found for this customer.");
                return;
            }
            foreach (var order in orders)
            {
                Console.WriteLine(
                    $"Order ID: {order.OrderId}, " +
                    $"Date: {order.OrderDate:yyyy-MM-dd}, " +
                    $"Total: {order.TotalAmount:C}");
            }
        }

        public void GetOrdersByDateRange()
        {
            Console.Write("Enter Start Date (yyyy-MM-dd): ");
            if (!DateTime.TryParseExact(
                Console.ReadLine(),
                "yyyy-MM-dd",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime startDate))
            {
                Console.WriteLine("Invalid start date. Please use yyyy-MM-dd format.");
                return;
            }

            Console.Write("Enter End Date (yyyy-MM-dd): ");
            if (!DateTime.TryParseExact(
                Console.ReadLine(),
                "yyyy-MM-dd",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime endDate))
            {
                Console.WriteLine("Invalid end date. Please use yyyy-MM-dd format.");
                return;
            }

            if (startDate > endDate)
            {
                Console.WriteLine("Start date cannot be greater than end date.");
                return;
            }

            var orders = _unitOfWork.Orders.GetOrdersByDateRange(
                startDate,
                endDate);

            if (orders.Count == 0)
            {
                Console.WriteLine("No orders found in this date range.");
                return;
            }

            foreach (var order in orders)
            {
                Console.WriteLine(
                    $"Order ID: {order.OrderId}, " +
                    $"Date: {order.OrderDate:yyyy-MM-dd}, " +
                    $"Total: {order.TotalAmount:C}");
            }
        }

        public void GetOrderCount()
        {
            Console.Write("Enter Customer ID: ");
            if (!int.TryParse(Console.ReadLine(), out int customerId))
            {
                Console.WriteLine("Invalid Customer ID. Please enter a valid number.");
                return;
            }
            int count = _unitOfWork.Orders.GetOrderCountByCustomer(customerId);
            Console.WriteLine($"Customer {customerId} has {count} order(s).");
        }

        public void GetTotalSales()
        {
            Console.Write("Enter Start Date (yyyy-MM-dd): ");
            if (!DateTime.TryParseExact(Console.ReadLine(),  "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime startDate))
            {
                Console.WriteLine("Invalid start date. Please use yyyy-MM-dd format.");
                return;
            }

            Console.Write("Enter End Date (yyyy-MM-dd): ");
            if (!DateTime.TryParseExact(Console.ReadLine(),  "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime endDate))
            {
                Console.WriteLine("Invalid end date. Please use yyyy-MM-dd format.");
                return;
            }

            if (startDate > endDate)
            {
                Console.WriteLine("Start date cannot be greater than end date.");
                return;
            }

            decimal totalSales = _unitOfWork.Orders.GetTotalSales(startDate,endDate);
            Console.WriteLine($"Total Sales: {totalSales:C}");
        }

        public void AddOrder()
        {
            Order order = new Order();
            Console.Write("Enter Customer ID: ");
            if (!int.TryParse(Console.ReadLine(), out int customerId))
            {
                Console.WriteLine("Invalid Customer ID. Please enter a valid number.");
                return;
            }
            var customer = _unitOfWork.Customers.GetById(customerId);
            if (customer == null)
            {
                Console.WriteLine("Customer not found.");
                return;
            }
            order.CustomerId = customerId;
            Console.Write("Enter Order Date (yyyy-MM-dd): ");
            if (!DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime orderDate))
            {
                Console.WriteLine("Invalid order date. Please use yyyy-MM-dd format.");
                return;
            }

            order.OrderDate = orderDate;
            Console.Write("Enter Total Amount: ");

            if (!decimal.TryParse(
                Console.ReadLine(),
                out decimal totalAmount))
            {
                Console.WriteLine("Invalid amount. Please enter a valid number.");
                return;
            }

            if (totalAmount < 0)
            {
                Console.WriteLine("Total amount cannot be negative.");
                return;
            }

            order.TotalAmount = totalAmount;

            _unitOfWork.Orders.Add(order);
            _unitOfWork.Save();

            Console.WriteLine("Order added successfully.");
        }

        public void UpdateOrder()
        {
            Console.Write("Enter Order ID: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid Order ID. Please enter a valid number.");
                return;
            }

            var order = _unitOfWork.Orders.GetById(id);

            if (order == null)
            {
                Console.WriteLine("Order not found.");
                return;
            }

            Console.Write("Enter new Order Date (yyyy-MM-dd): ");

            if (!DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime orderDate))
            {
                Console.WriteLine("Invalid order date. Please use yyyy-MM-dd format.");
                return;
            }

            Console.Write("Enter new Total Amount: ");
            if (!decimal.TryParse(
                Console.ReadLine(),
                out decimal totalAmount))
            {
                Console.WriteLine("Invalid amount. Please enter a valid number.");
                return;
            }

            if (totalAmount < 0)
            {
                Console.WriteLine("Total amount cannot be negative.");
                return;
            }
            order.OrderDate = orderDate;
            order.TotalAmount = totalAmount;
            _unitOfWork.Orders.Update(order);
            _unitOfWork.Save();
            Console.WriteLine("Order updated successfully.");
        }

        public void DeleteOrder()
        {
            Console.Write("Enter Order ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid Order ID. Please enter a valid number.");
                return;
            }
            var order = _unitOfWork.Orders.GetById(id);
            if (order == null)
            {
                Console.WriteLine("Order not found.");
                return;
            }
            _unitOfWork.Orders.Delete(id);
            _unitOfWork.Save();
            Console.WriteLine("Order deleted successfully.");
        }
    }
}
