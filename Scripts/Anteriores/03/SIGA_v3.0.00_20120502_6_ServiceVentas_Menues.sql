
DELETE RolesFunciones 
WHERE IdFuncion IN
 (
SELECT id FROM [Funciones]
 WHERE id='Service' or IdPadre='Service'
)
GO

DELETE [Funciones]
 WHERE id='Service' or IdPadre='Service'
GO


--Inserto el Menu nuevo

INSERT INTO Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
    ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
    ('Service', 'Service', '', 'True', 'False', 'True', 'True',
     NULL, 60, NULL, NULL, NULL)
GO

INSERT INTO RolesFunciones 
    (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'Service' AS Pantalla FROM dbo.Roles
--    WHERE Id IN ('Adm', 'Supervisor')
GO


--- Inserto las pantallas nuevas ---

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('ProductosEnReparacion', 'Administración de Productos en Reparación', 'Administración de Productos en Reparación', 
    'True', 'False', 'True', 'True', 'Service', 10,'Eniac.Service.Win', 'ProductosEnReparacion', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ProductosEnReparacion' AS Pantalla FROM dbo.Roles
GO                          


INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('ProductosRecepcion', 'Recepción de productos para reparación', 'Recepción de productos para reparación', 
    'True', 'False', 'True', 'True', 'Service', 20,'Eniac.Service.Win', 'ProductosRecepcion', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ProductosRecepcion' AS Pantalla FROM dbo.Roles
GO


INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('AdministracionNotasRecepcion', 'Administración de Notas de Recepción', 'Administración de Notas de Recepción', 
    'True', 'False', 'True', 'True', 'Service', 30,'Eniac.Service.Win', 'AdministracionNotasRecepcion', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'AdministracionNotasRecepcion' AS Pantalla FROM dbo.Roles
GO
