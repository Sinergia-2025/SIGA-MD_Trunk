CREATE TABLE [dbo].[CuentasDeCajas] (
    [IdCuentaCaja]     INT          NOT NULL,
    [NombreCuentaCaja] VARCHAR (40) NOT NULL,
    [IdTipoCuenta]     CHAR (1)     NOT NULL,
    [EsPosdatado]      BIT          NOT NULL,
    [PideCheque]       BIT          NOT NULL,
    [IdGrupoCuenta]    VARCHAR (15) NOT NULL,
    [IdCuentaContable] INT          NULL,
    CONSTRAINT [PK_CuentasDeCajas] PRIMARY KEY CLUSTERED ([IdCuentaCaja] ASC)
);

