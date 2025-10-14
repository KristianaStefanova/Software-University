CREATE DATABASE [EntityRelationsDemo2025]

USE [EntityRelationsDemo2025]

GO


-- Problem 1
    CREATE TABLE [Passports](
    [PassportID] INT PRIMARY KEY IDENTITY(101 , 1),
[PassportNumber] CHAR(8) NOT NULL
)


CREATE TABLE [Persons](
  [PersonId] INT PRIMARY KEY IDENTITY,
 [FirstName] NVARCHAR(50) NOT NULL,
	[Salary] DECIMAL(14, 2) NOT NULL,
[PassportID] INT FOREIGN KEY REFERENCES [Passports]([PassportID]) UNIQUE NOT NULL
)

INSERT INTO [Passports]([PassportNumber])
     VALUES
			('N34FG21B'),
			('K65LO4R7'),
			('ZE657QP2')

INSERT INTO [Persons]([FirstName], [Salary], [PassportID])
     VALUES
			('Roberto', 43300.00, 102), 
			('Tom', 56100.00, 103),
			('Yana', 60200.00, 101)

GO


-- Problem 2
CREATE TABLE [Manufacturers](
[ManufacturerID] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(80) NOT NULL,
[EstablishedOn] DATE NOT NULL,
)

CREATE TABLE [Models](
   [ModelID] INT PRIMARY KEY IDENTITY(101, 1),
   [Name] VARCHAR(80) NOT NULL,
   [ManufacturerID] INT FOREIGN KEY REFERENCES [Manufacturers]([ManufacturerID]) NOT NULL
)


INSERT INTO [Manufacturers] ([Name], [EstablishedOn])
     VALUES 
			('BMW', '07/03/1916'),
			('Tesla', '01/01/2003'),
			('Lada', '01/05/1966')


INSERT INTO [Models] ([Name], [ManufacturerID])
     VALUES 
			('X1', 1),
			('i6', 1),
			('Model S', 2),
			('Model X', 2),
			('Model 3', 2)

GO


-- Problem 3
CREATE TABLE [Exams](
	[ExamID] INT PRIMARY KEY IDENTITY(101, 1),
	[Name] VARCHAR(100 ) NOT NULL
)

CREATE TABLE [Students](
	[StudentID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [StudentsExams](
	[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID]),
	[ExamID] INT FOREIGN KEY REFERENCES [Exams]([ExamID]),
	CONSTRAINT [PK_Composite_StudentID_ExamID] PRIMARY KEY([StudentID], [ExamID])
)

GO


-- Problem 4
CREATE TABLE [Teachers](
	[TeacherID] INT PRIMARY KEY IDENTITY(101, 1),
	[Name] VARCHAR(50) NOT NULL,
	[ManagerID] INT FOREIGN KEY REFERENCES [Teachers]([TeacherID])
)

GO


-- Problem 5
CREATE TABLE [ItemTypes](
	[ItemTypeID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Cities(
	[CityID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Items](
	[ItemID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(80) NOT NULL,
	[ItemTypeID] INT FOREIGN KEY REFERENCES [ItemTypes]([ItemTypeID]) NOT NULL
)

CREATE TABLE [Customers](
	[CustomerID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(100) NOT NULL,
	[Birthday] DATE,
	[CityID] INT FOREIGN KEY REFERENCES [Cities]([CityID]) NOT NULL
)

CREATE TABLE [Orders](
	[OrderID] INT PRIMARY KEY IDENTITY,
	[CustomerID] INT FOREIGN KEY REFERENCES [Customers]([CustomerID]) NOT NULL
)

CREATE TABLE [OrderItems](
	[OrderID] INT FOREIGN KEY REFERENCES [Orders]([OrderID]) NOT NULL,
	[ItemID] INT FOREIGN KEY REFERENCES [Items]([ItemID]) NOT NULL,
	CONSTRAINT [PK_Composite_OrderID_ItemsID] PRIMARY KEY ([OrderID], [ItemID])
)

GO 


CREATE DATABASE [University]

USE [University]

GO


-- Problem 6
CREATE TABLE [Majors](
	[MajorID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(80) NOT NULL
)

CREATE TABLE [Subjects](
	[SubjectID] INT PRIMARY KEY IDENTITY,
	[SubjectName] VARCHAR(50) NOT NULL
)

CREATE TABLE [Students](
	[StudentID] INT PRIMARY KEY IDENTITY,
	[StudentNumber] VARCHAR(50) UNIQUE NOT NULL,
	[StudentName] VARCHAR(50) NOT NULL,
	[MajorID] INT FOREIGN KEY REFERENCES [Majors]([MajorID]) NOT NULL
)

CREATE TABLE [Payments](
	[PaymentID] INT PRIMARY KEY IDENTITY,
	[PaymentDate] DATETIME2 NOT NULL,
	[PaymentAmount] DECIMAL(18, 2) NOT NULL,
	[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID]) NOT NULL
)

CREATE TABLE [Agenda](
	[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID]) NOT NULL,
	[SubjectID] INT FOREIGN KEY REFERENCES [Subjects]([SubjectID]) NOT NULL,
	CONSTRAINT [PK_Composite_StudentID_SubjectID] PRIMARY KEY ([StudentID], [SubjectID])
)

GO


-- Problem 9
  SELECT [m].[MountainRange],
         [p].[PeakName],
  	     [p].[Elevation]
    FROM [Peaks] 
      AS [p]
    JOIN [Mountains] 
      AS [m]
      ON [p].[MountainId] = [m].[Id]
   WHERE [m].[MountainRange] = 'Rila'
ORDER BY [p].[Elevation] DESC


