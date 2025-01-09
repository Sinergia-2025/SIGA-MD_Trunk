SELECT C.IdSucursal, C.IdTipoComprobante, C.Letra, C.CentroEmisor, C.NumeroComprobante, 
       CONVERT(varchar(11), C.fecha, 120) as Fecha , C.IdCategoriaFiscal, C.Kilos, D.KilosDetalle

FROM
(
SELECT IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, Fecha, IdCategoriaFiscal, Kilos
 FROM Ventas
) C,
(
SELECT IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, SUM(Kilos) AS KilosDetalle
 FROM VentasProductos
 GROUP BY IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante
) D
 WHERE C.IdSucursal = D.IdSucursal 
   AND C.IdTipoComprobante = D.IdTipoComprobante
   AND C.Letra = D.Letra
   AND C.CentroEmisor = D.CentroEmisor
   AND C.NumeroComprobante = D.NumeroComprobante
   AND C.Kilos<>D.KilosDetalle
--   AND CONVERT(varchar(11), C.fecha, 120) >= '2010-04-07'
--   AND CONVERT(varchar(11), C.fecha, 120) <= '2010-04-07'


--   AND (C.IdTipoComprobante = 'COTIZACION' AND C.IdCategoriaFiscal=2)
   --- Busco Diferencias
--   AND (C.Kilos-D.KilosDetalle>1 or C.Kilos-D.KilosDetalle<-1)
ORDER BY C.IdCategoriaFiscal