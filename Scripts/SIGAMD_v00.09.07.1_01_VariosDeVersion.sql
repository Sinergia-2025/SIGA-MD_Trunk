PRINT ''
PRINT '1. Tabla ComprasProductos: Nuevos campos calidad'
IF dbo.ExisteCampo('ComprasProductos', 'InformeCalidadNumero') = 0
BEGIN
    ALTER TABLE ComprasProductos ADD InformeCalidadNumero Varchar(50) NULL
    ALTER TABLE ComprasProductos ADD InformeCalidadLink Varchar(MAX) NULL
END
GO

PRINT ''
PRINT 'F1. Nuevo Menu Asignacion de Actividades: MRP - asignacion de Actividades'
IF dbo.ExisteFuncion('MRP') = 1 AND dbo.ExisteFuncion('MRPAsignacionActividades') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('MRPAsignacionActividades', 'Asignacion de Actividades.', 'Asignacion de Actividades.', 'True', 'False', 'True', 'True'
        ,'MRP', 470, 'Eniac.Win', 'MRPAsignacionActividades', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'MRPAsignacionActividades' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO

PRINT ''
PRINT '1. Tabla EstadosOrdenesProduccion: Nuevo Estado PLANEADA'
IF NOT EXISTS (SELECT * FROM EstadosOrdenesProduccion WHERE IdEstado = 'PLANEADA')
BEGIN
	DECLARE @sOrden integer = (SELECT MAX(Orden) FROM EstadosOrdenesProduccion) + 1

	INSERT INTO EstadosOrdenesProduccion
           (idEstado
           ,IdTipoComprobante
           ,IdTipoEstado
           ,Orden
           ,Color
           ,ReservaMateriaPrima
           ,GeneraProductoTerminado
           ,TipoEstadoPedido
		   ,IdEstadoPedido)
     VALUES
           ('PLANEADA'
           ,NULL
           ,'EN PROCESO'
           ,@sOrden
           ,0
           ,0
           ,0
           ,NULL
           ,NULL)
END
GO

PRINT ''
PRINT '2. Tabla Parametros: Actualiza Parametro ESTADOORDENPRODUCCIONPLANIFICACION'
BEGIN
	UPDATE Parametros
		SET ValorParametro = 'PLANEADA'
	WHERE IdParametro = 'ESTADOORDENPRODUCCIONPLANIFICACION'
END
GO

PRINT ''
PRINT '1. Tabla EstadosOrdenesProduccionSucursales: Actualiza Deposito y Ubicacion Defecto'
BEGIN
	MERGE INTO EstadosOrdenesProduccionSucursales AS D
			USING (SELECT EOPS.IdEstado, EOPS.IdSucursal, max(SD.IdDeposito) as IdDeposito, SU.IdUbicacion from EstadosOrdenesProduccion EOP
					INNER JOIN EstadosOrdenesProduccionSucursales EOPS ON EOP.idEstado = EOPS.IdEstado
					INNER JOIN SucursalesDepositos SD ON SD.IdSucursal = EOPS.IdSucursal AND TipoDeposito = 'RESERVADO'
					INNER JOIN SucursalesUbicaciones SU ON SU.IdSucursal = EOPS.IdSucursal	AND SU.IdDeposito = SD.IdDeposito
					WHERE ReservaMateriaPrima = 1 group by EOPS.IdEstado, EOPS.IdSucursal, SU.IdUbicacion) AS O ON D.IdEstado = O.IdEstado AND O.IdSucursal = D.IdSucursal
		WHEN MATCHED THEN
			UPDATE SET D.IdDeposito      = O.IdDeposito
					 , D.IdUbicacion     = O.IdUbicacion;
END
GO
