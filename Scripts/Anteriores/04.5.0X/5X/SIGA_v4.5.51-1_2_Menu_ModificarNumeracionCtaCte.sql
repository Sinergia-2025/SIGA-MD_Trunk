
-- Solo lo agrega si utiliza el Modulo de Cuentas Corrientes de Proveedores

IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'CuentasCorrientes')

BEGIN

	--Inserto la pantalla nueva

	INSERT INTO Funciones
		 (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
		 ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
	  VALUES
		 ('ConsultaNumeracionCtaCte', 'Consulta Numeracion', 'Consulta Numeracion', 'True', 'False', 'True', 'True',
		  'CuentasCorrientes', 310, 'Eniac.Win', 'ConsultaNumeracionVentas', NULL, 'CTACTECLIE')
	;

	INSERT INTO RolesFunciones 
		  (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'ConsultaNumeracionCtaCte' AS Pantalla FROM dbo.Roles
		WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
	;

	--Inserto la pantalla nueva


	INSERT INTO Funciones
		 (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
		 ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
	  VALUES
		 ('ModificarNumeracionCtaCte', 'Modificar Numeracion de C.C. Cliente', 'Modificar Numeracion de C.C. Cliente', 'True', 'False', 'True', 'True',
		  'CuentasCorrientes', 320, 'Eniac.Win', 'ModificarNumeracionVentas', NULL, 'CTACTECLIE')
	;

	INSERT INTO RolesFunciones 
		  (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'ModificarNumeracionCtaCte' AS Pantalla FROM dbo.Roles
		WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
	;

END;
