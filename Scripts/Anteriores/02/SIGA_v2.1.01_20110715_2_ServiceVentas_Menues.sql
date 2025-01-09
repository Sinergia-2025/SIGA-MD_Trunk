--Inserto el Menu nuevo

INSERT INTO Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
    ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
    ('Service', 'Service', '', 'True', 'False', 'True', 'True',
     NULL, 45, NULL, NULL, NULL)
GO

INSERT INTO RolesFunciones 
    (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'Service' AS Pantalla FROM dbo.Roles
--    WHERE Id IN ('Adm', 'Supervisor')
GO


--- Inserto las pantallas nuevas ---

DELETE RolesFunciones where idfuncion = 'ProductosEnReparacionV'
GO

DELETE Funciones where id = 'ProductosEnReparacionV'
GO

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('ProductosEnReparacionV', 'Administración de Productos en Reparación', 'Administración de Productos en Reparación', 
    'True', 'False', 'True', 'True', 'Service', 10,'Eniac.Service.Win', 'ProductosEnReparacionV', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ProductosEnReparacionV' AS Pantalla FROM dbo.Roles
GO                          


DELETE RolesFunciones where idfuncion = 'ProductosRecepcionV'
GO

DELETE Funciones where id = 'ProductosRecepcionV'
GO

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('ProductosRecepcionV', 'Recepción de productos para reparación', 'Recepción de productos para reparación', 
    'True', 'False', 'True', 'True', 'Service', 20,'Eniac.Service.Win', 'ProductosRecepcionV', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ProductosRecepcionV' AS Pantalla FROM dbo.Roles
GO


INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('AdministracionNotasRecepcionV', 'Administración de Notas de Recepción', 'Administración de Notas de Recepción', 
    'True', 'False', 'True', 'True', 'Service', 30,'Eniac.Service.Win', 'AdministracionNotasRecepcionV', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'AdministracionNotasRecepcionV' AS Pantalla FROM dbo.Roles
GO
