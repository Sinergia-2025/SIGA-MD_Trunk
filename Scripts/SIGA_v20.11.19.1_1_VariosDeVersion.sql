PRINT ''
PRINT '1. Corrección de registros pre-existentes VentasProductosLotes'
INSERT INTO VentasProductosLotes (IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, Orden, IdProducto, IdLote, FechaVencimiento, Cantidad)
	SELECT MV.IdSucursal
	  , MV.IdTipoComprobante
	  , MV.Letra
	  , MV.CentroEmisor
	  , MV.NumeroComprobante
	  , MVP.Orden
	  , MVP.IdProducto
	  , MVPL.IdLote
	  , PL.FechaVencimiento
	  , MVPL.Cantidad
	FROM MovimientosVentasProductosLotes MVPL
 INNER JOIN MovimientosVentasProductos MVP ON MVPL.IdSucursal = MVP.IdSucursal
										  AND MVPL.IdTipoMovimiento = MVP.IdTipoMovimiento
										  AND MVPL.NumeroMovimiento = MVP.NumeroMovimiento
										  AND MVPL.Orden = MVP.Orden
										  AND MVPL.IdProducto = MVP.IdProducto
 INNER JOIN MovimientosVentas MV ON MVP.IdSucursal = MV.IdSucursal
								AND MVP.IdTipoMovimiento = MV.IdTipoMovimiento
								AND MVP.NumeroMovimiento = MV.NumeroMovimiento
 INNER JOIN ProductosLotes PL ON MVPL.IdProducto = PL.IdProducto
                             AND MVPL.IdLote = PL.IdLote
                             AND MVPL.IdSucursal = PL.IdSucursal
 WHERE NOT EXISTS (SELECT * FROM VentasProductosLotes VP WHERE MV.IdSucursal = Vp.IdSucursal
 														  AND MV.IdTipoComprobante = Vp.IdTipoComprobante
 														  AND MV.Letra = Vp.Letra
 														  AND MV.CentroEmisor = Vp.CentroEmisor
 														  AND MV.NumeroComprobante = Vp.NumeroComprobante)
   AND EXISTS (SELECT * FROM VentasProductos VP WHERE MV.IdSucursal = Vp.IdSucursal
                                                  AND MV.IdTipoComprobante = Vp.IdTipoComprobante
                                                  AND MV.Letra = Vp.Letra
                                                  AND MV.CentroEmisor = Vp.CentroEmisor
                                                  AND MV.NumeroComprobante = Vp.NumeroComprobante
                                                  AND VP.Orden = MVP.Orden
                                                  AND VP.IdProducto = MVP.IdProducto)
GO

PRINT ''
PRINT '2. Tabla Calendarios: Nuevos Campos PublicarEnWeb y IdNave'
ALTER TABLE dbo.Calendarios ADD PublicarEnWeb bit NULL
ALTER TABLE dbo.Calendarios ADD IdNave smallint NULL
GO
UPDATE Calendarios SET PublicarEnWeb = 0;
ALTER TABLE dbo.Calendarios ALTER COLUMN PublicarEnWeb bit NOT NULL
GO
