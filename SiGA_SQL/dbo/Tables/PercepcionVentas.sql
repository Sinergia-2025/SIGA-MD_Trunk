CREATE TABLE [dbo].[PercepcionVentas] (
    [IdSucursal]           INT             NOT NULL,
    [IdTipoImpuesto]       VARCHAR (5)     NOT NULL,
    [EmisorPercepcion]     INT             NOT NULL,
    [NumeroPercepcion]     BIGINT          NOT NULL,
    [FechaEmision]         DATETIME        NOT NULL,
    [BaseImponible]        DECIMAL (14, 4) NOT NULL,
    [Alicuota]             DECIMAL (6, 2)  NOT NULL,
    [ImporteTotal]         DECIMAL (14, 4) NOT NULL,
    [IdCajaIngreso]        INT             NULL,
    [NroPlanillaIngreso]   INT             NULL,
    [NroMovimientoIngreso] INT             NULL,
    [IdEstado]             VARCHAR (10)    NOT NULL,
    [IdActividad]          INT             NOT NULL,
    [IdProvincia]          CHAR (2)        NOT NULL,
    [IdCliente]            BIGINT          NOT NULL,
    CONSTRAINT [PK_PercepcionVentas] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdTipoImpuesto] ASC, [EmisorPercepcion] ASC, [NumeroPercepcion] ASC),
    CONSTRAINT [FK_PercepcionVentas_CajasDetalle] FOREIGN KEY ([IdSucursal], [IdCajaIngreso], [NroPlanillaIngreso], [NroMovimientoIngreso]) REFERENCES [dbo].[CajasDetalle] ([IdSucursal], [IdCaja], [NumeroPlanilla], [NumeroMovimiento]),
    CONSTRAINT [FK_PercepcionVentas_Clientes] FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[Clientes] ([IdCliente]),
    CONSTRAINT [FK_PercepcionVentas_Sucursales] FOREIGN KEY ([IdSucursal]) REFERENCES [dbo].[Sucursales] ([IdSucursal]),
    CONSTRAINT [FK_PercepcionVentas_TiposImpuestos] FOREIGN KEY ([IdTipoImpuesto]) REFERENCES [dbo].[TiposImpuestos] ([IdTipoImpuesto])
);

