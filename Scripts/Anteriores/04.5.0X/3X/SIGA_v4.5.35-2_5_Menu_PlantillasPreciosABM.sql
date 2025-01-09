
INSERT INTO Funciones  
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('PlantillasPreciosABM', 'ABM de Plantillas de Precios', 'ABM de Plantillas de Precios', 'True', 'False', 'True', 'True', 
      'Precios', 300, 'Eniac.Win', 'PlantillasPreciosABM', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'PlantillasPreciosABM' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO
