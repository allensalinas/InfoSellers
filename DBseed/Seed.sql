USE master
GO

DROP DATABASE IF EXISTS InfoSellers
go

CREATE DATABASE InfoSellers
GO

USE InfoSellers
GO

CREATE TABLE CommisionType
(
	ID INT IDENTITY(1, 1) PRIMARY KEY,
	CommissionTypeName varchar(20) NOT NULL,
	CommissionValue DECIMAL(10,2) NOT NULL
);
GO

CREATE TABLE Rol
(
	ID INT IDENTITY(1, 1) PRIMARY KEY,
	RolName VARCHAR(20) NOT NULL,
	CommissionTypeID INT
)

CREATE TABLE Seller
(
	Nit VARCHAR(50) PRIMARY KEY,
	FullName VARCHAR(200) NOT NULL,
	SellerAddress VARCHAR(200) NOT NULL,
	Phone VARCHAR(20) NOT NULL,
	PenaltyPercentage DECIMAL(5,2)
)
GO

INSERT INTO CommisionType VALUES('junior', 100);
INSERT INTO CommisionType VALUES('mid', 120);
INSERT INTO CommisionType VALUES('expert', 150);