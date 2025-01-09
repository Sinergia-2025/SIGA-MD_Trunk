DECLARE @ValorParametro varchar(max)
SET @ValorParametro = 'ESTANDAR';

-- RDS / RDS ACE
IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                                                     AND P.ValorParametro IN ('30714757128', '30714107220'))
BEGIN
    SET @ValorParametro = 'TALKIU';
END

MERGE INTO Parametros AS P
     USING (SELECT 'IMPORTARPEDIDOSFORMATOARCHIVO' AS IdParametro, @ValorParametro  ValorParametro, 'Formato Archivo Importación' AS DescripcionParametro
            ) AS PT ON P.IdParametro = PT.IdParametro
 WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro
 WHEN NOT MATCHED THEN INSERT (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL , PT.DescripcionParametro)
;

SELECT *
  FROM Parametros
 WHERE IdParametro = 'IMPORTARPEDIDOSFORMATOARCHIVO'
