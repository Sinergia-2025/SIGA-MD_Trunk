
/****** Object:  Table [dbo].[VentasColasImpresion]    Script Date: 01/20/2017 13:04:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VentasColasImpresion](
    [IdVentaColaImpresion] [int] NOT NULL,
    [NombreColaImpresion] [varchar](30) NOT NULL,
    [Estado] [varchar] (15) NOT NULL,
 CONSTRAINT [PK_VentasColasImpresion] PRIMARY KEY CLUSTERED 
([IdVentaColaImpresion] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY]
GO

INSERT INTO [dbo].[VentasColasImpresion]
           ([IdVentaColaImpresion],[NombreColaImpresion],[Estado])
     VALUES(1, 'Cola Principal', 'ACTIVA');

/****** Object:  Table [dbo].[VentasColasImpresionComprobantes]    Script Date: 01/24/2017 11:36:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VentasColasImpresionComprobantes](
	[IdVentaColaImpresion] [int] NOT NULL,
	[IdSucursal] [int] NOT NULL,
	[IdTipoComprobante] [varchar](15) NOT NULL,
	[Letra] [varchar](1) NOT NULL,
	[CentroEmisor] [int] NOT NULL,
	[NumeroComprobante] [bigint] NOT NULL,
	[IdCliente] [bigint] NOT NULL,
	[CodigoCliente] [bigint] NOT NULL,
	[NombreCliente] [nchar](100) NOT NULL,
	[TipoDocVendedor] [varchar](5) NOT NULL,
	[NroDocVendedor] [varchar](12) NOT NULL,
	[NombreVendedor] [varchar](100) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[IdFormasPago] [int] NOT NULL,
	[DescripcionFormasPago] [varchar](50) NOT NULL,
	[ImporteTotal] [decimal](12, 2) NOT NULL,
	[DescuentoRecargoPorc] [decimal](12, 2) NOT NULL,
	[IdCategoria] [int] NOT NULL,
	[IdCategoriaFiscal] [smallint] NOT NULL,
	[NombreCategoriaFiscal] [varchar](40) NOT NULL,
 CONSTRAINT [PK_VentasColasImpresionComprobantes] PRIMARY KEY CLUSTERED 
(	[IdVentaColaImpresion] ASC,
	[IdSucursal] ASC,
	[IdTipoComprobante] ASC,
	[Letra] ASC,
	[CentroEmisor] ASC,
	[NumeroComprobante] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[VentasColasImpresionComprobantes]  WITH CHECK ADD  CONSTRAINT [FK_VentasColasImpresionComprobantes_Categorias] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categorias] ([IdCategoria])
GO
ALTER TABLE [dbo].[VentasColasImpresionComprobantes] CHECK CONSTRAINT [FK_VentasColasImpresionComprobantes_Categorias]
GO
ALTER TABLE [dbo].[VentasColasImpresionComprobantes]  WITH CHECK ADD  CONSTRAINT [FK_VentasColasImpresionComprobantes_CategoriasFiscales] FOREIGN KEY([IdCategoriaFiscal])
REFERENCES [dbo].[CategoriasFiscales] ([IdCategoriaFiscal])
GO
ALTER TABLE [dbo].[VentasColasImpresionComprobantes] CHECK CONSTRAINT [FK_VentasColasImpresionComprobantes_CategoriasFiscales]
GO
ALTER TABLE [dbo].[VentasColasImpresionComprobantes]  WITH CHECK ADD  CONSTRAINT [FK_VentasColasImpresionComprobantes_Ventas] FOREIGN KEY([IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdSucursal])
REFERENCES [dbo].[Ventas] ([IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdSucursal])
GO
ALTER TABLE [dbo].[VentasColasImpresionComprobantes] CHECK CONSTRAINT [FK_VentasColasImpresionComprobantes_Ventas]
GO
ALTER TABLE [dbo].[VentasColasImpresionComprobantes]  WITH CHECK ADD  CONSTRAINT [FK_VentasColasImpresionComprobantes_VentasColasImpresion] FOREIGN KEY([IdVentaColaImpresion])
REFERENCES [dbo].[VentasColasImpresion] ([IdVentaColaImpresion])
GO
ALTER TABLE [dbo].[VentasColasImpresionComprobantes] CHECK CONSTRAINT [FK_VentasColasImpresionComprobantes_VentasColasImpresion]
GO
