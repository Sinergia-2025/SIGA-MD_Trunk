
--Inserto la pantalla nueva

INSERT INTO Funciones
     (Id, Nombre
     , Descripcion, EsMenu, EsBoton, [Enabled], Visible
     , IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('ClientesDescuentosMarcasGrilla', 'Clientes - Asignaci�n de Desc. por Marcas (Grilla)', 
      'Clientes - Asignaci�n de Descuentos por Marcas (Grilla)', 'True', 'False', 'True', 'True',
      'Precios', 110, 'Eniac.Win', 'ClientesDescuentosMarcasGrilla', NULL)
GO

INSERT INTO RolesFunciones 
      (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ClientesDescuentosMarcasGrilla' AS Pantalla FROM dbo.Roles
GO


-- Ajusto la posicion de la pantalla estandar

UPDATE Funciones SET 
    Nombre = 'Clientes - Asignaci�n de Descuentos por Marcas'
   ,Descripcion = 'Clientes - Asignaci�n de Descuentos por Marcas'
 WHERE Id = 'ClientesDescuentosMarcas'
GO
