PRINT ''
PRINT '1. Tabla MRPProcesosProductivosOperaciones: Nuevos campos'
IF dbo.ExisteCampo('MRPProcesosProductivosOperaciones', 'CostoExterno') = 0
BEGIN
    ALTER TABLE MRPProcesosProductivosOperaciones ADD CostoExterno decimal(16, 4) NULL
    ALTER TABLE MRPProcesosProductivosOperaciones ADD UnidadesHora decimal(16, 4) NULL
END
GO
PRINT ''
PRINT '2. Tabla MRPProcesosProductivosOperaciones: Nuevos campos'
BEGIN
	UPDATE MRPProcesosProductivosOperaciones 
       SET CostoExterno = 0, UnidadesHora = 1
     WHERE CostoExterno IS NULL

    ALTER TABLE MRPProcesosProductivosOperaciones ALTER COLUMN CostoExterno decimal(16, 4) NOT NULL
    ALTER TABLE MRPProcesosProductivosOperaciones ALTER COLUMN UnidadesHora decimal(16, 4) NOT NULL
END
GO

PRINT ''
PRINT 'PK1. Reconstruir Clave Principal: PK_MRPProcesosProductivos.'
if (SELECT COUNT(name) FROM sys.key_constraints WHERE type = 'PK' AND OBJECT_NAME(parent_object_id) = N'MRPProcesosProductivos') > 0
BEGIN
	ALTER TABLE MRPProcesosProductivos
		DROP CONSTRAINT PK_MRPProcesosProductivos
END
GO

PRINT ''
PRINT 'PK2. Reconstruir Clave Principal: PK_MRPProcesosProductivos.'
BEGIN
	ALTER TABLE MRPProcesosProductivos
		ADD CONSTRAINT PK_MRPProcesosProductivos  PRIMARY KEY CLUSTERED (IdProcesoProductivo ASC)
END
GO

PRINT ''
PRINT 'FK2. Nueva Clave Foranea: FK_ProcesosProductivos_OperacionesProductos.'
IF dbo.ExisteFK('FK_ProcesosProductivos_OperacionesProductos') = 0 
BEGIN
	ALTER TABLE MRPProcesosProductivosProductos
		WITH CHECK ADD  CONSTRAINT FK_ProcesosProductivos_OperacionesProductos FOREIGN KEY(IdOperacion, IdProcesoProductivo)
	REFERENCES MRPProcesosProductivosOperaciones (IdOperacion, IdProcesoProductivo)

	ALTER TABLE MRPProcesosProductivosProductos
		WITH CHECK ADD  CONSTRAINT FK_ProcesosProductivos_Productos FOREIGN KEY(IdProductoProceso)
	REFERENCES Productos (IdProducto)
END
GO

PRINT ''
PRINT 'FK2. Nueva Clave Foranea: FK_ProcesosProductivos_Productos.'
IF dbo.ExisteFK('FK_ProcesosProductivos_Productos') = 0 
BEGIN
	ALTER TABLE MRPProcesosProductivosProductos
		WITH CHECK ADD  CONSTRAINT FK_ProcesosProductivos_Productos FOREIGN KEY(IdProductoProceso)
	REFERENCES Productos (IdProducto)
END
GO


PRINT ''
PRINT 'FK3. Nueva Clave Foranea: FK_ProcesosProductivos_OperacionesCategorias.'
IF dbo.ExisteFK('FK_ProcesosProductivos_OperacionesCategorias') = 0 
BEGIN
	ALTER TABLE MRPProcesosProductivosCategoriasEmpleados
		WITH CHECK ADD  CONSTRAINT FK_ProcesosProductivos_OperacionesCategorias FOREIGN KEY(IdOperacion, IdProcesoProductivo)
	REFERENCES MRPProcesosProductivosOperaciones (IdOperacion, IdProcesoProductivo)

	ALTER TABLE MRPProcesosProductivosCategoriasEmpleados
		WITH CHECK ADD  CONSTRAINT FK_ProcesosProductivos_Categorias FOREIGN KEY(IdCategoriaEmpleado)
	REFERENCES MRPCategoriasEmpleados (IdCategoriaEmpleado)
END
GO

PRINT ''
PRINT 'FK3. Nueva Clave Foranea: FK_ProcesosProductivos_Categorias.'
IF dbo.ExisteFK('FK_ProcesosProductivos_Categorias') = 0 
BEGIN
	ALTER TABLE MRPProcesosProductivosCategoriasEmpleados
		WITH CHECK ADD  CONSTRAINT FK_ProcesosProductivos_Categorias FOREIGN KEY(IdCategoriaEmpleado)
	REFERENCES MRPCategoriasEmpleados (IdCategoriaEmpleado)
END
GO


PRINT ''
PRINT 'PK1. Reconstruir Clave Principal: PK_MRPProcesosProductivosProductos.'
if (SELECT COUNT(name) FROM sys.key_constraints WHERE type = 'PK' AND OBJECT_NAME(parent_object_id) = N'MRPProcesosProductivosProductos') > 0
BEGIN
	ALTER TABLE MRPProcesosProductivosProductos
		DROP CONSTRAINT PK_MRPProcesosProductivosProductos
END
GO

PRINT ''
PRINT 'PK2. Reconstruir Clave Principal: PK_MRPProcesosProductivosProductos.'
BEGIN
	ALTER TABLE MRPProcesosProductivosProductos
		ADD CONSTRAINT PK_MRPProcesosProductivosProductos  PRIMARY KEY CLUSTERED (IdOperacion ASC, IdProcesoProductivo ASC, IdProductoProceso ASC, EsProductoNecesario ASC)
END
GO

PRINT ''
PRINT 'C1. Dropear Campos: MRPProcesosProductivosProductos.'
IF EXISTS (SELECT name FROM sysindexes WHERE name = 'IDX_TipoUtilizacion')
BEGIN
     DROP INDEX MRPProcesosProductivosProductos.IDX_TipoUtilizacion
END
GO

PRINT ''
PRINT 'C1. Dropear Campos: MRPProcesosProductivosProductos.'
IF dbo.ExisteCampo('MRPProcesosProductivosProductos', 'TipoUtilizacionProducto') = 1
BEGIN
	ALTER TABLE MRPProcesosProductivosProductos
		DROP COLUMN TipoUtilizacionProducto

	ALTER TABLE MRPProcesosProductivosProductos
		DROP COLUMN IdProductoSustituye
END
GO

------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'T1. Nueva Tabla: Ordenes Produccion MRP.'
IF dbo.ExisteTabla('OrdenesProduccionMRP') = 0
BEGIN
    CREATE TABLE OrdenesProduccionMRP(
		IdSucursal						int				NOT NULL,
		NumeroOrdenProduccion			int				NOT NULL,
		IdTipoComprobante				varchar(15)		NOT NULL,
		Letra							varchar(1)		NOT NULL,
		CentroEmisor					int				NOT NULL,
		Orden							int				NOT NULL,
		IdProducto						varchar(15)		NOT NULL,	
	    IdProcesoProductivo				bigint			NOT NULL,
	    CodigoProcesoProductivo			varchar(30)		NOT NULL,
	    DescripcionProceso				varchar(50)		NOT NULL,
	    CostoManoObraInterna			decimal(16, 4)	NOT NULL,
	    CostoManoObraExterna			decimal(16, 4)	NOT NULL,
	    CostoMateriaPrima				decimal(16, 4)	NOT NULL,
	    CostoTotalProceso	 			decimal(16, 4)	NOT NULL,
		FechaAltaProceso				Datetime		NOT NULL,
		FechaModificaProceso			Datetime		NOT NULL,
		FechaActualizaCostos			Datetime		NOT NULL,
		TiempoTotalProceso				Decimal(16,8)	NOT NULL,
		IdArchivoAdjunto				int				NOT NULL,
		RespetaOrden					bit				NOT NULL,
		Activo							bit				NOT NULL,
     CONSTRAINT PK_OrdenesProduccionMRP 
     PRIMARY KEY CLUSTERED (IdSucursal ASC, NumeroOrdenProduccion ASC, IdTipoComprobante ASC, Letra Asc, CentroEmisor ASC, Orden ASC, IdProducto ASC, IdProcesoProductivo ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]

	 ALTER TABLE OrdenesProduccionMRP	 WITH CHECK ADD CONSTRAINT FK_OrdenesProduccionMRP_Producto 
		FOREIGN KEY(IdProducto) 
		   REFERENCES Productos (IdProducto)

	 ALTER TABLE OrdenesProduccionMRP	 WITH CHECK ADD CONSTRAINT FK_OrdenesProduccionMRP 
		FOREIGN KEY(IdSucursal, NumeroOrdenProduccion, IdProducto, Orden, IdTipoComprobante, Letra, CentroEmisor) 
		   REFERENCES OrdenesProduccionProductos (IdSucursal, NumeroOrdenProduccion, IdProducto, Orden, IdTipoComprobante, Letra, CentroEmisor)

END
GO
---------------------------------------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'T2. Nueva Tabla: Ordenes Produccion MRP Operaciones.'
IF dbo.ExisteTabla('OrdenesProduccionMRPOperaciones') = 0
BEGIN
    CREATE TABLE OrdenesProduccionMRPOperaciones(
		IdSucursal						int				NOT NULL,
		NumeroOrdenProduccion			int				NOT NULL,
		IdTipoComprobante				varchar(15)		NOT NULL,
		Letra							varchar(1)		NOT NULL,
		CentroEmisor					int				NOT NULL,
		Orden							int				NOT NULL,
		IdProducto						varchar(15)		NOT NULL,
	    IdProcesoProductivo				bigint			NOT NULL,
		IdOperacion						int				NOT NULL,
	    CodigoProcProdOperacion			varchar(30)		NOT NULL, 
	    DescripcionOperacion			varchar(50)		NOT NULL,
		SucursalOperacion				int				NOT NULL,
		DepositoOperacion				int				NOT NULL,
		UbicacionOperacion				int				NOT NULL,
		CentroProductorOperacion		int				NOT NULL,
		PAPTiemposMaquina				decimal(16,8)	NOT NULL,
		PAPTiemposHHombre				decimal(16,8)	NOT NULL,
		ProdTiemposMaquina				decimal(16,8)	NOT NULL,
		ProdTiemposHHombre				decimal(16,8)	NOT NULL,
		Proveedor						bigint			NULL,
		NormasDispositivos				varchar(MAX)	NULL,
	    NormasMetodos					varchar(MAX)	NULL,
	    NormasSeguridad					varchar(MAX)	NULL,
	    NormasControlCalidad			varchar(MAX)	NULL,
		CostoExterno					decimal(16,4)	NOT NULL,
		UnidadesHora					decimal(16,4)	NOT NULL,
     CONSTRAINT PK_OrdenesProduccionMRPOperaciones 
     PRIMARY KEY CLUSTERED (IdSucursal ASC, NumeroOrdenProduccion ASC, IdTipoComprobante ASC, Letra Asc, CentroEmisor ASC, Orden ASC, IdProducto ASC, IdProcesoProductivo ASC, IdOperacion ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]

	 ALTER TABLE OrdenesProduccionMRPOperaciones WITH CHECK ADD CONSTRAINT FK_OrdenesProduccionMRPOperaciones_Sucursal 
		FOREIGN KEY(SucursalOperacion) 
			REFERENCES Sucursales	(IdSucursal)

	 ALTER TABLE OrdenesProduccionMRPOperaciones WITH CHECK ADD CONSTRAINT FK_OrdenesProduccionMRPOperaciones_SucursalDeposito 
		FOREIGN KEY(DepositoOperacion, SucursalOperacion)  
			REFERENCES SucursalesDepositos (IdDeposito, IdSucursal)

	 ALTER TABLE OrdenesProduccionMRPOperaciones WITH CHECK ADD CONSTRAINT FK_OrdenesProduccionMRPOperaciones_SucursalUbicacion 
		FOREIGN KEY(DepositoOperacion, SucursalOperacion, UbicacionOperacion) 
			REFERENCES SucursalesUbicaciones (IdDeposito, IdSucursal, IdUbicacion)

	 ALTER TABLE OrdenesProduccionMRPOperaciones WITH CHECK ADD CONSTRAINT FK_OrdenesProduccionMRPOperaciones_CentroProductor 
		FOREIGN KEY(CentroProductorOperacion)  
			REFERENCES MRPCentrosProductores (IdCentroProductor)

	 ALTER TABLE OrdenesProduccionMRPOperaciones WITH CHECK ADD CONSTRAINT FK_OrdenesProduccionMRPOperaciones_Proveedor 
		FOREIGN KEY(Proveedor)				  
			REFERENCES Proveedores (IdProveedor)

	 ALTER TABLE OrdenesProduccionMRPOperaciones WITH CHECK ADD CONSTRAINT FK_OrdenesProduccionMRPOperaciones
		FOREIGN KEY(IdSucursal, NumeroOrdenProduccion, IdTipoComprobante, Letra, CentroEmisor, Orden, IdProducto, IdProcesoProductivo) 
		   REFERENCES OrdenesProduccionMRP (IdSucursal, NumeroOrdenProduccion, IdTipoComprobante, Letra, CentroEmisor, Orden, IdProducto, IdProcesoProductivo)
END
GO
------------------------------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'T3. Nueva Tabla: Ordenes Produccion MRP Productos.'
IF dbo.ExisteTabla('OrdenesProduccionMRPProductos') = 0
BEGIN
    CREATE TABLE OrdenesProduccionMRPProductos(
		IdSucursal						int				NOT NULL,
		NumeroOrdenProduccion			int				NOT NULL,
		IdTipoComprobante				varchar(15)		NOT NULL,
		Letra							varchar(1)		NOT NULL,
		CentroEmisor					int				NOT NULL,
		Orden							int				NOT NULL,
		IdProducto						varchar(15)		NOT NULL,
	    IdProcesoProductivo				bigint			NOT NULL,
		IdOperacion						int				NOT NULL,
		IdProductoProceso				varchar(15)		NOT NULL,	
		EsProductoNecesario				bit				NOT NULL,
	    CantidadSolicitada				decimal(16,2)	NOT NULL, 
	    PrecioCostoProducto				decimal(16,2)	NOT NULL, 
     CONSTRAINT PK_OrdenesProduccionMRPProductos 
     PRIMARY KEY CLUSTERED (IdSucursal ASC, NumeroOrdenProduccion ASC, IdTipoComprobante ASC, Letra Asc, CentroEmisor ASC, Orden ASC, IdProducto ASC, IdProcesoProductivo ASC, IdOperacion ASC, IdProductoProceso ASC, EsProductoNecesario ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]

	 ALTER TABLE OrdenesProduccionMRPProductos WITH CHECK ADD CONSTRAINT FK_OrdenesProduccionMRPProductos
		FOREIGN KEY(IdSucursal, NumeroOrdenProduccion, IdTipoComprobante, Letra, CentroEmisor, Orden, IdProducto, IdProcesoProductivo, IdOperacion) 
		   REFERENCES OrdenesProduccionMRPOperaciones (IdSucursal, NumeroOrdenProduccion, IdTipoComprobante, Letra, CentroEmisor, Orden, IdProducto, IdProcesoProductivo, IdOperacion)

	ALTER TABLE OrdenesProduccionMRPProductos WITH CHECK ADD  CONSTRAINT FK_OrdenesProduccionMRPProductos_Productos 
		FOREIGN KEY(IdProductoProceso)
		   REFERENCES Productos (IdProducto)
END
GO
------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'T4. Nueva Tabla: OrdenesProduccionMRPCategoriasEmpleados.'
IF dbo.ExisteTabla('OrdenesProduccionMRPCategoriasEmpleados') = 0
BEGIN
    CREATE TABLE OrdenesProduccionMRPCategoriasEmpleados(
		IdSucursal						int				NOT NULL,
		NumeroOrdenProduccion			int				NOT NULL,
		IdTipoComprobante				varchar(15)		NOT NULL,
		Letra							varchar(1)		NOT NULL,
		CentroEmisor					int				NOT NULL,
		Orden							int				NOT NULL,
		IdProducto						varchar(15)		NOT NULL,	
	    IdProcesoProductivo				bigint			NOT NULL,
		IdOperacion						int				NOT NULL,
		IdCategoriaEmpleado				int				NOT NULL,	
	    CantidadCategoria				decimal(16,2)	NOT NULL, 
	    ValorHoraCategoria				decimal(16,2)	NOT NULL, 
     CONSTRAINT PK_OrdenesProduccionMRPCategoriasEmpleados
     PRIMARY KEY CLUSTERED (IdSucursal ASC, NumeroOrdenProduccion ASC, IdTipoComprobante ASC, Letra Asc, CentroEmisor ASC, Orden ASC, IdProducto ASC, IdProcesoProductivo ASC, IdOperacion ASC, IdCategoriaEmpleado ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
	 
	 ALTER TABLE OrdenesProduccionMRPCategoriasEmpleados WITH CHECK ADD CONSTRAINT FK_OrdenesProduccionMRPCAtegoriaEmpleados
		 FOREIGN KEY(IdSucursal, NumeroOrdenProduccion, IdTipoComprobante, Letra, CentroEmisor, Orden, IdProducto, IdProcesoProductivo, IdOperacion) 
		   REFERENCES OrdenesProduccionMRPOperaciones (IdSucursal, NumeroOrdenProduccion, IdTipoComprobante, Letra, CentroEmisor, Orden, IdProducto, IdProcesoProductivo, IdOperacion)
END
GO