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


--Inserto el Menu nuevo

INSERT INTO [dbo].Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
    ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
    ('Contabilidad', 'Contabilidad', '', 'True', 'False', 'True', 'True',
     NULL, 150, NULL, NULL, NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'Contabilidad' AS Pantalla FROM [dbo].Roles
--    WHERE Id IN ('Adm', 'Supervisor')
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
GO

---------------------------------------------------------------------------------------------

--INSERT INTO [dbo].Funciones
--         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
--          IdPadre, Posicion, Archivo, Pantalla, Icono)
--     VALUES
--         ('ContabilidadProcesos', 'Importar Informacion desde la Gestion', 'Importar Informacion desde la Gestion', 'True', 'False', 'True', 'True', 
--          'Contabilidad', 20, 'Eniac.Win', 'ContabilidadProcesos', NULL)
--GO

--INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
--SELECT DISTINCT Id AS Rol, 'ContabilidadProcesos' AS Pantalla FROM [dbo].Roles
--GO

---------------------------------------------------------------------------------------------

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('ContabilidadReportesAdmin', 'Reportes Varios', 'Reportes Varios', 'True', 'False', 'True', 'True', 
          'Contabilidad', 30, 'Eniac.Win', 'ContabilidadReportesAdmin', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadReportesAdmin' AS Pantalla FROM [dbo].Roles
GO

---------------------------------------------------------------------------------------------

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('ContabilidadCuentasABM', 'ABM de Cuentas', 'ABM de Cuentas', 'True', 'False', 'True', 'True', 
          'Contabilidad', 100, 'Eniac.Win', 'ContabilidadCuentasABM', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadCuentasABM' AS Pantalla FROM [dbo].Roles
GO

---------------------------------------------------------------------------------------------

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('ContabilidadTiposCuentasABM', 'ABM de Tipos de Cuentas', 'ABM de Tipos de Cuentas', 'True', 'False', 'True', 'True', 
          'Contabilidad', 110, 'Eniac.Win', 'ContabilidadTiposCuentasABM', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadTiposCuentasABM' AS Pantalla FROM [dbo].Roles
GO

---------------------------------------------------------------------------------------------

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('ContabilidadCentrosCostosABM', 'ABM de Centros Costos', 'ABM de Centros Costos', 'True', 'False', 'True', 'True', 
          'Contabilidad', 120, 'Eniac.Win', 'ContabilidadCentrosCostosABM', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadCentrosCostosABM' AS Pantalla FROM [dbo].Roles
       WHERE Id = 'Adm'
GO

---------------------------------------------------------------------------------------------

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('ContabilidadCuentasTitulosABM', 'ABM de Cuentas Titulos', 'ABM de Cuentas Titulos', 'True', 'False', 'True', 'True', 
          'Contabilidad', 130, 'Eniac.Win', 'ContabilidadCuentasTitulosABM', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadCuentasTitulosABM' AS Pantalla FROM [dbo].Roles
GO

---------------------------------------------------------------------------------------------
INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('ContabilidadPlanesABM', 'ABM de Planes de Cuenta', 'ABM de Planes de Cuenta', 'True', 'False', 'True', 'True', 
          'Contabilidad', 140, 'Eniac.Win', 'ContabilidadPlanesABM', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadPlanesABM' AS Pantalla FROM [dbo].Roles
GO

---------------------------------------------------------------------------------------------

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('ContabilidadPlanCuentasDetalle', 'ABM de Cuentas por Plan', 'ABM de Cuentas por Plan', 'True', 'False', 'True', 'True', 
          'Contabilidad', 150, 'Eniac.Win', 'ContabilidadPlanesCuentasDetalle', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadPlanCuentasDetalle' AS Pantalla FROM [dbo].Roles
GO
---------------------------------------------------------------------------------------------

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('ContabilidadEjeciciosABM', 'ABM de Ejercicios Contables', 'ABM de Ejercicios Contables', 'True', 'False', 'True', 'True', 
          'Contabilidad', 160, 'Eniac.Win', 'ContabilidadEjeciciosABM', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadEjeciciosABM' AS Pantalla FROM [dbo].Roles
GO

