
INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('ClientesGeoLocalizacion', 'Clientes - Localizaci�n Geogr�fica (Mapa)', 'Clientes - Localizaci�n Geogr�fica (Mapa)', 
    'True', 'False', 'True', 'True', 'Archivos', 28, 'Eniac.Win', 'ClientesGeoLocalizacion', NULL)
GO

INSERT INTO RolesFunciones (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ClientesGeoLocalizacion' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor')
GO

