USE [CampoyTournament]
GO

/****** Object:  Login [campoy]    Script Date: 21/05/2014 9:26:37 ******/
CREATE LOGIN [campoy] WITH PASSWORD=N'campoy', 
DEFAULT_DATABASE=[CampoyTournament], 
DEFAULT_LANGUAGE=[us_english], 
CHECK_EXPIRATION=OFF, 
CHECK_POLICY=OFF
GO

ALTER SERVER ROLE [sysadmin] ADD MEMBER [campoy]
GO

ALTER SERVER ROLE [serveradmin] ADD MEMBER [campoy]
GO

USE [CampoyTournament]
GO

/****** Object:  User [CampoyUser]    Script Date: 21/05/2014 9:24:58 ******/
CREATE USER [campoy] FOR LOGIN [campoy] WITH DEFAULT_SCHEMA=[dbo]
GO


USE [CampoyTournament]
GO

/****** Object:  Table [dbo].[Role]    Script Date: 21/05/2014 9:33:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Role] ADD  CONSTRAINT [DF_Role_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

/****** Object:  Table [dbo].[Tournament]    Script Date: 21/05/2014 9:34:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Tournament](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Year] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsFinished] [bit] NOT NULL,
 CONSTRAINT [PK_Tournament] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Tournament] ADD  CONSTRAINT [DF_Tournament_isDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[Tournament] ADD  CONSTRAINT [DF_Tournament_IsActive]  DEFAULT ((0)) FOR [IsFinished]
GO

/****** Object:  Table [dbo].[Player]    Script Date: 21/05/2014 9:35:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Player](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[License] [nvarchar](50) NOT NULL,
	[Alias] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[RealHP] [float] NOT NULL,
	[GameHP] [float] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Player] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UN_Player] UNIQUE NONCLUSTERED 
(
	[License] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Player] ADD  CONSTRAINT [DF_Player_isDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

/****** Object:  Table [dbo].[User]    Script Date: 21/05/2014 9:30:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[RoleId] [int] NOT NULL,
	[PlayerId] [int] NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_Role]  DEFAULT ((0)) FOR [RoleId]
GO

ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_isDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Player] FOREIGN KEY([PlayerId])
REFERENCES [dbo].[Player] ([Id])
GO

ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Player]
GO

ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO

ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO

/****** Object:  Table [dbo].[Field]    Script Date: 21/05/2014 9:36:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Field](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[Province] [nvarchar](50) NOT NULL,
	[Web] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Field] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Field] ADD  CONSTRAINT [DF_Field_isDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

/****** Object:  Table [dbo].[Hole]    Script Date: 21/05/2014 9:36:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Hole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FieldId] [int] NOT NULL,
	[Handicap] [int] NOT NULL,
	[Distance] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Hole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Hole] ADD  CONSTRAINT [DF_Hole_isDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[Hole]  WITH CHECK ADD  CONSTRAINT [FK_Hole_Field] FOREIGN KEY([FieldId])
REFERENCES [dbo].[Field] ([Id])
GO

ALTER TABLE [dbo].[Hole] CHECK CONSTRAINT [FK_Hole_Field]
GO

/****** Object:  Table [dbo].[Match]    Script Date: 21/05/2014 9:37:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Match](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TournamentId] [int] NOT NULL,
	[FieldId] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsTournament] [bit] NOT NULL,
 CONSTRAINT [PK_Match] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Match] ADD  CONSTRAINT [DF_Match_isDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[Match]  WITH CHECK ADD  CONSTRAINT [FK_Match_Field] FOREIGN KEY([FieldId])
REFERENCES [dbo].[Field] ([Id])
GO

ALTER TABLE [dbo].[Match] CHECK CONSTRAINT [FK_Match_Field]
GO

ALTER TABLE [dbo].[Match]  WITH CHECK ADD  CONSTRAINT [FK_Match_Tournament] FOREIGN KEY([TournamentId])
REFERENCES [dbo].[Tournament] ([Id])
GO

ALTER TABLE [dbo].[Match] CHECK CONSTRAINT [FK_Match_Tournament]
GO

/****** Object:  Table [dbo].[Result]    Script Date: 21/05/2014 9:37:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Result](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HoleId] [int] NOT NULL,
	[MatchId] [int] NOT NULL,
	[PlayerId] [int] NOT NULL,
	[Strikes] [int] NOT NULL,
	[StableFordPoints] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Result] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UN_Result] UNIQUE NONCLUSTERED 
(
	[MatchId] ASC,
	[HoleId] ASC,
	[PlayerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Result] ADD  CONSTRAINT [DF_Result_isDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[Result]  WITH CHECK ADD  CONSTRAINT [FK_Result_Hole] FOREIGN KEY([HoleId])
REFERENCES [dbo].[Hole] ([Id])
GO

ALTER TABLE [dbo].[Result] CHECK CONSTRAINT [FK_Result_Hole]
GO

ALTER TABLE [dbo].[Result]  WITH CHECK ADD  CONSTRAINT [FK_Result_Match] FOREIGN KEY([MatchId])
REFERENCES [dbo].[Match] ([Id])
GO

ALTER TABLE [dbo].[Result] CHECK CONSTRAINT [FK_Result_Match]
GO

ALTER TABLE [dbo].[Result]  WITH CHECK ADD  CONSTRAINT [FK_Result_Player] FOREIGN KEY([PlayerId])
REFERENCES [dbo].[Player] ([Id])
GO

ALTER TABLE [dbo].[Result] CHECK CONSTRAINT [FK_Result_Player]
GO

USE [CampoyTournament]
GO

/****** Object:  Insert Values    Script Date: 21/05/2014 9:37:27 ******/

INSERT INTO [dbo].[Role] ([RoleName],[IsDeleted])
     VALUES ('Admin', 0),
			('Player', 0),
			('User', 0)
GO

INSERT INTO [dbo].[Tournament] ([Year],[IsDeleted],[IsFinished])
     VALUES (2014, 0, 0)
GO

INSERT INTO [dbo].[User] ([Name],[Surname],[Email],[Password],[RoleId],[IsDeleted])
     VALUES ('Tutor','Administrador','info@torneocampoy.tk','hacwmxlpb/MVoyRadORAEQ==',1,0)
GO




--**********************************************************************************
-- GetById PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:21
-- DateModified: 05/21/2014 18:44:21
-- Description:
--*****************************************
CREATE PROCEDURE uspGetUserById
	@Id int
AS
BEGIN
	SELECT [Id],
        [Name],
        [Surname],
        [Email],
        [Password],
        [RoleId],
        [PlayerId],
        [IsDeleted]	
    FROM [dbo].[User] 
	WHERE [Id] = @Id AND
		  [IsDeleted] = 0
END

--**********************************************************************************
-- GetAll PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:21
-- DateModified: 05/21/2014 18:44:21
-- Description:
--*****************************************
CREATE PROCEDURE uspGetAllUser
AS
BEGIN
	SELECT [Id],
        [Name],
        [Surname],
        [Email],
        [Password],
        [RoleId],
        [PlayerId],
        [IsDeleted]	
    FROM [dbo].[User] 
	WHERE [IsDeleted] = 0
END

--**********************************************************************************
-- Insert PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:21
-- DateModified: 05/21/2014 18:44:21
-- Description:
--*****************************************
CREATE PROCEDURE uspInsertUser
    @Name nvarchar(50),
    @Surname nvarchar(50),
    @Email nvarchar(50),
    @Password nvarchar(50),
    @RoleId int,
    @PlayerId int,
    @IsDeleted bit,
    @Id int output 
AS
BEGIN
	INSERT INTO [dbo].[User] 
	(
		[Name],
        [Surname],
        [Email],
        [Password],
        [RoleId],
        [PlayerId],
        [IsDeleted]	
    ) 
    VALUES 
    (
		@Name,
        @Surname,
        @Email,
        @Password,
        @RoleId,
        @PlayerId,
        @IsDeleted 
    )
	SET NOCOUNT ON
    
	-- Return Id value of the new row
	set @Id = scope_identity()
END
	
--**********************************************************************************
-- Update PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:22
-- DateModified: 05/21/2014 18:44:22
-- Description:
--*****************************************
CREATE PROCEDURE uspUpdateUser
    @Id int,
    @Name nvarchar(50),
    @Surname nvarchar(50),
    @Email nvarchar(50),
    @Password nvarchar(50),
    @RoleId int,
    @PlayerId int,
    @IsDeleted bit 
AS
BEGIN
	UPDATE [dbo].[User] 
	SET
		[Name] = @Name,
        [Surname] = @Surname,
        [Email] = @Email,
        [Password] = @Password,
        [RoleId] = @RoleId,
        [PlayerId] = @PlayerId,
        [IsDeleted] = @IsDeleted	
	WHERE
		[Id] = @Id	
END

--**********************************************************************************
-- Delete Procedure
--**********************************************************************************
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:22
-- DateModified: 05/21/2014 18:44:22
-- Description:
--*****************************************
CREATE PROCEDURE uspDeleteUser
    @Id int 
AS
BEGIN
	DELETE FROM [dbo].[User] 
	WHERE
		[Id] = @Id	
END

--**********************************************************************************
-- Get(T)s PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:22
-- DateModified: 05/21/2014 18:44:22
-- Description:
--*****************************************
CREATE PROCEDURE uspGetUsers
(
	@whereClause as nvarchar(max) = null,
	@OrderByClause as nvarchar(max) = null
)
AS
BEGIN
	DECLARE @MegaString nvarchar(max);
	set @MegaString = N'SELECT ' + '[Id], '+
        '[Name], '+
        '[Surname], '+
        '[Email], '+
        '[Password], '+
        '[RoleId], '+
        '[PlayerId], '+
        '[IsDeleted] '+
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
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:22
-- DateModified: 05/21/2014 18:44:22
-- Description:
--*****************************************
CREATE PROCEDURE uspLogicalDeleteUser
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


--**********************************************************************************
-- GetById PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:20
-- DateModified: 05/21/2014 18:44:20
-- Description:
--*****************************************
CREATE PROCEDURE uspGetTournamentById
	@Id int
AS
BEGIN
	SELECT [Id],
        [Year],
        [IsDeleted],
        [IsFinished]	
    FROM [dbo].[Tournament] 
	WHERE [Id] = @Id AND
		  [IsDeleted] = 0
END

--**********************************************************************************
-- GetAll PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:20
-- DateModified: 05/21/2014 18:44:20
-- Description:
--*****************************************
CREATE PROCEDURE uspGetAllTournament
AS
BEGIN
	SELECT [Id],
        [Year],
        [IsDeleted],
        [IsFinished]	
    FROM [dbo].[Tournament] 
	WHERE [IsDeleted] = 0
END

--**********************************************************************************
-- Insert PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:20
-- DateModified: 05/21/2014 18:44:20
-- Description:
--*****************************************
CREATE PROCEDURE uspInsertTournament
    @Year int,
    @IsDeleted bit,
    @IsFinished bit,
    @Id int output 
AS
BEGIN
	INSERT INTO [dbo].[Tournament] 
	(
		[Year],
        [IsDeleted],
        [IsFinished]	
    ) 
    VALUES 
    (
		@Year,
        @IsDeleted,
        @IsFinished 
    )
	SET NOCOUNT ON
    
	-- Return Id value of the new row
	set @Id = scope_identity()
END
	
--**********************************************************************************
-- Update PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:21
-- DateModified: 05/21/2014 18:44:21
-- Description:
--*****************************************
CREATE PROCEDURE uspUpdateTournament
    @Id int,
    @Year int,
    @IsDeleted bit,
    @IsFinished bit 
AS
BEGIN
	UPDATE [dbo].[Tournament] 
	SET
		[Year] = @Year,
        [IsDeleted] = @IsDeleted,
        [IsFinished] = @IsFinished	
	WHERE
		[Id] = @Id	
END

--**********************************************************************************
-- Delete Procedure
--**********************************************************************************
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:21
-- DateModified: 05/21/2014 18:44:21
-- Description:
--*****************************************
CREATE PROCEDURE uspDeleteTournament
    @Id int 
AS
BEGIN
	DELETE FROM [dbo].[Tournament] 
	WHERE
		[Id] = @Id	
END

--**********************************************************************************
-- Get(T)s PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:21
-- DateModified: 05/21/2014 18:44:21
-- Description:
--*****************************************
CREATE PROCEDURE uspGetTournaments
(
	@whereClause as nvarchar(max) = null,
	@OrderByClause as nvarchar(max) = null
)
AS
BEGIN
	DECLARE @MegaString nvarchar(max);
	set @MegaString = N'SELECT ' + '[Id], '+
        '[Year], '+
        '[IsDeleted], '+
        '[IsFinished] '+
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
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:21
-- DateModified: 05/21/2014 18:44:21
-- Description:
--*****************************************
CREATE PROCEDURE uspLogicalDeleteTournament
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


--**********************************************************************************
-- GetById PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:20
-- DateModified: 05/21/2014 18:44:20
-- Description:
--*****************************************
CREATE PROCEDURE uspGetRoleById
	@Id int
AS
BEGIN
	SELECT [Id],
        [RoleName],
        [IsDeleted]	
    FROM [dbo].[Role] 
	WHERE [Id] = @Id AND
		  [IsDeleted] = 0
END

--**********************************************************************************
-- GetAll PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:20
-- DateModified: 05/21/2014 18:44:20
-- Description:
--*****************************************
CREATE PROCEDURE uspGetAllRole
AS
BEGIN
	SELECT [Id],
        [RoleName],
        [IsDeleted]	
    FROM [dbo].[Role] 
	WHERE [IsDeleted] = 0
END

--**********************************************************************************
-- Insert PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:20
-- DateModified: 05/21/2014 18:44:20
-- Description:
--*****************************************
CREATE PROCEDURE uspInsertRole
    @RoleName nvarchar(50),
    @IsDeleted bit,
    @Id int output 
AS
BEGIN
	INSERT INTO [dbo].[Role] 
	(
		[RoleName],
        [IsDeleted]	
    ) 
    VALUES 
    (
		@RoleName,
        @IsDeleted 
    )
	SET NOCOUNT ON
    
	-- Return Id value of the new row
	set @Id = scope_identity()
END
	
--**********************************************************************************
-- Update PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:20
-- DateModified: 05/21/2014 18:44:20
-- Description:
--*****************************************
CREATE PROCEDURE uspUpdateRole
    @Id int,
    @RoleName nvarchar(50),
    @IsDeleted bit 
AS
BEGIN
	UPDATE [dbo].[Role] 
	SET
		[RoleName] = @RoleName,
        [IsDeleted] = @IsDeleted	
	WHERE
		[Id] = @Id	
END

--**********************************************************************************
-- Delete Procedure
--**********************************************************************************
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:20
-- DateModified: 05/21/2014 18:44:20
-- Description:
--*****************************************
CREATE PROCEDURE uspDeleteRole
    @Id int 
AS
BEGIN
	DELETE FROM [dbo].[Role] 
	WHERE
		[Id] = @Id	
END

--**********************************************************************************
-- Get(T)s PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:20
-- DateModified: 05/21/2014 18:44:20
-- Description:
--*****************************************
CREATE PROCEDURE uspGetRoles
(
	@whereClause as nvarchar(max) = null,
	@OrderByClause as nvarchar(max) = null
)
AS
BEGIN
	DECLARE @MegaString nvarchar(max);
	set @MegaString = N'SELECT ' + '[Id], '+
        '[RoleName], '+
        '[IsDeleted] '+
    'FROM [dbo].[Role] ';
 
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
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:20
-- DateModified: 05/21/2014 18:44:20
-- Description:
--*****************************************
CREATE PROCEDURE uspLogicalDeleteRole
    @Id int 
AS
BEGIN
	UPDATE [dbo].[Role] 
	SET
		[IsDeleted] = 1
	WHERE
		[Id] = @Id	
	SET NOCOUNT ON   
END

--**********************************************************************************
--**********************************************************************************
--**********************************************************************************


--**********************************************************************************
-- GetById PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:22
-- DateModified: 05/21/2014 18:44:22
-- Description:
--*****************************************
CREATE PROCEDURE uspGetResultById
	@Id int
AS
BEGIN
	SELECT [Id],
        [HoleId],
        [MatchId],
        [PlayerId],
        [Strikes],
        [StableFordPoints],
        [IsDeleted]	
    FROM [dbo].[Result] 
	WHERE [Id] = @Id AND
		  [IsDeleted] = 0
END

--**********************************************************************************
-- GetAll PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:22
-- DateModified: 05/21/2014 18:44:22
-- Description:
--*****************************************
CREATE PROCEDURE uspGetAllResult
AS
BEGIN
	SELECT [Id],
        [HoleId],
        [MatchId],
        [PlayerId],
        [Strikes],
        [StableFordPoints],
        [IsDeleted]	
    FROM [dbo].[Result] 
	WHERE [IsDeleted] = 0
END

--**********************************************************************************
-- Insert PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:22
-- DateModified: 05/21/2014 18:44:22
-- Description:
--*****************************************
CREATE PROCEDURE uspInsertResult
    @HoleId int,
    @MatchId int,
    @PlayerId int,
    @Strikes int,
    @StableFordPoints int,
    @IsDeleted bit,
    @Id int output 
AS
BEGIN
	INSERT INTO [dbo].[Result] 
	(
		[HoleId],
        [MatchId],
        [PlayerId],
        [Strikes],
        [StableFordPoints],
        [IsDeleted]	
    ) 
    VALUES 
    (
		@HoleId,
        @MatchId,
        @PlayerId,
        @Strikes,
        @StableFordPoints,
        @IsDeleted 
    )
	SET NOCOUNT ON
    
	-- Return Id value of the new row
	set @Id = scope_identity()
END
	
--**********************************************************************************
-- Update PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:23
-- DateModified: 05/21/2014 18:44:23
-- Description:
--*****************************************
CREATE PROCEDURE uspUpdateResult
    @Id int,
    @HoleId int,
    @MatchId int,
    @PlayerId int,
    @Strikes int,
    @StableFordPoints int,
    @IsDeleted bit 
AS
BEGIN
	UPDATE [dbo].[Result] 
	SET
		[HoleId] = @HoleId,
        [MatchId] = @MatchId,
        [PlayerId] = @PlayerId,
        [Strikes] = @Strikes,
        [StableFordPoints] = @StableFordPoints,
        [IsDeleted] = @IsDeleted	
	WHERE
		[Id] = @Id	
END

--**********************************************************************************
-- Delete Procedure
--**********************************************************************************
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:23
-- DateModified: 05/21/2014 18:44:23
-- Description:
--*****************************************
CREATE PROCEDURE uspDeleteResult
    @Id int 
AS
BEGIN
	DELETE FROM [dbo].[Result] 
	WHERE
		[Id] = @Id	
END

--**********************************************************************************
-- Get(T)s PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:23
-- DateModified: 05/21/2014 18:44:23
-- Description:
--*****************************************
CREATE PROCEDURE uspGetResults
(
	@whereClause as nvarchar(max) = null,
	@OrderByClause as nvarchar(max) = null
)
AS
BEGIN
	DECLARE @MegaString nvarchar(max);
	set @MegaString = N'SELECT ' + '[Id], '+
        '[HoleId], '+
        '[MatchId], '+
        '[PlayerId], '+
        '[Strikes], '+
        '[StableFordPoints], '+
        '[IsDeleted] '+
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
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:23
-- DateModified: 05/21/2014 18:44:23
-- Description:
--*****************************************
CREATE PROCEDURE uspLogicalDeleteResult
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


--**********************************************************************************
-- GetById PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:19
-- DateModified: 05/21/2014 18:44:19
-- Description:
--*****************************************
CREATE PROCEDURE uspGetPlayerById
	@Id int
AS
BEGIN
	SELECT [Id],
        [License],
        [Alias],
        [Phone],
        [RealHP],
        [GameHP],
        [IsDeleted]	
    FROM [dbo].[Player] 
	WHERE [Id] = @Id AND
		  [IsDeleted] = 0
END

--**********************************************************************************
-- GetAll PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:19
-- DateModified: 05/21/2014 18:44:19
-- Description:
--*****************************************
CREATE PROCEDURE uspGetAllPlayer
AS
BEGIN
	SELECT [Id],
        [License],
        [Alias],
        [Phone],
        [RealHP],
        [GameHP],
        [IsDeleted]	
    FROM [dbo].[Player] 
	WHERE [IsDeleted] = 0
END

--**********************************************************************************
-- Insert PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:19
-- DateModified: 05/21/2014 18:44:19
-- Description:
--*****************************************
CREATE PROCEDURE uspInsertPlayer
    @License nvarchar(50),
    @Alias nvarchar(50),
    @Phone nvarchar(50),
    @RealHP float,
    @GameHP float,
    @IsDeleted bit,
    @Id int output 
AS
BEGIN
	INSERT INTO [dbo].[Player] 
	(
		[License],
        [Alias],
        [Phone],
        [RealHP],
        [GameHP],
        [IsDeleted]	
    ) 
    VALUES 
    (
		@License,
        @Alias,
        @Phone,
        @RealHP,
        @GameHP,
        @IsDeleted 
    )
	SET NOCOUNT ON
    
	-- Return Id value of the new row
	set @Id = scope_identity()
END
	
--**********************************************************************************
-- Update PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:19
-- DateModified: 05/21/2014 18:44:19
-- Description:
--*****************************************
CREATE PROCEDURE uspUpdatePlayer
    @Id int,
    @License nvarchar(50),
    @Alias nvarchar(50),
    @Phone nvarchar(50),
    @RealHP float,
    @GameHP float,
    @IsDeleted bit 
AS
BEGIN
	UPDATE [dbo].[Player] 
	SET
		[License] = @License,
        [Alias] = @Alias,
        [Phone] = @Phone,
        [RealHP] = @RealHP,
        [GameHP] = @GameHP,
        [IsDeleted] = @IsDeleted	
	WHERE
		[Id] = @Id	
END

--**********************************************************************************
-- Delete Procedure
--**********************************************************************************
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:19
-- DateModified: 05/21/2014 18:44:19
-- Description:
--*****************************************
CREATE PROCEDURE uspDeletePlayer
    @Id int 
AS
BEGIN
	DELETE FROM [dbo].[Player] 
	WHERE
		[Id] = @Id	
END

--**********************************************************************************
-- Get(T)s PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:20
-- DateModified: 05/21/2014 18:44:20
-- Description:
--*****************************************
CREATE PROCEDURE uspGetPlayers
(
	@whereClause as nvarchar(max) = null,
	@OrderByClause as nvarchar(max) = null
)
AS
BEGIN
	DECLARE @MegaString nvarchar(max);
	set @MegaString = N'SELECT ' + '[Id], '+
        '[License], '+
        '[Alias], '+
        '[Phone], '+
        '[RealHP], '+
        '[GameHP], '+
        '[IsDeleted] '+
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
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:20
-- DateModified: 05/21/2014 18:44:20
-- Description:
--*****************************************
CREATE PROCEDURE uspLogicalDeletePlayer
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


--**********************************************************************************
-- GetById PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:18
-- DateModified: 05/21/2014 18:44:18
-- Description:
--*****************************************
CREATE PROCEDURE uspGetMatchById
	@Id int
AS
BEGIN
	SELECT [Id],
        [TournamentId],
        [FieldId],
        [Date],
        [IsDeleted],
        [IsTournament]	
    FROM [dbo].[Match] 
	WHERE [Id] = @Id AND
		  [IsDeleted] = 0
END

--**********************************************************************************
-- GetAll PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:18
-- DateModified: 05/21/2014 18:44:18
-- Description:
--*****************************************
CREATE PROCEDURE uspGetAllMatch
AS
BEGIN
	SELECT [Id],
        [TournamentId],
        [FieldId],
        [Date],
        [IsDeleted],
        [IsTournament]	
    FROM [dbo].[Match] 
	WHERE [IsDeleted] = 0
END

--**********************************************************************************
-- Insert PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:18
-- DateModified: 05/21/2014 18:44:18
-- Description:
--*****************************************
CREATE PROCEDURE uspInsertMatch
    @TournamentId int,
    @FieldId int,
    @Date datetime,
    @IsDeleted bit,
    @IsTournament bit,
    @Id int output 
AS
BEGIN
	INSERT INTO [dbo].[Match] 
	(
		[TournamentId],
        [FieldId],
        [Date],
        [IsDeleted],
        [IsTournament]	
    ) 
    VALUES 
    (
		@TournamentId,
        @FieldId,
        @Date,
        @IsDeleted,
        @IsTournament 
    )
	SET NOCOUNT ON
    
	-- Return Id value of the new row
	set @Id = scope_identity()
END
	
--**********************************************************************************
-- Update PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:19
-- DateModified: 05/21/2014 18:44:19
-- Description:
--*****************************************
CREATE PROCEDURE uspUpdateMatch
    @Id int,
    @TournamentId int,
    @FieldId int,
    @Date datetime,
    @IsDeleted bit,
    @IsTournament bit 
AS
BEGIN
	UPDATE [dbo].[Match] 
	SET
		[TournamentId] = @TournamentId,
        [FieldId] = @FieldId,
        [Date] = @Date,
        [IsDeleted] = @IsDeleted,
        [IsTournament] = @IsTournament	
	WHERE
		[Id] = @Id	
END

--**********************************************************************************
-- Delete Procedure
--**********************************************************************************
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:19
-- DateModified: 05/21/2014 18:44:19
-- Description:
--*****************************************
CREATE PROCEDURE uspDeleteMatch
    @Id int 
AS
BEGIN
	DELETE FROM [dbo].[Match] 
	WHERE
		[Id] = @Id	
END

--**********************************************************************************
-- Get(T)s PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:19
-- DateModified: 05/21/2014 18:44:19
-- Description:
--*****************************************
CREATE PROCEDURE uspGetMatchs
(
	@whereClause as nvarchar(max) = null,
	@OrderByClause as nvarchar(max) = null
)
AS
BEGIN
	DECLARE @MegaString nvarchar(max);
	set @MegaString = N'SELECT ' + '[Id], '+
        '[TournamentId], '+
        '[FieldId], '+
        '[Date], '+
        '[IsDeleted], '+
        '[IsTournament] '+
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
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:19
-- DateModified: 05/21/2014 18:44:19
-- Description:
--*****************************************
CREATE PROCEDURE uspLogicalDeleteMatch
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


--**********************************************************************************
-- GetById PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:17
-- DateModified: 05/21/2014 18:44:17
-- Description:
--*****************************************
CREATE PROCEDURE uspGetHoleById
	@Id int
AS
BEGIN
	SELECT [Id],
        [FieldId],
        [Handicap],
        [Distance],
        [IsDeleted]	
    FROM [dbo].[Hole] 
	WHERE [Id] = @Id AND
		  [IsDeleted] = 0
END

--**********************************************************************************
-- GetAll PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:18
-- DateModified: 05/21/2014 18:44:18
-- Description:
--*****************************************
CREATE PROCEDURE uspGetAllHole
AS
BEGIN
	SELECT [Id],
        [FieldId],
        [Handicap],
        [Distance],
        [IsDeleted]	
    FROM [dbo].[Hole] 
	WHERE [IsDeleted] = 0
END

--**********************************************************************************
-- Insert PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:18
-- DateModified: 05/21/2014 18:44:18
-- Description:
--*****************************************
CREATE PROCEDURE uspInsertHole
    @FieldId int,
    @Handicap int,
    @Distance int,
    @IsDeleted bit,
    @Id int output 
AS
BEGIN
	INSERT INTO [dbo].[Hole] 
	(
		[FieldId],
        [Handicap],
        [Distance],
        [IsDeleted]	
    ) 
    VALUES 
    (
		@FieldId,
        @Handicap,
        @Distance,
        @IsDeleted 
    )
	SET NOCOUNT ON
    
	-- Return Id value of the new row
	set @Id = scope_identity()
END
	
--**********************************************************************************
-- Update PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:18
-- DateModified: 05/21/2014 18:44:18
-- Description:
--*****************************************
CREATE PROCEDURE uspUpdateHole
    @Id int,
    @FieldId int,
    @Handicap int,
    @Distance int,
    @IsDeleted bit 
AS
BEGIN
	UPDATE [dbo].[Hole] 
	SET
		[FieldId] = @FieldId,
        [Handicap] = @Handicap,
        [Distance] = @Distance,
        [IsDeleted] = @IsDeleted	
	WHERE
		[Id] = @Id	
END

--**********************************************************************************
-- Delete Procedure
--**********************************************************************************
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:18
-- DateModified: 05/21/2014 18:44:18
-- Description:
--*****************************************
CREATE PROCEDURE uspDeleteHole
    @Id int 
AS
BEGIN
	DELETE FROM [dbo].[Hole] 
	WHERE
		[Id] = @Id	
END

--**********************************************************************************
-- Get(T)s PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:18
-- DateModified: 05/21/2014 18:44:18
-- Description:
--*****************************************
CREATE PROCEDURE uspGetHoles
(
	@whereClause as nvarchar(max) = null,
	@OrderByClause as nvarchar(max) = null
)
AS
BEGIN
	DECLARE @MegaString nvarchar(max);
	set @MegaString = N'SELECT ' + '[Id], '+
        '[FieldId], '+
        '[Handicap], '+
        '[Distance], '+
        '[IsDeleted] '+
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
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:18
-- DateModified: 05/21/2014 18:44:18
-- Description:
--*****************************************
CREATE PROCEDURE uspLogicalDeleteHole
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

--**********************************************************************************
-- GetById PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:10
-- DateModified: 05/21/2014 18:44:10
-- Description:
--*****************************************
CREATE PROCEDURE uspGetFieldById
	@Id int
AS
BEGIN
	SELECT [Id],
        [Name],
        [Address],
        [City],
        [Province],
        [Web],
        [Email],
        [Phone],
        [IsDeleted]	
    FROM [dbo].[Field] 
	WHERE [Id] = @Id AND
		  [IsDeleted] = 0
END

--**********************************************************************************
-- GetAll PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:13
-- DateModified: 05/21/2014 18:44:13
-- Description:
--*****************************************
CREATE PROCEDURE uspGetAllField
AS
BEGIN
	SELECT [Id],
        [Name],
        [Address],
        [City],
        [Province],
        [Web],
        [Email],
        [Phone],
        [IsDeleted]	
    FROM [dbo].[Field] 
	WHERE [IsDeleted] = 0
END

--**********************************************************************************
-- Insert PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:13
-- DateModified: 05/21/2014 18:44:13
-- Description:
--*****************************************
CREATE PROCEDURE uspInsertField
    @Name nvarchar(50),
    @Address nvarchar(50),
    @City nvarchar(50),
    @Province nvarchar(50),
    @Web nvarchar(50),
    @Email nvarchar(50),
    @Phone nvarchar(50),
    @IsDeleted bit,
    @Id int output 
AS
BEGIN
	INSERT INTO [dbo].[Field] 
	(
		[Name],
        [Address],
        [City],
        [Province],
        [Web],
        [Email],
        [Phone],
        [IsDeleted]	
    ) 
    VALUES 
    (
		@Name,
        @Address,
        @City,
        @Province,
        @Web,
        @Email,
        @Phone,
        @IsDeleted 
    )
	SET NOCOUNT ON
    
	-- Return Id value of the new row
	set @Id = scope_identity()
END
	
--**********************************************************************************
-- Update PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:17
-- DateModified: 05/21/2014 18:44:17
-- Description:
--*****************************************
CREATE PROCEDURE uspUpdateField
    @Id int,
    @Name nvarchar(50),
    @Address nvarchar(50),
    @City nvarchar(50),
    @Province nvarchar(50),
    @Web nvarchar(50),
    @Email nvarchar(50),
    @Phone nvarchar(50),
    @IsDeleted bit 
AS
BEGIN
	UPDATE [dbo].[Field] 
	SET
		[Name] = @Name,
        [Address] = @Address,
        [City] = @City,
        [Province] = @Province,
        [Web] = @Web,
        [Email] = @Email,
        [Phone] = @Phone,
        [IsDeleted] = @IsDeleted	
	WHERE
		[Id] = @Id	
END

--**********************************************************************************
-- Delete Procedure
--**********************************************************************************
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:17
-- DateModified: 05/21/2014 18:44:17
-- Description:
--*****************************************
CREATE PROCEDURE uspDeleteField
    @Id int 
AS
BEGIN
	DELETE FROM [dbo].[Field] 
	WHERE
		[Id] = @Id	
END

--**********************************************************************************
-- Get(T)s PROCEDURE
--**********************************************************************************
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:17
-- DateModified: 05/21/2014 18:44:17
-- Description:
--*****************************************
CREATE PROCEDURE uspGetFields
(
	@whereClause as nvarchar(max) = null,
	@OrderByClause as nvarchar(max) = null
)
AS
BEGIN
	DECLARE @MegaString nvarchar(max);
	set @MegaString = N'SELECT ' + '[Id], '+
        '[Name], '+
        '[Address], '+
        '[City], '+
        '[Province], '+
        '[Web], '+
        '[Email], '+
        '[Phone], '+
        '[IsDeleted] '+
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
SET QUOTED_IDENTIFIER ON
GO
--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:17
-- DateModified: 05/21/2014 18:44:17
-- Description:
--*****************************************
CREATE PROCEDURE uspLogicalDeleteField
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

