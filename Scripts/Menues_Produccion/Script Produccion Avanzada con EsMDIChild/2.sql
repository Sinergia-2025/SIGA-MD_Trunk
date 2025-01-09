-- Solo lo agrega si utiliza el Modulo de Cuentas Corrientes de Proveedores
IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'Produccion')

BEGIN
    INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible,
          IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
      VALUES
         ('ProduccionFormasABM', 'ABM de Formas de Productos', 'ABM de Formas de Productos', 'True', 'False', 'True', 'True', 
          'Produccion', 210, 'Eniac.Win', 'ProduccionFormasABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N','True');

    INSERT INTO RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'ProduccionFormasABM' AS Pantalla FROM Roles
        WHERE Id IN ('Adm', 'Supervisor', 'Oficina');

    INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible,
          IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
		  ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
      VALUES
         ('ProduccionProcesosABM', 'ABM de Procesos de Produccion', 'ABM de Procesos de Produccion', 'True', 'False', 'True', 'True', 
          'Produccion', 220, 'Eniac.Win', 'ProduccionProcesosABM', NULL, NULL
		  ,'True', 'S', 'N', 'N', 'N','True');

    INSERT INTO RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'ProduccionProcesosABM' AS Pantalla FROM Roles
        WHERE Id IN ('Adm', 'Supervisor', 'Oficina');

END;