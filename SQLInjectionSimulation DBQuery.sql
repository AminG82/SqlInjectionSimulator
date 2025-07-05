CREATE DATABASE ShopTestDB

go


USE ShopTestDB

go

CREATE TABLE Products (
	ProductId INT IDENTITY(1,1),
	ProductName NVARCHAR(50),
	ProductCategory NVARCHAR(50)
	)

CREATE TABLE Users (
	UserId INT IDENTITY(1,1),
	UserName NVARCHAR(50),
	UserLastName NVARCHAR(50),
	UserAddress NVARCHAR(100),
	UserNationalCode NVARCHAR(10)
	)

go

INSERT INTO Products(
	ProductName,ProductCategory)
	VALUES ('Samsung' , 'Mobile Phone'),
	('ASUS' , 'Laptop') , ('LG' , 'TV');

INSERT INTO Users (
	UserName , UserLastName ,UserAddress , UserNationalCode)
	VALUES ('Amin' , 'Ghasemi' , 'Tehran' , '0123456789'),
	('Ali' , 'Moradi' , 'Kerman' , '9876543210');

go

SELECT * FROM Products
SELECT * FROM Users