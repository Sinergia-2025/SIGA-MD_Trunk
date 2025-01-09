
CREATE TABLE [Proyectos](
	[IdProyecto] [int] NOT NULL,
	[NombreProyecto] [varchar](100) NOT NULL,
	[IdCliente] [bigint] NOT NULL,
	[Estado] [varchar](50) NOT NULL,
	[FechaInicio] [date] NOT NULL,
	[FechaFin] [date] NOT NULL,
	[Estimado] [decimal](12, 2) NOT NULL,
	[Presupuestado] [decimal](12, 2) NOT NULL,
 CONSTRAINT [PK_Proyectos] PRIMARY KEY CLUSTERED 
(
	[IdProyecto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE Proyectos  WITH CHECK ADD  CONSTRAINT [FK_Proyectos_Clientes] FOREIGN KEY([IdCliente])
REFERENCES Clientes ([IdCliente])
GO

ALTER TABLE [dbo].[Proyectos] CHECK CONSTRAINT [FK_Proyectos_Clientes]
GO
