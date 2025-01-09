
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
ALTER TABLE dbo.PedidosProductos ADD PrecioNeto decimal(14, 4) NULL
ALTER TABLE dbo.PedidosProductos ADD ImporteTotalNeto decimal(14, 4) NULL
ALTER TABLE dbo.PedidosProductos ADD DescRecGeneral decimal(14, 4) NULL
ALTER TABLE dbo.PedidosProductos ADD DescRecGeneralProducto decimal(14, 4) NULL
GO

UPDATE PedidosProductos
   SET PrecioNeto = CONVERT(decimal(9,4), VP.Precio * (1 + (VP.DescuentoRecargoPorc / 100)) 
                                                    * (1 + (VP.DescuentoRecargoPorc2 / 100))
                                                    * (1 + (V.DescuentoRecargoPorc / 100)))
     , DescRecGeneral = CONVERT(decimal(9,2), VP.Precio * ((V.DescuentoRecargoPorc / 100)) * VP.Cantidad)
     , DescRecGeneralProducto = CONVERT(decimal(9,2), VP.Precio * ((V.DescuentoRecargoPorc / 100)))
     , ImporteTotalNeto = CONVERT(decimal(9,2), VP.Precio * (1 + (VP.DescuentoRecargoPorc / 100)) 
                                                          * (1 + (VP.DescuentoRecargoPorc2 / 100))
                                                          * (1 + (V.DescuentoRecargoPorc / 100)) * VP.Cantidad)
  FROM Pedidos V
 INNER JOIN PedidosProductos VP ON V.IdSucursal = VP.IdSucursal
                    AND V.IdTipoComprobante = VP.IdTipoComprobante
                    AND V.Letra = VP.Letra
                    AND V.CentroEmisor = VP.CentroEmisor
                    AND V.NumeroPedido = VP.NumeroPedido
 --WHERE V.DescuentoRecargoPorc <> 0
GO

ALTER TABLE dbo.PedidosProductos ALTER COLUMN PrecioNeto decimal(14, 4) NOT NULL
ALTER TABLE dbo.PedidosProductos ALTER COLUMN ImporteTotalNeto decimal(14, 4) NOT NULL
ALTER TABLE dbo.PedidosProductos ALTER COLUMN DescRecGeneral decimal(14, 4) NOT NULL
ALTER TABLE dbo.PedidosProductos ALTER COLUMN DescRecGeneralProducto decimal(14, 4) NOT NULL
GO
ALTER TABLE dbo.PedidosProductos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
