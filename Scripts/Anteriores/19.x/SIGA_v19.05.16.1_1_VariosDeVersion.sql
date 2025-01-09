SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[GetValorParametro](@idParametro varchar(max)) RETURNS VARCHAR(MAX) AS
BEGIN
    DECLARE @valorParametro VARCHAR(MAX)
    SELECT @valorParametro = ValorParametro FROM Parametros P WHERE P.IdParametro = @idParametro
    RETURN @valorParametro
END
GO
CREATE FUNCTION [dbo].[SoyHAR]() RETURNS bit AS
BEGIN
    IF EXISTS (SELECT ValorParametro FROM Parametros P
                WHERE P.IdParametro = 'CUITEMPRESA' 
                  AND P.ValorParametro = '33711345499')
        RETURN 1
    RETURN 0
END
