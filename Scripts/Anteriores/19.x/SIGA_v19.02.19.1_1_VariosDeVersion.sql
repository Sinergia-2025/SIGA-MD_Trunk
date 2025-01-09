PRINT ''
PRINT '1. Nueva opción de Menu Informe de Turnos Detallado por Zonas'

--JIMENA HOMS
IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                    AND P.ValorParametro IN ('27329245069'))
--Inserto la Pantalla Nueva
BEGIN
	INSERT INTO Funciones (Id, Nombre, Descripcion , EsMenu, EsBoton, [Enabled], Visible, 
						   IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros, 
						   PV, Plus, Express, Basica)
	VALUES ('InfTurnosCalendariosPorZonas', 'Informe de Turnos Detallado por Zonas', 'Informe de Turnos Detallado por Zonas', 'True', 'False', 'True', 'True',
			'Turnos',150,'Eniac.Win','InfTurnosCalendariosPorZonas',NULL,NULL,
			'N','S','N','N');

	INSERT INTO RolesFunciones (IdRol, IdFuncion)
	SELECT DISTINCT Id AS Rol,'InfTurnosCalendariosPorZonas' AS Pantalla
	  FROM dbo.Roles
	 WHERE Id IN ('Adm','Supervisor','Oficina') ;
END;

GO

PRINT ''
PRINT '2. Nueva opción de Menu Tablero de Comando - Actualizacion Automática'
IF EXISTS (SELECT Id FROM Funciones WHERE Id = 'TableroDeComando')
BEGIN
	INSERT INTO Funciones
				(Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
				,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
				,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
	VALUES
		('TableroDeComando-Automatica', 'Tablero de Comando - Actualizacion Automática', 'Tablero de Comando - Actualizacion Automática', 'False', 'False', 'True', 'True', 
		'TableroDeComando', 900, 'Eniac.Win', NULL, NULL, NULL,
		'True', 'S', 'N', 'N', 'N')
	;

	IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' AND P.ValorParametro IN ('33711345499'))
	BEGIN
		INSERT INTO RolesFunciones (IdRol,IdFuncion)
		SELECT IdRol, 'TableroDeComando-Automatica'
			FROM Roles R
			INNER JOIN UsuariosRoles UR ON UR.IdRol = R.Id
			WHERE UR.IdUsuario = 'tablero'
	END
	ELSE
	BEGIN
		INSERT INTO RolesFunciones (IdRol,IdFuncion)
		SELECT IdRol, 'TableroDeComando-Automatica'
			FROM RolesFunciones RF
			WHERE RF.IdFuncion = 'TableroDeComando'
	END
END
