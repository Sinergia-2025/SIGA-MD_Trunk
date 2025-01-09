PRINT ''
PRINT '1. Actualización de Datos'
UPDATE CC SET CC.NumeroReparto = V.NumeroReparto
  FROM Ventas V
 INNER JOIN CuentasCorrientes CC ON CC.IdSucursal = V.IdSucursal
                                AND CC.IdTipoComprobante = V.IdTipoComprobante
                                AND CC.Letra = V.Letra
                                AND CC.CentroEmisor = V.CentroEmisor
                                AND CC.NumeroComprobante = V.NumeroComprobante
 WHERE V.NumeroReparto IS NOT NULL
   AND V.NumeroReparto <> ISNULL(CC.NumeroReparto, -1)
GO
