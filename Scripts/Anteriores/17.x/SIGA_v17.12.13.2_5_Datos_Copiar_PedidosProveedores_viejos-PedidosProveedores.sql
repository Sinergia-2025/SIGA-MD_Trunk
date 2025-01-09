PRINT '1. INSERT DE PedidosProveedores'
INSERT INTO PedidosProveedores
           (IdSucursal,IdTipoComprobante,Letra,CentroEmisor,NumeroPedido,IdProveedor,FechaPedido
           ,Observacion,IdUsuario,DescuentoRecargo,DescuentoRecargoPorc,TipoDocComprador,NroDocComprador
           ,IdFormasPago,IdTransportista,CotizacionDolar,IdTipoComprobanteFact,ImporteBruto,SubTotal
           ,TotalImpuestos,TotalImpuestoInterno,ImporteTotal,IdEstadoVisita,NumeroOrdenCompra,Kilos)
SELECT PP.IdSucursal,'PEDIDOPROVEEDOR' AS IdTipoComprobante,'X' AS Letra,I.CentroEmisor,IdPedido AS NumeroPedido,IdProveedor,FechaPedido
      ,Observacion + '___migrado' AS Observacion,IdUsuario,0 AS DescuentoRecargo,0 AS DescuentoRecargoPorc,'COD' AS TipoDocComprador,1 AS NroDocComprador
      ,IdFormasPago,NULL AS IdTransportista,1 AS CotizacionDolar,NULL AS IdTipoComprobanteFact,0 AS ImporteBruto,0 AS SubTotal
      ,0 AS TotalImpuestos,0 AS TotalImpuestoInterno,0 AS ImporteTotal,1 AS IdEstadoVisita,NumeroOrdenCompra,0 AS Kilos
  FROM PedidosProveedores_viejo PP
 INNER JOIN Impresoras I ON I.IdSucursal = PP.IdSucursal AND I.IdImpresora = 'NORMAL'
GO

PRINT '2. INSERT DE PedidosProductosProveedores'
INSERT INTO PedidosProductosProveedores
           (IdSucursal,IdTipoComprobante,Letra,CentroEmisor,NumeroPedido
           ,IdProducto,Orden,IdProveedor
           ,Cantidad,CostoLista,Costo,CostoNeto
           ,DescuentoRecargoPorc,DescuentoRecargoPorc2,DescuentoRecargoProducto
           ,DescRecGeneral,DescRecGeneralProducto
           ,AlicuotaImpuesto,ImporteImpuesto,ImpuestoInterno,ImporteImpuestoInterno,PorcImpuestoInterno
           ,ImporteTotal,ImporteTotalNeto
           ,NombreProducto,CantEntregada,CantEnProceso,IdTipoImpuesto,FechaActualizacion,Kilos
           ,IdCriticidad,FechaEntrega,CantAnulada,CantPendiente
           ,CostoConImpuestos,CostoNetoConImpuestos,ImporteTotalConImpuestos,ImporteTotalNetoConImpuestos)
SELECT PPP.IdSucursal,'PEDIDOPROVEEDOR' AS IdTipoComprobante,'X' AS Letra,I.CentroEmisor,PPP.IdPedido AS NumeroPedido
      ,PPP.IdProducto,PPP.Orden,PP.IdProveedor
      ,PPP.Cantidad,PPP.Costo AS CostoLista,PPP.Costo,PPP.Costo AS CostoNeto
      ,0 AS DescuentoRecargoPorc,0 AS DescuentoRecargoPorc2,0 AS DescuentoRecargoProducto
      ,0 AS DescRecGeneral,0 AS DescRecGeneralProducto
      ,P.Alicuota AS AlicuotaImpuesto, 0 AS ImporteImpuesto
      ,P.ImporteImpuestoInterno AS ImpuestoInterno,P.ImporteImpuestoInterno * PPP.Cantidad AS ImporteImpuestoInterno
      ,P.PorcImpuestoInterno
      ,PPP.ImporteTotal,PPP.ImporteTotal AS ImporteTotalNeto
      ,PPP.NombreProducto,0 AS CantEntregada,0 AS CantEnProceso,P.IdTipoImpuesto,NULL FechaActualizacion,0 Kilos
      ,NULL IdCriticidad, PP.FechaPedido AS FechaEntrega,0 AS CantAnulada,0 AS CantPendiente
      ,PPP.Costo AS CostoConImpuestos,PPP.Costo AS CostoNetoConImpuestos,PPP.ImporteTotal AS ImporteTotalConImpuestos,PPP.ImporteTotal AS ImporteTotalNetoConImpuestos
  FROM PedidosProductosProveedores_viejo PPP
 INNER JOIN PedidosProveedores_viejo PP ON PP.IdSucursal = PPP.IdSucursal AND PP.IdPedido = PPP.IdPedido
 INNER JOIN Productos P ON P.IdProducto = PPP.IdProducto
 INNER JOIN Impresoras I ON I.IdSucursal = PP.IdSucursal AND I.IdImpresora = 'NORMAL'
GO

PRINT '3. INSERT DE PedidosEstadosProveedores'
INSERT INTO PedidosEstadosProveedores
           (IdSucursal,IdTipoComprobante,Letra,CentroEmisor,NumeroPedido
           ,IdProducto,Orden,FechaEstado,IdProveedor
           ,IdEstado,IdUsuario,Observacion,IdCriticidad,FechaEntrega
           ,NumeroReparto,CantEstado,TipoEstadoPedido
           ,IdTipoComprobanteFact,LetraFact,CentroEmisorFact,NumeroComprobanteFact
           ,IdSucursalGenerado,IdTipoComprobanteGenerado,LetraGenerado,CentroEmisorGenerado,NumeroPedidoGenerado
           ,IdSucursalRemito,IdTipoComprobanteRemito,LetraRemito,CentroEmisorRemito,NumeroComprobanteRemito)
SELECT PEP.IdSucursal,'PEDIDOPROVEEDOR' AS IdTipoComprobante,'X' AS Letra,I.CentroEmisor,PEP.IdPedido AS NumeroPedido
      ,PEP.IdProducto,PEP.Orden,PEP.FechaEstado,PP.IdProveedor
      ,PEP.IdEstado,PEP.IdUsuario,PEP.Observacion,'Normal' IdCriticidad,PP.FechaPedido FechaEntrega
      ,NULL AS NumeroReparto,CantEntregada AS CantEstado,'PEDIDOSPROV' AS TipoEstadoPedido
      ,C.IdTipoComprobante AS IdTipoComprobanteFact,C.Letra AS LetraFact,C.CentroEmisor AS CentroEmisorFact,C.NumeroComprobante AS NumeroComprobanteFact
      ,NULL IdSucursalGenerado,NULL IdTipoComprobanteGenerado,NULL LetraGenerado,NULL CentroEmisorGenerado,NULL NumeroPedidoGenerado
      ,NULL IdSucursalRemito,NULL IdTipoComprobanteRemito,NULL LetraRemito,NULL CentroEmisorRemito,NULL NumeroComprobanteRemito
  FROM PedidosEstadosProveedores_viejo PEP
 INNER JOIN PedidosProveedores_viejo PP ON PP.IdSucursal = PEP.IdSucursal AND PP.IdPedido = PEP.IdPedido
 INNER JOIN Impresoras I ON I.IdSucursal = PP.IdSucursal AND I.IdImpresora = 'NORMAL'
  LEFT JOIN Compras C ON C.IdSucursal = PEP.IdSucursal
                     AND C.IdTipoComprobante = PEP.IdTipoComprobante
                     AND C.Letra = PEP.Letra
                     AND C.CentroEmisor = PEP.CentroEmisor
                     AND C.NumeroComprobante = PEP.NumeroComprobante
                     AND C.IdProveedor = PP.IdProveedor
GO

PRINT '4. Actualizo cantidades de PedidosProductosProveedores según el estado de cada línea.'
UPDATE PedidosProductosProveedores
   SET CantPendiente = PEP.CantPendiente
      ,CantEnProceso = PEP.CantEnProceso
      ,CantEntregada = PEP.CantEntregada
      ,CantAnulada = PEP.CantAnulada
  FROM (SELECT PPP.IdSucursal
              ,PPP.IdTipoComprobante
              ,PPP.Letra
              ,PPP.CentroEmisor
              ,PPP.NumeroPedido
              ,PPP.IdProducto
              ,PPP.Orden
              ,PEP.CantEstado
              ,PEP.IdEstado
              ,EPP.IdTipoEstado
              ,SUM(CASE WHEN EPP.IdTipoEstado = 'PENDIENTE' THEN CantEstado ELSE 0 END) AS CantPendiente
              ,SUM(CASE WHEN EPP.IdTipoEstado = 'ENPROCESO' THEN CantEstado ELSE 0 END) AS CantEnProceso
              ,SUM(CASE WHEN EPP.IdTipoEstado = 'ENTREGADO' THEN CantEstado ELSE 0 END) AS CantEntregada
              ,SUM(CASE WHEN EPP.IdTipoEstado = 'ANULADO' OR EPP.IdTipoEstado = 'RECHAZADO' THEN CantEstado ELSE 0 END) AS CantAnulada
          FROM PedidosProductosProveedores PPP
         INNER JOIN PedidosEstadosProveedores PEP ON PEP.IdSucursal = PPP.IdSucursal
                                                 AND PEP.IdTipoComprobante = PPP.IdTipoComprobante
                                                 AND PEP.Letra = PPP.Letra
                                                 AND PEP.CentroEmisor = PPP.CentroEmisor
                                                 AND PEP.NumeroPedido = PPP.NumeroPedido
                                                 AND PEP.IdProducto = PPP.IdProducto
                                                 AND PEP.Orden = PPP.Orden
         INNER JOIN EstadosPedidosProveedores EPP ON EPP.IdEstado = PEP.IdEstado AND EPP.TipoEstadoPedido = PEP.TipoEstadoPedido
         GROUP BY PPP.IdSucursal,PPP.IdTipoComprobante,PPP.Letra,PPP.CentroEmisor,PPP.NumeroPedido
                 ,PPP.IdProducto,PPP.Orden,PEP.CantEstado,PEP.IdEstado,EPP.IdTipoEstado) PEP
 INNER JOIN PedidosProductosProveedores PPP ON PEP.IdSucursal = PPP.IdSucursal
                                           AND PEP.IdTipoComprobante = PPP.IdTipoComprobante
                                           AND PEP.Letra = PPP.Letra
                                           AND PEP.CentroEmisor = PPP.CentroEmisor
                                           AND PEP.NumeroPedido = PPP.NumeroPedido
                                           AND PEP.IdProducto = PPP.IdProducto
                                           AND PEP.Orden = PPP.Orden

PRINT '5. Actualizo ImporteTotal y SubTotal de los Pedidos.'
UPDATE PedidosProveedores
   SET ImporteTotal = PPP.ImporteTotal
      ,SubTotal = PPP.ImporteTotal
  FROM (SELECT PP.IdSucursal
              ,PP.IdTipoComprobante
              ,PP.Letra
              ,PP.CentroEmisor
              ,PP.NumeroPedido
              ,SUM(PPP.ImporteTotal) AS ImporteTotal
          FROM PedidosProveedores PP
         INNER JOIN PedidosProductosProveedores PPP ON PPP.IdSucursal = PP.IdSucursal
                                                   AND PPP.IdTipoComprobante = PP.IdTipoComprobante
                                                   AND PPP.Letra = PP.Letra
                                                   AND PPP.CentroEmisor = PP.CentroEmisor
                                                   AND PPP.NumeroPedido = PP.NumeroPedido
         GROUP BY PP.IdSucursal,PP.IdTipoComprobante,PP.Letra,PP.CentroEmisor,PP.NumeroPedido) PPP
 INNER JOIN PedidosProveedores PP ON PPP.IdSucursal = PP.IdSucursal
                                 AND PPP.IdTipoComprobante = PP.IdTipoComprobante
                                 AND PPP.Letra = PP.Letra
                                 AND PPP.CentroEmisor = PP.CentroEmisor
                                 AND PPP.NumeroPedido = PP.NumeroPedido


PRINT '6. Actualizo punteros de númerador para tipo de comprobante.'
MERGE INTO VentasNumeros AS D
     USING (SELECT IdSucursal, IdTipoComprobante, Letra, CentroEmisor, MAX(NumeroPedido) Numero, MAX(FechaPedido) Fecha
              FROM PedidosProveedores GROUP BY IdSucursal, IdTipoComprobante, Letra, CentroEmisor) AS O
        ON D.IdSucursal = O.IdSucursal
       AND D.IdTipoComprobante = O.IdTipoComprobante
       AND D.LetraFiscal = O.Letra
       AND D.CentroEmisor = O.CentroEmisor
 WHEN MATCHED THEN
    UPDATE
       SET D.Numero = O.Numero
          ,D.Fecha = O.Fecha
 WHEN NOT MATCHED THEN
    INSERT (  IdSucursal,   IdTipoComprobante,   LetraFiscal,   CentroEmisor,   Numero,   Fecha)
    VALUES (O.IdSucursal, O.IdTipoComprobante, O.Letra      , O.CentroEmisor, O.Numero, O.Fecha)
;
SELECT IdSucursal,IdTipoComprobante,LetraFiscal,CentroEmisor,Numero
      ,IdTipoComprobanteRelacionado,Fecha
  FROM VentasNumeros
 WHERE IdTipoComprobante = 'PEDIDOPROVEEDOR'
