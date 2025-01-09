
DELETE FROM MovimientosVentasProductos
 WHERE IdSucursal=1
   AND IdTipoMovimiento IN ('VENTA','DEVOLUCION')
   AND NumeroMovimiento in 
 (SELECT NumeroMovimiento  FROM MovimientosVentas where IdTipoComprobante IN ('PROFORMA','DEV-PROFORMA'));


DELETE FROM MovimientosVentas
 where IdTipoComprobante IN ('PROFORMA','DEV-PROFORMA');


DELETE FROM VentasNumeros
 where IdTipoComprobante IN ('PROFORMA','DEV-PROFORMA');


DELETE FROM VentasProductos
 where IdTipoComprobante IN ('PROFORMA','DEV-PROFORMA');


DELETE FROM Ventas
 where IdTipoComprobante IN ('PROFORMA','DEV-PROFORMA');
