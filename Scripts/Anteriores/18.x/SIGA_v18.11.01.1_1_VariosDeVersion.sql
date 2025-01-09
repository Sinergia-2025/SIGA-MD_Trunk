
PRINT ''
PRINT '1. Tabla CRMNovedades: Agregar Campo IdUsuarioResponsable.'
GO
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
ALTER TABLE dbo.Usuarios SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.CRMNovedades ADD IdUsuarioResponsable varchar(10) NULL
GO
ALTER TABLE dbo.CRMNovedades ADD CONSTRAINT FK_CRMNovedades_Usuarios_Responsable
    FOREIGN KEY (IdUsuarioResponsable)
    REFERENCES dbo.Usuarios (Id)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION
GO
ALTER TABLE dbo.CRMNovedades SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '2. Tabla CRMEstadosNovedades: Agrego Campo ActualizaUsuarioResponsable.'
GO
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
ALTER TABLE dbo.CRMEstadosNovedades ADD ActualizaUsuarioResponsable bit NULL
GO
UPDATE CRMEstadosNovedades 
   SET ActualizaUsuarioResponsable = 0;

UPDATE CRMEstadosNovedades 
   SET ActualizaUsuarioResponsable = 1 
 WHERE IdTipoNovedad = 'PENDIENTE' AND IdEstadoNovedad IN (408, 402)
ALTER TABLE dbo.CRMEstadosNovedades ALTER COLUMN ActualizaUsuarioResponsable bit NOT NULL
GO
ALTER TABLE dbo.CRMEstadosNovedades SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
