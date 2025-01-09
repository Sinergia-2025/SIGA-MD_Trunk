PRINT ''
PRINT '1. Nuevo Campos ComprasProductos: IdDeposito-IdUbicacion.'
IF not exists(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME = 'IdDeposito' AND TABLE_NAME = 'ComprasProductos')
BEGIN
	ALTER TABLE ComprasProductos ADD IdDeposito Int NULL
	ALTER TABLE ComprasProductos ADD IdUbicacion Int NULL
END
GO

PRINT ''
PRINT '2. Nuevos Campos ProductosSucursales: IdDepositoDefecto-IdUbicacionDefecto.'
IF not exists(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME = 'IdDepositoDefecto' AND TABLE_NAME = 'ProductosSucursales')
BEGIN
	ALTER TABLE ProductosSucursales ADD IdDepositoDefecto Int NULL
	ALTER TABLE ProductosSucursales ADD IdUbicacionDefecto Int NULL
END
GO

PRINT ''
PRINT '2A. Nuevos Campos ProductosSucursales: IdDepositoDefecto-IdUbicacionDefecto.'
BEGIN
	UPDATE ProductosSucursales SET IdDepositoDefecto = 1,
								   IdUbicacionDefecto = 1

	ALTER TABLE ProductosSucursales ALTER COLUMN IdDepositoDefecto Int NOT NULL
	ALTER TABLE ProductosSucursales ALTER COLUMN IdUbicacionDefecto Int NOT NULL
END
GO


PRINT ''
PRINT '3. Nuevo Campos VentasProductos: IdDeposito-IdUbicacion.'
IF not exists(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME = 'IdDeposito' AND TABLE_NAME = 'VentasProductos')
BEGIN
	ALTER TABLE VentasProductos ADD IdDeposito Int NULL
	ALTER TABLE VentasProductos ADD IdUbicacion Int NULL
END
GO
