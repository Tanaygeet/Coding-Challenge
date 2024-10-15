/* Tanaygeet Shrivastava */


using System;
using System.Collections.Generic;
using OrderManagementSystem.dao;
using OrderManagementSystem.entity;

namespace OrderManagementSystem.UI
{
    class MainModule
    {
        static void Main(string[] args)
        {
            IOrderManagementRepository orderProcessor = new OrderProcessor();

            while (true)
            {
                Console.WriteLine("\nOrder Management System:");
                Console.WriteLine("1. Create User");
                Console.WriteLine("2. Create Product");
                Console.WriteLine("3. Get All Products");
                Console.WriteLine("4. Create Order");
                Console.WriteLine("5. Cancel Order");
                Console.WriteLine("6. Get Orders by User");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter User ID: ");
                        int userId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Username: ");
                        string username = Console.ReadLine();
                        Console.Write("Enter Password: ");
                        string password = Console.ReadLine();
                        Console.Write("Enter Role (Admin/User): ");
                        string role = Console.ReadLine();

                        User newUser = new User(userId, username, password, role);
                        orderProcessor.CreateUser(newUser);
                        Console.WriteLine("User created successfully.");
                        break;

                    case 2:
                        Console.Write("Enter Product ID: ");
                        int productId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Product Name: ");
                        string productName = Console.ReadLine();
                        Console.Write("Enter Description: ");
                        string description = Console.ReadLine();
                        Console.Write("Enter Price: ");
                        double price = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Enter Quantity In Stock: ");
                        int quantity = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Type (Electronics/Clothing): ");
                        string type = Console.ReadLine();

                        Product newProduct = new Product(productId, productName, description, price, quantity, type);
                        Console.Write("Enter User ID for admin creating this product: ");
                        int adminUserId = Convert.ToInt32(Console.ReadLine());
                        User adminUser = new User(adminUserId, username, password, "Admin");

                        orderProcessor.CreateProduct(adminUser, newProduct);
                        Console.WriteLine("Product created successfully.");
                        break;

                    case 3:
                        List<Product> products = orderProcessor.GetAllProducts();
                        foreach (var product in products)
                        {
                            Console.WriteLine($"ID: {product.ProductId}, Name: {product.ProductName}, Price: {product.Price}");
                        }
                        break;

                    case 4:
                        Console.Write("Enter User ID: ");
                        int userId = Convert.ToInt32(Console.ReadLine());

                        // Fetch the user and validate (not implemented here for brevity)
                        User user = new User(userId, "username", "password", "User");

                        Console.WriteLine("Enter number of products to order: ");
                        int numProducts = Convert.ToInt32(Console.ReadLine());
                        List<Product> productList = new List<Product>();

                        for (int i = 0; i < numProducts; i++)
                        {
                            Console.Write($"Enter Product ID for product {i + 1}: ");
                            int productId = Convert.ToInt32(Console.ReadLine());
                            // Fetch product and add to productList
                        }

                        orderProcessor.CreateOrder(user, productList);
                        break;

                    case 5:
                        Console.Write("Enter User ID: ");
                        userId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Order ID: ");
                        int orderId = Convert.ToInt32(Console.ReadLine());

                        orderProcessor.CancelOrder(userId, orderId);
                        break;

                    case 6:
                        Console.Write("Enter User ID: ");
                        userId = Convert.ToInt32(Console.ReadLine());

                        // Fetch the user and validate
                        user = new User(userId, "username", "password", "User");
                        List<Product> orders = orderProcessor.GetOrderByUser(user);

                        foreach (var product in orders)
                        {
                            Console.WriteLine($"Product ID: {product.ProductId}, Name: {product.ProductName}, Price: {product.Price}");
                        }
                        break;

                    case 7:
                        Console.WriteLine("Exiting application...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }
    }
}

