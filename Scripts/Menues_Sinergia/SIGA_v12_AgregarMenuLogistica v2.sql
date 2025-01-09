IF NOT EXISTS (SELECT * FROM Funciones WHERE Id='Logistica' OR IdPadre='Logistica')
BEGIN
    -- Inserto el Menu Nuevo --
    INSERT INTO [dbo].Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible,
              IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,
              PermiteMultiplesInstancias,Plus,Express,Basica,PV)
      VALUES
             ('Logistica', 'Logistica', '', 'True', 'False', 'True', 'True',
              NULL, 3, NULL, NULL, NULL, NULL,
              'True', 'S', 'O', 'O', 'O');

    INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'Logistica' AS Pantalla FROM [dbo].Roles
       WHERE Id IN ('Adm', 'Supervisor', 'Oficina');

    -- Inserto las Pantallas Nuevas --
    INSERT INTO [dbo].Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
              IdPadre, Posicion, Archivo, Pantalla, Icono,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
         VALUES
             ('FacturacionPedido', 'Pedidos', 'Pedidos', 'True', 'False', 'True', 'True', 
              'Logistica', 10, 'Eniac.Win', 'FacturacionPedido', NULL,'True', 'S', 'O', 'O', 'O');

    INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'FacturacionPedido' AS Pantalla FROM [dbo].Roles
       WHERE Id IN ('Adm', 'Supervisor', 'Oficina');

    ----
    INSERT INTO [dbo].Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible,
              IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,
              PermiteMultiplesInstancias,Plus,Express,Basica,PV)
         VALUES
             ('GenerarArchivos', 'Generar Archivos', 'Generar Archivos', 'True', 'False', 'True', 'True', 
              'Logistica', 20, 'Eniac.Win', 'GenerarArchivos', NULL, NULL,
              'True', 'S', 'O', 'O', 'O');

    INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'GenerarArchivos' AS Pantalla FROM [dbo].Roles
       WHERE Id IN ('Adm', 'Supervisor', 'Oficina');

    ----
    INSERT INTO [dbo].Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
              IdPadre, Posicion, Archivo, Pantalla, Icono,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
         VALUES
             ('Preventa', 'PreVenta', 'PreVenta', 'True', 'False', 'True', 'True', 
              'Logistica', 30, 'Eniac.SiLIVE.Win', 'Preventa', NULL,'True', 'S', 'O', 'O', 'O');

    INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'Preventa' AS Pantalla FROM [dbo].Roles
       WHERE Id IN ('Adm', 'Supervisor', 'Oficina');

    ----
    INSERT INTO [dbo].Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
              IdPadre, Posicion, Archivo, Pantalla, Icono,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
         VALUES
             ('OrganizarEntregas', 'Organizar Entregas', 'Organizar Entregas', 'True', 'False', 'True', 'True', 
              'Logistica', 40, 'Eniac.SiLIVE.Win', 'OrganizarEntregas', NULL,'True', 'S', 'O', 'O', 'O');

    INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'OrganizarEntregas' AS Pantalla FROM [dbo].Roles
       WHERE Id IN ('Adm', 'Supervisor', 'Oficina');

    ----
    INSERT INTO [dbo].Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
              IdPadre, Posicion, Archivo, Pantalla, Icono,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
         VALUES
             ('Interfase', 'Interfase', 'Interfase', 'True', 'False', 'False', 'False', 
              'Logistica', 40, 'Eniac.SiLIVE.Win', 'Interfase', NULL,'True', 'S', 'O', 'O', 'O');


    INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'Interfase' AS Pantalla FROM [dbo].Roles
       WHERE Id IN ('Adm', 'Supervisor', 'Oficina');

    ----
    INSERT INTO [dbo].Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
              IdPadre, Posicion, Archivo, Pantalla, Icono,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
         VALUES
             ('RegistracionPagos', 'Registración de Pagos', 'Registración de Pagos', 'True', 'False', 'True', 'True', 
              'Logistica', 45, 'Eniac.SiLIVE.Win', 'RegistracionPagos', NULL,'True', 'S', 'O', 'O', 'O');

    INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'RegistracionPagos' AS Pantalla FROM [dbo].Roles
       WHERE Id IN ('Adm', 'Supervisor', 'Oficina');

    ----
    INSERT INTO [dbo].Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
              IdPadre, Posicion, Archivo, Pantalla, Icono,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
         VALUES
             ('RutasABM', 'ABM de Rutas', 'ABM de Rutas', 'True', 'False', 'True', 'True', 
              'Logistica', 60, 'Eniac.SiLIVE.Win', 'RutasABM', NULL,'True', 'S', 'O', 'O', 'O');

    INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'RutasABM' AS Pantalla FROM [dbo].Roles
       WHERE Id IN ('Adm', 'Supervisor', 'Oficina');

    ----
    INSERT INTO [dbo].Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
              IdPadre, Posicion, Archivo, Pantalla, Icono,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
         VALUES
             ('RutasClientes', 'Asignar Clientes a Rutas', 'Asignar Clientes a Rutas', 'True', 'False', 'True', 'True', 
              'Logistica', 70, 'Eniac.SiLIVE.Win', 'RutasClientes', NULL,'True', 'S', 'O', 'O', 'O');

    INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'RutasClientes' AS Pantalla FROM [dbo].Roles
       WHERE Id IN ('Adm', 'Supervisor', 'Oficina');

    ----
    INSERT INTO [dbo].Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
              IdPadre, Posicion, Archivo, Pantalla, Icono,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
         VALUES
             ('CargarOfertas', 'Ofertas', 'Ofertas', 'True', 'False', 'True', 'True', 
              'Logistica', 80, 'Eniac.SiLIVE.Win', 'CargarOfertas', NULL,'True', 'S', 'O', 'O', 'O');


    INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'CargarOfertas' AS Pantalla FROM [dbo].Roles
       WHERE Id IN ('Adm', 'Supervisor', 'Oficina');

    ----
    INSERT INTO [dbo].Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
              IdPadre, Posicion, Archivo, Pantalla, Icono,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
         VALUES
             ('SiLIVEConsultarRepartos', 'Consultar Repartos', 'Consultar Repartos', 'True', 'False', 'True', 'True', 
              'Logistica', 100, 'Eniac.SiLIVE.Win', 'ConsultarRepartos', NULL,'True', 'S', 'O', 'O', 'O');

    INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'SiLIVEConsultarRepartos' AS Pantalla FROM [dbo].Roles
       WHERE Id IN ('Adm', 'Supervisor', 'Oficina');

    ----
    INSERT INTO [dbo].Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
              IdPadre, Posicion, Archivo, Pantalla, Icono,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
         VALUES
             ('InfCajonesHectolitros', 'Inf. Cajones y Hectolitros', 'Inf. Cajones y Hectolitros', 'True', 'False', 'True', 'True', 
              'Logistica', 200, 'Eniac.SiLIVE.Win', 'InfCajonesHectolitros', NULL,'True', 'S', 'O', 'O', 'O');

    INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'InfCajonesHectolitros' AS Pantalla FROM [dbo].Roles
       WHERE Id IN ('Adm', 'Supervisor', 'Oficina');

    ----
    INSERT INTO [dbo].Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
              IdPadre, Posicion, Archivo, Pantalla, Icono,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
         VALUES
             ('InfCanalesYRubros', 'Inf. Canales y Rubros', 'Inf. Canales y Rubros', 'True', 'False', 'True', 'True', 
              'Logistica', 210, 'Eniac.SiLIVE.Win', 'InfCanalesYRubros', NULL,'True', 'S', 'O', 'O', 'O');

    INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'InfCanalesYRubros' AS Pantalla FROM [dbo].Roles
       WHERE Id IN ('Adm', 'Supervisor', 'Oficina');

END