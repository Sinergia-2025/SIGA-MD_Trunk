-- Inserto la pantalla nueva

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
     ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('InfLiquidacionDetallada', 'Informe de Liquidacion Detallada', 'Informe de Liquidacion Detallada', 'True', 'False', 'True', 'True',
      'Cargos', 75, 'Eniac.Win', 'InfLiquidacionDetallada', NULL)
GO

INSERT INTO RolesFunciones 
      (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfLiquidacionDetallada' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO