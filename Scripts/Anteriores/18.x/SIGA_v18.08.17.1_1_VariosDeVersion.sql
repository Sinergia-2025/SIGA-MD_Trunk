
PRINT ''
PRINT '1. Nueva Tabla: PedidosProductosFormulas.'
GO

/****** Object:  Table [dbo].[PedidosProductosFormulas]    Script Date: 17/08/2018 13:09:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PedidosProductosFormulas](
	[IdSucursal] [int] NOT NULL,
	[IdTipoComprobante] [varchar](15) NOT NULL,
	[Letra] [varchar](1) NOT NULL,
	[CentroEmisor] [int] NOT NULL,
	[NumeroPedido] [int] NOT NULL,
	[IdProducto] [varchar](15) NOT NULL,
	[Orden] [int] NOT NULL,
	[IdProductoComponente] [varchar](15) NOT NULL,
	[IdFormula] [int] NOT NULL,
	[NombreProductoComponente] [varchar](60) NOT NULL,
	[NombreFormula] [varchar](100) NOT NULL,
	[PrecioCosto] [decimal](14, 4) NOT NULL,
	[PrecioVenta] [decimal](14, 4) NOT NULL,
	[Cantidad] [decimal](14, 4) NOT NULL,
	[SegunCalculoForma] [bit] NOT NULL,
 CONSTRAINT [PK_PedidosProductosFormula] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdTipoComprobante] ASC,
	[Letra] ASC,
	[CentroEmisor] ASC,
	[NumeroPedido] ASC,
	[IdProducto] ASC,
	[Orden] ASC,
	[IdProductoComponente] ASC,
	[IdFormula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[PedidosProductosFormulas]  WITH CHECK ADD  CONSTRAINT [FK_PedidosProductosFormula_PedidosProductos] FOREIGN KEY([IdSucursal], [NumeroPedido], [IdProducto], [Orden], [IdTipoComprobante], [Letra], [CentroEmisor])
REFERENCES [dbo].[PedidosProductos] ([IdSucursal], [NumeroPedido], [IdProducto], [Orden], [IdTipoComprobante], [Letra], [CentroEmisor])
GO

ALTER TABLE [dbo].[PedidosProductosFormulas] CHECK CONSTRAINT [FK_PedidosProductosFormula_PedidosProductos]
GO

ALTER TABLE [dbo].[PedidosProductosFormulas]  WITH CHECK ADD  CONSTRAINT [FK_PedidosProductosFormula_ProductosFormulas] FOREIGN KEY([IdProducto], [IdFormula])
REFERENCES [dbo].[ProductosFormulas] ([IdProducto], [IdFormula])
GO

ALTER TABLE [dbo].[PedidosProductosFormulas] CHECK CONSTRAINT [FK_PedidosProductosFormula_ProductosFormulas]
GO

PRINT ''
PRINT '2. Menu Nuevo: Pedidos\Anular Pedidos.'
GO

INSERT INTO Funciones
	(Id, Nombre, Descripcion
	,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
	VALUES
	('EliminarPedidos', 'Eliminar Pedidos', 'Eliminar Pedidos', 
	'True', 'False', 'True', 'True', 'Pedidos', 18, 'Eniac.Win', 'AnularPedidos', NULL, '|ELIMINAR')
;

INSERT INTO RolesFunciones 
	            (IdRol,IdFuncion)
SELECT IdRol,'EliminarPedidos'
    FROM RolesFunciones WHERE IdFuncion = 'AnularPedidos'
;


PRINT ''
PRINT '3. Menu Nuevo: Pedidos\Renumerar Pedidos.'
GO

INSERT INTO Funciones
	(Id, Nombre, Descripcion
	,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
	VALUES
	('RenumerarPedidos', 'Renumerar Pedidos', 'Renumerar Pedidos', 
	'True', 'False', 'True', 'True', 'Pedidos', 19, 'Eniac.Win', 'AnularPedidos', NULL, '|RENUMERAR')
;

INSERT INTO RolesFunciones 
	            (IdRol,IdFuncion)
SELECT IdRol,'RenumerarPedidos'
    FROM RolesFunciones WHERE IdFuncion = 'AnularPedidos'
;
