
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EmpleadosComisionesMarcas](
	[TipoDocEmpleado] [varchar](5) NOT NULL,
	[NroDocEmpleado] [varchar](12) NOT NULL,
	[IdMarca] [int] NOT NULL,
	[Comision] [decimal](5, 2) NULL,
 CONSTRAINT [PK_EmpleadosComisionesMarcas] PRIMARY KEY CLUSTERED 
(
	[TipoDocEmpleado] ASC,
	[NroDocEmpleado] ASC,
	[IdMarca] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[EmpleadosComisionesMarcas]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadosComisionesMarcas_Empleados] FOREIGN KEY([TipoDocEmpleado], [NroDocEmpleado])
REFERENCES [dbo].[Empleados] ([TipoDocEmpleado], [NroDocEmpleado])
GO

ALTER TABLE [dbo].[EmpleadosComisionesMarcas] CHECK CONSTRAINT [FK_EmpleadosComisionesMarcas_Empleados]
GO

ALTER TABLE [dbo].[EmpleadosComisionesMarcas]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadosComisionesMarcas_Marcas] FOREIGN KEY([IdMarca])
REFERENCES [dbo].[Marcas] ([IdMarca])
GO

ALTER TABLE [dbo].[EmpleadosComisionesMarcas] CHECK CONSTRAINT [FK_EmpleadosComisionesMarcas_Marcas]
GO
