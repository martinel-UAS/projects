USE [master]
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


