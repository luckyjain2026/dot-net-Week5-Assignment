
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
            Console.WriteLine("===== ALL CUSTOMERS =====");
            if (customers.Count == 0)
            {
                Console.WriteLine("No customers found.");
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
            Console.Write("Enter Customer ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid Customer ID. Please enter a valid number.");
                return;
            }
            var customer = _unitOfWork.Customers.GetById(id);
            if (customer == null)
            {
                Console.WriteLine("Customer not found.");
                return;
            }

            Console.WriteLine($"ID: {customer.CustomerId}");
            Console.WriteLine($"Name: {customer.Name}");
            Console.WriteLine($"Email: {customer.Email}");
            Console.WriteLine($"City: {customer.City}");
        }

        public void GetCustomersByCity()
        {
            Console.Write("Enter City: ");
            string city = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(city))
            {
                Console.WriteLine("City cannot be empty.");
                return;
            }
            var customers = _unitOfWork.Customers.GetByCity(city);
            if (customers.Count == 0)
            {
                Console.WriteLine("No customers found.");
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
            Console.Write("Enter Name: ");
            customer.Name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(customer.Name))
            {
                Console.WriteLine("Name cannot be empty.");
                return;
            }
            Console.Write("Enter Email: ");
            string email = Console.ReadLine();
            if (!IsValidEmail(email))
            {
                Console.WriteLine("Invalid email format.");
                return;
            }
            customer.Email = email;
            Console.Write("Enter City: ");
            customer.City = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(customer.City))
            {
                Console.WriteLine("City cannot be empty.");
                return;
            }
            _unitOfWork.Customers.Add(customer);
            _unitOfWork.Save();
            Console.WriteLine("Customer added successfully.");
        }

        public void UpdateCustomer()
        {
            Console.Write("Enter Customer ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid Customer ID. Please enter a valid number.");
                return;
            }
            var customer = _unitOfWork.Customers.GetById(id);
            if (customer == null)
            {
                Console.WriteLine("Customer not found.");
                return;
            }
            Console.Write("Enter new Name: ");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name cannot be empty.");
                return;
            }
            Console.Write("Enter new Email: ");
            string email = Console.ReadLine();
            if (!IsValidEmail(email))
            {
                Console.WriteLine("Invalid email format.");
                return;
            }

            Console.Write("Enter new City: ");
            string city = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(city))
            {
                Console.WriteLine("City cannot be empty.");
                return;
            }

            customer.Name = name;
            customer.Email = email;
            customer.City = city;
            _unitOfWork.Customers.Update(customer);
            _unitOfWork.Save();
            Console.WriteLine("Customer updated successfully.");
        }
        public void DeleteCustomer()
        {
            Console.Write("Enter Customer ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid Customer ID. Please enter a valid number.");
                return;
            }

            var customer = _unitOfWork.Customers.GetById(id);
            if (customer == null)
            {
                Console.WriteLine("Customer not found.");
                return;
            }
            _unitOfWork.Customers.Delete(id);
            _unitOfWork.Save();
            Console.WriteLine("Customer deleted successfully.");
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

