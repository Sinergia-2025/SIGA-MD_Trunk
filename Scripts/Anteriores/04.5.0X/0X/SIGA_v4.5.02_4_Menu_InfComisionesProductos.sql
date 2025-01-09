
--Inserto la pantalla nueva

INSERT INTO [dbo].Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
     ('InfComisionesProductos', 'Informe de Comisiones por Producto', 'Informe de Comisiones por Producto', 'True', 'False', 'True', 'True', 
      'CuentasCorrientes', 110, 'Eniac.Win', 'InfComisionesProductos', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfComisionesProductos' AS Pantalla FROM [dbo].Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO
