CREATE TABLE [dbo].[SueldosTiposRecibos] (
    [IdTipoRecibo]          INT          NOT NULL,
    [NombreTipoRecibo]      VARCHAR (50) NOT NULL,
    [PeriodoLiquidacion]    INT          NOT NULL,
    [NumeroLiquidacion]     INT          NOT NULL,
    [ImprimeRecibo]         BIT          NOT NULL,
    [CantidadLiquid]        INT          NOT NULL,
    [CantidadLiquidPeriodo] INT          NOT NULL,
    [FechaPago]             DATE         NOT NULL,
    CONSTRAINT [PK_SueldosTiposRecibos] PRIMARY KEY CLUSTERED ([IdTipoRecibo] ASC)
);



