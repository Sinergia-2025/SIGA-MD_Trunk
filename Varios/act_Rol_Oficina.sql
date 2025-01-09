
DELETE RolesFunciones
 WHERE IdRol = 'Oficina'
GO

INSERT INTO RolesFunciones
    (IdRol, IdFuncion)
SELECT 'Oficina' AS XXIdRol, IdFuncion FROM RolesFunciones
 WHERE IdRol = 'Supervisor'
GO

DELETE RolesFunciones
 WHERE IdRol = 'Oficina'
   AND IdFuncion IN (SELECT Id FROM Funciones
					  WHERE Id = 'VentasUtilidades' or IdPadre = 'VentasUtilidades'
					     OR Id = 'Seguridad' or IdPadre = 'Seguridad'
						 OR Id LIKE 'Anular%'
						 OR Id LIKE 'Eliminar%')
GO
