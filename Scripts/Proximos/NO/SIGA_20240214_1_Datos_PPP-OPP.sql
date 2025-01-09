UPDATE OPP
   SET IdSucursalPedido         = PE.IdSucursal
     , IdTipoComprobantePedido  = PE.IdTipoComprobante
     , LetraPedido              = PE.Letra
     , CentroEmisorPedido       = PE.CentroEmisor
     , NumeroPedido             = PE.NumeroPedido
	 , IdProductoPedido         = PE.IdProducto
     , OrdenPedido              = PE.Orden
  FROM PedidosEstados PE
 INNER JOIN OrdenesProduccionProductos OPP
         ON OPP.IdSucursal              = PE.IdSucursalProduccion
        AND OPP.IdTipoComprobante       = PE.IdTipoComprobanteProduccion
        AND OPP.Letra                   = PE.LetraProduccion
        AND OPP.CentroEmisor            = PE.CentroEmisorProduccion
        AND OPP.NumeroOrdenProduccion   = PE.NumeroOrdenProduccion
        AND OPP.IdProducto              = PE.IdProductoProduccion
        AND OPP.Orden                   = PE.OrdenProduccion
 WHERE PE.IdTipoComprobanteProduccion IS NOT NULL
   AND OPP.IdTipoComprobantePedido IS NULL
