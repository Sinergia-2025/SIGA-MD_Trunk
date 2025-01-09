CREATE TABLE [dbo].[PedidosProductos] (
    [IdSucursal]               INT             NOT NULL,
    [IdPedido]                 INT             NOT NULL,
    [IdProducto]               VARCHAR (15)    NOT NULL,
    [Cantidad]                 DECIMAL (12, 4) NOT NULL,
    [Precio]                   DECIMAL (12, 4) NOT NULL,
    [Costo]                    DECIMAL (12, 4) NOT NULL,
    [ImporteTotal]             DECIMAL (12, 4) NOT NULL,
    [NombreProducto]           VARCHAR (60)    NOT NULL,
    [CantEntregada]            DECIMAL (12, 4) NOT NULL,
    [CantEnProceso]            DECIMAL (12, 4) NOT NULL,
    [Orden]                    INT             NOT NULL,
    [DescuentoRecargoProducto] DECIMAL (14, 4) NOT NULL,
    [DescuentoRecargoPorc2]    DECIMAL (6, 2)  NOT NULL,
    [DescuentoRecargoPorc]     DECIMAL (6, 2)  NOT NULL,
    [IdTipoImpuesto]           VARCHAR (5)     NOT NULL,
    [AlicuotaImpuesto]         DECIMAL (6, 2)  NOT NULL,
    [ImporteImpuesto]          DECIMAL (14, 4) NOT NULL,
    [PrecioLista]              DECIMAL (12, 4) NOT NULL,
    CONSTRAINT [PK_PedidosProductos] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdPedido] ASC, [IdProducto] ASC, [Orden] ASC),
    CONSTRAINT [FK_PedidosProductos_Pedidos] FOREIGN KEY ([IdSucursal], [IdPedido]) REFERENCES [dbo].[Pedidos] ([IdSucursal], [IdPedido]),
    CONSTRAINT [FK_PedidosProductos_Productos] FOREIGN KEY ([IdProducto]) REFERENCES [dbo].[Productos] ([IdProducto])
);

