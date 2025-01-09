
--Inserto la pantalla nueva

INSERT INTO Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
     IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
    ('RegistrarMovCtaCteProveedores', 'Registrar Movimientos en Cta.Cte. Proveedores', 'Registrar Movimientos en Cta.Cte. Proveedores', 'True', 'False', 'True', 'True', 
     'CuentasCorrientesProveedores' , 40, 'Eniac.Win', 'RegistrarMovCtaCteProveedores' , NULL)
GO


INSERT INTO RolesFunciones 
     (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'RegistrarMovCtaCteProveedores' AS Pantalla FROM dbo.Roles
GO
