
DELETE RolesFunciones
  WHERE IdFuncion IN ('ProductosPorListasDePrecios','ListasDePreciosMultiples')
GO

DELETE Funciones
  WHERE Id IN ('ProductosPorListasDePrecios','ListasDePreciosMultiples')
GO


--Inserto la pantalla nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('ListasDePreciosMultiples', 'Emisión de Listas de Precios Múltiples', 'Emisión de Listas de Precios Múltiples', 
    'True', 'False', 'True', 'True', 'Precios', 60, 'Eniac.Win', 'ListasDePreciosMultiples', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ListasDePreciosMultiples' AS Pantalla FROM dbo.Roles
GO
