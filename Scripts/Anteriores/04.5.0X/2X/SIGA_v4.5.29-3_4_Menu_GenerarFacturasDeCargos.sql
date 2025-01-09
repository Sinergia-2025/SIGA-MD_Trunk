
--Inserto la pantalla nueva

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
     ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('GenerarFacturasDeCargos', 'Generar Facturas de Cargos', 'Generar Facturas de Cargos', 'True', 'False', 'True', 'True',
      'Cargos', 90, 'Eniac.Win', 'GenerarFacturasDeCargos', NULL)
GO

INSERT INTO RolesFunciones 
      (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'GenerarFacturasDeCargos' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO
