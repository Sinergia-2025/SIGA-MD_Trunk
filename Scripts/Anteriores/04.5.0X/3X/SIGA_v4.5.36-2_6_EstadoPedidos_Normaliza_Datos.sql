
DELETE EstadosPedidos WHERE IdTipoEstado = 'CANCELADO';

UPDATE EstadosPedidos SET IdTipoEstado = 'ENTREGADO' WHERE IdTipoEstado = 'FINALIZADO';

-- Atencion que campo "AfectaPendiente" debe estar en FALSE para PENDIENTE y EN PROCESO.

SELECT * FROM EstadosPedidos ORDER BY Orden;
