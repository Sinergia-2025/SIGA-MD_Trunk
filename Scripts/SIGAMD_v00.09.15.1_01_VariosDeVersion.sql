PRINT ''
PRINT 'DROP CONSTRAINT: Movimiento de Compras/Ventas'

IF dbo.ExisteTabla('MovimientosComprasProductos_Viejos') = 1 and dbo.ExisteFK('FK_MovimientosComprasProductos_Productos') = 1
BEGIN
    ALTER TABLE MovimientosComprasProductos_Viejos DROP CONSTRAINT FK_MovimientosComprasProductos_Productos
END
GO
IF dbo.ExisteTabla('MovimientosComprasProductosNrosSerie_Viejos') = 1 and dbo.ExisteFK('FK_MovimientosComprasProductosNrosSerie_MovimientosComprasProductos') = 1
BEGIN
    ALTER TABLE MovimientosComprasProductosNrosSerie_Viejos DROP CONSTRAINT FK_MovimientosComprasProductosNrosSerie_MovimientosComprasProductos
END

IF dbo.ExisteTabla('MovimientosVentasProductosLotes_Viejos') = 1 and dbo.ExisteFK('FK_MovimientosVentasProductosLotes_MovimientosVentasProductos') = 1
BEGIN
    ALTER TABLE MovimientosVentasProductosLotes_Viejos DROP CONSTRAINT FK_MovimientosVentasProductosLotes_MovimientosVentasProductos
END

IF dbo.ExisteTabla('MovimientosVentasProductosNrosSerie_Viejos') = 1 and dbo.ExisteFK('FK_MovimientosVentasProductosNrosSerie_MovimientosVentasProductos') = 1
BEGIN
    ALTER TABLE MovimientosVentasProductosNrosSerie_Viejos DROP CONSTRAINT FK_MovimientosVentasProductosNrosSerie_MovimientosVentasProductos
END

IF dbo.ExisteTabla('MovimientosVentasProductos_Viejos') = 1 and dbo.ExisteFK('FK_MovimientosVentasProductos_Productos') = 1
BEGIN
    ALTER TABLE MovimientosVentasProductos_Viejos DROP CONSTRAINT FK_MovimientosVentasProductos_Productos
END

PRINT ''
PRINT '1. Campos Nuevo: MRP: Tipo Comprobante - Solicita Informe de Calidad.'
IF dbo.ExisteCampo('TiposComprobantes ','SolicitaInformeCalidad ') = 0
BEGIN
	ALTER TABLE TiposComprobantes ADD SolicitaInformeCalidad bit NULL
END
GO

PRINT ''
PRINT '2. Campos Nuevo: MRP: Tipo Comprobante - Solicita Informe de Calidad = False.'
BEGIN
	UPDATE TiposComprobantes SET SolicitaInformeCalidad = 0
	ALTER TABLE TiposComprobantes ALTER COLUMN SolicitaInformeCalidad bit NOT NULL
END
GO

PRINT ''
PRINT '3. Campos Nuevo: MRP: Tipo Comprobante - Solicita Informe de Calidad = True.'
BEGIN
	UPDATE TiposComprobantes SET SolicitaInformeCalidad = 1
		WHERE IdTipoComprobante IN ('COTIZACIONCOM', 'FACTCOM', 'FACTCOM-M', 'REMITOCOMOFIC')
END
GO

PRINT ''
PRINT '1. Tabla MovimientosStockProductos: Nuevos campos calidad'
IF dbo.ExisteCampo('MovimientosStockProductos', 'InformeCalidadNumero') = 0
BEGIN
    ALTER TABLE MovimientosStockProductos ADD InformeCalidadNumero Varchar(50) NULL
    ALTER TABLE MovimientosStockProductos ADD InformeCalidadLink Varchar(MAX) NULL
END
GO

PRINT ''
PRINT '1. Tabla EstadosPedidosProveedores: Nuevo Campo Declara Produccion'
IF dbo.ExisteCampo('EstadosPedidosProveedores', 'GeneraDeclaracionProduccion') = 0
BEGIN
    ALTER TABLE EstadosPedidosProveedores ADD GeneraDeclaracionProduccion bit NULL
END
GO

PRINT ''
PRINT '2. Campos Nuevo : Declara Produccion = False.'
BEGIN
	UPDATE EstadosPedidosProveedores SET GeneraDeclaracionProduccion = 0
	ALTER TABLE EstadosPedidosProveedores ALTER COLUMN GeneraDeclaracionProduccion bit NOT NULL
END
GO


PRINT ''
PRINT '1. Tabla MovimientosStockProductos: Nuevo Campo Fecha Vencimiento Lote'
IF dbo.ExisteCampo('MovimientosStockProductos', 'VtoLote') = 0
BEGIN
    ALTER TABLE MovimientosStockProductos ADD VtoLote datetime NULL
END
GO

PRINT ''
PRINT '2. Tabla ComprasProductos: Nuevo Campo Fecha Vencimiento Lote'
IF dbo.ExisteCampo('ComprasProductos', 'FechaVencimientoLote') = 0
BEGIN
    ALTER TABLE ComprasProductos ADD IdLote varchar(30) NULL
    ALTER TABLE ComprasProductos ADD FechaVencimientoLote datetime NULL
END
GO


PRINT ''
PRINT '1. Tabla MovimientosStockProductos: Actualiza Fecha Vto Lote'
BEGIN
	MERGE INTO MovimientosStockProductos AS D
			USING (SELECT PL.Idsucursal, PL.IdProducto, PL.IdLote, MAX(PL.FechaVencimiento) as FechaVencimiento FROM MovimientosStockProductos MSP
					INNER JOIN ProductosLotes  PL ON MSP.IdSucursal = PL.Idsucursal AND MSP.IdProducto = PL.IdProducto AND MSP.IdLote = PL.IdLote
				   GROUP BY PL.Idsucursal, PL.IdProducto, PL.IdLote) AS O 
			ON D.IdSucursal = O.Idsucursal AND D.IdProducto = O.IdProducto AND D.IdLote = O.IdLote
		WHEN MATCHED THEN
			UPDATE SET D.VtoLote      = O.FechaVencimiento;
END
GO
