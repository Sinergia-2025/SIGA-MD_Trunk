SELECT * FROM PeriodosFiscales
	WHERE IdEmpresa = 1

SELECT * FROM PeriodosFiscales
	WHERE IdEmpresa = 1

UPDATE PeriodosFiscales SET
		 TotalNetoVentas = 0.00
		,TotalImpuestosVentas = 0.00
		,TotalVentas = 0.00
		,TotalNetoCompras = 0.00
		,TotalCompras = 0.00
		,TotalRetenciones = 0.00
		,TotalPercepciones = 0.00
		,Posicion = 0.00
		,PosicionFinal = 0.00
where IdEmpresa = 1 and PeriodoFiscal <= '201910'