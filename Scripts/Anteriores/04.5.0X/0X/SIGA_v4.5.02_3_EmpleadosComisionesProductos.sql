
CREATE TABLE [dbo].[EmpleadosComisionesProductos](
	[TipoDocEmpleado] [varchar](5) NOT NULL,
	[NroDocEmpleado] [varchar](12) NOT NULL,
	[IdProducto] [varchar](15) NOT NULL,
	[Comision] [decimal](5, 2) NULL,
 CONSTRAINT [PK_EmpleadosComisionesProductos] PRIMARY KEY CLUSTERED 
(
	[TipoDocEmpleado] ASC,
	[NroDocEmpleado] ASC,
	[IdProducto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[EmpleadosComisionesProductos]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadosComisionesProductos_Empleados] FOREIGN KEY([TipoDocEmpleado], [NroDocEmpleado])
REFERENCES [dbo].[Empleados] ([TipoDocEmpleado], [NroDocEmpleado])
GO

ALTER TABLE [dbo].[EmpleadosComisionesProductos] CHECK CONSTRAINT [FK_EmpleadosComisionesProductos_Empleados]
GO

ALTER TABLE [dbo].[EmpleadosComisionesProductos]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadosComisionesProductos_Productos] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([IdProducto])
GO

ALTER TABLE [dbo].[EmpleadosComisionesProductos] CHECK CONSTRAINT [FK_EmpleadosComisionesProductos_Productos]
GO
