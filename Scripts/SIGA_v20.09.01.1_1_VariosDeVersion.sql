PRINT ''
PRINT '1. Nueva Función: EstadosProyectosABM'
IF dbo.ExisteFuncion('CRMABMs') = 1 AND dbo.ExisteFuncion('ProyectosABM') = 1
BEGIN
	INSERT INTO Funciones
	    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
	    ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
	    ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
	VALUES
	    ('EstadosProyectosABM', 'Estados de Proyectos', 'Estados de Proyectos', 'True', 'False', 'True', 'True'
	    ,'CRMABMs', 515 ,'Eniac.Win', 'EstadosProyectosABM', NULL, NULL
	    ,'True', 'S', 'N', 'N', 'N')
	
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'EstadosProyectosABM' FROM RolesFunciones WHERE IdFuncion = 'ProyectosABM'
END
GO

PRINT ''
PRINT '2. Nueva Función: TiposChequesABM'
IF dbo.ExisteFuncion('Caja') = 1
BEGIN
	INSERT INTO Funciones
	    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
	    ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
	    ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
	VALUES
	    ('TiposChequesABM', 'ABM de Tipos de Cheques', 'ABM de Tipos de Cheques', 'True', 'False', 'True', 'True'
	    ,'Caja', 165, 'Eniac.Win', 'TiposChequesABM', NULL, NULL
	    ,'True', 'S', 'N', 'N', 'N')
	
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'TiposChequesABM' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO

PRINT ''
PRINT '3. Parametros: Actualizacion Tolerancia IVA Manual'

IF dbo.GetValorParametro('COMPRASTOLERANCIAIVAMANUAL') <= '1'
	UPDATE Parametros 
	   SET ValorParametro = '1'
	 WHERE IdParametro = 'COMPRASTOLERANCIAIVAMANUAL' 

GO