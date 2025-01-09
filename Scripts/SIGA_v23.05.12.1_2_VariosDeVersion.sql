IF dbo.SoyHAR() = 1
BEGIN
INSERT [dbo].[AlertasSistema] ([IdAlertaSistema], [TituloAlerta], [ConsultaAlerta], [PermisosCondicion], [IdFuncionClick], [ParametrosPantalla], [UtilizaConsultaGenerica]) VALUES (3, N'Tickets sin Pendientes', N'SELECT N.IdTipoNovedad, N.Letra, N.CentroEmisor, N.IdNovedad, N.FechaNovedad, N.FechaEstadoNovedad, N.NombreCategoriaNovedad, N.NombreEstadoNovedad
     , N_ALL.IdTipoNovedad IdTipoNovedad_Pendiente, N_ALL.Letra Letra_Pendiente, N_ALL.CentroEmisor CentroEmisor_Pendiente, N_ALL.IdNovedad IdNovedad_Pendiente
     , EN_ALL.NombreEstadoNovedad NombreEstadoNovedad_Pendiente, MRN_ALL.NombreMetodoResolucionNovedad NombreMetodoResolucionNovedad_Pendiente
  FROM (

----
SELECT N.IdTipoNovedad, N.Letra, N.CentroEmisor, N.IdNovedad, N.FechaNovedad, N.FechaEstadoNovedad, CN.NombreCategoriaNovedad, EN.NombreEstadoNovedad
     , N_A.IdTipoNovedad IdTipoNovedad_A, N_A.Letra Letra_A, N_A.CentroEmisor CentroEmisor_A, N_A.IdNovedad IdNovedad_A, N_A.NombreEstadoNovedad NombreEstadoNovedad_A, N_A.NombreCategoriaNovedad NombreCategoriaNovedad_A
     , N_D.IdTipoNovedad IdTipoNovedad_D, N_D.Letra Letra_D, N_D.CentroEmisor CentroEmisor_D, N_D.IdNovedad IdNovedad_D, N_D.NombreEstadoNovedad NombreEstadoNovedad_D, N_D.NombreCategoriaNovedad NombreCategoriaNovedad_D
     , N_O.IdTipoNovedad IdTipoNovedad_O, N_O.Letra Letra_O, N_O.CentroEmisor CentroEmisor_O, N_O.IdNovedad IdNovedad_O, N_O.NombreEstadoNovedad NombreEstadoNovedad_O, N_O.NombreCategoriaNovedad NombreCategoriaNovedad_O
  FROM CRMNovedades N
  INNER JOIN CRMEstadosNovedades EN ON EN.IdEstadoNovedad = N.IdEstadoNovedad
  INNER JOIN CRMCategoriasNovedades CN ON CN.IdCategoriaNovedad = N.IdCategoriaNovedad
  LEFT JOIN (SELECT MRN.NombreMetodoResolucionNovedad, EN_A.NombreEstadoNovedad, CN_A.NombreCategoriaNovedad, N_A.*
              FROM CRMNovedades N_A
              INNER JOIN CRMEstadosNovedades EN_A ON EN_A.IdEstadoNovedad = N_A.IdEstadoNovedad
              INNER JOIN CRMCategoriasNovedades CN_A ON CN_A.IdCategoriaNovedad = N_A.IdCategoriaNovedad
              INNER JOIN CRMMetodosResolucionesNovedades MRN ON MRN.IdMetodoResolucionNovedad = N_A.IdMetodoResolucionNovedad
              WHERE N_A.IdTipoNovedad = ''PENDIENTE''
              AND N_A.IdMetodoResolucionNovedad = 250       -- ANALISIS
              AND EN_A.Finalizado = ''False''
          ) N_A ON N_A.IdTipoNovedadPadre = N.IdTipoNovedad
                  AND N_A.LetraPadre = N.Letra
                  AND N_A.CentroEmisorPadre = N.CentroEmisor
                  AND N_A.IdNovedadPadre = N.IdNovedad

  LEFT JOIN (SELECT MRN.NombreMetodoResolucionNovedad, EN_D.NombreEstadoNovedad, CN_D.NombreCategoriaNovedad, N_D.*
              FROM CRMNovedades N_D
              INNER JOIN CRMEstadosNovedades EN_D ON EN_D.IdEstadoNovedad = N_D.IdEstadoNovedad
              INNER JOIN CRMCategoriasNovedades CN_D ON CN_D.IdCategoriaNovedad = N_D.IdCategoriaNovedad
              INNER JOIN CRMMetodosResolucionesNovedades MRN ON MRN.IdMetodoResolucionNovedad = N_D.IdMetodoResolucionNovedad
              WHERE N_D.IdTipoNovedad = ''PENDIENTE''
              AND N_D.IdMetodoResolucionNovedad = 251       -- DESARROLLO
              AND EN_D.Finalizado = ''False''
          ) N_D ON N_D.IdTipoNovedadPadre = N.IdTipoNovedad
                  AND N_D.LetraPadre = N.Letra
                  AND N_D.CentroEmisorPadre = N.CentroEmisor
                  AND N_D.IdNovedadPadre = N.IdNovedad

  LEFT JOIN (SELECT MRN.NombreMetodoResolucionNovedad, EN_O.NombreEstadoNovedad, CN_O.NombreCategoriaNovedad, N_O.*
              FROM CRMNovedades N_O
              INNER JOIN CRMEstadosNovedades EN_O ON EN_O.IdEstadoNovedad = N_O.IdEstadoNovedad
              INNER JOIN CRMCategoriasNovedades CN_O ON CN_O.IdCategoriaNovedad = N_O.IdCategoriaNovedad
              INNER JOIN CRMMetodosResolucionesNovedades MRN ON MRN.IdMetodoResolucionNovedad = N_O.IdMetodoResolucionNovedad
              WHERE N_O.IdTipoNovedad = ''PENDIENTE''
              AND NOT N_O.IdMetodoResolucionNovedad IN (250, 251)   -- NI ANALISIS, NI DESARROLLO
              AND EN_O.Finalizado = ''False''
          ) N_O ON N_O.IdTipoNovedadPadre = N.IdTipoNovedad
                  AND N_O.LetraPadre = N.Letra
                  AND N_O.CentroEmisorPadre = N.CentroEmisor
                  AND N_O.IdNovedadPadre = N.IdNovedad

  WHERE N.IdTipoNovedad = ''TICKETS''
  AND EN.Finalizado = ''False''
  AND (1 = 2
      OR N.IdCategoriaNovedad = 421       -- ERROR
      OR N.IdCategoriaNovedad = 1128      -- ERROR ND
      )

----
) N
  LEFT JOIN (SELECT * FROM CRMNovedades N_ALL WHERE N_ALL.IdTipoNovedad = ''PENDIENTE''
          ) N_ALL ON N_ALL.IdTipoNovedadPadre = N.IdTipoNovedad
                 AND N_ALL.LetraPadre = N.Letra
                 AND N_ALL.CentroEmisorPadre = N.CentroEmisor
                 AND N_ALL.IdNovedadPadre = N.IdNovedad
  LEFT JOIN CRMEstadosNovedades EN_ALL ON EN_ALL.IdEstadoNovedad = N_ALL.IdEstadoNovedad
  LEFT JOIN CRMMetodosResolucionesNovedades MRN_ALL ON MRN_ALL.IdMetodoResolucionNovedad = N_ALL.IdMetodoResolucionNovedad
 WHERE (N.IdTipoNovedad_A IS NULL AND N.IdTipoNovedad_D IS NULL AND N.IdTipoNovedad_O IS NULL)
', N'AND', NULL, N'', 1)

INSERT [dbo].[AlertasSistemaCondiciones] ([IdAlertaSistema], [OrdenCondicion], [CondicionCount], [ValorCondicionCount], [MensajeCount], [ColorCondicionCount], [OrdenPrioridad], [MostrarPopUp], [ParametrosAdicionalesPantalla]) VALUES (3, 0, N'Mayor', 0, N'Hay @@COUNT@@ Tickets sin Pendientes', -256, 200, 0, N'')

INSERT [dbo].[AlertasSistemaPermisos] ([IdAlertaSistema], [IdFuncion]) VALUES (3, N'CRMNovedadesABMACTIVIDAD')

INSERT [dbo].[AlertasSistemaUsuarios] ([IdAlertaSistema], [IdUsuario]) VALUES (1, N'mblanco')
END
GO
