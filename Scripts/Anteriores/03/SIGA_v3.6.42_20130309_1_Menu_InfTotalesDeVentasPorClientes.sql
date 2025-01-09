
--Inserto la pantalla nueva

INSERT INTO [dbo].Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
     ('InfTotalesDeVentasPorClientes', 'Inf. Totales de Venta por Clientes', 'Inf. Totales de Venta por Clientes', 'True', 'False', 'True', 'True', 
      'Ventas', 34, 'Eniac.Win', 'InfTotalesDeVentasPorClientes', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfTotalesDeVentasPorClientes' AS Pantalla FROM [dbo].Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
