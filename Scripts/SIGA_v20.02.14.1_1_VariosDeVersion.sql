PRINT ''
PRINT '1. Correci�n del historial de las NC con Mercader�a Sin Despachar'

UPDATE V SET MercDespachada = 1
FROM Ventas V 
INNER JOIN TiposComprobantes TC ON V.IdTipoComprobante = TC.IdTipoComprobante
WHERE V.MercDespachada = 0 AND TC.CoeficienteStock = -1