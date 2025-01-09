
INSERT INTO Versiones
           (IdAplicacion
           ,NroVersion
           ,VersionFecha
           ,IdAplicacionBase
           ,NroVersionAplicacionBase
           ,VersionFramework
           ,VersionReportViewer
           ,VersionLenguaje)
SELECT distinct 
       IdSistema
	  ,[Version]
	  ,MAX(VersionFecha)
      ,NULL AS IdAplicacionBase
      ,NULL AS NroVersionAplicacionBase
      ,'4.0' AS VersionFramework
      ,'10' AS VersionReportViewer
      ,'VB.NET 2013' AS VersionLenguaje
  FROM CRMNovedades
 WHERE IdSistema = 'SIGA'
--   AND IdTipoNovedad = 'PENDIENTE'
   AND [Version] IS NOT NULL
   AND [Version] > '03'
   AND NOT EXISTS 
     (SELECT * FROM Versiones V
	    WHERE V.IdAplicacion = CRMNovedades.IdSistema
          AND V.NroVersion = CRMNovedades.[Version])
 GROUP BY IdSistema, [Version]
GO
