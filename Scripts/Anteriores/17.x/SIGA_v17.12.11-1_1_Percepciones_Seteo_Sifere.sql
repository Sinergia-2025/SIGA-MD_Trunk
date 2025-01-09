
-- Lo requiere Raymundo pero pero lo ejecutamos a todos.

UPDATE TiposComprobanteS SET CodigoComprobanteSifere = 'F'
 WHERE IdTipoComprobante LIKE '%FACT%';

UPDATE TiposComprobanteS SET CodigoComprobanteSifere = 'R'
 WHERE IdTipoComprobante LIKE '%RECIB%';

UPDATE TiposComprobanteS SET CodigoComprobanteSifere = 'D'
 WHERE IdTipoComprobante LIKE '%DEB%';

UPDATE TiposComprobanteS SET CodigoComprobanteSifere = 'C'
 WHERE IdTipoComprobante LIKE '%CRED%';
