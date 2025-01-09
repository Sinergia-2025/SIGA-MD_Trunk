PRINT ''
PRINT '1. Nuevo Campo PedidosProductos: CantidadDevolucion'
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PedidosProductos' AND COLUMN_NAME = 'CantidadDevolucion')
BEGIN
	ALTER TABLE PedidosProductos ADD CantidadDevolucion decimal(12,4) NULL
	ALTER TABLE PedidosProductos ADD NotaDevolucion varchar(100) NULL
END
GO

PRINT ''
PRINT '2. Nuevo Campo PedidosProductos: CantidadDevolucion'
BEGIN
	UPDATE PedidosProductos SET CantidadDevolucion = 0, NotaDevolucion = ''

	ALTER TABLE PedidosProductos ALTER COLUMN CantidadDevolucion decimal(12,4) NOT NULL
	ALTER TABLE PedidosProductos ALTER COLUMN NotaDevolucion varchar(100) NOT NULL

END
GO