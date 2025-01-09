
/****** Object:  Table [dbo].[ClientesContactos]    Script Date: 08/08/2017 16:30:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ClientesContactos](
	[IdCliente] [bigint] NOT NULL,
	[IdContacto] [int] NOT NULL,
	[NombreContacto] [varchar](100) NOT NULL,
	[Direccion] [varchar](100) NOT NULL,
	[IdLocalidad] [int] NOT NULL,
	[Telefono] [varchar](100) NULL,
	[CorreoElectronico] [varchar](500) NULL,
	[Celular] [varchar](100) NULL,
	[Observacion] [varchar](1000) NULL,
	[Activo] [bit] NOT NULL,
	[IdUsuario] [varchar](10) NOT NULL,
	[IdTipoContacto] [int] NOT NULL,
 CONSTRAINT [PK_ClientesContactos] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC,
	[IdContacto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ClientesContactos]  WITH CHECK ADD  CONSTRAINT [FK_ClientesContactos_Clientes] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO

ALTER TABLE [dbo].[ClientesContactos] CHECK CONSTRAINT [FK_ClientesContactos_Clientes]
GO

ALTER TABLE [dbo].[ClientesContactos]  WITH CHECK ADD  CONSTRAINT [FK_ClientesContactos_Localidades] FOREIGN KEY([IdLocalidad])
REFERENCES [dbo].[Localidades] ([IdLocalidad])
GO

ALTER TABLE [dbo].[ClientesContactos] CHECK CONSTRAINT [FK_ClientesContactos_Localidades]
GO

ALTER TABLE [dbo].[ClientesContactos]  WITH CHECK ADD  CONSTRAINT [FK_ClientesContactos_TiposContactos] FOREIGN KEY([IdTipoContacto])
REFERENCES [dbo].[TiposContactos] ([IdTipoContacto])
GO

ALTER TABLE [dbo].[ClientesContactos] CHECK CONSTRAINT [FK_ClientesContactos_TiposContactos]
GO

ALTER TABLE [dbo].[ClientesContactos]  WITH CHECK ADD  CONSTRAINT [FK_ClientesContactos_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([Id])
GO

ALTER TABLE [dbo].[ClientesContactos] CHECK CONSTRAINT [FK_ClientesContactos_Usuarios]
GO


