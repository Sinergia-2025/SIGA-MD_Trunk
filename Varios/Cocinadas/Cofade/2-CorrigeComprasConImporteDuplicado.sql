UPDATE CajasDetalle
   SET ImportePesos = 0
  FROM Compras C
 INNER JOIN CajasDetalle CD ON CONVERT(DATE, CD.FechaMovimiento) = C.Fecha 
                           AND CD.ImportePesos = C.ImportePesos * -1
                           AND CD.ImporteTarjetas = C.ImporteTarjetas * -1
                           AND CD.ImporteBancos = C.ImporteTransfBancaria * -1
 WHERE C.ImportePesos + C.ImporteTarjetas + C.ImporteTransfBancaria > C.ImporteTotal
   AND C.ImportePesos + C.ImporteTarjetas + C.ImporteTransfBancaria <> 0

UPDATE Compras
   SET ImportePesos = 0
  FROM Compras C
 WHERE C.ImportePesos + C.ImporteTarjetas + C.ImporteTransfBancaria > C.ImporteTotal
   AND C.ImportePesos + C.ImporteTarjetas + C.ImporteTransfBancaria <> 0
