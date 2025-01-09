
UPDATE CRMEstadosNovedades
   SET PorDefecto = CASE WHEN IdEstadoNovedad = 430 THEN 1 ELSE 0 END
 WHERE IdTipoNovedad = 'TICKETS'
GO
