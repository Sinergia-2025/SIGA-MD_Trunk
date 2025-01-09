
PRINT ''
PRINT '1. Tabla Clientes: Agregar campo BackupNroVersion.'
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
ALTER TABLE dbo.Clientes ADD BackupNroVersion varchar(15) NULL
GO
ALTER TABLE dbo.Clientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '2. Tabla AuditoriaClientes: Agregar campo BackupNroVersion.'
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
ALTER TABLE dbo.AuditoriaClientes ADD BackupNroVersion varchar(15) NULL
GO
ALTER TABLE dbo.AuditoriaClientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '3. Tabla Prospectos: Agregar campo BackupNroVersion.'
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
ALTER TABLE dbo.Prospectos ADD BackupNroVersion varchar(15) NULL
GO
ALTER TABLE dbo.Prospectos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '4. Tabla AuditoriaProspectos: Agregar campo BackupNroVersion.'
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
ALTER TABLE dbo.AuditoriaProspectos ADD BackupNroVersion varchar(15) NULL
GO
ALTER TABLE dbo.AuditoriaProspectos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

