

--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:17
-- DateModified: 05/21/2014 18:44:17
-- Description: CAUTION: THIS SCRIPT REMOVE ALL STORED PROCEDURES FROM AN ENTITY
--*****************************************

--**********************************************************************************
-- DROP PROCEDURES
--**********************************************************************************
DROP PROCEDURE dbo.uspGetHoleById
GO
DROP PROCEDURE dbo.uspGetAllHole
GO
DROP PROCEDURE dbo.uspInsertHole
GO
DROP PROCEDURE dbo.uspUpdateHole
GO
DROP PROCEDURE dbo.uspDeleteHole
GO
DROP PROCEDURE dbo.uspGetHoles
GO
DROP PROCEDURE dbo.uspLogicalDeleteHole
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
