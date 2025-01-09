USE [Marinzaldi]
GO
/****** Objeto:  Table [dbo].[MovimientosVentas]    Fecha de la secuencia de comandos: 02/10/2008 23:24:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MovimientosVentas](
	[IdSucursal] [int] NOT NULL,
	[IdTipoMovimiento] [varchar](50) NOT NULL,
	[NumeroMovimiento] [bigint] NOT NULL,
	[FechaMovimiento] [datetime] NULL,
	[Neto] [decimal](12, 2) NULL,
	[IvaInscripto] [decimal](12, 2) NULL,
	[IvaNoInscripto] [decimal](12, 2) NULL,
	[Total] [decimal](12, 2) NULL,
	[PorcentajeIVA] [decimal](12, 2) NULL,
	[TipoDocCliente] [varchar](5) NULL,
	[NroDocCliente] [varchar](12) NULL,
	[IdCategoriaFiscal] [smallint] NULL,
	[IdTipoComprobante] [varchar](10) NULL,
	[Letra] [varchar](1) NULL,
	[CentroEmisor] [int] NULL,
	[NumeroComprobante] [bigint] NULL,
 CONSTRAINT [PK_MovimientosVentas] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdTipoMovimiento] ASC,
	[NumeroMovimiento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[MovimientosVentas]  WITH CHECK ADD  CONSTRAINT [FK_MovimientosVentas_Clientes] FOREIGN KEY([TipoDocCliente], [NroDocCliente])
REFERENCES [dbo].[Clientes] ([TipoDocumento], [NroDocumento])
GO
ALTER TABLE [dbo].[MovimientosVentas] CHECK CONSTRAINT [FK_MovimientosVentas_Clientes]
GO
ALTER TABLE [dbo].[MovimientosVentas]  WITH CHECK ADD  CONSTRAINT [FK_MovimientosVentas_Sucursales] FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[Sucursales] ([IdSucursal])
GO
ALTER TABLE [dbo].[MovimientosVentas] CHECK CONSTRAINT [FK_MovimientosVentas_Sucursales]