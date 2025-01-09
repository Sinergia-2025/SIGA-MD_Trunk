SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION ExisteFuncion(@idFuncion varchar(max))
    RETURNS bit
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Funciones WHERE Id = @idFuncion)
        RETURN 1
    RETURN 0
END
GO
CREATE FUNCTION BaseConCuit(@cuitEmpresa varchar(max))
    RETURNS bit
AS
BEGIN
    IF EXISTS (SELECT ValorParametro FROM Parametros P
                WHERE P.IdParametro = 'CUITEMPRESA' 
                  AND P.ValorParametro = @cuitEmpresa)
        RETURN 1
    RETURN 0
END
GO