
IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                AND P.ValorParametro IN ('30710784236'))

BEGIN

	 INSERT INTO Funciones
				 (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
				 ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
				 ,PermiteMultiplesInstancias, Plus, Express, Basica,PV)
	SELECT 'Gestion' AS XXId, Nombre, Nombre AS xxDescripcion, EsMenu, EsBoton, [Enabled], Visible
		 , IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
		 , PermiteMultiplesInstancias, Plus, Express, Basica,PV
	  FROM Funciones
	 WHERE Id = 'Gestión'
	;

	UPDATE RolesFunciones
	   SET IdFuncion = 'Gestion'
	 WHERE IdFuncion = 'Gestión'
	;

	UPDATE Funciones
	   SET IdPadre = 'Gestion'
	 WHERE IdPadre = 'Gestión'
	;

	DELETE Funciones
	 WHERE Id = 'Gestión'
	;

	INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
             ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
	 VALUES
	   ('AcuerdosInforme', 'Informe de Acuerdos Realizados', 'Informe de Acuerdos Realizados', 
		'True', 'True', 'True', 'True', 'Gestion', 44, 'Eniac.Win', 'AcuerdosInforme', null, null,
              'True', 'S', 'N', 'N', 'N')
	;

	INSERT INTO RolesFunciones 
				  (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'AcuerdosInforme' AS Pantalla FROM dbo.Roles
		WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
	;

END;
