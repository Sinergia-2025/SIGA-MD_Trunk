
SELECT TOP (1000) [IdFuncion]
      ,[IdTipoLink]
      ,[Orden]
      ,[Link]
      ,[Descripcion]
  FROM [SIGA].[dbo].[FuncionesDocumentos]
--    where link LIKE '%Server02\Sinergia\Documentacion%'


UPDATE [SIGA].[dbo].[FuncionesDocumentos]
 SET [Link] =  REPLACE(Link, 'Server02\Sinergia\Documentacion', 'Server02\compartidos\Sinergia\Documentacion')
  where link LIKE '%Server02\Sinergia\Documentacion%'
GO


\\Server02\compartidos\Sinergia\Documentacion
