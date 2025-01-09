IF dbo.ExisteCampo('VentasProductos', 'ModificoPrecioManualmente') = 0
BEGIN
    ALTER TABLE dbo.VentasProductos ADD ModificoPrecioManualmente bit NULL
END
GO

UPDATE VentasProductos SET ModificoPrecioManualmente = 'False';
ALTER TABLE dbo.VentasProductos ALTER COLUMN ModificoPrecioManualmente bit NOT NULL
GO
