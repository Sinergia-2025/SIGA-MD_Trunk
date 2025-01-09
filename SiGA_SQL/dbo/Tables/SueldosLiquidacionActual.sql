CREATE TABLE [dbo].[SueldosLiquidacionActual] (
    [IdLegajo]       INT             NOT NULL,
    [IdTipoRecibo]   INT             NOT NULL,
    [IdTipoConcepto] INT             NOT NULL,
    [IdConcepto]     INT             NOT NULL,
    [Valor]          DECIMAL (10, 2) NULL,
    [Importe]        DECIMAL (10, 2) NULL,
    [NroLiquidacion] INT             NULL,
    [Aguinaldo]      VARCHAR (1)     NULL,
    CONSTRAINT [PK_SueldosLiquidacionActual] PRIMARY KEY CLUSTERED ([IdLegajo] ASC, [IdTipoRecibo] ASC, [IdTipoConcepto] ASC, [IdConcepto] ASC),
    CONSTRAINT [FK_SueldosLiquidacionActual_SueldosConceptos] FOREIGN KEY ([IdTipoConcepto], [IdConcepto]) REFERENCES [dbo].[SueldosConceptos] ([IdTipoConcepto], [IdConcepto]),
    CONSTRAINT [FK_SueldosLiquidacionActual_SueldosPersonal] FOREIGN KEY ([IdLegajo]) REFERENCES [dbo].[SueldosPersonal] ([IdLegajo]),
    CONSTRAINT [FK_SueldosLiquidacionActual_SueldosRubrosConceptos] FOREIGN KEY ([IdTipoConcepto]) REFERENCES [dbo].[SueldosTiposConceptos] ([IdTipoConcepto]),
    CONSTRAINT [FK_SueldosLiquidacionActual_SueldosTiposRecibos] FOREIGN KEY ([IdTipoRecibo]) REFERENCES [dbo].[SueldosTiposRecibos] ([IdTipoRecibo])
);

