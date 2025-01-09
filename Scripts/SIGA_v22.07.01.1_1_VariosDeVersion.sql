PRINT ''
PRINT '1. Nuevo Parametro: EXPENSASPERMITIRCARGARPRODUCTOSSINCONCEPTOS'
DECLARE @idParametro VARCHAR(MAX) = 'EXPENSASPERMITIRCARGARPRODUCTOSSINCONCEPTOS'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Expensas: Permitir cargar productos sin Conceptos'
DECLARE @valorParametro VARCHAR(MAX) = 'False'
IF dbo.BaseConCuit('20163064120') = 1
    SET @valorParametro = 'True'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, IdParametro, ValorParametro, DescripcionParametro
                 FROM (
                     SELECT 'CLIENTEREQUIERETELEFONO'                AS IdParametro, 'False'         ValorParametro, '' DescripcionParametro UNION ALL
                     SELECT 'CLIENTEREQUIERECELULAR'                 AS IdParametro, @valorParametro ValorParametro, '' DescripcionParametro UNION ALL 
                     SELECT 'CLIENTEREQUIERECORREOELECTRONICO'       AS IdParametro, @valorParametro ValorParametro, '' DescripcionParametro UNION ALL
                     SELECT 'CLIENTEREQUIERECORREOADMINISTRATIVO'    AS IdParametro, @valorParametro ValorParametro, '' DescripcionParametro) P
                 CROSS JOIN Empresas
               ) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;

SELECT *
  FROM Parametros
 WHERE IdParametro IN ('CLIENTEREQUIERETELEFONO', 'CLIENTEREQUIERECELULAR', 'CLIENTEREQUIERECORREOELECTRONICO', 'CLIENTEREQUIERECORREOADMINISTRATIVO') 


PRINT ''
PRINT '2. Nuevo Parametro: EXPENSASPERMITIRCARGARPRODUCTOSSINCONCEPTOS'
ALTER TABLE dbo.CRMNovedadesCambiosEstados ADD IdSucursalNovedad int NULL
GO

UPDATE NCE
   SET IdSucursalNovedad = N.IdSucursalNovedad
  FROM CRMNovedadesCambiosEstados NCE
 INNER JOIN CRMNovedades N ON N.IdTipoNovedad = NCE.IdTipoNovedad
                          AND N.Letra = NCE.Letra
                          AND N.CentroEmisor = NCE.CentroEmisor
                          AND N.IdNovedad = NCE.IdNovedad
GO