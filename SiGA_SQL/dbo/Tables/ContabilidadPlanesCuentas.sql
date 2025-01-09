CREATE TABLE [dbo].[ContabilidadPlanesCuentas] (
    [IdPlanCuenta] INT NOT NULL,
    [IdCuenta]     BIGINT NOT NULL,
    CONSTRAINT [PK_ContabilidadPlanesCuentas] PRIMARY KEY CLUSTERED ([IdPlanCuenta] ASC, [IdCuenta] ASC),
    CONSTRAINT [FK_ContabilidadPlanesCuentas_ContabilidadPlanes] FOREIGN KEY ([IdPlanCuenta]) REFERENCES [dbo].[ContabilidadPlanes] ([IdPlanCuenta])
);



