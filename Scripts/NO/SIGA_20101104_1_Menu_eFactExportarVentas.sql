--Inserto el Menu Nuevo

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('eFACT', 'Facturacion Electronica', 'Facturacion Electronica', 
    'True', 'False', 'True', 'True', 'Ventas', 180, NULL, NULL, NULL)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'eFACT' AS Pantalla FROM dbo.Roles
GO


  
--Inserto la pantalla nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('eFactExportarVentas', 'eFact - Exportar Comprobantes de Ventas', 'eFact - Exportar Comprobantes de Ventas', 
    'True', 'False', 'True', 'True', 'eFACT', 10, 'Eniac.Win', 'eFactExportarVentas', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'eFactExportarVentas' AS Pantalla FROM dbo.Roles
GO
