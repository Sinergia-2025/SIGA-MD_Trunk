CREATE TABLE [dbo].[ClientesMarcasListasDePrecios] (
    [IdMarca]        INT    NOT NULL,
    [IdListaPrecios] INT    NOT NULL,
    [IdCliente]      BIGINT NOT NULL,
    CONSTRAINT [PK_ClientesMarcasListasDePrecios] PRIMARY KEY CLUSTERED ([IdCliente] ASC, [IdMarca] ASC),
    CONSTRAINT [FK_ClientesMarcasListasDePrecios_Clientes] FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[Clientes] ([IdCliente]),
    CONSTRAINT [FK_ClientesMarcasListasDePrecios_ListasDePrecios] FOREIGN KEY ([IdListaPrecios]) REFERENCES [dbo].[ListasDePrecios] ([IdListaPrecios]),
    CONSTRAINT [FK_ClientesMarcasListasDePrecios_Marcas] FOREIGN KEY ([IdMarca]) REFERENCES [dbo].[Marcas] ([IdMarca])
);

