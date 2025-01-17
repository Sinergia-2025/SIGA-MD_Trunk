
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
ALTER TABLE dbo.TiposComprobantes ADD
	ComprobantesAsociados varchar(100) NULL
GO
ALTER TABLE dbo.TiposComprobantes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


/* -------- */

UPDATE TiposComprobantes 
  SET ComprobantesAsociados='''ENTREGAMERCAD'',''PRESUP'''
WHERE IdTipoComprobante='COTIZACION'
GO

UPDATE TiposComprobantes 
  SET ComprobantesAsociados='''COTIZACION'''
WHERE IdTipoComprobante='ENTREGAMERCAD'
GO

UPDATE TiposComprobantes 
  SET ComprobantesAsociados='''REMITOTRANSP'',''PRESUP'''
WHERE IdTipoComprobante='FACT'
GO

UPDATE TiposComprobantes 
  SET ComprobantesAsociados='''FACT'''
WHERE IdTipoComprobante='REMITOTRANSP'
GO

