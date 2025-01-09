IF dbo.SoyHAR() = 1
BEGIN
    UPDATE NS
       SET IdTipoComentarioNovedad = 1
      FROM CRMNovedadesSeguimiento NS
     INNER JOIN CRMNovedades N ON N.IdTipoNovedad = NS.IdTipoNovedad
                              AND N.Letra = NS.Letra
                              AND N.CentroEmisor = NS.CentroEmisor
                              AND N.IdNovedad = NS.IdNovedad
     INNER JOIN CRMMetodosResolucionesNovedades M ON M.IdMetodoResolucionNovedad = N.IdMetodoResolucionNovedad
     WHERE NS.IdTipoNovedad = 'PENDIENTE'
       AND NS.IdTipoComentarioNovedad = 101
END
