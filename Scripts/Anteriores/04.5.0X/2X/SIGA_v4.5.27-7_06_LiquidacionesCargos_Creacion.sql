
/****** Object:  Table [dbo].[LiquidacionesCargos]    Script Date: 28/9/2016 09:41:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[LiquidacionesCargos](
	[IdCargo] [int] NOT NULL,
	[PeriodoLiquidacion] [int] NOT NULL,
	[IdCliente] [bigint] NOT NULL,
	[ImporteAlquiler] [decimal](12, 2) NOT NULL,
	[ImporteExpensas] [decimal](12, 2) NOT NULL,
	[ImporteTotal] [decimal](12, 2) NOT NULL,
	[PrimerVto] [date] NOT NULL,
	[ImportePrimerVto] [decimal](12, 2) NOT NULL,
	[SegundoVto] [date] NOT NULL,
	[ImporteSegundoVto] [decimal](12, 2) NOT NULL,
	[SaldoAnterior] [decimal](12, 2) NOT NULL,
	[ImporteServicios] [decimal](12, 2) NOT NULL,
	[ImporteGastosAdmin] [decimal](10, 2) NOT NULL,
	[IdTipoComprobante] [varchar](15) NULL,
	[Letra] [varchar](1) NULL,
	[CentroEmisor] [int] NULL,
	[NumeroComprobante] [bigint] NULL,
	[NombreCategoria] [varchar](30) NOT NULL,
	[ImporteTotalAdicionales] [decimal](12, 2) NOT NULL,
	[IdSucursal] [int] NOT NULL,
 CONSTRAINT [PK_LiquidacionesCargos] PRIMARY KEY CLUSTERED 
(
	[IdCargo] ASC,
	[IdSucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO
