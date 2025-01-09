CREATE TABLE [dbo].[AFIPTiposComprobantesTiposCbtes] (
    [IdAFIPTipoComprobante] INT          NOT NULL,
    [IdTipoComprobante]     VARCHAR (15) NOT NULL,
    [Letra]                 VARCHAR (1)  NOT NULL,
    CONSTRAINT [PK_AFIPTiposComprobantesTiposCbtes] PRIMARY KEY CLUSTERED ([IdAFIPTipoComprobante] ASC, [IdTipoComprobante] ASC, [Letra] ASC),
    CONSTRAINT [FK_AFIPTiposComprobantesTiposCbtes_AFIPTiposComprobantes] FOREIGN KEY ([IdAFIPTipoComprobante]) REFERENCES [dbo].[AFIPTiposComprobantes] ([IdAFIPTipoComprobante])
);

