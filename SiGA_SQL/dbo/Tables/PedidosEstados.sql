CREATE TABLE [dbo].[PedidosEstados] (
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
    [IdCriticidad]      VARCHAR (10)    NOT NULL,
    [FechaEntrega]      DATE            NOT NULL,
    CONSTRAINT [PK_PedidosEstados] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdPedido] ASC, [IdProducto] ASC, [FechaEstado] ASC, [Orden] ASC),
    CONSTRAINT [FK_PedidosEstados_EstadosPedidos] FOREIGN KEY ([IdEstado]) REFERENCES [dbo].[EstadosPedidos] ([idEstado]),
    CONSTRAINT [FK_PedidosEstados_PedidosCriticidades] FOREIGN KEY ([IdCriticidad]) REFERENCES [dbo].[PedidosCriticidades] ([IdCriticidad]),
    CONSTRAINT [FK_PedidosEstados_PedidosProductos] FOREIGN KEY ([IdSucursal], [IdPedido], [IdProducto], [Orden]) REFERENCES [dbo].[PedidosProductos] ([IdSucursal], [IdPedido], [IdProducto], [Orden]),
    CONSTRAINT [FK_PedidosEstados_Usuarios] FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[Usuarios] ([Id]),
    CONSTRAINT [FK_PedidosEstados_Ventas] FOREIGN KEY ([IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdSucursal]) REFERENCES [dbo].[Ventas] ([IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdSucursal])
);

