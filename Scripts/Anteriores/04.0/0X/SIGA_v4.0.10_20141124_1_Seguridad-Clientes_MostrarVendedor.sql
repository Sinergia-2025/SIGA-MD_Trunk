
INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('Clientes-MostrarVendedor', 'Clientes - Mostrar Vendedor', 'Clientes - Mostrar Vendedor', 
    'False', 'False', 'True', 'False', 'Clientes', 10, 'Eniac.Win', 'Clientes-MostrarVendedor', NULL)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'Clientes-MostrarVendedor' AS Pantalla FROM dbo.Roles
--    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO
