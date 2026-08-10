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
                Console.WriteLine($"{Constant.GET_ALL_CUSTOMERS}. Get All Customers");
                Console.WriteLine($"{Constant.GET_CUSTOMER_BY_ID}. Get Customer By ID");
                Console.WriteLine($"{Constant.GET_CUSTOMERS_BY_CITY}. Get Customers By City");
                Console.WriteLine($"{Constant.ADD_CUSTOMER}. Add Customer");
                Console.WriteLine($"{Constant.UPDATE_CUSTOMER}. Update Customer");
                Console.WriteLine($"{Constant.DELETE_CUSTOMER}. Delete Customer");

                Console.WriteLine();
                Console.WriteLine("===== PRODUCT =====");
                Console.WriteLine($"{Constant.GET_ALL_PRODUCTS}. Get All Products");
                Console.WriteLine($"{Constant.GET_PRODUCT_BY_ID}. Get Product By ID");
                Console.WriteLine($"{Constant.GET_PRODUCTS_BY_CATEGORY}. Get Products By Category");
                Console.WriteLine($"{Constant.GET_PRODUCTS_BY_PRICE}. Get Products By Price");
                Console.WriteLine($"{Constant.GET_MOST_POPULAR_PRODUCTS}. Most Popular Products");
                Console.WriteLine($"{Constant.ADD_PRODUCT}. Add Product");
                Console.WriteLine($"{Constant.UPDATE_PRODUCT}. Update Product");
                Console.WriteLine($"{Constant.DELETE_PRODUCT}. Delete Product");

                Console.WriteLine();
                Console.WriteLine("===== ORDER =====");
                Console.WriteLine($"{Constant.GET_ALL_ORDERS}. Get All Orders");
                Console.WriteLine($"{Constant.GET_ORDER_BY_ID}. Get Order By ID");
                Console.WriteLine($"{Constant.GET_ORDERS_BY_CUSTOMER}. Orders By Customer");
                Console.WriteLine($"{Constant.GET_ORDERS_BY_DATE}. Orders By Date");
                Console.WriteLine($"{Constant.GET_ORDER_COUNT}. Order Count");
                Console.WriteLine($"{Constant.GET_TOTAL_SALES}. Total Sales");
                Console.WriteLine($"{Constant.ADD_ORDER}. Add Order");
                Console.WriteLine($"{Constant.UPDATE_ORDER}. Update Order");
                Console.WriteLine($"{Constant.DELETE_ORDER}. Delete Order");

                Console.WriteLine();
                Console.WriteLine($"{Constant.EXIT}. Exit");

                Console.Write("\nEnter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    // CUSTOMER
                    case Constant.GET_ALL_CUSTOMERS:
                        customerService.GetAllCustomers();
                        break;

                    case Constant.GET_CUSTOMER_BY_ID:
                        customerService.GetCustomerById();
                        break;

                    case Constant.GET_CUSTOMERS_BY_CITY:
                        customerService.GetCustomersByCity();
                        break;

                    case Constant.ADD_CUSTOMER:
                        customerService.AddCustomer();
                        break;

                    case Constant.UPDATE_CUSTOMER:
                        customerService.UpdateCustomer();
                        break;

                    case Constant.DELETE_CUSTOMER:
                        customerService.DeleteCustomer();
                        break;

                    // PRODUCT
                    case Constant.GET_ALL_PRODUCTS:
                        productService.GetAllProducts();
                        break;

                    case Constant.GET_PRODUCT_BY_ID:
                        productService.GetProductById();
                        break;

                    case Constant.GET_PRODUCTS_BY_CATEGORY:
                        productService.GetProductsByCategory();
                        break;

                    case Constant.GET_PRODUCTS_BY_PRICE:
                        productService.GetProductsByPrice();
                        break;

                    case Constant.GET_MOST_POPULAR_PRODUCTS:
                        productService.GetMostPopularProducts();
                        break;

                    case Constant.ADD_PRODUCT:
                        productService.AddProduct();
                        break;

                    case Constant.UPDATE_PRODUCT:
                        productService.UpdateProduct();
                        break;

                    case Constant.DELETE_PRODUCT:
                        productService.DeleteProduct();
                        break;

                    // ORDER
                    case Constant.GET_ALL_ORDERS:
                        orderService.GetAllOrders();
                        break;

                    case Constant.GET_ORDER_BY_ID:
                        orderService.GetOrderById();
                        break;

                    case Constant.GET_ORDERS_BY_CUSTOMER:
                        orderService.GetOrdersByCustomer();
                        break;

                    case Constant.GET_ORDERS_BY_DATE:
                        orderService.GetOrdersByDateRange();
                        break;

                    case Constant.GET_ORDER_COUNT:
                        orderService.GetOrderCount();
                        break;

                    case Constant.GET_TOTAL_SALES:
                        orderService.GetTotalSales();
                        break;

                    case Constant.ADD_ORDER:
                        orderService.AddOrder();
                        break;

                    case Constant.UPDATE_ORDER:
                        orderService.UpdateOrder();
                        break;

                    case Constant.DELETE_ORDER:
                        orderService.DeleteOrder();
                        break;

                    case Constant.EXIT:
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