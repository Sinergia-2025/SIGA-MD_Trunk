
--SELECT * FROM Retenciones
--GO

INSERT INTO CajasDetalle
   (IdSucursal, IdCaja, NumeroPlanilla, NumeroMovimiento, FechaMovimiento, IdCuentaCaja, IdTipoMovimiento
   ,ImportePesos, ImporteDolares, ImporteEuros, ImporteCheques, ImporteTarjetas, Observacion
   ,EsModificable, ImporteTickets, IdUsuario, PeriodoContable)
SELECT R.IdSucursal, R.IdCajaIngreso AS IdCaja, CD2.PlanMaxima
     , 500+ROW_NUMBER() OVER(ORDER BY R.IdSucursal, R.IdCajaIngreso, R.FechaEmision) AS Movimiento
     , R.FechaEmision, CD.IdCuentaCaja, 'I' AS IdTipoMovimiento, R.ImporteTotal AS ImportePesos
     , 0 AS ImporteDolares, 0 AS ImporteEuros, 0 AS ImporteCheques, 0 AS ImporteTarjetas, CD.Observacion
     , CD.EsModificable, 0 AS ImporteTickets, CD.IdUsuario, NULL AS PeriodoContable
  FROM Retenciones R, CajasDetalle CD,
    (SELECT IdSucursal, IdCaja, MAX(NumeroPlanilla) AS PlanMaxima FROM CajasDetalle
       GROUP BY IdSucursal, IdCaja) CD2
 WHERE R.IdSucursal = CD.IdSucursal AND R.IdCajaIngreso=CD.IdCaja AND R.NroPlanillaIngreso=CD.NumeroPlanilla AND R.NroMovimientoIngreso=CD.NumeroMovimiento
   AND R.IdSucursal = CD2.IdSucursal AND R.IdCajaIngreso=CD2.IdCaja
 ORDER BY R.IdSucursal, R.IdCajaIngreso, R.FechaEmision
GO

INSERT INTO CajasDetalle
   (IdSucursal, IdCaja, NumeroPlanilla, NumeroMovimiento, FechaMovimiento, IdCuentaCaja, IdTipoMovimiento
   ,ImportePesos, ImporteDolares, ImporteEuros, ImporteCheques, ImporteTarjetas, Observacion
   ,EsModificable, ImporteTickets, IdUsuario, PeriodoContable)
SELECT R.IdSucursal, R.IdCajaIngreso AS IdCaja, CD2.PlanMaxima
     , 600+ROW_NUMBER() OVER(ORDER BY R.IdSucursal, R.IdCajaIngreso, R.FechaEmision) AS Movimiento
     , R.FechaEmision, TI.IdCuentaCaja, 'E' AS IdTipoMovimiento, -R.ImporteTotal AS ImportePesos
     , 0 AS ImporteDolares, 0 AS ImporteEuros, 0 AS ImporteCheques, 0 AS ImporteTarjetas, CD.Observacion
     , CD.EsModificable, 0 AS ImporteTickets, CD.IdUsuario, NULL AS PeriodoContable
  FROM Retenciones R, TiposImpuestos TI, CajasDetalle CD,
    (SELECT IdSucursal, IdCaja, MAX(NumeroPlanilla) AS PlanMaxima FROM CajasDetalle
       GROUP BY IdSucursal, IdCaja) CD2
 WHERE R.IdTipoImpuesto = TI.IdTipoImpuesto
    AND R.IdSucursal = CD.IdSucursal AND R.IdCajaIngreso=CD.IdCaja AND R.NroPlanillaIngreso=CD.NumeroPlanilla AND R.NroMovimientoIngreso=CD.NumeroMovimiento
    AND R.IdSucursal = CD2.IdSucursal AND R.IdCajaIngreso=CD2.IdCaja
GO

