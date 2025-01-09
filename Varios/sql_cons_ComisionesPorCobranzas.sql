
SELECT CC.IdCliente
	 , CC.TipoDocVendedor, CC.NroDocVendedor

	--Recibo
	 , CC.IdSucursal 
	 , CC.IdTipoComprobante
	 , CC.Letra
	 , CC.CentroEmisor
	 , CC.NumeroComprobante
	 , CC.Fecha
	 , CC.IdUsuario

	--Comprobante Aplicado

	 , CC2.IdSucursal 
	 , CC2.IdTipoComprobante
	 , CC2.Letra
	 , CC2.CentroEmisor
	 , CC2.NumeroComprobante
	 , CC2.Fecha

  FROM CuentasCorrientes CC 

 --Mira los comprobantes tipo recibo.
 INNER JOIN TiposComprobantes TC on TC.IdTipoComprobante = CC.IdTipoComprobante AND TC.EsRecibo = 'True'

 --Obtiene los comprobantes que se pagaron
 INNER JOIN CuentasCorrientesPagos CCP on ccp.IdSucursal = CC.IdSucursal 
								AND ccp.IdTipoComprobante = CC.IdTipoComprobante
								AND ccp.Letra = CC.Letra
								AND ccp.CentroEmisor = CC.CentroEmisor
								AND ccp.NumeroComprobante = CC.NumeroComprobante

 --Controla el saldo de dichos comprobantes
 INNER JOIN CuentasCorrientes CC2 on CC2.IdSucursal = ccp.IdSucursal
								AND CC2.IdTipoComprobante = ccp.IdTipoComprobante2
								AND CC2.Letra = ccp.Letra2
								AND CC2.CentroEmisor = ccp.CentroEmisor2
								AND CC2.NumeroComprobante = ccp.NumeroComprobante2
								AND CC2.Saldo = 0
 WHERE CC.Fecha >= '20150801 00:00:00'
   AND CC.Fecha <= '20150930 23:59:59'
GO

