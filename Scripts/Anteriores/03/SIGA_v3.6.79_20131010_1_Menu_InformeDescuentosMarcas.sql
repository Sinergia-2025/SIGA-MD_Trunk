INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('InformeDescuentosMarcas', 'Informe Descuentos por Marcas', 'Informe Descuentos por Marcas', 
    'True', 'False', 'True', 'True', 'Precios', 96, 'Eniac.Win', 'InformeDescuentosMarcas', NULL)
GO

INSERT INTO RolesFunciones (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'InformeDescuentosMarcas' AS Pantalla FROM dbo.Roles
GO