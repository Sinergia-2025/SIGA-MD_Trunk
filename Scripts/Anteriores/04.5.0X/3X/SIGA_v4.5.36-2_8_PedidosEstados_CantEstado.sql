
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
ALTER TABLE dbo.PedidosEstados ADD CantEstado decimal(12, 2) NULL
GO
UPDATE PedidosEstados SET CantEstado = CantEntregada
GO
ALTER TABLE dbo.PedidosEstados ALTER COLUMN CantEstado decimal(12, 2) NOT NULL
GO
ALTER TABLE dbo.PedidosEstados DROP COLUMN CantEntregada
GO
ALTER TABLE dbo.PedidosEstados SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

---------------------------------------------------------------------------------

UPDATE PedidosEstados
   SET CantEstado = Cantidad - ISNULL(CantOtros, 0)
--SELECT Cantidad - ISNULL(CantOtros, 0), *
  FROM PedidosEstados PE_A
 INNER JOIN (SELECT PE.CantEstado AS CantEstado1, PP.Cantidad
             , (SELECT SUM(PE1.CantEstado)
                  FROM PedidosEstados PE1
                 INNER JOIN EstadosPedidos EP1 ON EP1.idEstado = PE1.IdEstado
                 WHERE EP1.IdTipoEstado <> 'PENDIENTE'
                   AND PE1.IdSucursal = PP.IdSucursal 
                   AND PE1.IdTipoComprobante = PP.IdTipoComprobante
                   AND PE1.Letra = PP.Letra
                   AND PE1.CentroEmisor = PP.CentroEmisor
                   AND PE1.NumeroPedido = PP.NumeroPedido
                   AND PE1.IdProducto = PP.IdProducto
                   AND PE1.Orden = PP.Orden) AS CantOtros
             , PE.*
          FROM PedidosEstados PE
         INNER JOIN EstadosPedidos EP ON EP.idEstado = PE.IdEstado
         INNER JOIN PedidosProductos PP ON PE.IdSucursal = PP.IdSucursal 
                                       AND PE.IdTipoComprobante = PP.IdTipoComprobante
                                       AND PE.Letra = PP.Letra
                                       AND PE.CentroEmisor = PP.CentroEmisor
                                       AND PE.NumeroPedido = PP.NumeroPedido
                                       AND PE.IdProducto = PP.IdProducto
                                       AND PE.Orden = PP.Orden
         WHERE EP.IdTipoEstado = 'PENDIENTE') PE_B
    ON PE_A.IdSucursal = PE_B.IdSucursal 
   AND PE_A.IdTipoComprobante = PE_B.IdTipoComprobante
   AND PE_A.Letra = PE_B.Letra
   AND PE_A.CentroEmisor = PE_B.CentroEmisor
   AND PE_A.NumeroPedido = PE_B.NumeroPedido
   AND PE_A.IdProducto = PE_B.IdProducto
   AND PE_A.Orden = PE_B.Orden
   AND PE_A.FechaEstado = PE_B.FechaEstado
GO
