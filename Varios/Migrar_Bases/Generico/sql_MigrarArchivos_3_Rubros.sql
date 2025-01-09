 
SELECT COUNT(*) FROM Rubros
GO
  
MERGE INTO Rubros AS P
     USING MO_SIGA.dbo.Rubros AS PT
        ON P.IdRubro = PT.IdRubro
 WHEN NOT MATCHED THEN
    INSERT (   IdRubro
	  ,[NombreRubro]
      ,[IdProvincia]
      ,[IdActividad]
      ,[ComisionPorVenta]
      ,[UnidHasta1]
      ,[UnidHasta2]
      ,[UnidHasta3]
      ,[UnidHasta4]
      ,[UnidHasta5]
      ,[UHPorc1]
      ,[UHPorc2]
      ,[UHPorc3]
      ,[UHPorc4]
      ,[UHPorc5]
      ,[FechaActualizacionWeb]
	  )
    VALUES (PT.IdRubro
	  ,PT.[NombreRubro]
      ,NULL 
      ,NULL 
      ,0 
      ,0
      ,0 
      ,0 
      ,0 
      ,0 
      ,0 
      ,0 
      ,0 
      ,0 
      ,0 
      ,GETDATE()
	  )
;


SELECT COUNT(*) FROM Rubros
GO

SELECT * FROM Rubros
GO
