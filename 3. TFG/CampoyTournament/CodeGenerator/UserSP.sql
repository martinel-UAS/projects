

--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/07/2014 19:58:24
-- DateModified: 05/07/2014 19:58:24
-- Description: CAUTION: THIS SCRIPT REMOVE ALL STORED PROCEDURES FROM AN ENTITY
--*****************************************

--**********************************************************************************
-- DROP PROCEDURES
--**********************************************************************************
DROP PROCEDURE dbo.uspGetUserById
GO
DROP PROCEDURE dbo.uspGetAllUser
GO
DROP PROCEDURE dbo.uspInsertUser
GO
DROP PROCEDURE dbo.uspUpdateUser
GO
DROP PROCEDURE dbo.uspDeleteUser
GO
DROP PROCEDURE dbo.uspGetUsers
GO
DROP PROCEDURE dbo.uspLogicalDeleteUser
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
-- DateCreated : 05/07/2014 19:58:24
-- DateModified: 05/07/2014 19:58:24
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
-- DateCreated : 05/07/2014 19:58:24
-- DateModified: 05/07/2014 19:58:24
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
-- DateCreated : 05/07/2014 19:58:24
-- DateModified: 05/07/2014 19:58:24
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
-- DateCreated : 05/07/2014 19:58:24
-- DateModified: 05/07/2014 19:58:24
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
-- DateCreated : 05/07/2014 19:58:25
-- DateModified: 05/07/2014 19:58:25
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
-- DateCreated : 05/07/2014 19:58:25
-- DateModified: 05/07/2014 19:58:25
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
-- DateCreated : 05/07/2014 19:58:25
-- DateModified: 05/07/2014 19:58:25
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
