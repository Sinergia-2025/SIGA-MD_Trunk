CREATE TABLE [dbo].[SueldosTiposConceptos] (
    [IdTipoConcepto]     INT          NOT NULL,
    [NombreTipoConcepto] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_SueldosRubrosConceptos] PRIMARY KEY CLUSTERED ([IdTipoConcepto] ASC)
);

