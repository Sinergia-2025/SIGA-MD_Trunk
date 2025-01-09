
/****** Object:  Table [dbo].[Cargos]    Script Date: 22/9/2016 14:32:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Cargos](
	[IdCargo] [int] NOT NULL,
	[IdSucursal] [int] NOT NULL,
	[NombreCargo] [varchar](60) NOT NULL,
	[Monto] [decimal](12, 2) NOT NULL,
	[Activo] [bit] NOT NULL,
	[ImprimeVoucher] [bit] NOT NULL,
	[CantidadMeses] [int] NULL,
	[ModificaImporte] [bit] NOT NULL,
	[CantidadCuotas] [int] NULL,
	[CuotaActual] [int] NULL,
	[ModificaCantidad] [bit] NOT NULL,
	[IdProducto] [varchar](15) NULL,
 CONSTRAINT [PK_Cargos] PRIMARY KEY CLUSTERED 
(
	[IdCargo] ASC,
	[IdSucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Cargos] ADD  CONSTRAINT [DF_Cargos_ModificaCantidad]  DEFAULT ((0)) FOR [ModificaCantidad]
GO

ALTER TABLE [dbo].[Cargos]  WITH CHECK ADD  CONSTRAINT [FK_Cargos_Productos] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([IdProducto])
GO

ALTER TABLE [dbo].[Cargos] CHECK CONSTRAINT [FK_Cargos_Productos]
GO

ALTER TABLE [dbo].[Cargos]  WITH CHECK ADD  CONSTRAINT [FK_Cargos_Sucursales] FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[Sucursales] ([IdSucursal])
GO

ALTER TABLE [dbo].[Cargos] CHECK CONSTRAINT [FK_Cargos_Sucursales]
GO
