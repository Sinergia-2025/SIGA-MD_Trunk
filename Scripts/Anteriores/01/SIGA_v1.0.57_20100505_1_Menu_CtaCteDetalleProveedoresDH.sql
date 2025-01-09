
--Inserto la pantalla nueva

INSERT INTO Funciones
           (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
            IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
           ('ConsultarCtaCteDetProveedorDH', 'Consultar Cta Cte Det Proveedores - Debe y Haber', 'Consultar Cta Cte Det Proveedores - Debe y Haber', 'True', 'False', 'True', 'True', 
             'CuentasCorrientesProveedores',55, 'Eniac.Win', 'ConsultarCtaCteDetProveedorDH', NULL)
GO


INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ConsultarCtaCteDetProveedorDH' AS Pantalla FROM dbo.Roles

GO
