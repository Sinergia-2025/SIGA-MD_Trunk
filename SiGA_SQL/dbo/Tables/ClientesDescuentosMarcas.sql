CREATE TABLE [dbo].[ClientesDescuentosMarcas] (
    [IdMarca]               INT            NOT NULL,
    [DescuentoRecargoPorc1] DECIMAL (5, 2) NOT NULL,
    [DescuentoRecargoPorc2] DECIMAL (5, 2) NOT NULL,
    [IdCliente]             BIGINT         NOT NULL,
    CONSTRAINT [PK_ClientesDescuentosMarcas] PRIMARY KEY CLUSTERED ([IdCliente] ASC, [IdMarca] ASC),
    CONSTRAINT [FK_ClientesDescuentosMarcas_Clientes] FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[Clientes] ([IdCliente]),
    CONSTRAINT [FK_ClientesDescuentosMarcas_Marcas] FOREIGN KEY ([IdMarca]) REFERENCES [dbo].[Marcas] ([IdMarca])
);

