
-- recibos BLANCOS Y NEGROS JUNTOS !

SELECT * from [SIGA_A_2015].[dbo].[CuentasCorrientesPagos] CCP
 WHERE NOT EXISTS 
  (SELECT *
     FROM [SIGA].[dbo].[CuentasCorrientesPagos] CC
       WHERE CCP.IdTipoComprobante = CC.IdTipoComprobante
         AND CCP.Letra = CC.Letra
         AND CCP.CentroEmisor = CC.CentroEmisor
         AND CCP.NumeroComprobante = CC.NumeroComprobante
         AND CCP.CuotaNumero = CC.CuotaNumero
     )
  --AND IdTipoComprobante2 <>'ANTICIPO'
 order by NumeroComprobante, CuotaNumero


SELECT [IdSucursal]
      ,[IdTipoComprobante]
      ,[Letra]
      ,[CentroEmisor]
      ,[NumeroComprobante]
      ,[CuotaNumero]
      ,[Fecha]
      ,[FechaVencimiento]
      ,[ImporteCuota]
      ,[SaldoCuota]
      ,[IdFormasPago]
      ,[Observacion]
      ,[IdTipoComprobante2]
      ,[NumeroComprobante2]
      ,[CentroEmisor2]
      ,[CuotaNumero2]
      ,[Letra2]
      ,[DescuentoRecargo]
      ,[DescuentoRecargoPorc]
  FROM [SIGA].[dbo].[CuentasCorrientesPagos]
 where IdTipoComprobante='RECIBO'
   AND Letra='X'
   AND NumeroComprobante IN
(   
SELECT NumeroComprobante from [SIGA_A_2015].[dbo].[CuentasCorrientesPagos] CCP
 WHERE NOT EXISTS 
  (SELECT *
     FROM [SIGA].[dbo].[CuentasCorrientesPagos] CC
       WHERE CCP.IdTipoComprobante = CC.IdTipoComprobante
         AND CCP.Letra = CC.Letra
         AND CCP.CentroEmisor = CC.CentroEmisor
         AND CCP.NumeroComprobante = CC.NumeroComprobante
         AND CCP.CuotaNumero = CC.CuotaNumero
     )
--  AND IdTipoComprobante2 <>'ANTICIPO'
)
  order by NumeroComprobante, CuotaNumero
GO
