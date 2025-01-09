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
ALTER TABLE dbo.Clientes ADD Facebook varchar(150) NULL
ALTER TABLE dbo.Clientes ADD Instagram varchar(150) NULL
ALTER TABLE dbo.Clientes ADD Twitter varchar(150) NULL
GO
ALTER TABLE dbo.Clientes SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.AuditoriaClientes ADD Facebook varchar(150) NULL
ALTER TABLE dbo.AuditoriaClientes ADD Instagram varchar(150) NULL
ALTER TABLE dbo.AuditoriaClientes ADD Twitter varchar(150) NULL
GO
ALTER TABLE dbo.AuditoriaClientes SET (LOCK_ESCALATION = TABLE)
GO

ALTER TABLE dbo.Prospectos ADD Facebook varchar(150) NULL
ALTER TABLE dbo.Prospectos ADD Instagram varchar(150) NULL
ALTER TABLE dbo.Prospectos ADD Twitter varchar(150) NULL
GO
ALTER TABLE dbo.Prospectos SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.AuditoriaProspectos ADD Facebook varchar(150) NULL
ALTER TABLE dbo.AuditoriaProspectos ADD Instagram varchar(150) NULL
ALTER TABLE dbo.AuditoriaProspectos ADD Twitter varchar(150) NULL
GO
ALTER TABLE dbo.AuditoriaProspectos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
