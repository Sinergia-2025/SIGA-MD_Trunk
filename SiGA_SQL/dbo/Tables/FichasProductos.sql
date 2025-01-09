CREATE TABLE [dbo].[FichasProductos] (
    [NroOperacion] INT             NOT NULL,
    [IdProducto]   VARCHAR (15)    NOT NULL,
    [Cantidad]     INT             NULL,
    [Precio]       DECIMAL (10, 2) NULL,
    [FechaEntrega] DATETIME        NULL,
    [Garantia]     INT             NULL,
    [IdSucursal]   INT             NOT NULL,
    [IdCliente]    BIGINT          NOT NULL,
    [IdProveedor]  BIGINT          NULL,
    CONSTRAINT [PK_FichasProductos] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdCliente] ASC, [NroOperacion] ASC, [IdProducto] ASC),
    CONSTRAINT [FK_FichasProductos_Proveedores] FOREIGN KEY ([IdProveedor]) REFERENCES [dbo].[Proveedores] ([IdProveedor])
);

