CREATE TABLE [dbo].[SueldosCierrePuntero] (
    [NroPerson]     INT          NOT NULL,
    [Caja]          VARCHAR (15) NULL,
    [Inscripcion]   VARCHAR (12) NULL,
    [NroLiqui]      INT          NULL,
    [LiqQuincela]   INT          NULL,
    [LiqMes]        INT          NULL,
    [LiqAno]        INT          NULL,
    [FechaPago]     DATE         NULL,
    [FechaDeposito] DATE         NULL,
    [DepositoLapso] VARCHAR (5)  NULL,
    [DepositoBano]  VARCHAR (15) NULL
);

