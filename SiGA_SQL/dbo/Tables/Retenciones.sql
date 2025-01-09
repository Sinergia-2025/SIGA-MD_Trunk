CREATE TABLE [dbo].[Retenciones] (
    [IdSucursal]           INT             NOT NULL,
    [IdTipoImpuesto]       VARCHAR (5)     NOT NULL,
    [EmisorRetencion]      INT             NOT NULL,
    [NumeroRetencion]      BIGINT          NOT NULL,
    [FechaEmision]         DATETIME        NOT NULL,
    [BaseImponible]        DECIMAL (12, 2) NOT NULL,
    [Alicuota]             DECIMAL (6, 2)  NOT NULL,
    [ImporteTotal]         DECIMAL (12, 2) NOT NULL,
    [IdCajaIngreso]        INT             NULL,
    [NroPlanillaIngreso]   INT             NULL,
    [NroMovimientoIngreso] INT             NULL,
    [IdEstado]             VARCHAR (10)    NOT NULL,
    [IdCliente]            BIGINT          NOT NULL,
    CONSTRAINT [PK_Retenciones] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdTipoImpuesto] ASC, [EmisorRetencion] ASC, [NumeroRetencion] ASC, [IdCliente] ASC),
    CONSTRAINT [FK_Retenciones_CajasDetalle] FOREIGN KEY ([IdSucursal], [IdCajaIngreso], [NroPlanillaIngreso], [NroMovimientoIngreso]) REFERENCES [dbo].[CajasDetalle] ([IdSucursal], [IdCaja], [NumeroPlanilla], [NumeroMovimiento]),
    CONSTRAINT [FK_Retenciones_Clientes] FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[Clientes] ([IdCliente]),
    CONSTRAINT [FK_Retenciones_Sucursales] FOREIGN KEY ([IdSucursal]) REFERENCES [dbo].[Sucursales] ([IdSucursal]),
    CONSTRAINT [FK_Retenciones_TiposImpuestos] FOREIGN KEY ([IdTipoImpuesto]) REFERENCES [dbo].[TiposImpuestos] ([IdTipoImpuesto])
);

