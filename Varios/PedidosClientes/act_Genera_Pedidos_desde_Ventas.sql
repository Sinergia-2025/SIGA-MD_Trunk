INSERT INTO SIGA.dbo.Pedidos
           (IdSucursal
           ,NumeroPedido
           ,FechaPedido
           ,Observacion
           ,IdUsuario
           ,DescuentoRecargo
           ,DescuentoRecargoPorc
           ,IdCliente
           ,IdTipoComprobante
           ,Letra
           ,CentroEmisor
           ,TipoDocVendedor
           ,NroDocVendedor
           ,IdFormasPago
           ,IdTransportista
           ,CotizacionDolar
           ,IdTipoComprobanteFact
           ,ImporteBruto
           ,SubTotal
           ,TotalImpuestos
           ,TotalImpuestoInterno
           ,ImporteTotal
           ,IdEstadoVisita
           ,NumeroOrdenCompra
           ,Kilos)
SELECT IdSucursal
           ,NumeroComprobante AS xNumeroPedido
           ,Fecha AS xFechaPedido
           ,'' AS xObservacion
           ,Usuario AS xIdUsuario
           ,DescuentoRecargo
           ,DescuentoRecargoPorc
           ,IdCliente
           ,'PEDIDO' AS xIdTipoComprobante
           ,Letra
           ,CentroEmisor
           ,TipoDocVendedor
           ,NroDocVendedor
           ,IdFormasPago
           ,IdTransportista
           ,CotizacionDolar
           ,IdTipoComprobanteFact
           ,ImporteBruto
           ,SubTotal
           ,TotalImpuestos
           ,TotalImpuestoInterno
           ,ImporteTotal
           ,1 AS xIdEstadoVisita
           ,NULL AS xNumeroOrdenCompra
           ,Kilos
  FROM Ventas
 where IdTipoComprobante='PRESUP'
   and IdEstadoComprobante IS NULL
 ;
 
 INSERT INTO PedidosProductos
           (IdSucursal
           ,NumeroPedido
           ,IdProducto
           ,Cantidad
           ,Precio
           ,Costo
           ,ImporteTotal
           ,NombreProducto
           ,CantEntregada
           ,CantEnProceso
           ,Orden
           ,DescuentoRecargoProducto
           ,DescuentoRecargoPorc2
           ,DescuentoRecargoPorc
           ,IdTipoImpuesto
           ,AlicuotaImpuesto
           ,ImporteImpuesto
           ,PrecioLista
           ,IdTipoComprobante
           ,Letra
           ,CentroEmisor
           ,FechaActualizacion
           ,IdListaPrecios
           ,NombreListaPrecios
           ,ImporteImpuestoInterno
           ,PrecioNeto
           ,ImporteTotalNeto
           ,DescRecGeneral
           ,DescRecGeneralProducto
           ,Kilos
           ,IdCriticidad
           ,FechaEntrega
           ,CantAnulada
           ,CantPendiente)
SELECT VP.IdSucursal
            ,VP.NumeroComprobante AS xNumeroPedido
           ,IdProducto
           ,Cantidad
           ,Precio
           ,Costo
           ,VP.ImporteTotal
           ,NombreProducto
           ,0 AS xCantEntregada
           ,0 AS xCantEnProceso
           ,Orden
           ,DescuentoRecargoProducto
           ,DescuentoRecargoPorc2
           ,VP.DescuentoRecargoPorc
           ,IdTipoImpuesto
           ,AlicuotaImpuesto
           ,ImporteImpuesto
           ,PrecioLista
           ,'PEDIDO' AS xIdTipoComprobante
           ,VP.Letra
           ,VP.CentroEmisor
           ,GETDATE() AS xFechaActualizacion
           ,IdListaPrecios
           ,NombreListaPrecios
           ,ImporteImpuestoInterno
           ,PrecioNeto
           ,ImporteTotalNeto
           ,DescRecGeneral
           ,DescRecGeneralProducto
           ,VP.Kilos
           ,'Normal' AS xIdCriticidad
           ,GETDATE() AS xFechaEntrega
           ,0 AS xCantAnulada
           ,Cantidad AS XCantPendiente
   FROM VentasProductos VP
  INNER JOIN Ventas V ON V.IdSucursal = VP.IdSucursal
                      AND V.IdTipoComprobante = VP.IdTipoComprobante
                      AND V.Letra = VP.Letra
                      AND V.CentroEmisor = VP.CentroEmisor
                      AND V.NumeroComprobante = VP.NumeroComprobante
                      AND V.IdEstadoComprobante IS NULL
 WHERE VP.IdTipoComprobante = 'PRESUP'
 ;

 
 INSERT INTO SIGA.dbo.PedidosEstados
           (IdSucursal
           ,NumeroPedido
           ,IdProducto
           ,FechaEstado
           ,IdEstado
           ,IdUsuario
           ,Observacion
           ,IdTipoComprobanteFact
           ,LetraFact
           ,CentroEmisorFact
           ,NumeroComprobanteFact
           ,Orden
           ,IdCriticidad
           ,FechaEntrega
           ,IdTipoComprobante
           ,Letra
           ,CentroEmisor
           ,NumeroReparto
           ,CantEstado)
SELECT IdSucursal
           ,NumeroPedido
           ,IdProducto
           ,GETDATE() AS xFechaEstado	---Sacar del Pedidos
           ,'PENDIENTE' AS xIdEstado
           ,'Patricia' AS xIdUsuario	---Sacar del Pedidos
           ,'' AS xObservacion
           ,NULL AS xIdTipoComprobanteFact
           ,NULL AS xLetraFact
           ,NULL AS xCentroEmisorFact
           ,NULL AS xNumeroComprobanteFact
           ,Orden
           ,IdCriticidad
           ,FechaEntrega
           ,IdTipoComprobante
           ,Letra
           ,CentroEmisor
           ,NULL AS xNumeroReparto
           ,Cantidad AS xCantEstado
  FROM SIGA.dbo.PedidosProductos
GO
