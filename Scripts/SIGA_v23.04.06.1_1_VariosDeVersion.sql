UPDATE Clientes SET EsExentoPercIVARes53292023 = 'True';

UPDATE C
   SET EsExentoPercIVARes53292023 = 'False'
  FROM Clientes C
 INNER JOIN CategoriasFiscales CF ON CF.IdCategoriaFiscal = C.IdCategoriaFiscal
 WHERE CF.CondicionIvaImpresoraFiscalEpson = 'I';
GO
