
/* Para evitar posibles problemas de pérdida de datos, debe revisar este script detalladamente antes de ejecutarlo fuera del contexto del diseñador de base de datos.*/
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
ALTER TABLE dbo.TiposComprobantes ADD GeneraObservConInvocados bit NULL
GO
ALTER TABLE dbo.TiposComprobantes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

/* --------------------------------------------- */

UPDATE TiposComprobantes
   SET GeneraObservConInvocados = 'False'
GO

UPDATE TiposComprobantes
   SET GeneraObservConInvocados = 'True'
 WHERE Tipo = 'VENTAS' 
   AND CantidadMaximaItemsObserv > 0
   AND IdTipoComprobante NOT IN (SELECT IdTipoComprobante FROM TiposComprobantesLetras)
GO

UPDATE TiposComprobantes 
   SET GeneraObservConInvocados = 'True'
 WHERE Tipo = 'VENTAS' 
   AND IdTipoComprobante IN 
      (SELECT IdTipoComprobante FROM TiposComprobantesLetras WHERE CantidadItemsObservaciones > 0)
GO

ALTER TABLE dbo.TiposComprobantes ALTER COLUMN GeneraObservConInvocados bit NOT NULL
GO
