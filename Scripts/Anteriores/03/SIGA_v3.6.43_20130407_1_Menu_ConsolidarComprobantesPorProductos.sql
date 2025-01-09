
--Inserto la pantalla nueva

INSERT INTO [dbo].Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
     ('ConsolidarComprobPorProductos', 'Consolidar Comprobantes por Productos', 'Consolidar Comprobantes por Productos', 'True', 'False', 'True', 'True', 
      'Ventas', 50, 'Eniac.Win', 'ConsolidarComprobantesPorProductos', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ConsolidarComprobPorProductos' AS Pantalla FROM [dbo].Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO
