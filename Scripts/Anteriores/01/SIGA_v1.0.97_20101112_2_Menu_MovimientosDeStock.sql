  
--Inserto la pantalla nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('MovimientosDeStock', 'Movimientos de Stock', 'Movimientos de Stock', 
    'True', 'False', 'True', 'True', 'Stock', 10, 'Eniac.Win', 'MovimientosDeStock', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'MovimientosDeStock' AS Pantalla FROM dbo.Roles
GO


UPDATE Funciones SET 
   [Enabled] = 'False',
   Visible  = 'False'
  WHERE Id = 'MovimientoStock'
GO
