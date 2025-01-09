UPDATE PedidosProductos
   SET DescuentoRecargoProducto = CONVERT(DECIMAL(9,4),
                                       ROUND(PP.Precio * PP.DescuentoRecargoPorc / 100, 4) +
                                                ((PP.Precio - ROUND(PP.Precio * PP.DescuentoRecargoPorc / 100, 4)) * PP.DescuentoRecargoPorc2 / 100))
  FROM PedidosProductos AS PP
 INNER JOIN Pedidos AS P ON P.IdSucursal = PP.IdSucursal
                        AND P.IdTipoComprobante = PP.IdTipoComprobante
                        AND P.Letra = PP.Letra
                        AND P.CentroEmisor = PP.CentroEmisor
                        AND P.NumeroPedido = PP.NumeroPedido
 WHERE (PP.DescuentoRecargoPorc <> 0 OR PP.DescuentoRecargoPorc2 <> 0 OR P.DescuentoRecargoPorc <> 0)
   AND P.FechaPedido > '20170901'


UPDATE VentasProductos
   SET DescuentoRecargoProducto = CONVERT(DECIMAL(14,4),
                                               ROUND(PP.Precio * PP.DescuentoRecargoPorc / 100, 4) +
                                                        ((PP.Precio - ROUND(PP.Precio * PP.DescuentoRecargoPorc / 100, 4)) * PP.DescuentoRecargoPorc2 / 100))
      ,DescuentoRecargo = CONVERT(DECIMAL(14,4),
                                        (ROUND(PP.Precio * PP.DescuentoRecargoPorc / 100, 4) +
                                                ((PP.Precio - ROUND(PP.Precio * PP.DescuentoRecargoPorc / 100, 4)) * PP.DescuentoRecargoPorc2 / 100))
                                                        * PP.Cantidad)
  FROM VentasProductos AS PP
 INNER JOIN Ventas AS P ON P.IdSucursal = PP.IdSucursal
                       AND P.IdTipoComprobante = PP.IdTipoComprobante
                       AND P.Letra = PP.Letra
                       AND P.CentroEmisor = PP.CentroEmisor
                       AND P.NumeroComprobante = PP.NumeroComprobante
 WHERE (PP.DescuentoRecargoPorc <> 0 OR PP.DescuentoRecargoPorc2 <> 0 OR P.DescuentoRecargoPorc <> 0)
   AND P.Fecha > '20170901'

