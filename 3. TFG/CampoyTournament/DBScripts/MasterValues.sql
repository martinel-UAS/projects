USE [CampoyTournament]
GO

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


