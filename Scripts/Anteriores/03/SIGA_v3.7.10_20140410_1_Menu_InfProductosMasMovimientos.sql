
INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('InfProductosMasMovimientos', 'Inf. Productos con Mas Movimientos', 'Inf. Productos con Mas Movimientos', 
    'True', 'False', 'True', 'True', 'Stock', 110, 'Eniac.Win', 'InfProductosMasMovimientos', NULL)
GO

INSERT INTO RolesFunciones (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfProductosMasMovimientos' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor')
GO

