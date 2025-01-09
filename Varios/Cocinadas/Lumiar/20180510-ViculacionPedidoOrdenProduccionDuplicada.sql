UPDATE PedidosEstados
   SET IdEstado = 'PENDIENTE'
      ,IdSucursalProduccion = NULL
      ,IdTipoComprobanteProduccion = NULL
      ,LetraProduccion = NULL
      ,CentroEmisorProduccion = NULL
      ,NumeroOrdenProduccion = NULL
      ,IdProductoProduccion = NULL
      ,OrdenProduccion = NULL
  FROM PedidosEstados PE
 WHERE 1 = 1
   AND PE.IdSucursalProduccion = 1
   AND PE.IdTipoComprobanteProduccion = 'ORDENPRODUCCION'
   AND PE.LetraProduccion = 'X'
   AND PE.CentroEmisorProduccion = 1
   AND PE.NumeroOrdenProduccion = 41
   AND ((PE.IdProductoProduccion = '116' AND PE.OrdenProduccion = 6) OR
        (PE.IdProductoProduccion = '95'  AND PE.OrdenProduccion = 2) OR
        (PE.IdProductoProduccion = '119' AND PE.OrdenProduccion = 8))
   AND (PE.FechaEstado = '20180412 16:08:37' OR PE.FechaEstado = '20180412 16:08:31' OR PE.FechaEstado = '20180412 16:08:35')
