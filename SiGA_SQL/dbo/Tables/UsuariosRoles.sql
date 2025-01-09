CREATE TABLE [dbo].[UsuariosRoles] (
    [IdUsuario]  VARCHAR (10) NOT NULL,
    [IdRol]      VARCHAR (12) NOT NULL,
    [IdSucursal] INT          NOT NULL,
    CONSTRAINT [PK_UsuariosRoles] PRIMARY KEY CLUSTERED ([IdUsuario] ASC, [IdRol] ASC, [IdSucursal] ASC),
    CONSTRAINT [FK_UsuariosRoles_Roles] FOREIGN KEY ([IdRol]) REFERENCES [dbo].[Roles] ([Id]),
    CONSTRAINT [FK_UsuariosRoles_Usuarios] FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[Usuarios] ([Id])
);

