CREATE TABLE [dbo].[CuentasBancos] (
    [IdCuentaBanco]     INT          NOT NULL,
    [NombreCuentaBanco] VARCHAR (40) NOT NULL,
    [IdTipoCuenta]      CHAR (1)     NOT NULL,
    [EsPosdatado]       BIT          NOT NULL,
    [PideCheque]        BIT          NOT NULL,
    [IdCuentaContable]  INT          NULL,
    [IdGrupoCuenta]     VARCHAR (15) NOT NULL,
    CONSTRAINT [PK_CuentasBancos] PRIMARY KEY CLUSTERED ([IdCuentaBanco] ASC)
);

