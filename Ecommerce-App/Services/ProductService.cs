
using Ecommerce_App.Models;

namespace Ecommerce_App.Services
{
    internal class ProductService
    {
        private readonly UnitOfWork _unitOfWork;
        public ProductService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void GetAllProducts()
        {
            var products = _unitOfWork.Products.GetAll();
            Console.WriteLine("===== ALL PRODUCTS =====");
            if (products.Count == 0)
            {
                Console.WriteLine("No products found.");
                return;
            }

            foreach (var product in products)
            {
                Console.WriteLine(
                    $"ID: {product.ProductId}, " +
                    $"Name: {product.Name}, " +
                    $"Price: {product.Price:C}, " +
                    $"Stock: {product.stock}");
            }
        }
        public void GetProductById()
        {
            Console.Write("Enter Product ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid Product ID. Please enter a valid number.");
                return;
            }

            var product = _unitOfWork.Products.GetById(id);
            if (product == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }
            Console.WriteLine($"ID: {product.ProductId}");
            Console.WriteLine($"Name: {product.Name}");
            Console.WriteLine($"Price: {product.Price:C}");
            Console.WriteLine($"Stock: {product.stock}");
        }

        public void GetProductsByCategory()
        {
            Console.Write("Enter Category ID: ");
            if (!int.TryParse(Console.ReadLine(), out int categoryId))
            {
                Console.WriteLine("Invalid Category ID. Please enter a valid number.");
                return;
            }
            if (categoryId <= 0)
            {
                Console.WriteLine("Category ID must be greater than 0.");
                return;
            }
            var products = _unitOfWork.Products.GetByCategory(categoryId);
            if (products.Count == 0)
            {
                Console.WriteLine("No products found.");
                return;
            }

            foreach (var product in products)
            {
                Console.WriteLine(
                    $"ID: {product.ProductId}, " +
                    $"Name: {product.Name}, " +
                    $"Price: {product.Price:C}");
            }
        }

        public void GetProductsByPrice()
        {
            Console.Write("Enter Minimum Price: ");

            if (!decimal.TryParse(
                Console.ReadLine(),
                out decimal minPrice))
            {
                Console.WriteLine("Invalid minimum price. Please enter a valid number.");
                return;
            }

            Console.Write("Enter Maximum Price: ");

            if (!decimal.TryParse(
                Console.ReadLine(),
                out decimal maxPrice))
            {
                Console.WriteLine("Invalid maximum price. Please enter a valid number.");
                return;
            }

            if (minPrice < 0 || maxPrice < 0)
            {
                Console.WriteLine("Price cannot be negative.");
                return;
            }

            if (minPrice > maxPrice)
            {
                Console.WriteLine("Minimum price cannot be greater than maximum price.");
                return;
            }

            var products = _unitOfWork.Products.GetProductsByPrice(
                minPrice,
                maxPrice);

            if (products.Count == 0)
            {
                Console.WriteLine("No products found in this price range.");
                return;
            }

            foreach (var product in products)
            {
                Console.WriteLine(
                    $"ID: {product.ProductId}, " +
                    $"Name: {product.Name}, " +
                    $"Price: {product.Price:C}");
            }
        }

        public void GetMostPopularProducts()
        {
            var products = _unitOfWork.Products.GetMostPopularProducts();
            Console.WriteLine("===== MOST POPULAR PRODUCTS =====");
            if (products.Count == 0)
            {
                Console.WriteLine("No popular products found.");
                return;
            }
            foreach (var product in products)
            {
                Console.WriteLine(
                    $"ID: {product.ProductId}, " +
                    $"Name: {product.Name}, " +
                    $"Price: {product.Price:C}");
            }
        }

        public void AddProduct()
        {
            Product product = new Product();
            Console.Write("Enter Product Name: ");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Product name cannot be empty.");
                return;
            }
            product.Name = name;
            Console.Write("Enter Price: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                Console.WriteLine("Invalid price. Please enter a valid number.");
                return;
            }

            if (price < 0)
            {
                Console.WriteLine("Price cannot be negative.");
                return;
            }
            product.Price = price;
            Console.Write("Enter Category ID: ");
            if (!int.TryParse(Console.ReadLine(), out int categoryId))
            {
                Console.WriteLine("Invalid Category ID. Please enter a valid number.");
                return;
            }
            if (categoryId <= 0)
            {
                Console.WriteLine("Category ID must be greater than 0.");
                return;
            }
            product.ProductCategoryId = categoryId;
            Console.Write("Enter Stock: ");
            if (!int.TryParse(Console.ReadLine(), out int stock))
            {
                Console.WriteLine("Invalid stock. Please enter a valid number.");
                return;
            }
            if (stock < 0)
            {
                Console.WriteLine("Stock cannot be negative.");
                return;
            }
            product.stock = stock;
            _unitOfWork.Products.Add(product);
            _unitOfWork.Save();
            Console.WriteLine("Product added successfully.");
        }

        public void UpdateProduct()
        {
            Console.Write("Enter Product ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid Product ID. Please enter a valid number.");
                return;
            }
            var product = _unitOfWork.Products.GetById(id);
            if (product == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            Console.Write("Enter new Product Name: ");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Product name cannot be empty.");
                return;
            }
            Console.Write("Enter new Price: ");
            if (!decimal.TryParse(
                Console.ReadLine(),
                out decimal price))
            {
                Console.WriteLine("Invalid price. Please enter a valid number.");
                return;
            }
            if (price < 0)
            {
                Console.WriteLine("Price cannot be negative.");
                return;
            }
            Console.Write("Enter new Category ID: ");

            if (!int.TryParse(
                Console.ReadLine(),
                out int categoryId))
            {
                Console.WriteLine("Invalid Category ID. Please enter a valid number.");
                return;
            }
            if (categoryId <= 0)
            {
                Console.WriteLine("Category ID must be greater than 0.");
                return;
            }

            Console.Write("Enter new Stock: ");
            if (!int.TryParse(
                Console.ReadLine(),
                out int stock))
            {
                Console.WriteLine("Invalid stock. Please enter a valid number.");
                return;
            }

            if (stock < 0)
            {
                Console.WriteLine("Stock cannot be negative.");
                return;
            }

            product.Name = name;
            product.Price = price;
            product.ProductCategoryId = categoryId;
            product.stock = stock;

            _unitOfWork.Products.Update(product);
            _unitOfWork.Save();
            Console.WriteLine("Product updated successfully.");
        }

        public void DeleteProduct()
        {
            Console.Write("Enter Product ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid Product ID. Please enter a valid number.");
                return;
            }
            var product = _unitOfWork.Products.GetById(id);
            if (product == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }
            _unitOfWork.Products.Delete(id);
            _unitOfWork.Save();
            Console.WriteLine("Product deleted successfully.");
        }
    }
}
