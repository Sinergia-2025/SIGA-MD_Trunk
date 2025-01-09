
UPDATE CuentasCorrientes
   SET Fecha = CONVERT(datetime, '2012-11-07 18:26:20', 21)
      ,FechaVencimiento = CONVERT(datetime, '2012-11-07 18:26:20', 21)
 WHERE IdSucursal = 1
   AND IdTipoComprobante = 'RECIBO'
   AND Letra = 'X'
   AND CentroEmisor = 1
   AND NumeroComprobante = 378
GO

UPDATE CuentasCorrientesPagos
   SET Fecha = CONVERT(datetime, '2012-11-07 18:26:20', 21)
      ,FechaVencimiento = CONVERT(datetime, '2012-11-07 18:26:20', 21)
 WHERE IdSucursal = 1
   AND IdTipoComprobante = 'RECIBO'
   AND Letra = 'X'
   AND CentroEmisor = 1
   AND NumeroComprobante = 378
GO

UPDATE CajasDetalle
   SET FechaMovimiento = CONVERT(datetime, '2012-11-07 18:26:20', 21)
WHERE EXISTS 
     ( SELECT * FROM CuentasCorrientes CC
		WHERE CC.IdSucursal = 1
		  AND CC.IdTipoComprobante = 'RECIBO'
		  AND CC.Letra = 'X'
		  AND CC.CentroEmisor = 1
		  AND CC.NumeroComprobante = 378
		  AND CC.IdSucursal = CajasDetalle.IdSucursal
		  AND CC.IdCaja = CajasDetalle.IdCaja
		  AND CC.NumeroPlanilla = CajasDetalle.NumeroPlanilla
		  AND CC.NumeroMovimiento = CajasDetalle.NumeroMovimiento
     )
GO  


SELECT * FROM CuentasCorrientes
 WHERE IdSucursal = 1
   AND IdTipoComprobante = 'RECIBO'
   AND Letra = 'X'
   AND CentroEmisor = 1
   AND NumeroComprobante = 378
GO

SELECT * FROM CuentasCorrientesPagos
 WHERE IdSucursal = 1
   AND IdTipoComprobante = 'RECIBO'
   AND Letra = 'X'
   AND CentroEmisor = 1
   AND NumeroComprobante = 378
GO

SELECT * FROM CajasDetalle
WHERE EXISTS 
     ( SELECT * FROM CuentasCorrientes CC
		WHERE CC.IdSucursal = 1
		  AND CC.IdTipoComprobante = 'RECIBO'
		  AND CC.Letra = 'X'
		  AND CC.CentroEmisor = 1
		  AND CC.NumeroComprobante = 378
		  AND CC.IdSucursal = CajasDetalle.IdSucursal
		  AND CC.IdCaja = CajasDetalle.IdCaja
		  AND CC.NumeroPlanilla = CajasDetalle.NumeroPlanilla
		  AND CC.NumeroMovimiento = CajasDetalle.NumeroMovimiento
     )
GO  
