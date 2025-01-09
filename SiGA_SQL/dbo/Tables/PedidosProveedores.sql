CREATE TABLE [dbo].[PedidosProveedores] (
    [IdSucursal]  INT           NOT NULL,
    [IdPedido]    INT           NOT NULL,
    [FechaPedido] DATE          NOT NULL,
    [IdPeriodo]   INT           NOT NULL,
    [Observacion] VARCHAR (100) NOT NULL,
    [IdUsuario]   VARCHAR (10)  NOT NULL,
    [IdProveedor] BIGINT        NOT NULL,
    CONSTRAINT [PK_PedidosProveedores] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdPedido] ASC),
    CONSTRAINT [FK_PedidosProveedores_Proveedores] FOREIGN KEY ([IdProveedor]) REFERENCES [dbo].[Proveedores] ([IdProveedor]),
    CONSTRAINT [FK_PedidosProveedores_Sucursales] FOREIGN KEY ([IdSucursal]) REFERENCES [dbo].[Sucursales] ([IdSucursal]),
    CONSTRAINT [FK_PedidosProveedores_Usuarios] FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[Usuarios] ([Id])
);

