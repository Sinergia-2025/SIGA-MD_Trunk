CREATE TABLE [dbo].[SueldosCierreLiqDatos] (
    [IdLegajo]                           INT           NOT NULL,
    [IdTipoRecibo]                       INT           NOT NULL,
    [PeriodoLiquidacion]                 INT           NOT NULL,
    [FechaPago]                          DATE          NOT NULL,
    [LugarPago]                          VARCHAR (100) NOT NULL,
    [DomicilioEmpresa]                   VARCHAR (150) NOT NULL,
    [IdBancoCtaBancaria]                 INT           NULL,
    [IdCuentasBancariasClaseCtaBancaria] INT           NULL,
    [NumeroCuentaBancaria]               VARCHAR (30)  NULL,
    [CBU]                                DECIMAL (22)  NULL,
    [NroLiquidacion]                     INT           NOT NULL,
    CONSTRAINT [PK_SueldosCierreLiqDatos] PRIMARY KEY CLUSTERED ([IdLegajo] ASC, [IdTipoRecibo] ASC, [PeriodoLiquidacion] ASC, [NroLiquidacion] ASC)
);

