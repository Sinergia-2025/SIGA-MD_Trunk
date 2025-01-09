CREATE TABLE [dbo].[Depositos] (
    [IdSucursal]       INT             NOT NULL,
    [NumeroDeposito]   BIGINT          NOT NULL,
    [IdCuentaBancaria] INT             NOT NULL,
    [Fecha]            DATETIME        NOT NULL,
    [UsoFechaCheque]   BIT             NOT NULL,
    [ImporteTotal]     DECIMAL (12, 2) NOT NULL,
    [Observacion]      VARCHAR (100)   NULL,
    [ImportePesos]     DECIMAL (10, 2) NOT NULL,
    [ImporteDolares]   DECIMAL (10, 2) NOT NULL,
    [ImporteEuros]     DECIMAL (10, 2) NOT NULL,
    [ImporteCheques]   DECIMAL (10, 2) NOT NULL,
    [ImporteTarjetas]  DECIMAL (10, 2) NOT NULL,
    [ImporteTickets]   DECIMAL (10, 2) NOT NULL,
    [FechaAplicado]    DATETIME        NOT NULL,
    [PeriodoContable]  VARCHAR (7)     NULL,
    [IdEstado]         VARCHAR (10)    NOT NULL,
    [IdCaja]           INT             NULL,
    CONSTRAINT [PK_Depositos] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [NumeroDeposito] ASC),
    CONSTRAINT [FK_Depositos_CuentasBancarias] FOREIGN KEY ([IdCuentaBancaria]) REFERENCES [dbo].[CuentasBancarias] ([IdCuentaBancaria]),
    CONSTRAINT [FK_Depositos_Sucursales] FOREIGN KEY ([IdSucursal]) REFERENCES [dbo].[Sucursales] ([IdSucursal])
);

