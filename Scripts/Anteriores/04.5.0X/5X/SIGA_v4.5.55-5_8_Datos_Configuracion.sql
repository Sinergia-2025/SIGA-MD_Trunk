
-- Si tiene el menu de Fichas
IF EXISTS (SELECT * FROM Funciones F
            INNER JOIN RolesFunciones RF ON RF.IdFuncion = F.Id
            WHERE F.Id = 'Fichas')
BEGIN
    MERGE INTO Parametros AS P
         USING (SELECT 'INTERESESMETODOPARADETERMINARRANGO' AS IdParametro
                       ,'DIASCORRIDOSVENCIMIENTO' ValorParametro
                       ,NULL AS CategoriaParametro
                       ,'Intereses toma desde/hasta como' AS DescripcionParametro) AS PT
            ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN
        UPDATE
           SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN
        INSERT (   IdParametro,    ValorParametro,    CategoriaParametro,    DescripcionParametro)
        VALUES (PT.IdParametro, PT.ValorParametro, PT.CategoriaParametro, PT.DescripcionParametro)
    ;
    MERGE INTO Parametros AS P
         USING (SELECT 'INTERESESCALCULOCOMPLETOPRIMERPAGO' AS IdParametro
                       ,'False' ValorParametro
                       ,NULL AS CategoriaParametro
                       ,'Los Intereses se Calculan Completamente en el Primer Pago' AS DescripcionParametro) AS PT
            ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN
        UPDATE
           SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN
        INSERT (   IdParametro,    ValorParametro,    CategoriaParametro,    DescripcionParametro)
        VALUES (PT.IdParametro, PT.ValorParametro, PT.CategoriaParametro, PT.DescripcionParametro)
    ;
    MERGE INTO Parametros AS P
         USING (SELECT 'INTERESESMONTOAPLICADOINCLUYEINTERESES' AS IdParametro
                       ,'False' ValorParametro
                       ,NULL AS CategoriaParametro
                       ,'Monto Aplicado Incluye los Intereses' AS DescripcionParametro) AS PT
            ON P.IdParametro = PT.IdParametro
     WHEN MATCHED THEN
        UPDATE
           SET P.ValorParametro = PT.ValorParametro
     WHEN NOT MATCHED THEN
        INSERT (   IdParametro,    ValorParametro,    CategoriaParametro,    DescripcionParametro)
        VALUES (PT.IdParametro, PT.ValorParametro, PT.CategoriaParametro, PT.DescripcionParametro)
    ;
END

SELECT *
  FROM Parametros
 WHERE IdParametro IN ('INTERESESMETODOPARADETERMINARRANGO',
                       'INTERESESCALCULOCOMPLETOPRIMERPAGO',
                       'INTERESESMONTOAPLICADOINCLUYEINTERESES')
;
