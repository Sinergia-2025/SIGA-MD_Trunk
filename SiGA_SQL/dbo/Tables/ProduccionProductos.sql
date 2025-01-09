CREATE TABLE [dbo].[ProduccionProductos] (
    [IdSucursal]        INT             NOT NULL,
    [IdProduccion]      INT             NOT NULL,
    [Orden]             INT             NOT NULL,
    [IdProducto]        VARCHAR (15)    NOT NULL,
    [CantidadProducida] DECIMAL (14, 4) NOT NULL,
    [IdLote]            VARCHAR (10)    NULL,
    [FechaVencimiento]  DATETIME        NULL,
    [IdFormula]         INT             NOT NULL,
    CONSTRAINT [PK_ProduccionProductos] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdProduccion] ASC, [Orden] ASC, [IdProducto] ASC),
    CONSTRAINT [FK_ProduccionProductos_Produccion] FOREIGN KEY ([IdSucursal], [IdProduccion]) REFERENCES [dbo].[Produccion] ([IdSucursal], [IdProduccion]),
    CONSTRAINT [FK_ProduccionProductos_Productos] FOREIGN KEY ([IdProducto]) REFERENCES [dbo].[Productos] ([IdProducto]),
    CONSTRAINT [FK_ProduccionProductos_ProductosLotes] FOREIGN KEY ([IdSucursal], [IdProducto], [IdLote]) REFERENCES [dbo].[ProductosLotes] ([IdSucursal], [IdProducto], [IdLote]),
    CONSTRAINT [FK_ProduccionProductos_ProductosSucursales] FOREIGN KEY ([IdSucursal], [IdProduccion]) REFERENCES [dbo].[Produccion] ([IdSucursal], [IdProduccion])
);

