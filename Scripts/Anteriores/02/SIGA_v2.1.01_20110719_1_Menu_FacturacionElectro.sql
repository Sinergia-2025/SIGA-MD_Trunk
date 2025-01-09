
--Pantalla Nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, Enabled, Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('FacturacionElectro', 'Facturacion Electrónica', 'Facturacion Electrónica', 
    'True', 'False', 'True', 'True', 'Ventas', 4, 'Eniac.Win', 'FacturacionElectro', NULL)
GO


INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'FacturacionElectro' AS Pantalla FROM dbo.Roles
GO
