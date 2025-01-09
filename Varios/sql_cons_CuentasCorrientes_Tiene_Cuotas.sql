SELECT cc.IdSucursal, cc.IdTipoComprobante, cc.Letra, cc.CentroEmisor, cc.NumeroComprobante, cc.IdUsuario, CC.Fecha, CC.IdFormasPago
  FROM CuentasCorrientes CC
 INNER JOIN CuentasCorrientesPagos ccp 
                               on  ccp.IdSucursal = cc.IdSucursal 
                               AND ccp.IdTipoComprobante = cc.IdTipoComprobante 
							   AND ccp.Letra = cc.Letra 
							   AND ccp.CentroEmisor = cc.CentroEmisor 
							   AND ccp.NumeroComprobante = cc.NumeroComprobante
 WHERE CCP.IdTipoComprobante = 'eFact'
   and CCP.CuotaNumero>1
order by CC.Fecha desc

