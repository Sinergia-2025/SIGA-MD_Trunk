PRINT ''
PRINT '1. Correción del historial de las NC con Mercadería Sin Despachar'

UPDATE V SET MercDespachada = 1
FROM Ventas V 
INNER JOIN TiposComprobantes TC ON V.IdTipoComprobante = TC.IdTipoComprobante
WHERE V.MercDespachada = 0 AND TC.CoeficienteStock = -1