CREATE TABLE [dbo].[ProductosNrosSerie] (
    [IdProducto]              VARCHAR (15) NOT NULL,
    [NroSerie]                VARCHAR (50) NOT NULL,
    [IdSucursal]              INT          NOT NULL,
    [Vendido]                 BIT          NOT NULL,
    [IdTipoCompCompra]        VARCHAR (15) NULL,
    [LetraCompra]             VARCHAR (1)  NULL,
    [CentroEmisorCompra]      INT          NULL,
    [NumeroComprobanteCompra] BIGINT       NULL,
    [IdSucursalVenta]         INT          NULL,
    [IdTipoCompVenta]         VARCHAR (15) NULL,
    [LetraVenta]              VARCHAR (1)  NULL,
    [CentroEmisorVenta]       INT          NULL,
    [NumeroComprobanteVenta]  BIGINT       NULL,
    [IdProveedor]             BIGINT       NULL,
    CONSTRAINT [PK_ProductosNrosSerie] PRIMARY KEY CLUSTERED ([IdProducto] ASC, [NroSerie] ASC),
    CONSTRAINT [FK_ProductosNrosSerie_Productos] FOREIGN KEY ([IdProducto]) REFERENCES [dbo].[Productos] ([IdProducto]),
    CONSTRAINT [FK_ProductosNrosSerie_Proveedores] FOREIGN KEY ([IdProveedor]) REFERENCES [dbo].[Proveedores] ([IdProveedor]),
    CONSTRAINT [FK_ProductosNrosSerie_Sucursales] FOREIGN KEY ([IdSucursal]) REFERENCES [dbo].[Sucursales] ([IdSucursal])
);

