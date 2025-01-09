
--Insertar Menu

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], 
      Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('SueldosReAbrirLiquidacion', 'Sueldos Reabrir Liquidacion', 'Sueldos Reabrir Liquidacion', 'False', 'False', 'True',
      'True', 'SueldosLiquidacion', 999, '', '', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'SueldosReAbrirLiquidacion' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervisor') 
GO
