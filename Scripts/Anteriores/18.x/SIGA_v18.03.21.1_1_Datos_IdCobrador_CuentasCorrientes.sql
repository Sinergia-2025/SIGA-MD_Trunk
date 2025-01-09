UPDATE CuentasCorrientes
   SET IdCobrador = V.IdCobrador
  FROM Ventas V
 INNER JOIN CuentasCorrientes CC ON CC.IdSucursal = V.IdSucursal
								AND CC.IdTipoComprobante = V.IdTipoComprobante
								AND CC.Letra = V.Letra
								AND CC.CentroEmisor = V.CentroEmisor
								AND CC.NumeroComprobante = V.NumeroComprobante
 WHERE V.IdCobrador IS NOT NULL
   AND CC.IdCobrador IS NULL
