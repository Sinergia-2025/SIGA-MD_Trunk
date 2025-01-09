IF dbo.SoyHAR() = 'True'
    MERGE INTO Parametros AS DEST
            USING (SELECT IdEmpresa, 'FTPUSUARIO2'       AS IdParametro, 'eniacftp'                  ValorParametro, '' DescripcionParametro FROM Empresas UNION ALL
                   SELECT IdEmpresa, 'FTPPASSWORD2'      AS IdParametro, 'Bandera98'                 ValorParametro, '' DescripcionParametro FROM Empresas UNION ALL
                   SELECT IdEmpresa, 'FTPCARPETAREMOTA2' AS IdParametro, 'Actualizador_Aplicaciones' ValorParametro, '' DescripcionParametro FROM Empresas)
               AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
        WHEN MATCHED THEN
            UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
        WHEN NOT MATCHED THEN 
            INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
    ;
