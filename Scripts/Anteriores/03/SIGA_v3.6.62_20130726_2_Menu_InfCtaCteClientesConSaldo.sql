
--Agrego la Pantalla Nueva.

INSERT INTO [dbo].Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('InfCtaCteClientesConSaldo', 'Informe de Cta. Cte. de Clientes Con Saldo', 'Informe de Cta. Cte. de Clientes Con Saldo', 'True', 'False', 'True', 'True', 
          'CuentasCorrientes', 42, 'Eniac.Win', 'InfCtaCteClientesConSaldo', NULL)
GO

INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT IdRol, 'InfCtaCteClientesConSaldo' AS Pantalla FROM [dbo].RolesFunciones
   WHERE IdFuncion = 'ConsultarCtaCteClientes'
GO
