
DELETE RolesFunciones WHERE IdFuncion = 'ListasPreciosImagen'
GO

DELETE Funciones WHERE Id = 'ListasPreciosImagen'
GO


--Inserto la pantalla nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('ListaDePreciosParaClientes', 'Emisión de Lista de Precios para Clientes', 'Emisión de Lista de Precios para Clientes', 
    'True', 'False', 'True', 'True', 'Precios', 65, 'Eniac.Win', 'ListaDePreciosParaClientes', NULL)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ListaDePreciosParaClientes' AS Pantalla FROM dbo.Roles
GO
