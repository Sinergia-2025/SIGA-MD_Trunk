 
--Inserto la pantalla nueva

INSERT INTO Funciones
           (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
           ,IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
           ('InfCtaCteDetalleProximoPago', 'Informe de Cta. Cte. Detalle de Clientes - Próximo Pago', 'Informe de Cta. Cte. Detalle de Clientes - Próximo Pago', 'True', 'False', 'True', 'True',
           'CuentasCorrientes', 53, 'Eniac.Win', 'InfCtaCteDetalleProximoPago', NULL)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfCtaCteDetalleProximoPago' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO
