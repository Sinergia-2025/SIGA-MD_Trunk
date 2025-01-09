PRINT ''
PRINT '1. Nueva tabla ProductosOfertas'
CREATE TABLE [dbo].[ProductosOfertas](
	[IdProducto] [varchar](15) NOT NULL,
	[IdOferta] [int] NOT NULL,
	[FechaDesde] [datetime] NOT NULL,
	[FechaHasta] [datetime] NOT NULL,
	[LimiteStock] [decimal](14, 4) NOT NULL,
	[CantidadConsumida] [decimal](14, 4) NOT NULL,
	[PrecioOferta] [decimal](14, 4) NOT NULL,
	[Activa] [bit] NOT NULL,
 CONSTRAINT [PK_ProductosOfertas] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC,
	[IdOferta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ProductosOfertas]  WITH CHECK ADD  CONSTRAINT [FK_ProductosOfertas_Productos] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([IdProducto])
GO

ALTER TABLE [dbo].[ProductosOfertas] CHECK CONSTRAINT [FK_ProductosOfertas_Productos]
GO

PRINT ''
PRINT '2. Agregar campo IdEstadoVenta en VentasProductos'
ALTER TABLE dbo.VentasProductos ADD IdEstadoVenta int NULL
GO
ALTER TABLE dbo.VentasProductos SET (LOCK_ESCALATION = TABLE)
GO
