
--Inserto la pantalla nueva

INSERT INTO Funciones
     (Id, Nombre, Descripcion, 
      EsMenu, EsBoton, [Enabled], Visible,
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('ImportarFormulasExcel', 'Importar Formulas desde Excel', 'Importar Formulas desde Excel', 
      'True', 'False', 'True', 'True',
      'Produccion', 50, 'Eniac.Win', 'ImportarFormulasExcel', NULL)
GO


INSERT INTO RolesFunciones 
           (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ImportarFormulasExcel' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor')
GO
