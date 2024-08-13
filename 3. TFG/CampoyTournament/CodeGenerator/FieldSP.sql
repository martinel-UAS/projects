


--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/07/2014 19:58:18
-- DateModified: 05/07/2014 19:58:18
-- Description: CAUTION: THIS SCRIPT REMOVE ALL STORED PROCEDURES FROM AN ENTITY
--*****************************************

--**********************************************************************************
-- DROP PROCEDURES
--**********************************************************************************
DROP PROCEDURE dbo.uspGetFieldById
GO
DROP PROCEDURE dbo.uspGetAllField
GO
DROP PROCEDURE dbo.uspInsertField
GO
DROP PROCEDURE dbo.uspUpdateField
GO
DROP PROCEDURE dbo.uspDeleteField
GO
DROP PROCEDURE dbo.uspGetFields
GO
DROP PROCEDURE dbo.uspLogicalDeleteField
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
-- DateCreated : 05/07/2014 19:58:18
-- DateModified: 05/07/2014 19:58:18
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
-- DateCreated : 05/07/2014 19:58:18
-- DateModified: 05/07/2014 19:58:18
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
-- DateCreated : 05/07/2014 19:58:19
-- DateModified: 05/07/2014 19:58:19
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
-- DateCreated : 05/07/2014 19:58:19
-- DateModified: 05/07/2014 19:58:19
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
-- DateCreated : 05/07/2014 19:58:19
-- DateModified: 05/07/2014 19:58:19
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
-- DateCreated : 05/07/2014 19:58:19
-- DateModified: 05/07/2014 19:58:19
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
-- DateCreated : 05/07/2014 19:58:19
-- DateModified: 05/07/2014 19:58:19
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
