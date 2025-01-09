CREATE TABLE [dbo].[MovimientosVentas] (
    [IdSucursal]        INT             NOT NULL,
    [IdTipoMovimiento]  VARCHAR (15)    NOT NULL,
    [NumeroMovimiento]  BIGINT          NOT NULL,
    [FechaMovimiento]   DATETIME        NOT NULL,
    [Neto]              DECIMAL (12, 2) NOT NULL,
    [Total]             DECIMAL (12, 2) NOT NULL,
    [IdCategoriaFiscal] SMALLINT        NULL,
    [IdTipoComprobante] VARCHAR (15)    NULL,
    [Letra]             VARCHAR (1)     NULL,
    [CentroEmisor]      INT             NULL,
    [NumeroComprobante] BIGINT          NULL,
    [Usuario]           VARCHAR (10)    NOT NULL,
    [Observacion]       VARCHAR (100)   NULL,
    [TotalImpuestos]    DECIMAL (12, 2) NOT NULL,
    [IdCliente]         BIGINT          NULL,
    CONSTRAINT [PK_MovimientosVentas] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdTipoMovimiento] ASC, [NumeroMovimiento] ASC),
    CONSTRAINT [FK_MovimientosVentas_CategoriasFiscales] FOREIGN KEY ([IdCategoriaFiscal]) REFERENCES [dbo].[CategoriasFiscales] ([IdCategoriaFiscal]),
    CONSTRAINT [FK_MovimientosVentas_Clientes] FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[Clientes] ([IdCliente]),
    CONSTRAINT [FK_MovimientosVentas_Sucursales] FOREIGN KEY ([IdSucursal]) REFERENCES [dbo].[Sucursales] ([IdSucursal]),
    CONSTRAINT [FK_MovimientosVentas_TiposComprobantes] FOREIGN KEY ([IdTipoComprobante]) REFERENCES [dbo].[TiposComprobantes] ([IdTipoComprobante]),
    CONSTRAINT [FK_MovimientosVentas_Usuarios] FOREIGN KEY ([Usuario]) REFERENCES [dbo].[Usuarios] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_MovimientosVentas_Comprobante]
    ON [dbo].[MovimientosVentas]([IdSucursal] ASC, [IdTipoComprobante] ASC, [Letra] ASC, [CentroEmisor] ASC, [NumeroComprobante] ASC);

