CREATE TABLE [dbo].[MovimientosComprasProductos] (
    [IdSucursal]       INT             NOT NULL,
    [IdTipoMovimiento] VARCHAR (15)    NOT NULL,
    [NumeroMovimiento] BIGINT          NOT NULL,
    [IdProducto]       VARCHAR (15)    NOT NULL,
    [Cantidad]         DECIMAL (12, 2) NOT NULL,
    [Precio]           DECIMAL (12, 2) NOT NULL,
    [IdLote]           VARCHAR (10)    NULL,
    [Orden]            INT             NOT NULL,
    CONSTRAINT [PK_MovimientosComprasProductos] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdTipoMovimiento] ASC, [NumeroMovimiento] ASC, [Orden] ASC, [IdProducto] ASC),
    CONSTRAINT [FK_MovimientosComprasProductos_MovimientosCompras] FOREIGN KEY ([IdSucursal], [IdTipoMovimiento], [NumeroMovimiento]) REFERENCES [dbo].[MovimientosCompras] ([IdSucursal], [IdTipoMovimiento], [NumeroMovimiento]),
    CONSTRAINT [FK_MovimientosComprasProductos_Productos] FOREIGN KEY ([IdProducto]) REFERENCES [dbo].[Productos] ([IdProducto])
);

