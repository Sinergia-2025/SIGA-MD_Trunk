
--Inserto la pantalla nueva

INSERT INTO Funciones
     (Id, Nombre
     , Descripcion, EsMenu, EsBoton, [Enabled], Visible
     , IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('ClientesDescuentosMarcas', 'Asignación de Descuentos a Clientes por Marcas', 
      'Asignación de Descuentos a Clientes por Marcas', 'True', 'False', 'True', 'True',
      'Precios', 200, 'Eniac.Win', 'ClientesDescuentosMarcas', NULL)
GO

INSERT INTO RolesFunciones 
      (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ClientesDescuentosMarcas' AS Pantalla FROM dbo.Roles
GO
