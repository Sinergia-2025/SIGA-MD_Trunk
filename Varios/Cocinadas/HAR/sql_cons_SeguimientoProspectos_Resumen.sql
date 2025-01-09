
SELECT LEFT(CONVERT(DATE, NS.FechaSeguimiento),7) AS Periodo
--      , CONVERT(DATE, NS.FechaSeguimiento) AS FechaSeguimiento_Fecha
      , N.IdSistema
      ,  CN.NombreCategoriaNovedad
      , EN.NombreEstadoNovedad
      , (CASE WHEN EN.Finalizado = 'True' THEN 'SI' ELSE 'NO' END) AS Finalizado
      , COUNT(N.IdSistema)
  FROM CRMNovedades AS N
 INNER JOIN CRMNovedadesSeguimiento AS NS ON NS.IdTipoNovedad = N.IdTipoNovedad and NS.IdNovedad = N.IDNovedad
--  LEFT JOIN CRMPrioridadesNovedades AS PN ON PN.IdPrioridadNovedad = N.IdPrioridadNovedad
  LEFT JOIN CRMCategoriasNovedades AS CN ON CN.IdCategoriaNovedad = N.IdCategoriaNovedad
  LEFT JOIN CRMEstadosNovedades AS EN ON EN.IdEstadoNovedad = NS.IdEstadoNovedad
 WHERE N.IdTipoNovedad = 'PROSP'
  AND NS.FechaSeguimiento >= '19000507 00:00:00'
  AND NS.FechaSeguimiento <= '20210507 23:59:59'
  AND NS.EsComentario = 1
--  and N.IdNovedad = 1192
 GROUP BY LEFT(CONVERT(DATE, NS.FechaSeguimiento),7)
      , N.IdSistema
      ,  CN.NombreCategoriaNovedad
      , EN.NombreEstadoNovedad
      , EN.Finalizado 
