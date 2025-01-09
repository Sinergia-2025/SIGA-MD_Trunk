
INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('Productos-MostrarPrecios', 'Productos - Mostrar Precios', 'Productos - Mostrar Precios', 
    'False', 'False', 'True', 'False', 'Productos', 10, 'Eniac.Win', 'Productos-MostrarPrecios', NULL)
GO

-- Aquellos Roles que pueden Actualizar Precios.
INSERT INTO RolesFunciones 
           (IdRol,IdFuncion)
SELECT IdRol, 'Productos-MostrarPrecios' AS Pantalla  FROM RolesFunciones 
 WHERE IdFuncion = 'ActualizarPrecios'
GO
