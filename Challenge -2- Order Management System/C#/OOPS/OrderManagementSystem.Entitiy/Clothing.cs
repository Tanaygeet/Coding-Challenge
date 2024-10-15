﻿namespace OrderManagementSystem.entity
{
    public class Clothing : Product
    {
        public string Size { get; set; }
        public string Color { get; set; }

        public Clothing(int productId, string productName, string description, double price, int quantityInStock, string type, string size, string color)
            : base(productId, productName, description, price, quantityInStock, type)
        {
            Size = size;
            Color = color;
        }
    }
}
