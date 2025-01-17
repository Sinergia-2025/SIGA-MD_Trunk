
--SELECT C1.*
--  FROM Cajas C1, Cajas C2
--  WHERE C1.IdSucursal = C2.IdSucursal
--    AND C1.IdCaja = C2.IdCaja
--    AND C1.NumeroPlanilla = C2.NumeroPlanilla-1
--    AND C1.ChequesSaldoFinal <> C2.ChequesSaldoInicial
--GO

 
--SELECT C.*
--  FROM Cheques C
-- WHERE IdEstadoCheque = 'ENCARTERA'
--   AND NOT EXISTS 
--   ( SELECT * FROM CajasDetalle CD
--         WHERE CD.IdSucursal = C.IdSucursal 
--           AND CD.IdCaja = C.IdCajaIngreso
--           AND CD.NumeroPlanilla = C.NroPlanillaIngreso 
--           AND CD.NumeroMovimiento = C.NroMovimientoIngreso 
           
--     ) 
--GO


SELECT C.IdSucursal, C.IdCaja, C.NumeroPlanilla, C.FechaPlanilla, 
       C.ChequesSaldoInicial, C.ChequesSaldoFinal, D.TotalDetalle+C.ChequesSaldoInicial AS FinalDetalle
FROM
(
SELECT IdSucursal, IdCaja, NumeroPlanilla, FechaPlanilla, ChequesSaldoInicial, ChequesSaldoFinal
 FROM Cajas
) C,
(
SELECT IdSucursal, IdCaja, NumeroPlanilla, SUM(ImporteCheques) AS TotalDetalle
 FROM CajasDetalle
 GROUP BY IdSucursal, IdCaja, NumeroPlanilla
) D
 WHERE C.IdSucursal = D.IdSucursal 
   AND C.IdCaja = D.IdCaja
   AND C.NumeroPlanilla = D.NumeroPlanilla
--   AND CONVERT(varchar(11), C.fecha, 120) >= '2012-05-01'
--   AND CONVERT(varchar(11), C.fecha, 120) <= '2012-05-31'
--   AND (C.IdTipoComprobante = 'COTIZACION' AND C.IdCategoriaFiscal=2)
   --- Busco Diferencias
   AND D.TotalDetalle+C.ChequesSaldoInicial<>C.ChequesSaldoFinal
 --  AND (C.Subtotal-D.TotalDetalle>1 or C.Subtotal-D.TotalDetalle<-1)

ORDER BY 1,2,3
