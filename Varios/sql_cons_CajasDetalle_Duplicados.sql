-- IdSucursal, NumeroPlanilla 

SELECT IdCaja ,NumeroMovimiento ,FechaMovimiento ,IdCuentaCaja ,IdTipoMovimiento 
      ,ImportePesos ,ImporteDolares ,ImporteEuros ,ImporteCheques ,ImporteTarjetas ,Observacion ,EsModificable 
      ,ImporteTickets ,IdUsuario ,ImporteBancos ,ImporteRetenciones ,IdPlanCuenta ,IdAsiento 
      ,COUNT(*) AS Registros
  FROM CajasDetalle
  GROUP BY IdCaja ,NumeroMovimiento ,FechaMovimiento ,IdCuentaCaja ,IdTipoMovimiento 
      ,ImportePesos ,ImporteDolares ,ImporteEuros ,ImporteCheques ,ImporteTarjetas ,Observacion ,EsModificable 
      ,ImporteTickets ,IdUsuario ,ImporteBancos ,ImporteRetenciones ,IdPlanCuenta ,IdAsiento 
  HAVING COUNT(*)>1
  ORDER BY IdCaja ,FechaMovimiento ,NumeroMovimiento  --,IdSucursal
  