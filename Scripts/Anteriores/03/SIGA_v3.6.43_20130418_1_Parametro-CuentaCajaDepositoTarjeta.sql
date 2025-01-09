
INSERT INTO [CuentasDeCajas]
           ([IdCuentaCaja]
           ,[NombreCuentaCaja]
           ,[IdTipoCuenta]
           ,[EsPosdatado]
           ,[PideCheque]
           ,[IdGrupoCuenta]
           ,[IdCuentaDebe]
           ,[IdCuentaHaber])
     VALUES
           (8
           ,'Depósito de Tarjetas'
           ,'E'
           ,'False'
           ,'False'
           ,1
           ,NULL
           ,NULL)


INSERT INTO Parametros 
  (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
 VALUES
  ('CTACAJADEPOSITOTARJETAS', 8, NULL, 'Define la Cuenta de Acreditación de Tarjetas')
GO
