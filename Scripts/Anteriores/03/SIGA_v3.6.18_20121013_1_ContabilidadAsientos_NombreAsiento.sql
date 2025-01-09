
ALTER TABLE [dbo].[ContabilidadAsientos] ALTER COLUMN [NombreAsiento] [varchar](100) NOT NULL
GO

/*

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ContabilidadAsientos](
	[IdPlanCuenta] [int] NOT NULL,
	[IdAsiento] [int] NOT NULL,
	[NombreAsiento] [varchar](70) NOT NULL,
	[FechaAsiento] [date] NOT NULL,
	[IdTipoDoc] [int] NOT NULL,
	[IdEjercicio] [int] NOT NULL,
	[IdSucursal] [int] NOT NULL,
 CONSTRAINT [PK_ContabilidadAsientos] PRIMARY KEY CLUSTERED 
(
	[IdPlanCuenta] ASC,
	[IdAsiento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ContabilidadAsientos]  WITH CHECK ADD  CONSTRAINT [FK_ContabilidadAsientos_ContabilidadEjercicios] FOREIGN KEY([IdEjercicio])
REFERENCES [dbo].[ContabilidadEjercicios] ([IdEjercicio])
GO

ALTER TABLE [dbo].[ContabilidadAsientos] CHECK CONSTRAINT [FK_ContabilidadAsientos_ContabilidadEjercicios]
GO

ALTER TABLE [dbo].[ContabilidadAsientos]  WITH CHECK ADD  CONSTRAINT [FK_ContabilidadAsientos_ContabilidadPlanes] FOREIGN KEY([IdPlanCuenta])
REFERENCES [dbo].[ContabilidadPlanes] ([IdPlanCuenta])
GO

ALTER TABLE [dbo].[ContabilidadAsientos] CHECK CONSTRAINT [FK_ContabilidadAsientos_ContabilidadPlanes]
GO

ALTER TABLE [dbo].[ContabilidadAsientos]  WITH CHECK ADD  CONSTRAINT [FK_ContabilidadAsientos_Sucursales] FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[Sucursales] ([IdSucursal])
GO

ALTER TABLE [dbo].[ContabilidadAsientos] CHECK CONSTRAINT [FK_ContabilidadAsientos_Sucursales]
GO


*/
