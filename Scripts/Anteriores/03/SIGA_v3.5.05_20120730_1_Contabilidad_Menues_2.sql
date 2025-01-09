
INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('ContabilidadAsientosModeloABM', 'ABM de Asientos Modelo', 'ABM de Asientos Modelo', 'True', 'False', 'True', 'True', 
          'Contabilidad', 170, 'Eniac.Win', 'ContabilidadAsientosModeloABM', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadAsientosModeloABM' AS Pantalla FROM Roles
GO

---------------------------------------------------------------------------------------------

--DELETE RolesFunciones WHERE IdRol = 'ContabilidadReportesAdmin' 
--GO

--DELETE Funciones WHERE Id = 'ContabilidadReportesAdmin' 
--GO

---------------------------------------------------------------------------------------------

INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('ContabilidadListadoLibroDiario', 'Libro Diario', 'Libro Diario', 'True', 'False', 'True', 'True', 
          'Contabilidad', 200, 'Eniac.Win', 'ContabilidadListadoLibroDiario', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadListadoLibroDiario' AS Pantalla FROM Roles
GO

---------------------------------------------------------------------------------------------


INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('ContabilidadListadoLibroMayor', 'Libro Mayor', 'Libro Mayor', 'True', 'False', 'True', 'True', 
          'Contabilidad', 210, 'Eniac.Win', 'ContabilidadListadoLibroMayor', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadListadoLibroMayor' AS Pantalla FROM Roles
GO

---------------------------------------------------------------------------------------------


INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('ContabilidadListadoBalance', 'Balance de Sumas y Saldos', 'Balance de Sumas y Saldos', 'True', 'False', 'True', 'True', 
          'Contabilidad', 220, 'Eniac.Win', 'ContabilidadListadoBalance', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadListadoBalance' AS Pantalla FROM Roles
GO

---------------------------------------------------------------------------------------------

INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('ContabilidadListadoAsientos', 'Consultar Asiento', 'Consultar Asiento', 'True', 'False', 'True', 'True', 
          'Contabilidad', 230, 'Eniac.Win', 'ContabilidadListadoAsientos', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadListadoAsientos' AS Pantalla FROM Roles
GO

