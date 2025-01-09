INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], 
      Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('AbrirAppStyle', 'Abrir App Style', 'Abrir App Style', 'True', 'False', 'True',
      'True', 'Ayuda', 30, 'Eniac.Win', 'AbrirAppStyle', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'AbrirAppStyle' AS Pantalla FROM Roles
    WHERE Id IN ('Adm') 
GO
