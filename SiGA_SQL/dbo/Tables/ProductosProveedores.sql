CREATE TABLE [dbo].[ProductosProveedores] (
    [IdProducto]              VARCHAR (15)    NOT NULL,
    [CodigoProductoProveedor] VARCHAR (20)    NULL,
    [UltimoPrecioCompra]      DECIMAL (14, 4) NULL,
    [UltimaFechaCompra]       DATETIME        NULL,
    [IdProveedor]             BIGINT          NOT NULL,
    [UltimoPrecioFabrica]     DECIMAL (14, 4) DEFAULT ((0)) NOT NULL,
    [DescuentoRecargoPorc1]   DECIMAL (5, 2)  DEFAULT ((0)) NOT NULL,
    [DescuentoRecargoPorc2]   DECIMAL (5, 2)  DEFAULT ((0)) NOT NULL,
    [DescuentoRecargoPorc3]   DECIMAL (5, 2)  DEFAULT ((0)) NOT NULL,
    [DescuentoRecargoPorc4]   DECIMAL (5, 2)  DEFAULT ((0)) NOT NULL,
    [DescuentoRecargoPorc5]   DECIMAL (5, 2)  DEFAULT ((0)) NOT NULL,
    [DescuentoRecargoPorc6]   DECIMAL (5, 2)  DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_ProductosProveedores] PRIMARY KEY CLUSTERED ([IdProveedor] ASC, [IdProducto] ASC),
    CONSTRAINT [FK_ProductosProveedores_Productos] FOREIGN KEY ([IdProducto]) REFERENCES [dbo].[Productos] ([IdProducto]),
    CONSTRAINT [FK_ProductosProveedores_Proveedores] FOREIGN KEY ([IdProveedor]) REFERENCES [dbo].[Proveedores] ([IdProveedor])
);

