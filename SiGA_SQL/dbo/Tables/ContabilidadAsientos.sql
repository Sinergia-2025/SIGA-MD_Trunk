CREATE TABLE [dbo].[ContabilidadAsientos] (
    [IdPlanCuenta]  INT           NOT NULL,
    [IdAsiento]     INT           NOT NULL,
    [NombreAsiento] VARCHAR (100) NOT NULL,
    [FechaAsiento]  DATE          NOT NULL,
    [IdTipoDoc]     INT           NOT NULL,
    [IdEjercicio]   INT           NOT NULL,
    [IdSucursal]    INT           NOT NULL,
    [SubsiAsiento]  CHAR (15)     NULL,
    CONSTRAINT [PK_ContabilidadAsientos] PRIMARY KEY CLUSTERED ([IdPlanCuenta] ASC, [IdAsiento] ASC),
    CONSTRAINT [FK_ContabilidadAsientos_ContabilidadEjercicios] FOREIGN KEY ([IdEjercicio]) REFERENCES [dbo].[ContabilidadEjercicios] ([IdEjercicio]),
    CONSTRAINT [FK_ContabilidadAsientos_ContabilidadPlanes] FOREIGN KEY ([IdPlanCuenta]) REFERENCES [dbo].[ContabilidadPlanes] ([IdPlanCuenta]),
    CONSTRAINT [FK_ContabilidadAsientos_Sucursales] FOREIGN KEY ([IdSucursal]) REFERENCES [dbo].[Sucursales] ([IdSucursal])
);

