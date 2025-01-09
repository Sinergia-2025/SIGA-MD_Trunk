
--19/10: Agregado Sñl


-- Solo queda en HAR, Generico, Met.A., V.P., I-Pol, Sñl / CEAR
IF NOT EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                AND P.ValorParametro IN ('33711345499','50000000024','20231852698','30711162891', '30506105419', '30711915695','30715213091'))	
BEGIN

	DELETE Bitacora 
	 WHERE IdFuncion IN (SELECT Id FROM Funciones
						  WHERE Id = 'Presupuestos' OR IdPadre='Presupuestos')
	;

	DELETE Traducciones
	WHERE IdFuncion IN (SELECT Id FROM Funciones
						 WHERE Id = 'Presupuestos' OR IdPadre='Presupuestos')
	;

	DELETE RolesFunciones
	WHERE IdFuncion IN (SELECT Id FROM Funciones
						 WHERE Id = 'Presupuestos' OR IdPadre='Presupuestos')
	;

	DELETE Funciones
	WHERE IdPadre = 'Presupuestos'
	;

	DELETE Funciones
	WHERE Id = 'Presupuestos'
	;

END
