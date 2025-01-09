
--Inserto la pantalla nueva

INSERT INTO Funciones
           (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
           ,IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
           ('ConsultarCtaCteClientesDH', 'Consultar Cta. Cte. de Cliente - Debe y Haber', 'Consultar Cta. Cte. de Cliente - Debe y Haber', 'True', 'False', 'True', 'True',
           'CuentasCorrientes', 45, 'Eniac.Win', 'ConsultarCtaCteClientesDH', NULL)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ConsultarCtaCteClientesDH' AS Pantalla FROM dbo.Roles
GO
