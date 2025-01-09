INSERT INTO SIGA.dbo.Funciones
           ([Id]
           ,[Nombre]
           ,[Descripcion]
           ,[EsMenu]
           ,[EsBoton]
           ,[Enabled]
           ,[Visible]
           ,[IdPadre]
           ,[Posicion]
           ,[Archivo]
           ,[Pantalla]
           ,[Icono]
           ,[Parametros])
SELECT [Id]
      ,[Nombre]
      ,[Descripcion]
      ,[EsMenu]
      ,[EsBoton]
      ,[Enabled]
      ,[Visible]
      ,[IdPadre]
      ,[Posicion]
      ,'SICAP' AS [xArchivo]
      ,[Pantalla]
      ,[Icono]
      ,NULL AS [xParametros]
  FROM SICAP.dbo.Funciones A
  WHERE A.Id IN
     ( SELECT F.Id FROM SIGA.dbo.Funciones F
--        WHERE F.Id = A.Id
--        WHERE CONVERT(varchar(15), F.Id) = CONVERT(varchar(15), A.Id)
     )
GO
