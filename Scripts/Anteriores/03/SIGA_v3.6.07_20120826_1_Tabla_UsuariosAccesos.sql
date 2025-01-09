
--DROP TABLE [dbo].[UsuariosAccesos]
--GO


/****** Object:  Table [dbo].[UsuariosAccesos]    Script Date: 08/26/2012 19:10:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[UsuariosAccesos](
	[IdSucursal] [int] NOT NULL,
	[FechaAcceso] [datetime] NOT NULL,
	[IdUsuario] [varchar](10) NOT NULL,
	[NombrePC] [varchar](20) NOT NULL,
	[Exitoso] [bit] NOT NULL,
	[Observacion] [varchar](100) NOT NULL,
 CONSTRAINT [PK_UsuariosAccesos] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[FechaAcceso] ASC,
	[IdUsuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[UsuariosAccesos]  WITH CHECK ADD  CONSTRAINT [FK_UsuariosAccesos_Sucursales] FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[Sucursales] ([IdSucursal])
GO

ALTER TABLE [dbo].[UsuariosAccesos] CHECK CONSTRAINT [FK_UsuariosAccesos_Sucursales]
GO

ALTER TABLE [dbo].[UsuariosAccesos]  WITH CHECK ADD  CONSTRAINT [FK_UsuariosAccesos_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([Id])
GO

ALTER TABLE [dbo].[UsuariosAccesos] CHECK CONSTRAINT [FK_UsuariosAccesos_Usuarios]
GO


