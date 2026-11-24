--Problem 1
USE [Minions]

-- Problem 2
CREATE TABLE [Minions](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[Age] SMALLINT
)

CREATE TABLE [Towns](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
)
GO

-- Problem 3
ALTER TABLE [Minions]
ADD [TownId] INT NOT NULL

ALTER TABLE [Minions]
ADD FOREIGN KEY ([TownId]) REFERENCES [Towns]([Id]) 

GO

-- Problem 4
INSERT INTO [Towns] ([Name])
VALUES
('Sofia'),
('Plovdiv'),
('Varna')

INSERT INTO [Minions]([Name], [Age], [TownId])
VALUES
('Kevin', 22, 1),
('Bob', 15, 3),
('Steward', NULL, 2)

GO

-- Problem 5
TRUNCATE TABLE [Minions]

GO

-- Problem 6
DROP TABLE [Minions]
DROP TABLE [Towns]

GO

-- Problem 7
CREATE TABLE [People](
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
	[Name] NVARCHAR(200) NOT NULL,
	[Picture] VARBINARY(MAX),
	[Height] DECIMAL(5, 2),
	[Weight] DECIMAL(5, 2),
	[Gender] CHAR(1) NOT NULL CHECK (Gender IN ('m', 'f')),
	[Birthdate] DATE NOT NULL,
	[Biography] NVARCHAR(MAX)
)


INSERT INTO [People] ([Name], [Picture], [Height], [Weight], [Gender], [Birthdate], [Biography])
VALUES
('Ivan Ivanov', NULL, 1.80, 75.50, 'm', '1990-05-12', 'Software developer from Sofia.'),
('Maria Petrova', NULL, 1.65, 60.20, 'f', '1988-11-23', 'Marketing specialist.'),
('Georgi Georgiev', NULL, 1.90, 85.00, 'm', '1995-01-08', 'Basketball player.'),
('Elena Dimitrova', NULL, 1.70, 55.00, 'f', '2000-03-15', 'Student in economics.'),
('Peter Pan', NULL, 1.75, 68.40, 'm', '1992-07-01', 'Musician and traveler.');

GO

-- Problem 8
CREATE TABLE [Users] (
[Id] BIGINT PRIMARY KEY IDENTITY(1, 1),
[Username] VARCHAR(30) NOT NULL UNIQUE,
[Password] VARCHAR(26) NOT NULL,
[ProfilePicture] VARBINARY(MAX) CHECK (DATALENGTH(ProfilePicture) <= 900000),
[LastLoginTime] DATETIME,
[IsDeleted] BIT NOT NULL
)

INSERT INTO [Users] ([Username], [Password], [ProfilePicture], [LastLoginTime], [IsDeleted])
VALUES
('ivan123', 'passIvan2025', NULL, '2025-09-01 10:30:00', 0),
('maria88', 'securePass88', NULL, '2025-09-02 14:15:00', 0),
('georgi95', 'geoPass95', NULL, '2025-08-25 09:00:00', 1),
('elena2000', 'elenaCool20', NULL, '2025-09-05 19:45:00', 0),
('peterPan', 'Neverland123', NULL, NULL, 0);

GO

-- Problem 9
EXEC sp_helpconstraint [Users]

ALTER TABLE [Users]
DROP CONSTRAINT [PK__Users__3214EC072AD45F0B]

ALTER TABLE [Users]
ADD CONSTRAINT [PK_Users_Id_Username] PRIMARY KEY ([Id], [Username])

GO

-- Problem 10
ALTER TABLE [Users]
ADD CONSTRAINT [CK_Users_Password_MinLength]
CHECK (LEN([Password]) >= 5)

GO

--Problem 11
ALTER TABLE [Users] 
ADD CONSTRAINT [DF_Users_LastLoginTime] DEFAULT GETDATE() FOR [LastLoginTime]

GO

--Problem 12
EXEC sp_helpconstraint [Users]

ALTER TABLE [Users]
DROP CONSTRAINT [PK_Users_Id_Username]

ALTER TABLE [Users]
ADD CONSTRAINT [PK_Username] PRIMARY KEY ([Id])

ALTER TABLE [Users]
ADD CONSTRAINT [UQ_Users_Username] UNIQUE ([Username])

ALTER TABLE [Users]
ADD CONSTRAINT [CK_Users_Username] CHECK (LEN([Username]) >= 3)

-- Change the name of the CONSTRAINT
ALTER TABLE [Users]
DROP CONSTRAINT [PK_Username]

ALTER TABLE [Users]
ADD CONSTRAINT [PK_Users_Id] PRIMARY KEY ([Id])

GO

-- Problem 13
CREATE DATABASE [Movies Database]

USE [Movies Database]

CREATE TABLE [Directors](
[Id] INT PRIMARY KEY IDENTITY(1, 1),
[DirectorName] NVARCHAR(100) NOT NULL,
[Notes] NVARCHAR(MAX)
)

CREATE TABLE [Genres](
[Id] INT PRIMARY KEY IDENTITY(1, 1),
[GenreName] NVARCHAR(50) NOT NULL,
[Notes] NVARCHAR(MAX)
)

CREATE TABLE [Categories](
[Id] INT PRIMARY KEY IDENTITY(1, 1),
[CategoryName] NVARCHAR(50) NOT NULL,
[Notes] NVARCHAR(MAX)
)

CREATE TABLE [Movies](
[Id] INT PRIMARY KEY IDENTITY(1, 1),
[Title] NVARCHAR(200) NOT NULL,
[DirectorId] INT FOREIGN KEY REFERENCES [Directors]([Id]) NOT NULL,
[CopyrightYear] SMALLINT,
[Length] INT,
[GenreId] INT FOREIGN KEY REFERENCES [Genres]([Id]) NOT NULL,
[CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]) NOT NULL,
[Rating] DECIMAL(3, 1),
[Notes] NVARCHAR(MAX)
)

INSERT INTO [Directors] ([DirectorName], [Notes])
VALUES
('Steven Spielberg', 'Known for blockbuster films'),
('Christopher Nolan', 'Famous for mind-bending stories'),
('Quentin Tarantino', 'Known for dialogue-driven films'),
('Martin Scorsese', 'Master of crime dramas'),
('Peter Jackson', 'Director of The Lord of the Rings trilogy')

-- Genres
INSERT INTO [Genres] ([GenreName], [Notes])
VALUES
('Action', 'Fast-paced movies'),
('Drama', 'Emotionally intense movies'),
('Comedy', 'Humorous movies'),
('Horror', 'Scary movies'),
('Science Fiction', 'Futuristic or technology-focused films')

-- Categories
INSERT INTO [Categories] ([CategoryName], [Notes])
VALUES
('Blockbuster', 'High-budget films'),
('Independent', 'Low-budget, artistic films'),
('Classic', 'Movies considered timeless'),
('Animated', 'Animation films'),
('Documentary', 'Non-fictional films')

-- Movies
INSERT INTO [Movies] ([Title], [DirectorId], [CopyrightYear], [Length], [GenreId], [CategoryId], [Rating], [Notes])
VALUES
('Jurassic Park', 1, 1993, 127, 1, 1, 8.1, 'Dinosaur adventure'),
('Inception', 2, 2010, 148, 5, 1, 8.8, 'Dream within a dream'),
('Pulp Fiction', 3, 1994, 154, 2, 3, 8.9, 'Crime classic'),
('The Wolf of Wall Street', 4, 2013, 180, 2, 1, 8.2, 'Stock market drama'),
('The Lord of the Rings: The Fellowship of the Ring', 5, 2001, 178, 5, 1, 8.8, 'Epic fantasy adventure')

GO

--Problem 14
CREATE DATABASE [CarRental]

GO

USE [CarRental]

GO

CREATE TABLE [Categories](
[Id] INT PRIMARY KEY IDENTITY(1, 1),
[CategoryName] NVARCHAR(50) NOT NULL,
[DailyRate] DECIMAL(10, 2) NOT NULL,
[WeeklyRate] DECIMAL(10, 2) NOT NULL,
[MonthlyRate] DECIMAL(10, 2) NOT NULL,
[WeekendRate] DECIMAL(10, 2) NOT NULL,
)

CREATE TABLE [Cars] (
[Id] INT PRIMARY KEY IDENTITY(1, 1),
[PlateNumber] VARCHAR(20) NOT NULL UNIQUE,
[Manufacturer] VARCHAR(50) NOT NULL,
[Model] VARCHAR(50) NOT NULL,
[CarYear] INT NOT NULL,
[CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]) NOT NULL,
[Doors] SMALLINT,
[Picture] VARBINARY(MAX),
[Condition] NVARCHAR(50) NOT NULL,
[Available] BIT NOT NULL
)

CREATE TABLE [Employees](
[Id] INT PRIMARY KEY IDENTITY(1, 1),
[FirstName] NVARCHAR(50) NOT NULL,
[LastName] NVARCHAR(80) NOT NULL,
[Title] NVARCHAR(80) NOT NULL,
[Notes] NVARCHAR(200)
)

CREATE TABLE [Customers](
[Id] INT PRIMARY KEY IDENTITY(1, 1),
[DriverLicenceNumber] NVARCHAR(20) NOT NULL UNIQUE,
[FullName] NVARCHAR(100) NOT NULL,
[Address] NVARCHAR(100) NOT NULL,
[City] NVARCHAR(50) NOT NULL,
[ZIPCode] NVARCHAR(10) NOT NULL,
[Notes] NVARCHAR(200)
)


CREATE TABLE [RentalOrders](
[Id] INT PRIMARY KEY IDENTITY(1, 1),
[EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]) NOT NULL,
[CustomerId] INT FOREIGN KEY REFERENCES [Customers]([Id]) NOT NULL,
[CarId] INT FOREIGN KEY REFERENCES [Cars]([Id]) NOT NULL,
[TankLevel] DECIMAL(5, 2) NOT NULL,
[KilometrageStart] INT NOT NULL,
[KilometrageEnd] INT NOT NULL,
[TotalKilometrage] AS ([KilometrageEnd] - [KilometrageStart]) PERSISTED,
[StartDate] DATE NOT NULL,
[EndDate] DATE NOT NULL,
[TotalDays] AS (DATEDIFF(DAY, [StartDate], [EndDate])) PERSISTED,
[RateApplied] DECIMAL(10, 2),
[TaxRate] DECIMAL(5, 2),
[OrderStatus] NVARCHAR(20) NOT NULL,
[Notes] NVARCHAR(200),
)

INSERT INTO [Categories] ([CategoryName], [DailyRate], [WeeklyRate], [MonthlyRate], [WeekendRate])
VALUES
('Economy', 30.00, 180.00, 600.00, 50.00),
('SUV', 60.00, 350.00, 1200.00, 100.00),
('Luxury', 120.00, 700.00, 2500.00, 200.00);

INSERT INTO [Cars] ([PlateNumber], [Manufacturer], [Model], [CarYear], [CategoryId], [Doors], [Picture], [Condition], [Available])
VALUES
('ABC123', 'Toyota', 'Yaris', 2020, 1, 4, NULL, 'Good', 1),
('XYZ789', 'BMW', 'X5', 2021, 2, 5, NULL, 'Excellent', 1),
('LMN456', 'Mercedes', 'E-Class', 2019, 3, 4, NULL, 'Good', 0);

INSERT INTO [Employees] ([FirstName], [LastName], [Title], [Notes])
VALUES
('John', 'Doe', 'Manager', '5 years experience'),
('Anna', 'Smith', 'Agent', NULL),
('Peter', 'Brown', 'Mechanic', 'Specialist in SUVs');

INSERT INTO [Customers] ([DriverLicenceNumber], [FullName], [Address], [City], [ZIPCode], [Notes])
VALUES
('DL12345', 'Carlos García', 'Calle Mayor 10', 'Madrid', '28013', NULL),
('DL67890', 'Maria Lopez', 'Av. Diagonal 200', 'Barcelona', '08018', 'VIP customer'),
('DL54321', 'John Johnson', 'Baker Street 221B', 'London', 'NW16XE', NULL);

INSERT INTO [RentalOrders] ([EmployeeId], [CustomerId], [CarId], [TankLevel], [KilometrageStart], [KilometrageEnd], [StartDate], [EndDate], [RateApplied], [TaxRate], [OrderStatus], [Notes])
VALUES
(1, 1, 1, 100.00, 5000, 5200, '2025-09-01', '2025-09-05', 30.00, 21.00, 'Completed', NULL),
(2, 2, 2, 80.00, 12000, 12300, '2025-09-03', '2025-09-07', 60.00, 21.00, 'Completed', 'Customer requested child seat'),
(3, 3, 3, 90.00, 30000, 30150, '2025-09-10', '2025-09-12', 120.00, 21.00, 'Pending', NULL);

GO

-- Problem 15
CREATE DATABASE [Hotel]

GO

USE [Hotel]

GO

CREATE TABLE Employees (
Id INT PRIMARY KEY IDENTITY(1, 1),
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(80) NOT NULL,
Title NVARCHAR(50) NOT NULL,
Notes NVARCHAR(200)
)

CREATE TABLE Customers (
AccountNumber INT PRIMARY KEY IDENTITY(1, 1),
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(80) NOT NULL,
PhoneNumber NVARCHAR(20) NOT NULL,
EmergencyName NVARCHAR(100) NOT NULL,
EmergencyNumber NVARCHAR(20) NOT NULL,
Notes NVARCHAR(200)
)

CREATE TABLE RoomStatus (
RoomStatus NVARCHAR(20) PRIMARY KEY,
Notes NVARCHAR(200)
)

CREATE TABLE RoomTypes (
RoomType NVARCHAR(20) PRIMARY KEY,
Notes NVARCHAR(200)
)

CREATE TABLE BedTypes (
BedType NVARCHAR(20) PRIMARY KEY,
Notes NVARCHAR(200)
)

CREATE TABLE Rooms (
RoomNumber INT PRIMARY KEY,
RoomType NVARCHAR(20) FOREIGN KEY REFERENCES RoomTypes(RoomType) NOT NULL,
BedType NVARCHAR(20) FOREIGN KEY REFERENCES BedTypes(BedType) NOT NULL,
Rate DECIMAL(10,2) NOT NULL,
RoomStatus NVARCHAR(20) FOREIGN KEY REFERENCES RoomStatus(RoomStatus) NOT NULL,
Notes NVARCHAR(200)
)

CREATE TABLE Payments(
Id INT PRIMARY KEY IDENTITY(1, 1),
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
PaymentDate DATE NOT NULL,
AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL,
FirstDateOccupied DATE NOT NULL,
LastDateOccupied DATE NOT NULL,
TotalDays AS (DATEDIFF(DAY, FirstDateOccupied, LastDateOccupied)) PERSISTED,
AmountCharged DECIMAL(5, 2) NOT NULL,
TaxRate DECIMAL(5, 2) NOT NULL,
TaxAmount AS (AmountCharged * (TaxRate/100.0)) PERSISTED,
PaymentTotal AS (AmountCharged + (AmountCharged * (TaxRate/100.0))) PERSISTED,
Notes NVARCHAR(200) NULL
)

CREATE TABLE Occupancies(
Id INT PRIMARY KEY IDENTITY(1, 1),
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
DateOccupied DATE NOT NULL,
AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL,
RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber) NOT NULL,
RateApplied DECIMAL(10,2) NOT NULL,
PhoneCharge DECIMAL(10,2) NOT NULL,
Notes NVARCHAR(200) NULL
)

INSERT INTO Employees (FirstName, LastName, Title, Notes)
VALUES
('John', 'Doe', 'Manager', '10 years experience'),
('Anna', 'Smith', 'Receptionist', NULL),
('Peter', 'Brown', 'Housekeeping', 'Specialist in VIP rooms');

INSERT INTO Customers (FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes) 
VALUES
('Carlos', 'García', '600111222', 'Maria García', '600333444', NULL),
('Laura', 'Lopez', '699888777', 'Jose Lopez', '699555444', 'Allergic to nuts'),
('John', 'Johnson', '700222111', 'Emma Johnson', '700999888', NULL);

INSERT INTO RoomStatus (RoomStatus, Notes) 
VALUES
('Available', 'Room is ready'),
('Occupied', 'Currently taken'),
('Maintenance', 'Out of service');

INSERT INTO RoomTypes (RoomType, Notes) 
VALUES
('Single', '1 guest'),
('Double', '2 guests'),
('Suite', 'Luxury suite');

INSERT INTO BedTypes (BedType, Notes) VALUES
('Single', '90x200 cm'),
('Double', '140x200 cm'),
('King', '180x200 cm');

INSERT INTO Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes) VALUES
(101, 'Single', 'Single', 50.00, 'Available', NULL),
(202, 'Double', 'Double', 80.00, 'Occupied', 'Near pool'),
(303, 'Suite', 'King', 200.00, 'Maintenance', 'Jacuzzi under repair');

INSERT INTO Payments (EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, AmountCharged, TaxRate, Notes) VALUES
(1, '2025-09-01', 1, '2025-09-01', '2025-09-05', 200.00, 10.00, 'Paid by credit card'),
(2, '2025-09-03', 2, '2025-09-03', '2025-09-06', 240.00, 15.00, NULL),
(1, '2025-09-10', 3, '2025-09-10', '2025-09-12', 400.00, 20.00, 'Late checkout included');

INSERT INTO Occupancies (EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes) VALUES
(2, '2025-09-01', 1, 101, 50.00, 5.00, NULL),
(3, '2025-09-03', 2, 202, 80.00, 0.00, 'No phone usage'),
(1, '2025-09-10', 3, 303, 200.00, 10.00, 'VIP guest');

GO

-- Problem 16
CREATE DATABASE [SoftUni]

GO

USE [SoftUni]

GO

CREATE TABLE [Towns](
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Addresses](
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
	[AddressText] VARCHAR(200) NOT NULL,
	[TownId] INT FOREIGN KEY REFERENCES [Towns]([Id]) NOT NULL
)

CREATE TABLE [Departments] (
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
	[Name] VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE [Employees] (
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
	[FirstName] VARCHAR(50) NOT NULL,
	[MiddleName] VARCHAR(50),
	[LastName] VARCHAR(100) NOT NULL,
	[JobTitle] VARCHAR(100) NOT NULL,
	[DepartmentId] INT FOREIGN KEY REFERENCES [Departments]([Id]) NOT NULL,
	[HireDate] DATE DEFAULT(GETDATE()) NOT NULL,
	[Salary] DECIMAL(16,4) NOT NULL,
	[AddressId] INT FOREIGN KEY REFERENCES [Addresses]([Id]) NOT NULL
)

GO

-- Problem 18
INSERT INTO Towns (Name)
VALUES 
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas');


INSERT INTO Departments (Name)
VALUES 
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance');


INSERT INTO Addresses (AddressText, TownId)
VALUES ('Main Street 1', 1),
       ('Central Blvd 2', 2),
       ('Sea Garden 5', 3),
       ('Sunset Road 8', 4),
       ('Student Campus 10', 1);



INSERT INTO Employees (FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary, AddressId)
VALUES 
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer',4,'2013-02-01', 3500.00, 1),

('Petar', 'Petrov', 'Petrov', 'Senior Engineer',1, '2004-03-02', 4000.00, 2),

('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-08-28', 525.25, 3),

('Georgi', 'Teziev', 'Ivanov', 'CEO', 2,'2007-12-09', 3000.00, 4),

('Peter', 'Pan', 'Pan', 'Intern', 3, '2016-08-28', 599.88, 5);

GO


-- Problem 19
SELECT *
FROM [Towns]

SELECT *
FROM [Departments]

SELECT *
FROM [Employees]

GO

--Problem 20
SELECT *
FROM [Towns]
ORDER BY [Name]

SELECT *
FROM [Departments]
ORDER BY [Name]

SELECT *
FROM [Employees]
ORDER BY [Salary] DESC

GO

-- Problem 21
SELECT [Name]
FROM [Towns]
ORDER BY [Name]

SELECT [Name]
FROM [Departments]
ORDER BY [Name]

SELECT [FirstName], [LastName], [JobTitle], [Salary]
FROM [Employees]
ORDER BY [Salary] DESC

GO

-- Problem 22
UPDATE [Employees]
SET [Salary] += [Salary] * 0.1

SELECT [Salary]
FROM [Employees]

GO

-- Problem 23
UPDATE [Payments]
SET [TaxRate] = TaxRate * 0.97

SELECT [TaxRate]
FROM [Payments]

GO

-- Problem 24
TRUNCATE TABLE [Occupancies]