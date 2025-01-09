SELECT * FROM CuentasCorrientes
 WHERE NOT EXISTS 
     ( SELECT * FROM CuentasCorrientesPagos CCP
       WHERE CCP.IdSucursal = CuentasCorrientes.IdSucursal
         AND CCP.IdTipoComprobante = CuentasCorrientes.IdTipoComprobante
         AND CCP.Letra = CuentasCorrientes.Letra
         AND CCP.CentroEmisor = CuentasCorrientes.CentroEmisor
         AND CCP.NumeroComprobante = CuentasCorrientes.NumeroComprobante)
   AND IdTipoComprobante<>'RECIBO'
GO

