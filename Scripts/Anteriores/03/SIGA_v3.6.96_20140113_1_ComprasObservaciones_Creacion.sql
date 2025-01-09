
/****** Object:  Table [dbo].[ComprasObservaciones]    Script Date: 01/13/2014 16:12:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ComprasObservaciones](
	[IdSucursal] [int] NOT NULL,
	[IdTipoComprobante] [varchar](15) NOT NULL,
	[Letra] [varchar](1) NOT NULL,
	[CentroEmisor] [int] NOT NULL,
	[NumeroComprobante] [bigint] NOT NULL,
	[TipoDocProveedor] [varchar](5) NOT NULL,
	[NroDocProveedor] [bigint] NOT NULL,
	[Linea] [int] NOT NULL,
	[Observacion] [varchar](100) NOT NULL,
 CONSTRAINT [PK_ComprasObservaciones] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdTipoComprobante] ASC,
	[Letra] ASC,
	[CentroEmisor] ASC,
	[NumeroComprobante] ASC,
	[TipoDocProveedor] ASC,
	[NroDocProveedor] ASC,
	[Linea] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ComprasObservaciones]  WITH CHECK ADD  CONSTRAINT [FK_ComprasObservaciones_Compras] FOREIGN KEY([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [TipoDocProveedor], [NroDocProveedor])
REFERENCES [dbo].[Compras] ([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [TipoDocProveedor], [NroDocProveedor])
GO

ALTER TABLE [dbo].[ComprasObservaciones] CHECK CONSTRAINT [FK_ComprasObservaciones_Compras]
GO


/* Habilito los Items de Observaciones, sino, no se ve la Solapa de Detalle */

UPDATE TiposComprobantes
 SET CantidadMaximaItemsObserv = CantidadMaximaItems-1
 WHERE Tipo = 'COMPRAS'
GO
