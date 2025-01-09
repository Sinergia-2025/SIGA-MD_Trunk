
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
ALTER TABLE dbo.TiposComprobantes ADD GeneraContabilidad bit NULL
GO
UPDATE TiposComprobantes
   SET GeneraContabilidad = AfectaCaja
GO
ALTER TABLE dbo.TiposComprobantes ALTER COLUMN GeneraContabilidad bit NOT NULL
GO
ALTER TABLE dbo.TiposComprobantes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

/* --------*/ 

UPDATE TiposComprobantes
   SET GeneraContabilidad = 'False'
WHERE EsAnticipo = 'True' OR (IdTipoComprobante LIKE 'SALDO%' AND CoeficienteStock = 0)
GO


SELECT Tipo, IdTipoComprobante, GeneraContabilidad FROM TiposComprobantes
 ORDER BY 3,1,2
GO
