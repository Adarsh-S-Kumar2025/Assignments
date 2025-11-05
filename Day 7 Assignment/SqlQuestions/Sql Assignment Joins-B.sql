-- E-commerce Platform Schema

CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    CustomerName VARCHAR(100),
    Email VARCHAR(100),
    RegistrationDate DATE
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(200),
    Price DECIMAL(10, 2),
    CategoryID INT
);

CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY,
    CategoryName VARCHAR(100)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    OrderDate DATE,
    TotalAmount DECIMAL(10, 2),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);

CREATE TABLE OrderDetails (
    OrderDetailID INT PRIMARY KEY,
    OrderID INT,
    ProductID INT,
    Quantity INT,
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);
-- ======================
-- DATA INSERTION
-- ======================


INSERT INTO Customers (CustomerID, CustomerName, Email, RegistrationDate) VALUES
(1, 'John Doe', 'john@example.com', '2023-01-15'),
(2, 'Alice Smith', 'alice@example.com', '2023-02-10'),
(3, 'Bob Johnson', 'bob@example.com', '2023-03-05'),
(4, 'Emma Wilson', 'emma@example.com', '2023-05-20'),
(5, 'David Brown', 'david@example.com', '2023-07-11');

INSERT INTO Categories (CategoryID, CategoryName) VALUES
(1, 'Electronics'),
(2, 'Fashion'),
(3, 'Home Appliances'),
(4, 'Sports'),
(5, 'Books');

INSERT INTO Products (ProductID, ProductName, Price, CategoryID) VALUES
(101, 'Smartphone', 699.99, 1),
(102, 'Laptop', 1199.99, 1),
(103, 'Headphones', 199.99, 1),
(104, 'T-Shirt', 29.99, 2),
(105, 'Washing Machine', 499.50, 3),
(106, 'Microwave Oven', 159.75, 3),
(107, 'Football', 39.90, 4),
(108, 'Novel - Mystery', 14.99, 5),
(109, 'Tablet', 299.50, 1),
(110, 'Sneakers', 79.99, 2),
(201, 'Wireless Mouse', 49.99, 1),
(202, 'Winter Jacket', 89.99, 2),
(203, 'Bluetooth Speaker', 129.99, 1);

INSERT INTO Orders (OrderID, CustomerID, OrderDate, TotalAmount) VALUES
(1001, 1, '2023-09-01', 899.98),
(1002, 2, '2023-09-05', 39.90),
(1003, 1, '2023-10-25', 1199.99),
(1004, 3, '2022-12-20', 159.75),
(1005, 5, '2023-10-20', 29.99),
(3001, 1, '2025-10-26', 699.99),
(3002, 2, '2025-10-24', 29.99),
(3003, 4, '2025-10-21', 1199.99);

INSERT INTO OrderDetails (OrderDetailID, OrderID, ProductID, Quantity) VALUES
(1, 1001, 101, 1),
(2, 1001, 103, 1),
(3, 1002, 107, 1),
(4, 1003, 102, 1),
(5, 1004, 106, 1),
(6, 1005, 104, 1),
(31, 3001, 201, 1),
(32, 3002, 202, 1),
(33, 3003, 203, 1);
-- Questions

-- 1. List all products with their category names, including products without a category.

SELECT P.ProductID, P.ProductName, C.CategoryName
FROM Products P
LEFT JOIN Categories C ON P.CategoryID = C.CategoryID;

-- 2. Display all customers and their order history, including customers who haven't placed any orders.

SELECT C.CustomerID, C.CustomerName, O.OrderID, O.OrderDate, O.TotalAmount
FROM Customers C
LEFT JOIN Orders O ON C.CustomerID = O.CustomerID;

-- 3. Show all categories and the products in each category, including categories without any products.

SELECT C.CategoryID, C.CategoryName, P.ProductID, P.ProductName
FROM Categories C
LEFT JOIN Products P ON C.CategoryID = P.CategoryID;
-- 4. List all possible customer-product combinations, regardless of whether a purchase has occurred.

SELECT C.CustomerID, C.CustomerName, P.ProductID, P.ProductName
FROM Customers C
CROSS JOIN Products P;

-- 5. Display all orders with customer and product information, including orders where either the customer or product information is missing.

SELECT O.OrderID, O.OrderDate, C.CustomerName, P.ProductName, OD.Quantity
FROM Orders O
LEFT JOIN Customers C ON O.CustomerID = C.CustomerID
LEFT JOIN OrderDetails OD ON O.OrderID = OD.OrderID
LEFT JOIN Products P ON OD.ProductID = P.ProductID;

-- 6. Show all products that have never been ordered, along with their category information.

SELECT P.ProductID, P.ProductName, C.CategoryName
FROM Products P
LEFT JOIN OrderDetails OD ON P.ProductID = OD.ProductID
LEFT JOIN Categories C ON P.CategoryID = C.CategoryID
WHERE OD.ProductID IS NULL;

-- 7. List all customers who have placed orders in the last week, along with the products they've purchased.

SELECT C.CustomerID, C.CustomerName, O.OrderDate, P.ProductName, OD.Quantity
FROM Customers C
INNER JOIN Orders O ON C.CustomerID = O.CustomerID
INNER JOIN OrderDetails OD ON O.OrderID = OD.OrderID
INNER JOIN Products P ON OD.ProductID = P.ProductID
WHERE O.OrderDate >= DATEADD(DAY, -7, GETDATE());


-- 8. Display all categories with products priced over $100, including categories without such products.

SELECT C.CategoryID, C.CategoryName, P.ProductName, P.Price
FROM Categories C
LEFT JOIN Products P ON C.CategoryID = P.CategoryID AND P.Price > 100;

-- 9. Show all orders placed before 2023 and any associated product information.

SELECT O.OrderID, O.OrderDate, P.ProductName, OD.Quantity
FROM Orders O
LEFT JOIN OrderDetails OD ON O.OrderID = OD.OrderID
LEFT JOIN Products P ON OD.ProductID = P.ProductID
WHERE O.OrderDate < '2023-01-01';

-- 10. List all possible category-customer combinations, regardless of whether the customer has purchased a product from that category.

SELECT C.CategoryID, C.CategoryName, CU.CustomerID, CU.CustomerName
FROM Categories C
CROSS JOIN Customers CU;