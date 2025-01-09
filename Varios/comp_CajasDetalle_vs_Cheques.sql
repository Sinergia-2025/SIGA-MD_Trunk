
SELECT * FROM CajasDetalle
 WHERE ImporteCheques<0
   AND Observacion NOT LIKE '%ANULA%'
   AND NOT EXISTS 
     ( SELECT * FROM Cheques Cheq
       WHERE Cheq.IdCajaEgreso = CajasDetalle.IdCaja
         AND Cheq.NroPlanillaEgreso = CajasDetalle.NumeroPlanilla 
         AND Cheq.NroMovimientoEgreso = CajasDetalle.NumeroMovimiento 
     )
GO

---

--SELECT * FROM Cheques
-- WHERE IdCajaEgreso>0
--   AND NOT EXISTS 
--     ( SELECT * FROM CajasDetalle CD
--       WHERE CD.IdCaja = Cheques.IdCajaEgreso
--         AND CD.NumeroPlanilla = Cheques.NroPlanillaEgreso
--         AND CD.NumeroMovimiento = cheques.NroMovimientoEgreso
--     )
--GO
