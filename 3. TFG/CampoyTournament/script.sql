USE [master]
GO
/****** Object:  Database [CampoyTournament]    Script Date: 30/03/2014 18:03:22 ******/
CREATE DATABASE [CampoyTournament]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TorneoCampoy', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQL2012\MSSQL\DATA\TorneoCampoy.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TorneoCampoy_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQL2012\MSSQL\DATA\TorneoCampoy_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CampoyTournament] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CampoyTournament].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CampoyTournament] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CampoyTournament] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CampoyTournament] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CampoyTournament] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CampoyTournament] SET ARITHABORT OFF 
GO
ALTER DATABASE [CampoyTournament] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CampoyTournament] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [CampoyTournament] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CampoyTournament] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CampoyTournament] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CampoyTournament] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CampoyTournament] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CampoyTournament] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CampoyTournament] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CampoyTournament] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CampoyTournament] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CampoyTournament] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CampoyTournament] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CampoyTournament] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CampoyTournament] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CampoyTournament] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CampoyTournament] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CampoyTournament] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CampoyTournament] SET RECOVERY FULL 
GO
ALTER DATABASE [CampoyTournament] SET  MULTI_USER 
GO
ALTER DATABASE [CampoyTournament] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CampoyTournament] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CampoyTournament] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CampoyTournament] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [CampoyTournament]
GO
/****** Object:  User [campoy]    Script Date: 30/03/2014 18:03:23 ******/
CREATE USER [campoy] FOR LOGIN [campoy] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspDeleteField]    Script Date: 30/03/2014 18:03:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 03/28/2014 20:12:59
-- DateModified: 03/28/2014 20:12:59
-- Description:
--*****************************************
CREATE PROCEDURE [dbo].[uspDeleteField]
    @id int 
AS
BEGIN
	DELETE FROM [dbo].[Field] 
	WHERE
		[id] = @id	
END

--**********************************************************************************
-- Get(T)s PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[uspDeleteHole]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 03/28/2014 20:13:00
-- DateModified: 03/28/2014 20:13:00
-- Description:
--*****************************************
CREATE PROCEDURE [dbo].[uspDeleteHole]
    @id int 
AS
BEGIN
	DELETE FROM [dbo].[Hole] 
	WHERE
		[id] = @id	
END

--**********************************************************************************
-- Get(T)s PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[uspDeleteMatch]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 03/28/2014 20:12:58
-- DateModified: 03/28/2014 20:12:58
-- Description:
--*****************************************
CREATE PROCEDURE [dbo].[uspDeleteMatch]
    @id int 
AS
BEGIN
	DELETE FROM [dbo].[Match] 
	WHERE
		[id] = @id	
END

--**********************************************************************************
-- Get(T)s PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[uspDeletePlayer]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 03/28/2014 20:13:02
-- DateModified: 03/28/2014 20:13:02
-- Description:
--*****************************************
CREATE PROCEDURE [dbo].[uspDeletePlayer]
    @id int 
AS
BEGIN
	DELETE FROM [dbo].[Player] 
	WHERE
		[id] = @id	
END

--**********************************************************************************
-- Get(T)s PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[uspDeleteResult]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 03/28/2014 20:13:01
-- DateModified: 03/28/2014 20:13:01
-- Description:
--*****************************************
CREATE PROCEDURE [dbo].[uspDeleteResult]
    @id int 
AS
BEGIN
	DELETE FROM [dbo].[Result] 
	WHERE
		[id] = @id	
END

--**********************************************************************************
-- Get(T)s PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[uspDeleteTournament]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 03/28/2014 20:12:57
-- DateModified: 03/28/2014 20:12:57
-- Description:
--*****************************************
CREATE PROCEDURE [dbo].[uspDeleteTournament]
    @id int 
AS
BEGIN
	DELETE FROM [dbo].[Tournament] 
	WHERE
		[id] = @id	
END

--**********************************************************************************
-- Get(T)s PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[uspDeleteUser]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 03/28/2014 20:13:03
-- DateModified: 03/28/2014 20:13:03
-- Description:
--*****************************************
CREATE PROCEDURE [dbo].[uspDeleteUser]
    @id int 
AS
BEGIN
	DELETE FROM [dbo].[User] 
	WHERE
		[id] = @id	
END

--**********************************************************************************
-- Get(T)s PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[uspGetAllField]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 03/28/2014 20:12:58
-- DateModified: 03/28/2014 20:12:58
-- Description:
--*****************************************
CREATE PROCEDURE [dbo].[uspGetAllField]
AS
BEGIN
	SELECT [id],
        [name],
        [address],
        [city],
        [province],
        [web],
        [email],
        [phone],
        [isDeleted]	
    FROM [dbo].[Field] 
	WHERE [IsDeleted] = 0
END

--**********************************************************************************
-- Insert PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[uspGetAllHole]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 03/28/2014 20:12:59
-- DateModified: 03/28/2014 20:12:59
-- Description:
--*****************************************
CREATE PROCEDURE [dbo].[uspGetAllHole]
AS
BEGIN
	SELECT [id],
        [fieldId],
        [holeId],
        [handicap],
        [distance],
        [isDeleted]	
    FROM [dbo].[Hole] 
	WHERE [IsDeleted] = 0
END

--**********************************************************************************
-- Insert PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[uspGetAllMatch]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 03/28/2014 20:12:57
-- DateModified: 03/28/2014 20:12:57
-- Description:
--*****************************************
CREATE PROCEDURE [dbo].[uspGetAllMatch]
AS
BEGIN
	SELECT [id],
        [tournamentId],
        [fieldId],
        [date],
        [isDeleted]	
    FROM [dbo].[Match] 
	WHERE [IsDeleted] = 0
END

--**********************************************************************************
-- Insert PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[uspGetAllPlayer]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 03/28/2014 20:13:01
-- DateModified: 03/28/2014 20:13:01
-- Description:
--*****************************************
CREATE PROCEDURE [dbo].[uspGetAllPlayer]
AS
BEGIN
	SELECT [id],
        [license],
        [alias],
        [phone],
        [realHP],
        [gameHP],
        [email],
        [isDeleted]	
    FROM [dbo].[Player] 
	WHERE [IsDeleted] = 0
END

--**********************************************************************************
-- Insert PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[uspGetAllResult]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 03/28/2014 20:13:00
-- DateModified: 03/28/2014 20:13:00
-- Description:
--*****************************************
CREATE PROCEDURE [dbo].[uspGetAllResult]
AS
BEGIN
	SELECT [id],
        [holeId],
        [matchId],
        [playerId],
        [strikes],
        [hp],
        [isDeleted]	
    FROM [dbo].[Result] 
	WHERE [IsDeleted] = 0
END

--**********************************************************************************
-- Insert PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[uspGetAllTournament]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 03/28/2014 20:12:57
-- DateModified: 03/28/2014 20:12:57
-- Description:
--*****************************************
CREATE PROCEDURE [dbo].[uspGetAllTournament]
AS
BEGIN
	SELECT [id],
        [year],
        [isDeleted]	
    FROM [dbo].[Tournament] 
	WHERE [IsDeleted] = 0
END

--**********************************************************************************
-- Insert PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[uspGetAllUser]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 03/28/2014 20:13:02
-- DateModified: 03/28/2014 20:13:02
-- Description:
--*****************************************
CREATE PROCEDURE [dbo].[uspGetAllUser]
AS
BEGIN
	SELECT [id],
        [name],
        [surname],
        [email],
        [password],
        [role],
        [isDeleted]	
    FROM [dbo].[User] 
	WHERE [IsDeleted] = 0
END

--**********************************************************************************
-- Insert PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[uspGetFieldById]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 03/28/2014 20:12:58
-- DateModified: 03/28/2014 20:12:58
-- Description:
--*****************************************
CREATE PROCEDURE [dbo].[uspGetFieldById]
	@Id int
AS
BEGIN
	SELECT [id],
        [name],
        [address],
        [city],
        [province],
        [web],
        [email],
        [phone],
        [isDeleted]	
    FROM [dbo].[Field] 
	WHERE [Id] = @Id AND
		  [IsDeleted] = 0
END

--**********************************************************************************
-- GetAll PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[uspGetFields]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 03/28/2014 20:12:59
-- DateModified: 03/28/2014 20:12:59
-- Description:
--*****************************************
CREATE PROCEDURE [dbo].[uspGetFields]
(
	@whereClause as nvarchar(max) = null,
	@OrderByClause as nvarchar(max) = null
)
AS
BEGIN
	DECLARE @MegaString nvarchar(max);
	set @MegaString = N'SELECT ' + '[id], '+
        '[name], '+
        '[address], '+
        '[city], '+
        '[province], '+
        '[web], '+
        '[email], '+
        '[phone], '+
        '[isDeleted] '+
    'FROM [dbo].[Field] ';
 
	IF (@whereClause <> NULL OR @whereClause <> '')
		BEGIN
			SET @MegaString = @MegaString + 'WHERE ' + @whereClause + ' ';
		END
	
	IF (@OrderByClause <> NULL  OR @OrderByClause <> '')
		begin
			SET @MegaString = @MegaString + 'ORDER BY ' + @OrderByClause + ' ';
		END
   EXEC(@MegaString);
END

--**********************************************************************************
-- Logical Delete Procedure
--**********************************************************************************
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[uspGetHoleById]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 03/28/2014 20:12:59
-- DateModified: 03/28/2014 20:12:59
-- Description:
--*****************************************
CREATE PROCEDURE [dbo].[uspGetHoleById]
	@Id int
AS
BEGIN
	SELECT [id],
        [fieldId],
        [holeId],
        [handicap],
        [distance],
        [isDeleted]	
    FROM [dbo].[Hole] 
	WHERE [Id] = @Id AND
		  [IsDeleted] = 0
END

--**********************************************************************************
-- GetAll PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[uspGetHoles]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 03/28/2014 20:13:00
-- DateModified: 03/28/2014 20:13:00
-- Description:
--*****************************************
CREATE PROCEDURE [dbo].[uspGetHoles]
(
	@whereClause as nvarchar(max) = null,
	@OrderByClause as nvarchar(max) = null
)
AS
BEGIN
	DECLARE @MegaString nvarchar(max);
	set @MegaString = N'SELECT ' + '[id], '+
        '[fieldId], '+
        '[holeId], '+
        '[handicap], '+
        '[distance], '+
        '[isDeleted] '+
    'FROM [dbo].[Hole] ';
 
	IF (@whereClause <> NULL OR @whereClause <> '')
		BEGIN
			SET @MegaString = @MegaString + 'WHERE ' + @whereClause + ' ';
		END
	
	IF (@OrderByClause <> NULL  OR @OrderByClause <> '')
		begin
			SET @MegaString = @MegaString + 'ORDER BY ' + @OrderByClause + ' ';
		END
   EXEC(@MegaString);
END

--**********************************************************************************
-- Logical Delete Procedure
--**********************************************************************************
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[uspGetMatchById]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 03/28/2014 20:12:57
-- DateModified: 03/28/2014 20:12:57
-- Description:
--*****************************************
CREATE PROCEDURE [dbo].[uspGetMatchById]
	@Id int
AS
BEGIN
	SELECT [id],
        [tournamentId],
        [fieldId],
        [date],
        [isDeleted]	
    FROM [dbo].[Match] 
	WHERE [Id] = @Id AND
		  [IsDeleted] = 0
END

--**********************************************************************************
-- GetAll PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[uspGetMatchs]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 03/28/2014 20:12:58
-- DateModified: 03/28/2014 20:12:58
-- Description:
--*****************************************
CREATE PROCEDURE [dbo].[uspGetMatchs]
(
	@whereClause as nvarchar(max) = null,
	@OrderByClause as nvarchar(max) = null
)
AS
BEGIN
	DECLARE @MegaString nvarchar(max);
	set @MegaString = N'SELECT ' + '[id], '+
        '[tournamentId], '+
        '[fieldId], '+
        '[date], '+
        '[isDeleted] '+
    'FROM [dbo].[Match] ';
 
	IF (@whereClause <> NULL OR @whereClause <> '')
		BEGIN
			SET @MegaString = @MegaString + 'WHERE ' + @whereClause + ' ';
		END
	
	IF (@OrderByClause <> NULL  OR @OrderByClause <> '')
		begin
			SET @MegaString = @MegaString + 'ORDER BY ' + @OrderByClause + ' ';
		END
   EXEC(@MegaString);
END

--**********************************************************************************
-- Logical Delete Procedure
--**********************************************************************************
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[uspGetPlayerById]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 03/28/2014 20:13:01
-- DateModified: 03/28/2014 20:13:01
-- Description:
--*****************************************
CREATE PROCEDURE [dbo].[uspGetPlayerById]
	@Id int
AS
BEGIN
	SELECT [id],
        [license],
        [alias],
        [phone],
        [realHP],
        [gameHP],
        [email],
        [isDeleted]	
    FROM [dbo].[Player] 
	WHERE [Id] = @Id AND
		  [IsDeleted] = 0
END

--**********************************************************************************
-- GetAll PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[uspGetPlayers]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 03/28/2014 20:13:02
-- DateModified: 03/28/2014 20:13:02
-- Description:
--*****************************************
CREATE PROCEDURE [dbo].[uspGetPlayers]
(
	@whereClause as nvarchar(max) = null,
	@OrderByClause as nvarchar(max) = null
)
AS
BEGIN
	DECLARE @MegaString nvarchar(max);
	set @MegaString = N'SELECT ' + '[id], '+
        '[license], '+
        '[alias], '+
        '[phone], '+
        '[realHP], '+
        '[gameHP], '+
        '[email], '+
        '[isDeleted] '+
    'FROM [dbo].[Player] ';
 
	IF (@whereClause <> NULL OR @whereClause <> '')
		BEGIN
			SET @MegaString = @MegaString + 'WHERE ' + @whereClause + ' ';
		END
	
	IF (@OrderByClause <> NULL  OR @OrderByClause <> '')
		begin
			SET @MegaString = @MegaString + 'ORDER BY ' + @OrderByClause + ' ';
		END
   EXEC(@MegaString);
END

--**********************************************************************************
-- Logical Delete Procedure
--**********************************************************************************
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[uspGetResultById]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 03/28/2014 20:13:00
-- DateModified: 03/28/2014 20:13:00
-- Description:
--*****************************************
CREATE PROCEDURE [dbo].[uspGetResultById]
	@Id int
AS
BEGIN
	SELECT [id],
        [holeId],
        [matchId],
        [playerId],
        [strikes],
        [hp],
        [isDeleted]	
    FROM [dbo].[Result] 
	WHERE [Id] = @Id AND
		  [IsDeleted] = 0
END

--**********************************************************************************
-- GetAll PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[uspGetResults]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 03/28/2014 20:13:01
-- DateModified: 03/28/2014 20:13:01
-- Description:
--*****************************************
CREATE PROCEDURE [dbo].[uspGetResults]
(
	@whereClause as nvarchar(max) = null,
	@OrderByClause as nvarchar(max) = null
)
AS
BEGIN
	DECLARE @MegaString nvarchar(max);
	set @MegaString = N'SELECT ' + '[id], '+
        '[holeId], '+
        '[matchId], '+
        '[playerId], '+
        '[strikes], '+
        '[hp], '+
        '[isDeleted] '+
    'FROM [dbo].[Result] ';
 
	IF (@whereClause <> NULL OR @whereClause <> '')
		BEGIN
			SET @MegaString = @MegaString + 'WHERE ' + @whereClause + ' ';
		END
	
	IF (@OrderByClause <> NULL  OR @OrderByClause <> '')
		begin
			SET @MegaString = @MegaString + 'ORDER BY ' + @OrderByClause + ' ';
		END
   EXEC(@MegaString);
END

--**********************************************************************************
-- Logical Delete Procedure
--**********************************************************************************
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[uspGetTournamentById]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 03/28/2014 20:12:57
-- DateModified: 03/28/2014 20:12:57
-- Description:
--*****************************************
CREATE PROCEDURE [dbo].[uspGetTournamentById]
	@Id int
AS
BEGIN
	SELECT [id],
        [year],
        [isDeleted]	
    FROM [dbo].[Tournament] 
	WHERE [Id] = @Id AND
		  [IsDeleted] = 0
END

--**********************************************************************************
-- GetAll PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[uspGetTournaments]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 03/28/2014 20:12:57
-- DateModified: 03/28/2014 20:12:57
-- Description:
--*****************************************
CREATE PROCEDURE [dbo].[uspGetTournaments]
(
	@whereClause as nvarchar(max) = null,
	@OrderByClause as nvarchar(max) = null
)
AS
BEGIN
	DECLARE @MegaString nvarchar(max);
	set @MegaString = N'SELECT ' + '[id], '+
        '[year], '+
        '[isDeleted] '+
    'FROM [dbo].[Tournament] ';
 
	IF (@whereClause <> NULL OR @whereClause <> '')
		BEGIN
			SET @MegaString = @MegaString + 'WHERE ' + @whereClause + ' ';
		END
	
	IF (@OrderByClause <> NULL  OR @OrderByClause <> '')
		begin
			SET @MegaString = @MegaString + 'ORDER BY ' + @OrderByClause + ' ';
		END
   EXEC(@MegaString);
END

--**********************************************************************************
-- Logical Delete Procedure
--**********************************************************************************
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[uspGetUserById]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 03/28/2014 20:13:02
-- DateModified: 03/28/2014 20:13:02
-- Description:
--*****************************************
CREATE PROCEDURE [dbo].[uspGetUserById]
	@Id int
AS
BEGIN
	SELECT [id],
        [name],
        [surname],
        [email],
        [password],
        [role],
        [isDeleted]	
    FROM [dbo].[User] 
	WHERE [Id] = @Id AND
		  [IsDeleted] = 0
END

--**********************************************************************************
-- GetAll PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[uspGetUsers]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 03/28/2014 20:13:03
-- DateModified: 03/28/2014 20:13:03
-- Description:
--*****************************************
CREATE PROCEDURE [dbo].[uspGetUsers]
(
	@whereClause as nvarchar(max) = null,
	@OrderByClause as nvarchar(max) = null
)
AS
BEGIN
	DECLARE @MegaString nvarchar(max);
	set @MegaString = N'SELECT ' + '[id], '+
        '[name], '+
        '[surname], '+
        '[email], '+
        '[password], '+
        '[role], '+
        '[isDeleted] '+
    'FROM [dbo].[User] ';
 
	IF (@whereClause <> NULL OR @whereClause <> '')
		BEGIN
			SET @MegaString = @MegaString + 'WHERE ' + @whereClause + ' ';
		END
	
	IF (@OrderByClause <> NULL  OR @OrderByClause <> '')
		begin
			SET @MegaString = @MegaString + 'ORDER BY ' + @OrderByClause + ' ';
		END
   EXEC(@MegaString);
END

--**********************************************************************************
-- Logical Delete Procedure
--**********************************************************************************
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[uspInsertField]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 03/28/2014 20:12:58
-- DateModified: 03/28/2014 20:12:58
-- Description:
--*****************************************
CREATE PROCEDURE [dbo].[uspInsertField]
    @name nvarchar(50),
    @address nvarchar(50),
    @city nvarchar(50),
    @province nvarchar(50),
    @web nvarchar(50),
    @email nvarchar(50),
    @phone nvarchar(50),
    @isDeleted bit,
    @id int output 
AS
BEGIN
	INSERT INTO [dbo].[Field] 
	(
		[name],
        [address],
        [city],
        [province],
        [web],
        [email],
        [phone],
        [isDeleted]	
    ) 
    VALUES 
    (
		@name,
        @address,
        @city,
        @province,
        @web,
        @email,
        @phone,
        @isDeleted 
    )
	SET NOCOUNT ON
    
	-- Return id value of the new row
	set @id = scope_identity()
END
	
--**********************************************************************************
-- Update PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[uspInsertHole]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 03/28/2014 20:12:59
-- DateModified: 03/28/2014 20:12:59
-- Description:
--*****************************************
CREATE PROCEDURE [dbo].[uspInsertHole]
    @fieldId int,
    @holeId int,
    @handicap int,
    @distance int,
    @isDeleted bit,
    @id int output 
AS
BEGIN
	INSERT INTO [dbo].[Hole] 
	(
		[fieldId],
        [holeId],
        [handicap],
        [distance],
        [isDeleted]	
    ) 
    VALUES 
    (
		@fieldId,
        @holeId,
        @handicap,
        @distance,
        @isDeleted 
    )
	SET NOCOUNT ON
    
	-- Return id value of the new row
	set @id = scope_identity()
END
	
--**********************************************************************************
-- Update PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[uspInsertMatch]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 03/28/2014 20:12:57
-- DateModified: 03/28/2014 20:12:57
-- Description:
--*****************************************
CREATE PROCEDURE [dbo].[uspInsertMatch]
    @tournamentId int,
    @fieldId int,
    @date date,
    @isDeleted bit,
    @id int output 
AS
BEGIN
	INSERT INTO [dbo].[Match] 
	(
		[tournamentId],
        [fieldId],
        [date],
        [isDeleted]	
    ) 
    VALUES 
    (
		@tournamentId,
        @fieldId,
        @date,
        @isDeleted 
    )
	SET NOCOUNT ON
    
	-- Return id value of the new row
	set @id = scope_identity()
END
	
--**********************************************************************************
-- Update PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[uspInsertPlayer]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 03/28/2014 20:13:01
-- DateModified: 03/28/2014 20:13:01
-- Description:
--*****************************************
CREATE PROCEDURE [dbo].[uspInsertPlayer]
    @license nvarchar(50),
    @alias nvarchar(50),
    @phone nvarchar(50),
    @realHP float,
    @gameHP float,
    @email nvarchar(50),
    @isDeleted bit,
    @id int output 
AS
BEGIN
	INSERT INTO [dbo].[Player] 
	(
		[license],
        [alias],
        [phone],
        [realHP],
        [gameHP],
        [email],
        [isDeleted]	
    ) 
    VALUES 
    (
		@license,
        @alias,
        @phone,
        @realHP,
        @gameHP,
        @email,
        @isDeleted 
    )
	SET NOCOUNT ON
    
	-- Return id value of the new row
	set @id = scope_identity()
END
	
--**********************************************************************************
-- Update PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[uspInsertResult]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 03/28/2014 20:13:00
-- DateModified: 03/28/2014 20:13:00
-- Description:
--*****************************************
CREATE PROCEDURE [dbo].[uspInsertResult]
    @holeId int,
    @matchId int,
    @playerId int,
    @strikes int,
    @hp float,
    @isDeleted bit,
    @id int output 
AS
BEGIN
	INSERT INTO [dbo].[Result] 
	(
		[holeId],
        [matchId],
        [playerId],
        [strikes],
        [hp],
        [isDeleted]	
    ) 
    VALUES 
    (
		@holeId,
        @matchId,
        @playerId,
        @strikes,
        @hp,
        @isDeleted 
    )
	SET NOCOUNT ON
    
	-- Return id value of the new row
	set @id = scope_identity()
END
	
--**********************************************************************************
-- Update PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[uspInsertTournament]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 03/28/2014 20:12:57
-- DateModified: 03/28/2014 20:12:57
-- Description:
--*****************************************
CREATE PROCEDURE [dbo].[uspInsertTournament]
    @year int,
    @isDeleted bit,
    @id int output 
AS
BEGIN
	INSERT INTO [dbo].[Tournament] 
	(
		[year],
        [isDeleted]	
    ) 
    VALUES 
    (
		@year,
        @isDeleted 
    )
	SET NOCOUNT ON
    
	-- Return id value of the new row
	set @id = scope_identity()
END
	
--**********************************************************************************
-- Update PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[uspInsertUser]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 03/28/2014 20:13:02
-- DateModified: 03/28/2014 20:13:02
-- Description:
--*****************************************
CREATE PROCEDURE [dbo].[uspInsertUser]
    @name nvarchar(50),
    @surname nvarchar(50),
    @email nvarchar(50),
    @password nvarchar(50),
    @role bit,
    @isDeleted bit,
    @id int output 
AS
BEGIN
	INSERT INTO [dbo].[User] 
	(
		[name],
        [surname],
        [email],
        [password],
        [role],
        [isDeleted]	
    ) 
    VALUES 
    (
		@name,
        @surname,
        @email,
        @password,
        @role,
        @isDeleted 
    )
	SET NOCOUNT ON
    
	-- Return id value of the new row
	set @id = scope_identity()
END
	
--**********************************************************************************
-- Update PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[uspLogicalDeleteField]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 03/28/2014 20:12:59
-- DateModified: 03/28/2014 20:12:59
-- Description:
--*****************************************
CREATE PROCEDURE [dbo].[uspLogicalDeleteField]
    @Id int 
AS
BEGIN
	UPDATE [dbo].[Field] 
	SET
		[IsDeleted] = 1
	WHERE
		[Id] = @Id	
	SET NOCOUNT ON   
END

--**********************************************************************************
--**********************************************************************************
--**********************************************************************************

GO
/****** Object:  StoredProcedure [dbo].[uspLogicalDeleteHole]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 03/28/2014 20:13:00
-- DateModified: 03/28/2014 20:13:00
-- Description:
--*****************************************
CREATE PROCEDURE [dbo].[uspLogicalDeleteHole]
    @Id int 
AS
BEGIN
	UPDATE [dbo].[Hole] 
	SET
		[IsDeleted] = 1
	WHERE
		[Id] = @Id	
	SET NOCOUNT ON   
END

--**********************************************************************************
--**********************************************************************************
--**********************************************************************************

GO
/****** Object:  StoredProcedure [dbo].[uspLogicalDeleteMatch]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 03/28/2014 20:12:58
-- DateModified: 03/28/2014 20:12:58
-- Description:
--*****************************************
CREATE PROCEDURE [dbo].[uspLogicalDeleteMatch]
    @Id int 
AS
BEGIN
	UPDATE [dbo].[Match] 
	SET
		[IsDeleted] = 1
	WHERE
		[Id] = @Id	
	SET NOCOUNT ON   
END

--**********************************************************************************
--**********************************************************************************
--**********************************************************************************

GO
/****** Object:  StoredProcedure [dbo].[uspLogicalDeletePlayer]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 03/28/2014 20:13:02
-- DateModified: 03/28/2014 20:13:02
-- Description:
--*****************************************
CREATE PROCEDURE [dbo].[uspLogicalDeletePlayer]
    @Id int 
AS
BEGIN
	UPDATE [dbo].[Player] 
	SET
		[IsDeleted] = 1
	WHERE
		[Id] = @Id	
	SET NOCOUNT ON   
END

--**********************************************************************************
--**********************************************************************************
--**********************************************************************************

GO
/****** Object:  StoredProcedure [dbo].[uspLogicalDeleteResult]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 03/28/2014 20:13:01
-- DateModified: 03/28/2014 20:13:01
-- Description:
--*****************************************
CREATE PROCEDURE [dbo].[uspLogicalDeleteResult]
    @Id int 
AS
BEGIN
	UPDATE [dbo].[Result] 
	SET
		[IsDeleted] = 1
	WHERE
		[Id] = @Id	
	SET NOCOUNT ON   
END

--**********************************************************************************
--**********************************************************************************
--**********************************************************************************

GO
/****** Object:  StoredProcedure [dbo].[uspLogicalDeleteTournament]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 03/28/2014 20:12:57
-- DateModified: 03/28/2014 20:12:57
-- Description:
--*****************************************
CREATE PROCEDURE [dbo].[uspLogicalDeleteTournament]
    @Id int 
AS
BEGIN
	UPDATE [dbo].[Tournament] 
	SET
		[IsDeleted] = 1
	WHERE
		[Id] = @Id	
	SET NOCOUNT ON   
END

--**********************************************************************************
--**********************************************************************************
--**********************************************************************************

GO
/****** Object:  StoredProcedure [dbo].[uspLogicalDeleteUser]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 03/28/2014 20:13:03
-- DateModified: 03/28/2014 20:13:03
-- Description:
--*****************************************
CREATE PROCEDURE [dbo].[uspLogicalDeleteUser]
    @Id int 
AS
BEGIN
	UPDATE [dbo].[User] 
	SET
		[IsDeleted] = 1
	WHERE
		[Id] = @Id	
	SET NOCOUNT ON   
END

--**********************************************************************************
--**********************************************************************************
--**********************************************************************************

GO
/****** Object:  StoredProcedure [dbo].[uspUpdateField]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 03/28/2014 20:12:59
-- DateModified: 03/28/2014 20:12:59
-- Description:
--*****************************************
CREATE PROCEDURE [dbo].[uspUpdateField]
    @id int,
    @name nvarchar(50),
    @address nvarchar(50),
    @city nvarchar(50),
    @province nvarchar(50),
    @web nvarchar(50),
    @email nvarchar(50),
    @phone nvarchar(50),
    @isDeleted bit 
AS
BEGIN
	UPDATE [dbo].[Field] 
	SET
		[name] = @name,
        [address] = @address,
        [city] = @city,
        [province] = @province,
        [web] = @web,
        [email] = @email,
        [phone] = @phone,
        [isDeleted] = @isDeleted	
	WHERE
		[id] = @id	
END

--**********************************************************************************
-- Delete Procedure
--**********************************************************************************
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[uspUpdateHole]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 03/28/2014 20:13:00
-- DateModified: 03/28/2014 20:13:00
-- Description:
--*****************************************
CREATE PROCEDURE [dbo].[uspUpdateHole]
    @id int,
    @fieldId int,
    @holeId int,
    @handicap int,
    @distance int,
    @isDeleted bit 
AS
BEGIN
	UPDATE [dbo].[Hole] 
	SET
		[fieldId] = @fieldId,
        [holeId] = @holeId,
        [handicap] = @handicap,
        [distance] = @distance,
        [isDeleted] = @isDeleted	
	WHERE
		[id] = @id	
END

--**********************************************************************************
-- Delete Procedure
--**********************************************************************************
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[uspUpdateMatch]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 03/28/2014 20:12:58
-- DateModified: 03/28/2014 20:12:58
-- Description:
--*****************************************
CREATE PROCEDURE [dbo].[uspUpdateMatch]
    @id int,
    @tournamentId int,
    @fieldId int,
    @date date,
    @isDeleted bit 
AS
BEGIN
	UPDATE [dbo].[Match] 
	SET
		[tournamentId] = @tournamentId,
        [fieldId] = @fieldId,
        [date] = @date,
        [isDeleted] = @isDeleted	
	WHERE
		[id] = @id	
END

--**********************************************************************************
-- Delete Procedure
--**********************************************************************************
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[uspUpdatePlayer]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 03/28/2014 20:13:02
-- DateModified: 03/28/2014 20:13:02
-- Description:
--*****************************************
CREATE PROCEDURE [dbo].[uspUpdatePlayer]
    @id int,
    @license nvarchar(50),
    @alias nvarchar(50),
    @phone nvarchar(50),
    @realHP float,
    @gameHP float,
    @email nvarchar(50),
    @isDeleted bit 
AS
BEGIN
	UPDATE [dbo].[Player] 
	SET
		[license] = @license,
        [alias] = @alias,
        [phone] = @phone,
        [realHP] = @realHP,
        [gameHP] = @gameHP,
        [email] = @email,
        [isDeleted] = @isDeleted	
	WHERE
		[id] = @id	
END

--**********************************************************************************
-- Delete Procedure
--**********************************************************************************
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[uspUpdateResult]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 03/28/2014 20:13:01
-- DateModified: 03/28/2014 20:13:01
-- Description:
--*****************************************
CREATE PROCEDURE [dbo].[uspUpdateResult]
    @id int,
    @holeId int,
    @matchId int,
    @playerId int,
    @strikes int,
    @hp float,
    @isDeleted bit 
AS
BEGIN
	UPDATE [dbo].[Result] 
	SET
		[holeId] = @holeId,
        [matchId] = @matchId,
        [playerId] = @playerId,
        [strikes] = @strikes,
        [hp] = @hp,
        [isDeleted] = @isDeleted	
	WHERE
		[id] = @id	
END

--**********************************************************************************
-- Delete Procedure
--**********************************************************************************
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[uspUpdateTournament]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 03/28/2014 20:12:57
-- DateModified: 03/28/2014 20:12:57
-- Description:
--*****************************************
CREATE PROCEDURE [dbo].[uspUpdateTournament]
    @id int,
    @year int,
    @isDeleted bit 
AS
BEGIN
	UPDATE [dbo].[Tournament] 
	SET
		[year] = @year,
        [isDeleted] = @isDeleted	
	WHERE
		[id] = @id	
END

--**********************************************************************************
-- Delete Procedure
--**********************************************************************************
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[uspUpdateUser]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 03/28/2014 20:13:02
-- DateModified: 03/28/2014 20:13:02
-- Description:
--*****************************************
CREATE PROCEDURE [dbo].[uspUpdateUser]
    @id int,
    @name nvarchar(50),
    @surname nvarchar(50),
    @email nvarchar(50),
    @password nvarchar(50),
    @role bit,
    @isDeleted bit 
AS
BEGIN
	UPDATE [dbo].[User] 
	SET
		[name] = @name,
        [surname] = @surname,
        [email] = @email,
        [password] = @password,
        [role] = @role,
        [isDeleted] = @isDeleted	
	WHERE
		[id] = @id	
END

--**********************************************************************************
-- Delete Procedure
--**********************************************************************************
SET ANSI_NULLS ON

GO
/****** Object:  Table [dbo].[Field]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Field](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[address] [nvarchar](50) NULL,
	[city] [nvarchar](50) NULL,
	[province] [nvarchar](50) NULL,
	[web] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[phone] [nvarchar](50) NULL,
	[isDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Field] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Hole]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hole](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fieldId] [int] NOT NULL,
	[holeId] [int] NOT NULL,
	[handicap] [int] NOT NULL,
	[distance] [int] NOT NULL,
	[isDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Hole] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UN_Hole] UNIQUE NONCLUSTERED 
(
	[fieldId] ASC,
	[holeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Match]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Match](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tournamentId] [int] NOT NULL,
	[fieldId] [int] NOT NULL,
	[date] [date] NOT NULL,
	[isDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Match] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UN_Match] UNIQUE NONCLUSTERED 
(
	[date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Player]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Player](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[license] [nvarchar](50) NOT NULL,
	[alias] [nvarchar](50) NOT NULL,
	[phone] [nvarchar](50) NOT NULL,
	[realHP] [float] NOT NULL,
	[gameHP] [float] NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[isDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Player] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UN_Player(email)] UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UN_Player(license)] UNIQUE NONCLUSTERED 
(
	[license] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Result]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Result](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[holeId] [int] NOT NULL,
	[matchId] [int] NOT NULL,
	[playerId] [int] NOT NULL,
	[strikes] [int] NOT NULL,
	[hp] [float] NOT NULL,
	[isDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Result] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UN_Result] UNIQUE NONCLUSTERED 
(
	[matchId] ASC,
	[holeId] ASC,
	[playerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tournament]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tournament](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[year] [int] NOT NULL,
	[isDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Tournament] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UN_Tournament] UNIQUE NONCLUSTERED 
(
	[year] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 30/03/2014 18:03:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[surname] [nvarchar](50) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[role] [bit] NOT NULL,
	[isDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UN_User] UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Field] ADD  CONSTRAINT [DF_Field_isDeleted]  DEFAULT ((0)) FOR [isDeleted]
GO
ALTER TABLE [dbo].[Hole] ADD  CONSTRAINT [DF_Hole_isDeleted]  DEFAULT ((0)) FOR [isDeleted]
GO
ALTER TABLE [dbo].[Match] ADD  CONSTRAINT [DF_Match_isDeleted]  DEFAULT ((0)) FOR [isDeleted]
GO
ALTER TABLE [dbo].[Player] ADD  CONSTRAINT [DF_Player_isDeleted]  DEFAULT ((0)) FOR [isDeleted]
GO
ALTER TABLE [dbo].[Result] ADD  CONSTRAINT [DF_Result_isDeleted]  DEFAULT ((0)) FOR [isDeleted]
GO
ALTER TABLE [dbo].[Tournament] ADD  CONSTRAINT [DF_Tournament_isDeleted]  DEFAULT ((0)) FOR [isDeleted]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_isDeleted]  DEFAULT ((0)) FOR [isDeleted]
GO
ALTER TABLE [dbo].[Hole]  WITH CHECK ADD  CONSTRAINT [FK_Hole_Field] FOREIGN KEY([fieldId])
REFERENCES [dbo].[Field] ([id])
GO
ALTER TABLE [dbo].[Hole] CHECK CONSTRAINT [FK_Hole_Field]
GO
ALTER TABLE [dbo].[Match]  WITH CHECK ADD  CONSTRAINT [FK_Match_Field] FOREIGN KEY([fieldId])
REFERENCES [dbo].[Field] ([id])
GO
ALTER TABLE [dbo].[Match] CHECK CONSTRAINT [FK_Match_Field]
GO
ALTER TABLE [dbo].[Match]  WITH CHECK ADD  CONSTRAINT [FK_Match_Tournament] FOREIGN KEY([tournamentId])
REFERENCES [dbo].[Tournament] ([id])
GO
ALTER TABLE [dbo].[Match] CHECK CONSTRAINT [FK_Match_Tournament]
GO
ALTER TABLE [dbo].[Player]  WITH CHECK ADD  CONSTRAINT [FK_Player_Player] FOREIGN KEY([id])
REFERENCES [dbo].[Player] ([id])
GO
ALTER TABLE [dbo].[Player] CHECK CONSTRAINT [FK_Player_Player]
GO
ALTER TABLE [dbo].[Player]  WITH CHECK ADD  CONSTRAINT [FK_Player_User] FOREIGN KEY([email])
REFERENCES [dbo].[User] ([email])
GO
ALTER TABLE [dbo].[Player] CHECK CONSTRAINT [FK_Player_User]
GO
ALTER TABLE [dbo].[Result]  WITH CHECK ADD  CONSTRAINT [FK_Result_Hole] FOREIGN KEY([holeId])
REFERENCES [dbo].[Hole] ([id])
GO
ALTER TABLE [dbo].[Result] CHECK CONSTRAINT [FK_Result_Hole]
GO
ALTER TABLE [dbo].[Result]  WITH CHECK ADD  CONSTRAINT [FK_Result_Match] FOREIGN KEY([matchId])
REFERENCES [dbo].[Match] ([id])
GO
ALTER TABLE [dbo].[Result] CHECK CONSTRAINT [FK_Result_Match]
GO
ALTER TABLE [dbo].[Result]  WITH CHECK ADD  CONSTRAINT [FK_Result_Player] FOREIGN KEY([playerId])
REFERENCES [dbo].[Player] ([id])
GO
ALTER TABLE [dbo].[Result] CHECK CONSTRAINT [FK_Result_Player]
GO
ALTER TABLE [dbo].[Tournament]  WITH CHECK ADD  CONSTRAINT [FK_Tournament_Tournament] FOREIGN KEY([id])
REFERENCES [dbo].[Tournament] ([id])
GO
ALTER TABLE [dbo].[Tournament] CHECK CONSTRAINT [FK_Tournament_Tournament]
GO
USE [master]
GO
ALTER DATABASE [CampoyTournament] SET  READ_WRITE 
GO
