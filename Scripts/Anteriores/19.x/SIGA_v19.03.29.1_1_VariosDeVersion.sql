PRINT ''
PRINT '1. Tabla MovilRutasListasDePrecios: Agrego Campo PorDefecto .'

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
ALTER TABLE dbo.MovilRutasListasDePrecios ADD PorDefecto  bit NULL
GO
COMMIT
UPDATE MovilRutasListasDePrecios SET PorDefecto  = 1;
ALTER TABLE dbo.MovilRutasListasDePrecios ALTER COLUMN PorDefecto bit NOT NULL
GO


PRINT ''
PRINT '2. Parametros Preventa Importa Descuento desdoblado.'
MERGE INTO Parametros AS P
        USING (SELECT 'PREVENTAV2IMPORTADESCUENTOSPEDIDOSPDA' AS IdParametro, ValorParametro, DescripcionParametro + ' Pedidos PDA' DescripcionParametro FROM Parametros WHERE IdParametro = 'PREVENTAV2IMPORTADESCUENTOS' UNION
               SELECT 'PREVENTAV2IMPORTADESCUENTOSSIMOVILWEB' AS IdParametro, ValorParametro, DescripcionParametro + ' Simovil Web' DescripcionParametro FROM Parametros WHERE IdParametro = 'PREVENTAV2IMPORTADESCUENTOS') AS PT ON P.IdParametro = PT.IdParametro
    WHEN MATCHED THEN
        UPDATE SET P.ValorParametro = PT.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL, PT.DescripcionParametro)
;

DELETE Parametros WHERE IdParametro = 'PREVENTAV2IMPORTADESCUENTOS';
