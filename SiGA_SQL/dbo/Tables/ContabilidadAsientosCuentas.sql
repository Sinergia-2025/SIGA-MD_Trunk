CREATE TABLE [dbo].[ContabilidadAsientosCuentas] (
    [IdPlanCuenta] INT             NOT NULL,
    [IdAsiento]    INT             NOT NULL,
    [IdCuenta]     BIGINT             NOT NULL,
    [IdRenglon]    INT             NOT NULL,
    [Debe]         DECIMAL (12, 2) NULL,
    [Haber]        DECIMAL (12, 2) NULL,
    CONSTRAINT [PK_ContabilidadAsientosCuentas] PRIMARY KEY CLUSTERED ([IdPlanCuenta] ASC, [IdAsiento] ASC, [IdCuenta] ASC, [IdRenglon] ASC),
    CONSTRAINT [FK_ContabilidadAsientosCuentas_ContabilidadAsientos] FOREIGN KEY ([IdPlanCuenta], [IdAsiento]) REFERENCES [dbo].[ContabilidadAsientos] ([IdPlanCuenta], [IdAsiento]),
    CONSTRAINT [FK_ContabilidadAsientosCuentas_ContabilidadCuentas] FOREIGN KEY ([IdCuenta]) REFERENCES [dbo].[ContabilidadCuentas] ([IdCuenta])
);

