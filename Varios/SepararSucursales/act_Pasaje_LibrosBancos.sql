INSERT INTO [SIGA].[dbo].[LibrosBancos]
           ([IdSucursal]
           ,[IdCuentaBancaria]
           ,[NumeroMovimiento]
           ,[IdCuentaBanco]
           ,[IdTipoMovimiento]
           ,[Importe]
           ,[FechaMovimiento]
           ,[FechaAplicado]
           ,[Observacion]
           ,[Conciliado]
           ,[NumeroCheque]
           ,[IdBancoCheque]
           ,[IdBancoSucursalCheque]
           ,[IdLocalidadCheque]
           ,[IdAsiento]
           ,[IdPlanCuenta]
           ,[EsModificable])
SELECT [IdSucursal]
      ,[IdCuentaBancaria]
      ,[NumeroMovimiento]
      ,[IdCuentaBanco]
      ,[IdTipoMovimiento]
      ,[Importe]
      ,[FechaMovimiento]
      ,[FechaAplicado]
      ,[Observacion]
      ,[Conciliado]
      ,[NumeroCheque]
      ,[IdBancoCheque]
      ,[IdBancoSucursalCheque]
      ,[IdLocalidadCheque]
      ,[IdAsiento]
      ,[IdPlanCuenta]
      ,[EsModificable]
  FROM SIGA_A_2015.dbo.[LibrosBancos] A
  WHERE NOT EXISTS 
     ( SELECT * FROM SIGA.dbo.LibrosBancos LB
       WHERE LB.IdSucursal = A.IdSucursal
         AND LB.IdCuentaBancaria = A.IdCuentaBancaria
         AND LB.NumeroMovimiento = A.NumeroMovimiento
     )
    AND (CONVERT(varchar(11), FechaMovimiento, 120) >= '2015-05-01'
         OR CONVERT(varchar(11), FechaAplicado, 120) >= '2015-05-01')
GO
    