PRINT ''
PRINT '1. Nueva Tabla: TarjetasCupones'
CREATE TABLE [dbo].[TarjetasCupones](
	[IdTarjetaCupon] [int] NOT NULL,
	[IdSucursal] [int] NOT NULL,
	[IdTarjeta] [int] NOT NULL,
	[IdBanco] [int] NOT NULL,
	[Monto] [decimal](14, 4) NOT NULL,
	[Cuotas] [int] NOT NULL,
	[NumeroLote] [int] NOT NULL,
	[NumeroCupon] [int] NOT NULL,
	[FechaEmision] [datetime] NOT NULL,
	[IdEstadoTarjeta] [varchar](10) NOT NULL,
	[IdEstadoTarjetaAnt] [varchar](10) NULL,
	[IdCajaIngreso] [int] NULL,
	[NroPlanillaIngreso] [int] NULL,
	[NroMovimientoIngreso] [int] NULL,
	[IdCajaEgreso] [int] NULL,
	[NroPlanillaEgreso] [int] NULL,
	[NroMovimientoEgreso] [int] NULL,
	[IdUsuarioActualizacion] [varchar](10) NULL,
	[FechaActualizacion] [datetime] NOT NULL,
	[IdCliente] [bigint] NULL,
	[IdProveedor] [bigint] NULL,
 CONSTRAINT [PK_TarjetasCupones] PRIMARY KEY CLUSTERED 
([IdTarjetaCupon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TarjetasCupones]  WITH CHECK ADD  CONSTRAINT [FK_TarjetasCupones_Bancos] FOREIGN KEY([IdBanco]) REFERENCES [dbo].[Bancos] ([IdBanco])
GO
ALTER TABLE [dbo].[TarjetasCupones] CHECK CONSTRAINT [FK_TarjetasCupones_Bancos]
GO
ALTER TABLE [dbo].[TarjetasCupones]  WITH CHECK ADD  CONSTRAINT [FK_TarjetasCupones_Clientes] FOREIGN KEY([IdCliente]) REFERENCES [dbo].[Clientes] ([IdCliente])
GO
ALTER TABLE [dbo].[TarjetasCupones] CHECK CONSTRAINT [FK_TarjetasCupones_Clientes]
GO
ALTER TABLE [dbo].[TarjetasCupones]  WITH CHECK ADD  CONSTRAINT [FK_TarjetasCupones_Proveedores] FOREIGN KEY([IdProveedor]) REFERENCES [dbo].[Proveedores] ([IdProveedor])
GO
ALTER TABLE [dbo].[TarjetasCupones] CHECK CONSTRAINT [FK_TarjetasCupones_Proveedores]
GO
ALTER TABLE [dbo].[TarjetasCupones]  WITH CHECK ADD  CONSTRAINT [FK_TarjetasCupones_Tarjetas] FOREIGN KEY([IdTarjeta]) REFERENCES [dbo].[Tarjetas] ([IdTarjeta])
GO
ALTER TABLE [dbo].[TarjetasCupones] CHECK CONSTRAINT [FK_TarjetasCupones_Tarjetas]
GO
ALTER TABLE [dbo].[TarjetasCupones]  WITH CHECK ADD  CONSTRAINT [FK_TarjetasCupones_TarjetasCupones] FOREIGN KEY([IdTarjetaCupon]) REFERENCES [dbo].[TarjetasCupones] ([IdTarjetaCupon])
GO
ALTER TABLE [dbo].[TarjetasCupones] CHECK CONSTRAINT [FK_TarjetasCupones_TarjetasCupones]
GO
ALTER TABLE [dbo].[TarjetasCupones]  WITH CHECK ADD  CONSTRAINT [FK_TarjetasCupones_Usuarios] FOREIGN KEY([IdUsuarioActualizacion]) REFERENCES [dbo].[Usuarios] ([Id])
GO
ALTER TABLE [dbo].[TarjetasCupones] CHECK CONSTRAINT [FK_TarjetasCupones_Usuarios]
GO
CREATE INDEX TarjetasCupones
ON TarjetasCupones (IdTarjetaCupon,IdSucursal, IdTarjeta,IdBanco,NumeroLote,NumeroCupon)


PRINT ''
PRINT '2. Nueva Tabla: TarjetasCuponesHistorial'
CREATE TABLE [dbo].[TarjetasCuponesHistorial](
	[IdTarjetaCupon] [int] NOT NULL,
	[IdSucursal] [int] NOT NULL,
	[IdTarjeta] [int] NOT NULL,
	[IdBanco] [int] NOT NULL,
	[Monto] [decimal](14, 4) NOT NULL,
	[Cuotas] [int] NOT NULL,
	[NumeroLote] [int] NOT NULL,
	[NumeroCupon] [int] NOT NULL,
	[FechaEmision] [datetime] NOT NULL,
	[IdEstadoTarjeta] [varchar](10) NOT NULL,
	[IdEstadoTarjetaAnt] [varchar](10) NULL,
	[IdCajaIngreso] [int] NULL,
	[NroPlanillaIngreso] [int] NULL,
	[NroMovimientoIngreso] [int] NULL,
	[IdCajaEgreso] [int] NULL,
	[NroPlanillaEgreso] [int] NULL,
	[NroMovimientoEgreso] [int] NULL,
	[IdUsuarioActualizacion] [varchar](10) NULL,
	[FechaActualizacion] [datetime] NOT NULL CONSTRAINT [DF_TarjetasCuponesHistorial_FechaActualizacion]  DEFAULT (getdate()),
	[IdCliente] [bigint] NULL,
	[IdProveedor] [bigint] NULL,
	[Orden] [int] IDENTITY(1,1) NOT NULL,
  CONSTRAINT [PK_TarjetasCuponesHistorial] PRIMARY KEY CLUSTERED 
(	[IdTarjetaCupon] ASC,	[Orden] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
GO
CREATE INDEX TarjetasCuponesHistorial
ON TarjetasCuponesHistorial (IdTarjetaCupon,IdSucursal, IdTarjeta,IdBanco,NumeroLote,NumeroCupon,Orden)
GO


PRINT ''
PRINT '3. Tabla VentasTarjetas: Agrego Campo IdTarjetasCupones y Lote'
ALTER TABLE dbo.CuentasCorrientesTarjetas ADD NumeroLote int null;
ALTER TABLE dbo.CuentasCorrientesTarjetas ADD IdTarjetaCupon int null;


PRINT ''
PRINT '4. Tabla VentasTarjetas: Agrego Campo IdTarjetasCupones y Lote'
ALTER TABLE dbo.VentasTarjetas ADD NumeroLote int null;
ALTER TABLE dbo.VentasTarjetas ADD IdTarjetaCupon int null;
GO

PRINT ''
PRINT '5. Tabla CuentasCorrientesTarjetas: FK a TarjetasCupones'
ALTER TABLE [dbo].[CuentasCorrientesTarjetas]  WITH CHECK ADD  CONSTRAINT [FK_CuentasCorrientesTarjetas_TarjetasCupones] FOREIGN KEY([IdTarjetaCupon])
REFERENCES [dbo].[TarjetasCupones] ([IdTarjetaCupon])
GO

PRINT ''
PRINT '6. Tabla VentasTarjetas: FK a TarjetasCupones'
ALTER TABLE [dbo].[VentasTarjetas]  WITH CHECK ADD  CONSTRAINT [FK_VentasTarjetas_TarjetasCupones] FOREIGN KEY([IdTarjetaCupon])
REFERENCES [dbo].[TarjetasCupones] ([IdTarjetaCupon])
GO


PRINT ''
PRINT '7. Menu: Nueva función Informe de Cupones de Tarjetas'
IF dbo.ExisteFuncion('Caja') = 'True'
BEGIN
    PRINT ''
    PRINT '7.1. Menu: Agregar nueva función Informe de Cupones de Tarjetas'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('InfTarjetasCupones', 'Informe de Cupones de Tarjetas', 'Informe de Cupones de Tarjetas', 'True', 'False', 'True', 'True'
        ,'Caja', 105, 'Eniac.Win', 'InfTarjetasCupones', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')

    PRINT ''
    PRINT '7.2. Menu: Asignar roles a nueva función Informe de Cupones de Tarjetas'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'InfTarjetasCupones' FROM RolesFunciones WHERE IdFuncion = 'PlanillaDeCaja'
END

PRINT ''
PRINT '8. Menu: Nueva función Informe Historico de Cupones de Tarjetas'
IF dbo.ExisteFuncion('Caja') = 'True'
BEGIN
    PRINT ''
    PRINT '8.1. Menu: Agregar nueva función Informe Historico de Cupones de Tarjetas'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('InfHistoricoTarjetasCupones', 'Informe Historico de Cupones de Tarjetas', 'Informe Historico de Cupones de Tarjetas', 'True', 'False', 'True', 'True'
        ,'Caja', 106, 'Eniac.Win', 'InfHistoricoTarjetasCupones', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')

    PRINT ''
    PRINT '8.2. Menu: Asignar roles a nueva función Informe Historico de Cupones de Tarjetas'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'InfHistoricoTarjetasCupones' FROM RolesFunciones WHERE IdFuncion = 'PlanillaDeCaja'
END
