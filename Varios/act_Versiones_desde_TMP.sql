
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
      'SIGA'
	  ,lTRIM(NroVersion)
      ,MAX(VersionFech)
      ,NULL AS IdAplicacionBase
      ,NULL AS NroVersionAplicacionBase
      ,'4.0' AS VersionFramework
      ,'10' AS VersionReportViewer
      ,'VB.NET 2013' AS VersionLenguaje
  FROM SIGA.dbo.Versiones_TMP
  GROUP BY NroVersion
GO
