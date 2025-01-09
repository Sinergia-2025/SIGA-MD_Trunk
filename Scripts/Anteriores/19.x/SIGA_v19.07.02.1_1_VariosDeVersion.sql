
PRINT ''
PRINT '1. Nueva Función InformeDeCajayBancos'
IF dbo.ExisteFuncion('Caja') = 1
BEGIN
     PRINT ''
     PRINT '1.1. Inserta nueva funcion InformeDeCajayBancos'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('InformeDeCajayBancos', 'Informe de Caja y Bancos', 'Informe de Caja y Bancos', 'True', 'False', 'True', 'True'
        ,'Caja', 100, 'Eniac.Win', 'InformeDeCajayBancos', NULL, NULL,'True', 'S', 'N', 'N', 'N')
    PRINT ''
    PRINT '1.2. Asignar Roles a la Función InformeDeCajayBancos'
	    INSERT INTO RolesFunciones (IdRol,IdFuncion)
	    SELECT DISTINCT Id AS Rol, 'InformeDeCajayBancos' AS Pantalla FROM dbo.Roles
	     WHERE Id IN ('Adm', 'Supervisor')
END

PRINT ''
PRINT '2. Nueva opción de menú InformeDeCobranzaPorProducto'
IF dbo.ExisteFuncion('CuentasCorrientes') = 1 AND dbo.ExisteFuncion('InfComisionesProductos') = 1
BEGIN
     PRINT ''
     PRINT '2.1. Inserta nueva funcion InformeDeCajayBancos'
     INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
             ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
	 VALUES
	   ('InformeDeCobranzaPorProducto', 'Informe de Cobranza por Producto', 'Informe de Cobranza por Producto', 
		'True', 'False', 'True', 'True', 'CuentasCorrientes', 46, 'Eniac.Win', 'InfComisionesProductos', null, 'COBRANZA',
              'True', 'S', 'N', 'N', 'N')
	
    PRINT ''
    PRINT '2.2. Asignar Roles a la Función InformeDeCobranzaPorProducto'
	INSERT INTO RolesFunciones 
				  (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InformeDeCobranzaPorProducto' AS Pantalla FROM dbo.Roles
		WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END