CREATE TABLE [dbo].[ProductosLotes] (
    [IdSucursal]       INT             NOT NULL,
    [IdProducto]       VARCHAR (15)    NOT NULL,
    [IdLote]           VARCHAR (10)    NOT NULL,
    [FechaIngreso]     DATETIME        NOT NULL,
    [FechaVencimiento] DATETIME        NOT NULL,
    [CantidadInicial]  DECIMAL (14, 4) NOT NULL,
    [CantidadActual]   DECIMAL (14, 4) NOT NULL,
    [Habilitado]       BIT             NOT NULL,
    CONSTRAINT [PK_ProductosLotes_1] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdProducto] ASC, [IdLote] ASC),
    CONSTRAINT [FK_ProductosLotes_ComprasProductos] FOREIGN KEY ([IdSucursal], [IdProducto], [IdLote]) REFERENCES [dbo].[ProductosLotes] ([IdSucursal], [IdProducto], [IdLote]),
    CONSTRAINT [FK_ProductosLotes_ProductosSucursales] FOREIGN KEY ([IdProducto], [IdSucursal]) REFERENCES [dbo].[ProductosSucursales] ([IdProducto], [IdSucursal])
);

