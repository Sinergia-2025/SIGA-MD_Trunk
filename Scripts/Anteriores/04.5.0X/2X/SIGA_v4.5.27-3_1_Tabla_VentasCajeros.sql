IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VentasCajeros]') AND type in (N'U'))
DROP TABLE [dbo].[VentasCajeros]
GO

/****** Object:  Table [dbo].[VentasCajeros]    Script Date: 09/26/2016 17:39:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[VentasCajeros](
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
 CONSTRAINT [PK_VentasCajeros] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdTipoComprobante] ASC,
	[Letra] ASC,
	[CentroEmisor] ASC,
	[NumeroComprobante] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO
