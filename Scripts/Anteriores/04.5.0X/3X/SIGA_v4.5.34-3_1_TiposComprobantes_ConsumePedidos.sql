
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
ALTER TABLE dbo.TiposComprobantes ADD ConsumePedidos bit NULL
GO
UPDATE TiposComprobantes
   SET ConsumePedidos = 0;
UPDATE TiposComprobantes
   SET ConsumePedidos = 1
 WHERE CoeficienteStock < 0
   AND Tipo = 'VENTAS'
   AND AfectaCaja = 1
   AND EsComercial = 1;
ALTER TABLE dbo.TiposComprobantes ALTER COLUMN ConsumePedidos bit NOT NULL
GO
ALTER TABLE dbo.TiposComprobantes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
