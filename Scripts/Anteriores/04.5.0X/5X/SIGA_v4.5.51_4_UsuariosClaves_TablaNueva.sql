
CREATE TABLE [dbo].[UsuariosClaves](
	[IdUsuario] [varchar](10) NOT NULL,
	[FechaModContrase�a] [datetime] NOT NULL,
	[Clave] [varchar](15) NULL,
 CONSTRAINT [PK_UsuariosClaves] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC,
	[FechaModContrase�a] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[UsuariosClaves]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_UsuariosClaves] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([Id])
GO

ALTER TABLE [dbo].[UsuariosClaves] CHECK CONSTRAINT [FK_Usuarios_UsuariosClaves]
GO

ALTER TABLE [dbo].[UsuariosClaves]  WITH CHECK ADD  CONSTRAINT [FK_UsuariosClaves_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([Id])
GO

ALTER TABLE [dbo].[UsuariosClaves] CHECK CONSTRAINT [FK_UsuariosClaves_Usuarios]
GO


/* ------------ */ 
INSERT INTO UsuariosClaves
           (IdUsuario, FechaModContrase�a, Clave)
SELECT Id, FechaUltimaModContrase�a, Clave FROM Usuarios
GO
