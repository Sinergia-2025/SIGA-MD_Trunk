
ALTER TABLE CuentasCorrientes ADD IdEstadoComprobante varchar(10) NULL
GO

UPDATE CuentasCorrientes
  SET IdEstadoComprobante = 'NORMAL'
 WHERE IdTipoComprobante in ('RECIBO', 'RECIBOPROV')
GO
   
UPDATE CuentasCorrientes
  SET IdEstadoComprobante = 'ANULADO'
 WHERE IdTipoComprobante in ('RECIBO', 'RECIBOPROV')
   AND Observacion = '***ANULADO***'
   AND ImporteTotal = 0
GO
   
