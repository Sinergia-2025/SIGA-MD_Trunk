SELECT  C.FechaPlanilla, CD.FechaMovimiento, CD.NumeroPlanilla, CD.NumeroMovimiento, CD.Observacion, 
  CASE CD.IdTipoMovimiento 
    WHEN 'I' Then CD.ImportePesos+CD.ImporteDolares+CD.ImporteEuros+CD.ImporteCheques+CD.ImporteTarjetas
    WHEN 'E' Then 0
  END Ingreso,
  CASE CD.IdTipoMovimiento 
    WHEN 'I' Then 0
    WHEN 'E' Then CD.ImportePesos+CD.ImporteDolares+CD.ImporteEuros+CD.ImporteCheques+CD.ImporteTarjetas
  END Egreso
FROM  Cajas C, CajasDetalle CD
 WHERE C.IdSucursal=CD.IdSucursal
   AND C.NumeroPlanilla=CD.NumeroPlanilla
   AND C.idsucursal=1
   AND C.FechaPlanilla BETWEEN '20071201' AND '20091201'
   AND CD.IdCuentaCaja=2



