
SELECT P1.IdEmpresa, P1.IdParametro, P1.ValorParametro, P2.ValorParametro
  FROM SIGA_TemporadaCamping_20220406.dbo.Parametros P1
 INNER JOIN SIGA_TemporadaCamping.dbo.Parametros P2 ON P1.IdParametro = P2.IdParametro AND P1.IdEmpresa = P2.IdEmpresa
 WHERE P1.ValorParametro <> P2.ValorParametro

SELECT *
  FROM (
        SELECT 'TC1' Tabla, *
            FROM SIGA_TemporadaCamping_20220406.dbo.TiposComprobantes TC1
        UNION
        SELECT 'TC2', *
            FROM SIGA_TemporadaCamping.dbo.TiposComprobantes TC2
        ) TC
 WHERE TC.IdTipoComprobante IN (
                                SELECT IdTipoComprobante
                                  FROM (
                                        SELECT *
                                          FROM SIGA_TemporadaCamping_20220406.dbo.TiposComprobantes TC1
                                        UNION
                                        SELECT *
                                          FROM SIGA_TemporadaCamping.dbo.TiposComprobantes TC2
                                        ) TC
                                  GROUP BY IdTipoComprobante
                                 HAVING COUNT(1) > 1)
