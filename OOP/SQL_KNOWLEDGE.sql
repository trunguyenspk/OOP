
--CREATE TABLE Customers (
--    CustomerID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
--    CustomerName varchar(255),
--    CustomerAddress varchar(255)
--);

--CREATE TABLE Orders (
--    OrderID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
--    EmployeeID int,
--    CustomerID int FOREIGN KEY REFERENCES Customers(CustomerID)
--);

--CREATE TABLE Providers (
--    ProviderID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
--    ProviderAddress varchar(255)
--);

--********************************************************************

--INNER JOIN********** Records that have matching values in both tables

		--SELECT Orders.OrderID, Customers.CustomerID, Customers.CustomerAddress
		--FROM Orders
		--INNER JOIN Customers ON Orders.CustomerID = Customers.CustomerID;

		--SAME RESULT WITH:

		--SELECT Orders.OrderID, Customers.CustomerID, Customers.CustomerAddress
		--FROM Orders, Customers
		--where Orders.CustomerID = Customers.CustomerID;

--INNER JOIN**********

--LEFT JOIN / OUTER JOIN********** 
--returns all records from the left table (table1), and the matched records from the right table (table2)

		--SELECT Customers.CustomerName, Orders.OrderID
		--FROM Customers
		--LEFT JOIN Orders ON Customers.CustomerID = Orders.CustomerID

		----SAME RESULT WITH:

		--SELECT Customers.CustomerName, Orders.OrderID
		--FROM Orders
		--RIGHT JOIN Customers ON Customers.CustomerID = Orders.CustomerID

--LEFT JOIN / OUTER JOIN**********

--RIGHT JOIN / RIGHT OUTER JOIN********** 
--returns all records from the right table (table2), and the matched records from the left table (table1)

		--SELECT Customers.CustomerName, Orders.OrderID
		--FROM Customers
		--RIGHT JOIN Orders ON Customers.CustomerID = Orders.CustomerID

		----SAME RESULT WITH:

		--SELECT Customers.CustomerName, Orders.OrderID
		--FROM Orders
		--LEFT JOIN Customers ON Customers.CustomerID = Orders.CustomerID

--RIGHT JOIN / RIGHT OUTER JOIN**********

--FULL JOIN********** 
--returns all records from the left table (table1), and the matched records from the right table (table2)

		--SELECT Orders.OrderID, Orders.EmployeeID, Customers.CustomerName 
		--FROM Orders
		--FULL JOIN Customers ON Customers.CustomerID = Orders.CustomerID

		--SAME RESULT WITH:

		--SELECT Orders.OrderID, Orders.EmployeeID, Customers.CustomerName 
		--FROM Customers
		--FULL JOIN Orders ON Customers.CustomerID = Orders.CustomerID

--FULL JOIN**********

--SELF JOIN**********
		SELECT A.CustomerName AS CustomerName1, B.CustomerName AS CustomerName2, A.CustomerAddress
		FROM Customers AS A, Customers AS B
		WHERE A.CustomerID <> B.CustomerID
		AND A.CustomerAddress = B.CustomerAddress
--SELF JOIN**********

		SELECT CustomerAddress FROM Customers
		UNION
		SELECT ProviderAddress FROM Providers


SELECT Customers.CustomerName, Customers.CustomerAddress,
CASE
    WHEN CustomerAddress = 'HCM' THEN 'The quantity is greater than 30'
    WHEN CustomerAddress = 'HA NOI' THEN 'The quantity is 30'
    ELSE 'The quantity is under 30'
END AS QuantityText
FROM Customers;