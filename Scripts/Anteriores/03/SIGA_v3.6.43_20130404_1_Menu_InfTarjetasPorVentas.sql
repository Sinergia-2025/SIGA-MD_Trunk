
--Inserto la pantalla nueva

INSERT INTO [dbo].Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
     ('InfTarjetasPorVentas', 'Inf. Tarjetas por Ventas', 'Inf. Tarjetas por Ventas', 'True', 'False', 'True', 'True', 
      'Ventas', 120, 'Eniac.Win', 'InfTarjetasPorVentas', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfTarjetasPorVentas' AS Pantalla FROM [dbo].Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO
