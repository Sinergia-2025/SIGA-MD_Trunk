USE [Marinzaldi]
GO
/****** Objeto:  Table [dbo].[MovimientosVentasProductos]    Fecha de la secuencia de comandos: 02/10/2008 23:24:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MovimientosVentasProductos](
	[IdSucursal] [int] NOT NULL,
	[IdTipoMovimiento] [varchar](50) NOT NULL,
	[NumeroMovimiento] [bigint] NOT NULL,
	[IdProducto] [varchar](20) NOT NULL,
	[Cantidad] [decimal](12, 2) NULL,
	[Precio] [decimal](12, 2) NULL,
 CONSTRAINT [PK_MovimientosVentasProductos] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdTipoMovimiento] ASC,
	[NumeroMovimiento] ASC,
	[IdProducto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[MovimientosVentasProductos]  WITH CHECK ADD  CONSTRAINT [FK_MovimientosVentasProductos_MovimientosVentas] FOREIGN KEY([IdSucursal], [IdTipoMovimiento], [NumeroMovimiento])
REFERENCES [dbo].[MovimientosVentas] ([IdSucursal], [IdTipoMovimiento], [NumeroMovimiento])
GO
ALTER TABLE [dbo].[MovimientosVentasProductos] CHECK CONSTRAINT [FK_MovimientosVentasProductos_MovimientosVentas]
GO
ALTER TABLE [dbo].[MovimientosVentasProductos]  WITH CHECK ADD  CONSTRAINT [FK_MovimientosVentasProductos_Productos] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([IdProducto])
GO
ALTER TABLE [dbo].[MovimientosVentasProductos] CHECK CONSTRAINT [FK_MovimientosVentasProductos_Productos]