

--*****************************************
-- Author : Luis Martinez Palomino
-- DateCreated : 05/07/2014 19:58:23
-- DateModified: 05/07/2014 19:58:23
-- Description: CAUTION: THIS SCRIPT REMOVE ALL STORED PROCEDURES FROM AN ENTITY
--*****************************************

--**********************************************************************************
-- DROP PROCEDURES
--**********************************************************************************
DROP PROCEDURE dbo.uspGetTournamentById
GO
DROP PROCEDURE dbo.uspGetAllTournament
GO
DROP PROCEDURE dbo.uspInsertTournament
GO
DROP PROCEDURE dbo.uspUpdateTournament
GO
DROP PROCEDURE dbo.uspDeleteTournament
GO
DROP PROCEDURE dbo.uspGetTournaments
GO
DROP PROCEDURE dbo.uspLogicalDeleteTournament
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
CREATE PROCEDURE uspGetTournamentById
	@Id int
AS
BEGIN
	SELECT [Id],
        [Year],
        [IsDeleted],
        [IsFinished]	
    FROM [dbo].[Tournament] 
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
CREATE PROCEDURE uspGetAllTournament
AS
BEGIN
	SELECT [Id],
        [Year],
        [IsDeleted],
        [IsFinished]	
    FROM [dbo].[Tournament] 
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
CREATE PROCEDURE uspInsertTournament
    @Year int,
    @IsDeleted bit,
    @IsFinished bit,
    @Id int output 
AS
BEGIN
	INSERT INTO [dbo].[Tournament] 
	(
		[Year],
        [IsDeleted],
        [IsFinished]	
    ) 
    VALUES 
    (
		@Year,
        @IsDeleted,
        @IsFinished 
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
CREATE PROCEDURE uspUpdateTournament
    @Id int,
    @Year int,
    @IsDeleted bit,
    @IsFinished bit 
AS
BEGIN
	UPDATE [dbo].[Tournament] 
	SET
		[Year] = @Year,
        [IsDeleted] = @IsDeleted,
        [IsFinished] = @IsFinished	
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
-- DateCreated : 05/07/2014 19:58:24
-- DateModified: 05/07/2014 19:58:24
-- Description:
--*****************************************
CREATE PROCEDURE uspDeleteTournament
    @Id int 
AS
BEGIN
	DELETE FROM [dbo].[Tournament] 
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
-- DateCreated : 05/07/2014 19:58:24
-- DateModified: 05/07/2014 19:58:24
-- Description:
--*****************************************
CREATE PROCEDURE uspGetTournaments
(
	@whereClause as nvarchar(max) = null,
	@OrderByClause as nvarchar(max) = null
)
AS
BEGIN
	DECLARE @MegaString nvarchar(max);
	set @MegaString = N'SELECT ' + '[Id], '+
        '[Year], '+
        '[IsDeleted], '+
        '[IsFinished] '+
    'FROM [dbo].[Tournament] ';
 
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
-- DateCreated : 05/07/2014 19:58:24
-- DateModified: 05/07/2014 19:58:24
-- Description:
--*****************************************
CREATE PROCEDURE uspLogicalDeleteTournament
    @Id int 
AS
BEGIN
	UPDATE [dbo].[Tournament] 
	SET
		[IsDeleted] = 1
	WHERE
		[Id] = @Id	
	SET NOCOUNT ON   
END

--**********************************************************************************
--**********************************************************************************
--**********************************************************************************
