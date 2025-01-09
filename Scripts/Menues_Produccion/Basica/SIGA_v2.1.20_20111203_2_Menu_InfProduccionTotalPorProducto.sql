
--Inserto la pantalla nueva

INSERT INTO Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
     IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
  VALUES
    ('InfProduccionTotalPorProducto', 'Informe de Produccion Total por Producto', 'Informe de Produccion Total por Producto', 'True', 'False', 'True', 'True', 
     'Produccion', 25, 'Eniac.Win', 'InfProduccionTotalPorProducto', NULL, NULL
            ,'True', 'S', 'N', 'N', 'N')
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfProduccionTotalPorProducto' AS Pantalla FROM Roles
GO
