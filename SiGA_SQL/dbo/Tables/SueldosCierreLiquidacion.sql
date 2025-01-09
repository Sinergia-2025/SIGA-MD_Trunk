CREATE TABLE [dbo].[SueldosCierreLiquidacion] (
    [IdLegajo]           INT             NOT NULL,
    [IdTipoRecibo]       INT             NOT NULL,
    [PeriodoLiquidacion] INT             NOT NULL,
    [IdTipoConcepto]     INT             NOT NULL,
    [IdConcepto]         INT             NOT NULL,
    [Valor]              DECIMAL (10, 2) NULL,
    [Importe]            DECIMAL (10, 2) NULL,
    [Aguinaldo]          VARCHAR (1)     NULL,
    [NroLiquidacion]     INT             NOT NULL,
    CONSTRAINT [PK_SueldosCierreLiquidacion] PRIMARY KEY CLUSTERED ([IdLegajo] ASC, [IdTipoConcepto] ASC, [IdConcepto] ASC, [IdTipoRecibo] ASC, [PeriodoLiquidacion] ASC, [NroLiquidacion] ASC),
    CONSTRAINT [FK_SueldosCierreLiquidacion_SueldosConceptos] FOREIGN KEY ([IdTipoConcepto], [IdConcepto]) REFERENCES [dbo].[SueldosConceptos] ([IdTipoConcepto], [IdConcepto]),
    CONSTRAINT [FK_SueldosCierreLiquidacion_SueldosPersonal] FOREIGN KEY ([IdLegajo]) REFERENCES [dbo].[SueldosPersonal] ([IdLegajo]),
    CONSTRAINT [FK_SueldosCierreLiquidacion_SueldosTiposRecibos] FOREIGN KEY ([IdTipoRecibo]) REFERENCES [dbo].[SueldosTiposRecibos] ([IdTipoRecibo])
);

