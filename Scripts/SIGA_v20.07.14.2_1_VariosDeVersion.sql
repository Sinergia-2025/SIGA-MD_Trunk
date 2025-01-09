PRINT ''
PRINT '1. Actualizo el estado de proyectos: Garantía > Abono'
UPDATE Proyectos SET
	Estado = 'Abono'
		WHERE Estado = 'Garantia'
GO

PRINT ''
PRINT '2. Actualizo los proyectos con Estado: Enviado/Aprobado/Rechazado > Pendiente'
UPDATE Proyectos SET
	Estado = 'Pendiente'
		WHERE Estado = 'Enviado' OR Estado = 'Aprobado' OR Estado = 'Rechazado'
GO
