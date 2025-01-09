CREATE TABLE [dbo].[CuentasCorrientesRetenciones] (
    [IdSucursal]        INT          NOT NULL,
    [IdTipoComprobante] VARCHAR (15) NOT NULL,
    [Letra]             VARCHAR (1)  NOT NULL,
    [CentroEmisor]      INT          NOT NULL,
    [NumeroComprobante] BIGINT       NOT NULL,
    [IdTipoImpuesto]    VARCHAR (5)  NOT NULL,
    [EmisorRetencion]   INT          NOT NULL,
    [NumeroRetencion]   BIGINT       NOT NULL,
    [IdCliente]         BIGINT       NOT NULL,
    CONSTRAINT [PK_CuentasCorrientesRetenciones] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdTipoComprobante] ASC, [Letra] ASC, [CentroEmisor] ASC, [NumeroComprobante] ASC, [IdTipoImpuesto] ASC, [EmisorRetencion] ASC, [NumeroRetencion] ASC, [IdCliente] ASC),
    CONSTRAINT [FK_CuentasCorrientesRetenciones_Clientes] FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[Clientes] ([IdCliente]),
    CONSTRAINT [FK_CuentasCorrientesRetenciones_CuentasCorrientes] FOREIGN KEY ([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante]) REFERENCES [dbo].[CuentasCorrientes] ([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante])
);

