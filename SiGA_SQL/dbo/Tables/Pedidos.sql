CREATE TABLE [dbo].[Pedidos] (
    [IdSucursal]           INT             NOT NULL,
    [IdPedido]             INT             NOT NULL,
    [FechaPedido]          DATETIME        NOT NULL,
    [IdPeriodo]            INT             NOT NULL,
    [Observacion]          VARCHAR (100)   NOT NULL,
    [IdUsuario]            VARCHAR (10)    NOT NULL,
    [DescuentoRecargo]     DECIMAL (14, 4) NOT NULL,
    [DescuentoRecargoPorc] DECIMAL (6, 2)  NOT NULL,
    [IdCliente]            BIGINT          NOT NULL,
    CONSTRAINT [PK_Pedidos] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdPedido] ASC),
    CONSTRAINT [FK_Pedidos_Clientes] FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[Clientes] ([IdCliente]),
    CONSTRAINT [FK_Pedidos_Sucursales] FOREIGN KEY ([IdSucursal]) REFERENCES [dbo].[Sucursales] ([IdSucursal]),
    CONSTRAINT [FK_Pedidos_Usuarios] FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[Usuarios] ([Id])
);

