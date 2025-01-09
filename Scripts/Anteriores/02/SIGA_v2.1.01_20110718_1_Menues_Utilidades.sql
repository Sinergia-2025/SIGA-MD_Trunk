
-- Modifico Descripciones y Nombres de las Pantallas.

DELETE RolesFunciones WHERE IdFuncion = 'UtilidadesPorCliente'
GO

DELETE Funciones WHERE Id = 'UtilidadesPorCliente'
GO

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('InfUtilidadesPorCliente', 'Inf. Utilidades por Cliente', 'Inf. Utilidades por Cliente', 
    'True', 'False', 'True', 'True', 'Ventas', 60, 'Eniac.Win', 'InfUtilidadesPorCliente', NULL)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfUtilidadesPorCliente' AS Pantalla FROM dbo.Roles
     WHERE Id IN ('Adm', 'Supervisor')
GO

----

DELETE RolesFunciones WHERE IdFuncion = 'UtilidadesPorMarca'
GO

DELETE Funciones WHERE Id = 'UtilidadesPorMarca'
GO

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('InfUtilidadesPorMarca', 'Inf. Utilidades por Marca', 'Inf. Utilidades por Marca', 
    'True', 'False', 'True', 'True', 'Ventas', 70, 'Eniac.Win', 'InfUtilidadesPorMarca', NULL)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfUtilidadesPorMarca' AS Pantalla FROM dbo.Roles
     WHERE Id IN ('Adm', 'Supervisor')
GO

----

DELETE RolesFunciones WHERE IdFuncion = 'UtilidadesPorProducto'
GO

DELETE Funciones WHERE Id = 'UtilidadesPorProducto'
GO

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('InfUtilidadesPorProducto', 'Inf. Utilidades por Producto', 'Inf. Utilidades por Producto', 
    'True', 'False', 'True', 'True', 'Ventas', 80, 'Eniac.Win', 'InfUtilidadesPorProducto', NULL)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfUtilidadesPorProducto' AS Pantalla FROM dbo.Roles
     WHERE Id IN ('Adm', 'Supervisor')
GO

