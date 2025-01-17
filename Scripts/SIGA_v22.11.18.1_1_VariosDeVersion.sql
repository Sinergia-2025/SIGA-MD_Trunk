SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

IF object_id(N'ExisteIX', N'FN') IS NOT NULL
    DROP FUNCTION ExisteIX
GO
CREATE FUNCTION [dbo].[ExisteIX](@NombreIX VARCHAR(MAX))
    RETURNS bit
AS
BEGIN
    IF EXISTS (SELECT * FROM SYS.INDEXES WHERE name=@NombreIX)
        RETURN 1
	RETURN 0
END
GO
