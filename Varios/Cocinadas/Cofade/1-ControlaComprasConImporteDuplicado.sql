SELECT C.IdTipoComprobante + ' ' + C.Letra + ' ' + CONVERT(VARCHAR(MAX), C.CentroEmisor) + '-' + CONVERT(VARCHAR(MAX), C.NumeroComprobante) Comprobante
     , C.IdProveedor
     , CD.IdCaja
     , CD.NumeroPlanilla
     , CD.NumeroMovimiento
     , C.Fecha
     , C.ImportePesos
     , C.ImporteTarjetas
     , C.ImporteTransfBancaria

     , CD.ImportePesos
     , CD.ImporteTarjetas
     , CD.ImporteBancos

  FROM Compras C
 INNER JOIN CajasDetalle CD ON CONVERT(DATE, CD.FechaMovimiento) = C.Fecha 
                           AND CD.ImportePesos = C.ImportePesos * -1
                           AND CD.ImporteTarjetas = C.ImporteTarjetas * -1
                           AND CD.ImporteBancos = C.ImporteTransfBancaria * -1
 WHERE C.ImportePesos + C.ImporteTarjetas + C.ImporteTransfBancaria > C.ImporteTotal
   AND C.ImportePesos + C.ImporteTarjetas + C.ImporteTransfBancaria <> 0
 ORDER BY C.Fecha

--SELECT C.IdTipoComprobante + ' ' + C.Letra + ' ' + CONVERT(VARCHAR(MAX), C.CentroEmisor) + '-' + CONVERT(VARCHAR(MAX), C.NumeroComprobante) Comprobante
--     , C.IdProveedor
--     , C.Fecha
--     , C.ImportePesos
--     , C.ImporteTarjetas
--     , C.ImporteTransfBancaria

--  FROM Compras C
-- WHERE C.ImportePesos + C.ImporteTarjetas + C.ImporteTransfBancaria > C.ImporteTotal
--   AND C.ImportePesos + C.ImporteTarjetas + C.ImporteTransfBancaria <> 0
-- ORDER BY C.Fecha
