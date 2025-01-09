MERGE AFIPTiposComprobantesTiposCbtes AS DEST
        USING (SELECT 1 AS IdAFIPTipoComprobante,'eFACT' AS IdTipoComprobante,'A' AS Letra UNION ALL
        SELECT 1 AS IdAFIPTipoComprobante,'eFACT-Web' AS IdTipoComprobante,'A' AS Letra UNION ALL
        SELECT 1 AS IdAFIPTipoComprobante,'ePRE-FACT' AS IdTipoComprobante,'A' AS Letra UNION ALL
        SELECT 1 AS IdAFIPTipoComprobante,'FACT' AS IdTipoComprobante,'A' AS Letra UNION ALL
        SELECT 1 AS IdAFIPTipoComprobante,'FACTCOM' AS IdTipoComprobante,'A' AS Letra UNION ALL
        
        SELECT 2 AS IdAFIPTipoComprobante,'eNDEB' AS IdTipoComprobante,'A' AS Letra UNION ALL
        SELECT 2 AS IdAFIPTipoComprobante,'eNDEBCHEQRECH' AS IdTipoComprobante,'A' AS Letra UNION ALL
        SELECT 2 AS IdAFIPTipoComprobante,'eNDEB-Web' AS IdTipoComprobante,'A' AS Letra UNION ALL
        SELECT 2 AS IdAFIPTipoComprobante,'ePRE-NDEB' AS IdTipoComprobante,'A' AS Letra UNION ALL
        SELECT 2 AS IdAFIPTipoComprobante,'ePRE-NDEBCHEQR' AS IdTipoComprobante,'A' AS Letra UNION ALL
        SELECT 2 AS IdAFIPTipoComprobante,'NDEB' AS IdTipoComprobante,'A' AS Letra UNION ALL
        SELECT 2 AS IdAFIPTipoComprobante,'NDEBCHEQRECH' AS IdTipoComprobante,'A' AS Letra UNION ALL
        SELECT 2 AS IdAFIPTipoComprobante,'NDEBCOM' AS IdTipoComprobante,'A' AS Letra UNION ALL
        
        SELECT 3 AS IdAFIPTipoComprobante,'eNCRED' AS IdTipoComprobante,'A' AS Letra UNION ALL
        SELECT 3 AS IdAFIPTipoComprobante,'eNCRED-Web' AS IdTipoComprobante,'A' AS Letra UNION ALL
        SELECT 3 AS IdAFIPTipoComprobante,'ePRE-NCRED' AS IdTipoComprobante,'A' AS Letra UNION ALL
        SELECT 3 AS IdAFIPTipoComprobante,'NCRED' AS IdTipoComprobante,'A' AS Letra UNION ALL
        SELECT 3 AS IdAFIPTipoComprobante,'NCREDCOM' AS IdTipoComprobante,'A' AS Letra UNION ALL
        
        SELECT 6 AS IdAFIPTipoComprobante,'eFACT' AS IdTipoComprobante,'B' AS Letra UNION ALL
        SELECT 6 AS IdAFIPTipoComprobante,'eFACT-Web' AS IdTipoComprobante,'B' AS Letra UNION ALL
        SELECT 6 AS IdAFIPTipoComprobante,'ePRE-FACT' AS IdTipoComprobante,'B' AS Letra UNION ALL
        SELECT 6 AS IdAFIPTipoComprobante,'FACT' AS IdTipoComprobante,'B' AS Letra UNION ALL
        SELECT 6 AS IdAFIPTipoComprobante,'FACTCOM' AS IdTipoComprobante,'B' AS Letra UNION ALL
        
        SELECT 7 AS IdAFIPTipoComprobante,'eNDEB' AS IdTipoComprobante,'B' AS Letra UNION ALL
        SELECT 7 AS IdAFIPTipoComprobante,'eNDEBCHEQRECH' AS IdTipoComprobante,'B' AS Letra UNION ALL
        SELECT 7 AS IdAFIPTipoComprobante,'eNDEB-Web' AS IdTipoComprobante,'B' AS Letra UNION ALL
        SELECT 7 AS IdAFIPTipoComprobante,'ePRE-NDEB' AS IdTipoComprobante,'B' AS Letra UNION ALL
        SELECT 7 AS IdAFIPTipoComprobante,'ePRE-NDEBCHEQR' AS IdTipoComprobante,'B' AS Letra UNION ALL
        SELECT 7 AS IdAFIPTipoComprobante,'NDEB' AS IdTipoComprobante,'B' AS Letra UNION ALL
        SELECT 7 AS IdAFIPTipoComprobante,'NDEBCHEQRECH' AS IdTipoComprobante,'B' AS Letra UNION ALL
        SELECT 7 AS IdAFIPTipoComprobante,'NDEBCOM' AS IdTipoComprobante,'B' AS Letra UNION ALL
        
        SELECT 8 AS IdAFIPTipoComprobante,'eNCRED' AS IdTipoComprobante,'B' AS Letra UNION ALL
        SELECT 8 AS IdAFIPTipoComprobante,'eNCRED-Web' AS IdTipoComprobante,'B' AS Letra UNION ALL
        SELECT 8 AS IdAFIPTipoComprobante,'ePRE-NCRED' AS IdTipoComprobante,'B' AS Letra UNION ALL
        SELECT 8 AS IdAFIPTipoComprobante,'NCRED' AS IdTipoComprobante,'B' AS Letra UNION ALL
        SELECT 8 AS IdAFIPTipoComprobante,'NCREDCOM' AS IdTipoComprobante,'B' AS Letra UNION ALL
        
        SELECT 11 AS IdAFIPTipoComprobante,'eFACT' AS IdTipoComprobante,'C' AS Letra UNION ALL
        SELECT 11 AS IdAFIPTipoComprobante,'eFACT-Web' AS IdTipoComprobante,'C' AS Letra UNION ALL
        SELECT 11 AS IdAFIPTipoComprobante,'ePRE-FACT' AS IdTipoComprobante,'C' AS Letra UNION ALL
        SELECT 11 AS IdAFIPTipoComprobante,'FACT' AS IdTipoComprobante,'C' AS Letra UNION ALL
        SELECT 11 AS IdAFIPTipoComprobante,'FACTCOM' AS IdTipoComprobante,'C' AS Letra UNION ALL
        
        SELECT 12 AS IdAFIPTipoComprobante,'eNDEB' AS IdTipoComprobante,'C' AS Letra UNION ALL
        SELECT 12 AS IdAFIPTipoComprobante,'eNDEBCHEQRECH' AS IdTipoComprobante,'C' AS Letra UNION ALL
        SELECT 12 AS IdAFIPTipoComprobante,'eNDEB-Web' AS IdTipoComprobante,'C' AS Letra UNION ALL
        SELECT 12 AS IdAFIPTipoComprobante,'ePRE-NDEB' AS IdTipoComprobante,'C' AS Letra UNION ALL
        SELECT 12 AS IdAFIPTipoComprobante,'ePRE-NDEBCHEQR' AS IdTipoComprobante,'C' AS Letra UNION ALL
        SELECT 12 AS IdAFIPTipoComprobante,'NDEB' AS IdTipoComprobante,'C' AS Letra UNION ALL
        SELECT 12 AS IdAFIPTipoComprobante,'NDEBCHEQRECH' AS IdTipoComprobante,'C' AS Letra UNION ALL
        SELECT 12 AS IdAFIPTipoComprobante,'NDEBCOM' AS IdTipoComprobante,'C' AS Letra UNION ALL
        
        SELECT 13 AS IdAFIPTipoComprobante,'eNCRED' AS IdTipoComprobante,'C' AS Letra UNION ALL
        SELECT 13 AS IdAFIPTipoComprobante,'eNCRED-Web' AS IdTipoComprobante,'C' AS Letra UNION ALL
        SELECT 13 AS IdAFIPTipoComprobante,'ePRE-NCRED' AS IdTipoComprobante,'C' AS Letra UNION ALL
        SELECT 13 AS IdAFIPTipoComprobante,'NCRED' AS IdTipoComprobante,'C' AS Letra UNION ALL
        SELECT 13 AS IdAFIPTipoComprobante,'NCREDCOM' AS IdTipoComprobante,'C' AS C) ORIG
      ON DEST.IdAFIPTipoComprobante = ORIG.IdAFIPTipoComprobante AND DEST.IdTipoComprobante = ORIG.IdTipoComprobante AND DEST.Letra = ORIG.Letra
    WHEN NOT MATCHED THEN 
        INSERT (IdAFIPTipoComprobante, IdTipoComprobante, Letra) VALUES (ORIG.IdAFIPTipoComprobante, ORIG.IdTipoComprobante, ORIG.Letra)
;

ALTER TABLE dbo.ClientesParametros
	DROP CONSTRAINT FK_ClientesParametros_Empresas
GO
