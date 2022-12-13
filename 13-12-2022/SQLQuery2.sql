CREATE TABLE customers (
	CustomerID INT IDENTITY(1,1),
	FirstName VARCHAR(255) NOT NULL,
	LastName VARCHAR(255) NOT NULL,
	PRIMARY KEY(CustomerID)
);

CREATE TABLE orders (
	OrderID INT IDENTITY(1,1),
	CustomerID INT NOT NULL,
	soldQuantity int NOT NULL,
	PRIMARY KEY(OrderID),
	FOREIGN KEY (CustomerID) REFERENCES customers
);

CREATE TABLE products (
	ProductID INT IDENTITY(1,1),
	OrderID INT,
	Name VARCHAR(255) NOT NULL,
	price INT NOT NULL,
	PRIMARY KEY (ProductID),
	FOREIGN KEY (OrderID) REFERENCES orders
);

INSERT INTO customers (FirstName, LastName)
VALUES ('Hassan','Ayasrah'), ('Ashraf','Shwaiat');

INSERT INTO orders (CustomerID, soldQuantity)
VALUES (1,3), (1,4), (1,2), (2,7);

INSERT INTO products (OrderID, Name, price)
VALUES (1,'rice',12), (1,'Jam',24), (2,'sugar',12), (3,'sugr',12),(3,'jam',12), (4,'sugar',12), (4,'banana',6), (4,'apple',6);

INSERT INTO customers (FirstName, LastName)
VALUES ('Malek','Obidat');

select * from customers
JOIN orders ON customers.CustomerID = orders.CustomerID
JOIN products ON products.OrderID = orders.OrderID;


select * from customers
LEFT JOIN orders ON customers.CustomerID = orders.CustomerID
LEFT JOIN products ON products.OrderID = orders.OrderID;