
--Inserto la pantalla nueva

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
     ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('InformeDescuentosProductos', 'Informe de Descuentos por Productos', 'Informe de Descuentos por Productos', 'True', 'False', 'True', 'True',
      'Precios', 150, 'Eniac.Win', 'InformeDescuentosProductos', NULL)
GO

INSERT INTO RolesFunciones 
      (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'InformeDescuentosProductos' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO
