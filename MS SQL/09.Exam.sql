CREATE DATABASE [EuroLeagues]

GO

USE [EuroLeagues]


-- Problem 1
CREATE TABLE [Leagues] (
    [Id] INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE [Players] (
    [Id] INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(100) NOT NULL,
    [Position] NVARCHAR(20) NOT NULL
)

CREATE TABLE [Teams] (
    [Id] INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(50) NOT NULL UNIQUE,
    [City] NVARCHAR(50) NOT NULL,
    [LeagueId] INT NOT NULL FOREIGN KEY REFERENCES [Leagues]([Id])
)

CREATE TABLE [PlayerStats] (
    [PlayerId] INT PRIMARY KEY,
    [Goals] INT NOT NULL DEFAULT 0,
    [Assists] INT NOT NULL DEFAULT 0,
    FOREIGN KEY ([PlayerId]) REFERENCES [Players]([Id])
)

CREATE TABLE [TeamStats] (
    [TeamId] INT PRIMARY KEY,
    [Wins] INT NOT NULL DEFAULT 0,
    [Draws] INT NOT NULL DEFAULT 0,
    [Losses] INT NOT NULL DEFAULT 0,
    FOREIGN KEY ([TeamId]) REFERENCES [Teams]([Id])
)

CREATE TABLE [PlayersTeams] (
    [PlayerId] INT NOT NULL,
    [TeamId] INT NOT NULL,
    PRIMARY KEY ([PlayerId], [TeamId]),
    FOREIGN KEY ([PlayerId]) REFERENCES [Players]([Id]),
    FOREIGN KEY ([TeamId]) REFERENCES [Teams]([Id])
)

CREATE TABLE [Matches] (
    [Id] INT PRIMARY KEY IDENTITY,
    [HomeTeamId] INT NOT NULL,
    [AwayTeamId] INT NOT NULL,
    [MatchDate] DATETIME2 NOT NULL,
    [HomeTeamGoals] INT NOT NULL DEFAULT 0,
    [AwayTeamGoals] INT NOT NULL DEFAULT 0,
    [LeagueId] INT NOT NULL,
    FOREIGN KEY ([HomeTeamId]) REFERENCES [Teams]([Id]),
    FOREIGN KEY ([AwayTeamId]) REFERENCES [Teams]([Id]),
    FOREIGN KEY ([LeagueId]) REFERENCES [Leagues]([Id])
)


GO

-- Problem 2
INSERT INTO [Leagues] ([Name]) 
VALUES 
(N'Eredivisie')



INSERT INTO [Players] ([Name], [Position]) 
VALUES
(N'Luuk de Jong', N'Forward'),
(N'Josip Sutalo', N'Defender')


INSERT INTO [Teams] ([Name], [City], [LeagueId]) 
VALUES
(N'PSV', N'Eindhoven', 
                       (
                        SELECT TOP (1) [Id] 
                                  FROM [Leagues] 
                                 WHERE [Name] = N'Eredivisie')
                       ),
(N'Ajax', N'Amsterdam', 
                       (
                        SELECT TOP 1 [Id] 
                        FROM [Leagues] 
                        WHERE [Name] = N'Eredivisie')
                       )


INSERT INTO [PlayerStats] ([PlayerId], [Goals], [Assists]) 
VALUES
((SELECT TOP (1) [Id] 
            FROM [Players] 
           WHERE [Name] = N'Luuk de Jong'), 2, 0),
((SELECT TOP (1) [Id] 
            FROM [Players] 
           WHERE [Name] = N'Josip Sutalo'), 2, 0)


INSERT INTO [TeamStats] ([TeamId], [Wins], [Draws], [Losses]) 
VALUES
((SELECT TOP (1) [Id] 
            FROM [Teams] 
           WHERE [Name] = N'PSV'), 15, 1, 3),
((SELECT TOP (1) [Id] 
            FROM [Teams] 
           WHERE [Name] = N'Ajax'), 14, 3, 2)


INSERT INTO [PlayersTeams] ([PlayerId], [TeamId])
VALUES
((SELECT TOP (1) [Id]
            FROM [Players] 
           WHERE [Name] = N'Luuk de Jong'), 
 (SELECT TOP (1) [Id]  
            FROM [Teams] 
           WHERE [Name] = N'PSV')),
((SELECT TOP (1) [Id] 
            FROM [Players] 
           WHERE [Name] = N'Josip Sutalo'), 
 (SELECT TOP (1) [Id] 
            FROM [Teams] 
           WHERE [Name] = N'Ajax'))


INSERT INTO [Matches] ([HomeTeamId], [AwayTeamId], [MatchDate], [HomeTeamGoals], [AwayTeamGoals], [LeagueId]) 
VALUES
((SELECT TOP (1) [Id] 
            FROM [Teams] 
           WHERE [Name] = N'Ajax'), 
 (SELECT TOP (1) [Id] 
            FROM [Teams] 
           WHERE [Name] = N'PSV'), 
 '2024-11-02 20:45:00', 3, 2, 
 (SELECT TOP (1) [Id] 
            FROM [Leagues] 
           WHERE [Name] = N'Eredivisie'))


GO


-- Problem 3
UPDATE [PlayerStats]
   SET [Goals] += 1
  FROM [PlayerStats] 
    AS [ps]
  JOIN [Players] 
    AS [p]
    ON [ps].[PlayerId] = [p].[Id]
  JOIN [PlayersTeams] 
    AS [pt] 
    ON [p].[Id] = [pt].[PlayerId]
  JOIN [Teams] 
    AS [t]
    ON [pt].[TeamId] = [t].[Id]
  JOIN [Leagues] 
    AS [l] 
    ON [t].[LeagueId] = [l].[Id]
 WHERE [p].[Position] = N'Forward'
   AND [l].[Name] = N'La Liga'

GO


-- Problem 4
DELETE FROM [Matches]
      WHERE [LeagueId] IN (
                            SELECT [Id] 
                              FROM [Leagues] 
                             WHERE [Name] = N'Eredivisie'
                           )


DELETE FROM [PlayersTeams]
      WHERE [PlayerId] IN (
                            SELECT [p].[Id] 
                              FROM [Players] 
                                AS [p]
                              JOIN [PlayersTeams] 
                                AS [pt]
                                ON [p].[Id] = [pt].[PlayerId]
                              JOIN [Teams] 
                                AS [t]
                                ON [pt].[TeamId] = [t].[Id]
                              JOIN [Leagues] 
                                AS [l]
                                ON [t].[LeagueId] = [l].[Id]
                             WHERE [p].[Name] IN (N'Luuk de Jong', N'Josip Sutalo')
                               AND [l].[Name] = N'Eredivisie'
)


DELETE FROM [PlayerStats]
      WHERE [PlayerId] IN (
                            SELECT [p].[Id] 
                              FROM [Players] 
                                AS [p]
                              JOIN [PlayersTeams] 
                                AS [pt]
                                ON [p].[Id] = [pt].[PlayerId]
                              JOIN [Teams] 
                                AS [t]
                                ON [pt].[TeamId] = [t].[Id]
                              JOIN [Leagues] 
                                AS [l]
                                ON [t].[LeagueId] = [l].[Id]
                             WHERE [p].[Name] IN (N'Luuk de Jong', N'Josip Sutalo')
                               AND [l].[Name] = N'Eredivisie'
                           )


DELETE FROM [Players]
      WHERE [Id] IN (
                        SELECT [p].[Id] 
                          FROM [Players] 
                            AS [p]
                          JOIN [PlayersTeams] 
                            AS [pt]
                            ON [p].[Id] = [pt].[PlayerId]
                          JOIN [Teams] 
                            AS [t]
                            ON [pt].[TeamId] = [t].[Id]
                          JOIN [Leagues] 
                            AS [l]
                            ON [t].[LeagueId] = [l].[Id]
                         WHERE [p].[Name] IN (N'Luuk de Jong', N'Josip Sutalo')
                           AND [l].[Name] = N'Eredivisie'
)

GO


-- Problem 5
  SELECT FORMAT([MatchDate], 'yyyy-MM-dd') 
      AS [MatchDate],
         [HomeTeamGoals],
         [AwayTeamGoals],
         [HomeTeamGoals] + [AwayTeamGoals]
      AS [TotalGoals]
    FROM [Matches]
   WHERE [HomeTeamGoals] + [AwayTeamGoals] >= 5
ORDER BY [TotalGoals] DESC,
         [MatchDate]


GO


-- Problem 6
  SELECT [p].[Name],
         [t].[City]
    FROM [Players] 
      AS [p]
    JOIN [PlayersTeams] 
      AS [pt]
      ON [p].[Id] = [pt].[PlayerId]
    JOIN [Teams] 
      AS [t] 
      ON [pt].[TeamId] = [t].[Id]
   WHERE [p].[Name] LIKE '%Aaron%'
ORDER BY [p].[Name]

GO


-- Problem 7
  SELECT [p].[Id],
         [p].[Name],
         [p].[Position]
    FROM [Players]
      AS [p]
    JOIN [PlayersTeams]
      AS [pt]
      ON [pt].[PlayerId] = [p].[Id]
    JOIN [Teams]
      AS [t]
      ON [t].[Id] = [pt].[TeamId]
   WHERE [t].[City] = 'London'
ORDER BY [p].[Name]


GO


-- Problem 8
SELECT TOP(10) [ht].[Name] 
            AS [HomeTeamName],
               [at].[Name]
            AS [AwayTeamName],
               [l].[Name] 
            AS [LeagueName],
               FORMAT([m].[MatchDate], 'yyyy-MM-dd')
            AS [MatchDate]
          FROM [Matches] 
            AS [m]
          JOIN [Teams] 
            AS [ht]
            ON [m].[HomeTeamId] = [ht].[Id]
          JOIN [Teams] 
            AS [at]
            ON [m].[AwayTeamId] = [at].[Id]
          JOIN [Leagues] 
            AS [l]
            ON [m].[LeagueId] = [l].[Id]
         WHERE [m].[MatchDate] >= '2024-09-01'
           AND [m].[MatchDate] <= '2024-09-15'
           AND [l].[Id] % 2 = 0
      ORDER BY [m].[MatchDate],
               [ht].[Name]

GO


-- Problem 9
  SELECT [t].[Id],
         [t].[Name],
         SUM(m.[AwayTeamGoals])
      AS [TotalAwayGoals]
    FROM [Teams] 
      AS [t]
    JOIN [Matches] 
      AS [m]
      ON [t].[Id] = [m].[AwayTeamId]
GROUP BY [t].[Id], 
         [t].[Name]
  HAVING SUM(m.[AwayTeamGoals]) >= 6
ORDER BY [TotalAwayGoals] DESC,
         [t].[Name] 


-- Problem 10
  SELECT [l].[Name] 
      AS [LeagueName],
         ROUND(AVG(CAST([m].[HomeTeamGoals] + [m].[AwayTeamGoals] AS FLOAT)), 2) 
      AS [AvgScoringRate]
    FROM [Matches] 
      AS [m]
    JOIN [Leagues] 
      AS [l]
      ON [m].[LeagueId] = [l].[Id]
GROUP BY [l].[Name]
ORDER BY [AvgScoringRate] DESC

GO


-- Problem 11
CREATE FUNCTION [udf_LeagueTopScorer](@LeagueName NVARCHAR(50))
  RETURNS TABLE
             AS
         RETURN
               (
                 SELECT [p].[Name] 
                     AS [PlayerName],
                        [ps].[Goals] 
                     AS [TotalGoals]
                   FROM [Players] 
                     AS [p]
                   JOIN [PlayerStats] 
                     AS [ps]
                     ON [p].[Id] = [ps].[PlayerId]
                   JOIN [PlayersTeams] 
                     AS [pt]
                     ON [p].[Id] = [pt].[PlayerId]
                   JOIN [Teams] 
                     AS [t]
                     ON [pt].[TeamId] = [t].[Id]
                   JOIN [Leagues] 
                     AS [l]
                     ON [t].[LeagueId] = [l].[Id]
                  WHERE [l].[Name] = @LeagueName
                    AND [ps].[Goals] = (
                                         SELECT MAX([ps2].[Goals])
                                           FROM [Players] 
                                             AS [p2]
                                           JOIN [PlayerStats] 
                                             AS [ps2]
                                             ON [p2].[Id] = [ps2].[PlayerId]
                                           JOIN [PlayersTeams]
                                             AS [pt2]
                                             ON [p2].[Id] = [pt2].[PlayerId]
                                           JOIN [Teams] 
                                             AS [t2]
                                             ON [pt2].[TeamId] = [t2].[Id]
                                           JOIN [Leagues]
                                             AS [l2]
                                             ON [t2].[LeagueId] = [l2].[Id]
                                          WHERE [l2].[Name] = @LeagueName
                                     )
               )


GO


-- Problem 12
CREATE PROCEDURE [usp_UpdatePlayerStats] @PlayerId INT, @GoalsDelta INT = NULL, @AssistsDelta INT = NULL
AS
BEGIN
         UPDATE [ps]
            SET 
                [ps].[Goals] = CASE 
                                    WHEN @GoalsDelta IS NOT NULL THEN [ps].[Goals] + @GoalsDelta 
                               ELSE [ps].[Goals] 
                                END,
         
                [ps].[Assists] = CASE 
                                      WHEN @AssistsDelta IS NOT NULL THEN [ps].[Assists] + @AssistsDelta 
                                 ELSE [ps].[Assists] 
                                  END
           FROM [PlayerStats] 
             AS [ps]
          WHERE [ps].PlayerId = @PlayerId
  
  END


EXEC [usp_UpdatePlayerStats] 51, 2
 
GO



