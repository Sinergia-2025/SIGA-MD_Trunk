IF object_id(N'ExistePKSchema', N'FN') IS NOT NULL
    DROP FUNCTION ExistePKSchema
GO
CREATE FUNCTION ExistePKSchema(@NombrePK VARCHAR(MAX), @NombreSchema VARCHAR(MAX) = 'dbo')
    RETURNS bit
AS
BEGIN
	-- Declare the return variable here
    IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME =@NombrePK AND CONSTRAINT_SCHEMA = @NombreSchema)
        RETURN 1
    RETURN 0
END
GO

IF object_id(N'ExistePK', N'FN') IS NOT NULL
    DROP FUNCTION ExistePK
GO
CREATE FUNCTION ExistePK(@NombrePK VARCHAR(MAX))
    RETURNS bit
AS
BEGIN
	RETURN dbo.ExistePKSchema(@NombrePK, 'dbo')
END
GO
