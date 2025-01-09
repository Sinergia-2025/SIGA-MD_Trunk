
INSERT INTO [dbo].[CargosClientesObservaciones]
           ([IdSucursal]
           ,[IdCliente]
           ,[Linea]
           ,[Observacion]
           ,[IdTipoLiquidacion])
SELECT [IdSucursal]
           ,[IdCliente]
           ,[Linea]
           ,[Observacion]
           ,[IdTipoLiquidacion]
  FROM [LiquidacionesObservaciones]
   where PeriodoLiquidacion ='201811'
  and IdSucursal=1
