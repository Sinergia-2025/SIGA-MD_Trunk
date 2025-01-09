PRINT ''
PRINT '1. Nuevo Campo Producto: EsDevuelto'
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Productos' AND COLUMN_NAME = 'EsDevuelto')
BEGIN
	ALTER TABLE Productos ADD EsDevuelto bit NULL
END
GO

PRINT ''
PRINT '2. Nuevo Campo Producto: EsDevuelto'
BEGIN
	UPDATE Productos SET EsDevuelto = 0
END
GO

PRINT ''
PRINT '1. Nuevo Campo AuditoriaProducto: EsDevuelto'
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'AuditoriaProductos' AND COLUMN_NAME = 'EsDevuelto')
BEGIN
	ALTER TABLE AuditoriaProductos ADD EsDevuelto bit NULL
END
GO

PRINT ''
PRINT '2. Nuevo Campo Producto: EsDevuelto'
BEGIN
	UPDATE AuditoriaProductos SET EsDevuelto = 0
END
GO