
/****** Object:  Table [dbo].[ContabilidadAsientosTmp]    Script Date: 11/20/2012 12:47:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ContabilidadAsientosTmp](
	[IdPlanCuenta] [int] NOT NULL,
	[IdAsiento] [int] NOT NULL,
	[NombreAsiento] [varchar](70) NOT NULL,
	[FechaAsiento] [date] NOT NULL,
	[IdTipoDoc] [int] NOT NULL,
	[IdEjercicio] [int] NOT NULL,
	[IdSucursal] [int] NOT NULL,
	[TipoAsiento][varchar](20) NOT NULL,
 CONSTRAINT [PK_ContabilidadAsientosTmp] PRIMARY KEY CLUSTERED 
(
	[IdPlanCuenta] ASC,
	[IdAsiento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ContabilidadAsientosTmp]  WITH CHECK ADD  CONSTRAINT [FK_ContabilidadAsientosTmp_ContabilidadEjercicios] FOREIGN KEY([IdEjercicio])
REFERENCES [dbo].[ContabilidadEjercicios] ([IdEjercicio])
GO

ALTER TABLE [dbo].[ContabilidadAsientosTmp] CHECK CONSTRAINT [FK_ContabilidadAsientosTmp_ContabilidadEjercicios]
GO

ALTER TABLE [dbo].[ContabilidadAsientosTmp]  WITH CHECK ADD  CONSTRAINT [FK_ContabilidadAsientosTmp_ContabilidadPlanes] FOREIGN KEY([IdPlanCuenta])
REFERENCES [dbo].[ContabilidadPlanes] ([IdPlanCuenta])
GO

ALTER TABLE [dbo].[ContabilidadAsientosTmp] CHECK CONSTRAINT [FK_ContabilidadAsientosTmp_ContabilidadPlanes]
GO

ALTER TABLE [dbo].[ContabilidadAsientosTmp]  WITH CHECK ADD  CONSTRAINT [FK_ContabilidadAsientosTmp_Sucursales] FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[Sucursales] ([IdSucursal])
GO

ALTER TABLE [dbo].[ContabilidadAsientosTmp] CHECK CONSTRAINT [FK_ContabilidadAsientosTmp_Sucursales]
GO


