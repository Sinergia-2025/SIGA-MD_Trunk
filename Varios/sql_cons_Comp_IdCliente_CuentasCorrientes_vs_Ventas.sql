SELECT CC.IdCliente, V.IdCliente
      ,cc.IdSucursal
      ,cc.IdTipoComprobante
      ,cc.Letra
      ,cc.CentroEmisor
      ,cc.NumeroComprobante
      ,cc.Fecha
  FROM (SELECT * FROM CuentasCorrientes CC WHERE cc.IdTipoComprobante IN ('RECIBO', 'RECIBOPROV', 'RECIBOCYO')) CC
 INNER JOIN CuentasCorrientesPagos CCP
    ON cc.IdSucursal = ccp.IdSucursal
   AND cc.IdTipoComprobante = ccp.IdTipoComprobante
   AND cc.Letra = ccp.Letra
   AND cc.CentroEmisor = ccp.CentroEmisor
   AND cc.NumeroComprobante = ccp.NumeroComprobante
 INNER JOIN Ventas V
    ON V.IdSucursal = ccp.IdSucursal
   AND V.IdTipoComprobante = ccp.IdTipoComprobante2
   AND V.Letra = ccp.Letra2
   AND V.CentroEmisor = ccp.CentroEmisor2
   AND V.NumeroComprobante = ccp.NumeroComprobante2
 WHERE V.IdCliente <> CC.IdCliente