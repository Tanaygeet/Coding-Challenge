/* By Tanaygeet Shrivastava */


/* Database Design */

-- 1
CREATE DATABASE OrderManagementSystem;
USE OrderManagementSystem;

---------------------------------------------------------------------------------------------------------------------------------------------------------
-- Creating Tables:

-- 2(i) - user table
CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL,
    Password NVARCHAR(50) NOT NULL,
    Role NVARCHAR(10) CHECK (Role IN ('Admin', 'User')) NOT NULL);


-- 2(ii) - product table
CREATE TABLE Products (
    ProductId INT IDENTITY(1,1) PRIMARY KEY,
    ProductName NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255),
    Price DECIMAL(10, 2) NOT NULL,
    QuantityInStock INT NOT NULL,
    Type NVARCHAR(20) CHECK (Type IN ('Electronics', 'Clothing')) NOT NULL);


-- 2(iii) - electronics table (inherits from product)
CREATE TABLE Electronics (
    ProductId INT PRIMARY KEY,
    Brand NVARCHAR(50) NOT NULL,
    WarrantyPeriod INT,
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId) ON DELETE CASCADE);


-- 2(iv) - clothing table (inherits from product)
CREATE TABLE Clothing (
    ProductId INT PRIMARY KEY,
    Size NVARCHAR(10) NOT NULL,
    Color NVARCHAR(20) NOT NULL,
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId) ON DELETE CASCADE);


-- 2(v) - order table
CREATE TABLE Orders (
    OrderId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT,
    OrderDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UserId) REFERENCES Users(UserId) ON DELETE CASCADE);


-- 2(vi) - OrderDetails table
CREATE TABLE OrderDetails (
    OrderDetailId INT IDENTITY(1,1) PRIMARY KEY,
    OrderId INT,
    ProductId INT,
    Quantity INT NOT NULL,
    FOREIGN KEY (OrderId) REFERENCES Orders(OrderId) ON DELETE CASCADE,
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId) ON DELETE CASCADE);



---------------------------------------------------------------------------------------------------------------------------------------------------------
-- Inserting Sample Data Into Tables:

-- 3(i)
INSERT INTO Users (Username, Password, Role) VALUES
('admin', 'password123', 'Admin'),
('john_doe', 'johnpass', 'User'),
('jane_doe', 'janepass', 'User'),
('mark_smith', 'markpass', 'User'),
('alice_jones', 'alicepass', 'User'),
('sam_wilson', 'sampass', 'User'),
('emma_watson', 'emmapass', 'User'),
('will_turner', 'willpass', 'User'),
('oliver_queen', 'oliverpass', 'User'),
('tony_stark', 'tonypass', 'User');


-- 3(ii)
INSERT INTO Products (ProductName, Description, Price, QuantityInStock, Type) VALUES
('Laptop', 'High performance laptop', 1200.00, 50, 'Electronics'),
('Smartphone', 'Latest smartphone model', 800.00, 100, 'Electronics'),
('Tablet', 'Portable tablet device', 400.00, 70, 'Electronics'),
('TV', '4K Ultra HD Television', 1500.00, 30, 'Electronics'),
('Headphones', 'Wireless noise-cancelling headphones', 200.00, 80, 'Electronics'),
('T-Shirt', '100% cotton t-shirt', 20.00, 200, 'Clothing'),
('Jeans', 'Denim jeans', 40.00, 150, 'Clothing'),
('Jacket', 'Leather jacket', 120.00, 50, 'Clothing'),
('Shoes', 'Running shoes', 60.00, 100, 'Clothing'),
('Dress', 'Evening dress', 80.00, 30, 'Clothing');


-- 3(iii)
INSERT INTO Electronics (ProductId, Brand, WarrantyPeriod) VALUES
(1, 'Dell', 24),
(2, 'Apple', 12),
(3, 'Samsung', 18),
(4, 'LG', 24),
(5, 'Sony', 12);


-- 3(iv)
INSERT INTO Clothing (ProductId, Size, Color) VALUES
(6, 'M', 'Blue'),
(7, 'L', 'Black'),
(8, 'M', 'Brown'),
(9, '9', 'White'),
(10, 'S', 'Red');


-- 3(v)
INSERT INTO Orders (UserId, OrderDate) VALUES
(2, '2024-10-01'),
(3, '2024-10-02'),
(4, '2024-10-03'),
(5, '2024-10-04'),
(6, '2024-10-05'),
(7, '2024-10-06'),
(8, '2024-10-07'),
(9, '2024-10-08'),
(10, '2024-10-09'),
(2, '2024-10-10');


-- 3(vi)
INSERT INTO OrderDetails (OrderId, ProductId, Quantity) VALUES
(1, 1, 1),
(1, 6, 2),
(2, 2, 1),
(2, 7, 3),
(3, 3, 2),
(3, 8, 1),
(4, 4, 1),
(4, 9, 2),
(5, 5, 2),
(5, 10, 1);



-----------------------------------------------------------------------------------------------------------------------------------------------------------------








