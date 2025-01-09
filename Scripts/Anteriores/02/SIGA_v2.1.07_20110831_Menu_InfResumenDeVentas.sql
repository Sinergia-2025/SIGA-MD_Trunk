
--Inserto la pantalla nueva

INSERT INTO Funciones
           (Id, Nombre, Descripcion, 
            EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
           ('InfResumenDeVentas', 'Inf. Resumen de Ventas', 'Inf. Resumen de Ventas',
            'True', 'False', 'True', 'True', 'Ventas', 50, 'Eniac.Win', 'InfResumenDeVentas', NULL)
GO

/*
INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfResumenDeVentas' AS Pantalla FROM Roles
GO
*/

UPDATE RolesFunciones SET IdFuncion = 'InfResumenDeVentas'
  WHERE IdFuncion = 'ResumenPorComprobanteVentas'
GO

DELETE Funciones
  WHERE Id = 'ResumenPorComprobanteVentas'
GO
