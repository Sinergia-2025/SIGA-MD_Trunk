CREATE TABLE [dbo].[VentasObservaciones] (
    [IdSucursal]        INT           NOT NULL,
    [IdTipoComprobante] VARCHAR (15)  NOT NULL,
    [Letra]             VARCHAR (1)   NOT NULL,
    [CentroEmisor]      INT           NOT NULL,
    [NumeroComprobante] BIGINT        NOT NULL,
    [Linea]             INT           NOT NULL,
    [Observacion]       VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_VentasObservaciones] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdTipoComprobante] ASC, [Letra] ASC, [CentroEmisor] ASC, [NumeroComprobante] ASC, [Linea] ASC),
    CONSTRAINT [FK_VentasObservaciones_Ventas] FOREIGN KEY ([IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdSucursal]) REFERENCES [dbo].[Ventas] ([IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdSucursal])
);

