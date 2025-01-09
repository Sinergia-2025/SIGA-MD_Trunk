
INSERT INTO [dbo].[CargosClientes]
           ([IdCliente]
           ,[IdCargo]
           ,[IdSucursal]
           ,[Monto]
           ,[Cantidad]
           ,[Observacion]
           ,[IdTipoLiquidacion]
           ,[PrecioLista]
           ,[DescuentoRecargoPorc1]
           ,[DescuentoRecargoPorc2]
           ,[DescuentoRecargoPorcGral])
SELECT [IdCliente]
           ,[IdCargo]
           ,[IdSucursal]
           ,Importe
           ,[CantidadAdicional]
           ,[Observacion]
           ,[IdTipoLiquidacion]
           ,[PrecioLista]
           ,[DescuentoRecargoPorc1]
           ,[DescuentoRecargoPorc2]
           ,[DescuentoRecargoPorcGral]
  FROM [SIGA].[dbo].[LiquidacionesDetallesClientes]
  where PeriodoLiquidacion ='201811'
  and IdSucursal=1