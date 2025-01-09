
--Elimino los menues anteriores.

DELETE [dbo].RolesFunciones WHERE IdFuncion IN
 (
SELECT id FROM [dbo].[Funciones]
 WHERE id = 'Contabilidad' OR IdPadre='Contabilidad'
)
GO

DELETE [dbo].[Funciones]
 WHERE id='Contabilidad' OR IdPadre='Contabilidad'
GO

-- Inserto el Menu Nuevo --

INSERT INTO [dbo].Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
    ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros, PermiteMultiplesInstancias, Plus, Express, Basica, PV, IdModulo,EsMDIChild)
  VALUES
    ('Contabilidad', 'Contabilidad', '', 'True', 'False', 'True', 'True',
     NULL, 150, NULL, NULL, NULL, NULL, 1, 'S', 'N', 'N', 'N',NULL,'True')
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'Contabilidad' AS Pantalla FROM [dbo].Roles
   WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

-- Inserto las Pantallas Nuevas --

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono, 
          Parametros, PermiteMultiplesInstancias, Plus, Express, Basica, PV, IdModulo,EsMDIChild)
     VALUES
         ('ContabilidadAsientosABM', 'ABM de Asientos', 'ABM de Asientos', 'True', 'False', 'True', 'True', 
          'Contabilidad', 10, 'Eniac.Win', 'ContabilidadAsientosABM', NULL
          ,NULL, 1, 'S', 'N', 'N', 'N',NULL,'True')
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadAsientosABM' AS Pantalla FROM [dbo].Roles
   WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

----

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono, 
            Parametros, PermiteMultiplesInstancias, Plus, Express, Basica, PV, IdModulo,EsMDIChild)
     VALUES
         ('ContabilidadAsientosModeloABM', 'ABM de Asientos Modelos', 'ABM de Asientos Modelos', 'True', 'False', 'True', 'True', 
          'Contabilidad', 20, 'Eniac.Win', 'ContabilidadAsientosModeloABM', NULL
          ,NULL, 1, 'S', 'N', 'N', 'N',NULL,'True')
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadAsientosModeloABM' AS Pantalla FROM [dbo].Roles
   WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

----

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono
          ,Parametros, PermiteMultiplesInstancias, Plus, Express, Basica, PV, IdModulo,EsMDIChild)
     VALUES
         ('ContabilidadListadoAsientos', 'Consultar Asientos', 'Consultar Asientos', 'True', 'False', 'True', 'True', 
          'Contabilidad', 110, 'Eniac.Win', 'ContabilidadListadoAsientos', NULL
          ,NULL, 1, 'S', 'N', 'N', 'N',NULL,'True')
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadListadoAsientos' AS Pantalla FROM [dbo].Roles
   WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

----

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono
          ,Parametros, PermiteMultiplesInstancias, Plus, Express, Basica, PV, IdModulo,EsMDIChild)
     VALUES
         ('ContabilidadListadoLibroDiario', 'Libro Diario', 'Libro Diario', 'True', 'False', 'True', 'True', 
          'Contabilidad', 120, 'Eniac.Win', 'ContabilidadListadoLibroDiario', NULL
          ,NULL, 1, 'S', 'N', 'N', 'N',NULL,'True')
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadListadoLibroDiario' AS Pantalla FROM [dbo].Roles
   WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

----

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono
          ,Parametros, PermiteMultiplesInstancias, Plus, Express, Basica, PV, IdModulo,EsMDIChild)
     VALUES
         ('ContabilidadListadoLibroMayor', 'Libro Mayor', 'Libro Mayor', 'True', 'False', 'True', 'True', 
          'Contabilidad', 130, 'Eniac.Win', 'ContabilidadListadoLibroMayor', NULL
          ,NULL, 1, 'S', 'N', 'N', 'N',NULL,'True')
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadListadoLibroMayor' AS Pantalla FROM [dbo].Roles
   WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

----

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono
             ,Parametros, PermiteMultiplesInstancias, Plus, Express, Basica, PV, IdModulo,EsMDIChild)
     VALUES
         ('ContabilidadListadoBalanceSyS', 'Balance de Sumas y Saldos', 'Balance de Sumas y Saldos', 'True', 'False', 'True', 'True', 
          'Contabilidad', 140, 'Eniac.Win', 'ContabilidadListadoBalance', NULL
          ,NULL, 1, 'S', 'N', 'N', 'N',NULL,'True')
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadListadoBalanceSyS' AS Pantalla FROM [dbo].Roles
   WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

----

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono
          ,Parametros, PermiteMultiplesInstancias, Plus, Express, Basica, PV, IdModulo,EsMDIChild)
     VALUES
         ('ContabilidadListadoBceGral', 'Balance General', 'Balance General', 'True', 'False', 'True', 'True', 
          'Contabilidad', 150, 'Eniac.Win', 'ContabilidadListadoBceGral', NULL
          ,NULL, 1, 'S', 'N', 'N', 'N',NULL,'True')
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadListadoBceGral' AS Pantalla FROM [dbo].Roles
   WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

----

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono
          ,Parametros, PermiteMultiplesInstancias, Plus, Express, Basica, PV, IdModulo,EsMDIChild)
     VALUES
         ('ContabilidadGeneracionAsientos', 'Generar Asientos del Historial', 'Generar Asientos del Historial', 'True', 'False', 'True', 'True', 
          'Contabilidad', 200, 'Eniac.Win', 'ContabilidadGeneracionAsientos', NULL
          ,NULL, 1, 'S', 'N', 'N', 'N',NULL,'True')
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadGeneracionAsientos' AS Pantalla FROM [dbo].Roles
   WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

----

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono
           ,Parametros, PermiteMultiplesInstancias, Plus, Express, Basica, PV, IdModulo,EsMDIChild)
     VALUES
         ('ContabilidadProcesos', 'Importar Informacion desde la Gestion', 'Importar Informacion desde la Gestion', 'True', 'False', 'True', 'True', 
          'Contabilidad', 210, 'Eniac.Win', 'ContabilidadProcesos', NULL
            ,NULL, 1, 'S', 'N', 'N', 'N',NULL,'True')
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadProcesos' AS Pantalla FROM [dbo].Roles
   WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

----

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono
                 ,Parametros, PermiteMultiplesInstancias, Plus, Express, Basica, PV, IdModulo,EsMDIChild)
     VALUES
         ('ContabilidadExportacion', 'Exportar Asientos Contables', 'Exportar Asientos Contables', 'True', 'False', 'True', 'True', 
          'Contabilidad', 220, 'Eniac.Win', 'ContabilidadExportacion', NULL
           ,NULL, 1, 'S', 'N', 'N', 'N',NULL,'True')
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadExportacion' AS Pantalla FROM [dbo].Roles
   WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

----

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono
          ,Parametros, PermiteMultiplesInstancias, Plus, Express, Basica, PV, IdModulo,EsMDIChild)
     VALUES
         ('ContabilidadCuentasABM', 'ABM de Cuentas Contables', 'ABM de Cuentas Contables', 'True', 'False', 'True', 'True', 
          'Contabilidad', 300, 'Eniac.Win', 'ContabilidadCuentasABM', NULL
          ,NULL, 1, 'S', 'N', 'N', 'N',NULL,'True')
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadCuentasABM' AS Pantalla FROM [dbo].Roles
   WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

----

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono
          ,Parametros, PermiteMultiplesInstancias, Plus, Express, Basica, PV, IdModulo,EsMDIChild)
     VALUES
         ('ContabilidadCuentasRubro', 'ABM de Cuentas por Rubros de Productos', 'ABM de Cuentas por Rubros de Productos', 'True', 'False', 'True', 'True', 
          'Contabilidad', 310, 'Eniac.Win', 'ContabilidadCuentasRubro', NULL
          ,NULL, 1, 'S', 'N', 'N', 'N',NULL,'True')
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadCuentasRubro' AS Pantalla FROM [dbo].Roles
   WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

----

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono
          ,Parametros, PermiteMultiplesInstancias, Plus, Express, Basica, PV, IdModulo,EsMDIChild)
     VALUES
         ('ContabilidadArbolPlanDeCuentas', 'Consultar Plan de Cuentas por Jerarquia', 'Consultar Plan de Cuentas por Jerarquia', 'True', 'False', 'True', 'True', 
          'Contabilidad', 320, 'Eniac.Win', 'ContabilidadPlanesCuentasPreView', NULL
          ,NULL, 1, 'S', 'N', 'N', 'N',NULL,'True')
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadArbolPlanDeCuentas' AS Pantalla FROM [dbo].Roles
   WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

----

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono
          ,Parametros, PermiteMultiplesInstancias, Plus, Express, Basica, PV, IdModulo,EsMDIChild)
     VALUES
         ('ContabilidadEjeciciosABM', 'ABM de Ejercicios Contables', 'ABM de Ejercicios Contables', 'True', 'False', 'True', 'True', 
          'Contabilidad', 330, 'Eniac.Win', 'ContabilidadEjeciciosABM', NULL
          ,NULL, 1, 'S', 'N', 'N', 'N',NULL,'True')
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadEjeciciosABM' AS Pantalla FROM [dbo].Roles
   WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

----

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono
          ,Parametros, PermiteMultiplesInstancias, Plus, Express, Basica, PV, IdModulo,EsMDIChild)
     VALUES
         ('ContabilidadCentrosCostosABM', 'ABM de Centros Costos', 'ABM de Centros Costos', 'True', 'False', 'True', 'True', 
          'Contabilidad', 340, 'Eniac.Win', 'ContabilidadCentrosCostosABM', NULL
                 ,NULL, 1, 'S', 'N', 'N', 'N',NULL,'True')
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadCentrosCostosABM' AS Pantalla FROM [dbo].Roles
   WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

----

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono
          ,Parametros, PermiteMultiplesInstancias, Plus, Express, Basica, PV, IdModulo,EsMDIChild)
     VALUES
         ('ContabilidadPlanesABM', 'ABM de Plan de Cuentas', 'ABM de Plan de Cuentas', 'True', 'False', 'True', 'True', 
          'Contabilidad', 350, 'Eniac.Win', 'ContabilidadPlanesABM', NULL
             ,NULL, 1, 'S', 'N', 'N', 'N',NULL,'True')
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadPlanesABM' AS Pantalla FROM [dbo].Roles
   WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

----

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono
          ,Parametros, PermiteMultiplesInstancias, Plus, Express, Basica, PV, IdModulo,EsMDIChild)
     VALUES
         ('ImportarContabilidadCuentasXLS', 'Importar Cuentas Contables desde Excel', 'Importar Cuentas Contables desde Excel', 'True', 'False', 'True', 'True', 
          'Contabilidad', 400, 'Eniac.Win', 'ImportarContabilidadCuentasExcel', NULL
          ,NULL, 1, 'S', 'N', 'N', 'N',NULL,'True')
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ImportarContabilidadCuentasXLS' AS Pantalla FROM [dbo].Roles
   WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

