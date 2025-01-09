CREATE TABLE [dbo].[CuentasBancarias] (
    [IdCuentaBancaria]      INT             NOT NULL,
    [CodigoBancario]        VARCHAR (20)    NOT NULL,
    [IdCuentaBancariaClase] INT             NOT NULL,
    [TieneChequera]         BIT             NOT NULL,
    [IdMoneda]              INT             NOT NULL,
    [IdBanco]               INT             NOT NULL,
    [IdLocalidad]           INT             NOT NULL,
    [Saldo]                 DECIMAL (12, 2) NULL,
    [SaldoConfirmado]       DECIMAL (12, 2) NULL,
    [IdBancoSucursal]       INT             NOT NULL,
    [NombreCuenta]          VARCHAR (50)    NOT NULL,
    [Activo]                BIT             NOT NULL,
    [IdPlanCuenta]          INT             NULL,
    [IdCuentaContable]      INT             NULL,
    CONSTRAINT [PK_CuentasBancarias] PRIMARY KEY CLUSTERED ([IdCuentaBancaria] ASC),
    CONSTRAINT [FK_CuentasBancarias_Bancos] FOREIGN KEY ([IdBanco]) REFERENCES [dbo].[Bancos] ([IdBanco]),
    CONSTRAINT [FK_CuentasBancarias_CuentasBancosClase] FOREIGN KEY ([IdCuentaBancariaClase]) REFERENCES [dbo].[CuentasBancariasClase] ([IdCuentaBancariaClase]),
    CONSTRAINT [FK_CuentasBancarias_Localidades] FOREIGN KEY ([IdLocalidad]) REFERENCES [dbo].[Localidades] ([IdLocalidad]),
    CONSTRAINT [FK_CuentasBancarias_Monedas] FOREIGN KEY ([IdMoneda]) REFERENCES [dbo].[Monedas] ([IdMoneda])
);

