
/****** Object:  Table [dbo].[LiquidacionesDetalle]    Script Date: 28/9/2016 09:42:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[LiquidacionesDetalle](
	[PeriodoLiquidacion] [int] NOT NULL,
	[IdRubroConcepto] [int] NOT NULL,
	[IdConcepto] [int] NOT NULL,
	[IdProveedor] [bigint] NOT NULL,
	[ImporteConcepto] [decimal](12, 2) NOT NULL,
	[NombreConcepto] [varchar](70) NOT NULL,
	[NombreRubroConcepto] [varchar](50) NOT NULL,
	[NombreProveedor] [varchar](100) NOT NULL,
	[ImprimeProveedor] [bit] NOT NULL,
	[IdSucursal] [int] NOT NULL,
 CONSTRAINT [PK_LiquidacionesDetalle] PRIMARY KEY CLUSTERED 
(
	[PeriodoLiquidacion] ASC,
	[IdRubroConcepto] ASC,
	[IdConcepto] ASC,
	[IdProveedor] ASC,
	[IdSucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[LiquidacionesDetalle]  WITH CHECK ADD  CONSTRAINT [FK_LiquidacionesDetalle_Conceptos] FOREIGN KEY([IdConcepto])
REFERENCES [dbo].[Conceptos] ([IdConcepto])
GO

ALTER TABLE [dbo].[LiquidacionesDetalle] CHECK CONSTRAINT [FK_LiquidacionesDetalle_Conceptos]
GO

ALTER TABLE [dbo].[LiquidacionesDetalle]  WITH CHECK ADD  CONSTRAINT [FK_LiquidacionesDetalle_Proveedores] FOREIGN KEY([IdProveedor])
REFERENCES [dbo].[Proveedores] ([IdProveedor])
GO

ALTER TABLE [dbo].[LiquidacionesDetalle] CHECK CONSTRAINT [FK_LiquidacionesDetalle_Proveedores]
GO

ALTER TABLE [dbo].[LiquidacionesDetalle]  WITH CHECK ADD  CONSTRAINT [FK_LiquidacionesDetalle_RubrosConceptos] FOREIGN KEY([IdRubroConcepto])
REFERENCES [dbo].[RubrosConceptos] ([IdRubroConcepto])
GO

ALTER TABLE [dbo].[LiquidacionesDetalle] CHECK CONSTRAINT [FK_LiquidacionesDetalle_RubrosConceptos]
GO
