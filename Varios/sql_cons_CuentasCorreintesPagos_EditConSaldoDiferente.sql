SELECT     IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, CuotaNumero, Fecha, ImporteCuota, SaldoCuota, IdFormasPago, Observacion, 
                      IdTipoComprobante2, NumeroComprobante2, CentroEmisor2, CuotaNumero2, Letra2, DescuentoRecargo, DescuentoRecargoPorc
FROM         CuentasCorrientesPagos
WHERE     (IdTipoComprobante IN ('ANTICIPO')) AND EXISTS
   (SELECT Saldo FROM CuentasCorrientes AS sub
      WHERE (NroDocCliente = '96')
       AND (CuentasCorrientesPagos.IdSucursal = IdSucursal) 
       AND (CuentasCorrientesPagos.IdTipoComprobante = IdTipoComprobante)
       AND (CuentasCorrientesPagos.Letra = Letra) 
       AND (CuentasCorrientesPagos.CentroEmisor = CentroEmisor)
       AND (CuentasCorrientesPagos.NumeroComprobante = NumeroComprobante))
ORDER BY NumeroComprobante
