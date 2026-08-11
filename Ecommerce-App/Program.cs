using Ecommerce_App.DataContext;
using Ecommerce_App.Services;

namespace Ecommerce_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EcommerceContext context = new EcommerceContext();

            UnitOfWork unitOfWork = new UnitOfWork(context);

            CustomerService customerService = new CustomerService(unitOfWork);

            ProductService productService =new ProductService(unitOfWork);

            OrderService orderService = new OrderService(unitOfWork);

            bool running = true;

            while (running)
            {
                Console.Clear();

                Console.WriteLine(Constant.MENU_TITLE);

                Console.WriteLine();
                Console.WriteLine("===== CUSTOMER =====");
                Console.WriteLine(Constant.GET_ALL_CUSTOMERS);
                Console.WriteLine(Constant.GET_CUSTOMER_BY_ID);
                Console.WriteLine(Constant.GET_CUSTOMERS_BY_CITY);
                Console.WriteLine(Constant.ADD_CUSTOMER);
                Console.WriteLine(Constant.UPDATE_CUSTOMER);
                Console.WriteLine(Constant.DELETE_CUSTOMER);

                Console.WriteLine();
                Console.WriteLine("===== PRODUCT =====");
                Console.WriteLine(Constant.GET_ALL_PRODUCTS);
                Console.WriteLine(Constant.GET_PRODUCT_BY_ID);
                Console.WriteLine(Constant.GET_PRODUCTS_BY_CATEGORY);
                Console.WriteLine(Constant.GET_PRODUCTS_BY_PRICE);
                Console.WriteLine(Constant.GET_MOST_POPULAR_PRODUCTS);
                Console.WriteLine(Constant.ADD_PRODUCT);
                Console.WriteLine(Constant.UPDATE_PRODUCT);
                Console.WriteLine(Constant.DELETE_PRODUCT);

                Console.WriteLine();
                Console.WriteLine("===== ORDER =====");
                Console.WriteLine(Constant.GET_ALL_ORDERS);
                Console.WriteLine(Constant.GET_ORDER_BY_ID);
                Console.WriteLine(Constant.GET_ORDERS_BY_CUSTOMER);
                Console.WriteLine(Constant.GET_ORDERS_BY_DATE);
                Console.WriteLine(Constant.GET_ORDER_COUNT);
                Console.WriteLine(Constant.GET_TOTAL_SALES);
                Console.WriteLine(Constant.ADD_ORDER);
                Console.WriteLine(Constant.UPDATE_ORDER);
                Console.WriteLine(Constant.DELETE_ORDER);

                Console.WriteLine();
                Console.WriteLine(Constant.EXIT);

                Console.Write("\nEnter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    // CUSTOMER
                    case "1":
                        customerService.GetAllCustomers();
                        break;

                    case "2":
                        customerService.GetCustomerById();
                        break;

                    case "3":
                        customerService.GetCustomersByCity();
                        break;

                    case "4":
                        customerService.AddCustomer();
                        break;

                    case "5":
                        customerService.UpdateCustomer();
                        break;

                    case "6":
                        customerService.DeleteCustomer();
                        break;

                    // PRODUCT
                    case "7":
                        productService.GetAllProducts();
                        break;

                    case "8":
                        productService.GetProductById();
                        break;

                    case "9":
                        productService.GetProductsByCategory();
                        break;

                    case "10":
                        productService.GetProductsByPrice();
                        break;

                    case "11":
                        productService.GetMostPopularProducts();
                        break;

                    case "12":
                        productService.AddProduct();
                        break;

                    case "13":
                        productService.UpdateProduct();
                        break;

                    case "14":
                        productService.DeleteProduct();
                        break;

                    // ORDER
                    case "15":
                        orderService.GetAllOrders();
                        break;

                    case "16":
                        orderService.GetOrderById();
                        break;

                    case "17":
                        orderService.GetOrdersByCustomer();
                        break;

                    case "18":
                        orderService.GetOrdersByDateRange();
                        break;

                    case "19":
                        orderService.GetOrderCount();
                        break;

                    case "20":
                        orderService.GetTotalSales();
                        break;

                    case "21":
                        orderService.AddOrder();
                        break;

                    case "22":
                        orderService.UpdateOrder();
                        break;

                    case "23":
                        orderService.DeleteOrder();
                        break;

                    case "0":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

                if (running)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }

            unitOfWork.Dispose();
        }
    }
}