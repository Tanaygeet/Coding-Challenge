/* Tanaygeet Shrivastava */

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using OrderManagementSystem.entity;
using OrderManagementSystem.exception;
using OrderManagementSystem.util;

namespace OrderManagementSystem.dao
{
    public class OrderProcessor : IOrderManagementRepository
    {
        private SqlConnection connection;

        public OrderProcessor()
        {
            connection = DBConnUtil.GetDBConn(DBPropertyUtil.GetConnectionString("dbConfig.properties"));
        }

        public void CreateOrder(User user, List<Product> products)
        {
            if (user == null)
            {
                throw new UserNotFoundException("User not found.");
            }

            try
            {
                connection.Open();
                
                // Insert a new order
                string orderQuery = "INSERT INTO Orders (UserId, OrderDate) OUTPUT INSERTED.OrderId VALUES (@UserId, @OrderDate)";
                int orderId;
                using (SqlCommand cmd = new SqlCommand(orderQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@UserId", user.UserId);
                    cmd.Parameters.AddWithValue("@OrderDate", DateTime.Now);

                    orderId = (int)cmd.ExecuteScalar(); 
                }

                // Insert products into OrderDetails table
                foreach (var product in products)
                {
                    string detailsQuery = "INSERT INTO OrderDetails (OrderId, ProductId, Quantity) VALUES (@OrderId, @ProductId, @Quantity)";
                    using (SqlCommand cmd = new SqlCommand(detailsQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@OrderId", orderId);
                        cmd.Parameters.AddWithValue("@ProductId", product.ProductId);
                        cmd.Parameters.AddWithValue("@Quantity", product.QuantityInStock); 
                        cmd.ExecuteNonQuery();
                    }
                }

                Console.WriteLine("Order created successfully with Order ID: " + orderId);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error creating order: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void CancelOrder(int userId, int orderId)
        {
            try
            {
                connection.Open();

                // Check if the order exists for the user
                string checkQuery = "SELECT COUNT(*) FROM Orders WHERE OrderId = @OrderId AND UserId = @UserId";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, connection))
                {
                    checkCmd.Parameters.AddWithValue("@OrderId", orderId);
                    checkCmd.Parameters.AddWithValue("@UserId", userId);

                    int count = (int)checkCmd.ExecuteScalar();
                    if (count == 0)
                    {
                        throw new OrderNotFoundException("Order not found for the given user.");
                    }
                }

                // Delete the order
                string deleteDetailsQuery = "DELETE FROM OrderDetails WHERE OrderId = @OrderId";
                using (SqlCommand cmd = new SqlCommand(deleteDetailsQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@OrderId", orderId);
                    cmd.ExecuteNonQuery();
                }

                string deleteOrderQuery = "DELETE FROM Orders WHERE OrderId = @OrderId";
                using (SqlCommand cmd = new SqlCommand(deleteOrderQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@OrderId", orderId);
                    cmd.ExecuteNonQuery();
                }

                Console.WriteLine("Order cancelled successfully.");
            }
            catch (OrderNotFoundException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error cancelling order: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

public void CreateProduct(User user, Product product)
        {
            if (user.Role != "Admin")
            {
                throw new UnauthorizedAccessException("Only admins can create products.");
            }

            string query = "INSERT INTO Products (ProductId, ProductName, Description, Price, QuantityInStock, Type) VALUES (@ProductId, @ProductName, @Description, @Price, @QuantityInStock, @Type)";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@ProductId", product.ProductId);
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@Description", product.Description);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@QuantityInStock", product.QuantityInStock);
                cmd.Parameters.AddWithValue("@Type", product.Type);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void CreateUser(User user)
        {
            string query = "INSERT INTO Users (UserId, Username, Password, Role) VALUES (@UserId, @Username, @Password, @Role)";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@UserId", user.UserId);
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Role", user.Role);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public List<Product> GetAllProducts()
        {
            string query = "SELECT * FROM Products";
            List<Product> products = new List<Product>();

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    products.Add(new Product(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetDecimal(3),
                        reader.GetInt32(4),
                        reader.GetString(5)
                    ));
                }
                connection.Close();
            }

            return products;
        }

        public List<Product> GetOrderByUser(User user)
        {
            List<Product> products = new List<Product>();

            try
            {
                connection.Open();

                string query = @"
                    SELECT p.ProductId, p.ProductName, p.Description, p.Price, p.QuantityInStock, p.Type
                    FROM Products p
                    JOIN OrderDetails od ON p.ProductId = od.ProductId
                    JOIN Orders o ON od.OrderId = o.OrderId
                    WHERE o.UserId = @UserId";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@UserId", user.UserId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(new Product(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetDecimal(3),
                                reader.GetInt32(4),
                                reader.GetString(5)
                            ));
                        }
                    }
                }

                if (products.Count == 0)
                {
                    Console.WriteLine("No orders found for the user.");
                }
                else
                {
                    Console.WriteLine($"Found {products.Count} products ordered by the user.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving orders: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return products;
        }
    }
}

