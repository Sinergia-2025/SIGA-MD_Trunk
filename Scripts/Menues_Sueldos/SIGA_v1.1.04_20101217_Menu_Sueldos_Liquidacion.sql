
--Inserto la pantalla nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('SueldosLiquidacion', 'Liquidación de Sueldos', 'Liquidación de Sueldos', 
    'True', 'False', 'True', 'True', 'Sueldos', 20, 'Eniac.Win', 'SueldosLiquidacion', NULL)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'SueldosLiquidacion' AS Pantalla FROM dbo.Roles
GO
