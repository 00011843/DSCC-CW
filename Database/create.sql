-- Create the database (replace YourDatabaseName with your desired name)
CREATE DATABASE YourDatabaseName;
GO

-- Use the newly created database
USE YourDatabaseName;
GO

-- Create the Company table
CREATE TABLE Company
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX),
    Contact NVARCHAR(255)
);
GO

-- Create the Vacancy table
CREATE TABLE Vacancy
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    JobName NVARCHAR(255) NOT NULL,
    CompanyId INT FOREIGN KEY REFERENCES Company(Id),
    JobDescription NVARCHAR(MAX),
    JobOpenedDate DATETIME,
    JobClosedDate DATETIME,
    Salary FLOAT
);
GO
