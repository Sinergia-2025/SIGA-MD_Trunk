
--Elimino los menues anteriores.

DELETE RolesFunciones WHERE IdFuncion IN
 (
SELECT id FROM [Funciones]
 WHERE id IN ('Produccion', 'Producción') OR IdPadre IN ('Produccion', 'Producción')
)
GO

DELETE [Funciones]
 WHERE id IN ('Produccion', 'Producción') OR IdPadre IN ('Produccion', 'Producción')
GO


--Inserto el Menu Nuevo

INSERT INTO Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
    ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
    ('Produccion', 'Produccion', '', 'True', 'False', 'True', 'True',
     NULL, 130, NULL, NULL, NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'Produccion' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor')
GO


-- Inserto las pantallas nuevas -----------------------------------------------------------

INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('MovimientosDeProduccion', 'Movimientos de Produccion', 'Movimientos de Produccion', 'True', 'False', 'True', 'True', 
          'Produccion', 10, 'Eniac.Win', 'MovimientosDeProduccion', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'MovimientosDeProduccion' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervisor')
GO

---------------------------------------------------------------------------------------------

INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('InfProduccion', 'Informe de Produccion', 'Informe de Produccion', 'True', 'False', 'True', 'True', 
          'Produccion', 20, 'Eniac.Win', 'InfProduccion', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfProduccion' AS Pantalla FROM Roles
GO

---------------------------------------------------------------------------------------------

INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('CalculoProduccion', 'Calculo de Produccion', 'Calculo de Produccion', 'True', 'False', 'True', 'True', 
          'Produccion', 30, 'Eniac.Win', 'CalculoProduccion', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'CalculoProduccion' AS Pantalla FROM Roles
GO

---------------------------------------------------------------------------------------------

INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('ProductosComponentes', 'Componentes de Productos', 'Componentes de Productos', 'True', 'False', 'True', 'True', 
          'Produccion' , 40, 'Eniac.Win', 'ProductosComponentes' , NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ProductosComponentes' AS Pantalla FROM Roles
GO

---------------------------------------------------------------------------------------------
