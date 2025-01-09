CREATE TABLE [dbo].[CuentasCorrientesProvRetenciones] (
    [IdSucursal]        INT          NOT NULL,
    [IdTipoComprobante] VARCHAR (15) NOT NULL,
    [Letra]             VARCHAR (1)  NOT NULL,
    [CentroEmisor]      INT          NOT NULL,
    [NumeroComprobante] BIGINT       NOT NULL,
    [IdTipoImpuesto]    VARCHAR (5)  NOT NULL,
    [EmisorRetencion]   INT          NOT NULL,
    [NumeroRetencion]   BIGINT       NOT NULL,
    [IdProveedor]       BIGINT       NOT NULL,
    CONSTRAINT [PK_CuentasCorrientesProvRetenciones] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdProveedor] ASC, [IdTipoComprobante] ASC, [Letra] ASC, [CentroEmisor] ASC, [NumeroComprobante] ASC, [IdTipoImpuesto] ASC, [EmisorRetencion] ASC, [NumeroRetencion] ASC),
    CONSTRAINT [FK_CuentasCorrientesProvRetenciones_CuentasCorrientesProv] FOREIGN KEY ([IdSucursal], [IdProveedor], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante]) REFERENCES [dbo].[CuentasCorrientesProv] ([IdSucursal], [IdProveedor], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante]),
    CONSTRAINT [FK_CuentasCorrientesProvRetenciones_Retenciones] FOREIGN KEY ([IdSucursal], [IdTipoImpuesto], [EmisorRetencion], [NumeroRetencion], [IdProveedor]) REFERENCES [dbo].[RetencionesCompras] ([IdSucursal], [IdTipoImpuesto], [EmisorRetencion], [NumeroRetencion], [IdProveedor])
);

