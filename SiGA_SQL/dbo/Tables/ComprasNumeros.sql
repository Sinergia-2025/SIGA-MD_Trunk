CREATE TABLE [dbo].[ComprasNumeros] (
    [IdTipoComprobante]            VARCHAR (15) NOT NULL,
    [LetraFiscal]                  CHAR (1)     NOT NULL,
    [CentroEmisor]                 SMALLINT     NOT NULL,
    [IdSucursal]                   INT          NOT NULL,
    [Numero]                       INT          NOT NULL,
    [IdTipoComprobanteRelacionado] VARCHAR (10) NULL,
    CONSTRAINT [PK_ComprasNumeros] PRIMARY KEY CLUSTERED ([IdTipoComprobante] ASC, [LetraFiscal] ASC, [CentroEmisor] ASC),
    CONSTRAINT [FK_ComprasNumeros_Sucursales] FOREIGN KEY ([IdSucursal]) REFERENCES [dbo].[Sucursales] ([IdSucursal]),
    CONSTRAINT [FK_ComprasNumeros_TiposComprobantes] FOREIGN KEY ([IdTipoComprobante]) REFERENCES [dbo].[TiposComprobantes] ([IdTipoComprobante])
);

