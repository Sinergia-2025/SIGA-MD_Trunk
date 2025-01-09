
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
   ('ProductosEnReparacion', 'Administraci�n de Productos en Reparaci�n', 'Administraci�n de Productos en Reparaci�n', 
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
   ('ProductosRecepcion', 'Recepci�n de productos para reparaci�n', 'Recepci�n de productos para reparaci�n', 
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
   ('AdministracionNotasRecepcion', 'Administraci�n de Notas de Recepci�n', 'Administraci�n de Notas de Recepci�n', 
    'True', 'False', 'True', 'True', 'Service', 30,'Eniac.Service.Win', 'AdministracionNotasRecepcion', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'AdministracionNotasRecepcion' AS Pantalla FROM dbo.Roles
GO
