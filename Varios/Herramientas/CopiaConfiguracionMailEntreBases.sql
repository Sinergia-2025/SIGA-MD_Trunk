MERGE INTO Parametros AS P
      USING (SELECT *
               FROM SIGA_HAR.dbo.Parametros
              WHERE IdParametro IN ('MAILDIRECCION','MAILPASSWORD','MAILPUERTOSALIDA','MAILREQUIEREAUTENTICACION','MAILREQUIERESSL','MAILSERVIDOR','MAILUSUARIO',
                                    'CANTEMAILSPORMINUTO','CANTEMAILSPORHORA')) AS PT
         ON P.IdParametro = PT.IdParametro
 WHEN MATCHED THEN
    UPDATE
       SET P.ValorParametro = PT.ValorParametro
 WHEN NOT MATCHED THEN
    INSERT (   IdParametro,    ValorParametro,    CategoriaParametro,    DescripcionParametro)
    VALUES (PT.IdParametro, PT.ValorParametro, PT.CategoriaParametro, PT.DescripcionParametro);

SELECT ValorParametro FROM Parametros WHERE IdParametro IN ('MAILDIRECCION','MAILPASSWORD','MAILPUERTOSALIDA','MAILREQUIEREAUTENTICACION','MAILREQUIERESSL','MAILSERVIDOR','MAILUSUARIO',
                                                            'CANTEMAILSPORMINUTO','CANTEMAILSPORHORA');
