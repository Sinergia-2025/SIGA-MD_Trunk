
/* Para evitar posibles problemas de pérdida de datos, debe revisar este script detalladamente antes de ejecutarlo fuera del contexto del diseñador de base de datos.*/
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
ALTER TABLE dbo.ProductosProveedores ADD
	UltimaFechaCompra datetime NULL
GO
ALTER TABLE dbo.ProductosProveedores SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

/* ---------------------------- */

UPDATE ProductosProveedores 
   SET UltimaFechaCompra =
(
SELECT TOP (1) MC.FechaMovimiento
  FROM MovimientosCompras MC, MovimientosComprasProductos MCP
 WHERE MC.IdSucursal = MCP.IdSucursal
   AND MC.IdTipoMovimiento = MCP.IdTipoMovimiento
   AND MC.NumeroMovimiento = MCP.NumeroMovimiento
   AND MC.IdTipoComprobante IN (SELECT IdTipoComprobante FROM TiposComprobantes WHERE CoeficienteStock<>0)
   AND MC.TipoDocProveedor = ProductosProveedores.TipoDocProveedor
   AND MC.NroDocProveedor = ProductosProveedores.NroDocProveedor
   AND MCP.IdProducto = ProductosProveedores.IdProducto
   ORDER BY MC.FechaMovimiento DESC
)
GO

