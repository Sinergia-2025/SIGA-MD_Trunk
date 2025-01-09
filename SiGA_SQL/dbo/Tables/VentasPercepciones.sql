CREATE TABLE [dbo].[VentasPercepciones] (
    [IdSucursal]        INT          NOT NULL,
    [IdTipoComprobante] VARCHAR (15) NOT NULL,
    [Letra]             VARCHAR (1)  NOT NULL,
    [CentroEmisor]      INT          NOT NULL,
    [NumeroComprobante] BIGINT       NOT NULL,
    [IdTipoImpuesto]    VARCHAR (5)  NOT NULL,
    [EmisorPercepcion]  INT          NOT NULL,
    [NumeroPercepcion]  BIGINT       NOT NULL,
    CONSTRAINT [PK_VentasPercepciones] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdTipoComprobante] ASC, [Letra] ASC, [CentroEmisor] ASC, [NumeroComprobante] ASC, [IdTipoImpuesto] ASC, [EmisorPercepcion] ASC, [NumeroPercepcion] ASC),
    CONSTRAINT [FK_VentasPercepciones_TiposImpuestos] FOREIGN KEY ([IdTipoImpuesto]) REFERENCES [dbo].[TiposImpuestos] ([IdTipoImpuesto]),
    CONSTRAINT [FK_VentasPercepciones_Ventas] FOREIGN KEY ([IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdSucursal]) REFERENCES [dbo].[Ventas] ([IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdSucursal])
);

