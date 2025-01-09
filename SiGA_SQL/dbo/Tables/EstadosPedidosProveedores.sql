CREATE TABLE [dbo].[EstadosPedidosProveedores] (
    [idEstado]          VARCHAR (10) NOT NULL,
    [IdTipoComprobante] VARCHAR (15) NULL,
    [IdTipoEstado]      VARCHAR (10) NOT NULL,
    [Orden]             INT          NOT NULL,
    CONSTRAINT [PK_EstadosPedidosProveedores] PRIMARY KEY CLUSTERED ([idEstado] ASC),
    CONSTRAINT [FK_EstadosPedidosProveedores_TiposComprobantes] FOREIGN KEY ([IdTipoComprobante]) REFERENCES [dbo].[TiposComprobantes] ([IdTipoComprobante])
);

