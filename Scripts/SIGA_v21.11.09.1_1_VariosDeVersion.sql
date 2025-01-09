PRINT ''
PRINT 'A1. Facturacion V2 - Agrupa cantidades por Codigo de Producto.-'
BEGIN
    -- Inserto Registro.- --
    MERGE INTO Parametros AS DEST
    USING (
            SELECT IdEmpresa, 
                'FACTURACIONAGRUPACANTIDADESPRODUCTOS' AS IdParametro, 
                'False' ValorParametro, 
                'FacturacionV2' CategoriaParametro, 
                'FACTURACIONAGRUPACANTIDADESPRODUCTOS' DescripcionParametro FROM Empresas) AS ORIG 
            ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
        VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
END