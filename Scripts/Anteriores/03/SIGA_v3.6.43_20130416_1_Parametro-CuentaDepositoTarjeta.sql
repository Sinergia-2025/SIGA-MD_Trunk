
INSERT INTO [CuentasBancos]
           ([IdCuentaBanco]
           ,[NombreCuentaBanco]
           ,[IdTipoCuenta]
           ,[EsPosdatado]
           ,[PideCheque])
     VALUES
           (7
           ,'Deposito de Tarjetas'
           ,'I'
           ,0
           ,0)
GO


INSERT INTO Parametros 
  (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
 VALUES
  ('CTABANCOACREDTARJETA', 7, NULL, 'Define la Cuenta de Acreditación de Tarjetas')
GO
