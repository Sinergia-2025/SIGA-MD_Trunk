

----------------------------------------------------

PRINT '99. Inserto Tabla VENTASCHEQUES Blanco (a Sucursal = 1)'
GO

-- SE NECESITAN LOS CHEQUES!!

--INSERT INTO [SIGA].[dbo].[VentasCheques]
--           ([IdSucursal]
--           ,[IdTipoComprobante]
--           ,[Letra]
--           ,[CentroEmisor]
--           ,[NumeroComprobante]
--           ,[NumeroCheque]
--           ,[IdBanco]
--           ,[IdBancoSucursal]
--           ,[IdLocalidad])
--SELECT [IdSucursal]
--      ,[IdTipoComprobante]
--      ,[Letra]
--      ,[CentroEmisor]
--      ,[NumeroComprobante]
--      ,[NumeroCheque]
--      ,[IdBanco]
--      ,[IdBancoSucursal]
--      ,[IdLocalidad]
--  FROM [SIGA_A_2015].[dbo].[VentasCheques] VC
-- WHERE EXISTS 
--     ( SELECT * FROM SIGA.dbo.Ventas V
--       WHERE V.IdSucursal = VC.IdSucursal
--         AND V.IdTipoComprobante = VC.IdTipoComprobante
--         AND V.Letra = VC.Letra
--         AND V.CentroEmisor = VC.CentroEmisor
--         AND V.NumeroComprobante = VC.NumeroComprobante
--         AND V.IdSucursal = 1
--     )
--GO


-- SE NECESITAN LOS CHEQUES!!

--INSERT INTO [SIGA].[dbo].[VentasCheques]
--           ([IdSucursal]
--           ,[IdTipoComprobante]
--           ,[Letra]
--           ,[CentroEmisor]
--           ,[NumeroComprobante]
--           ,[NumeroCheque]
--           ,[IdBanco]
--           ,[IdBancoSucursal]
--           ,[IdLocalidad])
--SELECT 3 AS [XXIdSucursal]
--      ,[IdTipoComprobante]
--      ,[Letra]
--      ,[CentroEmisor]
--      ,[NumeroComprobante]
--      ,[NumeroCheque]
--      ,[IdBanco]
--      ,[IdBancoSucursal]
--      ,[IdLocalidad]
--  FROM [SIGA_A_2015].[dbo].[VentasCheques] VC
-- WHERE EXISTS 
--     ( SELECT * FROM SIGA.dbo.Ventas V
--       WHERE 1 = VC.IdSucursal
--         AND V.IdTipoComprobante = VC.IdTipoComprobante
--         AND V.Letra = VC.Letra
--         AND V.CentroEmisor = VC.CentroEmisor
--         AND V.NumeroComprobante = VC.NumeroComprobante
--         AND V.IdSucursal = 3
--     )
--GO
