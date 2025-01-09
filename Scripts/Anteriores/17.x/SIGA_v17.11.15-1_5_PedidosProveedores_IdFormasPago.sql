ALTER TABLE PedidosProveedores ADD IdFormasPago	int	null
GO

UPDATE PedidosProveedores SET IdFormasPago = (SELECT IdFormasPago FROM VentasFormasPago WHERE Dias = 0)
GO

ALTER TABLE PedidosProveedores ALTER COLUMN IdFormasPago	int	not null
GO

