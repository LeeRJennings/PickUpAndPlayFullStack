USE [master]

IF db_id('PickUpAndPlay') IS NULL
  CREATE DATABASE [PickUpAndPlay]
GO

USE [PickUpAndPlay]
GO

DROP TABLE IF EXISTS [Comment];
DROP TABLE IF EXISTS [Stat];
DROP TABLE IF EXISTS [Like];
DROP TABLE IF EXISTS [Game];
DROP TABLE IF EXISTS [Area];
DROP TABLE IF EXISTS [SkillLevel];
DROP TABLE IF EXISTS [UserProfile];
GO

CREATE TABLE [UserProfile] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [FireBaseUserId] nvarchar(28) NOT NULL,
  [FirstName] nvarchar(255) NOT NULL,
  [LastName] nvarchar(255) NOT NULL,
  [Email] nvarchar(255) NOT NULL,
  [IsAdmin] bit NOT NULL,
  [IsActive] bit NOT NULL
)
GO

CREATE TABLE [Area] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [SkillLevel] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [Game] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [UserProfileId] int NOT NULL,
  [Title] nvarchar(255) NOT NULL,
  [ParkName] nvarchar(255) NOT NULL,
  [Address] nvarchar(255) NOT NULL,
  [Date] datetime NOT NULL,
  [Time] datetime NOT NULL,
  [AreaId] int NOT NULL,
  [SkillLevelId] int NOT NULL,
  [CreatedDateTime] datetime NOT NULL,
  [CleatsRequired] bit NOT NULL,
  [WhiteAndDarkShirt] bit NOT NULL,
  [BarefootFriendly] bit NOT NULL,
  [DogsAllowed] bit NOT NULL,
  [PlaygroundNearby] bit NOT NULL,
  [BathroomsNearby] bit NOT NULL,
  [DrinkingWaterNearby] bit NOT NULL,
  [AllAges] bit NOT NULL,
  [EighteenPlus] bit NOT NULL
)
GO

CREATE TABLE [Like] (
  [UserProfileId] int NOT NULL,
  [GameId] int NOT NULL
  PRIMARY KEY (UserProfileId, GameId)
)
GO

CREATE TABLE [Stat] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [UserProfileId] int NOT NULL,
  [GameId] int NOT NULL,
  [Goals] int NOT NULL,
  [Assists] int NOT NULL,
  [Blocks] int NOT NULL,
  [Turnovers] int NOT NULL
)
GO

CREATE TABLE [Comment] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [GameId] int NOT NULL,
  [UserProfileId] int NOT NULL,
  [Content] nvarchar(255) NOT NULL,
  [CreatedDateTime] datetime NOT NULL
)
GO

ALTER TABLE [Game] ADD FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([Id])
GO

ALTER TABLE [Comment] ADD FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([Id])
GO

ALTER TABLE [Stat] ADD FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([Id]) ON DELETE CASCADE
GO

ALTER TABLE [Like] ADD FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([Id]) ON DELETE CASCADE
GO

ALTER TABLE [Game] ADD FOREIGN KEY ([AreaId]) REFERENCES [Area] ([Id])
GO

ALTER TABLE [Game] ADD FOREIGN KEY ([SkillLevelId]) REFERENCES [SkillLevel] ([Id])
GO

ALTER TABLE [Comment] ADD FOREIGN KEY ([GameId]) REFERENCES [Game] ([Id]) ON DELETE CASCADE
GO

ALTER TABLE [Stat] ADD FOREIGN KEY ([GameId]) REFERENCES [Game] ([Id]) ON DELETE CASCADE
GO

ALTER TABLE [Like] ADD FOREIGN KEY ([GameId]) REFERENCES [Game] ([Id]) ON DELETE CASCADE
GO
