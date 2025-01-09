
--Inserto la pantalla nueva

INSERT INTO [dbo].Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
     ('InfComisionesSobreVentas', 'Inf. de Comisiones sobre Ventas', 'Inf. de Comisiones sobre Ventas', 'True', 'False', 'True', 'True', 
      'ComisionesVendedores', 40, 'Eniac.Win', 'InfComisionesSobreVentas', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfComisionesSobreVentas' AS Pantalla FROM [dbo].Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO
