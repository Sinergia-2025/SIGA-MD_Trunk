
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CuentasCorrientesRetenciones](
	[IdSucursal] [int] NOT NULL,
	[IdTipoComprobante] [varchar](15) NOT NULL,
	[Letra] [varchar](1) NOT NULL,
	[CentroEmisor] [int] NOT NULL,
	[NumeroComprobante] [bigint] NOT NULL,
	[IdTipoImpuesto] [varchar](5) NOT NULL,
	[EmisorRetencion] [int] NOT NULL,
	[NumeroRetencion] [bigint] NOT NULL,
 CONSTRAINT [PK_CuentasCorrientesRetenciones] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdTipoComprobante] ASC,
	[Letra] ASC,
	[CentroEmisor] ASC,
	[NumeroComprobante] ASC,
	[IdTipoImpuesto] ASC,
	[EmisorRetencion] ASC,
	[NumeroRetencion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[CuentasCorrientesRetenciones]  WITH CHECK ADD  CONSTRAINT [FK_CuentasCorrientesRetenciones_CuentasCorrientes] FOREIGN KEY([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante])
REFERENCES [dbo].[CuentasCorrientes] ([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante])
GO

ALTER TABLE [dbo].[CuentasCorrientesRetenciones] CHECK CONSTRAINT [FK_CuentasCorrientesRetenciones_CuentasCorrientes]
GO
