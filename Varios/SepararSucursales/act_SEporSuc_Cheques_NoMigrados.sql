 
SELECT [IdSucursal]
      ,[IdTipoComprobante]
      ,[Letra]
      ,[CentroEmisor]
      ,[NumeroComprobante]
      ,[NumeroCheque]
      ,[IdBanco]
      ,[IdBancoSucursal]
      ,[IdLocalidad]
      ,[IdProveedor]
  FROM [SIGA_A_2015].[dbo].[CuentasCorrientesProvCheques] CCH
   WHERE not EXISTS 
     ( SELECT * FROM SIGA.dbo.CuentasCorrientesProv CCP
       WHERE CCP.IdSucursal = CCH.IdSucursal
         AND CCP.IdTipoComprobante = CCH.IdTipoComprobante
         AND CCP.Letra = CCH.Letra
         AND CCP.CentroEmisor = CCH.CentroEmisor
         AND CCP.NumeroComprobante = CCH.NumeroComprobante
         AND CCP.IdProveedor = CCH.IdProveedor
     )
GO


