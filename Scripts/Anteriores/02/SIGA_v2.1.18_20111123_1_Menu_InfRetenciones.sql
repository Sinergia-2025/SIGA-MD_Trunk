
--Inserto la pantalla nueva

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
     ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('InfRetenciones', 'Informe de Retenciones', 'Informe de Retenciones', 'True', 'False', 'True', 'True'
     ,'AFIP', 30, 'Eniac.Win', 'InfRetenciones', NULL)
GO

INSERT INTO RolesFunciones (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfRetenciones' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor')
GO
