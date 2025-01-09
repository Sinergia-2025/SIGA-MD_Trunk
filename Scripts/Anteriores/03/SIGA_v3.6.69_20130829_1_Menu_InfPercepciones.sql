
--Inserto la pantalla nueva

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
     ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('InfPercepciones', 'Informe de Percepciones', 'Informe de Percepciones', 'True', 'False', 'True', 'True'
     ,'AFIP', 30, 'Eniac.Win', 'InfPercepciones', NULL)
GO

INSERT INTO RolesFunciones (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfPercepciones' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor')
GO
