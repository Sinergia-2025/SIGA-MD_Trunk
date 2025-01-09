CREATE TABLE [dbo].[ContabilidadAsientosTmp] (
    [IdPlanCuenta]           INT          NOT NULL,
    [IdAsiento]              INT          NOT NULL,
    [NombreAsiento]          VARCHAR (70) NOT NULL,
    [FechaAsiento]           DATE         NOT NULL,
    [IdTipoDoc]              INT          NOT NULL,
    [IdEjercicio]            INT          NOT NULL,
    [IdSucursal]             INT          NOT NULL,
    [SubsiAsiento]           CHAR (15)    NULL,
    [IdPlanCuentaDefinitivo] INT          NULL,
    [IdAsientoDefinitivo]    INT          NULL,
    CONSTRAINT [PK_ContabilidadAsientosTmp] PRIMARY KEY CLUSTERED ([IdPlanCuenta] ASC, [IdAsiento] ASC),
    CONSTRAINT [FK_ContabilidadAsientosTmp_ContabilidadEjercicios] FOREIGN KEY ([IdEjercicio]) REFERENCES [dbo].[ContabilidadEjercicios] ([IdEjercicio]),
    CONSTRAINT [FK_ContabilidadAsientosTmp_ContabilidadPlanes] FOREIGN KEY ([IdPlanCuenta]) REFERENCES [dbo].[ContabilidadPlanes] ([IdPlanCuenta]),
    CONSTRAINT [FK_ContabilidadAsientosTmp_Sucursales] FOREIGN KEY ([IdSucursal]) REFERENCES [dbo].[Sucursales] ([IdSucursal])
);

