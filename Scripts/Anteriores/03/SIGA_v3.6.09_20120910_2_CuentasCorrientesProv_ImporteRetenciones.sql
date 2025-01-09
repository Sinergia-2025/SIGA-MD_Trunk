
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
ALTER TABLE dbo.CuentasCorrientesProv ADD ImporteRetenciones decimal(14, 4) NULL
GO
ALTER TABLE dbo.CuentasCorrientesProv SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

/* ------------------------------- */

UPDATE dbo.CuentasCorrientesProv 
   SET ImporteRetenciones = 0
GO

ALTER TABLE dbo.CuentasCorrientesProv ALTER COLUMN ImporteRetenciones decimal(14, 4) NOT NULL
GO
