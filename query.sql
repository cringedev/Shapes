SELECT Products.Name, Categories.Name
FROM Products
LEFT JOIN ProductCategories ON Products.ID = ProductCategories.ProductID
LEFT JOIN Categories ON ProductCategories.CategoryID = Categories.ID


-- --queries for preparing test data

-- CREATE TABLE Categories (
--     Id INT PRIMARY KEY,
--     CategoryName NVARCHAR(50)
-- );

-- CREATE TABLE Products (
--     Id INT PRIMARY KEY,
--     Name NVARCHAR(50)
-- );

-- CREATE TABLE ProductCategories (
--     ProductId INT,
--     CategoryId INT,
--     FOREIGN KEY (ProductId) REFERENCES Products(Id),
--     FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
-- );

-- INSERT INTO Categories (Id, Name)
-- VALUES (1, 'Books'), (2, 'Electronics'), (3, 'Home Appliances');

-- INSERT INTO Products (Id, Name)
-- VALUES (1, 'Harry Potter'), (2, 'iPhone 14'), (3, 'MacBook Pro'), (4, 'Table'), (5, 'Xiaomi Mi Robot Vacuum'), (6, 'Snow');

-- INSERT INTO ProductCategories (ProductId, CategoryId)
-- VALUES (1, 1), (2, 2), (3, 2), (3, 3), (4, 3), (5, 2), (5, 3) ;
