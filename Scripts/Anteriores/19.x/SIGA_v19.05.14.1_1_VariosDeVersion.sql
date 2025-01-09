IF dbo.ExisteFuncion('FichasABM2') = 1
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('Fichas-BuscarTodasSucursales', 'Fichas - Permite seleccionar otras sucursales', 'Fichas - Permite seleccionar otras sucursales', 'True', 'False', 'True', 'True'
        ,'FichasABM2', 999, 'Eniac.Win', 'Fichas-BuscarTodasSucursales', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')

/*   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'Fichas-BuscarTodasSucursales' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor')
*/
END