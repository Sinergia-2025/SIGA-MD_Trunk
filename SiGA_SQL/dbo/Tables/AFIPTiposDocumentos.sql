CREATE TABLE [dbo].[AFIPTiposDocumentos] (
    [IdAFIPTipoDocumento]     INT          NOT NULL,
    [NombreAFIPTipoDocumento] VARCHAR (50) NULL,
    [TipoDocumento]           VARCHAR (5)  NULL,
    CONSTRAINT [PK_AFIPTiposDocumentos] PRIMARY KEY CLUSTERED ([IdAFIPTipoDocumento] ASC),
    CONSTRAINT [FK_AFIPTiposDocumentos_TiposDocumento] FOREIGN KEY ([TipoDocumento]) REFERENCES [dbo].[TiposDocumento] ([TipoDocumento])
);

