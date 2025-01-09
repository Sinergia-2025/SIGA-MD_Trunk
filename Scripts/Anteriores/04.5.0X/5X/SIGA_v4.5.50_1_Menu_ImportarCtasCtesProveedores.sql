
-- Solo lo agrega si utiliza el Modulo de Cuentas Corrientes de Proveedores

IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'CuentasCorrientesProveedores')

BEGIN

	--Inserto la pantalla nueva

	INSERT INTO Funciones
			   (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
			   ,IdPadre, Posicion, Archivo, Pantalla, Icono)
		 VALUES
			   ('ImportarCtasCtesProveedores', 'Importar Comprobantes con Saldos de Proveedores desde Excel', 'Importar Comprobantes con Saldos de Proveedores desde Excel', 'True', 'False', 'True', 'True',
			   'CuentasCorrientesProveedores', 200, 'Eniac.Win', 'ImportarCtasCtesProveedores', NULL)
	;

	INSERT INTO RolesFunciones 
				  (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'ImportarCtasCtesProveedores' AS Pantalla FROM dbo.Roles
		WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
	;

END;
