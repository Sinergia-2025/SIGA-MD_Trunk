
--Inserto la pantalla nueva

INSERT INTO Funciones
      (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
      ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
      ('ChequesMovimientosSucursales', 'Movimientos de Cheques entre Sucursales', 'Movimientos de Cheques entre Sucursales', 1, 0, 1, 1,
      'Caja', 160, 'Eniac.Win', 'ChequesMovimientosSucursales', NULL)
GO

INSERT INTO RolesFunciones 
           (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ChequesMovimientosSucursales' AS Pantalla FROM dbo.Roles
	WHERE Id = 'Adm'

GO

--En caso de tener Sucursales le agrego el menu al rol Supervisor.

IF EXISTS(SELECT IdSucursal, COUNT(IdSucursal) FROM Sucursales
               GROUP BY IdSucursal
               HAVING IdSucursal > 1)

	INSERT INTO RolesFunciones 
			   (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'ChequesMovimientosSucursales' AS Pantalla FROM dbo.Roles
		WHERE Id = 'Supervisor'
        
GO
