
INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('ResumenDeBancos', 'Resumen de Bancos', 'Resumen de Bancos', 'True', 'False', 'True', 'True', 
      'Bancos', 30, 'Eniac.Win', 'ResumenDeBancos', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ResumenDeBancos' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina') 
GO