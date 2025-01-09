CREATE TABLE [dbo].[CajasUsuarios] (
    [IdSucursal]        INT          NOT NULL,
    [IdCaja]            INT          NOT NULL,
    [IdUsuario]         VARCHAR (10) NOT NULL,
    [PermitirEscritura] BIT          NOT NULL,
    CONSTRAINT [PK_SubCajasUsuarios] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdCaja] ASC, [IdUsuario] ASC),
    CONSTRAINT [FK_CajasUsuarios_Usuarios] FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[Usuarios] ([Id]),
    CONSTRAINT [FK_SubCajasUsuarios_SubCajas] FOREIGN KEY ([IdSucursal], [IdCaja]) REFERENCES [dbo].[CajasNombres] ([IdSucursal], [IdCaja])
);

