
    --- Inserto las Pantallas Nuevas // Luego Reorganizo
	
	INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('OrdenesDeProduccion', 'Ordenes de Produccion', 'Ordenes de Produccion', 'True', 'False', 'True', 'True', 
          'Produccion', 10, 'Eniac.Win', 'OrdenesDeProduccion', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N','True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'OrdenesDeProduccion' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
	 GO

	 -----------------------

	INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('OrdenesProduccionAdmin', 'Administrar Ordenes de Producción', 'Administrar Ordenes de Producción', 'True', 'False', 'True', 'True', 
          'Produccion', 20, 'Eniac.Win', 'OrdenesProduccionAdmin', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N','True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'OrdenesProduccionAdmin' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
	 GO

	 ---------------------

	INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('ConsultarOrdenesProduccion', 'Consultar Ordenes de Produccion', 'Consultar Ordenes de Produccion', 'True', 'False', 'True', 'True', 
          'Produccion', 15, 'Eniac.Win', 'ConsultarOrdenesProduccion', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N','True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'ConsultarOrdenesProduccion' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
	 GO

	 ------------------------

	 INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('AnularOrdenesProduccion', 'Anular Ordenes de Producción', 'Anular Ordenes de Producción', 'True', 'False', 'True', 'True', 
          'Produccion', 15, 'Eniac.Win', 'AnularOrdenesProduccion', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N','True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'AnularOrdenesProduccion' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
	 GO

	 -----------------------

	  INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('EstadosOrdenesProduccionABM', 'ABM Estados de Ordenes de Producción', 'ABM Estados de Ordenes de Producción', 'True', 'False', 'True', 'True', 
          'Produccion', 22, 'Eniac.Win', 'EstadosOrdenesProduccionABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N','True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'EstadosOrdenesProduccionABM' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
	 GO

	 -------------------------

	 UPDATE Funciones SET
   Posicion = 
   (CASE ID WHEN 'OrdenesDeProduccion' THEN 10 
            WHEN 'ConsultarOrdenesProduccion' THEN 20 
            WHEN 'AnularOrdenesProduccion' THEN 30 
            WHEN 'OrdenesProduccionAdmin' THEN 40 
            WHEN 'MovimientosDeProduccion' THEN 50 
            WHEN 'AnularProduccion' THEN 60 
            WHEN 'InfProduccion' THEN 70 
            WHEN 'InfProduccionTotalPorProducto' THEN 80 
            WHEN 'CalculoProduccion' THEN 90 
            WHEN 'FormulasABM' THEN 100 
            WHEN 'InfFormulas' THEN 110 
            WHEN 'ImportarFormulasExcel' THEN 120 
            WHEN 'EstadosOrdenesProduccionABM' THEN 200 
            ELSE 0 END)
  WHERE IdPadre = 'Produccion'
GO