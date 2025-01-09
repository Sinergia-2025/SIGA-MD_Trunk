IF dbo.BaseConCUIT('30714757128') = 1
BEGIN
    UPDATE CC
       SET CantidadCuotas = (SELECT COUNT(1)
                               FROM CuentasCorrientesPagos CCP
                              WHERE CCP.IdSucursal = CC.IdSucursal
                                AND CCP.IdTipoComprobante = CC.IdTipoComprobante
                                AND CCP.Letra = CC.Letra
                                AND CCP.CentroEmisor = CC.CentroEmisor
                                AND CCP.NumeroComprobante = CC.NumeroComprobante)
      FROM CuentasCorrientes CC
     INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CC.IdTipoComprobante
     WHERE CC.CantidadCuotas = 0
       AND TC.EsRecibo = 0
END