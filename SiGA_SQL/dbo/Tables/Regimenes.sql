CREATE TABLE [dbo].[Regimenes] (
    [IdRegimen]                INT             NOT NULL,
    [ConceptoRegimen]          VARCHAR (200)   NOT NULL,
    [ARetenerInscripto]        DECIMAL (14, 2) NULL,
    [ARetenerNoInscripto]      DECIMAL (14, 2) NULL,
    [MontoAExceder]            DECIMAL (14, 2) NULL,
    [ImporteMinimoInscripto]   DECIMAL (14, 2) NULL,
    [ImporteMinimoNoInscripto] DECIMAL (14, 2) NULL,
    [IdTipoImpuesto]           VARCHAR (5)     NOT NULL,
    [RetienePorEscala]         BIT             NOT NULL,
    CONSTRAINT [PK_Regimenes] PRIMARY KEY CLUSTERED ([IdRegimen] ASC),
    CONSTRAINT [FK_Regimenes_TiposImpuestos] FOREIGN KEY ([IdTipoImpuesto]) REFERENCES [dbo].[TiposImpuestos] ([IdTipoImpuesto])
);

