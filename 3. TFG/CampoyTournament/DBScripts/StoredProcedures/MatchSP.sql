

--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/21/2014 18:44:18
-- DateModified: 05/21/2014 18:44:18
-- Description: CAUTION: THIS SCRIPT REMOVE ALL STORED PROCEDURES FROM AN ENTITY
--*****************************************

--**********************************************************************************
-- DROP PROCEDURES
--**********************************************************************************
DROP PROCEDURE dbo.uspGetMatchById
GO
DROP PROCEDURE dbo.uspGetAllMatch
GO
DROP PROCEDURE dbo.uspInsertMatch
GO
DROP PROCEDURE dbo.uspUpdateMatch
GO
DROP PROCEDURE dbo.uspDeleteMatch
GO
DROP PROCEDURE dbo.uspGetMatchs
GO
DROP PROCEDURE dbo.uspLogicalDeleteMatch
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
