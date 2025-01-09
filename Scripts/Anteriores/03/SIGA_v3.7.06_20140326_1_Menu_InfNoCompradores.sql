
INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('InfNoCompradores', 'Inf. No Compradores', 'Inf. No Compradores', 
    'True', 'False', 'True', 'True', 'Ventas', 200, 'Eniac.Win', 'InfNoCompradores', NULL)
GO

INSERT INTO RolesFunciones (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfNoCompradores' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor')
GO
