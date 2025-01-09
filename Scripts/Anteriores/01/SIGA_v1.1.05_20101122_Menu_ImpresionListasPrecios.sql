
--Inserto la pantalla nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('ProductosPorListasDePrecios', 'Impresion de Listas de Precios', 'Impresion de Listas de Precios', 
    'True', 'False', 'True', 'True', 'Precios', 110, 'Eniac.Win', 'ProductosPorListasDePrecios', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ProductosPorListasDePrecios' AS Pantalla FROM dbo.Roles
GO

