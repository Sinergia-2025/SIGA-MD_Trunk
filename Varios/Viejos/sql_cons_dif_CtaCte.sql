SELECT CC.IdSucursal, CC.IdTipoComprobante, CC.Letra, CC.CentroEmisor, CC.NumeroComprobante,
       CC.ImporteTotal, CCP.ImporteCuota
   FROM CuentasCorrientes CC, CuentasCorrientesPagos CCP
  WHERE CC.IdSucursal = CCP.IdSucursal
    AND CC.IdTipoComprobante = CCP.IdTipoComprobante 
    AND CC.Letra = CCP.Letra 
    AND CC.CentroEmisor = CCP.CentroEmisor 
    AND CC.NumeroComprobante = CCP.NumeroComprobante 
    AND CC.ImporteTotal <> CCP.ImporteCuota
GO
    
SELECT CC.IdSucursal, CC.IdTipoComprobante, CC.Letra, CC.CentroEmisor, CC.NumeroComprobante,
       CC.ImporteTotal, CCP.ImporteCuota
   FROM CuentasCorrientesProv CC, CuentasCorrientesProvPagos CCP
  WHERE CC.IdSucursal = CCP.IdSucursal
    AND CC.IdTipoComprobante = CCP.IdTipoComprobante 
    AND CC.Letra = CCP.Letra 
    AND CC.CentroEmisor = CCP.CentroEmisor 
    AND CC.NumeroComprobante = CCP.NumeroComprobante 
    AND CC.ImporteTotal <> CCP.ImporteCuota
GO
