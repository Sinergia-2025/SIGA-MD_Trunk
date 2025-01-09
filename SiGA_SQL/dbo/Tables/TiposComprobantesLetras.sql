CREATE TABLE [dbo].[TiposComprobantesLetras] (
    [IdTipoComprobante]          VARCHAR (15)  NOT NULL,
    [Letra]                      VARCHAR (1)   NOT NULL,
    [ArchivoAImprimir]           VARCHAR (100) NOT NULL,
    [ArchivoAImprimirEmbebido]   BIT           NOT NULL,
    [NombreImpresora]            VARCHAR (100) NULL,
    [CantidadItemsProductos]     INT           NOT NULL,
    [CantidadItemsObservaciones] INT           NOT NULL,
    [Imprime]                    BIT           NOT NULL,
    [CantidadCopias]             INT           NOT NULL,
    CONSTRAINT [PK_TiposComprobantesLetras] PRIMARY KEY CLUSTERED ([IdTipoComprobante] ASC, [Letra] ASC),
    CONSTRAINT [FK_TiposComprobantesLetras_TiposComprobantes] FOREIGN KEY ([IdTipoComprobante]) REFERENCES [dbo].[TiposComprobantes] ([IdTipoComprobante])
);

