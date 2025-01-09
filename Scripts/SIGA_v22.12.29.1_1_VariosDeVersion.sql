PRINT ''
PRINT '1. Tabla ClientesParametros: Cambiar tamaño ValorParametro a VARCHAR(MAX)'
ALTER TABLE ClientesParametros ALTER COLUMN ValorParametro VARCHAR(MAX) NULL


PRINT ''
PRINT '2. Tabla MovimientosVentasProductosLotes: Corregir Cantidad cuando es NC'
UPDATE MVPL
   SET MVPL.Cantidad = MVPL.Cantidad * -1
  FROM MovimientosVentasProductos MVP
 INNER JOIN MovimientosVentasProductosLotes MVPL
    ON MVPL.IdSucursal          = MVP.IdSucursal
   AND MVPL.IdTipoMovimiento    = MVP.IdTipoMovimiento
   AND MVPL.NumeroMovimiento    = MVP.NumeroMovimiento
   AND MVPL.IdProducto          = MVP.IdProducto
   AND MVPL.Orden               = MVP.Orden
   AND MVP.Cantidad / ABS(MVP.Cantidad) <> MVPL.Cantidad / ABS(MVPL.Cantidad)


PRINT ''
PRINT '3. Nuevo parámetro: Actualiza Categorias de Producto Arborea.-'
MERGE INTO Parametros AS DEST
USING (
        SELECT IdEmpresa, 
            'ARBOREAACTUALIZACATEGORIA' AS IdParametro, 
            'AMBAS' ValorParametro, 
            'Arborea' CategoriaParametro, 
            'Actualizacion Categorías' DescripcionParametro FROM Empresas) AS ORIG 
        ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
WHEN MATCHED THEN
    UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
WHEN NOT MATCHED THEN 
    INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
    VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);


PRINT ''
PRINT '3. Tabla Proyectos: Agrego Campo HsInformadas.'
IF dbo.ExisteCampo('Proyectos', 'HsInformadas') = 0
BEGIN
	ALTER TABLE dbo.Proyectos ADD HsInformadas decimal(8, 2) NULL
END
GO

UPDATE dbo.Proyectos SET HsInformadas = 0 WHERE HsInformadas IS NULL;

ALTER TABLE dbo.Proyectos ALTER COLUMN HsInformadas decimal(8, 2) NOT NULL;
GO
