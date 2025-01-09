--Inserto la pantalla nueva

INSERT INTO Funciones
  (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
   ,IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
  ('FacturacionRapida', 'Facturación Rápida', 'Facturación Rápida', 'True', 'False', 'True', 'True',
  'Ventas', 15, 'Eniac.Win', 'FacturacionRapida', NULL)
GO

INSERT INTO RolesFunciones 
      (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'FacturacionRapida' AS Pantalla FROM dbo.Roles
GO
