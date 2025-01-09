
--reviso movimientos con transferencias
SELECT * FROM CuentasCorrientes
 WHERE IdCaja = 2
   AND NumeroPlanilla = 5
   AND ImporteTransfBancaria <> 0
   AND NumeroComprobante <> 82 --Recibo con formato nuevo
 ORDER BY NumeroMovimiento
GO


--le bajo en 1 el numero de movimiento porque el primero es el del concepto RECIBO. El actual es Transferncia (Compensa)
UPDATE CuentasCorrientes
   SET NumeroMovimiento = NumeroMovimiento - 1
 WHERE IdCaja = 2
   AND NumeroPlanilla = 5
   AND ImporteTransfBancaria <> 0
   AND NumeroComprobante <> 82
GO

--Miro los conceptos de Transferncia (Compensacion)
SELECT * FROM CajasDetalle
 WHERE IdCaja = 2
   AND NumeroPlanilla = 5
   AND NumeroMovimiento IN 
(
SELECT NumeroMovimiento + 1 FROM CuentasCorrientes
 WHERE IdCaja = 2
   AND NumeroPlanilla = 5
   AND ImporteTransfBancaria <> 0
   AND NumeroComprobante <> 82
 )
GO


--Borro los conceptos de Transferncia (Compensacion)
DELETE CajasDetalle
 WHERE IdCaja = 2
   AND NumeroPlanilla = 5
   AND NumeroMovimiento IN 
(
SELECT NumeroMovimiento + 1 FROM CuentasCorrientes
 WHERE IdCaja = 2
   AND NumeroPlanilla = 5
   AND ImporteTransfBancaria <> 0
   AND NumeroComprobante <> 82
 )
GO

--Miro los conceptos de Pesos (Transferncia) que voy a mover a Banco
SELECT * FROM CajasDetalle
 WHERE IdCaja = 2
   AND NumeroPlanilla = 5
   AND NumeroMovimiento IN 
(
SELECT NumeroMovimiento FROM CuentasCorrientes
 WHERE IdCaja = 2
   AND NumeroPlanilla = 5
   AND ImporteTransfBancaria <> 0
   AND NumeroComprobante <> 82
 )
GO

--Transfieron de los conceptos de Pesos (Transferncia) a Banco
UPDATE CajasDetalle
   SET ImporteBancos = ImportePesos
 WHERE IdCaja = 2
   AND NumeroPlanilla = 5
   AND NumeroMovimiento IN 
(
SELECT NumeroMovimiento FROM CuentasCorrientes
 WHERE IdCaja = 2
   AND NumeroPlanilla = 5
   AND ImporteTransfBancaria <> 0
   AND NumeroComprobante <> 82
 )
GO
 
--Limpio de los conceptos de Pesos 
UPDATE CajasDetalle
   SET ImportePesos = 0
 WHERE IdCaja = 2
   AND NumeroPlanilla = 5
   AND NumeroMovimiento IN 
(
SELECT NumeroMovimiento FROM CuentasCorrientes
 WHERE IdCaja = 2
   AND NumeroPlanilla = 5
   AND ImporteTransfBancaria <> 0
   AND NumeroComprobante <> 82
 )
GO

---Queda mal si tuvo retenciones, arreglarlo a mano.
SELECT * FROM CuentasCorrientes
 WHERE IdCaja = 2
   AND NumeroPlanilla = 5
   AND ImporteTransfBancaria <> 0
   AND ImporteRetenciones <> 0
   AND NumeroComprobante <> 82
GO


SELECT * FROM CajasDetalle
 WHERE IdCaja = 2
   AND NumeroPlanilla = 5
   AND NumeroMovimiento IN 
(
SELECT NumeroMovimiento FROM CuentasCorrientes
 WHERE IdCaja = 2
   AND NumeroPlanilla = 5
   AND ImporteTransfBancaria <> 0
   AND ImporteRetenciones <> 0
   AND NumeroComprobante <> 82
 )
GO
