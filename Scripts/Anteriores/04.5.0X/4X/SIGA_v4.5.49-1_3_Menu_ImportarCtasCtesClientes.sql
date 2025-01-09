
-- Solo lo agrega si utiliza el Modulo de Cuentas Corrientes de Clientes

IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'CuentasCorrientes')

BEGIN

	--Inserto la pantalla nueva

	INSERT INTO Funciones
			   (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
			   ,IdPadre, Posicion, Archivo, Pantalla, Icono)
		 VALUES
			   ('ImportarCtasCtesClientes', 'Importar Comprobantes con Saldos de Clientes desde Excel', 'Importar Comprobantes con Saldos de Clientes desde Excel', 'True', 'False', 'True', 'True',
			   'CuentasCorrientes', 200, 'Eniac.Win', 'ImportarCtasCtesClientes', NULL)
	;

	INSERT INTO RolesFunciones 
				  (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'ImportarCtasCtesClientes' AS Pantalla FROM dbo.Roles
		WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
	;

END;
