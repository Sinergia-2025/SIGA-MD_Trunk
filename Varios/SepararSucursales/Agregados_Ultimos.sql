--INSERT INTO [SIGA].[dbo].[CajasDetalle]
--           ([IdSucursal]
--           ,[IdCaja]
--           ,[NumeroPlanilla]
--           ,[NumeroMovimiento]
--           ,[FechaMovimiento]
--           ,[IdCuentaCaja]
--           ,[IdTipoMovimiento]
--           ,[ImportePesos]
--           ,[ImporteDolares]
--           ,[ImporteEuros]
--           ,[ImporteCheques]
--           ,[ImporteTarjetas]
--           ,[Observacion]
--           ,[EsModificable]
--           ,[ImporteTickets]
--           ,[IdUsuario]
--           ,[PeriodoContable]
--           ,[ImporteBancos])
           
SELECT B.NombreCuentaCaja
      ,[IdSucursal]
      ,[IdCaja]
      ,[NumeroPlanilla]
      ,[NumeroMovimiento]
      ,[FechaMovimiento]
      ,a.IdCuentaCaja
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
  FROM SIGA_A_2015.dbo.CajasDetalle A, SIGA_A_2015.dbo.CuentasDeCajas B
  WHERE A.IdCuentaCaja = B.IdCuentaCaja
    AND A.IdCuentaCaja NOT IN (1,2,3,4,5,6,7,8,9)
    AND A.IdCuentaCaja NOT IN (83, 76, 11, 47, 44, 110, 98, 72)
    AND A.IdCuentaCaja NOT IN (20, 114, 30, 112, 125, 118, 113)
    AND A.IdCuentaCaja NOT IN (94, 92, 93, 36, 95, 37, 35)
    AND NOT EXISTS 
     ( SELECT * FROM SIGA.dbo.CajasDetalle CD
       WHERE CD.IdSucursal = A.IdSucursal
         AND CD.IdCaja = A.IdCaja
         AND CD.NumeroPlanilla = A.NumeroPlanilla
         AND CD.NumeroMovimiento = A.NumeroMovimiento
     )
    AND CONVERT(varchar(11), FechaMovimiento, 120) >= '2015-05-01'
    AND A.IdCuentaCaja NOT IN (39, 122, 52, 51, 131, 48, 50, 101, 102, 103, 104, 105, 106, 67, 70, 56, 66, 42, 63, 129, 34, 99, 10, 96, 97, 126, 88, 78, 79, 80)

 order by b.NombreCuentaCaja desc
GO
