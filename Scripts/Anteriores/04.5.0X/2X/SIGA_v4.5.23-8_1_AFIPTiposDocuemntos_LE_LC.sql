 
UPDATE AFIPTiposDocumentos
   SET TipoDocumento='LE'
 where IdAFIPTipoDocumento=89
  and TipoDocumento is null
GO

UPDATE AFIPTiposDocumentos
   SET TipoDocumento='LC'
 where IdAFIPTipoDocumento=90
  and TipoDocumento is null
GO
