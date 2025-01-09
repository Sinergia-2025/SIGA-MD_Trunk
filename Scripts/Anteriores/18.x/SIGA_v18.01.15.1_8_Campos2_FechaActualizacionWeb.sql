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
--   *******  PROSPECTOS  *******
PRINT '10. Renombro columna FechaActualizacion como FechaActualizacionWeb en Prospectos'
EXECUTE sp_rename N'dbo.Prospectos.FechaActualizacion', N'FechaActualizacionWeb', 'COLUMN' 
GO
ALTER TABLE dbo.Prospectos SET (LOCK_ESCALATION = TABLE)
GO

PRINT '10.1 Renombro columna FechaActualizacion como FechaActualizacionWeb en AuditoriaProspectos'
EXECUTE sp_rename N'dbo.AuditoriaProspectos.FechaActualizacion', N'FechaActualizacionWeb', 'COLUMN' 
GO
ALTER TABLE dbo.AuditoriaProspectos SET (LOCK_ESCALATION = TABLE)
GO

COMMIT