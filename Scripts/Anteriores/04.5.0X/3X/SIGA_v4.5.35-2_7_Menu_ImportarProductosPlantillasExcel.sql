
INSERT INTO Funciones  
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('ImportarProdPlantillaExcel', 'Importar Productos desde Plantillas Excel', 'Importar Productos desde Plantillas Excel', 'True', 'False', 'True', 'True', 
      'Procesos', 104, 'Eniac.Win', 'ImportarProductosPlantillaExcel', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ImportarProdPlantillaExcel' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO
