CREATE TABLE [dbo].[ContabilidadAsientosCuentasTmp] (
    [IdPlanCuenta] INT             NOT NULL,
    [IdAsiento]    INT             NOT NULL,
    [IdCuenta]     BIGINT             NOT NULL,
    [IdRenglon]    INT             NOT NULL,
    [Debe]         DECIMAL (12, 2) NULL,
    [Haber]        DECIMAL (12, 2) NULL,
    CONSTRAINT [PK_ContabilidadAsientosCuentasTmp] PRIMARY KEY CLUSTERED ([IdPlanCuenta] ASC, [IdAsiento] ASC, [IdCuenta] ASC, [IdRenglon] ASC),
    CONSTRAINT [FK_ContabilidadAsientosCuentasTmp_ContabilidadAsientosTmp] FOREIGN KEY ([IdPlanCuenta], [IdAsiento]) REFERENCES [dbo].[ContabilidadAsientosTmp] ([IdPlanCuenta], [IdAsiento]),
    CONSTRAINT [FK_ContabilidadAsientosCuentasTmp_ContabilidadCuentas] FOREIGN KEY ([IdCuenta]) REFERENCES [dbo].[ContabilidadCuentas] ([IdCuenta])
);

