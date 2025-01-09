 
--Inserto la pantalla nueva

INSERT INTO Funciones
           (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
           ,IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
           ('InfComprobCtaCteClientesFecha', 'Informe CtaCte. de Clientes - Comprobantes a Fecha', 'Informe de Cta. Cte. de Clientes - Comprobantes a Fecha', 'True', 'False', 'True', 'True',
           'CuentasCorrientes', 43, 'Eniac.Win', 'InfComprobantesCtaCteClientesFecha', NULL)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfComprobCtaCteClientesFecha' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO
