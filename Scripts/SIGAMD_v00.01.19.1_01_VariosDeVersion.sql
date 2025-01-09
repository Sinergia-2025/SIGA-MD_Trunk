/****** Object:  Table [dbo].[OrdenesProduccionProductosFormulas]    Script Date: 11/1/2023 19:51:50 ******/
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

PRINT ''
PRINT '1. Tabla Nueva: OrdenesProduccionProductosFormulas'
IF dbo.ExisteTabla('OrdenesProduccionProductosFormulas') = 0
BEGIN
    CREATE TABLE [dbo].[OrdenesProduccionProductosFormulas](
	    [IdSucursal] [int] NOT NULL,
	    [IdTipoComprobante] [varchar](15) NOT NULL,
	    [Letra] [varchar](1) NOT NULL,
	    [CentroEmisor] [int] NOT NULL,
	    [NumeroOrdenProduccion] [int] NOT NULL,
	    [IdProducto] [varchar](15) NOT NULL,
	    [Orden] [int] NOT NULL,
	    [IdProductoElaborado] [varchar](15) NOT NULL,
	    [IdUnicoNodoProductoElaborado] [varchar](50) NOT NULL,
	    [IdProductoComponente] [varchar](15) NOT NULL,
	    [IdUnicoNodoProductoComponente] [varchar](50) NOT NULL,
	    [IdFormula] [int] NOT NULL,
	    [SecuenciaFormula] [int] NOT NULL,
	    [NombreProductoElaborado] [varchar](60) NOT NULL,
	    [NombreProductoComponente] [varchar](60) NOT NULL,
	    [NombreFormula] [varchar](100) NOT NULL,
	    [PrecioCosto] [decimal](14, 4) NOT NULL,
	    [PrecioVenta] [decimal](14, 4) NOT NULL,
	    [Cantidad] [decimal](16, 4) NOT NULL,
	    [CantidadEnFormula] [decimal](16, 4) NOT NULL,
	    [SegunCalculoForma] [bit] NOT NULL,
	    [ImporteCosto] [decimal](14, 4) NOT NULL,
	    [ImporteVenta] [decimal](14, 4) NOT NULL,
	    [FormulaCalculoKilaje] [varchar](max) NOT NULL,
     CONSTRAINT [PK_OrdenesProduccionProductosFormula] PRIMARY KEY CLUSTERED (
	    [IdSucursal] ASC, [IdTipoComprobante] ASC, [Letra] ASC, [CentroEmisor] ASC, [NumeroOrdenProduccion] ASC,
	    [IdProducto] ASC, [Orden] ASC,
	    [IdProductoElaborado] ASC, [IdUnicoNodoProductoElaborado] ASC,
	    [IdProductoComponente] ASC, [IdUnicoNodoProductoComponente] ASC,
	    [IdFormula] ASC, [SecuenciaFormula] ASC
     ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO

IF dbo.ExisteFK('FK_OrdenesProduccionProductosFormula_OrdenesProduccionProductos') = 0
BEGIN
    ALTER TABLE [dbo].[OrdenesProduccionProductosFormulas]  WITH CHECK ADD  CONSTRAINT [FK_OrdenesProduccionProductosFormula_OrdenesProduccionProductos] 
                                        FOREIGN KEY([IdSucursal], [NumeroOrdenProduccion], [IdProducto], [Orden], [IdTipoComprobante], [Letra], [CentroEmisor])
     REFERENCES [dbo].[OrdenesProduccionProductos] ([IdSucursal], [NumeroOrdenProduccion], [IdProducto], [Orden], [IdTipoComprobante], [Letra], [CentroEmisor])
    ALTER TABLE [dbo].[OrdenesProduccionProductosFormulas] CHECK CONSTRAINT [FK_OrdenesProduccionProductosFormula_OrdenesProduccionProductos]
END
GO

IF dbo.ExisteFK('FK_OrdenesProduccionProductosFormula_ProductosFormulas') = 0
BEGIN
    ALTER TABLE [dbo].[OrdenesProduccionProductosFormulas]  WITH CHECK ADD  CONSTRAINT [FK_OrdenesProduccionProductosFormula_ProductosFormulas] 
                               FOREIGN KEY([IdProducto], [IdFormula])
     REFERENCES [dbo].[ProductosFormulas] ([IdProducto], [IdFormula])
    ALTER TABLE [dbo].[OrdenesProduccionProductosFormulas] CHECK CONSTRAINT [FK_OrdenesProduccionProductosFormula_ProductosFormulas]
END
GO


PRINT ''
PRINT '2. Nueva Tabla: Tipos de Observaciones.'
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'TiposObservaciones')
	BEGIN
		CREATE TABLE [dbo].[TiposObservaciones](
			[IdObservaciones] [smallint] NOT NULL,
			[Descripcion] [varchar](50) NOT NULL,
			[Activa] [bit] NOT NULL,
			[PorDefecto] [bit] NOT NULL,
			CONSTRAINT [PK_TiposObservaciones] PRIMARY KEY CLUSTERED 
		(
			[IdObservaciones] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
		) ON [PRIMARY]

		INSERT INTO TiposObservaciones (IdObservaciones, Descripcion, Activa, PorDefecto) VALUES (1,'Detallada', 1, 1) 
		INSERT INTO TiposObservaciones (IdObservaciones, Descripcion, Activa, PorDefecto) VALUES (2,'Provision', 1, 0) 
		INSERT INTO TiposObservaciones (IdObservaciones, Descripcion, Activa, PorDefecto) VALUES (3,'Referencia Obra', 1, 0) 
	END
GO


PRINT ''
PRINT '3. Nueva Campo: PedidosObservaciones.'
IF dbo.ExisteCampo('PedidosObservaciones', 'IdTipoObservacion') = 0
BEGIN
    ALTER TABLE dbo.PedidosObservaciones ADD IdTipoObservacion smallint NULL
END
GO

PRINT ''
PRINT '4. Nueva Campo: PedidosObservaciones.'
IF dbo.ExisteCampo('PedidosObservaciones', 'IdTipoObservacion') = 1
BEGIN
	UPDATE PedidosObservaciones SET IdTipoObservacion = 1 
    ALTER TABLE dbo.PedidosObservaciones ALTER COLUMN IdTipoObservacion smallint NOT NULL
END
GO

PRINT ''
PRINT '5. Nueva Campo: PedidosObservaciones.'
IF dbo.ExisteFK('FK_TipoObservacion') = 0
BEGIN
	ALTER TABLE PedidosObservaciones  WITH CHECK ADD  CONSTRAINT [FK_TipoObservacion] FOREIGN KEY([IdTipoObservacion])
   								      REFERENCES [dbo].[TiposObservaciones] ([IdObservaciones])
END
GO


IF dbo.ExisteCampo('PedidosProductos', 'Architran') = 1
BEGIN
    EXECUTE sp_rename N'dbo.PedidosProductos.Architran', N'Architrave', 'COLUMN' 
END
GO

UPDATE Parametros
   SET IdParametro = 'PEDIDOSMOSTRARPRODUCTOARCHITRAVE'
 WHERE IdParametro = 'PEDIDOSMOSTRARPRODUCTOARCHITRAN'

IF dbo.ExisteCampo('OrdenesProduccionProductos', 'IdProduccionModeloForma') = 0
BEGIN
    ALTER TABLE dbo.OrdenesProduccionProductos ADD IdProduccionModeloForma int NULL
    ALTER TABLE dbo.OrdenesProduccionProductos ADD Architrave decimal(10, 3) NULL
END
GO

IF dbo.ExisteFK('FK_OrdenesProduccionProductos_ProduccionModelosFormas') = 0
BEGIN
    ALTER TABLE dbo.OrdenesProduccionProductos ADD CONSTRAINT FK_OrdenesProduccionProductos_ProduccionModelosFormas
        FOREIGN KEY (IdProduccionModeloForma) 
        REFERENCES dbo.ProduccionModelosFormas (IdProduccionModeloForma)
        ON UPDATE  NO ACTION ON DELETE  NO ACTION 
END
GO



PRINT ''
PRINT '6. Nueva Campo: VentasObservaciones.'
IF dbo.ExisteCampo('VentasObservaciones', 'IdTipoObservacion') = 0
BEGIN
    ALTER TABLE dbo.VentasObservaciones ADD IdTipoObservacion smallint NULL
END
GO

PRINT ''
PRINT '7. Nueva Campo: VentasObservaciones.'
IF dbo.ExisteCampo('VentasObservaciones', 'IdTipoObservacion') = 1
BEGIN
	UPDATE VentasObservaciones SET IdTipoObservacion = 1 
    ALTER TABLE dbo.VentasObservaciones ALTER COLUMN IdTipoObservacion smallint NOT NULL
END
GO

PRINT ''
PRINT '8. Nueva Campo: PedidosObservaciones.'
IF dbo.ExisteFK('FK_TipoObservacionVta') = 0
BEGIN
	ALTER TABLE VentasObservaciones  WITH CHECK ADD  CONSTRAINT [FK_TipoObservacionVta] FOREIGN KEY([IdTipoObservacion])
   								      REFERENCES [dbo].[TiposObservaciones] ([IdObservaciones])
END
GO

PRINT ''
PRINT '9. Nueva Campo: PedidosObservaciones.'
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'CuentasCorrientesProv' AND COLUMN_NAME = 'FechaTransferencia')
BEGIN 
	ALTER TABLE dbo.CuentasCorrientesProv ADD FechaTransferencia datetime NULL
END
GO


PRINT ''
PRINT '10. Asigna las direcciones de los Clientes No Eventuales a los Pedidos'
BEGIN
	UPDATE PEDIDOS 
	SET Pedidos.Direccion = C.Direccion,
		pedidos.IdLocalidad = C.IdLocalidad 
	FROM Pedidos AS P
		INNER JOIN Clientes AS C ON C.IdCliente = P.IDCliente AND C.EsClienteGenerico = 0 
	WHERE P.IdLocalidad IS NULL
END



