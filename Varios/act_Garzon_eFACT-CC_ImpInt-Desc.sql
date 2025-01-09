UPDATE VentasProductos
   SET PrecioNeto = CONVERT(decimal(9,4), VP.Precio * (1 + (VP.DescuentoRecargoPorc / 100)) 
                                                    * (1 + (VP.DescuentoRecargoPorc2 / 100))
                                                    * (1 + (V.DescuentoRecargoPorc / 100)))
     , DescuentoRecargo = CONVERT(decimal(9,4), ((VP.Precio * VP.DescuentoRecargoPorc / 100) +
                                                 (VP.Precio + (VP.Precio * VP.DescuentoRecargoPorc / 100)) * VP.DescuentoRecargoPorc2 / 100) * VP.Cantidad)
     , DescuentoRecargoProducto = CONVERT(decimal(9,4), ((VP.Precio * VP.DescuentoRecargoPorc / 100) +
                                                         (VP.Precio + (VP.Precio * VP.DescuentoRecargoPorc / 100)) * VP.DescuentoRecargoPorc2 / 100))
     , DescRecGeneral = CONVERT(decimal(9,2), VP.Precio * ((V.DescuentoRecargoPorc / 100)) * VP.Cantidad)
     , DescRecGeneralProducto = CONVERT(decimal(9,2), VP.Precio * ((V.DescuentoRecargoPorc / 100)))
     --, ImporteTotalNeto = CONVERT(decimal(9,2), VP.Precio * (1 + (VP.DescuentoRecargoPorc / 100)) 
     --                                                     * (1 + (VP.DescuentoRecargoPorc2 / 100))
     --                                                     * (1 + (V.DescuentoRecargoPorc / 100)) * VP.Cantidad)
     , Utilidad = CONVERT(decimal(9,4),((VP.Precio * (1 + (VP.DescuentoRecargoPorc / 100))
                                                   * (1 + (VP.DescuentoRecargoPorc2 / 100))
                                                   * (1 + (V.DescuentoRecargoPorc / 100))) - VP.Costo) * VP.Cantidad)
  FROM Ventas V
 INNER JOIN VentasProductos VP ON V.IdSucursal = VP.IdSucursal
                    AND V.IdTipoComprobante = VP.IdTipoComprobante
                    AND V.Letra = VP.Letra
                    AND V.CentroEmisor = VP.CentroEmisor
                    AND V.NumeroComprobante = VP.NumeroComprobante
 WHERE (V.DescuentoRecargoPorc <> 0 AND 
        VP.DescRecGeneral = 0 AND 
        V.TotalImpuestoInterno <> 0 AND
        VP.ImporteImpuestoInterno <> 0 AND
        V.IdTipoComprobante = 'eFACT-CC')
    OR (VP.DescuentoRecargoPorc <> 0  AND 
        VP.DescuentoRecargo = 0 AND 
        VP.DescuentoRecargoProducto = 0 AND 
        VP.ImporteImpuestoInterno <> 0 AND 
        VP.PorcImpuestoInterno = 0 AND
        V.IdTipoComprobante = 'eFACT-CC')

UPDATE V
   SET Utilidad = ROUND((SELECT SUM(VP.Utilidad)
                           FROM VentasProductos VP
                          WHERE V.IdSucursal = VP.IdSucursal
                            AND V.IdTipoComprobante = VP.IdTipoComprobante
                            AND V.Letra = VP.Letra
                            AND V.CentroEmisor = VP.CentroEmisor
                            AND V.NumeroComprobante = VP.NumeroComprobante), 2)
  FROM Ventas V
 WHERE V.IdTipoComprobante = 'eFACT-CC'
   AND V.Utilidad <>
       ROUND((SELECT SUM(VP.Utilidad)
                FROM VentasProductos VP
               WHERE V.IdSucursal = VP.IdSucursal
                 AND V.IdTipoComprobante = VP.IdTipoComprobante
                 AND V.Letra = VP.Letra
                 AND V.CentroEmisor = VP.CentroEmisor
                 AND V.NumeroComprobante = VP.NumeroComprobante), 2)
