
IF dbo.BaseConCuit('33631312379') = 1 OR dbo.SoyHAR() = 1
BEGIN
	--Inserto la Pantalla Nueva
    PRINT ''
    PRINT '1.1. Insertar funcion: ABM de Tipos de Modelos de Productos'
	INSERT INTO Funciones
	   (Id, Nombre, Descripcion
	   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica, EsMDIChild)
	 VALUES
	   ('ConsultarOrdenesCompra', 'Consultar Ordenes de Compra', 'Consultar Ordenes de Compra', 
		'True', 'False', 'True', 'True', 'PedidosProv',51, 'Eniac.Win', 'ConsultarOrdenesCompra', null, null,'N','S','N','N','True')

		INSERT [dbo].[Funciones] ([Id], [Nombre], [Descripcion], [EsMenu], [EsBoton], [Enabled], [Visible], [IdPadre], [Posicion], [Archivo], [Pantalla], [Icono], [Parametros], [PermiteMultiplesInstancias], [Plus], [Express], [Basica], [PV], [IdModulo], [EsMDIChild]) VALUES (N'EstadosPedidosProvABM', N'ABM Estados de Pedidos Proveedores', N'ABM Estados de Pedidos Proveedores', 1, 0, 1, 1, N'PedidosProv', 22, N'Eniac.Win', N'EstadosPedidosProvABM', NULL, NULL, 1, N'S', N'N', N'N', N'N', NULL, 1)
END;


PRINT ''
PRINT '1.1. Tabla: CalidadOCActivaciones'

/****** Object:  Table [dbo].[CalidadOCActivaciones]    Script Date: 30/12/2021 10:04:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CalidadOCActivaciones](
	[IdSucursal] [int] NOT NULL,
	[IdTipoComprobante] [varchar](15) NOT NULL,
	[Letra] [varchar](1) NOT NULL,
	[CentroEmisor] [int] NOT NULL,
	[NumeroPedido] [bigint] NOT NULL,
	[IdProducto] [varchar](15) NOT NULL,
	[Orden] [int] NOT NULL,
	[OrdenActivacion] [int] NOT NULL,
	[IdUsuario] [varchar](10) NOT NULL,
	[FechaActivacion] [datetime] NOT NULL,
	[Observacion] [varchar](max) NULL,
	[Contacto] [varchar](150) NULL,
	[IdObservacion] [int] NULL,
 CONSTRAINT [PK_PedidosProveedoresActivaciones] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdTipoComprobante] ASC,
	[Letra] ASC,
	[CentroEmisor] ASC,
	[NumeroPedido] ASC,
	[IdProducto] ASC,
	[Orden] ASC,
	[OrdenActivacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[CalidadOCActivaciones]  WITH CHECK ADD  CONSTRAINT [FK_CalidadOCActivaciones_Observaciones] FOREIGN KEY([IdObservacion])
REFERENCES [dbo].[Observaciones] ([IdObservacion])
GO

ALTER TABLE [dbo].[CalidadOCActivaciones] CHECK CONSTRAINT [FK_CalidadOCActivaciones_Observaciones]
GO

ALTER TABLE [dbo].[CalidadOCActivaciones]  WITH CHECK ADD  CONSTRAINT [FK_CalidadOCActivaciones_PedidosProveedores] FOREIGN KEY([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroPedido])
REFERENCES [dbo].[PedidosProveedores] ([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroPedido])
GO

ALTER TABLE [dbo].[CalidadOCActivaciones] CHECK CONSTRAINT [FK_CalidadOCActivaciones_PedidosProveedores]
GO

ALTER TABLE [dbo].[CalidadOCActivaciones]  WITH CHECK ADD  CONSTRAINT [FK_CalidadOCActivaciones_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([Id])
GO

ALTER TABLE [dbo].[CalidadOCActivaciones] CHECK CONSTRAINT [FK_CalidadOCActivaciones_Usuarios]
GO


IF dbo.BaseConCuit('33631312379') = 1 OR dbo.SoyHAR() = 1
BEGIN
PRINT ''
PRINT '1.1. Función: ABM de Observaciones'

INSERT [dbo].[Funciones] ([Id], [Nombre], [Descripcion], [EsMenu], [EsBoton], [Enabled], [Visible], [IdPadre], [Posicion], [Archivo], [Pantalla], [Icono], [Parametros], [PermiteMultiplesInstancias], [Plus], [Express], [Basica], [PV], [IdModulo], [EsMDIChild]) VALUES (N'Observaciones', N'ABM de Observaciones', N'ABM de Observaciones', 1, 0, 1, 1, N'Archivos', 50, N'Eniac.Win', N'ObservacionesABM', NULL, N'', 1, N'', N'', N'', N'', NULL, 1)
END;