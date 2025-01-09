SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
GO
IF dbo.ExisteTabla('MRPAQLA') = 0
BEGIN
    CREATE TABLE dbo.MRPAQLA(
	    IdMRPAQLA int NOT NULL,
	    TamanoLoteDesde int NOT NULL,
	    TamanoLoteHasta int NOT NULL,
	    NivelGeneral1 varchar(1) NOT NULL,
	    NivelGeneral2 varchar(1) NOT NULL,
	    NivelGeneral3 varchar(1) NOT NULL,
	    NivelEspecialS1 varchar(1) NOT NULL,
	    NivelEspecialS2 varchar(1) NOT NULL,
	    NivelEspecialS3 varchar(1) NOT NULL,
	    NivelEspecialS4 varchar(1) NOT NULL,
     CONSTRAINT PK_MRPAQLA PRIMARY KEY CLUSTERED (IdMRPAQLA ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
END
GO
IF dbo.ExisteTabla('MRPAQLB') = 0
BEGIN
    CREATE TABLE dbo.MRPAQLB(
	    LimiteCalidadAceptable decimal(10, 5) NOT NULL,
	    CodigoNivel varchar(1) NOT NULL,
	    TamanoMuestreo int NOT NULL,
	    CantidadAceptacion int NOT NULL,
	    CantidadRechazo int NOT NULL,
     CONSTRAINT PK_MRPAQLB PRIMARY KEY CLUSTERED (LimiteCalidadAceptable ASC, CodigoNivel ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
END
GO
UPDATE VP
   SET IdDeposito = MSP.IdDeposito
     , IdUbicacion = MSP.IdUbicacion
  FROM VentasProductos VP
  LEFT JOIN MovimientosStock MS
         ON MS.IdSucursal = VP.IdSucursal
        AND MS.IdTipoComprobante = VP.IdTipoComprobante
        AND MS.Letra = VP.Letra
        AND MS.CentroEmisor = VP.CentroEmisor
        AND MS.NumeroComprobante = VP.NumeroComprobante
  LEFT JOIN MovimientosStockProductos MSP
         ON MSP.IdSucursal = MS.IdSucursal
        AND MSP.IdTipoMovimiento = MS.IdTipoMovimiento
        AND MSP.NumeroMovimiento = MS.NumeroMovimiento
        AND MSP.Orden = VP.Orden
        AND MSP.IdProducto = VP.IdProducto
 WHERE VP.IdUbicacion IS NULL

UPDATE VP
   SET IdDeposito = PS.IdDepositoDefecto
     , IdUbicacion = PS.IdUbicacionDefecto
   FROM VentasProductos VP
   LEFT JOIN ProductosSucursales PS
          ON PS.IdSucursal = VP.IdSucursal
         AND PS.IdProducto = VP.IdProducto
 WHERE VP.IdUbicacion IS NULL

ALTER TABLE VentasProductos ALTER COLUMN IdDeposito INT NOT NULL
ALTER TABLE VentasProductos ALTER COLUMN IdUbicacion INT NOT NULL


PRINT ''
PRINT '1.1. Tabla NovedadesProduccionMRP: Nueva tabla de Novedades'
IF dbo.ExisteTabla('NovedadesProduccionMRP') = 0
BEGIN
    CREATE TABLE NovedadesProduccionMRP(
	    NumeroNovedadesProducccion int NOT NULL,
		CodigoOperacion varchar(30) NOT NULL,
		IdSucursal int NOT NULL,
	    IdTipoComprobante varchar(15) NOT NULL,
	    LetraComprobante varchar(1) NOT NULL,
	    CentroEmisor int NOT NULL,
	    NumeroOrdenProduccion int NOT NULL,
	    Orden int NOT NULL,
	    idProducto varchar(15) NOT NULL,
		idProcesoProductivo bigint NOT NULL,
	    UsuarioAlta varchar(50) NOT NULL,	    
		FechaAlta datetime NOT NULL,
		FechaNovedad datetime NOT NULL,
		IdEmpleado int NOT NULL,

     CONSTRAINT PK_NovedadesProduccionMRP PRIMARY KEY CLUSTERED (NumeroNovedadesProducccion ASC, CodigoOperacion ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]	
	-- FK Empleados.-
	ALTER TABLE NovedadesProduccionMRP  WITH CHECK ADD  CONSTRAINT FK_Novedad_Empleado FOREIGN KEY(IdEmpleado)
		REFERENCES Empleados (IdEmpleado)
    ALTER TABLE NovedadesProduccionMRP CHECK CONSTRAINT FK_Novedad_Empleado
	-- FK Productos.-
	ALTER TABLE NovedadesProduccionMRP  WITH CHECK ADD  CONSTRAINT FK_Novedad_Producto FOREIGN KEY(idProducto)
		REFERENCES Productos (IdProducto)
    ALTER TABLE NovedadesProduccionMRP CHECK CONSTRAINT FK_Novedad_Producto
		-- FK Proceso Productivo.-
	ALTER TABLE NovedadesProduccionMRP  WITH CHECK ADD  CONSTRAINT FK_Novedad_Proceso FOREIGN KEY(idProcesoProductivo)
		REFERENCES MRPProcesosProductivos (idProcesoProductivo)
    ALTER TABLE NovedadesProduccionMRP CHECK CONSTRAINT FK_Novedad_Proceso

END
GO

PRINT ''
PRINT '1.2. Tabla NovedadesProduccionMRPTiempos: Nueva tabla de Novedades'
IF dbo.ExisteTabla('NovedadesProduccionMRPTiempos') = 0
BEGIN
    CREATE TABLE NovedadesProduccionMRPTiempos(
	    NumeroNovedadesProducccion int NOT NULL,
		CodigoOperacion varchar(30) NOT NULL,
		IdTipoDeclaracion Varchar(50) NOT NULL,
		FechaHoraInicio datetime NOT NULL,
		FechaHoraFin datetime NOT NULL,
		IdConcepto int NULL,
     CONSTRAINT PK_NovedadesProduccionMRPTiempos PRIMARY KEY CLUSTERED (NumeroNovedadesProducccion ASC, CodigoOperacion ASC, IdTipoDeclaracion ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]	

	ALTER TABLE NovedadesProduccionMRPTiempos  WITH CHECK ADD  CONSTRAINT FK_Novedad_Conceptos FOREIGN KEY(IdConcepto)
		REFERENCES MRPConceptosNoProductivos (idConceptoNoProductivo)
    ALTER TABLE NovedadesProduccionMRPTiempos CHECK CONSTRAINT FK_Novedad_Conceptos

	ALTER TABLE NovedadesProduccionMRPTiempos  WITH CHECK ADD  CONSTRAINT FK_NovedadTiempo_Conceptos FOREIGN KEY(NumeroNovedadesProducccion, CodigoOperacion)
		REFERENCES NovedadesProduccionMRP (NumeroNovedadesProducccion, CodigoOperacion)
    ALTER TABLE NovedadesProduccionMRPTiempos CHECK CONSTRAINT FK_NovedadTiempo_Conceptos
END
GO

PRINT ''
PRINT '1.3. Tabla NovedadesProduccionMRPProductos: Nueva tabla de Novedades'
IF dbo.ExisteTabla('NovedadesProduccionMRPProductos') = 0
BEGIN
    CREATE TABLE NovedadesProduccionMRPProductos(
	    NumeroNovedadesProducccion int NOT NULL,
		CodigoOperacion varchar(30) NOT NULL,
		IdProducto varchar(15) NOT NULL,
		EsProductoNecesario bit NOT NULL,
		EsProductoAgregado bit NOT NULL,
		Cantidad decimal(16,4) NOT NULL,
	    IdSucursal int NOT NULL,
	    IdDeposito int NOT NULL,
		IdUbicacion int NOT NULL,
		PrecioCosto decimal(16,4) NOT NULL,
		InformeCalidadNumero varchar(50) NULL, 
		InformeCalidadLink varchar(MAX) NULL,
	CONSTRAINT PK_NovedadesProduccionMRPProductos PRIMARY KEY CLUSTERED (NumeroNovedadesProducccion ASC, CodigoOperacion ASC, IdProducto ASC, EsProductoNecesario ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]	

	ALTER TABLE NovedadesProduccionMRPProductos  WITH CHECK ADD  CONSTRAINT FK_Novedad_Productos FOREIGN KEY(IdProducto)
		REFERENCES Productos (IdProducto)
    ALTER TABLE NovedadesProduccionMRPProductos CHECK CONSTRAINT FK_Novedad_Productos

END
GO

PRINT ''
PRINT '1.4. Tabla NovedadesProduccionMRPProductosLotes: Nueva tabla de Novedades'
IF dbo.ExisteTabla('NovedadesProduccionMRPProductosLotes') = 0
BEGIN
    CREATE TABLE NovedadesProduccionMRPProductosLotes(
	    NumeroNovedadesProducccion int NOT NULL,
		CodigoOperacion varchar(30) NOT NULL,
		IdProducto varchar(15) NOT NULL,
		IdLote varchar(30) NOT NULL,
		Cantidad decimal(16,4) NOT NULL,
	CONSTRAINT PK_NovedadesProduccionMRPProductosLotes PRIMARY KEY CLUSTERED (NumeroNovedadesProducccion ASC, CodigoOperacion ASC, IdProducto ASC, IdLote ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]	

	ALTER TABLE NovedadesProduccionMRPProductosLotes  WITH CHECK ADD  CONSTRAINT FK_Novedad_ProductosLotes FOREIGN KEY(IdProducto)
		REFERENCES Productos (IdProducto)
    ALTER TABLE NovedadesProduccionMRPProductosLotes CHECK CONSTRAINT FK_Novedad_ProductosLotes

END
GO

IF dbo.ExisteTabla('ProduccionProductosNrosSerie') = 0
BEGIN
    CREATE TABLE [dbo].[ProduccionProductosNrosSerie](
	    [IdSucursal] [int] NOT NULL,
	    [IdProduccion] [int] NOT NULL,
	    [Orden] [int] NOT NULL,
	    [IdProducto] [varchar](15) NOT NULL,
	    [NroSerie] [varchar](50) NOT NULL,
     CONSTRAINT [PK_ProduccionProductosNrosSerie] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdProduccion] ASC, [Orden] ASC, [IdProducto] ASC, [NroSerie] ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
END
GO

IF dbo.ExisteFK('FK_ProduccionProductosNrosSerie_ProduccionProductos') = 0
BEGIN
    ALTER TABLE [dbo].[ProduccionProductosNrosSerie]  WITH CHECK ADD  CONSTRAINT [FK_ProduccionProductosNrosSerie_ProduccionProductos] FOREIGN KEY([IdSucursal], [IdProduccion], [Orden], [IdProducto])
        REFERENCES [dbo].[ProduccionProductos] ([IdSucursal], [IdProduccion], [Orden], [IdProducto])
    ALTER TABLE [dbo].[ProduccionProductosNrosSerie] CHECK CONSTRAINT [FK_ProduccionProductosNrosSerie_ProduccionProductos]
END
GO

IF dbo.ExisteCampo('ProduccionProductosComponentes', 'IdDeposito') = 0
BEGIN
    ALTER TABLE dbo.ProduccionProductosComponentes ADD IdDeposito int NULL
    ALTER TABLE dbo.ProduccionProductosComponentes ADD IdUbicacion int NULL
END
GO
IF dbo.ExisteFK('FK_ProduccionProductosComponentes_SucursalesUbicaciones') = 0
BEGIN
    ALTER TABLE dbo.ProduccionProductosComponentes ADD CONSTRAINT FK_ProduccionProductosComponentes_SucursalesUbicaciones
        FOREIGN KEY (IdDeposito, IdSucursal, IdUbicacion)
        REFERENCES dbo.SucursalesUbicaciones (IdDeposito, IdSucursal, IdUbicacion)
        ON UPDATE  NO ACTION ON DELETE  NO ACTION 
END
GO

UPDATE PPC
   SET IdDeposito = PS.IdDepositoDefecto
     , IdUbicacion = PS.IdUbicacionDefecto
  FROM ProduccionProductosComponentes PPC
 INNER JOIN ProductosSucursales PS ON PS.IdSucursal = PPC.IdSucursal AND PS.IdProducto = PPC.IdProducto
 WHERE IdUbicacion IS NULL

ALTER TABLE dbo.ProduccionProductosComponentes ALTER COLUMN IdDeposito int NOT NULL
ALTER TABLE dbo.ProduccionProductosComponentes ALTER COLUMN IdUbicacion int NOT NULL


IF dbo.ExistePK('PK_ProduccionProductosComponentes') = 1
BEGIN
    IF dbo.ExisteFK('FK_ProduccionProductosComponentesNrosSerie_ProduccionProductosComponentes') = 1
    BEGIN
        ALTER TABLE ProduccionProductosComponentesNrosSerie DROP CONSTRAINT FK_ProduccionProductosComponentesNrosSerie_ProduccionProductosComponentes
    END
    IF dbo.ExisteFK('FK_ProduccionProductosComponentesLotes_ProduccionProductosComponentes') = 1
    BEGIN
        ALTER TABLE ProduccionProductosComponentesLotes DROP CONSTRAINT FK_ProduccionProductosComponentesLotes_ProduccionProductosComponentes
    END
    ALTER TABLE [dbo].[ProduccionProductosComponentes] DROP CONSTRAINT [PK_ProduccionProductosComponentes] WITH ( ONLINE = OFF )
END
GO

/****** Object:  Index [PK_ProduccionProductosComponentes]    Script Date: 27/9/2023 19:02:47 ******/
IF dbo.ExistePK('PK_ProduccionProductosComponentes') = 0
BEGIN
    ALTER TABLE [dbo].[ProduccionProductosComponentes] ADD  CONSTRAINT [PK_ProduccionProductosComponentes] PRIMARY KEY CLUSTERED 
    (
	    [IdSucursal] ASC,
	    [IdProduccion] ASC,
	    [Orden] ASC,
	    [IdProducto] ASC,
        [IdProductoComponente] ASC,
	    [SecuenciaFormula] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
END
GO

IF dbo.ExisteTabla('ProduccionProductosComponentesLotes') = 0
BEGIN
    CREATE TABLE dbo.ProduccionProductosComponentesLotes(
	    IdSucursal int NOT NULL,
	    IdProduccion int NOT NULL,
	    IdProducto varchar(15) NOT NULL,
	    Orden int NOT NULL,
	    IdProductoComponente varchar(15) NOT NULL,
	    SecuenciaFormula int NOT NULL,
	    IdLote varchar(30) NOT NULL,
	    Cantidad decimal(16, 4) NOT NULL,
    CONSTRAINT PK_ProduccionProductosComponentesLotes PRIMARY KEY CLUSTERED 
    (IdSucursal ASC, IdProduccion ASC, IdProducto ASC, Orden ASC, IdProductoComponente ASC, SecuenciaFormula ASC, IdLote ASC)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
END
GO

IF dbo.ExisteFK('FK_ProduccionProductosComponentesLotes_ProduccionProductosComponentes') = 0
BEGIN
    ALTER TABLE dbo.ProduccionProductosComponentesLotes ADD CONSTRAINT FK_ProduccionProductosComponentesLotes_ProduccionProductosComponentes
        FOREIGN KEY (IdSucursal, IdProduccion, Orden, IdProducto, IdProductoComponente, SecuenciaFormula)
        REFERENCES dbo.ProduccionProductosComponentes (IdSucursal, IdProduccion, Orden, IdProducto, IdProductoComponente, SecuenciaFormula)
        ON UPDATE  NO ACTION ON DELETE  NO ACTION 
END
GO

IF dbo.ExisteCampo('ProduccionProductosComponentes', 'IdLote') = 1
BEGIN
    EXEC ('
    INSERT INTO dbo.ProduccionProductosComponentesLotes
        (IdSucursal, IdProduccion, IdProducto, Orden, IdProductoComponente, SecuenciaFormula, IdLote, Cantidad)
    SELECT 
         IdSucursal, IdProduccion, IdProducto, Orden, IdProductoComponente, SecuenciaFormula, IdLote, Cantidad
        FROM ProduccionProductosComponentes
        WHERE IdLote IS NOT NULL')
END
GO
IF dbo.ExisteCampo('ProduccionProductosComponentes', 'IdLote') = 1
BEGIN
    EXEC SP_RENAME 'ProduccionProductosComponentes.IdLote', 'IdLote_Viejo', 'COLUMN'
END
GO

IF dbo.ExisteTabla('ProduccionProductosComponentesNrosSerie') = 0
BEGIN
    CREATE TABLE dbo.ProduccionProductosComponentesNrosSerie(
	    IdSucursal int NOT NULL,
	    IdProduccion int NOT NULL,
	    IdProducto varchar(15) NOT NULL,
	    Orden int NOT NULL,
	    IdProductoComponente varchar(15) NOT NULL,
	    SecuenciaFormula int NOT NULL,
	    NroSerie varchar(50) NOT NULL,
     CONSTRAINT PK_ProduccionProductosComponentesNrosSerie PRIMARY KEY CLUSTERED 
    (IdSucursal ASC, IdProduccion ASC, IdProducto ASC, Orden ASC, IdProductoComponente ASC, SecuenciaFormula ASC, NroSerie ASC)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
END
GO

IF dbo.ExisteFK('FK_ProduccionProductosComponentesNrosSerie_ProduccionProductosComponentes') = 0
BEGIN
    ALTER TABLE dbo.ProduccionProductosComponentesNrosSerie  WITH CHECK ADD  CONSTRAINT FK_ProduccionProductosComponentesNrosSerie_ProduccionProductosComponentes 
    FOREIGN KEY(IdSucursal, IdProduccion, Orden, IdProducto, IdProductoComponente, SecuenciaFormula)
    REFERENCES dbo.ProduccionProductosComponentes (IdSucursal, IdProduccion, Orden, IdProducto, IdProductoComponente, SecuenciaFormula)

    ALTER TABLE dbo.ProduccionProductosComponentesNrosSerie CHECK CONSTRAINT FK_ProduccionProductosComponentesNrosSerie_ProduccionProductosComponentes
END
GO
