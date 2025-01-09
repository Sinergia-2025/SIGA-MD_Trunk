CREATE TABLE [dbo].[ProduccionProductosComponentes] (
    [IdSucursal]           INT             NOT NULL,
    [IdProduccion]         INT             NOT NULL,
    [Orden]                INT             NOT NULL,
    [IdProducto]           VARCHAR (15)    NOT NULL,
    [IdProductoComponente] VARCHAR (15)    NOT NULL,
    [Cantidad]             DECIMAL (14, 4) NOT NULL,
    [PrecioCosto]          DECIMAL (14, 4) NOT NULL,
    [PrecioVenta]          DECIMAL (14, 4) NOT NULL,
    [IdMoneda]             INT             NULL,
    CONSTRAINT [PK_ProduccionProductosComponentes] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdProduccion] ASC, [Orden] ASC, [IdProducto] ASC, [IdProductoComponente] ASC),
    CONSTRAINT [FK_ProduccionProductosComponentes_Monedas] FOREIGN KEY ([IdMoneda]) REFERENCES [dbo].[Monedas] ([IdMoneda]),
    CONSTRAINT [FK_ProduccionProductosComponentes_ProduccionProductos] FOREIGN KEY ([IdSucursal], [IdProduccion], [Orden], [IdProducto]) REFERENCES [dbo].[ProduccionProductos] ([IdSucursal], [IdProduccion], [Orden], [IdProducto])
);

