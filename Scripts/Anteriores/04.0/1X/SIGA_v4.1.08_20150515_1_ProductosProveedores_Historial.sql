
--- SOLO EN Marinzaldi que esta mal.
UPDATE TiposComprobantes
   SET CoeficienteStock = 1
 WHERE Tipo = 'COMPRAS'
   AND CoeficienteStock = 0
   AND IdTipoComprobante IN ('FACTCOM','REMITOCOM')
GO


/* ---------------------------- */

INSERT INTO ProductosProveedores
           (IdProducto
           ,IdProveedor
           ,CodigoProductoProveedor
           ,UltimoPrecioCompra
           ,UltimaFechaCompra)
SELECT DISTINCT MCP.IdProducto
      ,MC.IdProveedor
      ,MCP.IdProducto
      ,0 AS Precio
      ,NULL AS Fecha
  FROM MovimientosCompras MC, MovimientosComprasProductos MCP, TiposComprobantes TC
 WHERE MC.IdSucursal = MCP.IdSucursal
   AND MC.IdTipoMovimiento = MCP.IdTipoMovimiento
   AND MC.NumeroMovimiento = MCP.NumeroMovimiento
   AND MC.IdTipoComprobante = TC.IdTipoComprobante 
   AND TC.CoeficienteStock <> 0
   AND NOT EXISTS 
       (SELECT * FROM ProductosProveedores pp
         WHERE PP.IdProducto = MCP.IdProducto
           AND PP.IdProveedor = MC.IdProveedor)
GO

/* ---------------------------- */

UPDATE ProductosProveedores 
   SET UltimoPrecioCompra =
(
SELECT TOP (1) MCP.Precio
  FROM MovimientosCompras MC, MovimientosComprasProductos MCP, TiposComprobantes TC
 WHERE MC.IdSucursal = MCP.IdSucursal
   AND MC.IdTipoMovimiento = MCP.IdTipoMovimiento
   AND MC.NumeroMovimiento = MCP.NumeroMovimiento
   AND MC.IdTipoComprobante = TC.IdTipoComprobante 
   AND MC.IdProveedor = ProductosProveedores.IdProveedor
   AND MCP.IdProducto = ProductosProveedores.IdProducto
   AND TC.CoeficienteStock <> 0
   ORDER BY MC.FechaMovimiento DESC
)
GO

/* ---------------------------- */

UPDATE ProductosProveedores 
   SET UltimaFechaCompra =
(
SELECT TOP (1) MC.FechaMovimiento
  FROM MovimientosCompras MC, MovimientosComprasProductos MCP, TiposComprobantes TC
 WHERE MC.IdSucursal = MCP.IdSucursal
   AND MC.IdTipoMovimiento = MCP.IdTipoMovimiento
   AND MC.NumeroMovimiento = MCP.NumeroMovimiento
   AND MC.IdTipoComprobante = TC.IdTipoComprobante 
   AND MC.IdProveedor = ProductosProveedores.IdProveedor
   AND MCP.IdProducto = ProductosProveedores.IdProducto
   AND TC.CoeficienteStock <> 0
   ORDER BY MC.FechaMovimiento DESC
)
GO
