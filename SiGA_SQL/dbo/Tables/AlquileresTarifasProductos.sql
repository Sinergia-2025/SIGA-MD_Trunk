CREATE TABLE [dbo].[AlquileresTarifasProductos] (
    [IdSucursal]     INT             NOT NULL,
    [IdProducto]     VARCHAR (15)    NOT NULL,
    [CantDias]       INT             NOT NULL,
    [PrecioAlquiler] DECIMAL (12, 2) NULL,
    CONSTRAINT [PK_AlquileresTarifasProductos] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdProducto] ASC, [CantDias] ASC),
    CONSTRAINT [FK_AlquileresTarifasProductos_Productos] FOREIGN KEY ([IdProducto]) REFERENCES [dbo].[Productos] ([IdProducto]),
    CONSTRAINT [FK_AlquileresTarifasProductos_Sucursales] FOREIGN KEY ([IdSucursal]) REFERENCES [dbo].[Sucursales] ([IdSucursal])
);

