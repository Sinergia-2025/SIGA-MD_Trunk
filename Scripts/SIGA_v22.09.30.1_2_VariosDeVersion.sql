IF dbo.ExisteCampo('ProduccionProductosComponentes', 'IdLote') = 0
    ALTER TABLE dbo.ProduccionProductosComponentes ADD IdLote varchar(30) NULL
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME = 'FK_ProduccionProductosComponentes_ProductosLotes')
    ALTER TABLE dbo.ProduccionProductosComponentes DROP CONSTRAINT FK_ProduccionProductosComponentes_ProductosLotes

ALTER TABLE dbo.ProduccionProductosComponentes ADD CONSTRAINT FK_ProduccionProductosComponentes_ProductosLotes
    FOREIGN KEY (IdSucursal, IdProductoComponente, IdLote)
    REFERENCES dbo.ProductosLotes (IdSucursal, IdProducto, IdLote)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO

IF dbo.ExisteCampo('ProduccionProductosComponentes', 'Sec') = 0
    ALTER TABLE dbo.ProduccionProductosComponentes ADD Sec INT NULL
GO
UPDATE ProduccionProductosComponentes SET Sec = 1;
ALTER TABLE dbo.ProduccionProductosComponentes ALTER COLUMN Sec INT NOT NULL


ALTER TABLE dbo.ProduccionProductosComponentes DROP CONSTRAINT PK_ProduccionProductosComponentes
GO
ALTER TABLE dbo.ProduccionProductosComponentes ADD CONSTRAINT PK_ProduccionProductosComponentes
    PRIMARY KEY CLUSTERED (IdSucursal, IdProduccion, Orden, IdProducto, IdProductoComponente, Sec)
    WITH( PAD_INDEX = OFF, FILLFACTOR = 90, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]


IF dbo.ExisteCampo('Productos', 'PublicarEnTiendaNube') = 0
BEGIN
    ALTER TABLE dbo.Productos ADD PublicarEnTiendaNube bit NULL
    ALTER TABLE dbo.Productos ADD PublicarEnMercadoLibre bit NULL
    ALTER TABLE dbo.Productos ADD PublicarEnArborea bit NULL
END
GO

UPDATE Productos
   SET PublicarEnTiendaNube     = 0
     , PublicarEnMercadoLibre   = 0
     , PublicarEnArborea        = 0
 WHERE PublicarEnTiendaNube IS NULL;

ALTER TABLE dbo.Productos ALTER COLUMN PublicarEnTiendaNube bit NOT NULL
ALTER TABLE dbo.Productos ALTER COLUMN PublicarEnMercadoLibre bit NOT NULL
ALTER TABLE dbo.Productos ALTER COLUMN PublicarEnArborea bit NOT NULL
GO

DECLARE @TiendaNubeToken        VARCHAR(MAX) = (SELECT TOP 1 ValorParametro FROM Parametros WHERE IdParametro = 'TIENDANUBETOKEN')
DECLARE @MercadoLibreToken      VARCHAR(MAX) = (SELECT TOP 1 ValorParametro FROM Parametros WHERE IdParametro = 'MERCADOLIBRETOKEN')
DECLARE @ArboreaUsuarioToken    VARCHAR(MAX) = (SELECT TOP 1 ValorParametro FROM Parametros WHERE IdParametro = 'ARBOREAUSUARIOTOKEN')

UPDATE Productos
   SET PublicarEnTiendaNube     = CASE WHEN @TiendaNubeToken     = '' THEN 0 ELSE 1 END
     , PublicarEnMercadoLibre   = CASE WHEN @MercadoLibreToken   = '' THEN 0 ELSE 1 END
     , PublicarEnArborea        = CASE WHEN @ArboreaUsuarioToken = '' THEN 0 ELSE 1 END
     , PublicarEnWeb = 0
 WHERE PublicarEnWeb = 1;

GO

IF dbo.ExisteCampo('AuditoriaProductos', 'PublicarEnTiendaNube') = 0
BEGIN
    ALTER TABLE dbo.AuditoriaProductos ADD PublicarEnTiendaNube bit NULL
    ALTER TABLE dbo.AuditoriaProductos ADD PublicarEnMercadoLibre bit NULL
    ALTER TABLE dbo.AuditoriaProductos ADD PublicarEnArborea bit NULL
END
GO
