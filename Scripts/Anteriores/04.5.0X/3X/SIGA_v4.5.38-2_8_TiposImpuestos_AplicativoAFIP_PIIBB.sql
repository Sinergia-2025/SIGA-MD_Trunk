
UPDATE TiposImpuestos
   SET AplicativoAfip = 'SIFERE'
 WHERE IdTipoImpuesto = 'PIIBB'
;

SELECT * FROM TiposImpuestos
 WHERE AplicativoAfip IS NOT NULL
;
