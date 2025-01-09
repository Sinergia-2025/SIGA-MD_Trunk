SELECT c.CodigoCliente, c.NombreCliente, CCR.Saldo, CCA.Saldo, *
  FROM CuentasCorrientes CCR  
 INNER JOIN CuentasCorrientes CCA ON CCA.IdTipoComprobante = 'ANTICIPOe'
                                 AND CCA.Letra = CCR.Letra
                                 AND CCA.CentroEmisor = CCR.CentroEmisor
                                 AND CCA.NumeroComprobante = CCR.NumeroComprobante
INNER JOIN  clientes c ON ccR.idcliente = c.IdCliente
 WHERE CCR.IdTipoComprobante = 'RECIBO-DA'
  and CCA.Saldo<0
 order by c.NombreCliente