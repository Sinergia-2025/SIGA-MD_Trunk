CREATE TABLE [dbo].[VentasTarjetas] (
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
    CONSTRAINT [PK_VentasTarjetas] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdTipoComprobante] ASC, [Letra] ASC, [CentroEmisor] ASC, [NumeroComprobante] ASC, [IdTarjeta] ASC, [IdBanco] ASC),
    CONSTRAINT [FK_VentasTarjetas_Tarjetas] FOREIGN KEY ([IdTarjeta]) REFERENCES [dbo].[Tarjetas] ([IdTarjeta]),
    CONSTRAINT [FK_VentasTarjetas_Ventas] FOREIGN KEY ([IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdSucursal]) REFERENCES [dbo].[Ventas] ([IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdSucursal])
);

