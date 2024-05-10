

--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/07/2014 19:58:23
-- DateModified: 05/07/2014 19:58:23
-- Description: CAUTION: THIS SCRIPT REMOVE ALL STORED PROCEDURES FROM AN ENTITY
--*****************************************

--**********************************************************************************
-- DROP PROCEDURES
--**********************************************************************************
DROP PROCEDURE dbo.uspGetRoleById
GO
DROP PROCEDURE dbo.uspGetAllRole
GO
DROP PROCEDURE dbo.uspInsertRole
GO
DROP PROCEDURE dbo.uspUpdateRole
GO
DROP PROCEDURE dbo.uspDeleteRole
GO
DROP PROCEDURE dbo.uspGetRoles
GO
DROP PROCEDURE dbo.uspLogicalDeleteRole
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
-- DateCreated : 05/07/2014 19:58:23
-- DateModified: 05/07/2014 19:58:23
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
-- DateCreated : 05/07/2014 19:58:23
-- DateModified: 05/07/2014 19:58:23
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
-- DateCreated : 05/07/2014 19:58:23
-- DateModified: 05/07/2014 19:58:23
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
-- DateCreated : 05/07/2014 19:58:23
-- DateModified: 05/07/2014 19:58:23
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
-- DateCreated : 05/07/2014 19:58:23
-- DateModified: 05/07/2014 19:58:23
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
-- DateCreated : 05/07/2014 19:58:23
-- DateModified: 05/07/2014 19:58:23
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
-- DateCreated : 05/07/2014 19:58:23
-- DateModified: 05/07/2014 19:58:23
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
