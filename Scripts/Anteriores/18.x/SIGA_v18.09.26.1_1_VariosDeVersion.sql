
PRINT ''
PRINT '1. Tablas Compras/MovimientosCompras: Renombro Neto210 y familiares y pongo los pongo Nullables.'
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
EXECUTE sp_rename N'dbo.Compras.Neto210', N'Neto210_Viejo', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.Compras.Neto105', N'Neto105_Viejo', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.Compras.Neto270', N'Neto270_Viejo', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.Compras.NetoNoGravado', N'NetoNoGravado_Viejo', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.Compras.IVA210', N'IVA210_Viejo', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.Compras.IVA105', N'IVA105_Viejo', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.Compras.IVA270', N'IVA270_Viejo', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.Compras.Bruto210', N'Bruto210_Viejo', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.Compras.Bruto105', N'Bruto105_Viejo', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.Compras.Bruto270', N'Bruto270_Viejo', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.Compras.BrutoNoGravado', N'BrutoNoGravado_Viejo', 'COLUMN' 
GO

ALTER TABLE Compras ALTER COLUMN Neto210_Viejo DECIMAL(14,2) NULL
ALTER TABLE Compras ALTER COLUMN Neto105_Viejo DECIMAL(14,2) NULL
ALTER TABLE Compras ALTER COLUMN Neto270_Viejo DECIMAL(14,2) NULL
ALTER TABLE Compras ALTER COLUMN NetoNoGravado_Viejo DECIMAL(14,2) NULL
ALTER TABLE Compras ALTER COLUMN IVA210_Viejo DECIMAL(14,2) NULL
ALTER TABLE Compras ALTER COLUMN IVA105_Viejo DECIMAL(14,2) NULL
ALTER TABLE Compras ALTER COLUMN IVA270_Viejo DECIMAL(14,2) NULL
ALTER TABLE Compras ALTER COLUMN Bruto210_Viejo DECIMAL(14,2) NULL
ALTER TABLE Compras ALTER COLUMN Bruto105_Viejo DECIMAL(14,2) NULL
ALTER TABLE Compras ALTER COLUMN Bruto270_Viejo DECIMAL(14,2) NULL
ALTER TABLE Compras ALTER COLUMN BrutoNoGravado_Viejo DECIMAL(14,2) NULL

ALTER TABLE Compras ALTER COLUMN IVA210Calculado DECIMAL(14,2) NULL
ALTER TABLE Compras ALTER COLUMN IVA105Calculado DECIMAL(14,2) NULL
ALTER TABLE Compras ALTER COLUMN IVA270Calculado DECIMAL(14,2) NULL

ALTER TABLE dbo.Compras SET (LOCK_ESCALATION = TABLE)
GO


EXECUTE sp_rename N'dbo.MovimientosCompras.Neto210', N'Neto210_Viejo', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.MovimientosCompras.Neto105', N'Neto105_Viejo', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.MovimientosCompras.Neto270', N'Neto270_Viejo', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.MovimientosCompras.NetoNoGravado', N'NetoNoGravado_Viejo', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.MovimientosCompras.IVA210', N'IVA210_Viejo', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.MovimientosCompras.IVA105', N'IVA105_Viejo', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.MovimientosCompras.IVA270', N'IVA270_Viejo', 'COLUMN' 
GO

ALTER TABLE MovimientosCompras ALTER COLUMN Neto210_Viejo DECIMAL(14,2) NULL
ALTER TABLE MovimientosCompras ALTER COLUMN Neto105_Viejo DECIMAL(14,2) NULL
ALTER TABLE MovimientosCompras ALTER COLUMN Neto270_Viejo DECIMAL(14,2) NULL
ALTER TABLE MovimientosCompras ALTER COLUMN NetoNoGravado_Viejo DECIMAL(14,2) NULL
ALTER TABLE MovimientosCompras ALTER COLUMN IVA210_Viejo DECIMAL(14,2) NULL
ALTER TABLE MovimientosCompras ALTER COLUMN IVA105_Viejo DECIMAL(14,2) NULL
ALTER TABLE MovimientosCompras ALTER COLUMN IVA270_Viejo DECIMAL(14,2) NULL

ALTER TABLE dbo.MovimientosCompras SET (LOCK_ESCALATION = TABLE)
GO

COMMIT

PRINT ''
PRINT '2. Tabla Funciones: Desactivo función MovimientosDeCompras.'
GO
UPDATE Funciones
   SET Visible = 0
 WHERE Id = 'MovimientosDeCompras'
GO

PRINT ''
PRINT '3. Tabla Funciones: Activa función MovimientosDeComprasV2.'
GO
UPDATE Funciones
   SET Visible = 1
 WHERE Id = 'MovimientosDeComprasV2'
GO
