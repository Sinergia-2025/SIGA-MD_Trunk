PRINT ''
PRINT '1. Nueva Tabla: ComprasProductosNrosSerie'
CREATE TABLE ComprasProductosNrosSerie(
	IdSucursal INT NOT NULL,
	IdTipoComprobante VARCHAR(15) NOT NULL,
	Letra VARCHAR(1) NOT NULL,
	CentroEmisor INT NOT NULL,
	NumeroComprobante BIGINT NOT NULL,
	Orden INT NOT NULL,
	IdProveedor BIGINT NOT NULL,
	IdProducto VARCHAR(15) NOT NULL,
	NroSerie VARCHAR(50) NOT NULL
	PRIMARY KEY(IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, Orden, IdProveedor, IdProducto, NroSerie)
)
GO

PRINT ''
PRINT '2. FK_ComprasProductosNrosSerie_ComprasProductos'
ALTER TABLE ComprasProductosNrosSerie
	ADD CONSTRAINT FK_ComprasProductosNrosSerie_ComprasProductos
	FOREIGN KEY (IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante,  IdProveedor, Orden,IdProducto) REFERENCES ComprasProductos(IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, IdProveedor, Orden, IdProducto)
GO

PRINT ''
PRINT '3. Nueva Tabla: MovimientosComprasProductosNrosSerie'
CREATE TABLE MovimientosComprasProductosNrosSerie(
	IdSucursal INT NOT NULL,
	IdTipoMovimiento VARCHAR(15) NOT NULL,
	NumeroMovimiento BIGINT NOT NULL,
	Orden INT NOT NULL,
	Cantidad INT NOT NULL,
	IdProducto VARCHAR(15) NOT NULL,
	NroSerie VARCHAR(50) NOT NULL
	PRIMARY KEY(IdSucursal, IdTipoMovimiento, NumeroMovimiento, Orden, IdProducto, NroSerie)
)
GO

PRINT ''
PRINT '4. FK_MovimientosComprasProductosNrosSerie_MovimientosComprasProductos'
ALTER TABLE MovimientosComprasProductosNrosSerie 
	ADD CONSTRAINT FK_MovimientosComprasProductosNrosSerie_MovimientosComprasProductos
	FOREIGN KEY (IdSucursal, IdTipoMovimiento, NumeroMovimiento, Orden, IdProducto) REFERENCES MovimientosComprasProductos (IdSucursal, IdTipoMovimiento, NumeroMovimiento, Orden, IdProducto)
GO

PRINT ''
PRINT '5. Nuevo Campo: OrdenCompra en ProductosNrosSerie'
ALTER TABLE ProductosNrosSerie
	ADD OrdenCompra INT NULL
GO

PRINT ''
PRINT '6. Nueva Función: CuentasBancariasClaseABM'
IF dbo.ExisteFuncion('Bancos') = 1
BEGIN
	INSERT INTO Funciones
	    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
	    ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
	    ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
	VALUES
	    ('CuentasBancariasClaseABM', 'ABM de Clases de Cuentas Bancarias', 'ABM de Clases de Cuentas Bancarias', 'True', 'False', 'True', 'True'
	    ,'Bancos', 85, 'Eniac.Win', 'CuentasBancariasClaseABM', NULL, NULL
	    ,'True', 'S', 'N', 'N', 'N')
	
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'CuentasBancariasClaseABM' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO