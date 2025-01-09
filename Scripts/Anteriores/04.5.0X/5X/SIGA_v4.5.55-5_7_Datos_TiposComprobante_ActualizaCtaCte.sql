
UPDATE TiposComprobantes
   SET ActualizaCtaCte = 'True'
 WHERE IdTipoComprobante = 'FICHAS'
;

SELECT ActualizaCtaCte, *
  FROM TiposComprobantes
 WHERE IdTipoComprobante = 'FICHAS'
;
