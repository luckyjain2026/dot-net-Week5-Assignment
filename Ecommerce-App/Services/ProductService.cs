
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
            Console.WriteLine(Constant.ALL_PRODUCTS_TITLE);
            if (products.Count == 0)
            {
                Console.WriteLine(Constant.NO_PRODUCTS_FOUND);
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
            Console.Write(Constant.ENTER_PRODUCT_ID);
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine(Constant.INVALID_PRODUCT_ID);
                return;
            }

            var product = _unitOfWork.Products.GetById(id);
            if (product == null)
            {
                Console.WriteLine(Constant.PRODUCT_NOT_FOUND);
                return;
            }
            Console.WriteLine($"ID: {product.ProductId}");
            Console.WriteLine($"Name: {product.Name}");
            Console.WriteLine($"Price: {product.Price:C}");
            Console.WriteLine($"Stock: {product.stock}");
        }

        public void GetProductsByCategory()
        {
            Console.Write(Constant.ENTER_CATEGORY_ID);
            if (!int.TryParse(Console.ReadLine(), out int categoryId))
            {
                Console.WriteLine(Constant.INVALID_CATEGORY_ID);
                return;
            }
            if (categoryId <= 0)
            {
                Console.WriteLine(Constant.CATEGORY_ID_GREATER_THAN_ZERO);
                return;
            }
            var products = _unitOfWork.Products.GetByCategory(categoryId);
            if (products.Count == 0)
            {
                Console.WriteLine(Constant.PRODUCT_NOT_FOUND);
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
            Console.Write(Constant.ENTER_MINIMUM_PRICE);

            if (!decimal.TryParse(
                Console.ReadLine(),
                out decimal minPrice))
            {
                Console.WriteLine(Constant.INVALID_MINIMUM_PRICE);
                return;
            }

            Console.Write(Constant.ENTER_MAXIMUM_PRICE);

            if (!decimal.TryParse(
                Console.ReadLine(),
                out decimal maxPrice))
            {
                Console.WriteLine(Constant.INVALID_MAXIMUM_PRICE);
                return;
            }

            if (minPrice < 0 || maxPrice < 0)
            {
                Console.WriteLine(Constant.PRICE_CANNOT_BE_NEGATIVE);
                return;
            }

            if (minPrice > maxPrice)
            {
                Console.WriteLine(Constant.MINIMUM_PRICE_GREATER_THAN_MAXIMUM);
                return;
            }

            var products = _unitOfWork.Products.GetProductsByPrice(minPrice, maxPrice);

            if (products.Count == 0)
            {
                Console.WriteLine(Constant.NO_PRODUCTS_IN_PRICE_RANGE);
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
            Console.WriteLine(Constant.MOST_POPULAR_PRODUCTS_TITLE);
            if (products.Count == 0)
            {
                Console.WriteLine(Constant.NO_POPULAR_PRODUCTS_FOUND);
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
            Console.Write(Constant.ENTER_PRODUCT_NAME);
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine(Constant.PRODUCT_NAME_CANNOT_BE_EMPTY);
                return;
            }
            product.Name = name;
            Console.Write(Constant.ENTER_PRICE);
            if (!decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                Console.WriteLine(Constant.INVALID_PRICE);
                return;
            }

            if (price < 0)
            {
                Console.WriteLine(Constant.PRICE_CANNOT_BE_NEGATIVE);
                return;
            }
            product.Price = price;
            Console.Write(Constant.ENTER_CATEGORY_ID);
            if (!int.TryParse(Console.ReadLine(), out int categoryId))
            {
                Console.WriteLine(Constant.INVALID_CATEGORY_ID);
                return;
            }
            if (categoryId <= 0)
            {
                Console.WriteLine(Constant.CATEGORY_ID_GREATER_THAN_ZERO);
                return;
            }
            product.ProductCategoryId = categoryId;
            Console.Write(Constant.ENTER_STOCK);
            if (!int.TryParse(Console.ReadLine(), out int stock))
            {
                Console.WriteLine(Constant.INVALID_STOCK);
                return;
            }
            if (stock < 0)
            {
                Console.WriteLine(Constant.STOCK_CANNOT_BE_NEGATIVE);
                return;
            }
            product.stock = stock;
            _unitOfWork.Products.Add(product);
            _unitOfWork.Save();
            Console.WriteLine(Constant.PRODUCT_ADDED_SUCCESSFULLY);
        }

        public void UpdateProduct()
        {
            Console.Write(Constant.ENTER_PRODUCT_ID);
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine(Constant.INVALID_PRODUCT_ID);
                return;
            }
            var product = _unitOfWork.Products.GetById(id);
            if (product == null)
            {
                Console.WriteLine(Constant.PRODUCT_NOT_FOUND);
                return;
            }

            Console.Write(Constant.ENTER_NEW_PRODUCT_NAME);
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine(Constant.PRODUCT_NAME_CANNOT_BE_EMPTY);
                return;
            }
            Console.Write(Constant.ENTER_NEW_PRICE);
            if (!decimal.TryParse(
                Console.ReadLine(),
                out decimal price))
            {
                Console.WriteLine(Constant.INVALID_PRICE);
                return;
            }
            if (price < 0)
            {
                Console.WriteLine(Constant.PRICE_CANNOT_BE_NEGATIVE);
                return;
            }
            Console.Write(Constant.ENTER_NEW_CATEGORY_ID);

            if (!int.TryParse(
                Console.ReadLine(),
                out int categoryId))
            {
                Console.WriteLine(Constant.INVALID_CATEGORY_ID);
                return;
            }
            if (categoryId <= 0)
            {
                Console.WriteLine(Constant.CATEGORY_ID_GREATER_THAN_ZERO);
                return;
            }

            Console.Write(Constant.ENTER_NEW_STOCK);
            if (!int.TryParse(
                Console.ReadLine(),
                out int stock))
            {
                Console.WriteLine(Constant.INVALID_STOCK);
                return;
            }

            if (stock < 0)
            {
                Console.WriteLine(Constant.STOCK_CANNOT_BE_NEGATIVE);
                return;
            }

            product.Name = name;
            product.Price = price;
            product.ProductCategoryId = categoryId;
            product.stock = stock;

            _unitOfWork.Products.Update(product);
            _unitOfWork.Save();
            Console.WriteLine(Constant.PRODUCT_UPDATED_SUCCESSFULLY);
        }

        public void DeleteProduct()
        {
            Console.Write(Constant.ENTER_PRODUCT_ID);
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine(Constant.INVALID_PRODUCT_ID);
                return;
            }
            var product = _unitOfWork.Products.GetById(id);
            if (product == null)
            {
                Console.WriteLine(Constant.PRODUCT_NOT_FOUND);
                return;
            }
            _unitOfWork.Products.Delete(id);
            _unitOfWork.Save();
            Console.WriteLine(Constant.PRODUCT_DELETED_SUCCESSFULLY);
        }
    }
}
