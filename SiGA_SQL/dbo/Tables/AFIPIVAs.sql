CREATE TABLE [dbo].[AFIPIVAs] (
    [IdAFIPIVA]          INT            NOT NULL,
    [DescripcionAFIPIVA] VARCHAR (50)   NULL,
    [IdTipoImpuesto]     VARCHAR (5)    NULL,
    [Alicuota]           DECIMAL (6, 2) NULL,
    CONSTRAINT [PK_AFIPIVAs] PRIMARY KEY CLUSTERED ([IdAFIPIVA] ASC),
    CONSTRAINT [FK_AFIPIVAs_Impuestos] FOREIGN KEY ([IdTipoImpuesto], [Alicuota]) REFERENCES [dbo].[Impuestos] ([IdTipoImpuesto], [Alicuota])
);

