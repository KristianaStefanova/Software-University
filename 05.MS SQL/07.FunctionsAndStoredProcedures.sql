USE [SoftUni]

GO


-- Problem 1
   CREATE  
PROCEDURE [usp_GetEmployeesSalaryAbove35000]
       AS (
			SELECT [FirstName]
				AS [First Name],
				   [LastName]
				AS [Last Name]
			  FROM [Employees]
			 WHERE [Salary] > 35000
		  )

GO


EXEC [dbo].[usp_GetEmployeesSalaryAbove35000]

GO


-- Problem 2
   CREATE 
PROCEDURE [usp_GetEmployeesSalaryAboveNumber] @minSalary DECIMAL(18, 4)
       AS 
	     (
		    SELECT [FirstName]
				AS [First Name],
				   [LastName]
				AS [Last Name]
			  FROM [Employees]
			 WHERE [Salary] >= @minSalary
		 )

GO

EXEC [dbo].[usp_GetEmployeesSalaryAboveNumber] 35000

GO


-- Problem 3
   CREATE
PROCEDURE [usp_GetTownsStartingWith] @startString NVARCHAR(50)
       AS
	     (
		   SELECT [Name]
             FROM [Towns]
            WHERE [Name] LIKE @startString + '%'
		 )

EXEC [dbo].[usp_GetTownsStartingWith] B

GO


-- Problem 4
   CREATE
PROCEDURE [usp_GetEmployeesFromTown] @townName VARCHAR(50)
       AS 
	      (
                SELECT [FirstName]
                    AS [First Name],
                	      [LastName]
                    AS [Last Name]
                  FROM [Employees]
                    AS [e]
             LEFT JOIN [Addresses]
                    AS [a]
             	   ON [e].[AddressID] = [a].[AddressID]
             LEFT JOIN [Towns]
                    AS [t]
             	   ON [a].[TownID] = [t].[TownID]
                 WHERE [t].[Name] = @townName OR 
				       ISNULL(@townName, '') = ISNULL([t].[Name], '')
	      )

GO

EXEC [dbo].[usp_GetEmployeesFromTown] 'Sofia'

GO


-- Problem 5
        CREATE 
      FUNCTION [ufn_GetSalaryLevel](@salary DECIMAL(18,4))
RETURNS VARCHAR (7)
            AS
         BEGIN 
                DECLARE @salaryLevel VARCHAR(7)
                SET @salaryLevel =
                       CASE
                            WHEN @salary < 30000 THEN 'Low'
                            WHEN @salary BETWEEN 30000 AND 50000 THEN 'Average'
                            WHEN @salary > 50000 THEN 'High'
                       END
                RETURN @salaryLevel
                
           END

GO

SELECT [Salary],
       [dbo].[ufn_GetSalaryLevel]([Salary])
    AS [Salary Level]
  FROM [Employees]
   

GO


-- Problem 6
CREATE 
PROCEDURE [usp_EmployeesBySalaryLevel] @SalaryLevel VARCHAR(7)
       AS 
          (
             SELECT [FirstName],
                    [LastName]
               FROM [Employees]
              WHERE [dbo].[ufn_GetSalaryLevel]([Salary]) = @SalaryLevel
          )
GO

EXEC [dbo].[usp_EmployeesBySalaryLevel] @SalaryLevel = 'High'

GO


-- Problem 7
      CREATE 
    FUNCTION [ufn_IsWordComprised](@setOfLetters VARCHAR(50), @word VARCHAR(50))
 RETURNS BIT
          AS
       BEGIN
                DECLARE @wordIndex TINYINT
                DECLARE @currentChar CHAR(1)

                    SET @wordIndex = 1
                  WHILE @wordIndex <= LEN(@word)
                  BEGIN
                          SET @currentChar = SUBSTRING(@word, @wordIndex, 1)
                           IF CHARINDEX(@currentChar, @setOfLetters) <= 0
                        BEGIN 
                              RETURN 0
                          END

                    SET @wordIndex += 1
                    END

                    RETURN 1
         END

GO

SELECT [dbo].[ufn_IsWordComprised]('oistmiahf', 'Sofia'),
       [dbo].[ufn_IsWordComprised]('oistmiahf', 'halves')

GO


-- Problem 8
   CREATE 
       OR
    ALTER
PROCEDURE [usp_DeleteEmployeesFromDepartment] @departmentId INT
       AS 
    BEGIN   
            DELETE
              FROM [EmployeesProjects]
             WHERE [EmployeeID] IN (
                                        SELECT [EmployeeID]
                                          FROM [Employees]
                                         WHERE [DepartmentID] = @departmentId
                                   )
                                     
            UPDATE [Employees]
               SET [ManagerID] = NULL
             WHERE [ManagerID] IN (
                                        SELECT [EmployeeID]
                                          FROM [Employees]
                                         WHERE [DepartmentID] = @departmentId
                                  )

             ALTER TABLE [Departments]
             ALTER COLUMN [ManagerId] INT

             UPDATE [Departments]
                SET [ManagerID] = NULL
              WHERE [ManagerID] IN (
                                        SELECT [EmployeeID]
                                          FROM [Employees]
                                         WHERE [DepartmentID] = @departmentId
                                   )

             DELETE 
               FROM [Employees]
              WHERE [DepartmentID] = @departmentId

             DELETE 
               FROM [Departments]
              WHERE [DepartmentID] = @departmentId

              SELECT COUNT(*)
                FROM [Employees]
               WHERE [DepartmentID] = @departmentId

      END                            
              
GO

EXEC [dbo].[usp_DeleteEmployeesFromDepartment] 1

GO


-- Problem 9
CREATE 
PROCEDURE [usp_GetHoldersFullName] 
       AS
    BEGIN
             SELECT CONCAT_WS(' ', [FirstName], [LastName])
                 AS [Full Name]
               FROM [AccountHolders]
      END

GO


-- Problem 10
   CREATE 
PROCEDURE [usp_GetHoldersWithBalanceHigherThan] @number DECIMAL(10, 2)
       AS
    BEGIN
             SELECT [ah].[FirstName],
                    [ah].[LastName]
               FROM [AccountHolders]
                 AS [ah]
          LEFT JOIN [Accounts]
                 AS [a]
                 ON [a].[AccountHolderId] = [ah].[Id]
           GROUP BY [ah].[Id], 
                    [ah].[FirstName],
                    [ah].[LastName]
             HAVING SUM([a].[Balance]) > @number
           ORDER BY [ah].[FirstName], 
                    [ah].[LastName]     
      END

GO

-- Problem 11
  CREATE 
FUNCTION [?ufn_CalculateFutureValue](@sum DECIMAL(18, 6), @yearlyInterestRate FLOAT, @numberOfYears INT)
 RETURNS DECIMAL(16,4)
      AS
   BEGIN
          RETURN ROUND(@sum * POWER(1 + @yearlyInterestRate, @numberOfYears), 4)
     END

GO

SELECT [dbo].[ufn_CalculateFutureValue](1000, 0.1, 5) AS FutureValue

GO


-- Problem 12
CREATE 
PROCEDURE [usp_CalculateFutureValueForAccount] @AccountId INT, @InterestRate FLOAT
       AS
    BEGIN
              SELECT [a].[Id] 
                  AS [Account Id],
                     [ah].[FirstName] 
                  AS [First Name],
                     [ah].[LastName] 
                  AS [Last Name],
                     [a].[Balance] 
                  AS [Current Balance],
                     [dbo].[ufn_CalculateFutureValue]([a].[Balance], @InterestRate, 5) 
                  AS [Balance in 5 years]
                FROM [Accounts]
                  AS [a]
          INNER JOIN [AccountHolders]
                  AS [ah]
                  ON [a].[AccountHolderId] = [ah].[Id]
               WHERE [a].[Id] = @AccountId
      END

GO

EXEC [usp_CalculateFutureValueForAccount] @AccountId = 1, @InterestRate = 0.1


GO


-- Problem 13
USE [Diablo]

GO

  CREATE
FUNCTION [ufn_CashInUsersGames](@gameName NVARCHAR(50))
RETURNS
  TABLE 
     AS 
        RETURN (
                 SELECT SUM([Cash])
                     AS [SumCash]
                   FROM (
                             SELECT [ug].[Cash],
                                    ROW_NUMBER() OVER(ORDER BY [ug].[Cash] DESC)
                                 AS [RowNum]
                               FROM [UsersGames]
                                 AS [ug]
                               JOIN [Games]
                                 AS [g]
                                 ON [ug].[GameId] = [g].[Id]
                              WHERE [g].[Name] = @gameName
                        )
                     AS [GameCashRowNumSubQuert]
                  WHERE [RowNum] % 2 = 1
        )

GO

SELECT * FROM [dbo].[ufn_CashInUsersGames]('Love in a mist')

GO


 