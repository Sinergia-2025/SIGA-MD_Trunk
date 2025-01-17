
--Elimino los menues anteriores.

DELETE RolesFunciones WHERE IdFuncion IN
 ( SELECT id FROM [Funciones]
    WHERE id = 'Alquiler' OR IdPadre = 'Alquiler'
       OR id = 'Alquileres' OR IdPadre = 'Alquileres'
 )
GO

DELETE [Funciones]
    WHERE id = 'Alquiler' OR IdPadre = 'Alquiler'
       OR id = 'Alquileres' OR IdPadre = 'Alquileres'
GO


--Inserto el Menu Nuevo

INSERT INTO Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
    ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
    ('Alquileres', 'Alquileres', '', 'True', 'False', 'True', 'True',
     NULL, 40, NULL, NULL, NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'Alquileres' AS Pantalla FROM dbo.Roles
--    WHERE Id IN ('Adm', 'Supervisor')
GO


-- Inserto las pantallas nuevas -----------------------------------------------------------

INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('AdministracionDeContratos', 'Administracion de Contratos', 'Administracion de Contratos', 'True', 'False', 'True', 'True', 
          'Alquileres', 10, 'Eniac.Win', 'AdministracionDeContratos', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'AdministracionDeContratos' AS Pantalla FROM Roles
GO

---------------------------------------------------------------------------------------------

INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('AlquilerABM', 'ABM de Alquileres', 'Lista de Alquileres', 'True', 'False', 'True', 'True', 
          'Alquileres', 20, 'Eniac.Win', 'AlquilerABM', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'AlquilerABM' AS Pantalla FROM Roles
GO

---------------------------------------------------------------------------------------------

INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('infProductosDisponibles', 'Informe de Productos Disponibles', 'Informe de Productos Disponibles', 'True', 'False', 'True', 'True', 
          'Alquileres', 30, 'Eniac.Win', 'infProductosDisponibles', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'infProductosDisponibles' AS Pantalla FROM Roles
GO

---------------------------------------------------------------------------------------------

--INSERT INTO Funciones
--         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
--          IdPadre, Posicion, Archivo, Pantalla, Icono)
--     VALUES
--         ('EquiposABM', 'ABM de Equipos', 'ABM de Equipos', 'True', 'False', 'True', 'True', 
--          'Alquileres', 40, 'Eniac.Win', 'EquiposABM', NULL)
--GO

--INSERT INTO RolesFunciones (IdRol, IdFuncion)
--SELECT DISTINCT Id AS Rol, 'EquiposABM' AS Pantalla FROM Roles
--GO

---------------------------------------------------------------------------------------------

INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('TarifasABM', 'ABM de Tarifas', 'ABM de Tarifas', 'True', 'False', 'True', 'True', 
          'Alquileres', 40, 'Eniac.Win', 'TarifasABM', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'TarifasABM' AS Pantalla FROM Roles
GO

---------------------------------------------------------------------------------------------
