
DELETE RolesFunciones
  WHERE IdFuncion IN ('ClientesListPrecMarca','ModificarPrecios','ClientesListaDePreciosMarca')
GO

DELETE Funciones
  WHERE Id IN ('ClientesListPrecMarca','ModificarPrecios','ClientesListaDePreciosMarca')
GO


--Inserto la pantalla nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
   ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
   ('ClientesListaDePreciosMarca', 'Clientes - Asignación Listas de Precios/Marca', 'Clientes - Asignación Listas de Precios/Marca', 'True', 'False', 'True', 'True',
   'Precios', 70, 'Eniac.Win', 'ClientesListaDePreciosMarca', NULL)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ClientesListaDePreciosMarca' AS Pantalla FROM dbo.Roles
GO


