

/****** Object:  Table [dbo].[CalidadProductosModelosSubTipos]    Script Date: 5/5/2022 11:12:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CalidadProductosModelosSubTipos](
	[IdProductoModeloSubTipo] [int] NOT NULL,
	[NombreProductoModeloSubTipo] [varchar](200) NOT NULL,
	[IdProductoModeloTipo] [int] NOT NULL,
 CONSTRAINT [PK_CalidadProductosModelosSubTipos] PRIMARY KEY CLUSTERED 
(
	[IdProductoModeloSubTipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CalidadProductosModelosSubTipos]  WITH CHECK ADD  CONSTRAINT [FK_CalidadProductosModelosSubTipos_CalidadProductosModelosTipos] FOREIGN KEY([IdProductoModeloTipo])
REFERENCES [dbo].[CalidadProductosModelosTipos] ([IdProductoModeloTipo])
GO

ALTER TABLE [dbo].[CalidadProductosModelosSubTipos] CHECK CONSTRAINT [FK_CalidadProductosModelosSubTipos_CalidadProductosModelosTipos]
GO


IF dbo.BaseConCuit('33631312379') = 1 OR dbo.SoyHAR() = 1
BEGIN
	--Inserto la Pantalla Nueva
    PRINT ''
    PRINT '1.1. Insertar funcion: ABM de SubTipos de Modelos de Productos'
	INSERT INTO Funciones
	   (Id, Nombre, Descripcion
	   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica, EsMDIChild)
	 VALUES
	   ('ProductosModelosSubTiposABM', 'ABM de SubTipos de Modelos de Productos', 'ABM de SubTipos de Modelos de Productos', 
		'True', 'False', 'True', 'True', 'Calidad',127, 'Eniac.Win', 'ProductosModelosSubTiposABM', null, null,'N','S','N','N','True')

END;



ALTER TABLE CalidadProductosModelos ADD IdProductoModeloSubTipo int null
GO

/****** Object:  Table [dbo].[CalidadEnviosOCErrores]    Script Date: 13/5/2022 08:40:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CalidadEnviosOCErrores](
	[IdSucursal] [int] NOT NULL,
	[IdTipoComprobante] [varchar](15) NOT NULL,
	[Letra] [varchar](1) NOT NULL,
	[CentroEmisor] [int] NOT NULL,
	[NumeroPedido] [bigint] NOT NULL,
	[FechaEnvioError] [datetime] NOT NULL,
	[DescripcionError] [varchar](1000) NOT NULL,
	[Usuario] [varchar](10) NULL,
 CONSTRAINT [PK_CalidadEnviosOCErrores] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdTipoComprobante] ASC,
	[Letra] ASC,
	[CentroEmisor] ASC,
	[NumeroPedido] ASC,
	[FechaEnvioError] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CalidadEnviosOCErrores]  WITH CHECK ADD  CONSTRAINT [FK_CalidadEnviosOCErrores_PedidosProveedores] FOREIGN KEY([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroPedido])
REFERENCES [dbo].[PedidosProveedores] ([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroPedido])
GO

ALTER TABLE [dbo].[CalidadEnviosOCErrores] CHECK CONSTRAINT [FK_CalidadEnviosOCErrores_PedidosProveedores]
GO


