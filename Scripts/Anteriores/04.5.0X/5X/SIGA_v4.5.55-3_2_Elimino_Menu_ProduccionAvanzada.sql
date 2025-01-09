
--19/10: Agregado S�l

-- Todavia No existen.
--Inf. de Ordenes de Producci�n Detallado
--Inf. de Ordenes de Producci�n Suma por Productos


-- Solo queda en Generico, V.P., I-Pol, S�l
IF NOT EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                AND P.ValorParametro IN ('50000000024','30711162891', '30506105419', '30711915695'))	
BEGIN

	DELETE Bitacora 
	 WHERE IdFuncion IN (SELECT Id FROM Funciones
						  WHERE Id IN ('OrdenesDeProduccion', 'ConsultarOrdenesProduccion', 'AnularOrdenesProduccion', 'EstadosOrdenesProduccionABM', 'OrdenesProduccionAdmin'))
	;

	DELETE Traducciones
	WHERE IdFuncion IN (SELECT Id FROM Funciones
						 WHERE Id IN ('OrdenesDeProduccion', 'ConsultarOrdenesProduccion', 'AnularOrdenesProduccion', 'EstadosOrdenesProduccionABM', 'OrdenesProduccionAdmin'))
	;

	DELETE RolesFunciones
	WHERE IdFuncion IN (SELECT Id FROM Funciones
						 WHERE Id IN ('OrdenesDeProduccion', 'ConsultarOrdenesProduccion', 'AnularOrdenesProduccion', 'EstadosOrdenesProduccionABM', 'OrdenesProduccionAdmin'))
	;

	DELETE Funciones
	WHERE Id IN ('OrdenesDeProduccion', 'ConsultarOrdenesProduccion', 'AnularOrdenesProduccion', 'EstadosOrdenesProduccionABM', 'OrdenesProduccionAdmin')
	;

END
