
/****** Object:  Table [dbo].[LiquidacionesDetallesClientes]    Script Date: 28/9/2016 09:43:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[LiquidacionesDetallesClientes](
	[PeriodoLiquidacion] [int] NOT NULL,
	[IdLiquidacionDetalleCliente] [int] NOT NULL,
	[IdCliente] [bigint] NOT NULL,
	[IdCargo] [int] NULL,
	[CodigoCliente] [bigint] NOT NULL,
	[NombreCliente] [varchar](100) NOT NULL,
	[IdCategoria] [int] NOT NULL,
	[NombreCategoria] [varchar](30) NOT NULL,
	[NombreCargo] [varchar](60) NULL,
	[Importe] [decimal](12, 2) NULL,
	[ImporteAlquiler] [decimal](12, 2) NULL,
	[CantidadAdicional] [decimal](12, 2) NULL,
	[PrecioAdicional] [decimal](12, 2) NULL,
	[IdSucursal] [int] NOT NULL,
 CONSTRAINT [PK_LiquidacionDetalleCliente] PRIMARY KEY CLUSTERED 
(
	[PeriodoLiquidacion] ASC,
	[IdLiquidacionDetalleCliente] ASC,
	[IdSucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[LiquidacionesDetallesClientes]  WITH CHECK ADD  CONSTRAINT [FK_LiquidacionDetalleCliente_Categorias] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categorias] ([IdCategoria])
GO

ALTER TABLE [dbo].[LiquidacionesDetallesClientes] CHECK CONSTRAINT [FK_LiquidacionDetalleCliente_Categorias]
GO

ALTER TABLE [dbo].[LiquidacionesDetallesClientes]  WITH CHECK ADD  CONSTRAINT [FK_LiquidacionDetalleCliente_Clientes] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO

ALTER TABLE [dbo].[LiquidacionesDetallesClientes] CHECK CONSTRAINT [FK_LiquidacionDetalleCliente_Clientes]
GO
