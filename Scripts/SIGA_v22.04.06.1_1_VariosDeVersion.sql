IF dbo.BaseConCuit('33631312379') = 1 OR dbo.SoyHAR() = 1
BEGIN
	--Inserto la Pantalla Nueva
    PRINT ''
    PRINT '1.1. Insertar funcion: Envio de Ordenes de Compra'
	INSERT INTO Funciones
	   (Id, Nombre, Descripcion
	   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica, EsMDIChild)
	 VALUES
	   ('EnvioDeOrdenesDeCompra', 'Envío de Ordenes de Compra', 'Envío de Ordenes de Compra', 
		'True', 'False', 'True', 'True', 'PedidosProv',52, 'Eniac.Win', 'EnvioDeOrdenesDeCompra', null, null,'N','S','N','N','True')

END;


IF dbo.BaseConCuit('33631312379') = 1 
BEGIN

UPDATE Proveedores SET CuitProveedor = NroDocProveedor

UPDATE Proveedores SET NroDocProveedor = 0 

END



/****** Object:  Table [dbo].[CalidadEnviosOC]    Script Date: 1/4/2022 11:17:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CalidadEnviosOC](
	[IdSucursal] [int] NOT NULL,
	[IdTipoComprobante] [varchar](15) NOT NULL,
	[Letra] [varchar](1) NOT NULL,
	[CentroEmisor] [int] NOT NULL,
	[NumeroPedido] [bigint] NOT NULL,
	[FechaEnvio] [datetime] NOT NULL,
	[IdUsuario] [varchar](10) NOT NULL,
	[MetodoGrabacion] [char](1) NOT NULL,
	[IdFuncion] [varchar](30) NOT NULL,
 CONSTRAINT [PK_CalidadEnviosOC] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdTipoComprobante] ASC,
	[Letra] ASC,
	[CentroEmisor] ASC,
	[NumeroPedido] ASC,
	[FechaEnvio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CalidadEnviosOC]  WITH CHECK ADD  CONSTRAINT [FK_CalidadEnviosOC_PedidosProveedores] FOREIGN KEY([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroPedido])
REFERENCES [dbo].[PedidosProveedores] ([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroPedido])
GO

ALTER TABLE [dbo].[CalidadEnviosOC] CHECK CONSTRAINT [FK_CalidadEnviosOC_PedidosProveedores]
GO

ALTER TABLE [dbo].[CalidadEnviosOC]  WITH CHECK ADD  CONSTRAINT [FK_CalidadEnviosOC_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([Id])
GO

ALTER TABLE [dbo].[CalidadEnviosOC] CHECK CONSTRAINT [FK_CalidadEnviosOC_Usuarios]
GO
