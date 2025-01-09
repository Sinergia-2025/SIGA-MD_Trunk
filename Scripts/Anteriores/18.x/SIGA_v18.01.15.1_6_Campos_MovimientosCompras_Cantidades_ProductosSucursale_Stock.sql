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
ALTER TABLE dbo.MovimientosComprasProductos ADD CantidadReservado decimal(12, 2) NULL
ALTER TABLE dbo.MovimientosComprasProductos ADD CantidadDefectuoso decimal(12, 2) NULL
ALTER TABLE dbo.MovimientosComprasProductos ADD CantidadFuturo decimal(12, 2) NULL
ALTER TABLE dbo.MovimientosComprasProductos ADD CantidadFuturoReservado decimal(12, 2) NULL
GO
UPDATE MovimientosComprasProductos
   SET CantidadReservado = 0
     , CantidadDefectuoso = 0
     , CantidadFuturo = 0
     , CantidadFuturoReservado = 0;
ALTER TABLE dbo.MovimientosComprasProductos ALTER COLUMN CantidadReservado decimal(12, 2) NOT NULL
ALTER TABLE dbo.MovimientosComprasProductos ALTER COLUMN CantidadDefectuoso decimal(12, 2) NOT NULL
ALTER TABLE dbo.MovimientosComprasProductos ALTER COLUMN CantidadFuturo decimal(12, 2) NOT NULL
ALTER TABLE dbo.MovimientosComprasProductos ALTER COLUMN CantidadFuturoReservado decimal(12, 2) NOT NULL
GO
ALTER TABLE dbo.MovimientosComprasProductos SET (LOCK_ESCALATION = TABLE)
GO

ALTER TABLE dbo.ProductosSucursales ADD StockDefectuoso decimal(12, 2) NULL
ALTER TABLE dbo.ProductosSucursales ADD StockFuturo decimal(12, 2) NULL
ALTER TABLE dbo.ProductosSucursales ADD StockFuturoReservado decimal(12, 2) NULL
GO
UPDATE ProductosSucursales
   SET StockDefectuoso = 0
     , StockFuturo = 0
     , StockFuturoReservado = 0;
ALTER TABLE dbo.ProductosSucursales ALTER COLUMN StockDefectuoso decimal(12, 2) NOT NULL
ALTER TABLE dbo.ProductosSucursales ALTER COLUMN StockFuturo decimal(12, 2) NOT NULL
ALTER TABLE dbo.ProductosSucursales ALTER COLUMN StockFuturoReservado decimal(12, 2) NOT NULL
GO
ALTER TABLE dbo.ProductosSucursales SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
