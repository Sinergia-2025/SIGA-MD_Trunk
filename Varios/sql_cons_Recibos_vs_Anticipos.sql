SELECT Letra, CentroEmisor, NumeroComprobante, SUM(Saldo) AS Suma
FROM 
(
SELECT CC.IdTipoComprobante, CC.Letra, CC.CentroEmisor, CC.NumeroComprobante, CC.ImporteTotal, CC.Saldo
  FROM CuentasCorrientes CC, TiposComprobantes TC
 WHERE CC.IdTipoComprobante=TC.IdTipoComprobante
 AND TC.EsAnticipo=1
 AND Saldo<>0
union
SELECT CC.IdTipoComprobante, CC.Letra, CC.CentroEmisor, CC.NumeroComprobante, CC.ImporteTotal, CC.Saldo*(-1) as Saldo
  FROM CuentasCorrientes CC, TiposComprobantes TC
 WHERE CC.IdTipoComprobante=TC.IdTipoComprobanteSecundario
 AND TC.EsAnticipo=1
 AND Saldo<>0
--ORDER BY 2,3,4,5
) A
GROUP BY Letra, CentroEmisor, NumeroComprobante
HAVING SUM(Saldo)<>0