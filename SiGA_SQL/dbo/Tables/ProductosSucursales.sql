CREATE TABLE [dbo].[ProductosSucursales] (
    [IdProducto]         VARCHAR (15)    NOT NULL,
    [IdSucursal]         INT             NOT NULL,
    [PrecioFabrica]      DECIMAL (14, 4) NOT NULL,
    [PrecioCosto]        DECIMAL (14, 4) NOT NULL,
    [PrecioVenta]        DECIMAL (14, 4) NOT NULL,
    [Usuario]            VARCHAR (10)    NOT NULL,
    [FechaActualizacion] DATETIME        NOT NULL,
    [Stock]              DECIMAL (14, 4) NOT NULL,
    [StockInicial]       DECIMAL (14, 4) NOT NULL,
    [PuntoDePedido]      DECIMAL (14, 4) NOT NULL,
    [StockMinimo]        DECIMAL (14, 4) NOT NULL,
    [StockMaximo]        DECIMAL (14, 4) NOT NULL,
    CONSTRAINT [PK_ProductosSucursales] PRIMARY KEY CLUSTERED ([IdProducto] ASC, [IdSucursal] ASC),
    CONSTRAINT [FK_ProductosSucursales_Productos] FOREIGN KEY ([IdProducto]) REFERENCES [dbo].[Productos] ([IdProducto]),
    CONSTRAINT [FK_ProductosSucursales_Sucursales] FOREIGN KEY ([IdSucursal]) REFERENCES [dbo].[Sucursales] ([IdSucursal]),
    CONSTRAINT [FK_ProductosSucursales_Usuarios] FOREIGN KEY ([Usuario]) REFERENCES [dbo].[Usuarios] ([Id])
);

