
--Inserto la pantalla nueva

INSERT INTO Funciones
           (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
           ,IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
           ('ConsultarCtaCteDetClientesDH', 'Consultar Cta. Cte. Det. de Cliente - Debe y Haber', 'Consultar Cta. Cte. Detallada de Cliente - Debe y Haber', 'True', 'False', 'True', 'True',
           'CuentasCorrientes', 55, 'Eniac.Win', 'ConsultarCtaCteDetClientesDH', NULL)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ConsultarCtaCteDetClientesDH' AS Pantalla FROM dbo.Roles
GO
