
PRINT '1. PedidosProductos: Creo los campos de los Precios con Impuestos y los Actualizo.'

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
ALTER TABLE dbo.PedidosProductos ADD PrecioConImpuestos decimal(14, 4) NULL
ALTER TABLE dbo.PedidosProductos ADD PrecioNetoConImpuestos decimal(14, 4) NULL
ALTER TABLE dbo.PedidosProductos ADD ImporteTotalConImpuestos decimal(14, 4) NULL
ALTER TABLE dbo.PedidosProductos ADD ImporteTotalNetoConImpuestos decimal(14, 4) NULL
ALTER TABLE dbo.PedidosProductos ALTER COLUMN DescuentoRecargoPorc2 decimal(10, 5) NULL
ALTER TABLE dbo.PedidosProductos ALTER COLUMN DescuentoRecargoPorc decimal(10, 5) NULL
GO
UPDATE PedidosProductos
   SET PrecioConImpuestos = ROUND((Precio * (1 + (AlicuotaImpuesto / 100))) + (ImporteImpuestoInterno / Cantidad), 2)
      ,PrecioNetoConImpuestos = ROUND((PrecioNeto * (1 + (AlicuotaImpuesto / 100))) + (ImporteImpuestoInterno / Cantidad), 2)
      ,ImporteTotalConImpuestos = ROUND((ImporteTotal * (1 + (AlicuotaImpuesto / 100))) + (ImporteImpuestoInterno / Cantidad), 2)
      ,ImporteTotalNetoConImpuestos = ROUND((ImporteTotalNeto * (1 + (AlicuotaImpuesto / 100))) + (ImporteImpuestoInterno / Cantidad), 2)
;
ALTER TABLE dbo.PedidosProductos ALTER COLUMN PrecioConImpuestos decimal(14, 4) NOT NULL
ALTER TABLE dbo.PedidosProductos ALTER COLUMN PrecioNetoConImpuestos decimal(14, 4) NOT NULL
ALTER TABLE dbo.PedidosProductos ALTER COLUMN ImporteTotalConImpuestos decimal(14, 4) NOT NULL
ALTER TABLE dbo.PedidosProductos ALTER COLUMN ImporteTotalNetoConImpuestos decimal(14, 4) NOT NULL
GO
ALTER TABLE dbo.PedidosProductos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

PRINT '2. VentasProductos: Creo los campos de los Precios con Impuestos y los Actualizo.'

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
ALTER TABLE dbo.VentasProductos ADD PrecioConImpuestos decimal(14, 4) NULL
ALTER TABLE dbo.VentasProductos ADD PrecioNetoConImpuestos decimal(14, 4) NULL
ALTER TABLE dbo.VentasProductos ADD ImporteTotalConImpuestos decimal(14, 4) NULL
ALTER TABLE dbo.VentasProductos ADD ImporteTotalNetoConImpuestos decimal(14, 4) NULL
GO
UPDATE VentasProductos
   SET PrecioConImpuestos = ROUND((Precio * (1 + (AlicuotaImpuesto / 100))) + (ImporteImpuestoInterno / Cantidad), 2)
      ,PrecioNetoConImpuestos = ROUND((PrecioNeto * (1 + (AlicuotaImpuesto / 100))) + (ImporteImpuestoInterno / Cantidad), 2)
      ,ImporteTotalConImpuestos = ROUND((ImporteTotal * (1 + (AlicuotaImpuesto / 100))) + (ImporteImpuestoInterno / Cantidad), 2)
      ,ImporteTotalNetoConImpuestos = ROUND((ImporteTotalNeto * (1 + (AlicuotaImpuesto / 100))) + (ImporteImpuestoInterno / Cantidad), 2)
;
ALTER TABLE dbo.VentasProductos ALTER COLUMN PrecioConImpuestos decimal(14, 4) NOT NULL
ALTER TABLE dbo.VentasProductos ALTER COLUMN PrecioNetoConImpuestos decimal(14, 4) NOT NULL
ALTER TABLE dbo.VentasProductos ALTER COLUMN ImporteTotalConImpuestos decimal(14, 4) NOT NULL
ALTER TABLE dbo.VentasProductos ALTER COLUMN ImporteTotalNetoConImpuestos decimal(14, 4) NOT NULL
GO
ALTER TABLE dbo.VentasProductos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
