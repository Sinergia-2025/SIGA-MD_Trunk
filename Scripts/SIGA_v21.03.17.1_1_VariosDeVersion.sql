
PRINT ''
PRINT '1. Tabla CalidadProductosTiposServicios: Nuevo campo Prefijo'
ALTER TABLE CalidadProductosTiposServicios ADD Prefijo varchar(10) null
GO

--Metalsur
IF dbo.BaseConCuit('33631312379') = 1 OR dbo.SoyHAR() = 1
BEGIN
UPDATE CalidadProductosTiposServicios SET Prefijo = 'RE' where IdProductoTipoServicio = 2
UPDATE CalidadProductosTiposServicios SET Prefijo = 'SA' where IdProductoTipoServicio = 3 

END

ALTER TABLE CRMNovedades ALTER COLUMN Cantidad DECIMAL (12,2) NOT NULL
ALTER TABLE CRMNovedades ALTER COLUMN CantidadProducto DECIMAL (12,2) NULL
ALTER TABLE CRMNovedades ALTER COLUMN CantidadProductoPrestado DECIMAL (12,2) NULL
ALTER TABLE AuditoriaCRMNovedades ALTER COLUMN Cantidad DECIMAL (12,2) NOT NULL
ALTER TABLE AuditoriaCRMNovedades ALTER COLUMN CantidadProducto DECIMAL (12,2) NULL
ALTER TABLE AuditoriaCRMNovedades ALTER COLUMN CantidadProductoPrestado DECIMAL (12,2) NULL
ALTER TABLE CargosClientes ALTER COLUMN Cantidad DECIMAL (12,2) NOT NULL
ALTER TABLE LiquidacionesDetallesClientes ALTER COLUMN CantidadAdicional DECIMAL (12,2) NULL
ALTER TABLE MovimientosComprasProductos ALTER COLUMN Cantidad DECIMAL (16,4) NOT NULL
ALTER TABLE MovimientosComprasProductos ALTER COLUMN CantidadReservado DECIMAL (16,4) NOT NULL
ALTER TABLE MovimientosComprasProductos ALTER COLUMN CantidadDefectuoso DECIMAL (16,4) NOT NULL
ALTER TABLE MovimientosComprasProductos ALTER COLUMN CantidadFuturo DECIMAL (16,4) NOT NULL
ALTER TABLE MovimientosComprasProductos ALTER COLUMN CantidadFuturoReservado DECIMAL (16,4) NOT NULL
ALTER TABLE RepartosCobranzasProductos ALTER COLUMN CantidadDevuelta DECIMAL (16,4) NOT NULL
ALTER TABLE ProductosSucursales ALTER COLUMN StockDefectuoso DECIMAL (16,4) NOT NULL
ALTER TABLE ProductosSucursales ALTER COLUMN StockFuturo DECIMAL (16,4) NOT NULL
ALTER TABLE ProductosSucursales ALTER COLUMN StockFuturoReservado DECIMAL (16,4) NOT NULL
ALTER TABLE PedidosProductosProveedores_viejo ALTER COLUMN Cantidad DECIMAL (16,4) NOT NULL
ALTER TABLE ProductosOfertas ALTER COLUMN LimiteStock DECIMAL (16,4) NOT NULL
ALTER TABLE ProductosOfertas ALTER COLUMN CantidadConsumida DECIMAL (16,4) NOT NULL
ALTER TABLE ProduccionProductos ALTER COLUMN CantidadProducida DECIMAL (16,4) NOT NULL
ALTER TABLE ProduccionProductosComponentes ALTER COLUMN Cantidad DECIMAL (16,4) NOT NULL
ALTER TABLE PedidosProductosFormulas ALTER COLUMN Cantidad DECIMAL (16,4) NOT NULL
ALTER TABLE MovimientosVentasProductosLotes ALTER COLUMN Cantidad DECIMAL (16,4) NOT NULL
ALTER TABLE ComprasProductos ALTER COLUMN Cantidad DECIMAL (16,4) NOT NULL
ALTER TABLE ProductosSucursales ALTER COLUMN Stock DECIMAL (16,4) NOT NULL
ALTER TABLE ProductosSucursales ALTER COLUMN StockInicial DECIMAL (16,4) NOT NULL
ALTER TABLE ProductosSucursales ALTER COLUMN StockMinimo DECIMAL (16,4) NOT NULL
ALTER TABLE ProductosSucursales ALTER COLUMN StockMaximo DECIMAL (16,4) NOT NULL
ALTER TABLE ProductosSucursales ALTER COLUMN StockReservado DECIMAL (16,4) NULL
ALTER TABLE MovimientosVentasProductos ALTER COLUMN Cantidad DECIMAL (16,4) NOT NULL
ALTER TABLE PedidosProductosProveedores ALTER COLUMN Cantidad DECIMAL (16,4) NOT NULL
ALTER TABLE ProductosComponentes ALTER COLUMN Cantidad DECIMAL (16,4) NOT NULL
ALTER TABLE RepartosProductosSinDescargar ALTER COLUMN Cantidad DECIMAL (16,4) NOT NULL
ALTER TABLE PedidosProductosTiendasWeb ALTER COLUMN Cantidad DECIMAL (16,4) NOT NULL
ALTER TABLE ProductosLotes ALTER COLUMN CantidadInicial DECIMAL (16,4) NOT NULL
ALTER TABLE ProductosLotes ALTER COLUMN CantidadActual DECIMAL (16,4) NOT NULL
ALTER TABLE OrdenesProduccionProductos ALTER COLUMN Cantidad DECIMAL (16,4) NOT NULL
ALTER TABLE VentasProductos ALTER COLUMN Cantidad DECIMAL (16,4) NOT NULL
ALTER TABLE VentasProductos ALTER COLUMN CantidadManual DECIMAL (16,4) NOT NULL
ALTER TABLE VentasProductosFormulas ALTER COLUMN Cantidad DECIMAL (16,4) NOT NULL
ALTER TABLE VentasProductosLotes ALTER COLUMN Cantidad DECIMAL (16,4) NOT NULL
ALTER TABLE RepartosComprobantesProductos ALTER COLUMN Cantidad DECIMAL (16,4) NOT NULL
ALTER TABLE RepartosComprobantesProductos ALTER COLUMN CantidadCambio DECIMAL (16,4) NOT NULL
ALTER TABLE PedidosProductos ALTER COLUMN Cantidad DECIMAL (16,4) NOT NULL
ALTER TABLE PedidosProductos ALTER COLUMN CantidadManual DECIMAL (16,4) NOT NULL
ALTER TABLE TiposComprobantesProductos ALTER COLUMN Cantidad DECIMAL (16,4) NOT NULL


PRINT ''
PRINT '2. Agrega Funcion ProductosListasControl: ProdListControl_ElimAgregList'
GO
BEGIN TRANSACTION
IF dbo.ExisteFuncion('ProdListControl_ElimAgregList') = 0 AND dbo.ExisteFuncion('ProductosListasControl') = 1
--Inserto la Pantalla Nueva
BEGIN
    PRINT ''
    PRINT '12.1. Insertar funcion'
	INSERT INTO Funciones
	   (Id, Nombre, Descripcion
	   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica)
	 VALUES
	   ('ProdListControl_ElimAgregList', 'Productos Listas de Control:Elimina/Agrega Listas de Control', 'Productos Listas de Control:Elimina/Agrega Listas de Control', 
		'False', 'False', 'True', 'True', 'ProductosListasControl',888, 'Eniac.Win', 'ProdListControl_ElimAgregList', null, null,'N','S','N','N')
	END;
	   	;
	COMMIT
GO

PRINT ''
PRINT '3. Agrega Funcion a ListasControlABM: ListasControlABM_ElimAgregItem'
GO
BEGIN TRANSACTION
IF dbo.ExisteFuncion('ListasControlABM_ElimAgregItem') = 0 AND dbo.ExisteFuncion('ListasControlABM') = 1
--Inserto la Pantalla Nueva
BEGIN
    PRINT ''
    PRINT '3.1. Insertar funcion'
	INSERT INTO Funciones
	   (Id, Nombre, Descripcion
	   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica)
	 VALUES
	   ('ListasControlABM_ElimAgregItem', 'ABM Listas de Control: Elimina/Agrega Items Listas Control', 'ABM Listas de Control: Elimina/Agrega Items Listas Control', 
		'False', 'False', 'True', 'True', 'ListasControlABM',888, 'Eniac.Win', 'ListasControlABM_ElimAgregItem', null, null,'N','S','N','N')
	END;
	   	;
	COMMIT
GO


PRINT ''
PRINT '4. Tabla Productos/AuditoriaProductos: nuevo campo Fecha Entrega Reprogramada'
ALTER TABLE Productos ADD CalidadFechaEntReProg datetime null
GO
ALTER TABLE AuditoriaProductos ADD CalidadFechaEntReProg datetime null
GO

PRINT ''
PRINT '5. Agrega Funcion Productos: ProdCalidadABM_FechaEntReProgramada'
GO
BEGIN TRANSACTION
IF dbo.ExisteFuncion('ProdCalidadABM_FechaEntReProg') = 0 AND dbo.ExisteFuncion('ProductosCalidadABM') = 1
--Inserto la Pantalla Nueva
BEGIN
    PRINT ''
    PRINT '12.1. Insertar funcion'
	INSERT INTO Funciones
	   (Id, Nombre, Descripcion
	   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica)
	 VALUES
	   ('ProdCalidadABM_FechaEntReProg', 'Productos Calidad: Fecha Entrega Reprogramada', 'Productos Calidad: Fecha Entrega Reprogramada', 
		'False', 'False', 'True', 'True', 'ProductosCalidadABM',888, 'Eniac.Win', 'ProdCalidadABM_FechaEntReProgr', null, null,'N','S','N','N')
	END;
	COMMIT
GO

IF dbo.BaseConCuit('33631312379') = 1 OR dbo.SoyHAR() = 1
BEGIN
UPDATE Productos SET CalidadFechaEntReProg = CalidadFechaEntProg
END
