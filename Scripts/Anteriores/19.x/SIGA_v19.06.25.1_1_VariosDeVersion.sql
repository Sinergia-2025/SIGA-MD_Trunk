
PRINT ''
PRINT '1. Nueva opción de menú ModificarComprobantesDeCtaCte'
IF dbo.ExisteFuncion('CuentasCorrientes') = 1 AND dbo.ExisteFuncion('ModificarComprobantesDeCtaCte') = 0
BEGIN
  INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
             ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
	 VALUES
	   ('ModificarComprobantesDeCtaCte', 'Modificar Comprobantes de Cuenta Corriente', 'Modificar Comprobantes de Cuenta Corriente', 
		'True', 'False', 'True', 'True', 'CuentasCorrientes', 46, 'Eniac.Win', 'ModificarComprobantesDeVentas', null, 'CTACTE',
              'True', 'S', 'N', 'N', 'N')
	

	INSERT INTO RolesFunciones 
				  (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'ModificarComprobantesDeCtaCte' AS Pantalla FROM dbo.Roles
		WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
