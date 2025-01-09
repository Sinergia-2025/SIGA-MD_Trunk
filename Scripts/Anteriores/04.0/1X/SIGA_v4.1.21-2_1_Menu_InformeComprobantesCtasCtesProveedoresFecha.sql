
--Inserto la pantalla nueva

INSERT INTO Funciones
           (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
           ,IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
           ('InfComprobCtaCteProvFecha', 'Informe CtaCte. de Prov. - Comprobantes a Fecha', 'Informe de Cta. Cte. de Proveedores - Comprobantes a Fecha', 'True', 'False', 'True', 'True',
           'CuentasCorrientesProveedores', 43, 'Eniac.Win', 'InfComprobCtaCteProvFecha', NULL)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfComprobCtaCteProvFecha' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO
