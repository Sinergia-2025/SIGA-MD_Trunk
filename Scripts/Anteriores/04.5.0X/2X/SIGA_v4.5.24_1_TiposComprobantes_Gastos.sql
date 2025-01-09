
SELECT IdTipoComprobante, GrabaLibro, EsComercial, LetrasHabilitadas, AfectaCaja, ActualizaCtaCte, CoeficienteStock, NumeracionAutomatica, UtilizaImpuestos
  FROM TiposComprobantes
 WHERE IdTipoComprobante = 'GASTO'
GO


-- Solo ajusta el seteo si nunca hizo un gasto.
IF NOT EXISTS (SELECT TOP(1) IdSucursal FROM Compras WHERE IdTipoComprobante = 'GASTO' AND ImporteTotal > 0)
BEGIN
	UPDATE TiposComprobantes
	   SET GrabaLibro = 'True'
		 , EsComercial = 'False'
		 , LetrasHabilitadas = 'X'
		 , AfectaCaja = 'True'
		 , ActualizaCtaCte = 'True'
		 , NumeracionAutomatica = 'True'
		 , UtilizaImpuestos = 'False'
	 WHERE IdTipoComprobante='GASTO'
     ;
END

SELECT IdTipoComprobante, GrabaLibro, EsComercial, LetrasHabilitadas, AfectaCaja, ActualizaCtaCte, CoeficienteStock, NumeracionAutomatica, UtilizaImpuestos
  FROM TiposComprobantes
 WHERE IdTipoComprobante = 'GASTO'
GO
