/****** Object:  Table [dbo].[Tarjetas]    Script Date: 08/06/2012 23:41:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Tarjetas](
	[IdTarjeta] [int] NOT NULL,
	[NombreTarjeta] [varchar](50) NOT NULL,
	[TipoTarjeta] [varchar](1) NOT NULL,
	[Habilitada] [bit] NOT NULL,
 CONSTRAINT [PK_Tarjetas] PRIMARY KEY CLUSTERED 
(
	[IdTarjeta] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Por ejemplo Visa, Mastercard, American Express' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Tarjetas', @level2type=N'COLUMN',@level2name=N'NombreTarjeta'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Es del Tipo Credito o Debito' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Tarjetas', @level2type=N'COLUMN',@level2name=N'TipoTarjeta'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Si esta habilitada para pagar o no' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Tarjetas', @level2type=N'COLUMN',@level2name=N'Habilitada'
GO

ALTER TABLE [dbo].[Tarjetas] ADD  CONSTRAINT [DF_Tarjetas_TipoTarjeta]  DEFAULT ('C') FOR [TipoTarjeta]
GO

ALTER TABLE [dbo].[Tarjetas] ADD  CONSTRAINT [DF_Tarjetas_Habilitada]  DEFAULT ((1)) FOR [Habilitada]
GO

----------------------------

/****** Object:  Table [dbo].[VentasTarjetas]    Script Date: 08/06/2012 23:42:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[VentasTarjetas](
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
 CONSTRAINT [PK_VentasTarjetas] PRIMARY KEY CLUSTERED 
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

ALTER TABLE [dbo].[VentasTarjetas]  WITH CHECK ADD  CONSTRAINT [FK_VentasTarjetas_Tarjetas] FOREIGN KEY([IdTarjeta])
REFERENCES [dbo].[Tarjetas] ([IdTarjeta])
GO

ALTER TABLE [dbo].[VentasTarjetas] CHECK CONSTRAINT [FK_VentasTarjetas_Tarjetas]
GO

ALTER TABLE [dbo].[VentasTarjetas]  WITH CHECK ADD  CONSTRAINT [FK_VentasTarjetas_Ventas] FOREIGN KEY([IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdSucursal])
REFERENCES [dbo].[Ventas] ([IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdSucursal])
GO

ALTER TABLE [dbo].[VentasTarjetas] CHECK CONSTRAINT [FK_VentasTarjetas_Ventas]
GO

---------------------------------------------------------------------------------------------

INSERT INTO Tarjetas (IdTarjeta, NombreTarjeta, TipoTarjeta, Habilitada)
     VALUES (1, 'VISA - CREDITO', 'C', 'True')
GO

INSERT INTO Tarjetas (IdTarjeta, NombreTarjeta, TipoTarjeta, Habilitada)
     VALUES (2, 'VISA - DEBITO', 'D', 'True')
GO
