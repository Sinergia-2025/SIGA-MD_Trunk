CREATE TABLE [dbo].[CuentasCorrientesCheques] (
    [NumeroCheque]          INT          NOT NULL,
    [IdBancoCheque]         INT          NOT NULL,
    [IdSucursal]            INT          NOT NULL,
    [IdTipoComprobante]     VARCHAR (15) NOT NULL,
    [Letra]                 VARCHAR (1)  NOT NULL,
    [CentroEmisor]          INT          NOT NULL,
    [NumeroComprobante]     BIGINT       NOT NULL,
    [IdLocalidadCheque]     INT          NOT NULL,
    [IdBancoSucursalCheque] INT          NOT NULL,
    CONSTRAINT [PK_CuentasCorrientesCheques] PRIMARY KEY CLUSTERED ([NumeroCheque] ASC, [IdBancoCheque] ASC, [IdSucursal] ASC, [IdTipoComprobante] ASC, [Letra] ASC, [CentroEmisor] ASC, [NumeroComprobante] ASC, [IdLocalidadCheque] ASC, [IdBancoSucursalCheque] ASC),
    CONSTRAINT [FK_CuentasCorrientesCheques_Cheques] FOREIGN KEY ([IdSucursal], [NumeroCheque], [IdBancoCheque], [IdBancoSucursalCheque], [IdLocalidadCheque]) REFERENCES [dbo].[Cheques] ([IdSucursal], [NumeroCheque], [IdBanco], [IdBancoSucursal], [IdLocalidad]),
    CONSTRAINT [FK_CuentasCorrientesCheques_CuentasCorrientes] FOREIGN KEY ([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante]) REFERENCES [dbo].[CuentasCorrientes] ([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante])
);

