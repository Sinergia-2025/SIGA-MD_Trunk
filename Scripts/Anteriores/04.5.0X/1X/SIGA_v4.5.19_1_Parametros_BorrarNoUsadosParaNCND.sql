
-- Estaban duplicados.
DELETE Parametros
 WHERE IdParametro IN ('IDNDEBRECARGOGL', 'IDNDEBRECARGONOGL', 'IDNCREDDESCUENTOGL', 'IDNCREDDESCUENTONOGL')
GO
