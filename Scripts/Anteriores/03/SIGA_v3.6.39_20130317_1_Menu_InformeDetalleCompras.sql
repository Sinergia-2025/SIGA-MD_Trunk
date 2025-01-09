
--Inserto la pantalla nueva

INSERT INTO [dbo].Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
     ('InfComprasDetallePorProductos', 'Informe de Compras detalle por Productos', 'Informe de Compras detalle por Productos', 'True', 'False', 'True', 'True', 
      'Compras', 32, 'Eniac.Win', 'InfComprasDetallePorProductos', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfComprasDetallePorProductos' AS Pantalla FROM [dbo].Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')