IF EXISTS(SELECT * FROM CRMTiposNovedades N WHERE IdTipoNovedad = 'SERVICE')
BEGIN
    PRINT ''
    PRINT '1. Agregar nuevos tipos de estados de Servicio Técnico'
    INSERT INTO dbo.CRMTiposEstadosNovedades (IdTipoEstadoNovedad,NombreTipoEstadoNovedad,Posicion,IdTipoNovedad)
         VALUES (101, 'NUEVO',      10, 'SERVICE'),
                (102, 'EN PROCESO', 20, 'SERVICE'),
                (103, 'FINALIZADO', 30, 'SERVICE'),
                (104, 'CANCELADO',  40, 'SERVICE')

    PRINT ''
    PRINT '2. Normalizar los estados de Servicio Técnico'
    MERGE INTO CRMEstadosNovedades AS D
        USING (SELECT 160 IdEstadoNovedad, 'ALTA'           NombreEstadoNovedad, 101 IdTipoEstadoNovedad,  10 Posicion, 'False' Finalizado, 'True'  PorDefecto, 'NoAfecta'  Entregado, 'False' Facturable UNION ALL
               SELECT 151 IdEstadoNovedad, 'INGRESADO'      NombreEstadoNovedad, 101 IdTipoEstadoNovedad,  20 Posicion, 'False' Finalizado, 'False' PorDefecto, 'NoAfecta'  Entregado, 'False' Facturable UNION ALL
               SELECT 130 IdEstadoNovedad, 'PRESUPUESTADO'  NombreEstadoNovedad, 102 IdTipoEstadoNovedad,  30 Posicion, 'False' Finalizado, 'False' PorDefecto, 'NoAfecta'  Entregado, 'False' Facturable UNION ALL
               SELECT 162 IdEstadoNovedad, 'A REPARAR'      NombreEstadoNovedad, 102 IdTipoEstadoNovedad,  40 Posicion, 'False' Finalizado, 'False' PorDefecto, 'NoAfecta'  Entregado, 'False' Facturable UNION ALL
               SELECT 125 IdEstadoNovedad, 'TRABAJANDO'     NombreEstadoNovedad, 102 IdTipoEstadoNovedad,  50 Posicion, 'False' Finalizado, 'False' PorDefecto, 'Limpia'    Entregado, 'False' Facturable UNION ALL
               SELECT 161 IdEstadoNovedad, 'REPARADO'       NombreEstadoNovedad, 103 IdTipoEstadoNovedad,  60 Posicion, 'False' Finalizado, 'False' PorDefecto, 'Graba'     Entregado, 'False' Facturable UNION ALL
               SELECT 140 IdEstadoNovedad, 'NO REPARADO'    NombreEstadoNovedad, 103 IdTipoEstadoNovedad,  70 Posicion, 'False' Finalizado, 'False' PorDefecto, 'Graba'     Entregado, 'False' Facturable UNION ALL
               SELECT 150 IdEstadoNovedad, 'ENTREGADO'      NombreEstadoNovedad, 103 IdTipoEstadoNovedad,  80 Posicion, 'True'  Finalizado, 'False' PorDefecto, 'Graba'     Entregado, 'True'  Facturable UNION ALL
               SELECT 170 IdEstadoNovedad, 'PAUSA CLIENTE'  NombreEstadoNovedad, 102 IdTipoEstadoNovedad,  90 Posicion, 'False' Finalizado, 'False' PorDefecto, 'NoAfecta'  Entregado, 'False' Facturable UNION ALL
               SELECT 171 IdEstadoNovedad, 'PAUSA EMPRESA'  NombreEstadoNovedad, 102 IdTipoEstadoNovedad, 100 Posicion, 'False' Finalizado, 'False' PorDefecto, 'NoAfecta'  Entregado, 'False' Facturable UNION ALL
               SELECT 172 IdEstadoNovedad, 'CANCELADO'      NombreEstadoNovedad, 104 IdTipoEstadoNovedad, 110 Posicion, 'False' Finalizado, 'False' PorDefecto, 'Graba'     Entregado, 'False' Facturable) AS O ON O.IdEstadoNovedad = D.IdEstadoNovedad
        WHEN MATCHED THEN
            UPDATE SET D.NombreEstadoNovedad    = O.NombreEstadoNovedad
                     , D.IdTipoEstadoNovedad    = O.IdTipoEstadoNovedad
                     , D.Posicion               = O.Posicion
                     , D.Finalizado             = O.Finalizado
                     , D.PorDefecto             = O.PorDefecto
                     , D.Entregado              = O.Entregado
        WHEN NOT MATCHED THEN 
            INSERT (IdEstadoNovedad, NombreEstadoNovedad, Posicion, SolicitaUsuario, Finalizado, IdTipoNovedad, PorDefecto, Color, DiasProximoContacto, ActualizaUsuarioResponsable,
                    SolicitaProveedorService, Imprime, Reporte, Embebido, AcumulaContador1, AcumulaContador2, EsFacturable, CantidadCopias, IdTipoEstadoNovedad, Entregado)
            VALUES (O.IdEstadoNovedad, O.NombreEstadoNovedad, O.Posicion, 'True', O.Finalizado, 'SERVICE', O.PorDefecto, NULL, 0, 'False',
                    'False', 'False', '', 'False', 'False', 'False', O.Facturable, 1, O.IdTipoEstadoNovedad, O.Entregado)
    ;
    PRINT ''
    PRINT '3.1. Eliminar los estados de servicio técnico que no deben existir'
    DELETE CRMEstadosNovedades WHERE IdEstadoNovedad IN (100, 110, 120);
    PRINT ''
    PRINT '3.2. Eliminar los tipos de estados de servicio técnico viejos'
    DELETE CRMTiposEstadosNovedades WHERE IdTipoNovedad = 'SERVICE' AND IdTipoEstadoNovedad < 100


    PRINT ''
    PRINT '4. Tabla CRMNovedades: Reseteo los campos de Entregado y Finalizado cargados hasta ahora para normalizar'
    UPDATE CRMNovedades
       SET FechaEntregado = NULL
         , IdEstadoNovedadEntregado = NULL
         , IdUsuarioEntregado = NULL
         , FechaFinalizado = NULL
         , IdEstadoNovedadFinalizado = NULL
         , IdUsuarioFinalizado = NULL

    PRINT ''
    PRINT '4.1. Tabla CRMNovedades: Determinar Entregado a partir de AuditoriaCRMNovedades'
    UPDATE N
       SET FechaEntregado = AN.FechaEntregado
         , IdEstadoNovedadEntregado = AN.IdEstadoNovedadEntregado
         , IdUsuarioEntregado = ISNULL(AN.IdUsuarioResponsable, AN.IdUsuarioAsignado)
      FROM CRMNovedades N
     INNER JOIN (SELECT AN.IdTipoNovedad, AN.Letra, AN.CentroEmisor, AN.IdNovedad, AN.FechaAuditoria FechaEntregado, an.IdEstadoNovedad IdEstadoNovedadEntregado
                      , AN.UsuarioAuditoria, AN.IdUsuarioAsignado, AN.IdUsuarioResponsable
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


    PRINT ''
    PRINT '4.2. Tabla CRMNovedades: Determinar Finalizado a partir de AuditoriaCRMNovedades'
    UPDATE N
       SET FechaFinalizado = AN.FechaEntregado
         , IdEstadoNovedadFinalizado = AN.IdEstadoNovedadEntregado
         , IdUsuarioFinalizado = AN.IdUsuarioAsignado
      FROM CRMNovedades N
     INNER JOIN (SELECT AN.IdTipoNovedad, AN.Letra, AN.CentroEmisor, AN.IdNovedad, AN.FechaAuditoria FechaEntregado, an.IdEstadoNovedad IdEstadoNovedadEntregado
                      , AN.UsuarioAuditoria, AN.IdUsuarioAsignado
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

    PRINT ''
    PRINT '4.3. Tabla CRMNovedades: Determinar Entregado de registros que no se pudo determinar previamente poniendo el valor de Finalizado'
    UPDATE N
       SET FechaEntregado = FechaEstadoNovedad
         , IdEstadoNovedadEntregado = N.IdEstadoNovedad
         , IdUsuarioEntregado = IdUsuarioAsignado
      FROM CRMNovedades N
     INNER JOIN CRMEstadosNovedades E ON E.IdEstadoNovedad = N.IdEstadoNovedad
     WHERE E.Finalizado = 'True'
       AND N.IdTipoNovedad <> 'ACTIVIDAD'
       AND N.FechaEntregado IS NULL
END
ELSE
BEGIN
    PRINT 'No tiene Service Instalado'
END