
--Inserto la pantalla nueva

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
     ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('SueldosModificarLiquidacion', 'Modificar Datos de Liquidacion', 'Modificar Datos de Liquidacion', 
	  'True', 'False', 'True', 'True',
      'Sueldos', 45, 'Eniac.Win', 'SueldosModificarLiquidacion', NULL)
GO

INSERT INTO RolesFunciones 
      (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'SueldosModificarLiquidacion' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO
