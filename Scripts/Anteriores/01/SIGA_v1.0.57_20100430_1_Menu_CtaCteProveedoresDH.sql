
--Inserto la pantalla nueva

INSERT INTO Funciones
           (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
            IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
           ('ConsultarCtaCteProveedoresDH', 'Consultar Cta Cte Proveedores - Debe y Haber', 'Consultar Cta Cte Proveedores - Debe y Haber', 'True', 'False', 'True', 'True', 
             'CuentasCorrientesProveedores', 45, 'Eniac.Win', 'ConsultarCtaCteProveedoresDH', NULL)
GO


INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ConsultarCtaCteProveedoresDH' AS Pantalla FROM dbo.Roles
GO
