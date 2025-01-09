CREATE TABLE [dbo].[CajasNombres] (
    [IdSucursal]       INT             NOT NULL,
    [IdCaja]           INT             NOT NULL,
    [NombreCaja]       VARCHAR (30)    NOT NULL,
    [NombrePC]         VARCHAR (20)    NULL,
    [IdPlanCuenta]     INT             NOT NULL,
    [TopeAviso]        DECIMAL (10, 2) NOT NULL,
    [TopeBloqueo]      DECIMAL (10, 2) NOT NULL,
    [IdCuentaContable] INT             NULL,
    [IdUsuario]        VARCHAR (10)    NULL,
    CONSTRAINT [PK_SubCajas] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdCaja] ASC),
    CONSTRAINT [FK_CajasNombres_ContabilidadPlanes] FOREIGN KEY ([IdPlanCuenta]) REFERENCES [dbo].[ContabilidadPlanes] ([IdPlanCuenta]),
    CONSTRAINT [FK_CajasNombres_Sucursales] FOREIGN KEY ([IdSucursal]) REFERENCES [dbo].[Sucursales] ([IdSucursal]),
    CONSTRAINT [FK_CajasNombres_Usuarios] FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[Usuarios] ([Id])
);

