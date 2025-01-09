--FALTA  (HACER JOIN)
---CRMClientesInterlocutores
--CRMProspectosInterlocutores
--CRMProveedoresInterlocutores

DECLARE @IdTablero VARCHAR(MAX) = 'SERVICE'

PRINT ''
PRINT '1. Borra Tabla CRMNovedadesSeguimientoAdjuntos.'
DELETE CRMNovedadesSeguimientoAdjuntos
 WHERE IdTipoNovedad = @IdTablero
;

PRINT ''
PRINT '2. Borra Tabla CRMNovedadesSeguimiento.'
DELETE CRMNovedadesSeguimiento
 WHERE IdTipoNovedad = @IdTablero
;

PRINT ''
PRINT '3. Borra Tabla CRMNovedades.'
DELETE CRMNovedades
 WHERE IdTipoNovedad = @IdTablero
;

PRINT ''
PRINT '4. Borra Tabla CRMCategoriasNovedades.'
DELETE CRMCategoriasNovedades
 WHERE IdTipoNovedad = @IdTablero
;

PRINT ''
PRINT '5. Borra Tabla CRMEstadosNovedades.'
DELETE CRMEstadosNovedades
 WHERE IdTipoNovedad = @IdTablero
;

PRINT ''
PRINT '6. Borra Tabla CRMMediosComunicacionesNovedades.'
DELETE CRMMediosComunicacionesNovedades
 WHERE IdTipoNovedad = @IdTablero
;


PRINT ''
PRINT '7. Borra Tabla CRMMetodosResolucionesNovedades.'
DELETE CRMMetodosResolucionesNovedades
 WHERE IdTipoNovedad = @IdTablero
;

PRINT ''
PRINT '8. Borra Tabla CRMPrioridadesNovedades.'
DELETE CRMPrioridadesNovedades
 WHERE IdTipoNovedad = @IdTablero
;

PRINT ''
PRINT '9. Borra Tabla CRMTiposNovedadesDinamicos.'
DELETE CRMTiposNovedadesDinamicos
 WHERE IdTipoNovedad = @IdTablero
;

PRINT ''
PRINT '10. Borra Tabla CRMTiposNovedades.'
DELETE CRMTiposNovedades
 WHERE IdTipoNovedad = @IdTablero
;
