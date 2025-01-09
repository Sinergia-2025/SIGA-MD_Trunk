DELETE CuentasCorrientesPagos
 WHERE IdTipoComprobante = 'RECIBOPROV'
  AND NumeroComprobante = 259
GO

DELETE CuentasCorrientes
 WHERE IdTipoComprobante = 'RECIBOPROV'
  AND NumeroComprobante = 259
GO



SELECT * FROM CuentasCorrientesPagos
 WHERE IdTipoComprobante = 'COTIZACION'
  AND NumeroComprobante = 342
GO

SELECT * FROM CuentasCorrientes
 WHERE IdTipoComprobante = 'COTIZACION'
  AND NumeroComprobante = 342
GO

UPDATE CuentasCorrientes
 SET Saldo = ImporteTotal
 WHERE IdTipoComprobante = 'COTIZACION'
  AND NumeroComprobante = 342
GO



