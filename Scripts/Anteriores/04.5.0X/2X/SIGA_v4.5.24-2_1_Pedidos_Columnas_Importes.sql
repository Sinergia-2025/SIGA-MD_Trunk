
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
ALTER TABLE dbo.Pedidos ADD ImporteBruto decimal(12, 2) NULL
ALTER TABLE dbo.Pedidos ADD SubTotal decimal(12, 2) NULL
ALTER TABLE dbo.Pedidos ADD TotalImpuestos decimal(12, 2) NULL
ALTER TABLE dbo.Pedidos ADD TotalImpuestoInterno decimal(14, 2) NULL
ALTER TABLE dbo.Pedidos ADD ImporteTotal decimal(12, 2) NULL
GO

UPDATE Pedidos
   SET ImporteBruto = ISNULL(PP.ImporteBruto, 0)
      ,SubTotal = ISNULL(PP.ImporteTotalNeto, 0)
      ,TotalImpuestos = ISNULL(PP.ImporteImpuesto, 0)
      ,TotalImpuestoInterno = ISNULL(ImporteImpuestoInterno, 0)
      ,ImporteTotal = ISNULL(PP.ImporteTotal, 0)
  FROM Pedidos AS P
  LEFT JOIN (SELECT PP.IdSucursal, PP.IdTipoComprobante, PP.Letra, PP.CentroEmisor, PP.NumeroPedido
                   ,SUM(PP.ImporteTotal) AS ImporteBruto
                   ,SUM(PP.ImporteTotal + PP.DescuentoRecargoProducto) AS ImporteTotalNeto
                   ,SUM(PP.ImporteImpuesto) AS ImporteImpuesto
                   ,0 AS ImporteImpuestoInterno
                   ,SUM(PP.ImporteTotal + PP.DescuentoRecargoProducto + PP.ImporteImpuesto) AS ImporteTotal
               FROM PedidosProductos AS PP 
              GROUP BY PP.IdSucursal, PP.IdTipoComprobante, PP.Letra, PP.CentroEmisor, PP.NumeroPedido) AS PP
                 ON P.IdSucursal = PP.IdSucursal
                AND P.IdTipoComprobante = PP.IdTipoComprobante
                AND P.Letra = PP.Letra
                AND P.CentroEmisor = PP.CentroEmisor
                AND P.NumeroPedido = PP.NumeroPedido
GO

ALTER TABLE dbo.Pedidos ALTER COLUMN ImporteBruto decimal(12, 2) NOT NULL
ALTER TABLE dbo.Pedidos ALTER COLUMN SubTotal decimal(12, 2) NOT NULL
ALTER TABLE dbo.Pedidos ALTER COLUMN TotalImpuestos decimal(12, 2) NOT NULL
ALTER TABLE dbo.Pedidos ALTER COLUMN TotalImpuestoInterno decimal(14, 2) NOT NULL
ALTER TABLE dbo.Pedidos ALTER COLUMN ImporteTotal decimal(12, 2) NOT NULL
GO
ALTER TABLE dbo.Pedidos SET (LOCK_ESCALATION = TABLE)
GO

COMMIT
