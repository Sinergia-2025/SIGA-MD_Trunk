
PRINT ''
PRINT '1. Tabla Cargos: Agrego campo Cargo Temporal .'
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
ALTER TABLE dbo.Cargos ADD CargoTemporal bit NULL
GO
UPDATE Cargos SET CargoTemporal = 0;
ALTER TABLE dbo.Cargos ALTER COLUMN CargoTemporal bit NOT NULL
GO
COMMIT

PRINT ''
PRINT '2. Funcion Registrar Repartor. Inactivarla salvo para Real Gas.'
GO
IF dbo.BaseConCuit('30715973037') = 0
 BEGIN
		UPDATE Funciones
		   SET EsMenu = 'False'
		     , [Enabled] = 'False'
			 , Visible = 'False'
		 WHERE Id = 'RegistrarReparto'
 END;

