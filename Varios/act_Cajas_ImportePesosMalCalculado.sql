
SELECT * FROM CajasDetalle
  WHERE IdCuentaCaja = 1
   AND ImportePesos>0 and (ImporteTarjetas>0 or ImporteCheques>0 or ImporteTickets>0)
GO

--EDITAR A MANO CajasDetalle!!!

UPDATE Cajas
  SET PesosSaldoFinal = 
      (SELECT SUM(ImportePesos) FROM CajasDetalle 
		WHERE IdSucursal = 1 
		  AND IdCaja = 1 
		  AND NumeroPlanilla <= 25)
 WHERE IdSucursal = 1 
   AND IdCaja = 1 
   AND NumeroPlanilla = 25
GO

--EDITAR A MANO Cajas!!! por saldo inicial del otro dia.

