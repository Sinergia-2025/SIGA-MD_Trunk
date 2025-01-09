
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[EmpleadosComisionesMarcasPrecios](
	[TipoDocEmpleado] [varchar](5) NOT NULL,
	[NroDocEmpleado] [varchar](12) NOT NULL,
	[IdMarca] [int] NOT NULL,
	[IdListaPrecios] [int] NOT NULL,
	[Comision] [decimal](5, 2) NULL,
 CONSTRAINT [PK_EmpleadosComisionesMarcasPrecios] PRIMARY KEY CLUSTERED 
(
	[TipoDocEmpleado] ASC,
	[NroDocEmpleado] ASC,
	[IdMarca] ASC,
	[IdListaPrecios] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[EmpleadosComisionesMarcasPrecios]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadosComisionesMarcasPrecios_Empleados] FOREIGN KEY([TipoDocEmpleado], [NroDocEmpleado])
REFERENCES [dbo].[Empleados] ([TipoDocEmpleado], [NroDocEmpleado])
GO

ALTER TABLE [dbo].[EmpleadosComisionesMarcasPrecios] CHECK CONSTRAINT [FK_EmpleadosComisionesMarcasPrecios_Empleados]
GO

ALTER TABLE [dbo].[EmpleadosComisionesMarcasPrecios]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadosComisionesMarcasPrecios_Marcas] FOREIGN KEY([IdMarca])
REFERENCES [dbo].[Marcas] ([IdMarca])
GO

ALTER TABLE [dbo].[EmpleadosComisionesMarcasPrecios] CHECK CONSTRAINT [FK_EmpleadosComisionesMarcasPrecios_Marcas]
GO

ALTER TABLE [dbo].[EmpleadosComisionesMarcasPrecios]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadosComisionesMarcasPrecios_ListasDePrecios] FOREIGN KEY([IdListaPrecios])
REFERENCES [dbo].[ListasDePrecios] ([IdListaPrecios])
GO

ALTER TABLE [dbo].[EmpleadosComisionesMarcasPrecios] CHECK CONSTRAINT [FK_EmpleadosComisionesMarcasPrecios_ListasDePrecios]
GO
