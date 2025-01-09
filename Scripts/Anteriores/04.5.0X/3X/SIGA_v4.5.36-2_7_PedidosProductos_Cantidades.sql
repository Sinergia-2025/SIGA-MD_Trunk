
/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidosProductos ADD CantAnulada decimal(12, 4) NULL
ALTER TABLE dbo.PedidosProductos ADD CantPendiente decimal(12, 4) NULL
GO

-------------------------------------------------------------------------------

UPDATE PedidosProductos
   SET CantPendiente = PE.CantPendiente
     , CantEnProceso = PE.CantEnProceso
     , CantEntregada = PE.CantEntregada
     , CantAnulada   = PE.CantAnulado
  FROM PedidosProductos PP
 INNER JOIN (SELECT PE.IdSucursal, PE.IdTipoComprobante, PE.Letra, PE.CentroEmisor, PE.NumeroPedido
                  , PE.IdProducto, PE.Orden
                   --, PP.Cantidad, PP.CantEnProceso, PP.CantEntregada
                  , SUM(PE.CantPendiente) AS CantPendiente
                  , SUM(PE.CantEnProceso) AS CantEnProceso
                  , SUM(PE.CantEntregada) AS CantEntregada
                  , SUM(PE.CantAnulado) AS CantAnulado
               FROM PedidosProductos PP
              INNER JOIN (SELECT PE.IdSucursal, PE.IdTipoComprobante, PE.Letra, PE.CentroEmisor, PE.NumeroPedido
                               , PE.IdProducto, PE.Orden, /*PE.IdEstado,*/ EP.IdTipoEstado
                               , CASE WHEN EP.IdTipoEstado = 'PENDIENTE' THEN SUM(PE.CantEntregada) ELSE 0 END AS CantPendiente
                               , CASE WHEN EP.IdTipoEstado = 'ENTREGADO' THEN SUM(PE.CantEntregada) ELSE 0 END AS CantEntregada
                               , CASE WHEN EP.IdTipoEstado = 'ANULADO' THEN SUM(PE.CantEntregada) ELSE 0 END AS CantAnulado
                               , CASE WHEN EP.IdTipoEstado = 'EN PROCESO' THEN SUM(PE.CantEntregada) ELSE 0 END AS CantEnProceso
                               , SUM(CantEntregada) AS CantEstado
                            FROM PedidosEstados PE
                           INNER JOIN EstadosPedidos EP ON EP.IdEstado = PE.IdEstado
                           GROUP BY PE.IdSucursal, PE.IdTipoComprobante, PE.Letra, PE.CentroEmisor, PE.NumeroPedido
                                  , PE.IdProducto, PE.Orden, /*PE.IdEstado,*/ EP.IdTipoEstado) AS PE
                      ON PE.IdSucursal = PP.IdSucursal
                     AND PE.IdTipoComprobante = PP.IdTipoComprobante
                     AND PE.Letra = PP.Letra
                     AND PE.CentroEmisor = PP.CentroEmisor
                     AND PE.NumeroPedido = PP.NumeroPedido
                     AND PE.IdProducto = PP.IdProducto
                     AND PE.Orden = PP.Orden
              GROUP BY PE.IdSucursal, PE.IdTipoComprobante, PE.Letra, PE.CentroEmisor, PE.NumeroPedido
                     , PE.IdProducto, PE.Orden) AS PE
         ON PE.IdSucursal = PP.IdSucursal
        AND PE.IdTipoComprobante = PP.IdTipoComprobante
        AND PE.Letra = PP.Letra
        AND PE.CentroEmisor = PP.CentroEmisor
        AND PE.NumeroPedido = PP.NumeroPedido
        AND PE.IdProducto = PP.IdProducto
        AND PE.Orden = PP.Orden
GO

-------------------------------------

ALTER TABLE dbo.PedidosProductos ALTER COLUMN CantAnulada decimal(12, 4) NOT NULL
ALTER TABLE dbo.PedidosProductos ALTER COLUMN CantPendiente decimal(12, 4) NOT NULL
GO
ALTER TABLE dbo.PedidosProductos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
