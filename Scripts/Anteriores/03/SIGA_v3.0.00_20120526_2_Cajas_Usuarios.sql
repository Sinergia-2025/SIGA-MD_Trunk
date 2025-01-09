
ALTER TABLE [dbo].[CajasDetalle]
    ADD IdUsuario VARCHAR(10) NULL
GO

UPDATE [dbo].[CajasDetalle]
  SET IdUsuario = 'Admin'
GO

ALTER TABLE [dbo].[CajasDetalle]
    ALTER COLUMN IdUsuario VARCHAR(10) NOT NULL
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
ALTER TABLE dbo.Usuarios SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.CajasDetalle ADD CONSTRAINT
	FK_CajasDetalle_Usuarios FOREIGN KEY
	(
	IdUsuario
	) REFERENCES dbo.Usuarios
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.CajasDetalle SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
