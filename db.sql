/*
File Name - db.sql
Programmers Name - Arindm Sharma ans Zivojin Pecin
Date of first useful version - 01/10/2017
Desription - The following script runs queries to create a Db called YoYoDB.
*/

-- dropping table if it already exists to start fresh--
DROP database IF EXISTS YoYoDB;

-- create database--
create database YoYoDB;

-- use the created database--
use YoYoDB;

-- creating Products table--
CREATE TABLE Products (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    ProductName VARCHAR(255),
);

-- creating CurrentProduction table--
CREATE TABLE CurrentProduction (
    ProductionID BIGINT IDENTITY(1,1) PRIMARY KEY,
	ProductID INT,
	FOREIGN KEY (ProductID)
        REFERENCES Products (ProductID),
		WorkArea VARCHAR(255),
		Line VARCHAR(255),
		ProductStatus VARCHAR(255),
		ProductionDateTime DATETIME,
		SerialNumber VARCHAR(255),
		Reason VARCHAR(225)

);

Insert into Products(ProductName) values('Original Sleeper'),('Black Beauty'),('Firecracker'),('Lemon Yellow'),('Midnight Blue'),('Screaming Orange'),('Gold Glitter'),('White Lightening');

