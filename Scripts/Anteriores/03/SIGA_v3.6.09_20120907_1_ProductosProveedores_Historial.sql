INSERT INTO ProductosProveedores
           (IdProducto
           ,TipoDocProveedor
           ,NroDocProveedor
           ,CodigoProductoProveedor
           ,UltimoPrecioCompra)
SELECT DISTINCT MCP.IdProducto
      ,MC.TipoDocProveedor
      ,MC.NroDocProveedor
      ,MCP.IdProducto
      ,0 AS Precio
  FROM MovimientosCompras MC, MovimientosComprasProductos MCP
 WHERE MC.IdSucursal = MCP.IdSucursal
   AND MC.IdTipoMovimiento = MCP.IdTipoMovimiento
   AND MC.NumeroMovimiento = MCP.NumeroMovimiento
   AND MC.IdTipoComprobante IN (SELECT IdTipoComprobante FROM TiposComprobantes WHERE CoeficienteStock<>0)
   AND NOT EXISTS 
       (SELECT * FROM ProductosProveedores pp
         WHERE PP.IdProducto = MCP.IdProducto
           AND PP.TipoDocProveedor = MC.TipoDocProveedor
           AND PP.NroDocProveedor = MC.NroDocProveedor)
GO

/* ---------------------------- */

UPDATE ProductosProveedores 
   SET UltimoPrecioCompra =
(
SELECT TOP (1) MCP.Precio
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


  