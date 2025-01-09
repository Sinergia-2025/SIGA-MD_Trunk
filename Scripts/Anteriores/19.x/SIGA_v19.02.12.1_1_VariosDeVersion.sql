PRINT ''
PRINT '1. Agrego Informe Gestion (Solo SIAP).'
GO
IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                AND P.ValorParametro IN ('30710784236'))

BEGIN
	
	  INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
             ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
	 VALUES
	   ('GestionesInforme', 'Informe de Gestiones', 'Informe de Gestiones', 
		'True', 'False', 'True', 'True', 'Gestion', 50, 'Eniac.Win', 'GestionesInforme', null, null,
              'True', 'S', 'N', 'N', 'N')
	;

	INSERT INTO RolesFunciones 
				  (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'GestionesInforme' AS Pantalla FROM dbo.Roles
		WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
	;

	
END;

IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                                                     AND P.ValorParametro IN ('23238857449'))
BEGIN
    UPDATE Parametros
       SET ValorParametro = 500
     WHERE IdParametro = 'WEBARCHIVOSCLIENTESTAMANOPAGINAGET'
END
