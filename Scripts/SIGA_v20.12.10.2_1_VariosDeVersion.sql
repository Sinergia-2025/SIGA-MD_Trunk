PRINT ''
PRINT '1. Actualización de los registros pre-existentes en PedidosProductos'
UPDATE PP SET PP.CantidadManual = PP.Cantidad, PP.Conversion = 1 FROM PedidosProductos PP
GO 

PRINT ''
PRINT '2. Ajuste en caso que se haya generado una factura mal'
UPDATE VP SET VP.CantidadManual = VP.Cantidad,
			 VP.Conversion = 1
FROM VentasProductos VP WHERE VP.CantidadManual = 0
GO
