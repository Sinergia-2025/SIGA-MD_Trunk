UPDATE Impresoras
   SET Metodo = 'DLLsV2'
  FROM Impresoras
 WHERE Modelo IN ('TM-900AF', 'SMH/P-250F2g')

IF dbo.BaseConCuit('20255840720') = 'True'
BEGIN
    UPDATE Impresoras
       SET Metodo = 'DLLsV2'
      FROM Impresoras
     WHERE TipoImpresora = 'FISCAL'
END
