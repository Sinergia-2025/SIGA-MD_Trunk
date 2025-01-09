IF dbo.ExisteFuncion('MRP') = 1 AND dbo.ExisteFuncion('MRPAQLAABM') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('MRPAQLAABM', 'ABM Límite de Calidad Aceptable A (AQL A)', 'ABM Límite de Calidad Aceptable A (AQL A)', 'True', 'False', 'True', 'True'
        ,'MRP', 2175, 'Eniac.Win', 'MRPAQLAABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'MRPAQLAABM' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
IF dbo.ExisteFuncion('MRP') = 1 AND dbo.ExisteFuncion('MRPAQLBABM') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('MRPAQLBABM', 'ABM Límite de Calidad Aceptable B (AQL B)', 'ABM Límite de Calidad Aceptable B (AQL B)', 'True', 'False', 'True', 'True'
        ,'MRP', 2175, 'Eniac.Win', 'MRPAQLBABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'MRPAQLBABM' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
IF dbo.ExisteFuncion('RequerimientosCompras') = 1 AND dbo.ExisteFuncion('InfReqComprasDetProducto') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('InfReqComprasDetProducto', 'Inf. Req. de Compra Det. Producto', 'Inf. Req. de Compra Det. Producto', 'True', 'False', 'True', 'True'
        ,'RequerimientosCompras', 550, 'Eniac.Win', 'InfReqComprasDetProducto', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InfReqComprasDetProducto' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO
