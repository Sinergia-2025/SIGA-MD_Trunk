
SELECT * FROM CuentasCorrientesPagos
  WHERE ImporteCuota = 0
GO

/*

-- Divide por la Cuota pero normalmente no se usa.
UPDATE CuentasCorrientesPagos
 SET SaldoCuota = 
       ( SELECT ROUND(Saldo/CantidadCuotas,2) FROM CuentasCorrientes CC
        WHERE CC.IdSucursal = CuentasCorrientesPagos.IdSucursal
          AND CC.IdTipoComprobante = CuentasCorrientesPagos.IdTipoComprobante
          AND CC.Letra = CuentasCorrientesPagos.Letra
          AND CC.CentroEmisor = CuentasCorrientesPagos.CentroEmisor
          AND CC.NumeroComprobante = CuentasCorrientesPagos.NumeroComprobante
         )
  WHERE ImporteCuota = 0
GO

UPDATE CuentasCorrientesPagos
 SET ImporteCuota = 
       (SELECT ROUND(ImportEtOTAL/CantidadCuotas,2) FROM CuentasCorrientes CC
        WHERE CC.IdSucursal = CuentasCorrientesPagos.IdSucursal
          AND CC.IdTipoComprobante = CuentasCorrientesPagos.IdTipoComprobante
          AND CC.Letra = CuentasCorrientesPagos.Letra
          AND CC.CentroEmisor = CuentasCorrientesPagos.CentroEmisor
          AND CC.NumeroComprobante = CuentasCorrientesPagos.NumeroComprobante
         )
  WHERE ImporteCuota = 0
GO

*/
