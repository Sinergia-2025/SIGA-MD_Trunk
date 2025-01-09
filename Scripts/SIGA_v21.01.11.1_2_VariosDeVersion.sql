UPDATE N
   SET FechaEntregado = AN.FechaEntregado
     , IdEstadoNovedadEntregado = AN.IdEstadoNovedadEntregado
  FROM CRMNovedades N
 INNER JOIN (SELECT AN.IdTipoNovedad, AN.Letra, AN.CentroEmisor, AN.IdNovedad, AN.FechaAuditoria FechaEntregado, an.IdEstadoNovedad IdEstadoNovedadEntregado
               FROM (
                     SELECT AN.IdTipoNovedad, AN.Letra, AN.CentroEmisor, AN.IdNovedad, MIN(AN.FechaAuditoria) FechaEntregado
                       FROM AuditoriaCRMNovedades AN
                      INNER JOIN CRMEstadosNovedades E ON E.IdEstadoNovedad = AN.IdEstadoNovedad
                      WHERE E.Entregado = 'Graba'
                      GROUP BY AN.IdTipoNovedad, AN.Letra, AN.CentroEmisor, AN.IdNovedad
                    ) AN1
             INNER JOIN AuditoriaCRMNovedades AN ON AN.IdTipoNovedad = AN1.IdTipoNovedad
                                                AND AN.Letra = AN1.Letra
                                                AND AN.CentroEmisor = AN1.CentroEmisor
                                                AND AN.IdNovedad = AN1.IdNovedad
                                                AND AN.FechaAuditoria = AN1.FechaEntregado) AN
         ON N.IdTipoNovedad = AN.IdTipoNovedad
        AND N.Letra = AN.Letra
        AND N.CentroEmisor = AN.CentroEmisor
        AND N.IdNovedad = AN.IdNovedad

UPDATE N
   SET FechaFinalizado = AN.FechaEntregado
     , IdEstadoNovedadEntregado = AN.IdEstadoNovedadEntregado
  FROM CRMNovedades N
 INNER JOIN (SELECT AN.IdTipoNovedad, AN.Letra, AN.CentroEmisor, AN.IdNovedad, AN.FechaAuditoria FechaEntregado, an.IdEstadoNovedad IdEstadoNovedadEntregado
               FROM (
                     SELECT AN.IdTipoNovedad, AN.Letra, AN.CentroEmisor, AN.IdNovedad, MIN(AN.FechaAuditoria) FechaEntregado
                       FROM AuditoriaCRMNovedades AN
                      INNER JOIN CRMEstadosNovedades E ON E.IdEstadoNovedad = AN.IdEstadoNovedad
                      WHERE E.Finalizado = 'True'
                      GROUP BY AN.IdTipoNovedad, AN.Letra, AN.CentroEmisor, AN.IdNovedad
                    ) AN1
             INNER JOIN AuditoriaCRMNovedades AN ON AN.IdTipoNovedad = AN1.IdTipoNovedad
                                                AND AN.Letra = AN1.Letra
                                                AND AN.CentroEmisor = AN1.CentroEmisor
                                                AND AN.IdNovedad = AN1.IdNovedad
                                                AND AN.FechaAuditoria = AN1.FechaEntregado) AN
         ON N.IdTipoNovedad = AN.IdTipoNovedad
        AND N.Letra = AN.Letra
        AND N.CentroEmisor = AN.CentroEmisor
        AND N.IdNovedad = AN.IdNovedad

UPDATE N
   SET FechaEntregado = FechaEstadoNovedad
  FROM CRMNovedades N
 INNER JOIN CRMEstadosNovedades E ON E.IdEstadoNovedad = N.IdEstadoNovedad
 WHERE E.Finalizado = 'True'
   AND N.IdTipoNovedad <> 'ACTIVIDAD'
   AND N.FechaEntregado IS NULL

