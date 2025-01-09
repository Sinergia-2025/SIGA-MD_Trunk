CREATE TABLE [dbo].[ProductosSucursalesPrecios] (
    [IdProducto]         VARCHAR (15)    NOT NULL,
    [IdSucursal]         INT             NOT NULL,
    [IdListaPrecios]     INT             NOT NULL,
    [PrecioVenta]        DECIMAL (14, 4) NOT NULL,
    [FechaActualizacion] DATETIME        NOT NULL,
    [Usuario]            VARCHAR (10)    NOT NULL,
    CONSTRAINT [PK_ProductosSucursalesPrecios] PRIMARY KEY CLUSTERED ([IdProducto] ASC, [IdSucursal] ASC, [IdListaPrecios] ASC),
    CONSTRAINT [FK_ProductosSucursalesPrecios_ListasDePrecios] FOREIGN KEY ([IdListaPrecios]) REFERENCES [dbo].[ListasDePrecios] ([IdListaPrecios]),
    CONSTRAINT [FK_ProductosSucursalesPrecios_ProductosSucursales] FOREIGN KEY ([IdProducto], [IdSucursal]) REFERENCES [dbo].[ProductosSucursales] ([IdProducto], [IdSucursal]),
    CONSTRAINT [FK_ProductosSucursalesPrecios_Usuarios] FOREIGN KEY ([Usuario]) REFERENCES [dbo].[Usuarios] ([Id])
);

