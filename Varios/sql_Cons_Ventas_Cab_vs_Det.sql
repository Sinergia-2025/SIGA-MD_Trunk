SELECT C.IdSucursal, C.IdTipoComprobante, C.Letra, C.CentroEmisor, C.NumeroComprobante, 
       CONVERT(varchar(11), C.fecha, 120) as Fecha , C.IdCategoriaFiscal, C.SubTotal, 
       C.TotalImpuestos, C.ImporteTotal, D.TotalDetalle

FROM
(
SELECT IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, Fecha, IdCategoriaFiscal, SubTotal, TotalImpuestos, ImporteTotal
 FROM Ventas
) C,
(
SELECT IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, SUM(ImporteTotalNeto) AS TotalDetalle
 FROM VentasProductos
 GROUP BY IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante
) D
 WHERE C.IdSucursal = D.IdSucursal 
   AND C.IdTipoComprobante = D.IdTipoComprobante
   AND C.Letra = D.Letra
   AND C.CentroEmisor = D.CentroEmisor
   AND C.NumeroComprobante = D.NumeroComprobante
--   AND CONVERT(varchar(11), C.fecha, 120) >= '2012-05-01'
--   AND CONVERT(varchar(11), C.fecha, 120) <= '2012-05-31'
--   AND (C.IdTipoComprobante = 'COTIZACION' AND C.IdCategoriaFiscal=2)
   --- Busco Diferencias
   AND C.Subtotal<>D.TotalDetalle
 --  AND (C.Subtotal-D.TotalDetalle>1 or C.Subtotal-D.TotalDetalle<-1)

ORDER BY C.IdCategoriaFiscal