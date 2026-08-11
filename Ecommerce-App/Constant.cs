using System;

namespace Ecommerce_App
{
    internal class Constant
    {
        public const string MENU_TITLE = "===== E-COMMERCE DATA ACCESS SYSTEM =====";

        public const string GET_ALL_CUSTOMERS = "1. Get All Customers";
        public const string GET_CUSTOMER_BY_ID = "2. Get Customer By ID";
        public const string GET_CUSTOMERS_BY_CITY = "3. Get Customers By City";
        public const string ADD_CUSTOMER = "4. Add Customer";
        public const string UPDATE_CUSTOMER = "5. Update Customer";
        public const string DELETE_CUSTOMER = "6. Delete Customer";

        public const string GET_ALL_PRODUCTS = "7. Get All Products";
        public const string GET_PRODUCT_BY_ID = "8. Get Product By ID";
        public const string GET_PRODUCTS_BY_CATEGORY = "9. Get Products By Category";
        public const string GET_PRODUCTS_BY_PRICE = "10. Get Products By Price";
        public const string GET_MOST_POPULAR_PRODUCTS = "11. Most Popular Products";
        public const string ADD_PRODUCT = "12. Add Product";
        public const string UPDATE_PRODUCT = "13. Update Product";
        public const string DELETE_PRODUCT = "14. Delete Product";

        public const string GET_ALL_ORDERS = "15. Get All Orders";
        public const string GET_ORDER_BY_ID = "16. Get Order By ID";
        public const string GET_ORDERS_BY_CUSTOMER = "17. Orders By Customer";
        public const string GET_ORDERS_BY_DATE = "18. Orders By Date";
        public const string GET_ORDER_COUNT = "19. Order Count";
        public const string GET_TOTAL_SALES = "20. Total Sales";
        public const string ADD_ORDER = "21. Add Order";
        public const string UPDATE_ORDER = "22. Update Order";
        public const string DELETE_ORDER = "23. Delete Order";

        public const string EXIT = "0. Exit";

        // PRODUCT MESSAGES
        // PRODUCT MESSAGES

        public const string ALL_PRODUCTS_TITLE = "===== ALL PRODUCTS =====";
        public const string NO_PRODUCTS_FOUND = "No products found.";
        public const string ENTER_PRODUCT_ID = "Enter Product ID: ";
        public const string INVALID_PRODUCT_ID = "Invalid Product ID. Please enter a valid number.";
        public const string PRODUCT_NOT_FOUND = "Product not found.";
        public const string ENTER_CATEGORY_ID = "Enter Category ID: ";
        public const string INVALID_CATEGORY_ID = "Invalid Category ID. Please enter a valid number.";
        public const string CATEGORY_ID_GREATER_THAN_ZERO = "Category ID must be greater than 0.";
        public const string ENTER_MINIMUM_PRICE = "Enter Minimum Price: ";
        public const string INVALID_MINIMUM_PRICE = "Invalid minimum price. Please enter a valid number.";
        public const string ENTER_MAXIMUM_PRICE = "Enter Maximum Price: ";
        public const string INVALID_MAXIMUM_PRICE = "Invalid maximum price. Please enter a valid number.";
        public const string PRICE_CANNOT_BE_NEGATIVE = "Price cannot be negative.";
        public const string MINIMUM_PRICE_GREATER_THAN_MAXIMUM = "Minimum price cannot be greater than maximum price.";
        public const string NO_PRODUCTS_IN_PRICE_RANGE = "No products found in this price range.";
        public const string MOST_POPULAR_PRODUCTS_TITLE = "===== MOST POPULAR PRODUCTS =====";
        public const string NO_POPULAR_PRODUCTS_FOUND = "No popular products found.";
        public const string ENTER_PRODUCT_NAME = "Enter Product Name: ";
        public const string PRODUCT_NAME_CANNOT_BE_EMPTY = "Product name cannot be empty.";
        public const string INVALID_PRICE = "Invalid price. Please enter a valid number.";
        public const string ENTER_STOCK = "Enter Stock: ";
        public const string INVALID_STOCK = "Invalid stock. Please enter a valid number.";
        public const string STOCK_CANNOT_BE_NEGATIVE = "Stock cannot be negative.";
        public const string PRODUCT_ADDED_SUCCESSFULLY = "Product added successfully.";
        public const string ENTER_NEW_PRODUCT_NAME = "Enter new Product Name: ";
        public const string ENTER_NEW_PRICE = "Enter new Price: ";
        public const string ENTER_PRICE = "Enter Price: ";
        public const string ENTER_NEW_CATEGORY_ID = "Enter new Category ID: ";
        public const string ENTER_NEW_STOCK = "Enter new Stock: ";
        public const string PRODUCT_UPDATED_SUCCESSFULLY = "Product updated successfully.";
        public const string PRODUCT_DELETED_SUCCESSFULLY = "Product deleted successfully.";


        // ORDER MESSAGES

        public const string ALL_ORDERS_TITLE = "===== ALL ORDERS =====";
        public const string NO_ORDERS_FOUND = "No orders found.";
        public const string ENTER_ORDER_ID = "Enter Order ID: ";
        public const string INVALID_ORDER_ID = "Invalid Order ID. Please enter a valid number.";
        public const string ORDER_NOT_FOUND = "Order not found.";
        public const string ENTER_CUSTOMER_ID = "Enter Customer ID: ";
        public const string INVALID_CUSTOMER_ID = "Invalid Customer ID. Please enter a valid number.";
        public const string NO_ORDERS_FOR_CUSTOMER = "No orders found for this customer.";
        public const string ENTER_START_DATE = "Enter Start Date (yyyy-MM-dd): ";
        public const string ENTER_END_DATE = "Enter End Date (yyyy-MM-dd): ";
        public const string INVALID_START_DATE = "Invalid start date. Please use yyyy-MM-dd format.";
        public const string INVALID_END_DATE = "Invalid end date. Please use yyyy-MM-dd format.";
        public const string START_DATE_GREATER_THAN_END_DATE = "Start date cannot be greater than end date.";
        public const string NO_ORDERS_IN_DATE_RANGE = "No orders found in this date range.";
        public const string CUSTOMER_ORDER_COUNT = "Customer {0} has {1} order(s).";
        public const string TOTAL_SALES = "Total Sales: {0:C}";
        public const string ENTER_TOTAL_AMOUNT = "Enter Total Amount: ";
        public const string INVALID_AMOUNT = "Invalid amount. Please enter a valid number.";
        public const string TOTAL_AMOUNT_CANNOT_BE_NEGATIVE = "Total amount cannot be negative.";
        public const string ENTER_ORDER_DATE = "Enter Order Date (yyyy-MM-dd): ";
        public const string INVALID_ORDER_DATE = "Invalid order date. Please use yyyy-MM-dd format.";
        public const string ORDER_ADDED_SUCCESSFULLY = "Order added successfully.";
        public const string ENTER_NEW_ORDER_DATE = "Enter new Order Date (yyyy-MM-dd): ";
        public const string ENTER_NEW_TOTAL_AMOUNT = "Enter new Total Amount: ";
        public const string ORDER_UPDATED_SUCCESSFULLY = "Order updated successfully.";
        public const string ORDER_DELETED_SUCCESSFULLY = "Order deleted successfully.";


        // CUSTOMER MESSAGES

        public const string ALL_CUSTOMERS_TITLE = "===== ALL CUSTOMERS =====";
        public const string NO_CUSTOMERS_FOUND = "No customers found.";
        public const string CUSTOMER_NOT_FOUND = "Customer not found.";
        public const string ENTER_CITY = "Enter City: ";
        public const string CITY_CANNOT_BE_EMPTY = "City cannot be empty.";
        public const string ENTER_NAME = "Enter Name: ";
        public const string NAME_CANNOT_BE_EMPTY = "Name cannot be empty.";
        public const string ENTER_EMAIL = "Enter Email: ";
        public const string INVALID_EMAIL = "Invalid email format.";
        public const string CUSTOMER_ADDED_SUCCESSFULLY = "Customer added successfully.";
        public const string ENTER_NEW_NAME = "Enter new Name: ";
        public const string ENTER_NEW_EMAIL = "Enter new Email: ";
        public const string ENTER_NEW_CITY = "Enter new City: ";
        public const string CUSTOMER_UPDATED_SUCCESSFULLY = "Customer updated successfully.";
        public const string CUSTOMER_DELETED_SUCCESSFULLY = "Customer deleted successfully.";
    }
} 