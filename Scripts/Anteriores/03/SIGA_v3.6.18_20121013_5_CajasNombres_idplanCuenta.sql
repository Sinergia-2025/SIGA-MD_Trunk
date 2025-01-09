
--ALTER TABLE Cajas DROP COLUMN IdPlanCuenta
--GO

ALTER TABLE CajasNombres ADD IdPlanCuenta [int] NULL
GO

UPDATE CajasNombres 
   SET IdPlanCuenta = 1
  WHERE IdPlanCuenta IS NULL
GO

ALTER TABLE CajasNombres ALTER COLUMN IdPlanCuenta [int] NOT NULL
GO


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
ALTER TABLE dbo.ContabilidadPlanes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.CajasNombres ADD CONSTRAINT
	FK_CajasNombres_ContabilidadPlanes FOREIGN KEY
	(
	IdPlanCuenta
	) REFERENCES dbo.ContabilidadPlanes
	(
	IdPlanCuenta
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.CajasNombres SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
