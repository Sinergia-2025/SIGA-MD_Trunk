
/****** Object:  Table [dbo].[VentasChequesRechazados]    Script Date: 04/02/2010 21:14:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[VentasChequesRechazados](
	[IdSucursal] [int] NOT NULL,
	[IdTipoComprobante] [varchar](15) NOT NULL,
	[Letra] [varchar](1) NOT NULL,
	[CentroEmisor] [int] NOT NULL,
	[NumeroComprobante] [bigint] NOT NULL,
	[NumeroCheque] [int] NOT NULL,
	[IdBanco] [int] NOT NULL,
	[IdBancoSucursal] [int] NOT NULL,
	[IdLocalidad] [int] NOT NULL,
 CONSTRAINT [PK_VentasChequesRechazados] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdTipoComprobante] ASC,
	[Letra] ASC,
	[CentroEmisor] ASC,
	[NumeroComprobante] ASC,
	[NumeroCheque] ASC,
	[IdBanco] ASC,
	[IdBancoSucursal] ASC,
	[IdLocalidad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[VentasChequesRechazados]  WITH CHECK ADD  CONSTRAINT [FK_VentasChequesRechazados_Cheques] FOREIGN KEY([NumeroCheque], [IdBanco], [IdBancoSucursal], [IdLocalidad])
REFERENCES [dbo].[Cheques] ([NumeroCheque], [IdBanco], [IdBancoSucursal], [IdLocalidad])
GO

ALTER TABLE [dbo].[VentasChequesRechazados] CHECK CONSTRAINT [FK_VentasChequesRechazados_Cheques]
GO

ALTER TABLE [dbo].[VentasChequesRechazados]  WITH CHECK ADD  CONSTRAINT [FK_VentasChequesRechazados_TiposComprobantes] FOREIGN KEY([IdTipoComprobante])
REFERENCES [dbo].[TiposComprobantes] ([IdTipoComprobante])
GO

ALTER TABLE [dbo].[VentasChequesRechazados] CHECK CONSTRAINT [FK_VentasChequesRechazados_TiposComprobantes]
GO

ALTER TABLE [dbo].[VentasChequesRechazados]  WITH CHECK ADD  CONSTRAINT [FK_VentasChequesRechazados_Ventas] FOREIGN KEY([IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdSucursal])
REFERENCES [dbo].[Ventas] ([IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdSucursal])
GO

ALTER TABLE [dbo].[VentasChequesRechazados] CHECK CONSTRAINT [FK_VentasChequesRechazados_Ventas]
GO


