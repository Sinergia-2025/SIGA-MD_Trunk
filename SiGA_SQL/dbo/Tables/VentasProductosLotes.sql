CREATE TABLE [dbo].[VentasProductosLotes] (
    [IdSucursal]        INT             NOT NULL,
    [IdTipoComprobante] VARCHAR (15)    NOT NULL,
    [Letra]             VARCHAR (1)     NOT NULL,
    [CentroEmisor]      INT             NOT NULL,
    [NumeroComprobante] BIGINT          NOT NULL,
    [Orden]             INT             NOT NULL,
    [IdProducto]        VARCHAR (15)    NOT NULL,
    [IdLote]            VARCHAR (10)    NOT NULL,
    [FechaVencimiento]  DATETIME        NOT NULL,
    [Cantidad]          DECIMAL (14, 4) NOT NULL,
    CONSTRAINT [PK_VentasProductosLotes] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdTipoComprobante] ASC, [Letra] ASC, [CentroEmisor] ASC, [NumeroComprobante] ASC, [Orden] ASC, [IdProducto] ASC, [IdLote] ASC),
    CONSTRAINT [FK_VentasProductosLotes_Productos] FOREIGN KEY ([IdProducto]) REFERENCES [dbo].[Productos] ([IdProducto]),
    CONSTRAINT [FK_VentasProductosLotes_ProductosLotes] FOREIGN KEY ([IdSucursal], [IdProducto], [IdLote]) REFERENCES [dbo].[ProductosLotes] ([IdSucursal], [IdProducto], [IdLote]),
    CONSTRAINT [FK_VentasProductosLotes_VentasProductos] FOREIGN KEY ([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [Orden], [IdProducto]) REFERENCES [dbo].[VentasProductos] ([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [Orden], [IdProducto])
);

