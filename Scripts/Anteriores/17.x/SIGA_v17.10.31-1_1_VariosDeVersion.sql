
PRINT '1. Tabla ProductosProveedores Ajusto ancho CodigoProductoProveedor a 30.'

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
ALTER TABLE dbo.ProductosProveedores ALTER column CodigoProductoProveedor varchar(30) NULL
GO
COMMIT

/* ----------------------------------------------------- */

PRINT ''
PRINT '2. Tabla EstadosPedidos agrego campo Color y lo seteo.'

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
ALTER TABLE dbo.EstadosPedidos ADD Color int NULL
GO
UPDATE EstadosPedidos SET Color = -65536 WHERE IdTipoEstado = 'PENDIENTE'
UPDATE EstadosPedidos SET Color = -256 WHERE IdTipoEstado = 'ANULADO'
UPDATE EstadosPedidos SET Color = -16744448 WHERE IdTipoEstado = 'ENTREGADO'
UPDATE EstadosPedidos SET Color = -16776961 WHERE IdTipoEstado = 'EN PROCESO'
ALTER TABLE dbo.EstadosPedidos ALTER COLUMN Color int NOT NULL
GO
ALTER TABLE dbo.EstadosPedidos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

/* ----------------------------------------------------- */

PRINT ''
PRINT '3. Quito Reportes\ de la configuracion en TiposComprobantesLetras para Compras.'

UPDATE TiposComprobantesLetras
   SET ArchivoAImprimir = REPLACE(TCL.ArchivoAImprimir, 'Reportes\', '')
  FROM TiposComprobantesLetras TCL
 INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = TCL.IdTipoComprobante
 WHERE TC.Tipo = 'COMPRAS'
   AND TCL.ArchivoAImprimir LIKE 'Reportes\%'
   AND TCL.ArchivoAImprimirEmbebido = 0
 GO
 