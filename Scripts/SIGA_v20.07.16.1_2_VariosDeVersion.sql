PRINT ''
PRINT '1. Actualización del Nombre del campo para el buscador de Proyectos'
UPDATE BuscadoresCampos SET
	IdBuscadorNombreCampo = 'IdPrioridadProyecto' WHERE IdBuscadorNombreCampo = 'IdPrioridad'
GO