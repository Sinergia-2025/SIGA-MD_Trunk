
--reviso movimientos con transferencias
SELECT * FROM CuentasCorrientesProv
 WHERE IdCaja = 2
   AND NumeroPlanilla = 5
   AND ImporteTransfBancaria <> 0
   AND NumeroComprobante <> 212 --Pago con formato nuevo
 ORDER BY NumeroMovimiento
GO


--le bajo en 1 el numero de movimiento porque el primero es el del concepto Pago. El actual es Transferncia (Compensa)
UPDATE CuentasCorrientesProv
   SET NumeroMovimiento = NumeroMovimiento - 1
 WHERE IdCaja = 2
   AND NumeroPlanilla = 5
   AND ImporteTransfBancaria <> 0
   AND NumeroComprobante <> 212
GO

--Miro los conceptos de Transferncia (Compensacion)
SELECT * FROM CajasDetalle
 WHERE IdCaja = 2
   AND NumeroPlanilla = 5
   AND NumeroMovimiento IN 
(
SELECT NumeroMovimiento + 1 FROM CuentasCorrientesProv
 WHERE IdCaja = 2
   AND NumeroPlanilla = 5
   AND ImporteTransfBancaria <> 0
   AND NumeroComprobante <> 212
 )
GO


--Borro los conceptos de Transferncia (Compensacion)
DELETE CajasDetalle
 WHERE IdCaja = 2
   AND NumeroPlanilla = 5
   AND NumeroMovimiento IN 
(
SELECT NumeroMovimiento + 1 FROM CuentasCorrientesProv
 WHERE IdCaja = 2
   AND NumeroPlanilla = 5
   AND ImporteTransfBancaria <> 0
   AND NumeroComprobante <> 212
 )
GO

--Miro los conceptos de Pesos (Transferncia) que voy a mover a Banco
SELECT * FROM CajasDetalle
 WHERE IdCaja = 2
   AND NumeroPlanilla = 5
   AND NumeroMovimiento IN 
(
SELECT NumeroMovimiento FROM CuentasCorrientesProv
 WHERE IdCaja = 2
   AND NumeroPlanilla = 5
   AND ImporteTransfBancaria <> 0
   AND NumeroComprobante <> 212
 )
GO

--Transfieron de los conceptos de Pesos (Transferncia) a Banco
UPDATE CajasDetalle
   SET ImporteBancos = ImportePesos
 WHERE IdCaja = 2
   AND NumeroPlanilla = 5
   AND NumeroMovimiento IN 
(
SELECT NumeroMovimiento FROM CuentasCorrientesProv
 WHERE IdCaja = 2
   AND NumeroPlanilla = 5
   AND ImporteTransfBancaria <> 0
   AND NumeroComprobante <> 212
 )
GO
 
--Limpio de los conceptos de Pesos 
UPDATE CajasDetalle
   SET ImportePesos = 0
 WHERE IdCaja = 2
   AND NumeroPlanilla = 5
   AND NumeroMovimiento IN 
(
SELECT NumeroMovimiento FROM CuentasCorrientesProv
 WHERE IdCaja = 2
   AND NumeroPlanilla = 5
   AND ImporteTransfBancaria <> 0
   AND NumeroComprobante <> 212
 )
GO

---Queda mal si tuvo retenciones, arreglarlo a mano.
SELECT * FROM CuentasCorrientesProv
 WHERE IdCaja = 2
   AND NumeroPlanilla = 5
   AND ImporteTransfBancaria <> 0
   AND ImporteRetenciones <> 0
   AND NumeroComprobante <> 212
GO


SELECT * FROM CajasDetalle
 WHERE IdCaja = 2
   AND NumeroPlanilla = 5
   AND NumeroMovimiento IN 
(
SELECT NumeroMovimiento FROM CuentasCorrientesProv
 WHERE IdCaja = 2
   AND NumeroPlanilla = 5
   AND ImporteTransfBancaria <> 0
   AND ImporteRetenciones <> 0
   AND NumeroComprobante <> 212
 )
GO
