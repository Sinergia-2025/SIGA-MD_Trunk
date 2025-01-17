--Elimino los menues anteriores.

DELETE RolesFunciones WHERE IdFuncion IN
 (
SELECT id FROM [Funciones]
 WHERE id = 'Sueldos' OR IdPadre='Sueldos'
)
GO

DELETE [Funciones]
 WHERE id='Sueldos' OR IdPadre='Sueldos'
GO


--Inserto el Menu nuevo

INSERT INTO Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
    ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
    ('Sueldos', 'Sueldos', '', 'True', 'False', 'True', 'True',
     NULL, 80, NULL, NULL, NULL)
GO

INSERT INTO RolesFunciones 
    (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'Sueldos' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor')
GO


-- Inserto las pantallas nuevas -----------------------------------------------------------

INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
   VALUES
          ('SueldosConceptosMasivo', 'Asignación de Conceptos Masivos', 'Asignación de Conceptos Masivos', 'True', 'False', 'True', 'True', 
           'Sueldos', 10, 'Eniac.Win', 'SueldosConceptosMasivo', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
  SELECT DISTINCT Id AS Rol, 'SueldosConceptosMasivo' AS Pantalla FROM Roles WHERE Id IN ('Adm', 'Supervisor')
GO

---------------------------------------------------------------------------------------------

INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
   VALUES
          ('SueldosConceptosPersonal', 'Carga de Conceptos al Personal', 'Carga de Conceptos al Personal', 'True', 'False', 'True', 'True', 
           'Sueldos', 20, 'Eniac.Win', 'SueldosConceptosPersonal', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
  SELECT DISTINCT Id AS Rol, 'SueldosConceptosPersonal' AS Pantalla FROM Roles WHERE Id IN ('Adm', 'Supervisor')
GO

---------------------------------------------------------------------------------------------

INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
   VALUES
          ('SueldosModificaImporteConcepto', 'Modificar Importe de Concepto', 'Modificar Importe de Concepto', 'True', 'False', 'True', 'True', 
           'Sueldos', 30, 'Eniac.Win', 'SueldosModificaImporteConcepto', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
  SELECT DISTINCT Id AS Rol, 'SueldosModificaImporteConcepto' AS Pantalla FROM Roles WHERE Id IN ('Adm', 'Supervisor')
GO

---------------------------------------------------------------------------------------------

INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
   VALUES
          ('SueldosLiquidacion', 'Liquidación de Sueldos', 'Liquidación de Sueldos', 'True', 'False', 'True', 'True', 
           'Sueldos', 40, 'Eniac.Win', 'SueldosLiquidacion', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
  SELECT DISTINCT Id AS Rol, 'SueldosLiquidacion' AS Pantalla FROM Roles WHERE Id IN ('Adm', 'Supervisor')
GO

---------------------------------------------------------------------------------------------

INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
   VALUES
          ('SueldosEmisionRecibos', 'Emisión de Recibos', 'Emisión de Recibos', 'True', 'False', 'True', 'True', 
           'Sueldos', 50, 'Eniac.Win', 'SueldosEmisionRecibos', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
  SELECT DISTINCT Id AS Rol, 'SueldosEmisionRecibos' AS Pantalla FROM Roles WHERE Id IN ('Adm', 'Supervisor')
GO

---------------------------------------------------------------------------------------------

INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
   VALUES
          ('SueldosInformeControl', 'Informe de Control', 'Informe de Control', 'True', 'False', 'True', 'True', 
           'Sueldos', 60, 'Eniac.Win', 'SueldosInformeControl', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
  SELECT DISTINCT Id AS Rol, 'SueldosInformeControl' AS Pantalla FROM Roles WHERE Id IN ('Adm', 'Supervisor')
GO

---------------------------------------------------------------------------------------------

INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
   VALUES
          ('SueldosLibroDeSueldosyJornales', 'Emisión de Libro de Sueldos y Jornales', 'Emisión de Libro de Sueldos y Jornales', 'True', 'False', 'True', 'True', 
           'Sueldos', 70, 'Eniac.Win', 'SueldosLibroDeSueldosyJornales', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
  SELECT DISTINCT Id AS Rol, 'SueldosLibroDeSueldosyJornales' AS Pantalla FROM Roles WHERE Id IN ('Adm', 'Supervisor')
GO

---------------------------------------------------------------------------------------------

INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
   VALUES
          ('SueldosPersonalABM', 'ABM de Personal', 'ABM de Personal', 'True', 'False', 'True', 'True', 
           'Sueldos', 80, 'Eniac.Win', 'SueldosPersonalABM', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
  SELECT DISTINCT Id AS Rol, 'SueldosPersonalABM' AS Pantalla FROM Roles WHERE Id IN ('Adm', 'Supervisor')
GO

---------------------------------------------------------------------------------------------

INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
   VALUES
          ('SueldosConceptosABM', 'ABM de Conceptos', 'ABM de Conceptos', 'True', 'False', 'True', 'True', 
           'Sueldos', 90, 'Eniac.Win', 'SueldosConceptosABM', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
  SELECT DISTINCT Id AS Rol, 'SueldosConceptosABM' AS Pantalla FROM Roles WHERE Id IN ('Adm', 'Supervisor')
GO

---------------------------------------------------------------------------------------------

INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
   VALUES
          ('SueldosCategoriasABM', 'ABM de Categorias de Personal', 'ABM de Categorias de Personal', 'True', 'False', 'True', 'True', 
           'Sueldos', 100, 'Eniac.Win', 'SueldosCategoriasABM', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
  SELECT DISTINCT Id AS Rol, 'SueldosCategoriasABM' AS Pantalla FROM Roles WHERE Id IN ('Adm', 'Supervisor')
GO

---------------------------------------------------------------------------------------------

INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
   VALUES
          ('SueldosLugaresActividadABM', 'ABM de Lugares de Actividad', 'ABM de Lugares de Actividad', 'True', 'False', 'True', 'True', 
           'Sueldos', 110, 'Eniac.Win', 'SueldosLugaresActividadABM', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
  SELECT DISTINCT Id AS Rol, 'SueldosLugaresActividadABM' AS Pantalla FROM Roles WHERE Id IN ('Adm', 'Supervisor')
GO

---------------------------------------------------------------------------------------------

INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
   VALUES
          ('SueldosMotivosBajaABM', 'ABM de Motivos de Baja', 'ABM de Motivos de Baja', 'True', 'False', 'True', 'True', 
           'Sueldos', 120, 'Eniac.Win', 'SueldosMotivosBajaABM', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
  SELECT DISTINCT Id AS Rol, 'SueldosMotivosBajaABM' AS Pantalla FROM Roles WHERE Id IN ('Adm', 'Supervisor')
GO

---------------------------------------------------------------------------------------------

INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
   VALUES
          ('SueldosObraSocialABM', 'ABM de Obras Sociales', 'ABM de Obras Sociales', 'True', 'False', 'True', 'True', 
           'Sueldos', 130, 'Eniac.Win', 'SueldosObraSocialABM', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
  SELECT DISTINCT Id AS Rol, 'SueldosObraSocialABM' AS Pantalla FROM Roles WHERE Id IN ('Adm', 'Supervisor')
GO

---------------------------------------------------------------------------------------------

INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
   VALUES
          ('SueldosTiposConceptosABM', 'ABM de Tipos de Conceptos', 'ABM de Tipos de Conceptos', 'True', 'False', 'True', 'True', 
           'Sueldos', 140, 'Eniac.Win', 'SueldosTiposConceptosABM', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
  SELECT DISTINCT Id AS Rol, 'SueldosTiposConceptosABM' AS Pantalla FROM Roles WHERE Id IN ('Adm', 'Supervisor')
GO

---------------------------------------------------------------------------------------------

INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
   VALUES
          ('SueldosTiposRecibosABM', 'ABM de Tipos de Recibos', 'ABM de Tipos de Recibos', 'True', 'False', 'True', 'True', 
           'Sueldos', 150, 'Eniac.Win', 'SueldosTiposRecibosABM', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
  SELECT DISTINCT Id AS Rol, 'SueldosTiposRecibosABM' AS Pantalla FROM Roles WHERE Id IN ('Adm', 'Supervisor')
GO

---------------------------------------------------------------------------------------------

INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
   VALUES
          ('SueldosEstadoCivilABM', 'ABM de Estados Civiles', 'ABM de Estados Civiles', 'True', 'False', 'True', 'True', 
           'Sueldos', 160, 'Eniac.Win', 'SueldosEstadoCivilABM', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
  SELECT DISTINCT Id AS Rol, 'SueldosEstadoCivilABM' AS Pantalla FROM Roles WHERE Id IN ('Adm', 'Supervisor')
GO

---------------------------------------------------------------------------------------------
