USE [Gringotts]

GO


-- Probelem 1
SELECT COUNT(*)
    AS [Count]
  FROM [WizzardDeposits]

GO


-- Problem 2
SELECT MAX([MagicWandSize])
    AS [LongestMagicWand]
  FROM [WizzardDeposits]

GO


-- Problem 3
  SELECT [DepositGroup],
         MAX([MagicWandSize])
      AS [LongestMagicWand]
    FROM [WizzardDeposits]
GROUP BY [DepositGroup]

GO


-- Problem 4
SELECT TOP (2) [DepositGroup]
      FROM [WizzardDeposits] 
  GROUP BY [DepositGroup]
  ORDER BY AVG([MagicWandSize])

GO


-- Problem 5
  SELECT [DepositGroup],
         SUM([DepositAmount])
      AS [TotalSum]
    FROM [WizzardDeposits]
GROUP BY [DepositGroup]

GO


-- Problem 6
  SELECT [DepositGroup],
         SUM([DepositAmount])
      AS [TotalSum]
    FROM [WizzardDeposits]
   WHERE [MagicWandCreator] = 'Ollivander family'
GROUP BY [DepositGroup]

GO


-- Problem 7
  SELECT [DepositGroup],
         SUM([DepositAmount])
      AS [TotalSum]
    FROM [WizzardDeposits]
   WHERE [MagicWandCreator] = 'Ollivander family'
GROUP BY [DepositGroup]
  HAVING SUM([DepositAmount]) < 150000
ORDER BY [TotalSum] DESC

GO


-- Problem 8
  SELECT [DepositGroup],
         [MagicWandCreator],
         MIN([DepositCharge])
      AS [MinDepositCharge]
    FROM [WizzardDeposits]
GROUP BY [DepositGroup],
         [MagicWandCreator]
ORDER BY [MagicWandCreator],
         [DepositGroup]

GO


-- Problem 9
  SELECT [AgeGroup],
         COUNT(*)
      AS [WizzardCount]
    FROM (    
          SELECT [Age],
                 CASE
                     WHEN [Age] BETWEEN 0 AND 10 THEN '[0-10]'
                     WHEN [Age] BETWEEN 11 AND 20 THEN '[11-20]'
                     WHEN [Age] BETWEEN 21 AND 30 THEN '[21-30]' 
                     WHEN [Age] BETWEEN 31 AND 40 THEN '[31-40]'
                     WHEN [Age] BETWEEN 41 AND 50 THEN '[41-50]'
                     WHEN [Age] BETWEEN 51 AND 60 THEN '[51-60]'
                     WHEN [Age] >= 61 THEN '[61+]'
                     ELSE NULL
                 END
              AS [AgeGroup]
            FROM [WizzardDeposits]
         )
      AS [AgeGroupingTempQuery]
GROUP BY [AgeGroup]

GO


-- Problem 10
  SELECT LEFT([FirstName], 1)
      AS [FirstLetter]
    FROM [WizzardDeposits]
   WHERE [DepositGroup] = 'Troll Chest'
GROUP BY LEFT([FirstName], 1)
ORDER BY [FirstLetter]

GO


-- Problem 11
  SELECT [DepositGroup],
         [IsDepositExpired],
         AVG([DepositInterest])
      AS [AverageInterest] 
    FROM [WizzardDeposits]
   WHERE [DepositStartDate] > '1985-01-01'
GROUP BY [DepositGroup],
         [IsDepositExpired]
ORDER BY [DepositGroup] DESC,
         [IsDepositExpired]

GO


-- Problem 12
   SELECT SUM([w1].[DepositAmount] - [w2].[DepositAmount]) 
       AS [SumDifference]
     FROM [WizzardDeposits] 
       AS [w1]
LEFT JOIN [WizzardDeposits]
       AS [w2] 
       ON [w1].[Id] = [w2].[Id] - 1

GO


-- Problem 13
USE [SoftUni]

GO


  SELECT [DepartmentID],
         SUM([Salary])
      AS [TotalSalary]
    FROM [Employees]
GROUP BY [DepartmentID]
ORDER BY [DepartmentID]

GO


-- Problem 14
  SELECT [DepartmentID],
         MIN([Salary])
      AS [MinimumSalary]
    FROM [Employees]
   WHERE [HireDate] > '2000-01-01'
GROUP BY [DepartmentID]
  HAVING [DepartmentID] IN (2, 5, 7)
ORDER BY [DepartmentID]

GO


-- Problem 15
SELECT * 
  INTO [EmpSalaryAbove30000]
  FROM [Employees]
 WHERE [Salary] > 30000

DELETE FROM [EmpSalaryAbove30000]
      WHERE [ManagerId] = 42

UPDATE [EmpSalaryAbove30000]
   SET [Salary] += 5000
 WHERE [DepartmentId] = 1

  SELECT [DepartmentID],
         AVG([Salary])
      AS [AverageSalary]
    FROM [EmpSalaryAbove30000]
GROUP BY [DepartmentID]

GO


-- Problem 16
   SELECT [DepartmentID],
          MAX([Salary])
       AS [MaxSalary]
     FROM [Employees]
 GROUP BY [DepartmentID]
  HAVING MAX([Salary]) NOT BETWEEN 30000 AND 70000

GO


-- Problem 17
SELECT COUNT(*)
    AS [Count]
  FROM [Employees]
 WHERE [ManagerID] IS NULL


  SELECT COUNT(*)
      AS [Count]
    FROM [Employees]
GROUP BY [ManagerID]
  HAVING [ManagerID] IS NULL


GO


-- Problem 18
  SELECT [DepartmentID],
         MAX([Salary]) 
      AS [ThirdHighestSalary]
    FROM
           (
                 SELECT [DepartmentID],
                        [Salary], 
                        DENSE_RANK() OVER (PARTITION BY [DepartmentID] ORDER BY [Salary] DESC )
                     AS [ThirdHighestSalary]
                   FROM Employees
           )
      AS [sal]
   WHERE ThirdHighestSalary = 3
GROUP BY [DepartmentID]

GO


-- Problem 19
SELECT TOP(10) [FirstName],
               [LastName],
               [e].[DepartmentID]
          FROM Employees
            AS [e]
          JOIN
                       (
                             SELECT [DepartmentID],
                                    AVG([Salary]) 
                                 AS [Average]
                               FROM Employees
                           GROUP BY DepartmentID
                       ) 
             AS [ea]
             ON [e].[DepartmentID] = [ea].[DepartmentID]
          WHERE [Salary] > [Average]

GO


 



         

