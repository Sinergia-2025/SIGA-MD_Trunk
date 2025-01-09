
/****** Object:  Table [dbo].[Liquidaciones]    Script Date: 28/9/2016 09:41:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Liquidaciones](
	[PeriodoLiquidacion] [int] NOT NULL,
	[FechaLiquidacion] [datetime] NOT NULL,
	[TotalAlquiler] [decimal](12, 2) NOT NULL,
	[TotalExpensas] [decimal](12, 2) NOT NULL,
	[TotalLiquidacion] [decimal](12, 2) NOT NULL,
	[TotalServicios] [decimal](12, 2) NOT NULL,
	[TotalGastosAdmin] [decimal](10, 2) NOT NULL,
	[FechaFacturado] [datetime] NULL,
	[TotalAlquilerAnterior] [decimal](12, 2) NOT NULL,
	[TotalGastosOperativos] [decimal](12, 2) NOT NULL,
	[TotalGastosNoGravado] [decimal](12, 2) NULL,
	[TotalGastosIVA105] [decimal](12, 2) NULL,
	[TotalGastosIVA210] [decimal](12, 2) NULL,
	[TotalGastosIVA270] [decimal](12, 2) NULL,
	[TotalAlquilerAnteriorCalculos] [decimal](12, 2) NOT NULL,
	[TotalGastosNeto105] [decimal](12, 2) NULL,
	[TotalGastosNeto210] [decimal](12, 2) NULL,
	[TotalGastosNeto270] [decimal](12, 2) NULL,
	[IdSucursal] [int] NOT NULL,
 CONSTRAINT [PK_Liquidaciones] PRIMARY KEY CLUSTERED 
(
	[PeriodoLiquidacion] ASC,
	[IdSucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
