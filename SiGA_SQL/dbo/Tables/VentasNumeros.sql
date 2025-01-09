CREATE TABLE [dbo].[VentasNumeros] (
    [IdTipoComprobante]            VARCHAR (15) NOT NULL,
    [LetraFiscal]                  CHAR (1)     NOT NULL,
    [CentroEmisor]                 SMALLINT     NOT NULL,
    [IdSucursal]                   INT          NOT NULL,
    [Numero]                       INT          NOT NULL,
    [IdTipoComprobanteRelacionado] VARCHAR (50) NULL,
    [Fecha]                        DATE         NOT NULL,
    CONSTRAINT [PK_VentasNumeros] PRIMARY KEY CLUSTERED ([IdTipoComprobante] ASC, [LetraFiscal] ASC, [CentroEmisor] ASC),
    CONSTRAINT [FK_VentasNumeros_TiposComprobantes] FOREIGN KEY ([IdTipoComprobante]) REFERENCES [dbo].[TiposComprobantes] ([IdTipoComprobante])
);

