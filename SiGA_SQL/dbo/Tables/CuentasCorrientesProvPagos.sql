CREATE TABLE [dbo].[CuentasCorrientesProvPagos] (
    [IdSucursal]         INT             NOT NULL,
    [IdTipoComprobante]  VARCHAR (15)    NOT NULL,
    [Letra]              VARCHAR (1)     NOT NULL,
    [CentroEmisor]       INT             NOT NULL,
    [NumeroComprobante]  BIGINT          NOT NULL,
    [CuotaNumero]        INT             NOT NULL,
    [Fecha]              DATETIME        NOT NULL,
    [FechaVencimiento]   DATETIME        NOT NULL,
    [ImporteCuota]       DECIMAL (12, 2) NOT NULL,
    [SaldoCuota]         DECIMAL (12, 2) NOT NULL,
    [IdFormasPago]       INT             NOT NULL,
    [Observacion]        VARCHAR (100)   NULL,
    [IdTipoComprobante2] VARCHAR (15)    NULL,
    [NumeroComprobante2] BIGINT          NULL,
    [CentroEmisor2]      INT             NULL,
    [CuotaNumero2]       INT             NULL,
    [Letra2]             VARCHAR (1)     NULL,
    [IdProveedor]        BIGINT          NOT NULL,
    CONSTRAINT [PK_CuentasCorrientesProvPagos] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdProveedor] ASC, [IdTipoComprobante] ASC, [Letra] ASC, [CentroEmisor] ASC, [NumeroComprobante] ASC, [CuotaNumero] ASC),
    CONSTRAINT [FK_CuentasCorrientesProvPagos_CuentasCorrientesProvPagos] FOREIGN KEY ([IdSucursal], [IdProveedor], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [CuotaNumero]) REFERENCES [dbo].[CuentasCorrientesProvPagos] ([IdSucursal], [IdProveedor], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [CuotaNumero]),
    CONSTRAINT [FK_CuentasCorrientesProvPagos_VentasFormasPago] FOREIGN KEY ([IdFormasPago]) REFERENCES [dbo].[VentasFormasPago] ([IdFormasPago])
);

