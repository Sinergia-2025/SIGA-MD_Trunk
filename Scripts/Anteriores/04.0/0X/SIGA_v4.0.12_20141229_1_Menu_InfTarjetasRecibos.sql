
--Inserto la pantalla nueva

INSERT INTO [dbo].Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
     ('InfTarjetasRecibos', 'Informe de Tarjetas por Recibos', 'Informe de Tarjetas por Recibos', 'True', 'False', 'True', 'True', 
      'CuentasCorrientes', 75, 'Eniac.Win', 'InfTarjetasRecibos', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfTarjetasRecibos' AS Pantalla FROM [dbo].Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO
