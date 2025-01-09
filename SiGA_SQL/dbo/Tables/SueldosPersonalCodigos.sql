CREATE TABLE [dbo].[SueldosPersonalCodigos] (
    [IdLegajo]       INT             NOT NULL,
    [IdTipoRecibo]   INT             NOT NULL,
    [IdTipoConcepto] INT             NOT NULL,
    [IdConcepto]     INT             NOT NULL,
    [Valor]          DECIMAL (10, 2) NULL,
    [Aguinaldo]      VARCHAR (1)     NULL,
    [Periodos]       INT             NULL,
    CONSTRAINT [PK_SueldosPersonalCodigos] PRIMARY KEY CLUSTERED ([IdLegajo] ASC, [IdTipoConcepto] ASC, [IdConcepto] ASC, [IdTipoRecibo] ASC),
    CONSTRAINT [FK_SueldosPersonalCodigos_SueldosPersonal] FOREIGN KEY ([IdLegajo]) REFERENCES [dbo].[SueldosPersonal] ([IdLegajo]),
    CONSTRAINT [FK_SueldosPersonalCodigos_SueldosRubrosConceptos] FOREIGN KEY ([IdTipoConcepto]) REFERENCES [dbo].[SueldosTiposConceptos] ([IdTipoConcepto]),
    CONSTRAINT [FK_SueldosPersonalCodigos_SueldosTiposRecibos] FOREIGN KEY ([IdTipoRecibo]) REFERENCES [dbo].[SueldosTiposRecibos] ([IdTipoRecibo])
);

