IF dbo.ExisteFK('FK_ProduccionProductosComponentes_ProduccionProductos') = 1
BEGIN
    ALTER TABLE dbo.ProduccionProductosComponentes DROP CONSTRAINT FK_ProduccionProductosComponentes_ProduccionProductos
END
GO
IF dbo.ExisteFK('FK_ProduccionProductosComponentes_Monedas') = 1
BEGIN
    ALTER TABLE dbo.ProduccionProductosComponentes DROP CONSTRAINT FK_ProduccionProductosComponentes_Monedas
END
GO

IF dbo.ExisteTabla('Tmp_ProduccionProductosComponentes') = 0
BEGIN
    CREATE TABLE dbo.Tmp_ProduccionProductosComponentes
	    (
	    IdSucursal int NOT NULL,
	    IdProduccion int NOT NULL,
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
	    FormulaCalculoKilaje varchar(MAX) NOT NULL,
	    IdMoneda int NULL,
	    IdLote varchar(30) NULL
	    )  ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO

IF dbo.ExisteCampo('ProduccionProductosComponentes', 'Sec') = 1 AND dbo.ExisteCampo('ProduccionProductosComponentes', 'FormulaCalculoKilaje') = 0 AND EXISTS(SELECT * FROM dbo.ProduccionProductosComponentes)
	 INSERT INTO dbo.Tmp_ProduccionProductosComponentes 
                (IdSucursal, IdProduccion, IdProducto, Orden, IdProductoElaborado, IdUnicoNodoProductoElaborado, IdProductoComponente, IdUnicoNodoProductoComponente, IdFormula, SecuenciaFormula, NombreProductoElaborado, NombreProductoComponente, NombreFormula, PrecioCosto, PrecioVenta, Cantidad, CantidadEnFormula, SegunCalculoForma, IdMoneda, IdLote, ImporteCosto,           ImporteVenta,           FormulaCalculoKilaje)
		  SELECT IdSucursal, IdProduccion, IdProducto, Orden, IdProducto,          IdProducto,                   IdProductoComponente, IdProductoComponente,          0,         Sec,              '',                      '',                       '',            PrecioCosto, PrecioVenta, Cantidad, Cantidad,          0,                 IdMoneda, IdLote, PrecioCosto * Cantidad, PrecioVenta * Cantidad, ''
            FROM dbo.ProduccionProductosComponentes WITH (HOLDLOCK TABLOCKX)
    UPDATE PPF
       SET FormulaCalculoKilaje = PF.FormulaCalculoKilaje
         , NombreProductoElaborado = P1.NombreProducto
         , NombreProductoComponente = P.NombreProducto
      FROM Tmp_ProduccionProductosComponentes PPF
     INNER JOIN Productos P ON P.IdProducto = PPF.IdProductoComponente
     INNER JOIN Productos P1 ON P1.IdProducto = PPF.IdProducto
     INNER JOIN ProduccionFormas PF ON PF.IdProduccionForma = P.IdProduccionForma    

    UPDATE PPC
       SET IdFormula = PF.IdFormula
         , NombreFormula = PF.NombreFormula
      FROM ProductosFormulas PF
     INNER JOIN Tmp_ProduccionProductosComponentes AS PPC ON PPC.IdProducto = PF.IdProducto
     INNER JOIN (
                 SELECT IdProducto, MIN(IdFormula) IdFormula
                   FROM ProductosFormulas
                  --WHERE IdProducto = '63001'
                  GROUP BY IdProducto) PF1
             ON PF1.IdProducto = PF.IdProducto AND PF1.IdFormula = PF.IdFormula

GO

IF dbo.ExisteCampo('ProduccionProductosComponentes', 'FormulaCalculoKilaje') = 0
BEGIN
    DROP TABLE dbo.ProduccionProductosComponentes
END
GO

IF dbo.ExisteTabla('ProduccionProductosComponentes') = 0
BEGIN
    EXECUTE sp_rename N'dbo.Tmp_ProduccionProductosComponentes', N'ProduccionProductosComponentes', 'OBJECT' 
END
GO

IF dbo.ExistePK('PK_ProduccionProductosComponentes') = 0
BEGIN
    ALTER TABLE dbo.ProduccionProductosComponentes ADD CONSTRAINT	PK_ProduccionProductosComponentes
        PRIMARY KEY CLUSTERED (IdSucursal, IdProduccion, Orden, IdProducto, IdProductoElaborado, IdUnicoNodoProductoElaborado, IdProductoComponente, IdUnicoNodoProductoComponente, SecuenciaFormula)
        WITH( PAD_INDEX = OFF, FILLFACTOR = 90, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
END
GO

IF dbo.ExisteFK('FK_ProduccionProductosComponentes_Monedas') = 0
BEGIN
    ALTER TABLE dbo.ProduccionProductosComponentes ADD CONSTRAINT	FK_ProduccionProductosComponentes_Monedas
        FOREIGN KEY (IdMoneda)
        REFERENCES dbo.Monedas (IdMoneda)
        ON UPDATE  NO ACTION ON DELETE  NO ACTION 
END
GO
IF dbo.ExistefK('FK_ProduccionProductosComponentes_ProduccionProductos') = 0
BEGIN
    ALTER TABLE dbo.ProduccionProductosComponentes ADD CONSTRAINT FK_ProduccionProductosComponentes_ProduccionProductos
        FOREIGN KEY (IdSucursal, IdProduccion, Orden, IdProducto)
        REFERENCES dbo.ProduccionProductos (IdSucursal, IdProduccion, Orden, IdProducto) ON UPDATE  NO ACTION ON DELETE  NO ACTION 
END	
GO
