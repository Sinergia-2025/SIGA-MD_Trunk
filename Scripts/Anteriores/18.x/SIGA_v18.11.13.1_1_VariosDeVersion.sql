
PRINT ''
PRINT '1. Tabla TiposComprobantes: Seteo que no controle TOpe CF a GrabaLibro NO.'
GO

UPDATE TiposComprobantes 
   SET ControlaTopeConsumidorFinal = 'False'
 WHERE Tipo = 'VENTAS'
   AND GrabaLibro = 'False'
   AND AfectaCaja = 'True'
   AND CoeficienteStock <> 0
   AND ControlaTopeConsumidorFinal = 'True'
GO


PRINT ''
PRINT '2. Tablas ClientesDirecciones y ProspectosDirecciones: Agrego el Campo DireccionAdicional.'
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
ALTER TABLE dbo.ClientesDirecciones ADD DireccionAdicional varchar(100) NULL
GO
UPDATE ClientesDirecciones SET DireccionAdicional = '';
ALTER TABLE dbo.ClientesDirecciones ALTER COLUMN DireccionAdicional varchar(100) NOT NULL
GO
ALTER TABLE dbo.ClientesDirecciones SET (LOCK_ESCALATION = TABLE)
GO

ALTER TABLE dbo.ProspectosDirecciones ADD DireccionAdicional varchar(100) NULL
GO
UPDATE ProspectosDirecciones SET DireccionAdicional = '';
ALTER TABLE dbo.ProspectosDirecciones ALTER COLUMN DireccionAdicional varchar(100) NOT NULL
GO
ALTER TABLE dbo.ProspectosDirecciones SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '2. Tablas Clientes, AuditoriaClientes, Prospectos y AuditoriaProspectos: Agrego el Campo DireccionAdicional.'
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
ALTER TABLE dbo.Clientes ADD DireccionAdicional varchar(100) NULL
GO
UPDATE Clientes SET DireccionAdicional = '';
ALTER TABLE dbo.Clientes ALTER COLUMN DireccionAdicional varchar(100) NOT NULL
GO
ALTER TABLE dbo.Clientes SET (LOCK_ESCALATION = TABLE)
GO

ALTER TABLE dbo.AuditoriaClientes ADD DireccionAdicional varchar(100) NULL
GO
UPDATE AuditoriaClientes SET DireccionAdicional = '';
ALTER TABLE dbo.AuditoriaClientes ALTER COLUMN DireccionAdicional varchar(100) NOT NULL
GO
ALTER TABLE dbo.AuditoriaClientes SET (LOCK_ESCALATION = TABLE)
GO


ALTER TABLE dbo.AuditoriaProspectos ADD DireccionAdicional varchar(100) NULL
GO
UPDATE AuditoriaProspectos SET DireccionAdicional = '';
ALTER TABLE dbo.AuditoriaProspectos ALTER COLUMN DireccionAdicional varchar(100) NOT NULL
GO
ALTER TABLE dbo.AuditoriaProspectos SET (LOCK_ESCALATION = TABLE)
GO

ALTER TABLE dbo.Prospectos ADD DireccionAdicional varchar(100) NULL
GO
UPDATE Prospectos SET DireccionAdicional = '';
ALTER TABLE dbo.Prospectos ALTER COLUMN DireccionAdicional varchar(100) NOT NULL
GO
ALTER TABLE dbo.Prospectos SET (LOCK_ESCALATION = TABLE)
GO

COMMIT
