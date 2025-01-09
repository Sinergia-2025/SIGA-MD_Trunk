
--Inserto la pantalla nueva

INSERT INTO Funciones
           (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
           ,IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
           ('ClientesListPrecMarca', 'Clientes - Asignación Listas de Precios/Marca', 'Clientes - Asignación Listas de Precios/Marca', 'True', 'False', 'True', 'True',
           'Archivos', 65, 'Eniac.Win', 'ClientesListasPreciosMarca', NULL)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ClientesListPrecMarca' AS Pantalla FROM dbo.Roles
GO

