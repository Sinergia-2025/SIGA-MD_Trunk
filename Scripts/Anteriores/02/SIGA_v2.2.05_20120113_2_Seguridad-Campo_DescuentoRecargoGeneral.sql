
DELETE RolesFunciones WHERE IdFuncion = 'Clientes-DescRecGeneralPorc'
GO

DELETE Funciones WHERE Id = 'Clientes-DescRecGeneralPorc'
GO

--Inserto el Campo de Pantalla

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('Clientes-DescRecGeneralPorc', 'Clientes - Porc. Descuento/Recargo General', 'Porc. Clientes - Descuento/Recargo General', 
    'False', 'False', 'True', 'True', 'Clientes', 10, 'Eniac.Win', 'Clientes-DescRecGeneralPorc', NULL)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'Clientes-DescRecGeneralPorc' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO
