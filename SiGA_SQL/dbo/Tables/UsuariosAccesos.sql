CREATE TABLE [dbo].[UsuariosAccesos] (
    [IdSucursal]  INT           NOT NULL,
    [FechaAcceso] DATETIME      NOT NULL,
    [IdUsuario]   VARCHAR (10)  NOT NULL,
    [NombrePC]    VARCHAR (20)  NOT NULL,
    [Exitoso]     BIT           NOT NULL,
    [Observacion] VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_UsuariosAccesos] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [FechaAcceso] ASC, [IdUsuario] ASC),
    CONSTRAINT [FK_UsuariosAccesos_Sucursales] FOREIGN KEY ([IdSucursal]) REFERENCES [dbo].[Sucursales] ([IdSucursal]),
    CONSTRAINT [FK_UsuariosAccesos_Usuarios] FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[Usuarios] ([Id])
);

