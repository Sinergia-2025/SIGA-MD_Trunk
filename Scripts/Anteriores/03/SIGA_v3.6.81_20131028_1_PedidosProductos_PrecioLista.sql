ALTER TABLE PedidosProductos ADD PrecioLista	decimal(12, 4)	NULL
GO

UPDATE PedidosProductos
  SET PrecioLista = 0 
GO

ALTER TABLE PedidosProductos ALTER COLUMN PrecioLista	decimal(12, 4)	NOT NULL
GO
