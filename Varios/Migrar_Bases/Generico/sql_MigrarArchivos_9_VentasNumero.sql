
MERGE INTO VentasNumeros AS VNO
     USING MO_SIGA.dbo.VentasNumeros AS VND
        ON VNO.IdTipoComprobante = VND.IdTipoComprobante
        AND VNO.LetraFiscal = VND.LetraFiscal
        AND VNO.CentroEmisor = VND.CentroEmisor
 WHEN NOT MATCHED THEN
    INSERT (IdTipoComprobante, LetraFiscal, CentroEmisor, IdSucursal,   Numero,    IdTipoComprobanteRelacionado,    Fecha)
    VALUES (VND.IdTipoComprobante, VND.LetraFiscal, VND.CentroEmisor, VND.IdSucursal, VND.Numero, VND.IdTipoComprobanteRelacionado, GETDATE()-1)
;
