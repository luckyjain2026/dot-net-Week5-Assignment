
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
            Console.WriteLine(Constant.ALL_ORDERS_TITLE);
            if (orders.Count == 0)
            {
                Console.WriteLine(Constant.NO_ORDERS_FOUND);
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
            Console.Write(Constant.ENTER_ORDER_ID);
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine(Constant.INVALID_ORDER_ID);
                return;
            }
            var order = _unitOfWork.Orders.GetById(id);
            if (order == null)
            {
                Console.WriteLine(Constant.ORDER_NOT_FOUND);
                return;
            }
            Console.WriteLine($"Order ID: {order.OrderId}");
            Console.WriteLine($"Customer ID: {order.CustomerId}");
            Console.WriteLine($"Order Date: {order.OrderDate:yyyy-MM-dd}");
            Console.WriteLine($"Total Amount: {order.TotalAmount:C}");
        }

        public void GetOrdersByCustomer()
        {
            Console.Write(Constant.ENTER_CUSTOMER_ID);
            if (!int.TryParse(Console.ReadLine(), out int customerId))
            {
                Console.WriteLine(Constant.INVALID_CUSTOMER_ID);
                return;
            }
            var orders = _unitOfWork.Orders.GetOrdersByCustomer(customerId);
            if (orders.Count == 0)
            {
                Console.WriteLine(Constant.NO_ORDERS_FOR_CUSTOMER);
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
            Console.Write(Constant.ENTER_START_DATE);
            if (!DateTime.TryParseExact(
                Console.ReadLine(),
                "yyyy-MM-dd",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime startDate))
            {
                Console.WriteLine(Constant.INVALID_START_DATE);
                return;
            }

            Console.Write(Constant.ENTER_END_DATE);
            if (!DateTime.TryParseExact(
                Console.ReadLine(),
                "yyyy-MM-dd",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime endDate))
            {
                Console.WriteLine(Constant.INVALID_END_DATE);
                return;
            }

            if (startDate > endDate)
            {
                Console.WriteLine(Constant.START_DATE_GREATER_THAN_END_DATE);
                return;
            }

            var orders = _unitOfWork.Orders.GetOrdersByDateRange(
                startDate,
                endDate);

            if (orders.Count == 0)
            {
                Console.WriteLine(Constant.NO_ORDERS_IN_DATE_RANGE);
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
            Console.Write(Constant.ENTER_CUSTOMER_ID);
            if (!int.TryParse(Console.ReadLine(), out int customerId))
            {
                Console.WriteLine(Constant.INVALID_CUSTOMER_ID);
                return;
            }
            int count = _unitOfWork.Orders.GetOrderCountByCustomer(customerId);
            Console.WriteLine($"Customer {customerId} has {count} order(s).");
        }

        public void GetTotalSales()
        {
            Console.Write(Constant.ENTER_START_DATE);
            if (!DateTime.TryParseExact(Console.ReadLine(),  "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime startDate))
            {
                Console.WriteLine(Constant.INVALID_START_DATE);
                return;
            }

            Console.Write(Constant.ENTER_END_DATE);
            if (!DateTime.TryParseExact(Console.ReadLine(),  "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime endDate))
            {
                Console.WriteLine(Constant.INVALID_END_DATE);
                return;
            }

            if (startDate > endDate)
            {
                Console.WriteLine(Constant.START_DATE_GREATER_THAN_END_DATE);
                return;
            }

            decimal totalSales = _unitOfWork.Orders.GetTotalSales(startDate,endDate);
            Console.WriteLine($"Total Sales: {totalSales:C}");
        }

        public void AddOrder()
        {
            Order order = new Order();
            Console.Write(Constant.ENTER_CUSTOMER_ID);
            if (!int.TryParse(Console.ReadLine(), out int customerId))
            {
                Console.WriteLine(Constant.INVALID_CUSTOMER_ID);
                return;
            }
            var customer = _unitOfWork.Customers.GetById(customerId);
            if (customer == null)
            {
                Console.WriteLine("Customer not found.");
                return;
            }
            order.CustomerId = customerId;
            Console.Write(Constant.ENTER_ORDER_DATE);
            if (!DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime orderDate))
            {
                Console.WriteLine(Constant.INVALID_ORDER_DATE);
                return;
            }

            order.OrderDate = orderDate;
            Console.Write(Constant.ENTER_TOTAL_AMOUNT);

            if (!decimal.TryParse(
                Console.ReadLine(),
                out decimal totalAmount))
            {
                Console.WriteLine(Constant.INVALID_AMOUNT);
                return;
            }

            if (totalAmount < 0)
            {
                Console.WriteLine(Constant.TOTAL_AMOUNT_CANNOT_BE_NEGATIVE);
                return;
            }

            order.TotalAmount = totalAmount;

            _unitOfWork.Orders.Add(order);
            _unitOfWork.Save();

            Console.WriteLine(Constant.ORDER_ADDED_SUCCESSFULLY);
        }

        public void UpdateOrder()
        {
            Console.Write(Constant.ENTER_ORDER_ID);

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine(Constant.INVALID_ORDER_ID);
                return;
            }

            var order = _unitOfWork.Orders.GetById(id);

            if (order == null)
            {
                Console.WriteLine(Constant.ORDER_NOT_FOUND);
                return;
            }

            Console.Write(Constant.ENTER_NEW_ORDER_DATE);

            if (!DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime orderDate))
            {
                Console.WriteLine(Constant.INVALID_ORDER_DATE);
                return;
            }

            Console.Write(Constant.ENTER_NEW_TOTAL_AMOUNT);
            if (!decimal.TryParse(
                Console.ReadLine(),
                out decimal totalAmount))
            {
                Console.WriteLine(Constant.INVALID_AMOUNT);
                return;
            }

            if (totalAmount < 0)
            {
                Console.WriteLine(Constant.TOTAL_AMOUNT_CANNOT_BE_NEGATIVE);
                return;
            }
            order.OrderDate = orderDate;
            order.TotalAmount = totalAmount;
            _unitOfWork.Orders.Update(order);
            _unitOfWork.Save();
            Console.WriteLine(Constant.ORDER_UPDATED_SUCCESSFULLY);
        }

        public void DeleteOrder()
        {
            Console.Write(Constant.ENTER_ORDER_ID);

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine(Constant.INVALID_ORDER_ID);
                return;
            }
            var order = _unitOfWork.Orders.GetById(id);
            if (order == null)
            {
                Console.WriteLine(Constant.ORDER_NOT_FOUND);
                return;
            }
            _unitOfWork.Orders.Delete(id);
            _unitOfWork.Save();
            Console.WriteLine(Constant.ORDER_DELETED_SUCCESSFULLY);
        }
    }
}
