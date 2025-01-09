CREATE TABLE [dbo].[RetencionesCompras] (
    [IdSucursal]          INT             NOT NULL,
    [IdTipoImpuesto]      VARCHAR (5)     NOT NULL,
    [EmisorRetencion]     INT             NOT NULL,
    [NumeroRetencion]     BIGINT          NOT NULL,
    [FechaEmision]        DATETIME        NOT NULL,
    [BaseImponible]       DECIMAL (12, 2) NOT NULL,
    [Alicuota]            DECIMAL (6, 2)  NOT NULL,
    [ImporteTotal]        DECIMAL (12, 2) NOT NULL,
    [IdCajaEgreso]        INT             NULL,
    [NroPlanillaEgreso]   INT             NULL,
    [NroMovimientoEgreso] INT             NULL,
    [IdEstado]            VARCHAR (10)    NOT NULL,
    [IdRegimen]           INT             NULL,
    [IdProveedor]         BIGINT          NOT NULL,
    CONSTRAINT [PK_RetencionesCompras] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdTipoImpuesto] ASC, [EmisorRetencion] ASC, [NumeroRetencion] ASC, [IdProveedor] ASC),
    CONSTRAINT [FK_RetencionesCompras_CajasDetalle] FOREIGN KEY ([IdSucursal], [IdCajaEgreso], [NroPlanillaEgreso], [NroMovimientoEgreso]) REFERENCES [dbo].[CajasDetalle] ([IdSucursal], [IdCaja], [NumeroPlanilla], [NumeroMovimiento]),
    CONSTRAINT [FK_RetencionesCompras_Proveedores] FOREIGN KEY ([IdProveedor]) REFERENCES [dbo].[Proveedores] ([IdProveedor]),
    CONSTRAINT [FK_RetencionesCompras_Regimenes] FOREIGN KEY ([IdRegimen]) REFERENCES [dbo].[Regimenes] ([IdRegimen]),
    CONSTRAINT [FK_RetencionesCompras_Sucursales] FOREIGN KEY ([IdSucursal]) REFERENCES [dbo].[Sucursales] ([IdSucursal]),
    CONSTRAINT [FK_RetencionesCompras_TiposImpuestos] FOREIGN KEY ([IdTipoImpuesto]) REFERENCES [dbo].[TiposImpuestos] ([IdTipoImpuesto])
);

