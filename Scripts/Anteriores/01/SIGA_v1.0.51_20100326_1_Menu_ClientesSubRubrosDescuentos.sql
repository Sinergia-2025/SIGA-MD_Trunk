DELETE RolesFunciones
 WHERE IdFuncion = 'ClientesSubRubrosDescuentos'
GO

DELETE Funciones
 WHERE Id = 'ClientesSubRubrosDescuentos'
GO
 

--Inserto la pantalla nueva

INSERT INTO Funciones
           (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
           ,IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
           ('ClientesSubRubrosDescuentos', 'Clientes - Asignaci�n de Descuentos en SubRubros', 'Clientes - Asignaci�n de Descuentos en SubRubros', 'True', 'False', 'True', 'True',
           'Archivos', 65, 'Eniac.Win', 'ClientesSubRubrosDescuentos', NULL)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ClientesSubRubrosDescuentos' AS Pantalla FROM dbo.Roles
GO
