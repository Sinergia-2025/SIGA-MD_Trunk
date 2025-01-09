PRINT ''
PRINT '5. Limpia Tabla Movimientos Stock.'
BEGIN
	DELETE FROM MovimientosStockProductosNrosSerie
	DELETE FROM MovimientosStockProductosLotes
	DELETE FROM MovimientosStockProductos
	DELETE FROM MovimientosStock
END
GO

PRINT ''
PRINT '6. Merge MovimientoCompras a MovimientosStock.'
BEGIN
	INSERT INTO MovimientosStock
		(IdSucursal
		,IdTipoMovimiento	
		,NumeroMovimiento	
		,FechaMovimiento		
		,Neto                
		,Total				
		,PorcentajeIVA		
		,IdCategoriaFiscal	
		,IdTipoComprobante	
		,Letra				
		,CentroEmisor		
		,NumeroComprobante	
		,Usuario				
		,Observacion			
		,TotalImpuestos      
		,IdCliente           
		,IdSucursal2			
		,PercepcionIVA		
		,PercepcionIB		
		,PercepcionGanancias	
		,PercepcionVarias	
		,IdProduccion		
		,IdProveedor			
		,IdEmpleado			
		,ImpuestosInternos		
	)	
	SELECT 
		 IdSucursal	
		,IdTipoMovimiento	
		,NumeroMovimiento	
		,FechaMovimiento		
		,0                
		,Total				
		,PorcentajeIVA		
		,IdCategoriaFiscal	
		,IdTipoComprobante	
		,Letra				
		,CentroEmisor		
		,NumeroComprobante	
		,Usuario				
		,Observacion			
		,0      
		,NULL           
		,IdSucursal2
		,PercepcionIVA		
		,PercepcionIB		
		,PercepcionGanancias	
		,PercepcionVarias	
		,IdProduccion		
		,IdProveedor			
		,IdEmpleado			
		,ImpuestosInternos		
	FROM MovimientosCompras AS MC
    UNION ALL
	SELECT 
		 IdSucursal
		,IdTipoMovimiento	
		,NumeroMovimiento	
		,FechaMovimiento		
		,Neto                 
		,Total				
		,0		
		,IdCategoriaFiscal	
		,IdTipoComprobante	
		,Letra				
		,CentroEmisor		
		,NumeroComprobante	
		,Usuario				
		,Observacion			
		,TotalImpuestos       
		,IdCliente            
		,NULL
		,0	
		,0	
		,0
		,0	
		,NULL		
		,NULL			
		,NULL			
		,0		
	FROM MovimientosVentas AS MV
END
GO

DECLARE @idDepositoOperativo  INT = 1
DECLARE @idDepositoReservado  INT = 99
DECLARE @idDepositoDefectuoso INT = 98

PRINT ''
PRINT '8. Merge MovimientoComprasProductos a MovimientosStockProductos.'
BEGIN
	INSERT INTO MovimientosStockProductos 
		(IdSucursal				
		,IdDeposito 
		,IdUbicacion 
		,IdTipoMovimiento		
		,NumeroMovimiento		
		,IdProducto				
		,Cantidad				
		,Cantidad2				
		,Precio					
		,IdLote					
		,Orden
		,IdDeposito2 
		,IdUbicacion2
		,IdaAtributoProducto01	
		,IdaAtributoProducto02	
		,IdaAtributoProducto03	
		,IdaAtributoProducto04
	)	
	SELECT 
		 IdSucursal
        , CASE WHEN CantidadReservado  <> 0 THEN @idDepositoReservado ELSE 
          CASE WHEN CantidadDefectuoso <> 0 THEN @idDepositoDefectuoso ELSE
                                                 @idDepositoOperativo  END END
		,1
		,IdTipoMovimiento		
		,NumeroMovimiento		
		,IdProducto				
		,Cantidad + CantidadReservado + CantidadDefectuoso
		,0
		,Precio					
		,IdLote					
		,Orden					
		,NULL
		,NULL
		,IdaAtributoProducto01		
		,IdaAtributoProducto02		
		,IdaAtributoProducto03	  
		,IdaAtributoProducto04	  
	FROM MovimientosComprasProductos AS MCP
    UNION ALL
	SELECT 
		 IdSucursal
		,(SELECT MIN(IdDeposito) FROM SucursalesDepositos AS SD WHERE SD.IdSucursal = MVP.IdSucursal)
		,1
		,IdTipoMovimiento		
		,NumeroMovimiento		
		,IdProducto				
		,Cantidad
		,0
		,Precio					
		,NULL					
		,Orden					
		,NULL
		,NULL
		,IdaAtributoProducto01		
		,IdaAtributoProducto02		
		,IdaAtributoProducto03	  
		,IdaAtributoProducto04	  
	FROM MovimientosVentasProductos AS MVP
END
GO

PRINT ''
PRINT '10. Merge MovimientoVentasProductosLotes a MovimientosStockProductosLotes.'
BEGIN
	INSERT INTO MovimientosStockProductosLotes 
		(IdSucursal
		,IdDeposito
		,IdUbicacion
		,IdTipoMovimiento
		,NumeroMovimiento
		,Orden			
		,IdProducto		
		,IdLote			
		,Cantidad
		,Cantidad2
	)	
	SELECT 
		 IdSucursal
		,(SELECT MIN(IdDeposito) FROM SucursalesDepositos AS SD WHERE SD.IdSucursal = MVPL.IdSucursal)
		,1
		,IdTipoMovimiento
		,NumeroMovimiento
		,Orden			
		,IdProducto		
		,IdLote			
		,Cantidad
		,0
	FROM MovimientosVentasProductosLotes AS MVPL
END
GO

PRINT ''
PRINT '11. Merge MovimientoComprasProductos a MovimientosStockProductos.'
BEGIN
	INSERT INTO MovimientosStockProductosNrosSerie  
		(IdSucursal			
		,IdDeposito 
		,IdUbicacion 
		,IdTipoMovimiento	
		,NumeroMovimiento	
		,Orden				
		,IdProducto			
		,NroSerie			
		,Cantidad			
		,Cantidad2			
	)	
	SELECT 
		 IdSucursal			
		,(SELECT MIN(IdDeposito) FROM SucursalesDepositos AS SD WHERE SD.IdSucursal = MCPS.IdSucursal)
		,1
		,IdTipoMovimiento	
		,NumeroMovimiento	
		,Orden				
		,IdProducto			
		,NroSerie			
		,Cantidad
		,0
	FROM MovimientosComprasProductosNrosSerie  AS MCPS
END
GO

PRINT ''
PRINT '12. Merge MovimientoVentasProductos a MovimientosStockProductos.'
BEGIN
	INSERT INTO MovimientosStockProductosNrosSerie  
		(IdSucursal			
		,IdDeposito 
		,IdUbicacion 
		,IdTipoMovimiento	
		,NumeroMovimiento	
		,Orden				
		,IdProducto			
		,NroSerie			
		,Cantidad
		,Cantidad2
	)	
	SELECT 
		 IdSucursal			
		,(SELECT MIN(IdDeposito) FROM SucursalesDepositos AS SD WHERE SD.IdSucursal = MVPS.IdSucursal)
		,1
		,IdTipoMovimiento	
		,NumeroMovimiento	
		,Orden				
		,IdProducto			
		,NroSerie			
		,Cantidad
		,0
	FROM MovimientosVentasProductosNrosSerie  AS MVPS
END
GO
