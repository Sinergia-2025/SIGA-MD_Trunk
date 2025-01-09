
--Inserto la pantalla nueva

INSERT INTO [dbo].Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
     ('InfUltimaVentaPorClientes', 'Inf. Ultima Venta de Clientes', 'Inf. Ultima Venta de Clientes', 'True', 'False', 'True', 'True', 
      'Ventas', 32, 'Eniac.Win', 'InfUltimaVentaPorClientes', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfUltimaVentaPorClientes' AS Pantalla FROM [dbo].Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
    