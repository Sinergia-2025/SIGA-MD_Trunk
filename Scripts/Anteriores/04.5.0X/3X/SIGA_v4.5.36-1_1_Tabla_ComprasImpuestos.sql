
/****** Object:  Table [dbo].[ComprasImpuestos]    Script Date: 03/28/2017 15:57:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ComprasImpuestos](
	[IdSucursal] [int] NOT NULL,
	[IdTipoComprobante] [varchar](15) NOT NULL,
	[Letra] [varchar](1) NOT NULL,
	[CentroEmisor] [int] NOT NULL,
	[NumeroComprobante] [bigint] NOT NULL,
	[IdProveedor] [bigint] NOT NULL,
	[Orden] [int] NOT NULL,
	[IdTipoImpuesto] [varchar](5) NOT NULL,
	[IdProvincia] [char](2) NULL,
	[BaseImponible] [decimal](12, 2) NOT NULL,
	[Alicuota] [decimal](6, 2) NOT NULL,
	[Importe] [decimal](12, 2) NOT NULL,
 CONSTRAINT [PK_ComprasImpuestos_1] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdTipoComprobante] ASC,
	[Letra] ASC,
	[CentroEmisor] ASC,
	[NumeroComprobante] ASC,
	[IdProveedor] ASC,
	[Orden] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ComprasImpuestos]  WITH CHECK ADD  CONSTRAINT [FK_ComprasImpuestos_Compras] FOREIGN KEY([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdProveedor])
REFERENCES [dbo].[Compras] ([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdProveedor])
GO

ALTER TABLE [dbo].[ComprasImpuestos] CHECK CONSTRAINT [FK_ComprasImpuestos_Compras]
GO

ALTER TABLE [dbo].[ComprasImpuestos]  WITH CHECK ADD  CONSTRAINT [FK_ComprasImpuestos_Provincias] FOREIGN KEY([IdProvincia])
REFERENCES [dbo].[Provincias] ([IdProvincia])
GO

ALTER TABLE [dbo].[ComprasImpuestos] CHECK CONSTRAINT [FK_ComprasImpuestos_Provincias]
GO

ALTER TABLE [dbo].[ComprasImpuestos]  WITH CHECK ADD  CONSTRAINT [FK_ComprasImpuestos_TiposImpuestos] FOREIGN KEY([IdTipoImpuesto])
REFERENCES [dbo].[TiposImpuestos] ([IdTipoImpuesto])
GO

ALTER TABLE [dbo].[ComprasImpuestos] CHECK CONSTRAINT [FK_ComprasImpuestos_TiposImpuestos]
GO
