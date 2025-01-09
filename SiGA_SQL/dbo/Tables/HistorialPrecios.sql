CREATE TABLE [dbo].[HistorialPrecios] (
    [IdProducto]     VARCHAR (15)    NOT NULL,
    [IdSucursal]     INT             NOT NULL,
    [IdListaPrecios] INT             NOT NULL,
    [FechaHora]      DATETIME        NOT NULL,
    [PrecioFabrica]  DECIMAL (14, 4) NOT NULL,
    [PrecioCosto]    DECIMAL (14, 4) NOT NULL,
    [PrecioVenta]    DECIMAL (14, 4) NOT NULL,
    [Usuario]        VARCHAR (10)    NOT NULL,
    CONSTRAINT [PK_HistorialPrecios] PRIMARY KEY CLUSTERED ([IdProducto] ASC, [IdSucursal] ASC, [IdListaPrecios] ASC, [FechaHora] ASC),
    CONSTRAINT [FK_HistorialPrecios_Productos] FOREIGN KEY ([IdProducto]) REFERENCES [dbo].[Productos] ([IdProducto]),
    CONSTRAINT [FK_HistorialPrecios_Sucursales] FOREIGN KEY ([IdSucursal]) REFERENCES [dbo].[Sucursales] ([IdSucursal]),
    CONSTRAINT [FK_HistorialPrecios_Usuarios] FOREIGN KEY ([Usuario]) REFERENCES [dbo].[Usuarios] ([Id])
);

