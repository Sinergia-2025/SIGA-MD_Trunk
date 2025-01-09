CREATE TABLE [dbo].[ComprasObservaciones] (
    [IdSucursal]        INT           NOT NULL,
    [IdTipoComprobante] VARCHAR (15)  NOT NULL,
    [Letra]             VARCHAR (1)   NOT NULL,
    [CentroEmisor]      INT           NOT NULL,
    [NumeroComprobante] BIGINT        NOT NULL,
    [Linea]             INT           NOT NULL,
    [Observacion]       VARCHAR (100) NOT NULL,
    [IdProveedor]       BIGINT        NOT NULL,
    CONSTRAINT [PK_ComprasObservaciones] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdTipoComprobante] ASC, [Letra] ASC, [CentroEmisor] ASC, [NumeroComprobante] ASC, [IdProveedor] ASC, [Linea] ASC),
    CONSTRAINT [FK_ComprasObservaciones_Compras] FOREIGN KEY ([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdProveedor]) REFERENCES [dbo].[Compras] ([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdProveedor])
);

