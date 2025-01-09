PRINT ''
PRINT '1. Tabla Nueva de Sucursales Depósitos.-'
IF dbo.ExisteTabla('SucursalesDepositos') = 0
BEGIN
	CREATE TABLE [dbo].[SucursalesDepositos](
                       [IdDeposito] [int] NOT NULL,
                       [IdSucursal] [int] NOT NULL,
                       [NombreDeposito] [varchar](50) NOT NULL,
                       [CodigoDeposito] [varchar](30) NOT NULL,
                       [SucursalAsociada] [int] NULL,
                       [DepositoAsociado] [int] NULL,
                       [DisponibleVenta] [bit]  NOT NULL,
                       [TipoDeposito] [varchar](30) NOT NULL,
                       [Activo] [bit] NOT NULL,
		CONSTRAINT [PK_SucursalesDepositos] PRIMARY KEY CLUSTERED ([IdDeposito] ASC, [IdSucursal] ASC)
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]


		ALTER TABLE dbo.SucursalesDepositos  WITH CHECK ADD  CONSTRAINT [FK_SucursalesDepositos] FOREIGN KEY([IdSucursal])
												       REFERENCES [dbo].[Sucursales] ([IdSucursal])

		CREATE UNIQUE NONCLUSTERED INDEX AK_CodigoDeposito ON dbo.SucursalesDepositos (IdSucursal, CodigoDeposito)
        WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

		ALTER TABLE dbo.SucursalesDepositos SET (LOCK_ESCALATION = TABLE)
END
GO

PRINT ''
PRINT '2. Tabla Nueva de Sucursales Depositos Usuarios.-'
IF dbo.ExisteTabla('SucursalesDepositosUsuarios') = 0
BEGIN
	CREATE TABLE SucursalesDepositosUsuarios(
		IdDeposito  Int          NOT NULL,
		IdSucursal  Int          NOT NULL,
		IdUsuario   Varchar (10) NOT NULL,
		Responsable   bit  NOT NULL,
		UsuarioDefault   bit  NOT NULL,
		PermitirEscritura   bit  NOT NULL,
			CONSTRAINT PK_SucursalesDepositosUsuarios PRIMARY KEY CLUSTERED 
			([IdSucursal] ASC, [IdDeposito] ASC, [IdUsuario] ASC)
			WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) 
			ON [PRIMARY]) ON [PRIMARY]

END
GO

PRINT ''
PRINT '3. Tabla Nueva de Estados Ubicaciones.-'
IF dbo.ExisteTabla('EstadosUbicaciones') = 0
BEGIN
	CREATE TABLE [dbo].[EstadosUbicaciones](
                       [IdEstado] [int] NOT NULL,
                       [NombreEstado] [varchar](50) NOT NULL,
                       [OrdenEstado] [int] NOT NULL,
                       [Activo] [bit] NOT NULL,
		CONSTRAINT [PK_EstadosUbicacionesDepositos] PRIMARY KEY CLUSTERED ([IdEstado] ASC)
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
END
GO

PRINT ''
PRINT '4. Tabla Nueva de Ubicaciones Ubicaciones.-'
IF dbo.ExisteTabla('SucursalesUbicaciones') = 0
BEGIN
	CREATE TABLE [dbo].[SucursalesUbicaciones](
                       [IdDeposito] [int] NOT NULL,
                       [IdSucursal] [int] NOT NULL,
                       [IdUbicacion] [int] NOT NULL,
                       [NombreUbicacion] [varchar](50) NOT NULL,
                       [CodigoUbicacion] [varchar](50) NOT NULL,
                       [EstadoUbicacion] [int] NOT NULL,
                       [SucursalAsociada] [int] NULL,
                       [DepositoAsociado] [int] NULL,
					   [UbicacionAsociada] [int] NULL,
                       [Activo] [bit] NOT NULL,
		CONSTRAINT [PK_UbicacionesDepositos] PRIMARY KEY CLUSTERED ([IdDeposito] ASC, [IdSucursal] ASC, [IdUbicacion] ASC)
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]

		ALTER TABLE [dbo].[SucursalesUbicaciones]  WITH CHECK ADD  CONSTRAINT [FK_UbicacionDepositos] FOREIGN KEY([IdDeposito], [IdSucursal])
												                   REFERENCES [dbo].[SucursalesDepositos] ([IdDeposito], [IdSucursal])
		ALTER TABLE [dbo].[SucursalesUbicaciones]  WITH CHECK ADD  CONSTRAINT [FK_EstadosUbicaciones] FOREIGN KEY([EstadoUbicacion])
												                   REFERENCES [dbo].[EstadosUbicaciones] ([IdEstado])
END
GO

PRINT ''
PRINT '5. Tabla Nueva de Productos Depósitos.-'
IF dbo.ExisteTabla('ProductosDepositos') = 0
BEGIN
	CREATE TABLE [dbo].[ProductosDepositos](
                       IdProducto varchar(15) NOT NULL,
                       IdSucursal int NOT NULL,
                       IdDeposito int NOT NULL,
                       Stock Decimal(16,4) NOT NULL,
                       Stock2 Decimal(16,4) NOT NULL,
                       --FechaActualizacion  DateTime NOT NULL,

		CONSTRAINT [PK_ProductosDepositos] PRIMARY KEY CLUSTERED (IdProducto ASC, IdSucursal ASC, IdDeposito ASC)
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
	-- FK Productos.- --
	ALTER TABLE ProductosDepositos  WITH CHECK ADD  CONSTRAINT FK_DepositosProductos FOREIGN KEY(IdProducto) REFERENCES Productos (IdProducto)
	-- FK Sucursales.- --
	ALTER TABLE ProductosDepositos  WITH CHECK ADD  CONSTRAINT FK_SucursalesProductos FOREIGN KEY(Idsucursal) REFERENCES Sucursales (IdSucursal)
	-- FK Depositos.- --
	ALTER TABLE ProductosDepositos  WITH CHECK ADD  CONSTRAINT FK_DepositosSucursalesProductos FOREIGN KEY(IdDeposito, IdSucursal) REFERENCES SucursalesDepositos (IdDeposito, IdSucursal)

END
GO

PRINT ''
PRINT '6. Tabla Nueva de Productos Ubicaciones.-'
IF dbo.ExisteTabla('ProductosUbicaciones') = 0
BEGIN
	CREATE TABLE [dbo].[ProductosUbicaciones](
                       IdProducto varchar(15) NOT NULL,
                       IdSucursal int NOT NULL,
                       IdDeposito int NOT NULL,
                       IdUbicacion int NOT NULL,
                       Stock Decimal(16,4) NOT NULL,
                       Stock2 Decimal(16,4) NOT NULL,

		CONSTRAINT [PK_ProductosUbicaciones] PRIMARY KEY CLUSTERED (IdProducto ASC, IdSucursal ASC, IdDeposito ASC, IdUbicacion ASC)
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
	-- FK Productos.- --
	ALTER TABLE ProductosUbicaciones  WITH CHECK ADD  CONSTRAINT FK_Productos FOREIGN KEY(IdProducto) 
				REFERENCES Productos (IdProducto)
	-- FK Sucursales.- --
	ALTER TABLE ProductosUbicaciones  WITH CHECK ADD  CONSTRAINT FK_Sucursales FOREIGN KEY(Idsucursal) 
				REFERENCES Sucursales (IdSucursal)
	-- FK Depositos.- --
	ALTER TABLE ProductosUbicaciones  WITH CHECK ADD  CONSTRAINT FK_Depositos FOREIGN KEY(IdDeposito, IdSucursal) REFERENCES SucursalesDepositos (IdDeposito, IdSucursal)
	-- FK Ubicaciones.- --
	ALTER TABLE ProductosUbicaciones  WITH CHECK ADD  CONSTRAINT FK_Ubicaciones FOREIGN KEY(IdDeposito, IdSucursal, IdUbicacion) 
				REFERENCES SucursalesUbicaciones (IdDeposito, IdSucursal, IdUbicacion)

END
GO

IF dbo.ExisteCampo('ProductosSucursales', 'StockReservado') = 1
BEGIN
    -- No debe acumular los reservados y defectuosos porque no son Depositos OPERATIVOS.
    --UPDATE ProductosSucursales
    --   SET Stock = Stock + StockReservado + StockDefectuoso + StockFuturo + StockFuturoReservado;
    EXECUTE sp_rename N'dbo.ProductosSucursales.StockReservado',        N'StockReservado_Viejo',        'COLUMN' 
    EXECUTE sp_rename N'dbo.ProductosSucursales.StockDefectuoso',       N'StockDefectuoso_Viejo',       'COLUMN' 
    EXECUTE sp_rename N'dbo.ProductosSucursales.StockFuturo',           N'StockFuturo_Viejo',           'COLUMN' 
    EXECUTE sp_rename N'dbo.ProductosSucursales.StockFuturoReservado',  N'StockFuturoReservado_Viejo',  'COLUMN' 

END

ALTER TABLE ProductosSucursales ALTER COLUMN StockReservado_Viejo decimal(16, 4) NULL
ALTER TABLE ProductosSucursales ALTER COLUMN StockDefectuoso_Viejo decimal(16, 4) NULL
ALTER TABLE ProductosSucursales ALTER COLUMN StockFuturo_Viejo decimal(16, 4) NULL
ALTER TABLE ProductosSucursales ALTER COLUMN StockFuturoReservado_Viejo decimal(16, 4) NULL

GO