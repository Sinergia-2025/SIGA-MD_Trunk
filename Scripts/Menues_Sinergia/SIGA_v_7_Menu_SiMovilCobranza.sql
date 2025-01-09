PRINT '1. Nuevo Menu: Cuentas Corrientes\SiMovil Cobranzas (Empresa Generica).'
GO

IF dbo.ExisteFuncion('CobranzasMovil') = 0
BEGIN
    --Inserto el Menú del Módulo
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
        VALUES
        ('CobranzasMovil', 'SiMovil', 'SiMovil Cobranzas', 'True', 'False', 'True', 'True'
        ,NULL, 85, 'Eniac.Win', NULL, NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')
    INSERT INTO RolesFunciones 
                    (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'CobranzasMovil' AS Pantalla FROM dbo.Roles
     WHERE Id IN ('Adm', 'Supervidor', 'Oficina')
END;

IF dbo.ExisteFuncion('CobranzasMovil') = 1
BEGIN
    IF dbo.ExisteFuncion('MovilRutasABM') = 0
    BEGIN
        PRINT '2. Nuevo Menu: Cuentas Corrientes\SiMovil Cobranzas\Rutas.'
        --Inserto la pantalla nueva
        INSERT INTO Funciones
            (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
            ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
          VALUES
            ('MovilRutasABM', 'Rutas', 'Rutas', 'True', 'False', 'True', 'True'
            ,'CobranzasMovil', 10, 'Eniac.Win', 'MovilRutasABM', NULL, NULL
            ,'True', 'S', 'N', 'N', 'N')
        INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
        SELECT DISTINCT Id AS Rol, 'MovilRutasABM' AS Pantalla FROM dbo.Roles
         WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
    END
    IF dbo.ExisteFuncion('MovilRutasClientes') = 0
    BEGIN
        PRINT '3. Nuevo Menu: Cuentas Corrientes\SiMovil Cobranzas\Rutas Clientes.'
        --Inserto la pantalla nueva
        INSERT INTO Funciones
            (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
            ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
          VALUES
            ('MovilRutasClientes', 'Asignar Clientes a Rutas', 'Rutas', 'True', 'False', 'True', 'True'
            ,'CobranzasMovil', 20, 'Eniac.Win', 'MovilRutasClientes', NULL, NULL
            ,'True', 'S', 'N', 'N', 'N')
        INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
        SELECT DISTINCT Id AS Rol, 'MovilRutasClientes' AS Pantalla FROM dbo.Roles
         WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
    END
    IF dbo.ExisteFuncion('SincronizacionSubidaMovil') = 0
    BEGIN
        PRINT '4. Nuevo Menu: Cuentas Corrientes\SiMovil Cobranzas\Subida SiMovil.'
        --Inserto la pantalla nueva
        INSERT INTO Funciones
            (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
            ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
          VALUES
            ('SincronizacionSubidaMovil', 'Sincronización - Subir a la Web', 'Sincronización - Subir a la Web', 'True', 'False', 'True', 'True'
            ,'CobranzasMovil', 50, 'Eniac.Win', 'SincronizacionSubidaMovil', NULL, NULL
            ,'True', 'S', 'N', 'N', 'N')
        INSERT INTO RolesFunciones (IdRol, IdFuncion)
        SELECT DISTINCT Id AS Rol, 'SincronizacionSubidaMovil' AS Pantalla FROM Roles
         WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
    END
    IF dbo.ExisteFuncion('InfClientesRuta') = 0
    BEGIN
	    INSERT INTO Funciones
            (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
            ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
	     VALUES
	       ('InfClientesRuta', 'Informe de Clientes en Rutas', 'Informe de Clientes en Rutas', 'True', 'False', 'True', 'True'
            ,'CobranzasMovil', 75, 'Eniac.Win', 'InfClientesRuta', NULL, NULL
            ,'True', 'S', 'N', 'N', 'N')
	    INSERT INTO RolesFunciones (IdRol,IdFuncion)
	    SELECT DISTINCT Id AS Rol, 'InfClientesRuta' AS Pantalla FROM dbo.Roles
	     WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
    END
    IF dbo.ExisteFuncion('InfClientesRuta') = 0
    BEGIN
	    INSERT INTO Funciones
            (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
            ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
	     VALUES
	        ('PreventaV3', 'Pedidos - Preventa (v3 - Web)', 'Pedidos - Preventa (v3 - Web)', 'True', 'False', 'True', 'True'
            ,'CobranzasMovil', 110, 'Eniac.Win', 'PreventaV3', NULL, NULL
            ,'True', 'S', 'N', 'N', 'N');
	    INSERT INTO RolesFunciones (IdRol,IdFuncion)
	    SELECT DISTINCT Id AS Rol, 'PreventaV3' AS Pantalla FROM dbo.Roles
	     WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
    END
    IF dbo.ExisteFuncion('SincronizacionBajadaCobranzas') = 0
    BEGIN
        PRINT '5. Nuevo Menu: Cuentas Corrientes\SiMovil Cobranzas\Bajada SiMovil.'
        --Inserto la pantalla nueva
        INSERT INTO Funciones
            (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
            ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
          VALUES
            ('SincronizacionBajadaCobranzas', 'Sincronización - Bajar Cobranzas', 'Sincronización - Bajar Cobranzas', 'True', 'False', 'True', 'True'
            ,'CobranzasMovil', 120, 'Eniac.Win', 'SincronizacionBajadaCobranzas', NULL, NULL
            ,'True', 'S', 'N', 'N', 'N')
        INSERT INTO RolesFunciones (IdRol, IdFuncion)
        SELECT DISTINCT Id AS Rol, 'SincronizacionBajadaCobranzas' AS Pantalla FROM Roles
         WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
    END




    IF dbo.ExisteFuncion('CobranzasMovil') = 1 AND dbo.ExisteFuncion('SiMovilWeb') = 0
    BEGIN
	    INSERT INTO Funciones
            (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
            ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
	     VALUES
            ('SiMovilWeb', 'SiMovil en la Web', 'SiMovil en la Web', 'True', 'False', 'True', 'True'
            ,'CobranzasMovil', 900, 'Eniac.Win', NULL, NULL, NULL
            ,'False','N','S','N','N');
	    INSERT INTO RolesFunciones (IdRol,IdFuncion)
	    SELECT IdRol, 'SiMovilWeb' FROM RolesFunciones
	     WHERE IdFuncion = 'PreventaV3';

	    INSERT INTO Funciones
            (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
            ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
	     VALUES
	        ('InfPedidosSiMovil', 'Informe de Pedidos Web de SiMovil', 'Informe de Pedidos Web de SiMovil', 'True', 'False', 'True', 'True'
            ,'SiMovilWeb',10, 'Eniac.Win', 'InfPedidosSiMovil', NULL, NULL
            ,'False','N','S','N','N');
	    INSERT INTO RolesFunciones (IdRol,IdFuncion)
	    SELECT IdRol, 'InfPedidosSiMovil' FROM RolesFunciones
	     WHERE IdFuncion = 'PreventaV3';

	    INSERT INTO Funciones
            (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
            ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
	     VALUES
	       ('AdminPedidosSiMovil', 'Administración de Pedidos Web de SiMovil', 'Administración de Pedidos Web de SiMovil', 'True', 'False', 'True', 'True'
           ,'SiMovilWeb',510, 'Eniac.Win', 'InfPedidosSiMovil', NULL, 'ADMIN'
           ,'False','N','S','N','N');
	    INSERT INTO RolesFunciones (IdRol,IdFuncion)
	    SELECT IdRol, 'AdminPedidosSiMovil' FROM RolesFunciones
	     WHERE IdFuncion = 'PreventaV3';
    END
END


--PRINT '6. Configura URL.'
--MERGE INTO Parametros AS P
--     USING (SELECT 'SIMOVILCOBRANZAURLBASE' AS IdParametro, 'http://w1021701.ferozo.com/api/'  ValorParametro, 'URL Base para Simovil Cobranzas' AS DescripcionParametro
--            ) AS PT ON P.IdParametro = PT.IdParametro
-- WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro
-- WHEN NOT MATCHED THEN INSERT (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL , PT.DescripcionParametro)
--;

--SELECT *
--  FROM Parametros
-- WHERE IdParametro = 'SIMOVILCOBRANZAURLBASE'
