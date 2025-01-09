
CREATE TABLE [CuentasCorrientesTarjetas](
	[IdSucursal] [int] NOT NULL,
	[IdTipoComprobante] [varchar](15) NOT NULL,
	[Letra] [varchar](1) NOT NULL,
	[CentroEmisor] [int] NOT NULL,
	[NumeroComprobante] [bigint] NOT NULL,
	[IdTarjeta] [int] NOT NULL,
	[IdBanco] [int] NOT NULL,
	[Monto] [decimal](14, 4) NOT NULL,
	[Cuotas] [int] NULL,
	[NumeroCupon] [int] NULL,
 CONSTRAINT [PK_CuentasCorrientesTarjetas] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdTipoComprobante] ASC,
	[Letra] ASC,
	[CentroEmisor] ASC,
	[NumeroComprobante] ASC,
	[IdTarjeta] ASC,
	[IdBanco] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[CuentasCorrientesTarjetas]  WITH CHECK ADD  CONSTRAINT [FK_CuentasCorrientesTarjetas_Tarjetas] FOREIGN KEY([IdTarjeta])
REFERENCES [dbo].[Tarjetas] ([IdTarjeta])
GO

ALTER TABLE [dbo].[CuentasCorrientesTarjetas] CHECK CONSTRAINT [FK_CuentasCorrientesTarjetas_Tarjetas]
GO

ALTER TABLE [dbo].[CuentasCorrientesTarjetas]  WITH CHECK ADD  CONSTRAINT [FK_CuentasCorrientesTarjetas_CuentasCorrientes] FOREIGN KEY([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante])
REFERENCES [dbo].[CuentasCorrientes] ([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante])
GO

ALTER TABLE [dbo].[CuentasCorrientesTarjetas] CHECK CONSTRAINT [FK_CuentasCorrientesTarjetas_CuentasCorrientes]
GO


