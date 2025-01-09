CREATE TABLE [dbo].[DepositosCheques] (
    [IdSucursal]      INT    NOT NULL,
    [NumeroDeposito]  BIGINT NOT NULL,
    [NumeroCheque]    INT    NOT NULL,
    [IdBanco]         INT    NOT NULL,
    [IdBancoSucursal] INT    NOT NULL,
    [IdLocalidad]     INT    NOT NULL,
    CONSTRAINT [PK_DepositosCheques] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [NumeroDeposito] ASC, [NumeroCheque] ASC, [IdBanco] ASC, [IdBancoSucursal] ASC, [IdLocalidad] ASC),
    CONSTRAINT [FK_DepositosCheques_Cheques] FOREIGN KEY ([IdSucursal], [NumeroCheque], [IdBanco], [IdBancoSucursal], [IdLocalidad]) REFERENCES [dbo].[Cheques] ([IdSucursal], [NumeroCheque], [IdBanco], [IdBancoSucursal], [IdLocalidad]),
    CONSTRAINT [FK_DepositosCheques_Depositos] FOREIGN KEY ([IdSucursal], [NumeroDeposito]) REFERENCES [dbo].[Depositos] ([IdSucursal], [NumeroDeposito])
);

