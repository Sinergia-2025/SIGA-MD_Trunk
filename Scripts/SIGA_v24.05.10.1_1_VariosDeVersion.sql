UPDATE PP
   SET CantPendiente = PE.CantPendiente
     , CantEnProceso = PE.CantEnProceso
     , CantEntregada = PE.CantEntregada
     , CantAnulada   = PE.CantAnulada
  FROM (SELECT PE.IdSucursal, PE.IdTipoComprobante, PE.Letra, PE.CentroEmisor, PE.NumeroPedido, PE.IdProducto, PE.Orden
             , SUM(CASE WHEN  EP.IdTipoEstado = 'PENDIENTE' THEN PE.CantEstado ELSE 0 END) CantPendiente 
             , SUM(CASE WHEN  EP.IdTipoEstado = 'EN PROCESO' THEN PE.CantEstado ELSE 0 END) CantEnProceso
             , SUM(CASE WHEN  EP.IdTipoEstado = 'ENTREGADO' THEN PE.CantEstado ELSE 0 END) CantEntregada 
             , SUM(CASE WHEN (EP.IdTipoEstado = 'ANULADO' AND PE.AnulacionPorModificacion = 0)           
                          OR  EP.IdTipoEstado = 'RECHAZADO' THEN PE.CantEstado ELSE 0 END) CantAnulada   
          FROM PedidosEstados PE
         INNER JOIN EstadosPedidos EP ON EP.IdEstado = PE.IdEstado AND EP.TipoEstadoPedido = PE.TipoEstadoPedido
         GROUP BY PE.IdSucursal, PE.IdTipoComprobante, PE.Letra, PE.CentroEmisor, PE.NumeroPedido, PE.IdProducto, PE.Orden) PE
 INNER JOIN PedidosProductos PP ON PP.IdSucursal = PE.IdSucursal
                               AND PP.IdTipoComprobante = PE.IdTipoComprobante
                               AND PP.Letra = PE.Letra
                               AND PP.CentroEmisor = PE.CentroEmisor
                               AND PP.NumeroPedido = PE.NumeroPedido
                               AND PP.IdProducto = PE.IdProducto
                               AND PP.Orden = PE.Orden
 WHERE (PP.CantPendiente <> PE.CantPendiente OR
        PP.CantEnProceso <> PE.CantEnProceso OR
        PP.CantEntregada <> PE.CantEntregada OR
        PP.CantAnulada   <> PE.CantAnulada)
