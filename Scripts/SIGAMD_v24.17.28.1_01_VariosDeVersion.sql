
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
IF dbo.ExisteTabla('ComprasTransferencias') = 0
BEGIN


/****** Object:  Table [dbo].[ComprasTransferencias]    Script Date: 15/5/2024 10:42:54 ******/
SET ANSI_NULLS ON
--GO

SET QUOTED_IDENTIFIER ON
--GO

CREATE TABLE [dbo].[ComprasTransferencias](
	[IdSucursal] [int] NOT NULL,
	[IdTipoComprobante] [varchar](15) NOT NULL,
	[Letra] [varchar](1) NOT NULL,
	[CentroEmisor] [int] NOT NULL,
	[NumeroComprobante] [bigint] NOT NULL,
	[IdProveedor] [bigint] NOT NULL,
	[Orden] [int] NOT NULL,
	[Importe] [decimal](14, 2) NOT NULL,
	[IdCuentaBancaria] [int] NOT NULL,
	[IdSucursalLibroBanco] [int] NULL,
	[IdCuentaBancariaLibroBanco] [int] NULL,
	[NumeroMovimientoLibroBanco] [int] NULL,
 CONSTRAINT [PK_ComprasTransferencias] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdTipoComprobante] ASC,
	[Letra] ASC,
	[CentroEmisor] ASC,
	[NumeroComprobante] ASC,
	[IdProveedor] ASC,
	[Orden] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
--GO

ALTER TABLE [dbo].[ComprasTransferencias]  WITH CHECK ADD  CONSTRAINT [FK_ComprasTransferencias_CuentasBancarias] FOREIGN KEY([IdCuentaBancaria])
REFERENCES [dbo].[CuentasBancarias] ([IdCuentaBancaria])
--GO

ALTER TABLE [dbo].[ComprasTransferencias] CHECK CONSTRAINT [FK_ComprasTransferencias_CuentasBancarias]
--GO

ALTER TABLE [dbo].[ComprasTransferencias]  WITH CHECK ADD  CONSTRAINT [FK_ComprasTransferencias_LibrosBancos] FOREIGN KEY([IdSucursalLibroBanco], [IdCuentaBancariaLibroBanco], [NumeroMovimientoLibroBanco])
REFERENCES [dbo].[LibrosBancos] ([IdSucursal], [IdCuentaBancaria], [NumeroMovimiento])
--GO

ALTER TABLE [dbo].[ComprasTransferencias] CHECK CONSTRAINT [FK_ComprasTransferencias_LibrosBancos]
--GO

ALTER TABLE [dbo].[ComprasTransferencias]  WITH CHECK ADD  CONSTRAINT [FK_ComprasTransferencias_Compras] FOREIGN KEY([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdProveedor])
REFERENCES [dbo].[Compras] ([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdProveedor])
--GO

ALTER TABLE [dbo].[ComprasTransferencias] CHECK CONSTRAINT [FK_ComprasTransferencias_Compras]
--GO

END
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
IF dbo.ExisteTabla('EstadosOrdenesCalidad') = 0
BEGIN
    CREATE TABLE EstadosOrdenesCalidad(
	    IdEstadoCalidad varchar(15) NOT NULL,
	    TipoEstadoCalidad varchar(15) NOT NULL,
	    IdTipoComprobante varchar(15) NULL,
	    Orden int NOT NULL,
	    BackColor int NULL,
	    ForeColor int NULL,
     CONSTRAINT PK_EstadosOrdenesCalidad PRIMARY KEY CLUSTERED (IdEstadoCalidad ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
END
GO

IF dbo.ExisteFK('FK_EstadosOrdenesCalidad_TiposComprobantes') = 0
BEGIN
    ALTER TABLE dbo.EstadosOrdenesCalidad  WITH CHECK ADD  CONSTRAINT FK_EstadosOrdenesCalidad_TiposComprobantes FOREIGN KEY(IdTipoComprobante)
        REFERENCES dbo.TiposComprobantes (IdTipoComprobante)
    ALTER TABLE dbo.EstadosOrdenesCalidad CHECK CONSTRAINT FK_EstadosOrdenesCalidad_TiposComprobantes
END
GO

IF NOT EXISTS(SELECT * FROM EstadosOrdenesCalidad)
BEGIN
    INSERT INTO EstadosOrdenesCalidad 
            (IdEstadoCalidad, TipoEstadoCalidad, IdTipoComprobante, Orden, BackColor, ForeColor)
    VALUES  ('PENDIENTE',  'PENDIENTE' , NULL, 10, NULL     , NULL),
            ('EN PROCESO', 'ENPROCESO' , NULL, 20, -13289985, -1),
            ('ANULADO',    'ANULADO'   , NULL, 30, -256     , NULL),
            ('ACEPTADO',   'ACEPTADO'  , NULL, 40, -16736945, NULL),
            ('RECHAZADO',  'RECHAZADO' , NULL, 50, -65536   , -1)
END
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
IF dbo.ExisteFuncion('Calidad') = 1 AND dbo.ExisteFuncion('EstadosOrdenesCalidadABM') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('EstadosOrdenesCalidadABM', 'ABM Estados de Ordenes de Calidad', 'ABM Estados de Ordenes de Calidad', 'True', 'False', 'True', 'True'
        ,'Calidad', 2350, 'Eniac.Win', 'EstadosOrdenesCalidadABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'EstadosOrdenesCalidadABM' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
IF dbo.ExisteTabla('CalidadListasControlProductos') = 1
BEGIN
	IF dbo.ExisteFK('FK_CalidadListasControlProductos_Productos') = 1
	BEGIN
		ALTER TABLE CalidadListasControlProductos	DROP CONSTRAINT FK_CalidadListasControlProductos_Productos
	END
	IF dbo.ExisteFK('FK_CalidadListasControlProductos_ListaControl') = 1
	BEGIN
		ALTER TABLE CalidadListasControlProductos	DROP CONSTRAINT FK_CalidadListasControlProductos_ListaControl
	END
	IF dbo.ExisteFK('FK_CalidadListasControlProductos_ListaControlItem') = 1
	BEGIN
		ALTER TABLE CalidadListasControlProductos	DROP CONSTRAINT FK_CalidadListasControlProductos_ListaControlItem
	END
	DROP TABLE CalidadListasControlProductos
END

IF dbo.ExisteTabla('CalidadListasControlProductos') = 0
BEGIN
	CREATE TABLE CalidadListasControlProductos(
		IdProducto varchar(15) NOT NULL,
		IdListaControl int NOT NULL,
		FechaActualizacion datetime NOT NULL,
		IdUsuario varchar(10) NOT NULL
	 CONSTRAINT [PK_CalidadListascontrolProductos] PRIMARY KEY CLUSTERED 
	(
		IdProducto ASC,
		IdListaControl ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	ALTER TABLE CalidadListasControlProductos  
		WITH CHECK ADD  CONSTRAINT FK_CalidadListasControlProductos_Productos FOREIGN KEY(IdProducto)
	REFERENCES Productos (IdProducto)

	ALTER TABLE CalidadListasControlProductos  
		WITH CHECK ADD  CONSTRAINT FK_CalidadListasControlProductos_ListaControl FOREIGN KEY(IdListaControl)
	REFERENCES CalidadListasControl (IdListaControl)
END
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
IF dbo.ExisteCampo('CuentasCorrientesTarjetas', 'Orden') = 0
BEGIN
    ALTER TABLE CuentasCorrientesTarjetas ADD Orden int NULL
END
GO

IF dbo.ExistePK('PK_CuentasCorrientesTarjetas') = 1
BEGIN
    ALTER TABLE CuentasCorrientesTarjetas DROP CONSTRAINT PK_CuentasCorrientesTarjetas WITH ( ONLINE = OFF )
END
GO

UPDATE CuentasCorrientesTarjetas
   SET Orden = 1
 WHERE Orden IS NULL;

ALTER TABLE CuentasCorrientesTarjetas ALTER COLUMN Orden int NOT NULL
GO

/****** Object:  Index PK_CuentasCorrientesTarjetas    Script Date: 17/5/2024 17:46:31 ******/
IF dbo.ExistePK('PK_CuentasCorrientesTarjetas') = 0
BEGIN
    ALTER TABLE dbo.CuentasCorrientesTarjetas ADD  CONSTRAINT PK_CuentasCorrientesTarjetas PRIMARY KEY CLUSTERED 
        (IdSucursal ASC, IdTipoComprobante ASC, Letra ASC, CentroEmisor ASC, NumeroComprobante ASC,
         IdTarjeta ASC, IdBanco ASC, Orden ASC)
        WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, 
              ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
END
GO
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
IF dbo.ExisteTabla('CuentasCorrientesProvTransferencias') = 0
BEGIN

/****** Object:  Table [dbo].[CuentasCorrientesTransferencias]    Script Date: 20/5/2024 09:48:40 ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[CuentasCorrientesProvTransferencias](
	[IdSucursal] [int] NOT NULL,
	[IdTipoComprobante] [varchar](15) NOT NULL,
	[Letra] [varchar](1) NOT NULL,
	[CentroEmisor] [int] NOT NULL,
	[NumeroComprobante] [bigint] NOT NULL,
	[IdProveedor] [bigint] NOT NULL,
	[Orden] [int] NOT NULL,
	[Importe] [decimal](14, 2) NOT NULL,
	[IdCuentaBancaria] [int] NOT NULL,
	[IdSucursalLibroBanco] [int] NULL,
	[IdCuentaBancariaLibroBanco] [int] NULL,
	[NumeroMovimientoLibroBanco] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdProveedor] ASC,
	[IdTipoComprobante] ASC,
	[Letra] ASC,
	[CentroEmisor] ASC,
	[NumeroComprobante] ASC,
	[Orden] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[CuentasCorrientesProvTransferencias]  WITH CHECK ADD  CONSTRAINT [FK_CuentasCorrientesProvTransferencias_CuentasBancarias] FOREIGN KEY([IdCuentaBancaria])
REFERENCES [dbo].[CuentasBancarias] ([IdCuentaBancaria])


ALTER TABLE [dbo].[CuentasCorrientesProvTransferencias] CHECK CONSTRAINT [FK_CuentasCorrientesProvTransferencias_CuentasBancarias]


ALTER TABLE [dbo].[CuentasCorrientesProvTransferencias]  WITH CHECK ADD  CONSTRAINT [FK_CuentasCorrientesProvTransferencias_CuentasCorrientesProv] FOREIGN KEY([IdSucursal], [IdProveedor], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante])
REFERENCES [dbo].[CuentasCorrientesProv] ([IdSucursal], [IdProveedor], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante])


ALTER TABLE [dbo].[CuentasCorrientesProvTransferencias] CHECK CONSTRAINT [FK_CuentasCorrientesProvTransferencias_CuentasCorrientesProv]


ALTER TABLE [dbo].[CuentasCorrientesProvTransferencias]  WITH CHECK ADD  CONSTRAINT [FK_CuentasCorrientesProvTransferencias_LibrosBancos] FOREIGN KEY([IdSucursalLibroBanco], [IdCuentaBancariaLibroBanco], [NumeroMovimientoLibroBanco])
REFERENCES [dbo].[LibrosBancos] ([IdSucursal], [IdCuentaBancaria], [NumeroMovimiento])


ALTER TABLE [dbo].[CuentasCorrientesProvTransferencias] CHECK CONSTRAINT [FK_CuentasCorrientesProvTransferencias_LibrosBancos]

END
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
IF dbo.ExisteFK('FK_EstadosOrdenesCalidad_TiposComprobantes') = 1
BEGIN
    ALTER TABLE dbo.EstadosOrdenesCalidad DROP CONSTRAINT FK_EstadosOrdenesCalidad_TiposComprobantes
END
GO

IF dbo.ExisteCampo('EstadosOrdenesCalidad', 'IdTipoComprobante') = 1
BEGIN
    ALTER TABLE dbo.EstadosOrdenesCalidad DROP COLUMN IdTipoComprobante
END
GO
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

IF dbo.ExisteTabla('UnidadesDeMedidasConversiones') = 0
BEGIN
    CREATE TABLE UnidadesDeMedidasConversiones(
	    IdUnidadMedidaDesde varchar(10) NOT NULL,
	    IdUnidadMedidaHacia varchar(10) NOT NULL,
	    FactorConversion decimal(14, 10) NOT NULL,
	    Fija bit NOT NULL,
     CONSTRAINT PK_UnidadesDeMedidasConversiones PRIMARY KEY CLUSTERED (IdUnidadMedidaDesde ASC, IdUnidadMedidaHacia ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
END
GO

IF dbo.ExisteFK('FK_UnidadesDeMedidasConversiones_UnidadesDeMedidasDesde') = 0
BEGIN
    ALTER TABLE dbo.UnidadesDeMedidasConversiones  WITH CHECK ADD  CONSTRAINT FK_UnidadesDeMedidasConversiones_UnidadesDeMedidasDesde FOREIGN KEY(IdUnidadMedidaDesde)
        REFERENCES dbo.UnidadesDeMedidas (IdUnidadDeMedida)
    ALTER TABLE dbo.UnidadesDeMedidasConversiones CHECK CONSTRAINT FK_UnidadesDeMedidasConversiones_UnidadesDeMedidasDesde
END
GO

IF dbo.ExisteFK('FK_UnidadesDeMedidasConversiones_UnidadesDeMedidasHacia') = 0
BEGIN
    ALTER TABLE dbo.UnidadesDeMedidasConversiones  WITH CHECK ADD  CONSTRAINT FK_UnidadesDeMedidasConversiones_UnidadesDeMedidasHacia FOREIGN KEY(IdUnidadMedidaHacia)
        REFERENCES dbo.UnidadesDeMedidas (IdUnidadDeMedida)
    ALTER TABLE dbo.UnidadesDeMedidasConversiones CHECK CONSTRAINT FK_UnidadesDeMedidasConversiones_UnidadesDeMedidasHacia
END
GO
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
DECLARE @idBuscador int = 34
DECLARE @alineacion_der int = 64
DECLARE @alineacion_izq int = 16

MERGE INTO Buscadores AS D
        USING (SELECT @idBuscador IdBuscador, 'Unidades de Medida' Titulo, 600 AnchoAyuda, 'Grilla' IniciaConFocoEn, '' ColumaBusquedaInicial) AS O ON D.IdBuscador = O.IdBuscador
    WHEN MATCHED THEN
        UPDATE SET D.Titulo                 = O.Titulo
                 , D.AnchoAyuda             = O.AnchoAyuda
                 , D.IniciaConFocoEn        = O.IniciaConFocoEn
                 , D.ColumaBusquedaInicial  = O.ColumaBusquedaInicial
    WHEN NOT MATCHED THEN 
        INSERT (  IdBuscador,   Titulo,   AnchoAyuda,   IniciaConFocoEn,   ColumaBusquedaInicial) 
        VALUES (O.IdBuscador, O.Titulo, O.AnchoAyuda, O.IniciaConFocoEn, O.ColumaBusquedaInicial)
;
MERGE INTO BuscadoresCampos AS D
        USING (SELECT @idBuscador IdBuscador, 'IdUnidadDeMedida'     IdBuscadorNombreCampo, 1 Orden, 'Código'           Titulo, @alineacion_der Alineacion, 80  Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador IdBuscador, 'NombreUnidadDeMedida' IdBuscadorNombreCampo, 2 Orden, 'Unidad de Medida' Titulo, @alineacion_izq Alineacion, 150 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador IdBuscador, 'ConversionAKilos'     IdBuscadorNombreCampo, 3 Orden, 'Conv. a Kilos'    Titulo, @alineacion_der Alineacion, 120 Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila UNION ALL
               SELECT @idBuscador IdBuscador, 'IdAFIP'               IdBuscadorNombreCampo, 4 Orden, 'Código AFIP'      Titulo, @alineacion_der Alineacion, 60  Ancho, '' Formato, NULL Condicion, NULL Valor, NULL ColorFila
               ) AS O ON D.IdBuscador = O.IdBuscador AND D.IdBuscadorNombreCampo = O.IdBuscadorNombreCampo
    WHEN MATCHED THEN
        UPDATE SET D.Orden      = O.Orden
                 , D.Titulo     = O.Titulo
                 , D.Alineacion = O.Alineacion
                 , D.Ancho      = O.Ancho
                 , D.Formato    = O.Formato
                 , D.Condicion  = O.Condicion
                 , D.Valor      = O.Valor
                 , D.ColorFila  = O.ColorFila
    WHEN NOT MATCHED THEN 
        INSERT (  IdBuscador,   IdBuscadorNombreCampo,   Orden,   Titulo,   Alineacion,   Ancho,   Formato,   Condicion,   Valor,   ColorFila) 
        VALUES (O.IdBuscador, O.IdBuscadorNombreCampo, O.Orden, O.Titulo, O.Alineacion, O.Ancho, O.Formato, O.Condicion, O.Valor, O.ColorFila)
;

----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
IF dbo.ExisteFuncion('Archivos') = 1 AND dbo.ExisteFuncion('UnidadesMedidasConversionesABM') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('UnidadesMedidasConversionesABM', 'Unidades de Medida - Conversiones', 'Unidades de Medida - Conversiones', 'True', 'False', 'True', 'True'
        ,'Archivos', 222, 'Eniac.Win', 'UnidadesDeMedidasConversionesABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'UnidadesMedidasConversionesABM' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
