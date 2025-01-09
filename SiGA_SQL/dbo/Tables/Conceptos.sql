CREATE TABLE [dbo].[Conceptos] (
    [IdConcepto]       INT          NOT NULL,
    [NombreConcepto]   VARCHAR (70) NOT NULL,
    [IdRubroConcepto]  INT          NOT NULL,
    [EsNogravado]      BIT          NOT NULL,
    [ImprimeProveedor] BIT          NOT NULL,
    [Activo]           BIT          NOT NULL,
    CONSTRAINT [PK_Conceptos] PRIMARY KEY CLUSTERED ([IdConcepto] ASC),
    CONSTRAINT [FK_Conceptos_RubrosConceptos] FOREIGN KEY ([IdRubroConcepto]) REFERENCES [dbo].[RubrosConceptos] ([IdRubroConcepto])
);

