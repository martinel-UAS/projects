

--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:19
-- DateModified: 05/21/2014 18:44:19
-- Description: CAUTION: THIS SCRIPT REMOVE ALL STORED PROCEDURES FROM AN ENTITY
--*****************************************

--**********************************************************************************
-- DROP PROCEDURES
--**********************************************************************************
DROP PROCEDURE dbo.uspGetPlayerById
GO
DROP PROCEDURE dbo.uspGetAllPlayer
GO
DROP PROCEDURE dbo.uspInsertPlayer
GO
DROP PROCEDURE dbo.uspUpdatePlayer
GO
DROP PROCEDURE dbo.uspDeletePlayer
GO
DROP PROCEDURE dbo.uspGetPlayers
GO
DROP PROCEDURE dbo.uspLogicalDeletePlayer
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
