CREATE TABLE [dbo].[ClientesDescuentosProductos] (
    [IdCliente]             BIGINT         NOT NULL,
    [IdProducto]            VARCHAR (15)   NOT NULL,
    [DescuentoRecargoPorc1] DECIMAL (5, 2) NOT NULL,
    [DescuentoRecargoPorc2] DECIMAL (5, 2) NOT NULL,
    CONSTRAINT [PK_ClientesDescuentosProductos] PRIMARY KEY CLUSTERED ([IdCliente] ASC, [IdProducto] ASC),
    CONSTRAINT [FK_ClientesDescuentosProductos_Clientes] FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[Clientes] ([IdCliente]),
    CONSTRAINT [FK_ClientesDescuentosProductos_Productos] FOREIGN KEY ([IdProducto]) REFERENCES [dbo].[Productos] ([IdProducto])
);

