PRINT ''
PRINT '1. Tabla Productos: Nuevos campos EnviarSinCargo y CodigoProductoTiendaNube, CodigoProductoMercadoLibre, IdVarianteProducto'
ALTER TABLE Productos ADD EnviarSinCargo BIT NULL
ALTER TABLE Productos ADD CodigoProductoTiendaNube VARCHAR(30) NULL
ALTER TABLE Productos ADD CodigoProductoMercadoLibre VARCHAR(30) NULL
ALTER TABLE Productos ADD IdVarianteProducto VARCHAR(30) NULL
GO

PRINT ''
PRINT '1.1. Tabla Productos: Actualización de registros pre-existentes para EnviarSinCargo'
UPDATE Productos SET EnviarSinCargo = 'True'
GO

PRINT ''
PRINT '1.2. Tabla Productos: NOT NULL para EnviarSinCargo'
ALTER TABLE Productos ALTER COLUMN EnviarSinCargo BIT NOT NULL
GO

PRINT ''
PRINT '1.3. Tabla AuditoriasProductos: Nuevos campos EnviarSinCargo y CodigoProductoTiendaNube, CodigoProductoMercadoLibre, IdVarianteProducto'
ALTER TABLE AuditoriaProductos ADD EnviarSinCargo BIT NULL
ALTER TABLE AuditoriaProductos ADD CodigoProductoTiendaNube VARCHAR(30) NULL
ALTER TABLE AuditoriaProductos ADD CodigoProductoMercadoLibre VARCHAR(30) NULL
ALTER TABLE AuditoriaProductos ADD IdVarianteProducto VARCHAR(30) NULL
GO

PRINT ''
PRINT '2. Tabla Rubros: Nuevos campos: IdRubroTiendaNube y IdRubroMercadoLibre'
ALTER TABLE Rubros ADD IdRubroTiendaNube VARCHAR(30) NULL
ALTER TABLE Rubros ADD IdRubroMercadoLibre VARCHAR(30) NULL
GO

PRINT ''
PRINT '2.1. Tabla SubRubros: Nuevos campos: IdRubroTiendaNube y IdRubroMercadoLibre'
ALTER TABLE SubRubros ADD IdSubRubroTiendaNube VARCHAR(30) NULL
ALTER TABLE SubRubros ADD IdSubRubroMercadoLibre VARCHAR(30) NULL
GO

PRINT ''
PRINT '2.2. Tabla SubSubRubros: Nuevos campos: IdRubroTiendaNube y IdRubroMercadoLibre'
ALTER TABLE SubSubRubros ADD IdSubSubRubroTiendaNube VARCHAR(30) NULL
ALTER TABLE SubSubRubros ADD IdSubSubRubroMercadoLibre VARCHAR(30) NULL
GO


PRINT ''
PRINT '3. Tabla Pedidos: Nuevos campos IdPedidoTiendaNube y IdPedidoMercadoLibre'
ALTER TABLE Pedidos ADD IdPedidoTiendaNube VARCHAR(30) NULL 
ALTER TABLE Pedidos ADD IdPedidoMercadoLibre VARCHAR(30) NULL
GO

PRINT ''
PRINT '4. Tabla Clientes: Nuevos campos IdClienteTiendaNube y IdClienteMercadoLibre'
ALTER TABLE Clientes ADD IdClienteTiendaNube VARCHAR(30) NULL 
ALTER TABLE Clientes ADD IdClienteMercadoLibre VARCHAR(30) NULL
GO

PRINT ''
PRINT '5. Tabla AuditoriaClientes: Nuevos campos IdClienteTiendaNube y IdClienteMercadoLibre'
ALTER TABLE AuditoriaClientes ADD IdClienteTiendaNube VARCHAR(30) NULL 
ALTER TABLE AuditoriaClientes ADD IdClienteMercadoLibre VARCHAR(30) NULL
GO

PRINT ''
PRINT '6. Tabla Prospectos: Nuevos campos IdProspectoTiendaNube y IdProspectoMercadoLibre'
ALTER TABLE Prospectos ADD IdProspectoTiendaNube VARCHAR(30) NULL 
ALTER TABLE Prospectos ADD IdProspectoMercadoLibre VARCHAR(30) NULL
GO

PRINT ''
PRINT '7. Tabla AuditoriaProspectos: Nuevos campos IdProspectoTiendaNube y IdProspectoMercadoLibre'
ALTER TABLE AuditoriaProspectos ADD IdProspectoTiendaNube VARCHAR(30) NULL 
ALTER TABLE AuditoriaProspectos ADD IdProspectoMercadoLibre VARCHAR(30) NULL
GO

PRINT ''
PRINT '8. Nueva Tabla: FechasSincronizaciones'
CREATE TABLE FechasSincronizaciones(
	FechaSubida DATETIME NULL,
	FechaBajada DATETIME NULL,
	SistemaDestino VARCHAR(200) NOT NULL,
	Tabla VARCHAR(200) NOT NULL,
	IdUsuario VARCHAR(10) NOT NULL,
	FechaActualizacion DATETIME NOT NULL,
	NroVersionAplicacion VARCHAR(50) NOT NULL
	PRIMARY KEY (Tabla, SistemaDestino)
)
GO

PRINT ''
PRINT '8.1 FK_FechasSincronizaciones_Usuarios'
ALTER TABLE FechasSincronizaciones
	ADD CONSTRAINT FK_FechasSincronizaciones_Usuarios
	FOREIGN KEY (IdUsuario) REFERENCES Usuarios (Id)
GO

PRINT ''
PRINT '9. Nuevo parámetro: Lista de Precios predeterminada para Tienda Nube'
DECLARE @idParametro VARCHAR(MAX) = 'TIENDANUBELISTAPRECIOS'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Tienda Nube: Lista de Precios Predeterminada'
MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, ValorParametro, @descripcionParametro DescripcionParametro 
		         FROM Parametros WHERE IdParametro = 'LISTAPRECIOSPREDETERMINADA') AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;

PRINT ''
PRINT '10 Nueva Función: Informe de Saldos Antiguedad de Deuda Proveedores'
IF dbo.ExisteFuncion('CuentasCorrientesProveedores') = 1 AND dbo.ExisteFuncion('InfSaldosAntiguedadDeudaProv') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('InfSaldosAntiguedadDeudaProv', 'Informe de Saldos Antiguedad de Deuda Proveedores', 'Informe de Saldos Antiguedad de Deuda Proveedores', 'True', 'False', 'True', 'True'
        ,'CuentasCorrientesProveedores', 45, 'Eniac.Win', 'InfSaldosAntiguedadDeudaProv', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InfSaldosAntiguedadDeudaProv' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
