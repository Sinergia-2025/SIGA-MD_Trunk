CREATE TABLE [dbo].[PedidosProductosProveedores] (
    [IdSucursal]            INT             NOT NULL,
    [IdPedido]              INT             NOT NULL,
    [IdProducto]            VARCHAR (15)    NOT NULL,
    [Cantidad]              DECIMAL (12, 4) NOT NULL,
    [Precio]                DECIMAL (12, 4) NOT NULL,
    [Costo]                 DECIMAL (12, 4) NOT NULL,
    [ImporteTotal]          DECIMAL (12, 4) NOT NULL,
    [NombreProducto]        VARCHAR (60)    NOT NULL,
    [CantEntregada]         DECIMAL (12, 4) NOT NULL,
    [CantEnProceso]         DECIMAL (12, 4) NOT NULL,
    [Orden]                 INT             NOT NULL,
    [DescuentoRecargoPorc]  DECIMAL (6, 2)  NOT NULL,
    [DescuentoRecargoPorc2] DECIMAL (6, 2)  NOT NULL,
    [PrecioNeto]            DECIMAL (12, 4) NOT NULL,
    CONSTRAINT [PK_PedidosProductosProveedores] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdPedido] ASC, [IdProducto] ASC, [Orden] ASC),
    CONSTRAINT [FK_PedidosProductosProveedores_PedidosProveedores] FOREIGN KEY ([IdSucursal], [IdPedido]) REFERENCES [dbo].[PedidosProveedores] ([IdSucursal], [IdPedido]),
    CONSTRAINT [FK_PedidosProductosProveedores_Productos] FOREIGN KEY ([IdProducto]) REFERENCES [dbo].[Productos] ([IdProducto])
);

