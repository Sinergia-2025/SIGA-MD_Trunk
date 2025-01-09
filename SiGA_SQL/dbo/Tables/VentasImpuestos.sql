CREATE TABLE [dbo].[VentasImpuestos] (
    [IdSucursal]        INT             NOT NULL,
    [IdTipoComprobante] VARCHAR (15)    NOT NULL,
    [Letra]             VARCHAR (1)     NOT NULL,
    [CentroEmisor]      INT             NOT NULL,
    [NumeroComprobante] BIGINT          NOT NULL,
    [IdTipoImpuesto]    VARCHAR (5)     NOT NULL,
    [Alicuota]          DECIMAL (6, 2)  NOT NULL,
    [Bruto]             DECIMAL (12, 2) NOT NULL,
    [Neto]              DECIMAL (12, 2) NOT NULL,
    [Importe]           DECIMAL (12, 2) NOT NULL,
    [Total]             DECIMAL (12, 2) NOT NULL,
    CONSTRAINT [PK_VentasImpuestos_1] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdTipoComprobante] ASC, [Letra] ASC, [CentroEmisor] ASC, [NumeroComprobante] ASC, [IdTipoImpuesto] ASC, [Alicuota] ASC),
    CONSTRAINT [FK_VentasImpuestos_Impuestos] FOREIGN KEY ([IdTipoImpuesto], [Alicuota]) REFERENCES [dbo].[Impuestos] ([IdTipoImpuesto], [Alicuota]),
    CONSTRAINT [FK_VentasImpuestos_Ventas] FOREIGN KEY ([IdTipoImpuesto], [Alicuota]) REFERENCES [dbo].[Impuestos] ([IdTipoImpuesto], [Alicuota])
);

