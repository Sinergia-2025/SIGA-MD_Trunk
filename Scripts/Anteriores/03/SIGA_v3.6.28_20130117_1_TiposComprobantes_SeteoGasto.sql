
--En caso de estar como NO Comercial, no sirve que tenga la marca de GrabaLibro, genera problemas.
UPDATE TiposComprobantes 
   SET GrabaLibro = 'False'
 WHERE IdTipoComprobante = 'GASTO'
   AND EsComercial = 'False'
   AND GrabaLibro = 'True'
GO
