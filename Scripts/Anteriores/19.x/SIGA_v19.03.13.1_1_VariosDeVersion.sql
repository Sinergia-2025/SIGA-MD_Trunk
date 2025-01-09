
PRINT ''
PRINT '1. Tabla ListasDePrecios: Agrego Campo PublicarenWeb'
GO
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ListasDePrecios ADD PublicarenWeb  bit  NULL
GO
UPDATE ListasDePrecios SET PublicarenWeb  = 1;
ALTER TABLE dbo.ListasDePrecios ALTER COLUMN PublicarenWeb bit NOT NULL
GO
COMMIT


PRINT ''
PRINT '2. Ajustar datos Función de Backup'
UPDATE Funciones
   SET Archivo = 'Eniac.SiGA.Win'
 WHERE Id IN ('Backups')
GO


PRINT ''
PRINT '3. Parametro Nuevo BUSCAPRODUCTOPORCODIGOPROVEEDORHABITUAL'
DECLARE @ValorParametro varchar(max) = 'False'

IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                AND P.ValorParametro IN ('30712079459'))
BEGIN
    SET @ValorParametro = 'True'
END

MERGE INTO Parametros AS P
        USING (SELECT 'BUSCAPRODUCTOPORCODIGOPROVEEDORHABITUAL'   AS IdParametro, @ValorParametro     ValorParametro, 'Busca Producto Por Codigo Proveedor Habitual'   AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
    WHEN MATCHED THEN
        UPDATE SET P.ValorParametro = PT.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL, PT.DescripcionParametro)
;
--select * from Parametros where IdParametro='BUSCAPRODUCTOPORCODIGOPROVEEDORHABITUAL'


PRINT ''
PRINT '4. Campo PermiteIngresarPorcentajeDescuentos en tabla MovilRutas'
/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.MovilRutas ADD PermiteIngresarPorcentajeDescuentos bit NULL
GO
UPDATE MovilRutas SET PermiteIngresarPorcentajeDescuentos = 0;
ALTER TABLE dbo.MovilRutas ALTER COLUMN PermiteIngresarPorcentajeDescuentos bit NOT NULL
GO
ALTER TABLE dbo.MovilRutas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
