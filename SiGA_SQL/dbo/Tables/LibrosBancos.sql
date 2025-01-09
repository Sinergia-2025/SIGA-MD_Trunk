CREATE TABLE [dbo].[LibrosBancos] (
    [IdSucursal]            INT             NOT NULL,
    [IdCuentaBancaria]      INT             NOT NULL,
    [NumeroMovimiento]      INT             NOT NULL,
    [IdCuentaBanco]         INT             NOT NULL,
    [IdTipoMovimiento]      CHAR (1)        NOT NULL,
    [Importe]               DECIMAL (10, 2) NOT NULL,
    [FechaMovimiento]       DATETIME        NOT NULL,
    [FechaAplicado]         DATETIME        NOT NULL,
    [Observacion]           VARCHAR (100)   NULL,
    [Conciliado]            BIT             NOT NULL,
    [NumeroCheque]          INT             NULL,
    [IdBancoCheque]         INT             NULL,
    [IdBancoSucursalCheque] INT             NULL,
    [IdLocalidadCheque]     INT             NULL,
    [IdAsiento]             INT             NULL,
    [IdPlanCuenta]          INT             NULL,
    CONSTRAINT [PK_LibrosBancos] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdCuentaBancaria] ASC, [NumeroMovimiento] ASC),
    CONSTRAINT [FK_LibrosBancos_Cheques] FOREIGN KEY ([IdSucursal], [NumeroCheque], [IdBancoCheque], [IdBancoSucursalCheque], [IdLocalidadCheque]) REFERENCES [dbo].[Cheques] ([IdSucursal], [NumeroCheque], [IdBanco], [IdBancoSucursal], [IdLocalidad]),
    CONSTRAINT [FK_LibrosBancos_CuentasBancarias] FOREIGN KEY ([IdCuentaBancaria]) REFERENCES [dbo].[CuentasBancarias] ([IdCuentaBancaria]),
    CONSTRAINT [FK_LibrosBancos_CuentasBancos] FOREIGN KEY ([IdCuentaBanco]) REFERENCES [dbo].[CuentasBancos] ([IdCuentaBanco])
);



