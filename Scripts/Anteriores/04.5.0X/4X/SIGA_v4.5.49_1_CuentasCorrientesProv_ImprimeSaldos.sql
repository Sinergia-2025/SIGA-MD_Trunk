
PRINT '1. Agrego CuentasCorrientesProv.ImprimeSaldos'
;

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
ALTER TABLE dbo.CuentasCorrientesProv ADD ImprimeSaldos bit NULL
GO
ALTER TABLE dbo.CuentasCorrientesProv SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '2. Actualizo CuentasCorrientesProv.ImprimeSaldos con True a los Pagos'
;

UPDATE CuentasCorrientesProv
   SET ImprimeSaldos = 'True'
  FROM CuentasCorrientesProv CC
 INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CC.IdTipoComprobante
 WHERE TC.EsRecibo = 'True'
ALTER TABLE dbo.CuentasCorrientesProv SET (LOCK_ESCALATION = TABLE)
GO
