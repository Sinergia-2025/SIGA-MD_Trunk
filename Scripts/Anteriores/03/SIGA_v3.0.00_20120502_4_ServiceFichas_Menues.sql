DELETE RolesFunciones 
WHERE IdFuncion IN
 (
SELECT id FROM [Funciones]
 WHERE id='Service' or IdPadre='Service'
   OR (id='ServiceF' or IdPadre='ServiceF')
)
GO

DELETE [Funciones]
 WHERE id='Service' or IdPadre='Service'
   OR (id='ServiceF' or IdPadre='ServiceF')
GO


--Inserto el Menu nuevo

INSERT INTO Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
    ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
    ('ServiceF', 'Service (F)', '', 'True', 'False', 'True', 'True',
     NULL, 60, NULL, NULL, NULL)
GO

INSERT INTO RolesFunciones 
    (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ServiceF' AS Pantalla FROM dbo.Roles
--    WHERE Id IN ('Adm', 'Supervisor')
GO


--- Inserto las pantallas nuevas ---

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('ProductosEnReparacionF', 'Administraci�n de Productos en Reparaci�n', 'Administraci�n de Productos en Reparaci�n', 
    'True', 'False', 'True', 'True', 'ServiceF', 10,'Eniac.Service.Win', 'ProductosEnReparacionF', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ProductosEnReparacionF' AS Pantalla FROM dbo.Roles
GO                          


INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('ProductosRecepcionF', 'Recepci�n de productos para reparaci�n', 'Recepci�n de productos para reparaci�n', 
    'True', 'False', 'True', 'True', 'ServiceF', 20,'Eniac.Service.Win', 'ProductosRecepcionF', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ProductosRecepcionF' AS Pantalla FROM dbo.Roles
GO


INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('AdministracionNotasRecepcionF', 'Administraci�n de Notas de Recepci�n', 'Administraci�n de Notas de Recepci�n', 
    'True', 'False', 'True', 'True', 'ServiceF', 30,'Eniac.Service.Win', 'AdministracionNotasRecepcionF', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'AdministracionNotasRecepcionF' AS Pantalla FROM dbo.Roles
GO
