PRINT ''
PRINT '1.- Nuevo Parametro: Generación de Pedidos Proveedores desde Pedidos de Clientes: Utiliza OC Obligatoria'
DECLARE @idParametro VARCHAR(MAX) = 'PEDIDOSGENPEDPROVOCOBLIGATORIA'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Generación de Pedidos Proveedores desde Pedidos de Clientes: Utiliza OC Obligatoria'
DECLARE @valorParametro VARCHAR(MAX) = 'False'
IF dbo.BaseConCuit('30714757128') = 'True'      --SOLO RDS ACE.
    SET @valorParametro = 'True'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;

PRINT ''
PRINT '2.- Parametro: Cambiar URL de Soporte al nuevo servidor'
UPDATE Parametros
   SET ValorParametro = REPLACE(ValorParametro, 'wi531792.ferozo.com/SSSSoporte', 'sinergiamovil.com.ar/SSSSoporte')
 WHERE ValorParametro LIKE '%wi531792.ferozo.com/SSSSoporte%'
