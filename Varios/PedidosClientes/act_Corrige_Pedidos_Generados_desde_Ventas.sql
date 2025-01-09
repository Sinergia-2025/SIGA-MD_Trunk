PRINT '0. BEGIN TRANSACTION'
BEGIN TRANSACTION
GO

PRINT '1. Corrijo PedidosProductos.FechaActualizacion'
UPDATE PedidosProductos
   SET FechaActualizacion = P.FechaPedido
  FROM PedidosProductos PP
 INNER JOIN Pedidos P ON PP.IdSucursal = P.IdSucursal
                     AND PP.IdTipoComprobante = P.IdTipoComprobante
                     AND PP.Letra = P.Letra
                     AND PP.CentroEmisor = P.CentroEmisor
                     AND PP.NumeroPedido = P.NumeroPedido

PRINT '2. Inserto PedidosEstados con la nueva fecha'
INSERT INTO [PedidosEstados]
           ([IdSucursal] ,[NumeroPedido] ,[IdProducto] ,[FechaEstado] ,[IdEstado] ,[IdUsuario] ,[Observacion]
           ,[IdTipoComprobanteFact] ,[LetraFact] ,[CentroEmisorFact] ,[NumeroComprobanteFact] ,[Orden] ,[IdCriticidad]
           ,[FechaEntrega] ,[IdTipoComprobante] ,[Letra] ,[CentroEmisor] ,[NumeroReparto] ,[CantEstado])
SELECT PE.[IdSucursal] ,PE.[NumeroPedido] ,PE.[IdProducto] ,P.FechaPedido ,PE.[IdEstado] ,PE.[IdUsuario] ,PE.[Observacion]
      ,PE.[IdTipoComprobanteFact] ,PE.[LetraFact] ,PE.[CentroEmisorFact] ,PE.[NumeroComprobanteFact] ,PE.[Orden] ,PE.[IdCriticidad]
      ,PE.[FechaEntrega] ,PE.[IdTipoComprobante] ,PE.[Letra] ,PE.[CentroEmisor] ,PE.[NumeroReparto] ,PE.[CantEstado]
  FROM PedidosProductos PP
 INNER JOIN Pedidos P ON PP.IdSucursal = P.IdSucursal
                     AND PP.IdTipoComprobante = P.IdTipoComprobante
                     AND PP.Letra = P.Letra
                     AND PP.CentroEmisor = P.CentroEmisor
                     AND PP.NumeroPedido = P.NumeroPedido
 INNER JOIN PedidosEstados PE ON PE.IdSucursal = PP.IdSucursal
                             AND PE.IdTipoComprobante = P.IdTipoComprobante
                             AND PE.Letra = P.Letra
                             AND PE.CentroEmisor = P.CentroEmisor
                             AND PE.NumeroPedido = P.NumeroPedido
                             AND PE.IdProducto = PP.IdProducto
                             AND PE.Orden = PP.Orden
 WHERE PE.IdEstado = 'PENDIENTE'
   AND PE.FechaEstado <> P.FechaPedido
   AND PE.Observacion = ''

PRINT '3. Borro PedidosEstados con la fecha vieja'
DELETE PedidosEstados
  FROM PedidosProductos PP
 INNER JOIN Pedidos P ON PP.IdSucursal = P.IdSucursal
                     AND PP.IdTipoComprobante = P.IdTipoComprobante
                     AND PP.Letra = P.Letra
                     AND PP.CentroEmisor = P.CentroEmisor
                     AND PP.NumeroPedido = P.NumeroPedido
 INNER JOIN PedidosEstados PE ON PE.IdSucursal = PP.IdSucursal
                             AND PE.IdTipoComprobante = P.IdTipoComprobante
                             AND PE.Letra = P.Letra
                             AND PE.CentroEmisor = P.CentroEmisor
                             AND PE.NumeroPedido = P.NumeroPedido
                             AND PE.IdProducto = PP.IdProducto
                             AND PE.Orden = PP.Orden
 WHERE PE.IdEstado = 'PENDIENTE'
   AND PE.FechaEstado <> P.FechaPedido
   AND PE.Observacion = ''

PRINT '4. Corrijo Pedidos.IdTipoComprobanteFact'
UPDATE Pedidos
   SET IdTipoComprobanteFact = 'COTIZACION'
  FROM Pedidos
 WHERE IdTipoComprobanteFact IS NULL

COMMIT
PRINT '99. COMMIT'
