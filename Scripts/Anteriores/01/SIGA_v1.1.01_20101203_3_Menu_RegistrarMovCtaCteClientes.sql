
--Inserto la pantalla nueva

INSERT INTO Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
     IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
    ('RegistrarMovCtaCteClientes', 'Registrar Movimientos en Cta.Cte. Clientes', 'Registrar Movimientos en Cta.Cte. Clientes', 'True', 'False', 'True', 'True', 
     'CuentasCorrientes' , 40, 'Eniac.Win', 'RegistrarMovCtaCteClientes' , NULL)
GO


INSERT INTO RolesFunciones 
     (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'RegistrarMovCtaCteClientes' AS Pantalla FROM dbo.Roles
GO
