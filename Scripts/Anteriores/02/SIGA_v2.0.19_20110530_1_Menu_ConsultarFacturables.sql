
--Pantalla Nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('ConsultarFacturables', 'Consultar Facturables', 'Consultar Facturables', 
    'True', 'False', 'True', 'True', 'Ventas', 25, 'Eniac.Win', 'ConsultarFacturables', NULL)
GO


INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ConsultarFacturables' AS Pantalla FROM dbo.Roles
GO
