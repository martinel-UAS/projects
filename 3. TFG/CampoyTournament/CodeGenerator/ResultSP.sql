

--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/07/2014 19:58:22
-- DateModified: 05/07/2014 19:58:22
-- Description: CAUTION: THIS SCRIPT REMOVE ALL STORED PROCEDURES FROM AN ENTITY
--*****************************************

--**********************************************************************************
-- DROP PROCEDURES
--**********************************************************************************
DROP PROCEDURE dbo.uspGetResultById
GO
DROP PROCEDURE dbo.uspGetAllResult
GO
DROP PROCEDURE dbo.uspInsertResult
GO
DROP PROCEDURE dbo.uspUpdateResult
GO
DROP PROCEDURE dbo.uspDeleteResult
GO
DROP PROCEDURE dbo.uspGetResults
GO
DROP PROCEDURE dbo.uspLogicalDeleteResult
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
-- DateCreated : 05/07/2014 19:58:22
-- DateModified: 05/07/2014 19:58:22
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
        [Handicap],
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
-- DateCreated : 05/07/2014 19:58:22
-- DateModified: 05/07/2014 19:58:22
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
        [Handicap],
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
-- DateCreated : 05/07/2014 19:58:22
-- DateModified: 05/07/2014 19:58:22
-- Description:
--*****************************************
CREATE PROCEDURE uspInsertResult
    @HoleId int,
    @MatchId int,
    @PlayerId int,
    @Strikes int,
    @Handicap float,
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
        [Handicap],
        [IsDeleted]	
    ) 
    VALUES 
    (
		@HoleId,
        @MatchId,
        @PlayerId,
        @Strikes,
        @Handicap,
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
-- DateCreated : 05/07/2014 19:58:22
-- DateModified: 05/07/2014 19:58:22
-- Description:
--*****************************************
CREATE PROCEDURE uspUpdateResult
    @Id int,
    @HoleId int,
    @MatchId int,
    @PlayerId int,
    @Strikes int,
    @Handicap float,
    @IsDeleted bit 
AS
BEGIN
	UPDATE [dbo].[Result] 
	SET
		[HoleId] = @HoleId,
        [MatchId] = @MatchId,
        [PlayerId] = @PlayerId,
        [Strikes] = @Strikes,
        [Handicap] = @Handicap,
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
-- DateCreated : 05/07/2014 19:58:22
-- DateModified: 05/07/2014 19:58:22
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
-- DateCreated : 05/07/2014 19:58:22
-- DateModified: 05/07/2014 19:58:22
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
        '[Handicap], '+
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
-- DateCreated : 05/07/2014 19:58:22
-- DateModified: 05/07/2014 19:58:22
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
