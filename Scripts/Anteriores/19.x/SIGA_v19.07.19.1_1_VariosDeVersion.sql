
PRINT ''
PRINT '1. Tabla Transportistas: Agrego campos Cantidad de Kilos Maximo y Cantidad Palets Maximo.'
GO
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
ALTER TABLE dbo.Transportistas ADD KilosMaximo decimal(10,3) null
ALTER TABLE dbo.Transportistas ADD PaletsMaximo  integer null
GO
UPDATE Transportistas SET KilosMaximo  = 0,PaletsMaximo  = 0;
ALTER TABLE dbo.Transportistas ALTER COLUMN KilosMaximo decimal(10,3) NOT NULL
ALTER TABLE dbo.Transportistas ALTER COLUMN PaletsMaximo integer NOT NULL
GO
COMMIT
