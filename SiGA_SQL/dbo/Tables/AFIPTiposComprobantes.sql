CREATE TABLE [dbo].[AFIPTiposComprobantes] (
    [IdAFIPTipoComprobante]     INT           NOT NULL,
    [NombreAFIPTipoComprobante] VARCHAR (100) NOT NULL,
    [IdTipoComprobante]         VARCHAR (15)  NULL,
    [Letra]                     VARCHAR (1)   NULL,
    CONSTRAINT [PK_AFIPTiposComprobantes] PRIMARY KEY CLUSTERED ([IdAFIPTipoComprobante] ASC),
    CONSTRAINT [FK_AFIPTiposComprobantes_TiposComprobantes] FOREIGN KEY ([IdTipoComprobante]) REFERENCES [dbo].[TiposComprobantes] ([IdTipoComprobante])
);

