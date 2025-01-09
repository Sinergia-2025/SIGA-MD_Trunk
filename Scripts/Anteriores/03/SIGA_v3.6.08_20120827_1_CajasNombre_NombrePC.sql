
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
ALTER TABLE dbo.CajasNombres ADD NombrePC varchar(20) NULL
GO
ALTER TABLE dbo.CajasNombres SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


/* ------------------ */

ALTER TABLE dbo.CajasNombres ALTER COLUMN NombreCaja varchar(30) NOT NULL
GO
