USE [SoftUni]

GO


-- Problem 1
SELECT TOP(5) [e].[EmployeeID]
           AS [EmployeeId],
       	      [e].[JobTitle],
       	      [e].[AddressID]
           AS [AddressId],
       	      [a].[AddressText]
         FROM [Employees]
           AS [e]
         JOIN [Addresses]
           AS [a]
           ON [a].[AddressID] = [e].[AddressID]
     ORDER BY [AddressId]

GO


-- Problem 2
SELECT TOP (50) [e].[FirstName],
           [e].[LastName],
           [t].[Name]
        AS [Town],
           [a].[AddressText]
      FROM [Employees]
        AS [e]
      JOIN [Addresses]
        AS [a]
        ON [a].[AddressID] = [e].[AddressID]
      JOIN [Towns] 
        AS [t]
        ON [t].[TownID] = [a].[TownID]
  ORDER BY [FirstName],
           [LastName]
    
GO


-- Problem 3
  SELECT [e].[EmployeeID],
         [e].[FirstName],
         [e].[LastName],
         [d].[Name]
      AS [DepartmentName]
    FROM [Employees]
      AS [e]
    JOIN [Departments]
      AS [d]
      ON [d].[DepartmentID] = [e].[DepartmentID]
   WHERE [d].[Name] = 'Sales'
ORDER BY [e].[EmployeeID]

GO


-- Problem 4
SELECT TOP(5) [e].[EmployeeID],
              [e].[FirstName],
              [e].[Salary],
              [d].[Name]
           AS [DepartmentName]
         FROM [Employees]
           AS [e]
         JOIN [Departments]
           AS [d]
           ON [d].[DepartmentID] = [e].[DepartmentID]
        WHERE [Salary] > 15000
     ORDER BY [e].[DepartmentID]

GO


-- Problem 5
SELECT TOP(3) [e].[EmployeeID],
              [e].[FirstName]
         FROM [Employees]
           AS [e]
    LEFT JOIN [EmployeesProjects]
           AS [ep]
           ON [e].[EmployeeID] = [ep].[EmployeeID]
        WHERE [ep].[ProjectID] IS NULL
     ORDER BY [e].[EmployeeID]

GO


-- Problem 6
SELECT [e].[FirstName],
       [e].[LastName],
       [e].[HireDate],
       [d].[Name]
    AS [DeptName]
  FROM [Employees] 
    AS [e]
  JOIN [Departments]
    AS [d]
    ON [d].[DepartmentID] = [e].[DepartmentID]
   AND [e].[HireDate] > '1999-01-01'
   AND [d].[Name] IN ('Sales', 'Finance')

GO


-- Problem 7
  SELECT TOP(5) [e].[EmployeeID],
                [e].[FirstName],
                [p].[Name]
             AS [ProjectName]
           FROM [EmployeesProjects]
             AS [ep]
           JOIN [Employees]
             AS [e]
             ON [e].[EmployeeID] = [ep].[EmployeeID]
           JOIN [Projects]
             AS [p]
             ON [p].[ProjectID] = [ep].[ProjectID]
          WHERE [p].[StartDate] > '2002-08-13' 
            AND [p].EndDate IS NULL
       ORDER BY [e].[EmployeeID]

GO


-- Problem 8
  SELECT [e].[EmployeeID],
         [e].[FirstName],
         CASE
             WHEN [p].[StartDate] >= '2005-01-01' THEN NULL
             ELSE [p].[Name]
         END
      AS [ProjectName]
    FROM [EmployeesProjects]
      AS [ep]
    JOIN [Employees]
      AS [e]
      ON [e].[EmployeeID] = [ep].[EmployeeID]
    JOIN [Projects]
      AS [p]
      ON [p].[ProjectID] = [ep].[ProjectID]
   WHERE [e].[EmployeeID] IN (24)
ORDER BY [e].[EmployeeID]

GO


-- Problem 9
  SELECT [e].[EmployeeID],
         [e].[FirstName],
         [e].[ManagerID],
         [m].[FirstName]
      AS [ManagerName]
    FROM [Employees]
      AS [e]
    JOIN [Employees]
      AS [m]
      ON [e].[ManagerID] = [m].[EmployeeID] 
   WHERE [e].[ManagerID] IN (3, 7)
ORDER BY [e].[EmployeeID]

GO


-- Problem 10
SELECT TOP(50) [e].[EmployeeID],
               CONCAT_WS(' ', [e].[FirstName], [e].[LastName])
            AS [EmployeeName],
               CONCAT_WS(' ', [m].[FirstName], [m].[LastName])
            AS [ManagerName],
               [d].[Name]
            AS [DepartmentName]
          FROM [Employees]
            AS [e]
          JOIN [Employees]
            AS [m]
            ON [e].[ManagerID] = [m].[EmployeeID]
          JOIN [Departments]
            AS [d]
            ON [d].[DepartmentID] = [e].[DepartmentID]
      ORDER BY [e].[EmployeeID]

GO


-- Problem 11
SELECT MIN([AverageSalary])
    AS [MinAverageSalary]
  FROM (
          SELECT [DepartmentID],
             AVG (Salary)
              AS [AverageSalary]
            FROM [Employees]
        GROUP BY [DepartmentID]
       )
              AS [DepartmentAverages]

GO


-- Problem 12
USE [Geography]

GO

  SELECT [mc].[CountryCode],
         [m].[MountainRange],
         [p].[PeakName],
         [p].[Elevation]
    FROM [Mountains]
      AS [m]
    JOIN [Peaks]
      AS [p]
      ON [p].[MountainId] = [m].[Id]
    JOIN [MountainsCountries]
      AS [mc]
      ON [mc].[MountainId] = [m].[Id]
     AND [p].[Elevation] > 2835
     AND [mc].[CountryCode] = 'BG'
ORDER BY [p].[Elevation] DESC

GO


-- Problem 13
   SELECT [c].[CountryCode],
          COUNT([mc].[MountainId])
       AS [MountainRanges]
     FROM [Countries]
       AS [c]
LEFT JOIN [MountainsCountries]   
       AS [mc]
       ON [mc].[CountryCode] = [c].[CountryCode]
    WHERE [c].[CountryName] IN ('United States', 'Russia', 'Bulgaria')
 GROUP BY [c].[CountryCode]

GO


-- Problem 14
SELECT TOP(5) [c].[CountryName],
              [r].[RiverName]
         FROM [Countries]
           AS [c]
    LEFT JOIN [CountriesRivers]
           AS [cr]
           ON [cr].[CountryCode] = [c].[CountryCode]
    LEFT JOIN [Rivers]
           AS [r]
           ON [r].[Id] = [cr].[RiverId] 
         JOIN [Continents]
           AS [ct]
           ON [ct].[ContinentCode] = [c].[ContinentCode]
          AND [ct].[ContinentName] = ('Africa')
     ORDER BY [c].[CountryName]


GO


--Problem 15
  SELECT [ContinentCode],
         [CurrencyCode],
         [CurrencyUsage]
    FROM (
           SELECT *,
                  DENSE_RANK() OVER(PARTITION BY[ContinentCode] ORDER BY [CurrencyUsage] DESC)
               AS [CurrencyRank]
             FROM (
                      SELECT [ContinentCode],
                             [CurrencyCode],
                             COUNT([CountryCode])
                          AS [CurrencyUsage]
                        FROM [Countries]
                       WHERE [CurrencyCode] IS NOT NULL  
                    GROUP BY [ContinentCode],
                             [CurrencyCode]
                      HAVING COUNT([CountryCode]) > 1
                  )
               AS[CurrencyUsageTempQuery]
         )  
      AS [CurrencyRankingTempQuery]
   WHERE [CurrencyRank] = 1
ORDER BY [ContinentCode]


 GO


-- Problem 16 
   SELECT COUNT(*)
       AS [Count]
     FROM [Countries]
       AS [c]
LEFT JOIN [MountainsCountries]
       AS [mc]
       ON [mc].[CountryCode] = [c].[CountryCode]
    WHERE [mc].MountainId IS NULL

GO


-- Problem 17
   SELECT TOP (5) [c].[CountryName],
              MAX([p].[Elevation])
           AS [HighestPeakElevation],
              MAX([r].[Length])
           AS [LongestRiverLength]
         FROM [Countries]
           AS [c]
    LEFT JOIN [MountainsCountries]
           AS [mc]
           ON [mc].[CountryCode] = [c].[CountryCode]
    LEFT JOIN [Mountains]
           AS [m]
           ON [m].[Id] = [mc].[MountainId]
    LEFT JOIN [Peaks]
           AS [p]
           ON [p].[MountainId] = [mc].[MountainId]
    LEFT JOIN [CountriesRivers]
           AS [cr]
           ON [cr].[CountryCode] = [c].[CountryCode]
    LEFT JOIN [Rivers] 
           AS [r]
           ON [r].[Id] = [cr].[RiverId]
     GROUP BY [c].[CountryName]
     ORDER BY [HighestPeakElevation] DESC,
          [LongestRiverLength] DESC,
          [c].[CountryName]
    
          
GO


--  Problem 18
 SELECT TOP(5) [CountryName]
            AS [Country],
               ISNULL([PeakName], '(no highest peak)')
            AS [Highest Peak Name],
               ISNULL([Elevation], 0)
            AS [Highest Peak Elevation],
               ISNULL([MountainRange], '(no mountain)')
            AS [Mountain]
          FROM (
                   SELECT [c].[CountryName],
                          [p].[PeakName],
                          [p].[Elevation],
                          [m].[MountainRange],
                          DENSE_RANK() OVER(PARTITION BY [c].[CountryCode] ORDER BY [p].[Elevation] DESC)
                       AS [PeakRank]
                     FROM [Countries]
                       AS [c]
                LEFT JOIN [MountainsCountries]
                       AS [mc]
                       ON [mc].[CountryCode] = [c].[CountryCode] 
                LEFT JOIN [Mountains]
                       AS [m]
                       ON [mc].[MountainId] = [m].[Id]
                LEFT JOIN [Peaks]
                       AS [p]
                       ON [p].[MountainId] = [m].Id
               )
            AS [PeakRrankingTempQuery]
         WHERE [PeakRank] = 1
      ORDER BY [Country],
               [Highest Peak Name]

GO