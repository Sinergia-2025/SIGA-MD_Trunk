PRINT ''
PRINT '1. Parametro: MRP: Tipo Comprobante Orden de Produccion en Planificacion'
DECLARE @idParametro VARCHAR(MAX) = 'ESTADOFINALORDENPRODUCCION'
DECLARE @descripcionParametro VARCHAR(MAX) = 'MRP: Estado que toma la orden de producción al finalizar la misma.'
DECLARE @valorParametro VARCHAR(MAX) = NULL

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, 'MRP', ORIG.DescripcionParametro)
;
GO
PRINT ''
PRINT '2. Parametro: MRP: Estado de orden de compra A Vincular en funcionalidad Talleres externos'
DECLARE @idParametro VARCHAR(MAX) = 'ESTADOORDENCOMPRAAVINCULAR'
DECLARE @descripcionParametro VARCHAR(MAX) = 'MRP: Estado de orden de compra A Vincular en funcionalidad Talleres externos.'
DECLARE @valorParametro VARCHAR(MAX) = NULL

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, 'MRP', ORIG.DescripcionParametro)
;
GO
PRINT ''
PRINT '3. Parametro: MRP: Estado de orden de compra vinculada en funcionalidad Talleres externos'
DECLARE @idParametro VARCHAR(MAX) = 'ESTADOORDENCOMPRAVINCULADA'
DECLARE @descripcionParametro VARCHAR(MAX) = 'MRP: Estado de orden de compra vinculada en funcionalidad Talleres externos.'
DECLARE @valorParametro VARCHAR(MAX) = NULL

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, 'MRP', ORIG.DescripcionParametro)
;
GO
PRINT ''
PRINT '4. Parametro: MRP: Operario que informa productos necesarios en funcionalidad Talleres externos'
DECLARE @idParametro VARCHAR(MAX) = 'OPERARIOINFORMATALLERESEXTERNOS' 
DECLARE @descripcionParametro VARCHAR(MAX) = 'MRP: Operario que informa productos necesarios en funcionalidad Talleres externos.'
DECLARE @valorParametro VARCHAR(MAX) = 0

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, 'MRP', ORIG.DescripcionParametro)
;
GO
