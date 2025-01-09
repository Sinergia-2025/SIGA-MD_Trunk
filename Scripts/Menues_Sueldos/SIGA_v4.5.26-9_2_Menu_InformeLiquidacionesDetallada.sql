 
--Inserto la pantalla nueva

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
     ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('SueldosInformeLiquidacionesDet', 'Informe de Liquidaciones Detallada', 'Informe de Liquidaciones Detallada', 'True', 'False', 'True', 'True',
      'Sueldos', 75, 'Eniac.Win', 'SueldosInformeLiquidacionesDet', NULL)
GO

INSERT INTO RolesFunciones 
      (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'SueldosInformeLiquidacionesDet' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO
