PRINT ''
PRINT '1. Nuevo Campos ProductosSucursales: Stock2.'
IF not exists(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME = 'Stock2' AND TABLE_NAME = 'ProductosSucursales')
BEGIN
	ALTER TABLE ProductosSucursales ADD Stock2 Decimal(16,4) NULL
END
GO

PRINT ''
PRINT '2. Asigna Valor Campos ProductosSucursales: Stock2.'
BEGIN
	UPDATE ProductosSucursales SET Stock2 = 0
	ALTER TABLE ProductosSucursales ALTER COLUMN Stock2 Decimal(16,4) NOT NULL
END
GO

PRINT ''
PRINT '3. Nuevos Campos ProductosSeries.'
IF not exists(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME = 'idDeposito' AND TABLE_NAME = 'ProductosNrosSerie')
BEGIN
	ALTER TABLE ProductosNrosSerie ADD IdDeposito Int NULL
	ALTER TABLE ProductosNrosSerie ADD IdUbicacion Int NULL
END
GO

PRINT ''
PRINT '4. Asigna Valor Campos ProductosNrosSerie.'
BEGIN
	UPDATE ProductosNrosSerie SET IdDeposito = 1, IdUbicacion = 1

	ALTER TABLE ProductosNrosSerie ALTER COLUMN IdDeposito Int NOT NULL
	ALTER TABLE ProductosNrosSerie ALTER COLUMN IdUbicacion Int NOT NULL

	IF OBJECT_ID('dbo.[FK_ProductosNrosSerie_Depositos]', 'F') IS NULL
		BEGIN
			ALTER TABLE ProductosNrosSerie  WITH CHECK ADD  CONSTRAINT FK_ProductosNrosSerie_Depositos FOREIGN KEY(IdDeposito, IdSucursal)
			REFERENCES  SucursalesDepositos (IdDeposito, IdSucursal)
			ALTER TABLE ProductosNrosSerie CHECK CONSTRAINT FK_ProductosNrosSerie_Depositos
		END
	IF OBJECT_ID('dbo.[FK_ProductosNrosSerie_Ubicaciones]', 'F') IS NULL
		BEGIN
			ALTER TABLE ProductosNrosSerie  WITH CHECK ADD  CONSTRAINT FK_ProductosNrosSerie_Ubicaciones FOREIGN KEY(IdDeposito, IdSucursal, IdUbicacion)
			REFERENCES  SucursalesUbicaciones (IdDeposito, IdSucursal, IdUbicacion)
			ALTER TABLE ProductosNrosSerie CHECK CONSTRAINT FK_ProductosNrosSerie_Ubicaciones
		END
END
GO

PRINT ''
PRINT '5. Nuevos Campos ProductosLotes.'
IF not exists(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME = 'idDeposito' AND TABLE_NAME = 'ProductosLotes')
BEGIN
	ALTER TABLE ProductosLotes ADD IdDeposito Int NULL
	ALTER TABLE ProductosLotes ADD IdUbicacion Int NULL
END
GO

PRINT ''
PRINT '6. Asigna Valor Campos ProductosLotes.'
BEGIN
	UPDATE ProductosLotes SET IdDeposito = 1, IdUbicacion = 1

	ALTER TABLE ProductosLotes ALTER COLUMN IdDeposito Int NOT NULL
	ALTER TABLE ProductosLotes ALTER COLUMN IdUbicacion Int NOT NULL

	IF OBJECT_ID('dbo.[FK_ProductosLotes_Depositos]', 'F') IS NULL
		BEGIN
			ALTER TABLE ProductosLotes  WITH CHECK ADD CONSTRAINT FK_ProductosLotes_Depositos FOREIGN KEY(IdDeposito, IdSucursal)
			REFERENCES  SucursalesDepositos (IdDeposito, IdSucursal)
			ALTER TABLE ProductosLotes CHECK CONSTRAINT FK_ProductosLotes_Depositos
		END
	IF OBJECT_ID('dbo.[FK_ProductosLotes_Ubicaciones]', 'F') IS NULL
		BEGIN
			ALTER TABLE ProductosLotes  WITH CHECK ADD  CONSTRAINT FK_ProductosLotes_Ubicaciones FOREIGN KEY(IdDeposito, IdSucursal, IdUbicacion)
			REFERENCES  SucursalesUbicaciones (IdDeposito, IdSucursal, IdUbicacion)
			ALTER TABLE ProductosLotes CHECK CONSTRAINT FK_ProductosLotes_Ubicaciones
		END
	-------------------------------------------------------------------------------------------------------------------------------------
	IF OBJECT_ID('dbo.[FK_VentasProductosLotes_ProductosLotes]', 'F') IS NOT NULL
		BEGIN
			ALTER TABLE VentasProductosLotes DROP CONSTRAINT FK_VentasProductosLotes_ProductosLotes
		END
	IF OBJECT_ID('dbo.[FK_ProduccionProductos_ProductosLotes]', 'F') IS NOT NULL
		BEGIN
			ALTER TABLE ProduccionProductos DROP CONSTRAINT FK_ProduccionProductos_ProductosLotes
		END
	IF OBJECT_ID('dbo.[FK_MovimientosComprasProductos_ProductosLotes]', 'F') IS NOT NULL
		BEGIN
			ALTER TABLE MovimientosComprasProductos DROP CONSTRAINT FK_MovimientosComprasProductos_ProductosLotes
		END
	-------------------------------------------------------------------------------------------------------------------------------------
	IF OBJECT_ID('dbo.[FK_ProduccionProductosComponentes_ProductosLotes]', 'F') IS NOT NULL
		ALTER TABLE dbo.ProduccionProductosComponentes DROP CONSTRAINT FK_ProduccionProductosComponentes_ProductosLotes

	
	IF OBJECT_ID('dbo.[PK_ProductosLotes]', 'PK') IS NOT NULL
	BEGIN
		ALTER TABLE ProductosLotes DROP CONSTRAINT PK_ProductosLotes
	END
	ALTER TABLE ProductosLotes ADD CONSTRAINT PK_ProductosLotes PRIMARY KEY (IdSucursal, IdProducto, IdLote, IdDeposito, IDUbicacion)


	IF OBJECT_ID('dbo.[FK_ProduccionProductosComponentes_ProductosLotes]', 'F') IS NOT NULL
		ALTER TABLE dbo.ProduccionProductosComponentes ADD CONSTRAINT FK_ProduccionProductosComponentes_ProductosLotes
			FOREIGN KEY (IdSucursal, IdProductoComponente, IdLote)
			REFERENCES dbo.ProductosLotes (IdSucursal, IdProducto, IdLote)
			ON UPDATE  NO ACTION ON DELETE  NO ACTION 
	-------------------------------------------------------------------------------------------------------------------------------------
	IF not exists(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME = 'idDeposito' AND TABLE_NAME = 'VentasProductosLotes')
		BEGIN
			ALTER TABLE VentasProductosLotes ADD IdDeposito Int NULL
			ALTER TABLE VentasProductosLotes ADD IdUbicacion Int NULL
		END
	-------------------------------------------------------------------------------------------------------------------------------------
	IF not exists(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME = 'idDeposito' AND TABLE_NAME = 'ProduccionProductos')
		BEGIN
			ALTER TABLE ProduccionProductos ADD IdDeposito Int NULL
			ALTER TABLE ProduccionProductos ADD IdUbicacion Int NULL
		END
	-------------------------------------------------------------------------------------------------------------------------------------
	ALTER TABLE VentasProductosLotes  WITH CHECK ADD  CONSTRAINT FK_VentasProductosLotes_ProductosLotes FOREIGN KEY(IdSucursal, IdProducto, IdLote, IdDeposito, IdUbicacion) 
		  REFERENCES  ProductosLotes (IdSucursal, IdProducto, IdLote, IdDeposito, IdUbicacion)
	ALTER TABLE VentasProductosLotes CHECK CONSTRAINT FK_VentasProductosLotes_ProductosLotes

	ALTER TABLE ProduccionProductos  WITH CHECK ADD  CONSTRAINT FK_ProduccionProductos_ProductosLotes FOREIGN KEY(IdSucursal, IdProducto, IdLote, IdDeposito, IdUbicacion) 
		  REFERENCES  ProductosLotes (IdSucursal, IdProducto, IdLote, IdDeposito, IdUbicacion)
	ALTER TABLE ProduccionProductos CHECK CONSTRAINT FK_ProduccionProductos_ProductosLotes

END
GO

PRINT ''
PRINT '7. Nuevos Campos Productos Sucursales Atributos.'
IF not exists(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME = 'idDeposito' AND TABLE_NAME = 'ProductosSucursalesAtributos')
BEGIN
	ALTER TABLE ProductosSucursalesAtributos ADD IdDeposito Int NULL
	ALTER TABLE ProductosSucursalesAtributos ADD IdUbicacion Int NULL
	ALTER TABLE ProductosSucursalesAtributos ADD Stock2 Decimal(16,4) NULL
END
GO

PRINT ''
PRINT '8. Asigna Valor Campos ProductosLotes.'
BEGIN
	UPDATE ProductosSucursalesAtributos SET IdDeposito = 1, IdUbicacion = 1, Stock2 = 0

	ALTER TABLE ProductosSucursalesAtributos ALTER COLUMN IdDeposito Int NOT NULL
	ALTER TABLE ProductosSucursalesAtributos ALTER COLUMN IdUbicacion Int NOT NULL

	IF OBJECT_ID('dbo.[FK_ProductosSucursalesAtributos_Depositos]', 'F') IS NULL
		BEGIN
			ALTER TABLE ProductosSucursalesAtributos  WITH CHECK ADD CONSTRAINT FK_ProductosSucursalesAtributos_Depositos FOREIGN KEY(IdDeposito, IdSucursal)
			REFERENCES  SucursalesDepositos (IdDeposito, IdSucursal)
			ALTER TABLE ProductosSucursalesAtributos CHECK CONSTRAINT FK_ProductosSucursalesAtributos_Depositos
		END
	IF OBJECT_ID('dbo.[FK_ProductosSucursalesAtributos_Ubicaciones]', 'F') IS NULL
		BEGIN
			ALTER TABLE ProductosSucursalesAtributos  WITH CHECK ADD  CONSTRAINT FK_ProductosSucursalesAtributos_Ubicaciones FOREIGN KEY(IdDeposito, IdSucursal, IdUbicacion)
			REFERENCES  SucursalesUbicaciones (IdDeposito, IdSucursal, IdUbicacion)
			ALTER TABLE ProductosSucursalesAtributos CHECK CONSTRAINT FK_ProductosSucursalesAtributos_Ubicaciones
		END
	-------------------------------------------------------------------------------------------------------------------------------------
	ALTER TABLE ProductosSucursalesAtributos DROP CONSTRAINT PK_ProductoSucursalAtributo
	ALTER TABLE ProductosSucursalesAtributos ADD CONSTRAINT  PK_ProductoSucursalAtributo PRIMARY KEY (IdSucursal, IdProducto, IdProdSucAtributo, IdDeposito, IDUbicacion)
	-------------------------------------------------------------------------------------------------------------------------------------
END
GO