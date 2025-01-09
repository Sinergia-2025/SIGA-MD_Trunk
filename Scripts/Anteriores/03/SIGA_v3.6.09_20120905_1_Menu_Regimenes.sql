
--Inserto la pantalla nueva

INSERT INTO Funciones
     (Id, Nombre, Descripcion, 
      EsMenu, EsBoton, [Enabled], Visible,
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('RegimenesABM', 'ABM Regimenes', 'ABM Regimenes', 
      'True', 'False', 'True', 'True',
      'AFIP', 100, 'Eniac.Win', 'RegimenesABM', NULL)
GO


INSERT INTO RolesFunciones 
           (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'RegimenesABM' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor')
GO
