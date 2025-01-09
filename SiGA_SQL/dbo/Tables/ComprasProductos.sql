CREATE TABLE [dbo].[ComprasProductos] (
    [IdSucursal]               INT             NOT NULL,
    [IdTipoComprobante]        VARCHAR (15)    NOT NULL,
    [Letra]                    VARCHAR (1)     NOT NULL,
    [CentroEmisor]             INT             NOT NULL,
    [NumeroComprobante]        BIGINT          NOT NULL,
    [IdProducto]               VARCHAR (15)    NOT NULL,
    [Cantidad]                 DECIMAL (14, 4) NOT NULL,
    [Precio]                   DECIMAL (14, 4) NOT NULL,
    [DescRecGeneral]           DECIMAL (14, 4) NOT NULL,
    [DescuentoRecargo]         DECIMAL (14, 4) NOT NULL,
    [ImporteTotal]             DECIMAL (14, 4) NOT NULL,
    [DescuentoRecargoProducto] DECIMAL (14, 4) NOT NULL,
    [DescuentoRecargoPorc]     DECIMAL (6, 2)  NULL,
    [DescRecGeneralProducto]   DECIMAL (14, 4) NOT NULL,
    [PrecioNeto]               DECIMAL (14, 4) NOT NULL,
    [ImporteTotalNeto]         DECIMAL (14, 4) NOT NULL,
    [PorcentajeIVA]            DECIMAL (12, 2) NULL,
    [IVA]                      DECIMAL (12, 2) NOT NULL,
    [Orden]                    INT             NOT NULL,
    [NombreProducto]           VARCHAR (60)    NOT NULL,
    [IdProveedor]              BIGINT          NOT NULL,
    [IdConcepto]               INT             NULL,
    [PasajeMovimiento]         BIT             NOT NULL,
    [MontoAplicado]            DECIMAL (14, 4) NOT NULL,
    [MontoSaldo]               DECIMAL (14, 4) NOT NULL,
    [ProporcionalImp]          DECIMAL (14, 4) NOT NULL,
    CONSTRAINT [PK_ComprasProductos] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdTipoComprobante] ASC, [Letra] ASC, [CentroEmisor] ASC, [NumeroComprobante] ASC, [IdProveedor] ASC, [Orden] ASC, [IdProducto] ASC),
    CONSTRAINT [FK_ComprasProductos_Compras] FOREIGN KEY ([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdProveedor]) REFERENCES [dbo].[Compras] ([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdProveedor]),
    CONSTRAINT [FK_ComprasProductos_Conceptos] FOREIGN KEY ([IdConcepto]) REFERENCES [dbo].[Conceptos] ([IdConcepto]),
    CONSTRAINT [FK_ComprasProductos_Productos] FOREIGN KEY ([IdProducto]) REFERENCES [dbo].[Productos] ([IdProducto])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Descuento Recargo de la Factura general', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ComprasProductos', @level2type = N'COLUMN', @level2name = N'DescRecGeneralProducto';

