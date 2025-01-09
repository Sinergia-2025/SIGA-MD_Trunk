CREATE TABLE [dbo].[CuentasCorrientesTarjetas] (
    [IdSucursal]        INT             NOT NULL,
    [IdTipoComprobante] VARCHAR (15)    NOT NULL,
    [Letra]             VARCHAR (1)     NOT NULL,
    [CentroEmisor]      INT             NOT NULL,
    [NumeroComprobante] BIGINT          NOT NULL,
    [IdTarjeta]         INT             NOT NULL,
    [IdBanco]           INT             NOT NULL,
    [Monto]             DECIMAL (14, 4) NOT NULL,
    [Cuotas]            INT             NULL,
    [NumeroCupon]       INT             NULL,
    CONSTRAINT [PK_CuentasCorrientesTarjetas] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdTipoComprobante] ASC, [Letra] ASC, [CentroEmisor] ASC, [NumeroComprobante] ASC, [IdTarjeta] ASC, [IdBanco] ASC),
    CONSTRAINT [FK_CuentasCorrientesTarjetas_Bancos] FOREIGN KEY ([IdBanco]) REFERENCES [dbo].[Bancos] ([IdBanco]),
    CONSTRAINT [FK_CuentasCorrientesTarjetas_CuentasCorrientes] FOREIGN KEY ([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante]) REFERENCES [dbo].[CuentasCorrientes] ([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante]),
    CONSTRAINT [FK_CuentasCorrientesTarjetas_Tarjetas] FOREIGN KEY ([IdTarjeta]) REFERENCES [dbo].[Tarjetas] ([IdTarjeta])
);

