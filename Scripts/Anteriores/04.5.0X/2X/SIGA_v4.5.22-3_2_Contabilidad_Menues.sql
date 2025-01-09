
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
    ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
    ('Contabilidad', 'Contabilidad', '', 'True', 'False', 'True', 'True',
     NULL, 150, NULL, NULL, NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'Contabilidad' AS Pantalla FROM [dbo].Roles
   WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

-- Inserto las Pantallas Nuevas --

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('ContabilidadAsientosABM', 'ABM de Asientos', 'ABM de Asientos', 'True', 'False', 'True', 'True', 
          'Contabilidad', 10, 'Eniac.Win', 'ContabilidadAsientosABM', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadAsientosABM' AS Pantalla FROM [dbo].Roles
   WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

----

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('ContabilidadAsientosModeloABM', 'ABM de Asientos Modelos', 'ABM de Asientos Modelos', 'True', 'False', 'True', 'True', 
          'Contabilidad', 20, 'Eniac.Win', 'ContabilidadAsientosModeloABM', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadAsientosModeloABM' AS Pantalla FROM [dbo].Roles
   WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

----

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('ContabilidadListadoAsientos', 'Consultar Asientos', 'Consultar Asientos', 'True', 'False', 'True', 'True', 
          'Contabilidad', 110, 'Eniac.Win', 'ContabilidadListadoAsientos', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadListadoAsientos' AS Pantalla FROM [dbo].Roles
   WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

----

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('ContabilidadListadoLibroDiario', 'Libro Diario', 'Libro Diario', 'True', 'False', 'True', 'True', 
          'Contabilidad', 120, 'Eniac.Win', 'ContabilidadListadoLibroDiario', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadListadoLibroDiario' AS Pantalla FROM [dbo].Roles
   WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

----

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('ContabilidadListadoLibroMayor', 'Libro Mayor', 'Libro Mayor', 'True', 'False', 'True', 'True', 
          'Contabilidad', 130, 'Eniac.Win', 'ContabilidadListadoLibroMayor', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadListadoLibroMayor' AS Pantalla FROM [dbo].Roles
   WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

----

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('ContabilidadListadoBalanceSyS', 'Balance de Sumas y Saldos', 'Balance de Sumas y Saldos', 'True', 'False', 'True', 'True', 
          'Contabilidad', 140, 'Eniac.Win', 'ContabilidadListadoBalance', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadListadoBalanceSyS' AS Pantalla FROM [dbo].Roles
   WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

----

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('ContabilidadListadoBceGral', 'Balance General', 'Balance General', 'True', 'False', 'True', 'True', 
          'Contabilidad', 150, 'Eniac.Win', 'ContabilidadListadoBceGral', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadListadoBceGral' AS Pantalla FROM [dbo].Roles
   WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

----

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('ContabilidadGeneracionAsientos', 'Generar Asientos del Historial', 'Generar Asientos del Historial', 'True', 'False', 'True', 'True', 
          'Contabilidad', 200, 'Eniac.Win', 'ContabilidadGeneracionAsientos', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadGeneracionAsientos' AS Pantalla FROM [dbo].Roles
   WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

----

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('ContabilidadProcesos', 'Importar Informacion desde la Gestion', 'Importar Informacion desde la Gestion', 'True', 'False', 'True', 'True', 
          'Contabilidad', 210, 'Eniac.Win', 'ContabilidadProcesos', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadProcesos' AS Pantalla FROM [dbo].Roles
   WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

----

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('ContabilidadExportacion', 'Exportar Asientos Contables', 'Exportar Asientos Contables', 'True', 'False', 'True', 'True', 
          'Contabilidad', 220, 'Eniac.Win', 'ContabilidadExportacion', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadExportacion' AS Pantalla FROM [dbo].Roles
   WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

----

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('ContabilidadCuentasABM', 'ABM de Cuentas Contables', 'ABM de Cuentas Contables', 'True', 'False', 'True', 'True', 
          'Contabilidad', 300, 'Eniac.Win', 'ContabilidadCuentasABM', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadCuentasABM' AS Pantalla FROM [dbo].Roles
   WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

----

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('ContabilidadCuentasRubro', 'ABM de Cuentas por Rubros de Productos', 'ABM de Cuentas por Rubros de Productos', 'True', 'False', 'True', 'True', 
          'Contabilidad', 310, 'Eniac.Win', 'ContabilidadCuentasRubro', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadCuentasRubro' AS Pantalla FROM [dbo].Roles
   WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

----

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('ContabilidadArbolPlanDeCuentas', 'Consultar Plan de Cuentas por Jerarquia', 'Consultar Plan de Cuentas por Jerarquia', 'True', 'False', 'True', 'True', 
          'Contabilidad', 320, 'Eniac.Win', 'ContabilidadPlanesCuentasPreView', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadArbolPlanDeCuentas' AS Pantalla FROM [dbo].Roles
   WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

----

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('ContabilidadEjeciciosABM', 'ABM de Ejercicios Contables', 'ABM de Ejercicios Contables', 'True', 'False', 'True', 'True', 
          'Contabilidad', 330, 'Eniac.Win', 'ContabilidadEjeciciosABM', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadEjeciciosABM' AS Pantalla FROM [dbo].Roles
   WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

----

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('ContabilidadCentrosCostosABM', 'ABM de Centros Costos', 'ABM de Centros Costos', 'True', 'False', 'True', 'True', 
          'Contabilidad', 340, 'Eniac.Win', 'ContabilidadCentrosCostosABM', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadCentrosCostosABM' AS Pantalla FROM [dbo].Roles
   WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

----

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('ContabilidadPlanesABM', 'ABM de Plan de Cuentas', 'ABM de Plan de Cuentas', 'True', 'False', 'True', 'True', 
          'Contabilidad', 350, 'Eniac.Win', 'ContabilidadPlanesABM', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadPlanesABM' AS Pantalla FROM [dbo].Roles
   WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

----

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('ImportarContabilidadCuentasXLS', 'Importar Cuentas Contables desde Excel', 'Importar Cuentas Contables desde Excel', 'True', 'False', 'True', 'True', 
          'Contabilidad', 400, 'Eniac.Win', 'ImportarContabilidadCuentasExcel', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ImportarContabilidadCuentasXLS' AS Pantalla FROM [dbo].Roles
   WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

