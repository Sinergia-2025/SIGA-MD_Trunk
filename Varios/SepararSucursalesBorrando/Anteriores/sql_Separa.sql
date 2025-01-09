SELECT DISTINCT C.IdTipoComprobante
  FROM Compras C
  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = C.IdTipoComprobante
      AND (TC.GrabaLibro=0)

SELECT DISTINCT v.IdTipoComprobante
  FROM Ventas V
  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante
     AND (TC.GrabaLibro=0 AND TC.EsPreElectronico=0)
     AND TC.IdTipoComprobante NOT IN ('REPRESENTACION','REPRESENT-NC','REMITOTRANSP')
     
SELECT *
  FROM Ventas V
  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante
     AND (TC.GrabaLibro=0 AND TC.EsPreElectronico=0)
     AND TC.IdTipoComprobante NOT IN ('REPRESENTACION','REPRESENT-NC','REMITOTRANSP')
  WHERE V.IdSucursal = 1
    AND v.IdTipoComprobanteFact = 'REMITOTRANSP'
     