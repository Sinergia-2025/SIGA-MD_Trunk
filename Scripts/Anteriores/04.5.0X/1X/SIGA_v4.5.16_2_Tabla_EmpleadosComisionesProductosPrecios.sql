
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[EmpleadosComisionesProductosPrecios](
	[TipoDocEmpleado] [varchar](5) NOT NULL,
	[NroDocEmpleado] [varchar](12) NOT NULL,
	[IdProducto] [varchar](15) NOT NULL,
	[IdListaPrecios] [int] NOT NULL,
	[Comision] [decimal](5, 2) NULL,
 CONSTRAINT [PK_EmpleadosComisionesProductosPrecios] PRIMARY KEY CLUSTERED 
(
	[TipoDocEmpleado] ASC,
	[NroDocEmpleado] ASC,
	[IdProducto] ASC,
	[IdListaPrecios] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[EmpleadosComisionesProductosPrecios]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadosComisionesProductosPrecios_Empleados] FOREIGN KEY([TipoDocEmpleado], [NroDocEmpleado])
REFERENCES [dbo].[Empleados] ([TipoDocEmpleado], [NroDocEmpleado])
GO

ALTER TABLE [dbo].[EmpleadosComisionesProductosPrecios] CHECK CONSTRAINT [FK_EmpleadosComisionesProductosPrecios_Empleados]
GO

ALTER TABLE [dbo].[EmpleadosComisionesProductosPrecios]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadosComisionesProductosPrecios_Productos] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([IdProducto])
GO

ALTER TABLE [dbo].[EmpleadosComisionesProductosPrecios] CHECK CONSTRAINT [FK_EmpleadosComisionesProductosPrecios_Productos]
GO

ALTER TABLE [dbo].[EmpleadosComisionesProductosPrecios]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadosComisionesProductosPrecios_ListasDePrecios] FOREIGN KEY([IdListaPrecios])
REFERENCES [dbo].[ListasDePrecios] ([IdListaPrecios])
GO

ALTER TABLE [dbo].[EmpleadosComisionesProductosPrecios] CHECK CONSTRAINT [FK_EmpleadosComisionesProductosPrecios_ListasDePrecios]
GO
