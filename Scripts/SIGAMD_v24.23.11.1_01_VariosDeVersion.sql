IF dbo.ExisteCampo('CuentasCorrientesProv', 'SaldoCtaCte') = 0
BEGIN
ALTER TABLE CuentasCorrientesProv ADD SaldoCtaCte decimal(14,2) null
END
GO

IF dbo.ExisteFuncion('CuentasCorrientesProveedores') = 1 AND dbo.ExisteFuncion('GenerarMinutasProveedores') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('GenerarMinutasProveedores', 'Generar Minutas Masivas a Proveedores', 'Generar Minutas Masivas a Proveedores', 'True', 'False', 'True', 'True'
        ,'CuentasCorrientesProveedores', 61, 'Eniac.Win', 'GenerarMinutasProveedores', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'GenerarMinutasProveedores' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO


IF dbo.ExisteTabla('CRMNovedadesProductosLotes') = 0
BEGIN
CREATE TABLE [dbo].[CRMNovedadesProductosLotes](
    [IdTipoNovedad] [varchar](10) NOT NULL,
	[IdNovedad] [bigint] NOT NULL,
	[LetraNovedad] [varchar](1) NOT NULL,
	[CentroEmisor] [smallint] NOT NULL,
	[IdProducto] [varchar](15) NOT NULL,
	[OrdenProducto] [int] NOT NULL,	
	[IdLote] [varchar](30) NOT NULL,
	[FechaIngreso] [datetime] NOT NULL,
	[FechaVencimiento] [datetime] NULL,
	[CantidadActual] [decimal](16, 4) NOT NULL,
	[IdSucursal] [int] NOT NULL,
	[IdDeposito] [int] NOT NULL,
	[IdUbicacion] [int] NOT NULL,
 CONSTRAINT [PK_CRMNovedadesProductosLotes] PRIMARY KEY CLUSTERED 
(
	[IdTipoNovedad] ASC,
	[IdNovedad] ASC,
	[LetraNovedad] ASC,
	[CentroEmisor] ASC,
	[IdProducto] ASC,
	[OrdenProducto] ASC,	
	[IdLote] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[CRMNovedadesProductosLotes]  WITH CHECK ADD  CONSTRAINT [FK_CRMNovedadesProductosLotes_Depositos] FOREIGN KEY([IdDeposito], [IdSucursal])
REFERENCES [dbo].[SucursalesDepositos] ([IdDeposito], [IdSucursal])

ALTER TABLE [dbo].[CRMNovedadesProductosLotes] CHECK CONSTRAINT [FK_CRMNovedadesProductosLotes_Depositos]

ALTER TABLE [dbo].[CRMNovedadesProductosLotes]  WITH CHECK ADD  CONSTRAINT [FK_CRMNovedadesProductosLotes_Ubicaciones] FOREIGN KEY([IdDeposito], [IdSucursal], [IdUbicacion])
REFERENCES [dbo].[SucursalesUbicaciones] ([IdDeposito], [IdSucursal], [IdUbicacion])

ALTER TABLE [dbo].[CRMNovedadesProductosLotes] CHECK CONSTRAINT [FK_CRMNovedadesProductosLotes_Ubicaciones]

ALTER TABLE [dbo].[CRMNovedadesProductosLotes]  WITH CHECK ADD  CONSTRAINT [FK_CRMNovedadesProductosLotes_CRMNovedadesProductos] FOREIGN KEY([IdTipoNovedad], [IdNovedad], [LetraNovedad], [CentroEmisor], [IdProducto], [OrdenProducto])
REFERENCES [dbo].[CRMNovedadesProductos]  ([IdTipoNovedad], [IdNovedad], [LetraNovedad], [CentroEmisor], [IdProducto], [OrdenProducto])
 
ALTER TABLE [dbo].[CRMNovedadesProductosLotes] CHECK CONSTRAINT [FK_CRMNovedadesProductosLotes_CRMNovedadesProductos]
END



IF dbo.ExisteTabla('CRMNovedadesProductosNrosSerie ') = 0
BEGIN
CREATE TABLE [dbo].[CRMNovedadesProductosNrosSerie](
    [IdTipoNovedad] [varchar](10) NOT NULL,
	[IdNovedad] [bigint] NOT NULL,
	[LetraNovedad] [varchar](1) NOT NULL,
	[CentroEmisor] [smallint] NOT NULL,
	[IdProducto] [varchar](15) NOT NULL,
	[OrdenProducto] [int] NOT NULL,	
	[NroSerie] [varchar](50) NOT NULL,
	[IdSucursal] [int] NOT NULL,
	[IdDeposito] [int] NOT NULL,
	[IdUbicacion] [int] NOT NULL,
 CONSTRAINT [PK_CRMNovedadesProductosNrosSerie] PRIMARY KEY CLUSTERED 
(
	[IdTipoNovedad] ASC,
	[IdNovedad] ASC,
	[LetraNovedad] ASC,
	[CentroEmisor] ASC,
	[IdProducto] ASC,
	[OrdenProducto] ASC,	
	[NroSerie] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[CRMNovedadesProductosNrosSerie]  WITH CHECK ADD  CONSTRAINT [FK_CRMNovedadesProductosNrosSerie_Depositos] FOREIGN KEY([IdDeposito], [IdSucursal])
REFERENCES [dbo].[SucursalesDepositos] ([IdDeposito], [IdSucursal])

ALTER TABLE [dbo].[CRMNovedadesProductosNrosSerie] CHECK CONSTRAINT [FK_CRMNovedadesProductosNrosSerie_Depositos]

ALTER TABLE [dbo].[CRMNovedadesProductosNrosSerie]  WITH CHECK ADD  CONSTRAINT [FK_CRMNovedadesProductosNrosSerie_Ubicaciones] FOREIGN KEY([IdDeposito], [IdSucursal], [IdUbicacion])
REFERENCES [dbo].[SucursalesUbicaciones] ([IdDeposito], [IdSucursal], [IdUbicacion])

ALTER TABLE [dbo].[CRMNovedadesProductosNrosSerie] CHECK CONSTRAINT [FK_CRMNovedadesProductosNrosSerie_Ubicaciones]

ALTER TABLE [dbo].[CRMNovedadesProductosNrosSerie]  WITH CHECK ADD  CONSTRAINT [FK_CRMNovedadesProductosNrosSerie_CRMNovedadesProductos] FOREIGN KEY([IdTipoNovedad], [IdNovedad], [LetraNovedad], [CentroEmisor], [IdProducto], [OrdenProducto])
REFERENCES [dbo].[CRMNovedadesProductos]  ([IdTipoNovedad], [IdNovedad], [LetraNovedad], [CentroEmisor], [IdProducto], [OrdenProducto])
 
ALTER TABLE [dbo].[CRMNovedadesProductosNrosSerie] CHECK CONSTRAINT [FK_CRMNovedadesProductosNrosSerie_CRMNovedadesProductos]
END


IF dbo.ExisteCampo('CRMNovedadesProductos','IdSucursalActual') = 0
BEGIN
ALTER TABLE CRMNovedadesProductos ADD IdSucursalActual int NULL
ALTER TABLE CRMNovedadesProductos ADD IdDepositoActual int NULL
ALTER TABLE CRMNovedadesProductos ADD IdUbicacionActual int NULL
ALTER TABLE CRMNovedadesProductos ADD IdsucursalAnterior int NULL
ALTER TABLE CRMNovedadesProductos ADD IdDepositoAnterior int NULL
ALTER TABLE CRMNovedadesProductos ADD IdUbicacionAnterior int NULL
ALTER TABLE CRMNovedadesProductos ADD StockReservadoProducto bit null
END
GO

UPDATE CRMNovedadesProductos SET StockReservadoProducto = 'True'
GO
ALTER TABLE CRMNovedadesProductos ALTER COLUMN StockReservadoProducto bit not null
GO


    PRINT '-- movimiento para reserva y reserva devolucion'
 IF (NOT EXISTS(SELECT * FROM TiposMovimientos where IdTipoMovimiento = 'SRV_DEVRESERVA'))
        BEGIN

INSERT [dbo].[TiposMovimientos] ([IdTipoMovimiento], [Descripcion], [CoeficienteStock], [ComprobantesAsociados], 
[AsociaSucursal], [MuestraCombo], [HabilitaDestinatario], [HabilitaRubro], [Imprime], [CargaPrecio], 
[IdContraTipoMovimiento], [HabilitaEmpleado], [ReservaMercaderia]) 
VALUES (N'SRV_DEVRESERVA', N'Devolucion Reserva Servic', -1, NULL, 0, 0, 0, 0, 0, N'NO', NULL, 0, 1)

INSERT [dbo].[TiposMovimientos] ([IdTipoMovimiento], [Descripcion], [CoeficienteStock], [ComprobantesAsociados], 
[AsociaSucursal], [MuestraCombo], [HabilitaDestinatario], [HabilitaRubro], [Imprime], [CargaPrecio], 
[IdContraTipoMovimiento], [HabilitaEmpleado], [ReservaMercaderia]) 
VALUES (N'SRV_RESERVA', N'Reserva Service', 1, NULL, 0, 0, 0, 0, 0, N'NO', NULL, 0, 1)

       END