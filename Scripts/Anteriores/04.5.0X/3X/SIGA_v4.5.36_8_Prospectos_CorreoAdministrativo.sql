
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
ALTER TABLE dbo.Prospectos ADD CorreoAdministrativo varchar(500) NULL
GO
ALTER TABLE dbo.Prospectos SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.AuditoriaProspectos ADD CorreoAdministrativo varchar(500) NULL
GO
ALTER TABLE dbo.AuditoriaProspectos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT