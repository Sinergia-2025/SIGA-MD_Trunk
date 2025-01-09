IF dbo.ExisteFK('FK_PedidosProductosFormula_ProductosFormulas') = 1
BEGIN
    ALTER TABLE dbo.PedidosProductosFormulas DROP CONSTRAINT FK_PedidosProductosFormula_ProductosFormulas
END
GO
IF dbo.ExisteFK('FK_PedidosProductosFormula_PedidosProductos') = 1
BEGIN
    ALTER TABLE dbo.PedidosProductosFormulas DROP CONSTRAINT FK_PedidosProductosFormula_PedidosProductos
END
GO

IF dbo.ExisteTabla('Tmp_PedidosProductosFormulas') = 0
BEGIN
    CREATE TABLE dbo.Tmp_PedidosProductosFormulas
	    (
	    IdSucursal int NOT NULL,
	    IdTipoComprobante varchar(15) NOT NULL,
	    Letra varchar(1) NOT NULL,
	    CentroEmisor int NOT NULL,
	    NumeroPedido int NOT NULL,
	    IdProducto varchar(15) NOT NULL,
	    Orden int NOT NULL,
	    IdProductoElaborado varchar(15) NOT NULL,
        IdUnicoNodoProductoElaborado varchar(50) NOT NULL,
	    IdProductoComponente varchar(15) NOT NULL,
        IdUnicoNodoProductoComponente varchar(50) NOT NULL,
	    IdFormula int NOT NULL,
        SecuenciaFormula int NOT NULL,
	    NombreProductoElaborado varchar(60) NOT NULL,
	    NombreProductoComponente varchar(60) NOT NULL,
	    NombreFormula varchar(100) NOT NULL,
	    PrecioCosto decimal(14, 4) NOT NULL,
	    PrecioVenta decimal(14, 4) NOT NULL,
	    Cantidad decimal(16, 4) NOT NULL,
	    CantidadEnFormula decimal(16, 4) NOT NULL,
	    SegunCalculoForma bit NOT NULL,
	    ImporteCosto decimal(14, 4) NOT NULL,
	    ImporteVenta decimal(14, 4) NOT NULL,
	    FormulaCalculoKilaje varchar(MAX) NOT NULL
	    )  ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO

IF dbo.ExisteCampo('PedidosProductosFormulas', 'FormulaCalculoKilaje') = 0 AND EXISTS(SELECT * FROM dbo.PedidosProductosFormulas)
	 EXEC('INSERT INTO dbo.Tmp_PedidosProductosFormulas 
                (IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroPedido, IdProducto, Orden, IdProductoElaborado, IdUnicoNodoProductoElaborado, IdProductoComponente, IdUnicoNodoProductoComponente, IdFormula, SecuenciaFormula, NombreProductoElaborado, NombreProductoComponente, NombreFormula, PrecioCosto, PrecioVenta, Cantidad, CantidadEnFormula, SegunCalculoForma, ImporteCosto,           ImporteVenta,           FormulaCalculoKilaje)
		  SELECT IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroPedido, IdProducto, Orden, IdProducto,          IdProducto,                   IdProductoComponente, IdProductoComponente,          IdFormula, 0,                '',                      NombreProductoComponente, NombreFormula, PrecioCosto, PrecioVenta, Cantidad, Cantidad,          SegunCalculoForma, PrecioCosto * Cantidad, PrecioVenta * Cantidad, ''
            FROM dbo.PedidosProductosFormulas WITH (HOLDLOCK TABLOCKX)')
    UPDATE PPF
       SET FormulaCalculoKilaje = PF.FormulaCalculoKilaje
         , NombreProductoElaborado = P1.NombreProducto
      FROM Tmp_PedidosProductosFormulas PPF
     INNER JOIN Productos P ON P.IdProducto = PPF.IdProductoComponente
     INNER JOIN Productos P1 ON P1.IdProducto = PPF.IdProducto
     INNER JOIN ProduccionFormas PF ON PF.IdProduccionForma = P.IdProduccionForma    
GO

IF dbo.ExisteCampo('PedidosProductosFormulas', 'FormulaCalculoKilaje') = 0
BEGIN
    DROP TABLE dbo.PedidosProductosFormulas
END
GO

IF dbo.ExisteTabla('PedidosProductosFormulas') = 0
BEGIN
    EXECUTE sp_rename N'dbo.Tmp_PedidosProductosFormulas', N'PedidosProductosFormulas', 'OBJECT' 
END
GO

IF dbo.ExistePK('PK_PedidosProductosFormula') = 0
BEGIN
    ALTER TABLE dbo.PedidosProductosFormulas ADD CONSTRAINT	PK_PedidosProductosFormula
        PRIMARY KEY CLUSTERED (IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroPedido, IdProducto, Orden, IdProductoElaborado, IdUnicoNodoProductoElaborado, IdProductoComponente, IdUnicoNodoProductoComponente, IdFormula, SecuenciaFormula)
        WITH( PAD_INDEX = OFF, FILLFACTOR = 90, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
END
GO

IF dbo.ExisteFK('FK_PedidosProductosFormula_PedidosProductos') = 0
BEGIN
    ALTER TABLE dbo.PedidosProductosFormulas ADD CONSTRAINT	FK_PedidosProductosFormula_PedidosProductos
        FOREIGN KEY (IdSucursal, NumeroPedido, IdProducto, Orden, IdTipoComprobante, Letra, CentroEmisor)
        REFERENCES dbo.PedidosProductos (IdSucursal, NumeroPedido, IdProducto, Orden, IdTipoComprobante, Letra, CentroEmisor )
        ON UPDATE  NO ACTION ON DELETE  NO ACTION 
END
GO
IF dbo.ExistefK('FK_PedidosProductosFormula_ProductosFormulas') = 0
BEGIN
    ALTER TABLE dbo.PedidosProductosFormulas ADD CONSTRAINT FK_PedidosProductosFormula_ProductosFormulas
        FOREIGN KEY (IdProducto, IdFormula)
        REFERENCES dbo.ProductosFormulas (IdProducto, IdFormula) ON UPDATE  NO ACTION ON DELETE  NO ACTION 
END	
GO
