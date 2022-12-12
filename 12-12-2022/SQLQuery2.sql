CREATE TABLE customers (
	CustomerID INT IDENTITY(1,1),
	FirstName VARCHAR(255) NOT NULL,
	MiddleInitial VARCHAR(255),
	LastName VARCHAR(255) NOT NULL
);

CREATE TABLE orders (
	OrderID INT IDENTITY(1,1),
	ProductID INT NOT NULL,
	CustomerID INT NOT NULL,
	soldQuantity int NOT NULL,
);

CREATE TABLE products (
	ProductID INT IDENTITY(1,1),
	Name VARCHAR(255) NOT NULL,
	price INT NOT NULL,
	Discription VARCHAR(255) NOT NULL
);

CREATE TABLE Employee (
	EmployeeID INT IDENTITY(1,1),
	FirstName VARCHAR(255) NOT NULL,
	MiddleInitial VARCHAR(255),
	LastName VARCHAR(255) NOT NULL,
	salary INT,
	JobID INT 
);