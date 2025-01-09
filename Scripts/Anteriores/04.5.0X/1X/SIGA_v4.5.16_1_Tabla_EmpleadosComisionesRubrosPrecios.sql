
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[EmpleadosComisionesRubrosPrecios](
	[TipoDocEmpleado] [varchar](5) NOT NULL,
	[NroDocEmpleado] [varchar](12) NOT NULL,
	[IdRubro] [int] NOT NULL,
	[IdListaPrecios] [int] NOT NULL,
	[Comision] [decimal](5, 2) NULL,
 CONSTRAINT [PK_EmpleadosComisionesRubrosPrecios] PRIMARY KEY CLUSTERED 
(
	[TipoDocEmpleado] ASC,
	[NroDocEmpleado] ASC,
	[IdRubro] ASC,
	[IdListaPrecios] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[EmpleadosComisionesRubrosPrecios]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadosComisionesRubrosPrecios_Empleados] FOREIGN KEY([TipoDocEmpleado], [NroDocEmpleado])
REFERENCES [dbo].[Empleados] ([TipoDocEmpleado], [NroDocEmpleado])
GO

ALTER TABLE [dbo].[EmpleadosComisionesRubrosPrecios] CHECK CONSTRAINT [FK_EmpleadosComisionesRubrosPrecios_Empleados]
GO

ALTER TABLE [dbo].[EmpleadosComisionesRubrosPrecios]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadosComisionesRubrosPrecios_Rubros] FOREIGN KEY([IdRubro])
REFERENCES [dbo].[Rubros] ([IdRubro])
GO

ALTER TABLE [dbo].[EmpleadosComisionesRubrosPrecios] CHECK CONSTRAINT [FK_EmpleadosComisionesRubrosPrecios_Rubros]
GO

ALTER TABLE [dbo].[EmpleadosComisionesRubrosPrecios]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadosComisionesRubrosPrecios_ListasDePrecios] FOREIGN KEY([IdListaPrecios])
REFERENCES [dbo].[ListasDePrecios] ([IdListaPrecios])
GO

ALTER TABLE [dbo].[EmpleadosComisionesRubrosPrecios] CHECK CONSTRAINT [FK_EmpleadosComisionesRubrosPrecios_ListasDePrecios]
GO
