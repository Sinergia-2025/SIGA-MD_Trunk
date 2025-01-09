CREATE TABLE [dbo].[HistorialConsultaProductos] (
    [IdSucursal] INT          NOT NULL,
    [IdProducto] VARCHAR (15) NOT NULL,
    [FechaHora]  DATETIME     NOT NULL,
    [Usuario]    VARCHAR (10) NOT NULL,
    CONSTRAINT [PK_HistorialConsultaProductos] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdProducto] ASC, [FechaHora] ASC),
    CONSTRAINT [FK_HistorialConsultaProductos_ProductosSucursales] FOREIGN KEY ([IdProducto], [IdSucursal]) REFERENCES [dbo].[ProductosSucursales] ([IdProducto], [IdSucursal]),
    CONSTRAINT [FK_HistorialConsultaProductos_Usuarios] FOREIGN KEY ([Usuario]) REFERENCES [dbo].[Usuarios] ([Id])
);

