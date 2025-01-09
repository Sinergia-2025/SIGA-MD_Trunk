
----Inserta el stock inicial-------------

INSERT INTO MovimientosStock (IdSucursal, IdTipoMovimiento, 
	NumeroMovimiento, IdProducto, Orden, Cantidad, FechaMovimiento)
SELECT IdSucursal, 'AJUSTE', 1, IdProducto, 1, Stock, GETDATE()  FROM ProductosSucursales 