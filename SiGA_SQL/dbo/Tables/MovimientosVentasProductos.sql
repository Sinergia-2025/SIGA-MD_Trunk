CREATE TABLE [dbo].[MovimientosVentasProductos] (
    [IdSucursal]       INT             NOT NULL,
    [IdTipoMovimiento] VARCHAR (15)    NOT NULL,
    [NumeroMovimiento] BIGINT          NOT NULL,
    [IdProducto]       VARCHAR (15)    NOT NULL,
    [Cantidad]         DECIMAL (14, 4) NOT NULL,
    [Precio]           DECIMAL (14, 4) NOT NULL,
    [IdLote]           VARCHAR (10)    NULL,
    [Orden]            INT             NOT NULL,
    CONSTRAINT [PK_MovimientosVentasProductos] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdTipoMovimiento] ASC, [NumeroMovimiento] ASC, [Orden] ASC, [IdProducto] ASC),
    CONSTRAINT [FK_MovimientosVentasProductos_MovimientosVentas] FOREIGN KEY ([IdSucursal], [IdTipoMovimiento], [NumeroMovimiento]) REFERENCES [dbo].[MovimientosVentas] ([IdSucursal], [IdTipoMovimiento], [NumeroMovimiento]),
    CONSTRAINT [FK_MovimientosVentasProductos_Productos] FOREIGN KEY ([IdProducto]) REFERENCES [dbo].[Productos] ([IdProducto])
);

