IF dbo.BaseConCuit('23278908704') = 'True'
BEGIN
    MERGE INTO Traducciones AS DEST
            USING (SELECT 'SILIVE' [IdFuncion], '' [Pantalla], 'ListadoDeClientesConEnvases_TituloCantidadEnvase1' [Control], 'es_AR' [IdIdioma], 'G' [Texto] UNION ALL
                   SELECT 'SILIVE', '', 'ListadoDeClientesConEnvases_TituloCantidadEnvase2', 'es_AR', 'C') AS ORIG
               ON DEST.[IdFuncion] = ORIG.[IdFuncion] AND DEST.[Pantalla] = ORIG.[Pantalla] AND DEST.[Control] = ORIG.[Control] AND DEST.[IdIdioma] = ORIG.[IdIdioma]
        WHEN MATCHED THEN
            UPDATE SET DEST.[Texto] = ORIG.[Texto]
        WHEN NOT MATCHED THEN 
            INSERT (     [IdFuncion],      [Pantalla],      [Control],      [IdIdioma],      [Texto])
            VALUES (ORIG.[IdFuncion], ORIG.[Pantalla], ORIG.[Control], ORIG.[IdIdioma], ORIG.[Texto])
    ;
END
