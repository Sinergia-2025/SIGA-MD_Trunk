
SELECT * FROM CajasDetalle 
WHERE EXISTS
(
-- IdSucursal, NumeroPlanilla 
SELECT IdCaja ,NumeroMovimiento ,FechaMovimiento ,IdCuentaCaja ,IdTipoMovimiento 
      ,ImportePesos ,ImporteDolares ,ImporteEuros ,ImporteCheques ,ImporteTarjetas ,Observacion ,EsModificable 
      ,ImporteTickets ,IdUsuario ,ImporteBancos ,ImporteRetenciones ,IdPlanCuenta ,IdAsiento 
      ,count(*) AS Registros
  FROM CajasDetalle A
 WHERE CajasDetalle.IdCaja = A.IdCaja
   AND CajasDetalle.NumeroMovimiento = A.NumeroMovimiento
   AND CajasDetalle.FechaMovimiento = A.FechaMovimiento
   AND CajasDetalle.IdCuentaCaja = A.IdCuentaCaja
   AND CajasDetalle.IdTipoMovimiento  = A.IdTipoMovimiento
   AND CajasDetalle.ImportePesos = A.ImportePesos
   AND CajasDetalle.ImporteDolares = A.ImporteDolares
   AND CajasDetalle.ImporteEuros = A.ImporteEuros
   AND CajasDetalle.ImporteCheques = A.ImporteCheques
   AND CajasDetalle.ImporteTarjetas = A.ImporteTarjetas
   AND CajasDetalle.Observacion = A.Observacion
   AND CajasDetalle.EsModificable  = A.EsModificable
   AND CajasDetalle.ImporteTickets = A.ImporteTickets
   AND CajasDetalle.IdUsuario = A.IdUsuario
   AND CajasDetalle.ImporteBancos = A.ImporteBancos
   AND CajasDetalle.ImporteRetenciones = A.ImporteRetenciones
--   AND Observacion LIKE '%Provisorio%'

--   AND CajasDetalle.IdPlanCuenta = A.IdPlanCuenta
--   AND CajasDetalle.IdAsiento = A.IdAsiento
  
  GROUP BY IdCaja ,NumeroMovimiento ,FechaMovimiento ,IdCuentaCaja ,IdTipoMovimiento 
      ,ImportePesos ,ImporteDolares ,ImporteEuros ,ImporteCheques ,ImporteTarjetas ,Observacion ,EsModificable 
      ,ImporteTickets ,IdUsuario ,ImporteBancos ,ImporteRetenciones ,IdPlanCuenta ,IdAsiento 
  having count(*)>1
) 
  ORDER BY IdCaja ,FechaMovimiento ,NumeroMovimiento 