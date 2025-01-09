SELECT COUNT(P.IdSucursal) FROM Pedidos P
 INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = P.IdTipoComprobante AND TC.Tipo = 'PRESUPCLIE'
 INNER JOIN PedidosEstados PE ON PE.IdSucursal = P.IdSucursal 
                                 AND PE.IdTipoComprobante = P.IdTipoComprobante
                                 AND PE.Letra = P.Letra
                                 AND PE.CentroEmisor = P.CentroEmisor
                                 AND PE.NumeroOrdenProduccion = P.NumeroPedido
 INNER JOIN EstadosPedidos EP ON EP.IdEstado = PE.IdEstado AND EP.IdTipoEstado NOT IN ('ANULADO','RECHAZADO')
 WHERE P.IdSucursal >= 1
   AND YEAR(P.FechaPedido) = YEAR(GETDATE())
   AND MONTH(P.FechaPedido) = MONTH(GETDATE())
;
