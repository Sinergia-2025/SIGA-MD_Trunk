PRINT ''
PRINT '13. Renombra Tablas de Movimeintos Compras-Ventas-Lotes-NrosSerie.'
BEGIN
	EXEC sp_rename 'MovimientosCompras', 'MovimientosCompras_Viejos'
	EXEC sp_rename 'MovimientosVentas', 'MovimientosVentas_Viejos'
	EXEC sp_rename 'MovimientosComprasProductos', 'MovimientosComprasProductos_Viejos'
	EXEC sp_rename 'MovimientosVentasProductos', 'MovimientosVentasProductos_Viejos'
	EXEC sp_rename 'MovimientosVentasProductosLotes', 'MovimientosVentasProductosLotes_Viejos'
	EXEC sp_rename 'MovimientosComprasProductosNrosSerie', 'MovimientosComprasProductosNrosSerie_Viejos'
	EXEC sp_rename 'MovimientosVentasProductosNrosSerie', 'MovimientosVentasProductosNrosSerie_Viejos'
END
GO