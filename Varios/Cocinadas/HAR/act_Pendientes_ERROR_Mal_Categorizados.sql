
SELECT CAT.NombreCategoriaNovedad, Nov.* 
  FROM CRMNovedades Nov
 INNER JOIN CRMCategoriasNovedades Cat ON Cat.IdCategoriaNovedad = Nov.IdCategoriaNovedad
 WHERE Nov.IdTipoNovedad = 'PENDIENTE'
   AND Nov.Descripcion LIKE '%ERROR%'
   AND CAT.NombreCategoriaNovedad NOT IN ('ERROR', 'ERROR ND', 'ERROR PUBLICO', 'INTERNO', 'NO APLICA')
 ORDER BY CAT.NombreCategoriaNovedad
GO

SELECT * FROM CRMCategoriasNovedades
 WHERE IdTipoNovedad = 'PENDIENTE'
   AND NombreCategoriaNovedad IN ('ERROR','MEJORA','PROYECTO')
GO

SELECT * FROM CRMNovedades
 WHERE IdTipoNovedad = 'PENDIENTE'
   AND Descripcion LIKE '%ERROR%'
   AND IdCategoriaNovedad IN (401, 402)
GO

UPDATE CRMNovedades
   SET IdCategoriaNovedad = 403
 WHERE IdTipoNovedad = 'PENDIENTE'
   AND Descripcion LIKE '%ERROR%'
   AND IdCategoriaNovedad IN (401, 402)
GO
