PRINT ''
PRINT '1. Tabla Bitacora: Nuevo Indice por FechaBitacora y Tipo'
CREATE NONCLUSTERED INDEX IX_FechaBitacora ON dbo.Bitacora
	(FechaBitacora, Tipo) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

PRINT ''
PRINT '2. Tabla Bitacora: Borrar Errores anteriores a 3 meses'
DELETE Bitacora
 WHERE Tipo = 'SucedioError'
   AND FechaBitacora < DATEADD(MONTH, -3, CONVERT(DATE, GETDATE()))

PRINT ''
PRINT '3. Parametrizar los meses a borrar de los errores de bitacora'
DECLARE @idParametro VARCHAR(MAX) = 'LOGINMESESPRESERVARBITACORAERROR'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Login: Meses que se presentan los errores en Bitacora'
DECLARE @valorParametro VARCHAR(MAX) = '3'
--IF dbo.BaseConCuit('20170521014') = 1
--    SET @valor = 'True'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;

