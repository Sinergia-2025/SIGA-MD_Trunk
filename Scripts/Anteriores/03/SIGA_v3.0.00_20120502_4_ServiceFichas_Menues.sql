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
   ('ProductosEnReparacionF', 'Administración de Productos en Reparación', 'Administración de Productos en Reparación', 
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
   ('ProductosRecepcionF', 'Recepción de productos para reparación', 'Recepción de productos para reparación', 
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
   ('AdministracionNotasRecepcionF', 'Administración de Notas de Recepción', 'Administración de Notas de Recepción', 
    'True', 'False', 'True', 'True', 'ServiceF', 30,'Eniac.Service.Win', 'AdministracionNotasRecepcionF', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'AdministracionNotasRecepcionF' AS Pantalla FROM dbo.Roles
GO
