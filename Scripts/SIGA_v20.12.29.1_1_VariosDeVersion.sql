
PRINT ''
PRINT '1. Nuevo Campo: RequiereTesteo en CRMNovedades'
ALTER TABLE dbo.CRMNovedades ADD RequiereTesteo bit NULL
GO
UPDATE CRMNovedades SET RequiereTesteo = 0;
ALTER TABLE dbo.CRMNovedades ALTER COLUMN RequiereTesteo bit NOT NULL
GO

ALTER TABLE dbo.AuditoriaCRMNovedades ADD RequiereTesteo bit NULL
GO


PRINT ''

PRINT '2. Coloco en True a RequiereTesteo de los estados vinculados a test'

--SELECT * FROM CRMEstadosNovedades
--WHERE IdTipoNovedad = 'PENDIENTE'
--AND NombreEstadoNovedad LIKE '%TEST%'

--406	TESTEANDO
--409	PARA TESTEAR
--417	POST-TEST
--418	PRE-TEST
--424	TEST OK

UPDATE CRMNovedades
  SET RequiereTesteo = 'True'
WHERE IdTipoNovedad = 'PENDIENTE'
  AND IdEstadoNovedad IN (406, 409, 417, 418, 424)
GO



