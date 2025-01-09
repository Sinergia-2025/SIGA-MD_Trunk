
UPDATE CRMEstadosNovedades
   SET NombreEstadoNovedad = 'VENDIDO'
 WHERE IdTipoNovedad = 'PROSP'
   AND NombreEstadoNovedad = 'FINALIZADO'
;

UPDATE CRMEstadosNovedades
   SET NombreEstadoNovedad = 'NO VENDIDO'
 WHERE IdTipoNovedad = 'PROSP'
  AND NombreEstadoNovedad = 'CANCELADO'
;

SELECT * FROM CRMEstadosNovedades
 WHERE IdTipoNovedad = 'PROSP'
;
