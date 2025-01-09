
--Actualizo la pantalla

UPDATE Funciones
  SET Nombre = 'Movimientos entre Cajas y Sucursales'
     ,Descripcion = 'Movimientos entre Cajas y Sucursales'
  WHERE Id = 'ChequesMovimientosSucursales'
GO

--En algunos lugares con solo 1 Sucursal no estaba.
DELETE RolesFunciones 
 WHERE IdFuncion = 'ChequesMovimientosSucursales' 
  AND IdRol in ('Adm', 'Supervisor')
GO

INSERT INTO RolesFunciones 
           (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ChequesMovimientosSucursales' AS Pantalla FROM dbo.Roles
	WHERE Id in ('Adm', 'Supervisor')
GO
