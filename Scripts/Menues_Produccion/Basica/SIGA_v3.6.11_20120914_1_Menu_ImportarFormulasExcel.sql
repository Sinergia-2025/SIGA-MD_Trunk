
--Inserto la pantalla nueva

INSERT INTO Funciones
     (Id, Nombre, Descripcion, 
      EsMenu, EsBoton, [Enabled], Visible,
      IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
  VALUES
     ('ImportarFormulasExcel', 'Importar Formulas desde Excel', 'Importar Formulas desde Excel', 
      'True', 'False', 'True', 'True',
      'Produccion', 50, 'Eniac.Win', 'ImportarFormulasExcel', NULL, NULL
            ,'True', 'S', 'N', 'N', 'N')
GO


INSERT INTO RolesFunciones 
           (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ImportarFormulasExcel' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor')
GO
