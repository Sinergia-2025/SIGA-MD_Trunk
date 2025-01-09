IF dbo.ExisteCampo('Productos', 'KilosEsUMCompras') = 0
BEGIN
    ALTER TABLE dbo.Productos ADD KilosEsUMCompras bit NULL
END
IF dbo.ExisteCampo('AuditoriaProductos', 'KilosEsUMCompras') = 0
BEGIN
    ALTER TABLE dbo.AuditoriaProductos ADD KilosEsUMCompras bit NULL
END
GO

UPDATE Productos SET KilosEsUMCompras = 0 WHERE KilosEsUMCompras IS NULL;
ALTER TABLE dbo.Productos ALTER COLUMN KilosEsUMCompras bit NOT NULL
GO

IF dbo.ExisteCampo('RequerimientosComprasProductos', 'Kilos') = 0
BEGIN
    ALTER TABLE dbo.RequerimientosComprasProductos ADD Kilos decimal(16, 4) NULL
    ALTER TABLE dbo.RequerimientosComprasProductos ADD KilosProducto decimal(16, 4) NULL
END
GO
UPDATE RequerimientosComprasProductos
   SET Kilos = 0
     , KilosProducto = 0
 WHERE Kilos IS NULL;

ALTER TABLE dbo.RequerimientosComprasProductos ALTER COLUMN Kilos decimal(16, 4) NOT NULL
ALTER TABLE dbo.RequerimientosComprasProductos ALTER COLUMN KilosProducto decimal(16, 4) NOT NULL
GO

IF dbo.ExisteCampo('PedidosProductosProveedores', 'KilosProducto') = 0
BEGIN
    ALTER TABLE dbo.PedidosProductosProveedores ADD KilosProducto decimal(16, 4) NULL
    ALTER TABLE dbo.PedidosProductosProveedores ADD PrecioPorKilos decimal(16, 4) NULL
END
GO

UPDATE PedidosProductosProveedores
   SET Kilos = 0
     , KilosProducto = 0
     , PrecioPorKilos = 0
 WHERE KilosProducto IS NULL
;

ALTER TABLE dbo.PedidosProductosProveedores ALTER COLUMN Kilos decimal(16, 4) NOT NULL
ALTER TABLE dbo.PedidosProductosProveedores ALTER COLUMN KilosProducto decimal(16, 4) NOT NULL
ALTER TABLE dbo.PedidosProductosProveedores ALTER COLUMN PrecioPorKilos decimal(16, 4) NOT NULL
GO

IF dbo.ExisteCampo('PedidosProveedores', 'Kilos') = 1
BEGIN
    ALTER TABLE dbo.PedidosProveedores DROP COLUMN Kilos
END
GO

IF dbo.ExisteCampo('ComprasProductos', 'Kilos') = 0
BEGIN
    ALTER TABLE dbo.ComprasProductos ADD Kilos decimal(16, 4) NULL
    ALTER TABLE dbo.ComprasProductos ADD KilosProducto decimal(16, 4) NULL
    ALTER TABLE dbo.ComprasProductos ADD PrecioPorKilo decimal(16, 4) NULL
END
GO
UPDATE ComprasProductos
   SET Kilos = 0
     , KilosProducto = 0
     , PrecioPorKilo = 0
 WHERE KilosProducto IS NULL;
ALTER TABLE dbo.ComprasProductos ALTER COLUMN Kilos decimal(16, 4) NOT NULL
ALTER TABLE dbo.ComprasProductos ALTER COLUMN KilosProducto decimal(16, 4) NOT NULL
ALTER TABLE dbo.ComprasProductos ALTER COLUMN PrecioPorKilo decimal(16, 4) NOT NULL
GO
