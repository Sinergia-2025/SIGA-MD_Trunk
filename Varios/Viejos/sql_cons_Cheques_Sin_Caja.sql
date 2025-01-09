SELECT * FROM Cheques
 WHERE NOT EXISTS 
     ( SELECT * FROM CajasDetalle CD
       WHERE CD.NumeroPlanilla = Cheques.NroPlanillaIngreso
         AND CD.NumeroMovimiento = Cheques.NroMovimientoIngreso
     )

