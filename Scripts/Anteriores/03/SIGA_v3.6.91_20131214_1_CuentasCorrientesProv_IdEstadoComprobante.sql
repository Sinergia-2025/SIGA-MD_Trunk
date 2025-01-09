
ALTER TABLE CuentasCorrientesProv ADD IdEstadoComprobante varchar(10) NULL
GO

UPDATE CuentasCorrientesProv
  SET IdEstadoComprobante = 'NORMAL'
 WHERE IdTipoComprobante in ('PAGO', 'PAGOPROV')
GO
   
UPDATE CuentasCorrientesProv
  SET IdEstadoComprobante = 'ANULADO'
 WHERE IdTipoComprobante in ('PAGO', 'PAGOPROV')
   AND Observacion = '***ANULADO***'
   AND ImporteTotal = 0
GO
   
