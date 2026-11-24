USE [SoftUni]

GO

-- Problem 1
SELECT [FirstName],
	   [LastName]
  FROM [Employees]
 WHERE [FirstName] LIKE 'Sa%'

 GO

-- Problem 2
SELECT [FirstName],
	   [LastName]
  FROM [Employees]
 WHERE [LastName] LIKE '%ei%'

GO

-- Problem 3
SELECT [FirstName]
  FROM [Employees]
 WHERE [DepartmentID] IN (3, 10)
   AND YEAR([HireDate]) BETWEEN 1995 AND 2005

GO

-- Problem 4
SELECT [FirstName],
	   [LastName]
  FROM [Employees]
 WHERE CHARINDEX('engineer', [JobTitle]) = 0

GO

-- Problem 5
  SELECT [Name]
    FROM [Towns]
   WHERE LEN([Name]) IN (5, 6)
ORDER BY [Name]

GO

-- Problem 6
  SELECT *
    FROM [Towns]
   WHERE [Name] LIKE '[MKBE]%'
ORDER BY [Name]

  SELECT *
    FROM [Towns]
   WHERE LEFT([Name], 1) IN ('M', 'K', 'B', 'E')
ORDER BY [Name]

GO

-- Problem 7
  SELECT *
    FROM [Towns]
   WHERE [Name] LIKE '[^RBD]%'
ORDER BY [Name]

GO

-- Problem 8
CREATE VIEW [V_EmployeesHiredAfter2000] AS
     SELECT [FirstName],
            [LastName]
       FROM [Employees]
      WHERE [HireDate] >= '2001-01-01'

GO

-- Problem 9
SELECT [FirstName],
       [LastName]
  FROM [Employees]
 WHERE LEN([LastName]) = 5

GO
-- Problem 10
  SELECT [EmployeeID],  /* 3 */
         [FirstName],
         [LastName],
         [Salary],
         DENSE_RANK() OVER (PARTITION BY [Salary] ORDER BY [EmployeeID])
      AS [Rank]
    FROM [Employees]  /* 1 */
   WHERE [Salary] BETWEEN 10000 AND 50000   /* 2 */
ORDER BY [Salary] DESC  /* 4 */

GO

-- Problem 11
  SELECT *
    FROM (
             SELECT [EmployeeID],  /* 3 */
                    [FirstName],
                    [LastName],
                    [Salary],
                    DENSE_RANK() OVER (PARTITION BY [Salary] ORDER BY [EmployeeID])
                 AS [Rank]
               FROM [Employees]  /* 1 */
              WHERE [Salary] BETWEEN 10000 AND 50000   /* 2 */
         )
      AS [TempRankResultSet]
   WHERE [Rank] = 2
ORDER BY [Salary] DESC

GO

-- Problem 12
USE [Geography]

GO

  SELECT [CountryName],
         [ISOCode]
    FROM [Countries]
   WHERE (LEN([CountryName]) - LEN(REPLACE(UPPER([CountryName]), 'A', ''))) >= 3
ORDER BY [ISOCode]

GO

-- Problem 13
/* Multiple select */ 
  SELECT [p].[PeakName],
         [r].[RiverName],
         CONCAT(SUBSTRING(LOWER([p].[PeakName]), 1, LEN([p].[PeakName]) - 1), LOWER([r].[RiverName]))
      AS [Mix]
    FROM [Peaks]
      AS [p],
         [Rivers]
      AS [r]
   WHERE LOWER(RIGHT([PeakName], 1)) = LOWER(LEFT([RiverName], 1))
ORDER BY [Mix]

GO

-- Problem 14
USE [Diablo]

GO

SELECT TOP (50) [Name],
           FORMAT([Start], 'yyyy-MM-dd') AS Start
      FROM [Games]
     WHERE YEAR([Start]) IN (2011, 2012)
  ORDER BY [Start],
           [Name]

GO

-- Problem 15
  SELECT [Username],
         SUBSTRING(Email, CHARINDEX('@', Email) + 1 , LEN(Email))
      AS [Email Provider]
    FROM [Users]
ORDER BY [Email Provider],
         [Username]

GO

-- Problem 16
  SELECT Username, IpAddress
    FROM Users
   WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username

GO

-- Problem 17
  SELECT [Name]
      AS [Game],
         CASE
             WHEN DATEPART(HOUR, [Start]) BETWEEN 0 AND 11 THEN 'Morning'
             WHEN DATEPART(HOUR, [Start]) BETWEEN 12 AND 17 THEN 'Afternoon'
             ELSE 'Evening'
         END
      AS [Part of the Day],
         CASE
             WHEN [Duration] <= 3 THEN 'Extra Short'
             WHEN [Duration] BETWEEN 4 AND 6 THEN 'Short'
             WHEN [Duration] > 6 THEN 'Long'
             WHEN [Duration] IS NULL THEN 'Extra Long'
         END
      AS [Duration]
    FROM [Games]
      AS [g]
ORDER BY [Game],
         [Duration],
         [Part Of the Day]

GO

-- Problem 18
CREATE DATABASE [OrdersTable]

GO

USE [OrdersTable]

GO

CREATE TABLE [Orders] (
    [Id] INT PRIMARY KEY,
    [ProductName] NVARCHAR(100),
    [OrderDate] DATETIME
)

INSERT INTO [Orders] ([Id], [ProductName], [OrderDate])
VALUES
(1, 'Butter', '2016-09-19 00:00:00.000'),
(2, 'Milk', '2016-09-30 00:00:00.000'),
(3, 'Cheese', '2016-09-04 00:00:00.000'),
(4, 'Bread', '2015-12-20 00:00:00.000'),
(5, 'Tomatoes', '2015-01-01 00:00:00.000');


  SELECT [ProductName],
         [OrderDate],
         DATEADD(day, 3, OrderDate) 
      AS [Pay Due],
         DATEADD(month, 1, OrderDate) 
      AS [Deliver Due]
    FROM [Orders]

GO

