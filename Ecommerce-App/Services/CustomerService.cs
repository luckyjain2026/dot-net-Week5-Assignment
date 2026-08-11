
using Ecommerce_App.Models;
using System.Net.Mail;

namespace Ecommerce_App.Services
{
    internal class CustomerService
    {
        private readonly UnitOfWork _unitOfWork;
        public CustomerService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void GetAllCustomers()
        {
            var customers = _unitOfWork.Customers.GetAll();
            Console.WriteLine(Constant.ALL_CUSTOMERS_TITLE);
            if (customers.Count == 0)
            {
                Console.WriteLine(Constant.NO_CUSTOMERS_FOUND);
                return;
            }
            foreach (var customer in customers)
            {
                Console.WriteLine(
                    $"ID: {customer.CustomerId}, " +
                    $"Name: {customer.Name}, " +
                    $"Email: {customer.Email}, " +
                    $"City: {customer.City}");
            }
        }

        public void GetCustomerById()
        {
            Console.Write(Constant.ENTER_CUSTOMER_ID);
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine(Constant.INVALID_CUSTOMER_ID);
                return;
            }
            var customer = _unitOfWork.Customers.GetById(id);
            if (customer == null)
            {
                Console.WriteLine(Constant.CUSTOMER_NOT_FOUND);
                return;
            }

            Console.WriteLine($"ID: {customer.CustomerId}");
            Console.WriteLine($"Name: {customer.Name}");
            Console.WriteLine($"Email: {customer.Email}");
            Console.WriteLine($"City: {customer.City}");
        }

        public void GetCustomersByCity()
        {
            Console.Write(Constant.ENTER_CITY);
            string city = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(city))
            {
                Console.WriteLine(Constant.CITY_CANNOT_BE_EMPTY);
                return;
            }
            var customers = _unitOfWork.Customers.GetByCity(city);
            if (customers.Count == 0)
            {
                Console.WriteLine(Constant.NO_CUSTOMERS_FOUND);
                return;
            }

            foreach (var customer in customers)
            {
                Console.WriteLine(
                    $"ID: {customer.CustomerId}, " +
                    $"Name: {customer.Name}, " +
                    $"Email: {customer.Email}, " +
                    $"City: {customer.City}");
            }
        }

        public void AddCustomer()
        {
            Customer customer = new Customer();
            Console.Write(Constant.ENTER_NAME);
            customer.Name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(customer.Name))
            {
                Console.WriteLine(Constant.NAME_CANNOT_BE_EMPTY);
                return;
            }
            Console.Write(Constant.ENTER_EMAIL);
            string email = Console.ReadLine();
            if (!IsValidEmail(email))
            {
                Console.WriteLine(Constant.INVALID_EMAIL);
                return;
            }
            customer.Email = email;
            Console.Write(Constant.ENTER_CITY);
            customer.City = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(customer.City))
            {
                Console.WriteLine(Constant.CITY_CANNOT_BE_EMPTY);
                return;
            }
            _unitOfWork.Customers.Add(customer);
            _unitOfWork.Save();
            Console.WriteLine(Constant.CUSTOMER_ADDED_SUCCESSFULLY);
        }

        public void UpdateCustomer()
        {
            Console.Write(Constant.ENTER_CUSTOMER_ID);
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine(Constant.INVALID_CUSTOMER_ID);
                return;
            }
            var customer = _unitOfWork.Customers.GetById(id);
            if (customer == null)
            {
                Console.WriteLine(Constant.CUSTOMER_NOT_FOUND);
                return;
            }
            Console.Write(Constant.ENTER_NEW_NAME);
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine(Constant.NAME_CANNOT_BE_EMPTY);
                return;
            }
            Console.Write(Constant.ENTER_NEW_EMAIL);
            string email = Console.ReadLine();
            if (!IsValidEmail(email))
            {
                Console.WriteLine(Constant.INVALID_EMAIL);
                return;
            }

            Console.Write(Constant.ENTER_NEW_CITY);
            string city = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(city))
            {
                Console.WriteLine(Constant.CITY_CANNOT_BE_EMPTY);
                return;
            }

            customer.Name = name;
            customer.Email = email;
            customer.City = city;
            _unitOfWork.Customers.Update(customer);
            _unitOfWork.Save();
            Console.WriteLine(Constant.CUSTOMER_UPDATED_SUCCESSFULLY);
        }
        public void DeleteCustomer()
        {
            Console.Write(Constant.ENTER_CUSTOMER_ID);
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine(Constant.INVALID_CUSTOMER_ID);
                return;
            }

            var customer = _unitOfWork.Customers.GetById(id);
            if (customer == null)
            {
                Console.WriteLine(Constant.CUSTOMER_NOT_FOUND);
                return;
            }
            _unitOfWork.Customers.Delete(id);
            _unitOfWork.Save();
            Console.WriteLine(Constant.CUSTOMER_DELETED_SUCCESSFULLY);
        }
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            try
            {
                MailAddress mailAddress = new MailAddress(email);
                return mailAddress.Address == email;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
    }

