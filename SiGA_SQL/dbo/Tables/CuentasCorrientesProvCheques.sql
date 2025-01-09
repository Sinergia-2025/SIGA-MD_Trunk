CREATE TABLE [dbo].[CuentasCorrientesProvCheques] (
    [IdSucursal]        INT          NOT NULL,
    [IdTipoComprobante] VARCHAR (15) NOT NULL,
    [Letra]             VARCHAR (1)  NOT NULL,
    [CentroEmisor]      INT          NOT NULL,
    [NumeroComprobante] BIGINT       NOT NULL,
    [NumeroCheque]      INT          NOT NULL,
    [IdBanco]           INT          NOT NULL,
    [IdBancoSucursal]   INT          NOT NULL,
    [IdLocalidad]       INT          NOT NULL,
    [IdProveedor]       BIGINT       NOT NULL,
    CONSTRAINT [PK_CuentasCorrientesProvCheques] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdProveedor] ASC, [IdTipoComprobante] ASC, [Letra] ASC, [CentroEmisor] ASC, [NumeroComprobante] ASC, [NumeroCheque] ASC, [IdBanco] ASC, [IdBancoSucursal] ASC, [IdLocalidad] ASC),
    CONSTRAINT [FK_CuentasCorrientesProvCheques_Cheques] FOREIGN KEY ([IdSucursal], [NumeroCheque], [IdBanco], [IdBancoSucursal], [IdLocalidad]) REFERENCES [dbo].[Cheques] ([IdSucursal], [NumeroCheque], [IdBanco], [IdBancoSucursal], [IdLocalidad]),
    CONSTRAINT [FK_CuentasCorrientesProvCheques_CuentasCorrientesProv] FOREIGN KEY ([IdSucursal], [IdProveedor], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante]) REFERENCES [dbo].[CuentasCorrientesProv] ([IdSucursal], [IdProveedor], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante])
);

