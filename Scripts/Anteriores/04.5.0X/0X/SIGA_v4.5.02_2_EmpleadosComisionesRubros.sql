
CREATE TABLE [dbo].[EmpleadosComisionesRubros](
	[TipoDocEmpleado] [varchar](5) NOT NULL,
	[NroDocEmpleado] [varchar](12) NOT NULL,
	[IdRubro] [int] NOT NULL,
	[Comision] [decimal](5, 2) NULL,
 CONSTRAINT [PK_EmpleadosComisionesRubros] PRIMARY KEY CLUSTERED 
(
	[TipoDocEmpleado] ASC,
	[NroDocEmpleado] ASC,
	[IdRubro] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[EmpleadosComisionesRubros]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadosComisionesRubros_Empleados] FOREIGN KEY([TipoDocEmpleado], [NroDocEmpleado])
REFERENCES [dbo].[Empleados] ([TipoDocEmpleado], [NroDocEmpleado])
GO

ALTER TABLE [dbo].[EmpleadosComisionesRubros] CHECK CONSTRAINT [FK_EmpleadosComisionesRubros_Empleados]
GO

ALTER TABLE [dbo].[EmpleadosComisionesRubros]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadosComisionesRubros_Rubros] FOREIGN KEY([IdRubro])
REFERENCES [dbo].[Rubros] ([IdRubro])
GO

ALTER TABLE [dbo].[EmpleadosComisionesRubros] CHECK CONSTRAINT [FK_EmpleadosComisionesRubros_Rubros]
GO
