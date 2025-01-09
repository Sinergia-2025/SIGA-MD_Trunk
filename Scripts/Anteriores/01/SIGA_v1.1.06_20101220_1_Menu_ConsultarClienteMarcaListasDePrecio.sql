
DELETE RolesFunciones
  WHERE IdFuncion IN ('ConsultaListasPrecios','ConsultarClientesListaDPMarca','ConsultarClienteMarcaLDePrecio')
GO

DELETE Funciones
  WHERE Id IN ('ConsultaListasPrecios','ConsultarClientesListaDPMarca','ConsultarClienteMarcaLDePrecio')
GO


--Inserto la pantalla nueva

INSERT INTO Funciones
           (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
           ,IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
           ('ConsultarClienteMarcaLDePrecio', 'Consultar Clientes/Listas de Precios/Marca', 'Consultar Clientes/Listas de Precios/Marca', 'True', 'False', 'True', 'True',
           'Precios', 80, 'Eniac.Win', 'ConsultarClienteMarcaLDePrecio', NULL)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ConsultarClienteMarcaLDePrecio' AS Pantalla FROM dbo.Roles
GO
