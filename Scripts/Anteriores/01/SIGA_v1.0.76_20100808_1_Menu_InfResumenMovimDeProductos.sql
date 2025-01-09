  
--Inserto la pantalla nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('InfResumenMovimDeProductos', 'Inf. Resumen de Movimientos de Productos', 'Inf. Resumen de Movimientos de Productos', 
    'True', 'False', 'True', 'True', 'Stock', 25, 'Eniac.Win', 'InfResumenMovimDeProductos', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfResumenMovimDeProductos' AS Pantalla FROM dbo.Roles
GO
