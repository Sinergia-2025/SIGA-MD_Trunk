ALTER TABLE Ventas ADD ImportePesos decimal(12, 2) NULL
ALTER TABLE Ventas ADD ImporteTickets decimal(12, 2) NULL
ALTER TABLE Ventas ADD ImporteTarjetas decimal(12, 2) NULL
ALTER TABLE Ventas ADD ImporteCheques decimal(12, 2) NULL

CREATE TABLE [dbo].[VentasCheques](
	[IdSucursal] [int] NOT NULL,
	[IdTipoComprobante] [varchar](15) NOT NULL,
	[Letra] [varchar](1) NOT NULL,
	[CentroEmisor] [int] NOT NULL,
	[NumeroComprobante] [bigint] NOT NULL,
	[NumeroCheque] [int] NOT NULL,
	[IdBanco] [int] NOT NULL,
	[IdBancoSucursal] [int] NOT NULL,
	[IdLocalidad] [int] NOT NULL,
 CONSTRAINT [PK_VentasCheques] PRIMARY KEY CLUSTERED 
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
ALTER TABLE [dbo].[VentasCheques]  WITH CHECK ADD  CONSTRAINT [FK_VentasCheques_Cheques] FOREIGN KEY([NumeroCheque], [IdBanco], [IdBancoSucursal], [IdLocalidad])
REFERENCES [dbo].[Cheques] ([NumeroCheque], [IdBanco], [IdBancoSucursal], [IdLocalidad])
GO
ALTER TABLE [dbo].[VentasCheques] CHECK CONSTRAINT [FK_VentasCheques_Cheques]
GO
ALTER TABLE [dbo].[VentasCheques]  WITH CHECK ADD  CONSTRAINT [FK_VentasCheques_TiposComprobantes] FOREIGN KEY([IdTipoComprobante])
REFERENCES [dbo].[TiposComprobantes] ([IdTipoComprobante])
GO
ALTER TABLE [dbo].[VentasCheques] CHECK CONSTRAINT [FK_VentasCheques_TiposComprobantes]
GO
ALTER TABLE [dbo].[VentasCheques]  WITH CHECK ADD  CONSTRAINT [FK_VentasCheques_Ventas] FOREIGN KEY([IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdSucursal])
REFERENCES [dbo].[Ventas] ([IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdSucursal])
GO
ALTER TABLE [dbo].[VentasCheques] CHECK CONSTRAINT [FK_VentasCheques_Ventas]
GO









