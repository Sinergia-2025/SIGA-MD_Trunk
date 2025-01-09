
-- Limpio el SAldo de CtaCte de los Recibos que aplican Anticipos porque esta mal calculado.

UPDATE CuentasCorrientes
   SET SaldoCtaCte = NULL
 WHERE SaldoCtaCte IS NOT NULL
 AND EXISTS 
     ( SELECT * FROM CuentasCorrientesPagos CCP, TiposComprobantes TC
        WHERE CCP.IdSucursal = CuentasCorrientes.IdSucursal
          AND CCP.IdTipoComprobante = CuentasCorrientes.IdTipoComprobante
          AND CCP.Letra = CuentasCorrientes.Letra
          AND CCP.CentroEmisor = CuentasCorrientes.CentroEmisor
          AND CCP.NumeroComprobante = CuentasCorrientes.NumeroComprobante
          AND CCP.IdTipoComprobante2 = TC.IdTipoComprobante
          AND TC.EsAnticipo = 'True' )
GO
