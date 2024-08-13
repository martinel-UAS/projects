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

