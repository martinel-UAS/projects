
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/07/2014 19:42:34
-- Generated from EDMX file: C:\Users\Luis\Documents\Visual Studio 2013\Projects\CampoyTournament\DataBaseDiagram\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CampoyTournament];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Hole_Field]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Hole] DROP CONSTRAINT [FK_Hole_Field];
GO
IF OBJECT_ID(N'[dbo].[FK_Match_Field]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Match] DROP CONSTRAINT [FK_Match_Field];
GO
IF OBJECT_ID(N'[dbo].[FK_Match_Tournament]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Match] DROP CONSTRAINT [FK_Match_Tournament];
GO
IF OBJECT_ID(N'[dbo].[FK_Result_Hole]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Result] DROP CONSTRAINT [FK_Result_Hole];
GO
IF OBJECT_ID(N'[dbo].[FK_Result_Match]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Result] DROP CONSTRAINT [FK_Result_Match];
GO
IF OBJECT_ID(N'[dbo].[FK_Result_Player]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Result] DROP CONSTRAINT [FK_Result_Player];
GO
IF OBJECT_ID(N'[dbo].[FK_User_Player]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_User_Player];
GO
IF OBJECT_ID(N'[dbo].[FK_User_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_User_Role];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Field]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Field];
GO
IF OBJECT_ID(N'[dbo].[Hole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Hole];
GO
IF OBJECT_ID(N'[dbo].[Match]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Match];
GO
IF OBJECT_ID(N'[dbo].[Player]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Player];
GO
IF OBJECT_ID(N'[dbo].[Result]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Result];
GO
IF OBJECT_ID(N'[dbo].[Role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Role];
GO
IF OBJECT_ID(N'[dbo].[Tournament]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tournament];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Field'
CREATE TABLE [dbo].[Field] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Address] nvarchar(50)  NOT NULL,
    [City] nvarchar(50)  NOT NULL,
    [Province] nvarchar(50)  NOT NULL,
    [Web] nvarchar(50)  NOT NULL,
    [Email] nvarchar(50)  NOT NULL,
    [Phone] nvarchar(50)  NOT NULL,
    [IsDeleted] bit  NOT NULL
);
GO

-- Creating table 'Hole'
CREATE TABLE [dbo].[Hole] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FieldId] int  NOT NULL,
    [Handicap] int  NOT NULL,
    [Distance] int  NOT NULL,
    [IsDeleted] bit  NOT NULL
);
GO

-- Creating table 'Match'
CREATE TABLE [dbo].[Match] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TournamentId] int  NOT NULL,
    [FieldId] int  NOT NULL,
    [Date] datetime  NOT NULL,
    [IsDeleted] bit  NOT NULL,
    [IsTournament] bit  NOT NULL
);
GO

-- Creating table 'Player'
CREATE TABLE [dbo].[Player] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [License] nvarchar(50)  NOT NULL,
    [Alias] nvarchar(50)  NOT NULL,
    [Phone] nvarchar(50)  NOT NULL,
    [RealHP] float  NOT NULL,
    [GameHP] float  NOT NULL,
    [IsDeleted] bit  NOT NULL
);
GO

-- Creating table 'Result'
CREATE TABLE [dbo].[Result] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [HoleId] int  NOT NULL,
    [MatchId] int  NOT NULL,
    [PlayerId] int  NOT NULL,
    [Strikes] int  NOT NULL,
    [Handicap] float  NOT NULL,
    [IsDeleted] bit  NOT NULL
);
GO

-- Creating table 'Role'
CREATE TABLE [dbo].[Role] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RoleName] nvarchar(50)  NOT NULL,
    [IsDeleted] bit  NOT NULL
);
GO

-- Creating table 'Tournament'
CREATE TABLE [dbo].[Tournament] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Year] int  NOT NULL,
    [IsDeleted] bit  NOT NULL,
    [IsFinished] bit  NOT NULL
);
GO

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Surname] nvarchar(50)  NOT NULL,
    [Email] nvarchar(50)  NOT NULL,
    [Password] nvarchar(50)  NOT NULL,
    [RoleId] int  NOT NULL,
    [PlayerId] int  NULL,
    [IsDeleted] bit  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Field'
ALTER TABLE [dbo].[Field]
ADD CONSTRAINT [PK_Field]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Hole'
ALTER TABLE [dbo].[Hole]
ADD CONSTRAINT [PK_Hole]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Match'
ALTER TABLE [dbo].[Match]
ADD CONSTRAINT [PK_Match]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Player'
ALTER TABLE [dbo].[Player]
ADD CONSTRAINT [PK_Player]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Result'
ALTER TABLE [dbo].[Result]
ADD CONSTRAINT [PK_Result]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Role'
ALTER TABLE [dbo].[Role]
ADD CONSTRAINT [PK_Role]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tournament'
ALTER TABLE [dbo].[Tournament]
ADD CONSTRAINT [PK_Tournament]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [FieldId] in table 'Hole'
ALTER TABLE [dbo].[Hole]
ADD CONSTRAINT [FK_Hole_Field]
    FOREIGN KEY ([FieldId])
    REFERENCES [dbo].[Field]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Hole_Field'
CREATE INDEX [IX_FK_Hole_Field]
ON [dbo].[Hole]
    ([FieldId]);
GO

-- Creating foreign key on [FieldId] in table 'Match'
ALTER TABLE [dbo].[Match]
ADD CONSTRAINT [FK_Match_Field]
    FOREIGN KEY ([FieldId])
    REFERENCES [dbo].[Field]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Match_Field'
CREATE INDEX [IX_FK_Match_Field]
ON [dbo].[Match]
    ([FieldId]);
GO

-- Creating foreign key on [HoleId] in table 'Result'
ALTER TABLE [dbo].[Result]
ADD CONSTRAINT [FK_Result_Hole]
    FOREIGN KEY ([HoleId])
    REFERENCES [dbo].[Hole]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Result_Hole'
CREATE INDEX [IX_FK_Result_Hole]
ON [dbo].[Result]
    ([HoleId]);
GO

-- Creating foreign key on [TournamentId] in table 'Match'
ALTER TABLE [dbo].[Match]
ADD CONSTRAINT [FK_Match_Tournament]
    FOREIGN KEY ([TournamentId])
    REFERENCES [dbo].[Tournament]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Match_Tournament'
CREATE INDEX [IX_FK_Match_Tournament]
ON [dbo].[Match]
    ([TournamentId]);
GO

-- Creating foreign key on [MatchId] in table 'Result'
ALTER TABLE [dbo].[Result]
ADD CONSTRAINT [FK_Result_Match]
    FOREIGN KEY ([MatchId])
    REFERENCES [dbo].[Match]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Result_Match'
CREATE INDEX [IX_FK_Result_Match]
ON [dbo].[Result]
    ([MatchId]);
GO

-- Creating foreign key on [PlayerId] in table 'Result'
ALTER TABLE [dbo].[Result]
ADD CONSTRAINT [FK_Result_Player]
    FOREIGN KEY ([PlayerId])
    REFERENCES [dbo].[Player]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Result_Player'
CREATE INDEX [IX_FK_Result_Player]
ON [dbo].[Result]
    ([PlayerId]);
GO

-- Creating foreign key on [PlayerId] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [FK_User_Player]
    FOREIGN KEY ([PlayerId])
    REFERENCES [dbo].[Player]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_User_Player'
CREATE INDEX [IX_FK_User_Player]
ON [dbo].[User]
    ([PlayerId]);
GO

-- Creating foreign key on [RoleId] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [FK_User_Role]
    FOREIGN KEY ([RoleId])
    REFERENCES [dbo].[Role]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_User_Role'
CREATE INDEX [IX_FK_User_Role]
ON [dbo].[User]
    ([RoleId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------