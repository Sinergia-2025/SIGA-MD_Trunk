CREATE TABLE [dbo].[VentasChequesRechazados] (
    [IdSucursal]        INT          NOT NULL,
    [IdTipoComprobante] VARCHAR (15) NOT NULL,
    [Letra]             VARCHAR (1)  NOT NULL,
    [CentroEmisor]      INT          NOT NULL,
    [NumeroComprobante] BIGINT       NOT NULL,
    [NumeroCheque]      INT          NOT NULL,
    [IdBanco]           INT          NOT NULL,
    [IdBancoSucursal]   INT          NOT NULL,
    [IdLocalidad]       INT          NOT NULL,
    CONSTRAINT [PK_VentasChequesRechazados] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdTipoComprobante] ASC, [Letra] ASC, [CentroEmisor] ASC, [NumeroComprobante] ASC, [NumeroCheque] ASC, [IdBanco] ASC, [IdBancoSucursal] ASC, [IdLocalidad] ASC),
    CONSTRAINT [FK_VentasChequesRechazados_Cheques] FOREIGN KEY ([IdSucursal], [NumeroCheque], [IdBanco], [IdBancoSucursal], [IdLocalidad]) REFERENCES [dbo].[Cheques] ([IdSucursal], [NumeroCheque], [IdBanco], [IdBancoSucursal], [IdLocalidad]),
    CONSTRAINT [FK_VentasChequesRechazados_TiposComprobantes] FOREIGN KEY ([IdTipoComprobante]) REFERENCES [dbo].[TiposComprobantes] ([IdTipoComprobante]),
    CONSTRAINT [FK_VentasChequesRechazados_Ventas] FOREIGN KEY ([IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdSucursal]) REFERENCES [dbo].[Ventas] ([IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdSucursal])
);

