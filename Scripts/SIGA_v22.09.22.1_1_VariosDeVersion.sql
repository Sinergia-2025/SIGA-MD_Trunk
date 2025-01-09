SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

IF object_id(N'ExisteCampoSchema', N'FN') IS NOT NULL
    DROP FUNCTION ExisteCampoSchema
GO
CREATE FUNCTION ExisteCampoSchema(@NombreTabla VARCHAR(MAX), @NombreCampo VARCHAR(MAX), @NombreSchema VARCHAR(MAX))
    RETURNS bit
AS
BEGIN
	-- Declare the return variable here
    IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME = @NombreCampo AND TABLE_NAME = @NombreTabla AND TABLE_SCHEMA = @NombreSchema)
        RETURN 1
    RETURN 0
END
GO
IF object_id(N'ExisteTablaSchema', N'FN') IS NOT NULL
    DROP FUNCTION ExisteTablaSchema
GO
CREATE FUNCTION ExisteTablaSchema(@NombreTabla VARCHAR(MAX), @NombreSchema VARCHAR(MAX) = 'dbo')
    RETURNS bit
AS
BEGIN
	-- Declare the return variable here
    IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = @NombreTabla AND TABLE_SCHEMA = @NombreSchema)
        RETURN 1
    RETURN 0
END
GO
IF object_id(N'ExisteFKSchema', N'FN') IS NOT NULL
    DROP FUNCTION ExisteFKSchema
GO
CREATE FUNCTION ExisteFKSchema(@NombreFK VARCHAR(MAX), @NombreSchema VARCHAR(MAX) = 'dbo')
    RETURNS bit
AS
BEGIN
	-- Declare the return variable here
    IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME =@NombreFK AND CONSTRAINT_SCHEMA = @NombreSchema)
        RETURN 1
    RETURN 0
END
GO

IF object_id(N'ExisteCampo', N'FN') IS NOT NULL
    DROP FUNCTION ExisteCampo
GO
CREATE FUNCTION ExisteCampo (@NombreTabla VARCHAR(MAX), @NombreCampo VARCHAR(MAX))
    RETURNS bit
AS
BEGIN
    RETURN dbo.ExisteCampoSchema(@NombreTabla, @NombreCampo, 'dbo')
END
GO
IF object_id(N'ExisteTabla', N'FN') IS NOT NULL
    DROP FUNCTION ExisteTabla
GO
CREATE FUNCTION ExisteTabla(@NombreTabla VARCHAR(MAX))
    RETURNS bit
AS
BEGIN
    RETURN dbo.ExisteTablaSchema(@NombreTabla, 'dbo')
END
GO
IF object_id(N'ExisteFKSchema', N'FN') IS NOT NULL
    DROP FUNCTION ExisteFKSchema
GO
CREATE FUNCTION ExisteFKSchema(@NombreFK VARCHAR(MAX))
    RETURNS bit
AS
BEGIN
	RETURN dbo.ExisteFKSchema(@NombreFK, 'dbo')
END
GO
