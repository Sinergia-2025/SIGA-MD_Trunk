
INSERT INTO CajasDetalle
     (IdSucursal, IdCaja, NumeroPlanilla, NumeroMovimiento, FechaMovimiento, IdCuentaCaja
     ,IdTipoMovimiento, ImportePesos, ImporteDolares, ImporteEuros, ImporteCheques, ImporteTarjetas
     ,ImporteTickets, Observacion, EsModificable, IdUsuario, PeriodoContable)
 VALUES
     (1, 1, 771, 72, '20130830 22:00:00', 17
     ,'I', 0, 0, 0, 19036.77, 0
     ,0, 'POR DIFERENCIA DE CAJA NO ENCONTRADA. NO HAY FALTANTES DE CHEQUES.', 'True', 'admin', NULL)
GO

-- Saldo Final de la Caja con problemas
UPDATE Cajas
  SET ChequesSaldoFinal = ChequesSaldoFinal + 19036.77
 WHERE IdSucursal = 1 AND IdCaja = 1 AND NumeroPlanilla = 771
GO

-- El resto de las cajas
UPDATE Cajas
  SET ChequesSaldoInicial = ChequesSaldoInicial + 19036.77
     ,ChequesSaldoFinal = ChequesSaldoFinal + 19036.77
 WHERE IdSucursal = 1 AND IdCaja = 1 AND NumeroPlanilla > 771
--  AND NumeroPlanilla < (SELECT MAX(NumeroPlanilla) FROM Cajas) 
GO

-- Ultima Caja (en caso de estar abierta).
--UPDATE Cajas
--  SET ChequesSaldoInicial = ChequesSaldoInicial + 19036.77
-- WHERE IdSucursal = 1 AND IdCaja = 1
--   AND NumeroPlanilla = (SELECT MAX(NumeroPlanilla) FROM Cajas) 
--GO

