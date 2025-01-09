PRINT ''
PRINT '0. Renombra Tablas de Movimeintos Compras-Ventas-Lotes-NrosSerie (Viejos).'
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES  WHERE TABLE_NAME = 'MovimientosCompras_Viejos')
BEGIN
	EXEC sp_rename 'MovimientosCompras_Viejos', 'MovimientosCompras'
	EXEC sp_rename 'MovimientosVentas_Viejos', 'MovimientosVentas'
	EXEC sp_rename 'MovimientosComprasProductos_Viejos', 'MovimientosComprasProductos'
	EXEC sp_rename 'MovimientosVentasProductos_Viejos', 'MovimientosVentasProductos'
	EXEC sp_rename 'MovimientosVentasProductosLotes_Viejos', 'MovimientosVentasProductosLotes'
	EXEC sp_rename 'MovimientosComprasProductosNrosSerie_Viejos', 'MovimientosComprasProductosNrosSerie'
	EXEC sp_rename 'MovimientosVentasProductosNrosSerie_Viejos', 'MovimientosVentasProductosNrosSerie'
END
GO

PRINT ''
PRINT '1. Crea Tabla Movimientos Stock.'
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES  WHERE TABLE_NAME = 'MovimientosStock')
	BEGIN

		CREATE TABLE MovimientosStock(
			IdSucursal				int				NOT NULL,
			IdTipoMovimiento		varchar(15)		NOT NULL,
			NumeroMovimiento		bigint			NOT NULL,
			FechaMovimiento			datetime		NOT NULL,
			Neto                    decimal(14, 2)  NOT NULL,
			Total					decimal(14, 2)	NOT NULL,
			PorcentajeIVA			decimal(14, 2)	NULL,
			IdCategoriaFiscal		smallint		NULL,
			IdTipoComprobante		varchar(15)		NULL,
			Letra					varchar(1)		NULL,
			CentroEmisor			int				NULL,
			NumeroComprobante		bigint			NULL,
			Usuario					varchar(10)		NOT NULL,
			Observacion				varchar(100)	NULL,
			TotalImpuestos          decimal(14, 2)  NULL,
			IdCliente               bigint          NULL,
			IdSucursal2				int				NULL,
			PercepcionIVA			decimal(14, 2)	NOT NULL,
			PercepcionIB			decimal(14, 2)	NOT NULL,
			PercepcionGanancias		decimal(14, 2)	NOT NULL,
			PercepcionVarias		decimal(14, 2)	NOT NULL,
			IdProduccion			int				NULL,
			IdProveedor				bigint			NULL,
			IdEmpleado				int				NULL,
			ImpuestosInternos		decimal(14, 2)	NOT NULL,

		 CONSTRAINT PK_MovimientosStock PRIMARY KEY CLUSTERED 
		   (IdSucursal ASC, IdTipoMovimiento ASC, NumeroMovimiento ASC) 
		 WITH 
		 (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
		) ON [PRIMARY]

		ALTER TABLE MovimientosStock  WITH CHECK ADD  CONSTRAINT FK_MovimientosStock_CategoriasFiscales FOREIGN KEY(IdCategoriaFiscal) REFERENCES  CategoriasFiscales(IdCategoriaFiscal)
		ALTER TABLE MovimientosStock CHECK CONSTRAINT FK_MovimientosStock_CategoriasFiscales

		ALTER TABLE MovimientosStock  WITH CHECK ADD  CONSTRAINT FK_MovimientosStock_Empleados FOREIGN KEY(IdEmpleado) REFERENCES  Empleados (IdEmpleado)
		ALTER TABLE MovimientosStock CHECK CONSTRAINT FK_MovimientosStock_Empleados

		ALTER TABLE MovimientosStock  WITH CHECK ADD  CONSTRAINT FK_MovimientosStock_Proveedores FOREIGN KEY(IdProveedor) REFERENCES  Proveedores (IdProveedor)
		ALTER TABLE MovimientosStock CHECK CONSTRAINT FK_MovimientosStock_Proveedores

		ALTER TABLE MovimientosStock  WITH CHECK ADD  CONSTRAINT FK_MovimientosStock_Sucursales FOREIGN KEY(IdSucursal)	REFERENCES  Sucursales (IdSucursal)
		ALTER TABLE MovimientosStock CHECK CONSTRAINT FK_MovimientosStock_Sucursales

		ALTER TABLE MovimientosStock  WITH CHECK ADD  CONSTRAINT FK_MovimientosStock_Sucursales2 FOREIGN KEY(IdSucursal2) REFERENCES  Sucursales (IdSucursal)
		ALTER TABLE MovimientosStock CHECK CONSTRAINT FK_MovimientosStock_Sucursales2

		ALTER TABLE MovimientosStock  WITH CHECK ADD  CONSTRAINT FK_MovimientosStock_TiposComprobantes FOREIGN KEY(IdTipoComprobante) REFERENCES  TiposComprobantes (IdTipoComprobante)
		ALTER TABLE MovimientosStock CHECK CONSTRAINT FK_MovimientosStock_TiposComprobantes

		ALTER TABLE MovimientosStock  WITH CHECK ADD  CONSTRAINT FK_MovimientosStock_TiposMovimientos FOREIGN KEY(IdTipoMovimiento)	REFERENCES  TiposMovimientos (IdTipoMovimiento)
		ALTER TABLE MovimientosStock CHECK CONSTRAINT FK_MovimientosStock_TiposMovimientos

		ALTER TABLE MovimientosStock  WITH CHECK ADD  CONSTRAINT FK_MovimientosStock_Usuarios FOREIGN KEY(Usuario) REFERENCES  Usuarios (Id)
		ALTER TABLE MovimientosStock CHECK CONSTRAINT FK_MovimientosStock_Usuarios

		ALTER TABLE MovimientosStock  WITH CHECK ADD  CONSTRAINT FK_MovimientosStock_Clientes FOREIGN KEY(IdCliente)
		REFERENCES  Clientes (IdCliente)
		ALTER TABLE MovimientosStock CHECK CONSTRAINT FK_MovimientosStock_Clientes

	END
GO

PRINT ''
PRINT '2. Crea Tabla Movimientos Stock Productos.'
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES  WHERE TABLE_NAME = 'MovimientosStockProductos')
	BEGIN
		CREATE TABLE	MovimientosStockProductos(
						IdSucursal					int				NOT NULL,
						IdDeposito					int				NOT NULL,
						IdUbicacion					int				NOT NULL,
						IdTipoMovimiento			varchar(15)		NOT NULL,
						NumeroMovimiento			bigint			NOT NULL,
						IdProducto					varchar(15)		NOT NULL,
						Cantidad					decimal(16, 4)	NOT NULL,
						Cantidad2					decimal(16, 4)	NOT NULL,
						Precio						decimal(14, 2)	NOT NULL,
						IdLote						varchar(30)		NULL,
						Orden						int				NOT NULL,
						IdDeposito2					int				NULL,
						IdUbicacion2				int				NULL,
						IdaAtributoProducto01		int				NULL,
						IdaAtributoProducto02		int				NULL,
						IdaAtributoProducto03		int				NULL,
						IdaAtributoProducto04		int				NULL,

		 CONSTRAINT PK_MovimientosStockProductos PRIMARY KEY CLUSTERED 
		   (IdSucursal ASC, IdDeposito ASC, IdUbicacion ASC, IdTipoMovimiento ASC, NumeroMovimiento ASC, Orden ASC, IdProducto ASC) 
		   WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
		)  ON [PRIMARY]

		ALTER TABLE MovimientosStockProductos  WITH CHECK ADD  CONSTRAINT FK_MovimientosStockProductos_MovimientosStock 
			FOREIGN KEY(IdSucursal, IdTipoMovimiento, NumeroMovimiento)
			REFERENCES  MovimientosStock (IdSucursal, IdTipoMovimiento, NumeroMovimiento)
		ALTER TABLE MovimientosStockProductos CHECK CONSTRAINT FK_MovimientosStockProductos_MovimientosStock

		ALTER TABLE MovimientosStockProductos  WITH CHECK ADD  CONSTRAINT FK_MovimientosStockProductos_Productos 
			FOREIGN KEY(IdProducto)
			REFERENCES  Productos (IdProducto)
		ALTER TABLE MovimientosStockProductos CHECK CONSTRAINT FK_MovimientosStockProductos_Productos

		ALTER TABLE MovimientosStockProductos  WITH CHECK ADD  CONSTRAINT FK_MovimientosStockProductos_ProductosLotes 
			FOREIGN KEY(IdSucursal, IdProducto, IdLote, IdDeposito, IdUbicacion)
			REFERENCES  ProductosLotes (IdSucursal, IdProducto, IdLote, IdDeposito, IdUbicacion)
		ALTER TABLE MovimientosStockProductos CHECK CONSTRAINT FK_MovimientosStockProductos_ProductosLotes

		ALTER TABLE MovimientosStockProductos  WITH CHECK ADD  CONSTRAINT FK_MovimientosStockProductos_Depositos FOREIGN KEY(IdDeposito, IdSucursal)
		REFERENCES  SucursalesDepositos (IdDeposito, IdSucursal)
		ALTER TABLE MovimientosStockProductos CHECK CONSTRAINT FK_MovimientosStockProductos_Depositos

		ALTER TABLE MovimientosStockProductos  WITH CHECK ADD  CONSTRAINT FK_MovimientosStockProductos_Ubicaciones FOREIGN KEY(IdDeposito, IdSucursal, IdUbicacion)
		REFERENCES  SucursalesUbicaciones (IdDeposito, IdSucursal, IdUbicacion)
		ALTER TABLE MovimientosStockProductos CHECK CONSTRAINT FK_MovimientosStockProductos_Ubicaciones

		ALTER TABLE MovimientosStockProductos  WITH CHECK ADD  CONSTRAINT FK_MovimientosStockProductos_Ubicaciones2 FOREIGN KEY(IdDeposito2, IdSucursal, IdUbicacion2)
		REFERENCES  SucursalesUbicaciones (IdDeposito, IdSucursal, IdUbicacion)
		ALTER TABLE MovimientosStockProductos CHECK CONSTRAINT FK_MovimientosStockProductos_Ubicaciones2

	END
GO

PRINT ''
PRINT '3. Crea Tabla Movimientos Stock Productos Lotes.'
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES  WHERE TABLE_NAME = 'MovimientosStockProductosLotes')
	BEGIN
		CREATE TABLE	MovimientosStockProductosLotes(
						IdSucursal					int				NOT NULL,
						IdDeposito					int				NOT NULL,
						IdUbicacion					int				NOT NULL,
						IdTipoMovimiento			varchar(15)		NOT NULL,
						NumeroMovimiento			bigint			NOT NULL,
						Orden						int				NOT NULL,
						IdProducto					varchar(15)		NOT NULL,
						IdLote						varchar(30)		NOT NULL,
						Cantidad					decimal(16, 4)	NOT NULL,
						Cantidad2					decimal(16, 4)	NOT NULL,

		 CONSTRAINT PK_MovimientosStockProductosLotes PRIMARY KEY CLUSTERED 
		   (IdSucursal ASC, IdDeposito ASC, IdUbicacion ASC, IdTipoMovimiento ASC, NumeroMovimiento ASC, Orden ASC, IdProducto ASC, IdLote ASC) 
		   WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
		)  ON [PRIMARY]

		ALTER TABLE MovimientosStockProductosLotes  WITH CHECK ADD  CONSTRAINT FK_MovimientosStockProductosLotes_MovimientosStockProductos
		FOREIGN KEY(IdSucursal, IdDeposito, IdUbicacion, IdTipoMovimiento, NumeroMovimiento, Orden, IdProducto)
		REFERENCES MovimientosStockProductos (IdSucursal, IdDeposito, IdUbicacion, IdTipoMovimiento, NumeroMovimiento, Orden, IdProducto)
		ALTER TABLE MovimientosStockProductosLotes CHECK CONSTRAINT FK_MovimientosStockProductosLotes_MovimientosStockProductos

		ALTER TABLE MovimientosStockProductosLotes  WITH CHECK ADD  CONSTRAINT FK_MovimientosStockProductos_DepositosLotes FOREIGN KEY(IdDeposito, IdSucursal)
		REFERENCES  SucursalesDepositos (IdDeposito, IdSucursal)
		ALTER TABLE MovimientosStockProductosLotes CHECK CONSTRAINT FK_MovimientosStockProductos_DepositosLotes

		ALTER TABLE MovimientosStockProductosLotes  WITH CHECK ADD  CONSTRAINT FK_MovimientosStockProductos_UbicacionesLotes FOREIGN KEY(IdDeposito, IdSucursal, IdUbicacion)
		REFERENCES  SucursalesUbicaciones (IdDeposito, IdSucursal, IdUbicacion)
		ALTER TABLE MovimientosStockProductosLotes CHECK CONSTRAINT FK_MovimientosStockProductos_UbicacionesLotes
	END
GO

PRINT ''
PRINT '4. Crea Tabla Movimientos Stock Productos Nros Series.'
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES  WHERE TABLE_NAME = 'MovimientosStockProductosNrosSerie')
	BEGIN
		CREATE TABLE MovimientosStockProductosNrosSerie(
			         IdSucursal			int				NOT NULL,
			         IdDeposito			int				NOT NULL,
			         IdUbicacion		int				NOT NULL,
			         IdTipoMovimiento	varchar(15)		NOT NULL,
			         NumeroMovimiento	bigint			NOT NULL,
			         Orden				int				NOT NULL,
			         IdProducto			varchar(15)		NOT NULL,
			         NroSerie			varchar(50)		NOT NULL,
					 Cantidad			decimal(16, 4)	NOT NULL,
					 Cantidad2			decimal(16, 4)	NOT NULL,
		PRIMARY KEY CLUSTERED 
		(IdSucursal ASC, IdDeposito ASC, IdUbicacion ASC, IdTipoMovimiento ASC, NumeroMovimiento ASC, Orden ASC, IdProducto ASC, NroSerie ASC)
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
		) ON [PRIMARY]

		ALTER TABLE MovimientosStockProductosNrosSerie  WITH CHECK ADD  CONSTRAINT FK_MovimientosStockProductosNrosSerie_MovimientosStockProductos 
			FOREIGN KEY(IdSucursal, IdDeposito, IdUbicacion, IdTipoMovimiento, NumeroMovimiento, Orden, IdProducto)
			REFERENCES  MovimientosStockProductos (IdSucursal, IdDeposito, IdUbicacion, IdTipoMovimiento, NumeroMovimiento, Orden, IdProducto)
		ALTER TABLE MovimientosStockProductosNrosSerie CHECK CONSTRAINT FK_MovimientosStockProductosNrosSerie_MovimientosStockProductos

	END
GO
