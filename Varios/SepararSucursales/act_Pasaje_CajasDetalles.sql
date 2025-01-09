INSERT INTO [SIGA].[dbo].[CajasDetalle]
           ([IdSucursal]
           ,[IdCaja]
           ,[NumeroPlanilla]
           ,[NumeroMovimiento]
           ,[FechaMovimiento]
           ,[IdCuentaCaja]
           ,[IdTipoMovimiento]
           ,[ImportePesos]
           ,[ImporteDolares]
           ,[ImporteEuros]
           ,[ImporteCheques]
           ,[ImporteTarjetas]
           ,[Observacion]
           ,[EsModificable]
           ,[ImporteTickets]
           ,[IdUsuario]
           ,[IdAsiento]
           ,[ImporteBancos]
           ,[ImporteRetenciones]
           ,[IdPlanCuenta])
SELECT [IdSucursal]
      ,[IdCaja]
      ,[NumeroPlanilla]
      ,[NumeroMovimiento]
      ,[FechaMovimiento]
      ,[IdCuentaCaja]
      ,[IdTipoMovimiento]
      ,[ImportePesos]
      ,[ImporteDolares]
      ,[ImporteEuros]
      ,[ImporteCheques]
      ,[ImporteTarjetas]
      ,[Observacion]
      ,[EsModificable]
      ,[ImporteTickets]
      ,[IdUsuario]
      ,[IdAsiento]
      ,[ImporteBancos]
      ,[ImporteRetenciones]
      ,[IdPlanCuenta]
  FROM SIGA_A_2015.dbo.CajasDetalle A
  WHERE NOT EXISTS 
     ( SELECT * FROM SIGA.dbo.CajasDetalle CD
       WHERE CD.IdSucursal = A.IdSucursal
         AND CD.IdCaja = A.IdCaja
         AND CD.NumeroPlanilla = A.NumeroPlanilla
         AND CD.NumeroMovimiento = A.NumeroMovimiento
     )
    AND CONVERT(varchar(11), FechaMovimiento, 120) >= '2015-05-01'
GO
