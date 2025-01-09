UPDATE PeriodosFiscales
   SET TotalNetoVentas =
		(SELECT SUM(VI.Neto) AS TotalNetoVentas
		  FROM VentasImpuestos VI
		  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = VI.IdTipoComprobante
		  INNER JOIN Ventas V ON V.IdSucursal = VI.IdSucursal
							 AND V.IdTipoComprobante = VI.IdTipoComprobante
							 AND V.Letra = VI.Letra
							 AND V.CentroEmisor = VI.CentroEmisor
							 AND V.NumeroComprobante = VI.NumeroComprobante
		  WHERE VI.IdTipoImpuesto = 'IVA'
			AND TC.GrabaLibro = 'True'
			AND RIGHT(TC.IdTipoComprobante,4) <> '-CYO'
			AND YEAR(V.Fecha)*100+MONTH(V.Fecha)  = '201812'
		)
 WHERE PeriodoFiscal = 201812
GO

UPDATE PeriodosFiscales
   SET TotalImpuestosVentas =
		(SELECT SUM(VI.Importe) AS TotalIVAVentas
		  FROM VentasImpuestos VI
		  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = VI.IdTipoComprobante
		  INNER JOIN Ventas V ON V.IdSucursal = VI.IdSucursal
							 AND V.IdTipoComprobante = VI.IdTipoComprobante
							 AND V.Letra = VI.Letra
							 AND V.CentroEmisor = VI.CentroEmisor
							 AND V.NumeroComprobante = VI.NumeroComprobante
		  WHERE VI.IdTipoImpuesto = 'IVA'
			AND TC.GrabaLibro = 'True'
			AND RIGHT(TC.IdTipoComprobante,4) <> '-CYO'
			AND YEAR(V.Fecha)*100+MONTH(V.Fecha)  = '201812'
		)
 WHERE PeriodoFiscal = 201812
GO

-- Se podrian tomar tambien por SUM(VI.Total) de VentasImpuestos
UPDATE PeriodosFiscales
   SET TotalVentas = TotalNetoVentas + TotalImpuestosVentas
 WHERE PeriodoFiscal = 201812
GO

-------------------------------------------

UPDATE PeriodosFiscales 
   SET Posicion = TotalImpuestosVentas - TotalImpuestosCompras
 WHERE PeriodoFiscal = 201812
GO


/* ------------------------------------------------------------------------------ */

UPDATE PeriodosFiscales 
   SET PosicionFinal = Posicion - TotalRetenciones - TotalPercepciones
 WHERE PeriodoFiscal = 201812
GO
