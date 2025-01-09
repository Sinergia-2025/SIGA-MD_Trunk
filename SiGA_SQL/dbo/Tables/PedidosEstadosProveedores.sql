CREATE TABLE [dbo].[PedidosEstadosProveedores] (
    [IdSucursal]        INT             NOT NULL,
    [IdPedido]          INT             NOT NULL,
    [IdProducto]        VARCHAR (15)    NOT NULL,
    [FechaEstado]       DATETIME        NOT NULL,
    [IdEstado]          VARCHAR (10)    NOT NULL,
    [IdUsuario]         VARCHAR (10)    NOT NULL,
    [CantEntregada]     DECIMAL (12, 2) NOT NULL,
    [Observacion]       VARCHAR (100)   NOT NULL,
    [IdTipoComprobante] VARCHAR (15)    NULL,
    [Letra]             VARCHAR (1)     NULL,
    [CentroEmisor]      INT             NULL,
    [NumeroComprobante] BIGINT          NULL,
    [Orden]             INT             NOT NULL,
    [IdProveedor]       BIGINT          NULL,
    CONSTRAINT [PK_PedidosEstadosProveedores] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdPedido] ASC, [IdProducto] ASC, [FechaEstado] ASC, [Orden] ASC),
    CONSTRAINT [FK_PedidosEstadosProveedores_Compras] FOREIGN KEY ([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdProveedor]) REFERENCES [dbo].[Compras] ([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdProveedor]),
    CONSTRAINT [FK_PedidosEstadosProveedores_EstadosPedidosProveedores] FOREIGN KEY ([IdEstado]) REFERENCES [dbo].[EstadosPedidosProveedores] ([idEstado]),
    CONSTRAINT [FK_PedidosEstadosProveedores_PedidosProductosProveedores] FOREIGN KEY ([IdSucursal], [IdPedido], [IdProducto], [Orden]) REFERENCES [dbo].[PedidosProductosProveedores] ([IdSucursal], [IdPedido], [IdProducto], [Orden]),
    CONSTRAINT [FK_PedidosEstadosProveedores_Proveedores] FOREIGN KEY ([IdProveedor]) REFERENCES [dbo].[Proveedores] ([IdProveedor]),
    CONSTRAINT [FK_PedidosEstadosProveedores_Usuarios] FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[Usuarios] ([Id])
);

