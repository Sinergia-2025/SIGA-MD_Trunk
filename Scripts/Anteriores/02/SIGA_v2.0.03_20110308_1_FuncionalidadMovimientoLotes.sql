GO
PRINT N'Altering [dbo].[ComprasProductos]...';


GO
ALTER TABLE [dbo].[ComprasProductos] DROP COLUMN [IdLote];


GO
PRINT N'Altering [dbo].[MovimientosComprasProductos]...';


GO
ALTER TABLE [dbo].[MovimientosComprasProductos]
    ADD [IdLote] VARCHAR (10) NULL;

GO
CREATE TABLE [dbo].[MovimientosVentasProductosLotes] (
    [IdSucursal]       INT             NOT NULL,
    [IdTipoMovimiento] VARCHAR (15)    NOT NULL,
    [NumeroMovimiento] BIGINT          NOT NULL,
    [Orden]            BIGINT          NOT NULL,
    [IdProducto]       VARCHAR (15)    NOT NULL,
    [IdLote]           VARCHAR (10)    NOT NULL,
    [Cantidad]         DECIMAL (12, 2) NOT NULL
);


GO
PRINT N'Creating PK_MovimientosVentasProductosLotes...';


GO
ALTER TABLE [dbo].[MovimientosVentasProductosLotes]
    ADD CONSTRAINT [PK_MovimientosVentasProductosLotes] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdTipoMovimiento] ASC, [NumeroMovimiento] ASC, [Orden] ASC, [IdProducto] ASC, [IdLote] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

GO
PRINT N'Creating FK_MovimientosVentasProductosLotes_MovimientosVentasProductos...';


GO
ALTER TABLE [dbo].[MovimientosVentasProductosLotes] WITH NOCHECK
    ADD CONSTRAINT [FK_MovimientosVentasProductosLotes_MovimientosVentasProductos] FOREIGN KEY ([IdSucursal], [IdTipoMovimiento], [NumeroMovimiento], [Orden], [IdProducto]) REFERENCES [dbo].[MovimientosVentasProductos] ([IdSucursal], [IdTipoMovimiento], [NumeroMovimiento], [Orden], [IdProducto]) ON DELETE NO ACTION ON UPDATE NO ACTION;


