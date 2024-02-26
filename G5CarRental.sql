CREATE DATABASE G5CarRental;
GO
USE G5CarRental;
GO

CREATE TABLE Customers(
    CustomerID INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    CustomerFirstName NVARCHAR(75) NOT NULL,
    CustomerLastName NVARCHAR(75) NOT NULL,
	UID NVARCHAR(25) NOT NULL, --Unique identity document--
    Address NVARCHAR(255) NOT NULL,
    Phone NVARCHAR(35) NOT NULL,
    CustomerEmail NVARCHAR(75) NOT NULL,
    License NVARCHAR(25) NOT NULL
);
GO
CREATE TABLE Vehicles(
    VehicleID INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    Brand NVARCHAR(75) NOT NULL,
    Model NVARCHAR(75) NOT NULL,
    Year INT NOT NULL,
    Type NVARCHAR(50) NOT NULL,
    Availability BIT NOT NULL
);
GO
CREATE TABLE Employees(
    EmployeeID INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    EmployeeFirstName NVARCHAR(75) NOT NULL,
    EmployeeLastName NVARCHAR(75) NOT NULL,
    Position NVARCHAR(100) NOT NULL,
    Salary MONEY NOT NULL,
	EmployeeEmail NVARCHAR(75) NOT NULL,
    HireDate DATE NOT NULL
);
GO
CREATE TABLE Rentals(
    RentID INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    CustomerID INT NOT NULL,
    VehicleID INT NOT NULL,
    EmployeeID INT NOT NULL,
    StartDate DATETIME NOT NULL,
    EndDate DATETIME NOT NULL,
    AmountPaid MONEY NOT NULL,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (VehicleID) REFERENCES Vehicles(VehicleID),
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
);
GO