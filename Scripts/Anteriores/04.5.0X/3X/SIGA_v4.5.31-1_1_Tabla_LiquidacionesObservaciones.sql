
/****** Object:  Table [dbo].[LiquidacionesObservaciones]    Script Date: 11/30/2016 19:23:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[LiquidacionesObservaciones](
	[IdSucursal] [int] NOT NULL,
	[PeriodoLiquidacion] [int] NOT NULL,
	[IdCliente] [bigint] NOT NULL,
	[Linea] [int] NOT NULL,
	[Observacion] [varchar](100) NOT NULL,
 CONSTRAINT [PK_LiquidacionesObservaciones] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[PeriodoLiquidacion] ASC,
	[IdCliente] ASC,
	[Linea] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[LiquidacionesObservaciones]  WITH CHECK ADD  CONSTRAINT [FK_LiquidacionesObservaciones_Clientes] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO

ALTER TABLE [dbo].[LiquidacionesObservaciones] CHECK CONSTRAINT [FK_LiquidacionesObservaciones_Clientes]
GO

ALTER TABLE [dbo].[LiquidacionesObservaciones]  WITH CHECK ADD  CONSTRAINT [FK_LiquidacionesObservaciones_Liquidaciones] FOREIGN KEY([PeriodoLiquidacion], [IdSucursal])
REFERENCES [dbo].[Liquidaciones] ([PeriodoLiquidacion], [IdSucursal])
GO

ALTER TABLE [dbo].[LiquidacionesObservaciones] CHECK CONSTRAINT [FK_LiquidacionesObservaciones_Liquidaciones]
GO
