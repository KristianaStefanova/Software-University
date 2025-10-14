USE [Diablo]

GO

-- Problem	1
  SELECT SUBSTRING([Email], CHARINDEX('@', [Email]) + 1, LEN([Email]))
      AS [Email Provider],
         COUNT(*)
      AS [Number of Users]
    FROM [Users]
GROUP BY SUBSTRING([Email], CHARINDEX('@', [Email]) + 1, LEN([Email]))
ORDER BY [Number of Users] DESC,
         [Email Provider]

GO


-- Problem 2
  SELECT [g].[Name]
      AS [Game],
         [gt].[Name]
      AS [Game Type],
         [u].[Username],
         [ug].[Level],
         [ug].[Cash],
         [c].[Name]
      AS [Character] 
    FROM [Games]
      AS [g]
    JOIN [GameTypes]
      AS [gt]
      ON [gt].[Id] = [g].[GameTypeId]
    JOIN [UsersGames]
      AS [ug]
      ON [ug].[GameId] = [g].[Id]
    JOIN [Characters]
      AS [c]
      ON [c].[Id] = [ug].[CharacterId]
    JOIN [Users]
      AS [u]
      ON [u].[Id] = [ug].[UserId]
ORDER BY [ug].[Level] DESC,
         [u].[Username],
         [g].[Name]

GO


-- Problem 3
  SELECT [u].[Username],
         [g].[Name]
      AS [Game],
         COUNT([i].[Id])
      AS [Items Count],
         SUM([i].[Price])
      AS [Items Price]
    FROM [Users]
      AS [u]
    JOIN [UsersGames]
      AS [ug]
      ON [ug].[UserId] = [u].[Id]
    JOIN [Games]
      AS [g]
      ON [g].[Id] = [ug].[GameId]
    JOIN [UserGameItems]
      AS [ugi]
      ON [ugi].[UserGameId] = [ug].[Id]
    JOIN [Items]
      AS [i]
      ON [i].[Id] = [ugi].[ItemId]
GROUP BY [u].[Username],
         [g].[Name]
  HAVING COUNT([i].[Id]) >= 10
ORDER BY [Items Count] DESC,
         [Items Price] DESC,
         [u].[Username]

GO


-- Problem 4
  SELECT [u].[Username],
         [g].[Name] 
      AS [Game],
  	     MAX([c].[Name])
      AS [Character],
  	     (SUM([is].[Strength]) + MAX([gs].[Strength]) + MAX([s].[Strength]))
      AS [Strenght],
  	     (SUM([is].[Defence]) + MAX([gs].[Defence]) + MAX([s].[Defence]))
      AS [Defence],
  	     (SUM([is].[Speed]) + MAX([gs].[Speed]) + MAX([s].[Speed]))
      AS [Speed],
  	     (SUM([is].[Mind]) + MAX([gs].[Mind]) + MAX([s].[Mind])) 
      AS [Mind],
  	     (SUM([is].[Luck]) + MAX([gs].[Luck]) + MAX([s].[Luck])) 
      AS [Luck]
    FROM [Users]
      AS [u] 
    JOIN UsersGames
      AS [ug]
      ON [ug].[UserId] = [u].[Id]
    JOIN [Games] 
      AS [g]
      ON [ug].[GameId] = [g].[Id]
    JOIN [GameTypes]
      AS [gt]
      ON [gt].[Id] = [g].[GameTypeId]
    JOIN [Statistics] 
      AS [gs]
      ON [gt].[BonusStatsId] = [gs].[Id]
    JOIN [Characters]
      AS [c]
      ON [ug].[CharacterId] = [c].[Id]
    JOIN [Statistics] 
      AS [s]
      ON [c].[StatisticId] = [s].[Id]
    JOIN [UserGameItems]
      AS [ugi]
      ON [ugi].[UserGameId] = [ug].[Id]
    JOIN [Items]
      AS [i]
      ON [ugi].[ItemId] = [i].[Id]
    JOIN [Statistics]
      AS [is]
      ON [i].[StatisticId] = [is].[Id]
GROUP BY [u].[Username],
         [g].[Name]
ORDER BY 4 DESC,
         5 DESC, 
         6 DESC, 
         7 DESC, 
         8 DESC

GO


-- Problem 5
  SELECT [i].[Name],
         [i].[Price],
         [i].[MinLevel],
         [s].[Strength],
         [s].[Defence],
         [s].[Speed],
         [s].[Luck],
         [s].[Mind]
    FROM [Items]
      AS [i]
    JOIN [Statistics]
      AS [s]
      ON [s].[Id] = [i].[StatisticId]
   WHERE [s].[Speed] > 
                       (
                            SELECT AVG([s2].[Speed])
                              FROM [Statistics]
                                AS [s2]
                       )
     AND [s].[Luck] >  
                       (
                            SELECT AVG([s3].[Luck])
                              FROM [Statistics]
                                AS [s3]
                       )
     AND [s].[Mind] >  
                       (
                            SELECT AVG([s4].[Mind])
                              FROM [Statistics]
                                AS [s4]
                       )
ORDER BY [i].[Name]

GO


-- Problem 6
   SELECT [i].[Name]
       AS [Item],
          [i].[Price],
          [i].[MinLevel],
          [gt].[Name]
       AS [Forbidden Game Type]
     FROM [Items]
       AS [i]
LEFT JOIN [GameTypeForbiddenItems]
       AS [gtfi]
       ON [gtfi].[ItemId] = [i].[Id]
LEFT JOIN [GameTypes]
       AS [gt]
       ON [gt].[Id] = [gtfi].[GameTypeId]
 ORDER BY [gt].[Name] DESC,
          [i].[Name]

GO


-- Problem 7
DECLARE @itemPrice MONEY = 
                            (
                              SELECT SUM([Price])
                                FROM [Items]
                               WHERE [Name] IN ('Blackguard',
                                                 'Bottomless Potion of Amplification', 
                                                 'Eye of Etlich (Diablo III)', 
                                                 'Gem of Efficacious Toxin', 
                                                 'Golden Gorget of Leoric', 
                                                 'Hellfire Amulet'
                                                )
                            )

DECLARE @userId INT = (
                        SELECT TOP (1) [Id]
                                  FROM [Users]
                                 WHERE [Username] = 'Alex'
                      )

DECLARE @gameId INT = (
                        SELECT TOP 1 [Id]
                        FROM [Games]
                        WHERE [Name] = 'Edinburgh'
                      )

DECLARE @userGameId INT = (
                            SELECT TOP (1) [Id]
                                      FROM [UsersGames]
                                     WHERE [UserId] = @userId
                                       AND [GameId] = @gameId
                          )


UPDATE [UsersGames]
   SET [Cash] = [Cash] - @itemPrice
 WHERE [UserId] = @userId
   AND [GameId] = @gameId

INSERT INTO [UserGameItems] ([ItemId], [UserGameId])
     SELECT [Id], @userGameId
       FROM [Items]
      WHERE [Name] IN ('Blackguard',
                       'Bottomless Potion of Amplification', 
                       'Eye of Etlich (Diablo III)', 
                       'Gem of Efficacious Toxin', 
                       'Golden Gorget of Leoric', 
                       'Hellfire Amulet'
                      )


GO


   SELECT [u].[Username], 
          [g].[Name] 
       AS [Game], 
          [ug].[Cash], 
          [i].[Name]
       AS [Item Name]
     FROM [UsersGames] 
       AS [ug]
LEFT JOIN [Users] 
       AS [u]
       ON [ug].[UserId] = [u].[Id]
LEFT JOIN [Games] 
       AS [g]
       ON [ug].[GameId] = g.[Id]
LEFT JOIN [UserGameItems] 
          [ugi] 
       ON [ugi].[UserGameId] = [ug].[Id]
LEFT JOIN [Items] 
       AS [i] 
       ON [ugi].[ItemId] = i.[Id]
    WHERE [ug].[GameId] = @gameId
 ORDER BY [i].[Name]


GO

USE [Geography]

GO

-- Problem 8
SELECT [p].[PeakName],
       [m].[MountainRange]
    AS [Mountain],
       [p].[Elevation]
  FROM [Peaks]
    AS [p]
  JOIN [Mountains]
    AS [m]
    ON [m].[Id] = [p].[MountainId]
ORDER BY [p].[Elevation] DESC,
         [p].[PeakName]


GO


-- Problem 9
  SELECT [p].[PeakName],
         [m].[MountainRange]
      AS [Mountain],
         [c].[CountryName],
         [ct].ContinentName
    FROM [Peaks]
      AS [p]
   JOIN [Mountains]
      AS [m]
      ON [m].[Id] = [p].[MountainId]
    JOIN [MountainsCountries]
      AS [mc]
      ON [mc].[MountainId] = [m].[Id]
    JOIN [Countries]
      AS [c]
      ON [c].[CountryCode] = [mc].[CountryCode]
    JOIN [Continents]
      AS [ct]
      ON [ct].[ContinentCode]  = [c].[ContinentCode]
ORDER BY [p].[PeakName],
         [c].[CountryName]

GO


-- Problem 10
   SELECT [c].[CountryName],
          [ct].[ContinentName],
          COUNT([r].[Id])
       AS [RiversCount],
          ISNULL(SUM([r].Length), 0)
       AS [TotalLength]
     FROM [Countries]
       AS [c]
     JOIN [Continents]
       AS [ct]
       ON [ct].[ContinentCode] = [c].[ContinentCode]
LEFT JOIN [CountriesRivers]
       AS [cr]
       ON [cr].[CountryCode] = [c].[CountryCode]
LEFT JOIN [Rivers]
       AS [r]
       ON [r].[Id] = [cr].[RiverId]
 GROUP BY [c].[CountryName],  
          [ct].[ContinentName]
 ORDER BY [RiversCount] DESC,
          [TotalLength] DESC,
          [c].[CountryName]


GO


-- Problrm 11
   SELECT [cr].[CurrencyCode],
          [cr].[Description],
          COUNT([c].[ContinentCode])
       AS [NumberOfCountries]
     FROM [Currencies]
       AS [cr]
LEFT JOIN [Countries]
       AS [c] 
       ON [c].[CurrencyCode] = [cr].[CurrencyCode]
 GROUP BY [cr].[CurrencyCode],
          [cr].[Description]
 ORDER BY [NumberOfCountries] DESC,
          [cr].[Description]

GO


-- Problem 12
  SELECT [ct].[ContinentName],
         SUM(CAST([c].[AreaInSqKm] AS BIGINT))
      AS [CountriesArea],
         SUM(CAST([c].[Population] AS BIGINT))
      AS [CountriesPopulation]
    FROM [Continents]
      AS [ct]
    JOIN [Countries]
      AS [c]
      ON [c].[ContinentCode] = [ct].[ContinentCode]
GROUP BY [ct].[ContinentName]
ORDER BY [CountriesPopulation] DESC

GO


-- Problem 13
CREATE TABLE [Monasteries] (
 [Id] INT PRIMARY KEY IDENTITY,
 [Name] NVARCHAR(100) NOT NULL,
 [CountryCode] CHAR(2) NOT NULL FOREIGN KEY REFERENCES [Countries]([CountryCode])
 )

INSERT INTO Monasteries(Name, CountryCode) VALUES 
('Rila Monastery “St. Ivan of Rila”', 'BG'),  
('Bachkovo Monastery “Virgin Mary”', 'BG'), 
('Troyan Monastery “Holy Mother''s Assumption”', 'BG'), 
('Kopan Monastery', 'NP'), 
('Thrangu Tashi Yangtse Monastery', 'NP'), 
('Shechen Tennyi Dargyeling Monastery', 'NP'), 
('Benchen Monastery', 'NP'), 
('Southern Shaolin Monastery', 'CN'), 
('Dabei Monastery', 'CN'), 
('Wa Sau Toi', 'CN'), 
('Lhunshigyia Monastery', 'CN'), 
('Rakya Monastery', 'CN'), 
('Monasteries of Meteora', 'GR'), 
('The Holy Monastery of Stavronikita', 'GR'), 
('Taung Kalat Monastery', 'MM'), 
('Pa-Auk Forest Monastery', 'MM'), 
('Taktsang Palphug Monastery', 'BT'), 
('Sümela Monastery', 'TR')

ALTER TABLE [Countries]
ADD [IsDeleted] BIT NOT NULL DEFAULT 0

UPDATE [c]
   SET [c].[IsDeleted] = 1
  FROM Countries 
    AS [c]
 WHERE (
          SELECT COUNT([cr].[RiverId])
            FROM [CountriesRivers]
              AS [cr]
           WHERE [cr].[CountryCode] = [c].[CountryCode]
       ) > 3

  SELECT [m].[Name] 
      AS [Monastery],
         [c].[CountryName]
      AS [Country]
    FROM [Monasteries]
      AS [m]
    JOIN [Countries]
      AS [c]
      ON [m].[CountryCode] = [c].[CountryCode]
   WHERE [c].[IsDeleted] = 0
ORDER BY [m].[Name]


GO


-- Problem 14
UPDATE [Countries]
   SET [CountryName] = 'Burma'
 WHERE [CountryName] = 'Myanmar'

INSERT INTO Monasteries ([Name], [CountryCode])
VALUES ('Hanga Abbey', 
                        (
                            SELECT [c].[CountryCode]
                              FROM [Countries]
                                AS [c]
                             WHERE [c].[CountryName] = 'Tanzania')
                        ),
       ('Myin-Tin-Daik', 
                        (  
                            SELECT [c].[CountryCode]
                              FROM [Countries]
                                   [c]
                             WHERE [c].[CountryName] = 'Myanmar')
                        )

   SELECT [ct].[ContinentName],
          [c].[CountryName],
          COUNT([m].[Id]) 
       AS [MonasteriesCount]
     FROM Countries 
       AS [c]
     JOIN [Continents]
       AS [ct]
       ON [ct].[ContinentCode] = [c].[ContinentCode]
LEFT JOIN [Monasteries]
          [m]
       ON [m].CountryCode = c.CountryCode
    WHERE [c].IsDeleted = 0
 GROUP BY [ct].[ContinentName],
          [c].[CountryName]
 ORDER BY [MonasteriesCount] DESC,
          [c].[CountryName]


 
   