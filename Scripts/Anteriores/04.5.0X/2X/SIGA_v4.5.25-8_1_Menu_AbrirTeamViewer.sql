
DELETE RolesFunciones WHERE IdFuncion IN ('AbrirTeamViewer', 'About', 'Ayuda')
GO
DELETE Funciones WHERE Id IN ('AbrirTeamViewer', 'About', 'Ayuda')
GO

--Insertar Menu
INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], 
      Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('Ayuda', 'Ayuda', 'Ayuda', 'True', 'False', 'True',
      'True', NULL, 900, NULL, NULL, NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'Ayuda' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina') 
GO


INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], 
      Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('About', 'Acerca de Sinergia Software...', 'Acerca de Sinergia Software...', 'True', 'False', 'True',
      'True', 'Ayuda', 10, 'Eniac.Win', 'About', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'About' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina') 
GO

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], 
      Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('AbrirTeamViewer', 'Abrir TeamViewer', 'Abrir TeamViewer', 'True', 'False', 'True',
      'True', 'Ayuda', 20, 'Eniac.Win', 'AbrirTeamViewer', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'AbrirTeamViewer' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina') 
GO
