
INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('InfFormulas', 'Informe de F�rmulas', 'Informe de F�rmulas', 
    'True', 'False', 'True', 'True', 'Produccion', 45, 'Eniac.Win', 'InfFormulas', NULL)
GO

INSERT INTO RolesFunciones (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfFormulas' AS Pantalla FROM dbo.Roles
GO
