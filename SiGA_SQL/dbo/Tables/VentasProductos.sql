CREATE TABLE [dbo].[VentasProductos] (
    [IdSucursal]               INT             NOT NULL,
    [IdTipoComprobante]        VARCHAR (15)    NOT NULL,
    [Letra]                    VARCHAR (1)     NOT NULL,
    [CentroEmisor]             INT             NOT NULL,
    [NumeroComprobante]        BIGINT          NOT NULL,
    [IdProducto]               VARCHAR (15)    NOT NULL,
    [Cantidad]                 DECIMAL (14, 4) NOT NULL,
    [Precio]                   DECIMAL (14, 4) NOT NULL,
    [Costo]                    DECIMAL (14, 4) NOT NULL,
    [DescRecGeneral]           DECIMAL (14, 4) NOT NULL,
    [DescuentoRecargo]         DECIMAL (14, 4) NOT NULL,
    [PrecioLista]              DECIMAL (14, 4) NOT NULL,
    [Utilidad]                 DECIMAL (14, 4) NOT NULL,
    [ImporteTotal]             DECIMAL (14, 4) NOT NULL,
    [DescuentoRecargoProducto] DECIMAL (14, 4) NOT NULL,
    [DescuentoRecargoPorc]     DECIMAL (6, 2)  NOT NULL,
    [DescRecGeneralProducto]   DECIMAL (14, 4) NOT NULL,
    [PrecioNeto]               DECIMAL (14, 4) NOT NULL,
    [ImporteTotalNeto]         DECIMAL (14, 4) NOT NULL,
    [Kilos]                    DECIMAL (10, 3) NOT NULL,
    [DescuentoRecargoPorc2]    DECIMAL (6, 2)  NOT NULL,
    [NombreProducto]           VARCHAR (60)    NOT NULL,
    [IdTipoImpuesto]           VARCHAR (5)     NOT NULL,
    [AlicuotaImpuesto]         DECIMAL (6, 2)  NOT NULL,
    [ImporteImpuesto]          DECIMAL (12, 2) NOT NULL,
    [Orden]                    INT             NOT NULL,
    [ComisionVendedorPorc]     DECIMAL (5, 2)  NOT NULL,
    [ComisionVendedor]         DECIMAL (14, 4) NOT NULL,
    [IdListaPrecios]           INT             NOT NULL,
    [NombreListaPrecios]       VARCHAR (50)    NOT NULL,
    CONSTRAINT [PK_VentasProductos] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdTipoComprobante] ASC, [Letra] ASC, [CentroEmisor] ASC, [NumeroComprobante] ASC, [Orden] ASC, [IdProducto] ASC),
    CONSTRAINT [FK_Ventas_Productos] FOREIGN KEY ([IdProducto]) REFERENCES [dbo].[Productos] ([IdProducto]),
    CONSTRAINT [FK_VentasProductos_Impuestos] FOREIGN KEY ([IdTipoImpuesto], [AlicuotaImpuesto]) REFERENCES [dbo].[Impuestos] ([IdTipoImpuesto], [Alicuota]),
    CONSTRAINT [FK_VentasProductos_Ventas] FOREIGN KEY ([IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdSucursal]) REFERENCES [dbo].[Ventas] ([IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdSucursal])
);




GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Descuento Recargo de la Factura general', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'VentasProductos', @level2type = N'COLUMN', @level2name = N'DescRecGeneral';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Descuento Recargo de la Factura general', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'VentasProductos', @level2type = N'COLUMN', @level2name = N'DescRecGeneralProducto';

