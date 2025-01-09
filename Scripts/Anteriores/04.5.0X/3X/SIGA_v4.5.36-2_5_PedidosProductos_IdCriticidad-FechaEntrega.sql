
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
ALTER TABLE dbo.PedidosCriticidades SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidosProductos ADD IdCriticidad varchar(10) NULL
ALTER TABLE dbo.PedidosProductos ADD FechaEntrega date NULL
GO

UPDATE PedidosProductos
   SET IdCriticidad = PE.IdCriticidad
     , FechaEntrega = PE.FechaEntrega
  FROM PedidosProductos PP
 INNER JOIN (SELECT IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroPedido, IdProducto, Orden
                  , IdCriticidad, FechaEntrega
                  , COUNT(1) Count
               FROM PedidosEstados PE
              GROUP BY IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroPedido, IdProducto, Orden
                     , IdCriticidad, FechaEntrega) PE ON PE.IdSucursal = PP.IdSucursal
                                                     AND PE.IdTipoComprobante = PP.IdTipoComprobante
                                                     AND PE.Letra = PP.Letra
                                                     AND PE.CentroEmisor = PP.CentroEmisor
                                                     AND PE.NumeroPedido = PP.NumeroPedido
                                                     AND PE.IdProducto = PP.IdProducto
                                                     AND PE.Orden = PP.Orden
GO

ALTER TABLE dbo.PedidosProductos ALTER COLUMN IdCriticidad varchar(10) NULL
ALTER TABLE dbo.PedidosProductos ALTER COLUMN FechaEntrega date NULL
GO

ALTER TABLE dbo.PedidosProductos ADD CONSTRAINT
    FK_PedidosProductos_PedidosCriticidades FOREIGN KEY (IdCriticidad)
    REFERENCES dbo.PedidosCriticidades (IdCriticidad)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION
GO
ALTER TABLE dbo.PedidosProductos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
