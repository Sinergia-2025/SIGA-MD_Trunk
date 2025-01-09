Public Class TableroDeComando
   Inherits Comunes

   Public Sub New(da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Function GetClientesVersiones(filtros As Entidades.TablerosDeComando.FiltroTableros) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("SELECT 'DarkGray' as Color ")
         .AppendLine("       ,C.IdCliente")
         .AppendLine("       ,C.CodigoCliente")
         .AppendLine("       ,C.NombreCliente")
         .AppendLine("       ,C.NombreDeFantasia")
         .AppendLine("       ,C.IdCategoria")
         .AppendLine("       ,CAT.NombreCategoria")
         .AppendLine("       ,C.IdAplicacion ")
         .AppendLine("       ,C.Edicion")
         .AppendLine("       ,C.NroVersion")
         .AppendLine("       ,C.FechaActualizacionVersion ")
         .AppendLine("       ,DATEDIFF(day,C.FechaActualizacionVersion , GETDATE()) AS DiasVersion")
         .AppendLine("       ,CP.ValorParametro NroVersionBackup")
         .AppendLine("       ,CAT.ActualizarAplicacion")
         .AppendFormatLine("       ,{0}", ConvertirBitSiNo("CAT", "ActualizarAplicacion"))
         .AppendLine("  FROM  Clientes AS C ")
         .AppendLine("  LEFT JOIN Categorias AS CAT ON CAT.IdCategoria = C.IdCategoria")
         .AppendLine("  LEFT JOIN ClientesParametros CP ON CP.IdCliente = C.IdCliente AND CP.IdParametro = 'VERSIONBACKUP'")
         .AppendLine("  WHERE 1 = 1")
         GetListaCategoriasMultiples(stb, filtros.Categorias, "C")
         If filtros.ActualizarAplicacion <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormat("   AND CAT.ActualizarAplicacion = '{0}'", filtros.ActualizarAplicacion = Entidades.Publicos.SiNoTodos.SI)
         End If
         .AppendLine(" ORDER BY CAT.ActualizarAplicacion DESC, DiasVersion DESC, C.NombreCliente")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetClientesApi(filtros As Entidades.TablerosDeComando.FiltroTableros) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("SELECT 'DarkGray' as Color ")
         .AppendLine("       ,C.IdCliente")
         .AppendLine("       ,C.CodigoCliente")
         .AppendLine("       ,C.NombreCliente")
         .AppendLine("       ,C.NombreDeFantasia")
         .AppendLine("       ,C.IdCategoria")
         .AppendLine("       ,CAT.NombreCategoria")
         .AppendLine("       ,C.IdAplicacion ")
         .AppendLine("       ,C.Edicion")
         .AppendLine("       ,CW.IdAplicacionMovil")
         .AppendLine("       ,CW.URLPropio")
         .AppendLine("       ,CW.VersionAPI")
         .AppendLine("       ,CAT.ActualizarAplicacion")
         .AppendFormatLine("       ,{0}", ConvertirBitSiNo("CAT", "ActualizarAplicacion"))
         .AppendLine("  FROM  Clientes AS C ")
         .AppendLine("  LEFT JOIN Categorias AS CAT ON CAT.IdCategoria = C.IdCategoria")
         .AppendLine("  LEFT JOIN ClientesParametros CP ON CP.IdCliente = C.IdCliente AND CP.IdParametro = 'VERSIONBACKUP'")

         .AppendLine("  INNER JOIN (SELECT IdCliente, 'SiMovil.Pe' IdAplicacionMovil, URLWebmovilPropio       URLPropio, NroVersionWebmovilPropio       VersionAPI FROM Clientes WHERE ISNULL(URLWebmovilPropio, '')       <> '' UNION")
         .AppendLine("              SELECT IdCliente, 'SiMovilAdm'                  , URLWebmovilAdminPropio           , NroVersionWebmovilAdminPropio             FROM Clientes WHERE ISNULL(URLWebmovilAdminPropio, '')  <> '' UNION")
         .AppendLine("              SELECT IdCliente, 'Simovil.Ge'                  , URLSimovilGestionPropio          , NroVersionSimovilGestionPropio            FROM Clientes WHERE ISNULL(URLSimovilGestionPropio, '') <> '' UNION")
         .AppendLine("              SELECT IdCliente, 'Actualiza'                   , URLActualizadorPropio            , NroVersionActualizadorPropio              FROM Clientes WHERE ISNULL(URLActualizadorPropio, '')   <> '') CW ON CW.IdCliente = C.IdCliente")

         .AppendLine("  WHERE 1 = 1")
         GetListaCategoriasMultiples(stb, filtros.Categorias, "C")
         If filtros.ActualizarAplicacion <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormat("   AND CAT.ActualizarAplicacion='{0}'", filtros.ActualizarAplicacion = Entidades.Publicos.SiNoTodos.SI)
         End If
         .AppendLine(" ORDER BY CAT.ActualizarAplicacion DESC, C.NombreCliente")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetClientesPCs(filtros As Entidades.TablerosDeComando.FiltroTableros) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("SELECT *")
         .AppendLine("      ,CantidadDePCs - PCsCliente DeltaPC")
         .AppendLine("  FROM (SELECT 'DarkGray' as Color")
         .AppendLine("              ,C.IdCliente")
         .AppendLine("              ,C.CodigoCliente")
         .AppendLine("              ,C.NombreCliente")
         .AppendLine("              ,C.NombreDeFantasia")
         .AppendLine("              ,C.IdCategoria")
         .AppendLine("              ,CAT.NombreCategoria")
         .AppendLine("              ,C.IdAplicacion")
         .AppendLine("              ,C.Edicion")
         .AppendLine("              ,CantidadDePCs")
         .AppendLine("              ,(SELECT COUNT(IdDispositivo) FROM ClientesDispositivos CD WHERE CD.IdCliente = C.IdCliente)  as PCsCliente")
         'Parametrizar el Tiempo de los dispositivos. Iniciando en 60 dias
         .AppendLine("              ,CAT.ActualizarAplicacion")
         .AppendFormatLine("              ,{0}", ConvertirBitSiNo("CAT", "ActualizarAplicacion"))
         .AppendLine("  FROM  Clientes AS C")
         .AppendLine("  LEFT JOIN Categorias AS CAT ON CAT.IdCategoria = C.IdCategoria) C")
         .AppendLine(" WHERE 1 = 1")
         GetListaCategoriasMultiples(stb, filtros.Categorias, "C")
         If filtros.ActualizarAplicacion <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormat("   AND C.ActualizarAplicacion='{0}'", filtros.ActualizarAplicacion = Entidades.Publicos.SiNoTodos.SI)
         End If
         .AppendLine(" ORDER BY C.ActualizarAplicacion DESC, DeltaPC, C.NombreCliente")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function
   Public Function GetFechaLargada(filtros As Entidades.TablerosDeComando.FiltroTableros) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("SELECT *")
         .AppendLine("  FROM (SELECT 'DarkGray' as Color")
         .AppendLine("              ,C.IdCliente")
         .AppendLine("              ,C.CodigoCliente")
         .AppendLine("              ,C.NombreCliente")
         .AppendLine("              ,C.NombreDeFantasia")
         .AppendLine("              ,C.IdCategoria")
         .AppendLine("              ,CAT.NombreCategoria")
         .AppendLine("              ,C.IdAplicacion")
         .AppendLine("              ,C.Edicion")
         .AppendLine("              ,CAT.ActualizarAplicacion")
         .AppendFormatLine("              ,{0}", ConvertirBitSiNo("CAT", "ActualizarAplicacion"))
         .AppendLine("              ,C.FechaInicio")
         .AppendLine("              ,C.FechaInicioReal")
         .AppendLine("              ,C.IdClienteCtaCte")
         .AppendLine("  FROM  Clientes AS C")
         .AppendLine("  LEFT JOIN Categorias AS CAT ON CAT.IdCategoria = C.IdCategoria) C")
         .AppendLine(" WHERE 1 = 1")
         GetListaCategoriasMultiples(stb, filtros.Categorias, "C")
         If filtros.ActualizarAplicacion <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("   AND C.ActualizarAplicacion='{0}'", filtros.ActualizarAplicacion = Entidades.Publicos.SiNoTodos.SI)
         End If
         .AppendFormatLine("   AND C.IdClienteCtaCte IS NULL")
         .AppendLine(" ORDER BY C.ActualizarAplicacion DESC, C.FechaInicioReal,C.FechaInicio")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetClientesBackups(filtros As Entidades.TablerosDeComando.FiltroTableros) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("SELECT 'DarkGray' as Color ")
         .AppendLine("      ,C.IdCliente")
         .AppendLine("      ,C.CodigoCliente")
         .AppendLine("      ,C.NombreCliente")
         .AppendLine("      ,C.NombreDeFantasia")
         .AppendLine("      ,C.IdCategoria")
         .AppendLine("      ,CAT.NombreCategoria")
         .AppendLine("      ,CB.NombreServidor")
         .AppendLine("      ,CB.BaseDatos")
         .AppendLine("      ,C.IdAplicacion ")
         .AppendLine("      ,C.Edicion")
         .AppendLine("      ,CBE.FechaInicioBackup")
         .AppendLine("      ,CBE.FechaFinBackup")
         .AppendLine("      ,'' AS TiempoBackup")
         .AppendLine("      ,CASE WHEN CBE.FechaInicioBackup IS NULL THEN CASE WHEN CB.FechaInicioBackup IS NULL THEN -99999 ELSE 99999 END ELSE DATEDIFF(day,CBE.FechaFinBackup, GETDATE()) END as DiasBackup")
         .AppendLine("      ,CB.FechaInicioBackup FechaInicioBackupUltimo")
         .AppendLine("      ,CB.FechaFinBackup FechaFinBackupUltimo")
         .AppendLine("       ,CAT.ActualizarAplicacion")
         .AppendFormatLine("       ,{0}", ConvertirBitSiNo("CAT", "ActualizarAplicacion"))
         .AppendLine("  FROM  Clientes AS C ")
         .AppendLine("  LEFT JOIN Categorias AS CAT ON CAT.IdCategoria = C.IdCategoria")
         .AppendLine("  LEFT JOIN (SELECT CB.*")
         .AppendLine("               FROM ClientesBackups CB")
         .AppendLine("              INNER JOIN (SELECT IdCliente, NombreServidor, BaseDatos, MAX(FechaEjecucion) FechaEjecucion")
         .AppendLine("                            FROM ClientesBackups")
         .AppendLine("                           GROUP BY IdCliente, NombreServidor, BaseDatos) CB1 ON CB1.IdCliente = CB.IdCliente")
         .AppendLine("                                                                             AND CB1.NombreServidor = CB.NombreServidor")
         .AppendLine("                                                                             AND CB1.BaseDatos = CB.BaseDatos")
         .AppendLine("                                                                             AND CB1.FechaEjecucion = CB.FechaEjecucion")
         .AppendLine("                           WHERE CB.Activo = 1) CB")
         .AppendLine("            ON CB.IdCliente = C.IdCliente")
         .AppendLine("  LEFT JOIN (SELECT CB.*")
         .AppendLine("               FROM ClientesBackups CB")
         .AppendLine("              INNER JOIN (SELECT IdCliente, NombreServidor, BaseDatos, MAX(FechaEjecucion) FechaEjecucion")
         .AppendLine("         FROM ClientesBackups")
         .AppendLine("         WHERE FechaFinBackup Is Not NULL")
         .AppendLine("                           GROUP BY IdCliente, NombreServidor, BaseDatos) CB1 ON CB1.IdCliente = CB.IdCliente")
         .AppendLine("                                                                             AND CB1.NombreServidor = CB.NombreServidor")
         .AppendLine("                                                                             AND CB1.BaseDatos = CB.BaseDatos")
         .AppendLine("                                                                             AND CB1.FechaEjecucion = CB.FechaEjecucion) CBE")
         .AppendLine("            ON CBE.IdCliente = C.IdCliente")
         .AppendLine("           AND CBE.NombreServidor = CB.NombreServidor")
         .AppendLine("           AND CBE.BaseDatos = CB.BaseDatos")
         .AppendLine(" WHERE 1 = 1")
         GetListaCategoriasMultiples(stb, filtros.Categorias, "C")
         If filtros.ActualizarAplicacion <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormat("   AND CAT.ActualizarAplicacion='{0}'", filtros.ActualizarAplicacion = Entidades.Publicos.SiNoTodos.SI)
         End If
         '.AppendLine("   AND C.CodigoCliente = 197")
         .AppendLine(" ORDER BY CAT.ControlaBackup DESC, DiasBackup DESC, C.NombreCliente")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetClientesVersionBackup(categorias As Entidades.Categoria(), actualizarAplicacion As Entidades.Publicos.SiNoTodos) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("SELECT 'DarkGray' as Color ")
         .AppendLine("      ,C.IdCliente")
         .AppendLine("      ,C.CodigoCliente")
         .AppendLine("      ,C.NombreCliente")
         .AppendLine("      ,C.NombreDeFantasia")
         .AppendLine("      ,C.IdCategoria")
         .AppendLine("      ,CAT.NombreCategoria")
         .AppendLine("      ,C.IdAplicacion ")
         .AppendLine("      ,C.Edicion")
         .AppendLine("      ,CP.ValorParametro")
         .AppendLine("      ,C.FechaActualizacionVersion ")
         .AppendLine("       ,CAT.ActualizarAplicacion")
         .AppendFormatLine("       ,{0}", ConvertirBitSiNo("CAT", "ActualizarAplicacion"))
         .AppendLine("  FROM  Clientes AS C ")
         .AppendLine("  LEFT JOIN Categorias AS CAT ON CAT.IdCategoria = C.IdCategoria")
         .AppendLine("  LEFT JOIN ClientesParametros CP ON CP.IdCliente = C.IdCliente ")
         .AppendLine("  WHERE CP.IdParametro = 'VERSIONBACKUP'")
         GetListaCategoriasMultiples(stb, categorias, "C")
         If actualizarAplicacion <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormat("       AND CAT.ActualizarAplicacion='{0}'", actualizarAplicacion = Entidades.Publicos.SiNoTodos.SI)
         End If
         .AppendLine(" ORDER BY CAT.ActualizarAplicacion DESC, CP.ValorParametro, C.NombreCliente")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetClientesVencimientoLicencias(filtros As Entidades.TablerosDeComando.FiltroTableros) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("SELECT 'DarkGray' as Color")
         .AppendLine("     , C.IdCliente")
         .AppendLine("     , C.CodigoCliente")
         .AppendLine("     , C.NombreCliente")
         .AppendLine("      ,C.NombreDeFantasia")
         .AppendLine("     , C.IdCategoria")
         .AppendLine("     , CAT.NombreCategoria")
         .AppendLine("     , C.IdAplicacion")
         .AppendLine("     , C.Edicion")
         .AppendLine("     , C.VencimientoLicencia")
         .AppendLine("     , DATEDIFF(day,GETDATE(), C.VencimientoLicencia) AS DiasVencimientoLicencia")
         .AppendLine("       ,CAT.ActualizarAplicacion")
         .AppendFormatLine("       ,{0}", ConvertirBitSiNo("CAT", "ActualizarAplicacion"))
         .AppendLine("  FROM Clientes AS C")
         .AppendLine("  LEFT JOIN Categorias AS CAT ON CAT.IdCategoria = C.IdCategoria")
         .AppendLine("  WHERE 1 = 1")
         GetListaCategoriasMultiples(stb, filtros.Categorias, "C")
         If filtros.ActualizarAplicacion <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormat("       AND CAT.ActualizarAplicacion='{0}'", filtros.ActualizarAplicacion = Entidades.Publicos.SiNoTodos.SI)
         End If
         .AppendLine(" ORDER BY CAT.ActualizarAplicacion DESC, ISNULL(DATEDIFF(day,GETDATE(), C.VencimientoLicencia), 9999), C.NombreCliente")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   ' Devuelve una tabla con información sobre el vencimiento de las licencias
   Public Function GetInfVencimientoLicencias(idCliente As Long, fechaDesde As DateTime?, fechaHasta As DateTime?) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormat("SELECT IdCliente")
         .AppendFormat("     , CodigoCliente")
         .AppendFormat("     , NombreCliente")
         .AppendFormat("     , VencimientoLicencia")
         .AppendFormat("     , DATEDIFF(day,GETDATE(), C.VencimientoLicencia) AS DiasVencimientoLicencia")
         .AppendFormat("  FROM Clientes AS C")
         .AppendFormat("  WHERE 1 = 1")

         If idCliente > 0 Then
            .AppendFormat("AND IdCliente = {0} ", idCliente.ToString())
         End If
         If fechaDesde.HasValue Then
            .AppendFormat("AND VencimientoLicencia >= '{0}' ", ObtenerFecha(fechaDesde.Value, True))
         End If
         If fechaHasta.HasValue Then
            .AppendFormat("AND VencimientoLicencia <= '{0}' ", ObtenerFecha(fechaHasta.Value, True))
         End If
         .AppendLine("ORDER BY DiasVencimientoLicencia ASC")
      End With

      ' Retorno la tabla
      Return Me.GetDataTable(stb.ToString())
   End Function


   Public Function GetNovedades(idTipoNovedad As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT N.IdUsuarioAsignado, U.Nombre NombreUsuarioAsignado, N.IdEstadoNovedad, E.NombreEstadoNovedad")
         .AppendFormatLine("     , E.Color ColorEstadoNovedad, E.Posicion PosicionEstadoNovedad, COUNT(1) CantidadEstadoNovedad, MIN(N.FechaEstadoNovedad) FechaEstadoNovedadMasAntigua")
         .AppendFormatLine("  FROM CRMNovedades N")
         .AppendFormatLine(" INNER JOIN CRMEstadosNovedades E ON E.IdEstadoNovedad = N.IdEstadoNovedad")
         .AppendFormatLine(" INNER JOIN Usuarios U ON U.Id = N.IdUsuarioAsignado")
         .AppendFormatLine(" WHERE E.Finalizado = 'False'")
         .AppendFormatLine("   AND N.IdTipoNovedad = '{0}'", idTipoNovedad)
         .AppendFormatLine(" GROUP BY N.IdUsuarioAsignado, U.Nombre, N.IdEstadoNovedad, E.NombreEstadoNovedad, E.Color, E.Posicion")
         .AppendFormatLine(" ORDER BY E.Posicion")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetCRMSituacionPorTipoEstado(fechaDesde As DateTime, fechaHasta As DateTime, filtros As Entidades.TablerosDeComando.FiltroTableros, mostrarDetalleEstados As Boolean,
                                                diasHabilesMes As Integer, diasHabilesHoy As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT DISTINCT QUOTENAME('____' + CASE WHEN N.FechaEntregado IS NULL THEN N.IdUsuarioAsignado ELSE N.IdUsuarioEntregado END) + ','")
         .AppendFormatLine("  FROM CRMNovedades N")
         .AppendFormatLine(" INNER JOIN CRMEstadosNovedades E ON E.IdEstadoNovedad = N.IdEstadoNovedad")
         .AppendFormatLine(" INNER JOIN CRMTiposEstadosNovedades TE ON TE.IdTipoEstadoNovedad = E.IdTipoEstadoNovedad")
         .AppendFormatLine("  LEFT JOIN CRMEstadosNovedades EE ON EE.IdEstadoNovedad = N.IdEstadoNovedadEntregado")
         .AppendFormatLine("  LEFT JOIN CRMTiposEstadosNovedades TEE ON TEE.IdTipoEstadoNovedad = EE.IdTipoEstadoNovedad")
         .AppendFormatLine(" WHERE N.IdTipoNovedad = '{0}'", filtros.idTipoNovedad)
         '.AppendFormatLine("   AND (N.FechaEntregado BETWEEN '{0}' AND '{1}' OR N.FechaEntregado IS NULL)", ObtenerFecha(fechaDesde, True), ObtenerFecha(fechaHasta, True))
         .AppendFormatLine("   AND (N.FechaEntregado BETWEEN '{0}' AND '{1}' OR (N.FechaEntregado IS NULL AND E.Finalizado = 'False'))", ObtenerFecha(fechaDesde, True), ObtenerFecha(fechaHasta, True))
         .AppendFormatLine(" ORDER BY 1")
         .AppendFormatLine("   FOR XML PATH('')")
      End With
      Dim dtColumnas = GetDataTable(stb.ToString())

      Dim pivotColumns As String = String.Empty
      If dtColumnas.Rows.Count > 0 Then
         Dim dr = dtColumnas.Rows(0)
         pivotColumns = dtColumnas.Rows(0)(0).ToString().Trim(","c)
      End If

      stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT *")
         .AppendFormatLine("  FROM (")
         .AppendFormatLine("        SELECT CASE WHEN N.FechaEntregado IS NULL THEN TE.NombreTipoEstadoNovedad ELSE TEE.NombreTipoEstadoNovedad END NombreTipoEstadoNovedad")
         .AppendFormatLine("             , CASE WHEN N.FechaEntregado IS NULL THEN TE.Posicion ELSE TEE.Posicion END Posicion")
         If mostrarDetalleEstados Then
            .AppendFormatLine("             , CASE WHEN N.FechaEntregado IS NULL THEN E.NombreEstadoNovedad ELSE EE.NombreEstadoNovedad END NombreEstadoNovedad")
            .AppendFormatLine("             , CASE WHEN N.FechaEntregado IS NULL THEN E.Posicion ELSE EE.Posicion END PosicionEstado")
         End If
         If Not String.IsNullOrWhiteSpace(pivotColumns) Then
            .AppendFormatLine("             , '____' + CASE WHEN N.FechaEntregado IS NULL THEN N.IdUsuarioAsignado ELSE N.IdUsuarioEntregado END IdUsuarioAsignado")
            .AppendFormatLine("             , 1 Cantidad")
         End If
         .AppendFormatLine("          FROM CRMNovedades N")
         .AppendFormatLine("         INNER JOIN CRMEstadosNovedades E ON E.IdEstadoNovedad = N.IdEstadoNovedad")
         .AppendFormatLine("         INNER JOIN CRMTiposEstadosNovedades TE ON TE.IdTipoEstadoNovedad = E.IdTipoEstadoNovedad")
         .AppendFormatLine("          LEFT JOIN CRMEstadosNovedades EE ON EE.IdEstadoNovedad = N.IdEstadoNovedadEntregado")
         .AppendFormatLine("          LEFT JOIN CRMTiposEstadosNovedades TEE ON TEE.IdTipoEstadoNovedad = EE.IdTipoEstadoNovedad")
         .AppendFormatLine("         WHERE N.IdTipoNovedad = '{0}'", filtros.idTipoNovedad)
         '.AppendFormatLine("           AND (N.FechaEntregado BETWEEN '{0}' AND '{1}' OR N.FechaEntregado IS NULL)", ObtenerFecha(fechaDesde, True), ObtenerFecha(fechaHasta, True))
         .AppendFormatLine("   AND (N.FechaEntregado BETWEEN '{0}' AND '{1}' OR (N.FechaEntregado IS NULL AND E.Finalizado = 'False'))", ObtenerFecha(fechaDesde, True), ObtenerFecha(fechaHasta, True))
         .AppendFormatLine("        ) N")
         If Not String.IsNullOrWhiteSpace(pivotColumns) Then
            .AppendFormatLine(" PIVOT(SUM(N.Cantidad) FOR N.IdUsuarioAsignado IN ({0})) AS N", pivotColumns)
         End If
         If Not String.IsNullOrWhiteSpace(pivotColumns) Then

            .AppendFormatLine("UNION ALL")

            'Entregados en lo que va del mes
            .AppendFormatLine("SELECT N.*")
            .AppendFormatLine("  FROM (")
            .AppendFormatLine("        SELECT 'PERFORMANCE' NombreTipoEstadoNovedad, 0 Posicion, '____' + N.IdUsuarioEntregado IdUsuarioEntregado, COUNT(1) Cantidad")
            If mostrarDetalleEstados Then
               .AppendFormatLine("             , '' NombreEstadoNovedad")
               .AppendFormatLine("             , 0 PosicionEstado")
            End If
            .AppendFormatLine("          FROM CRMNovedades N")
            .AppendFormatLine("         WHERE N.IdTipoNovedad = '{0}'", filtros.idTipoNovedad)
            .AppendFormatLine("           AND N.FechaEntregado IS NOT NULL")
            .AppendFormatLine("           AND N.FechaEntregado BETWEEN '{0}' AND '{1}'", ObtenerFecha(fechaDesde.PrimerDiaMes(), True), ObtenerFecha(Today.UltimoSegundoDelDia(), True))
            .AppendFormatLine("         GROUP BY DATEADD(month, DATEDIFF(month, 0, N.FechaEntregado), 0), N.IdUsuarioEntregado")
            .AppendFormatLine("       ) N")
            .AppendFormatLine(" PIVOT (SUM(N.Cantidad) FOR IdUsuarioEntregado IN ({0})) AS N", pivotColumns)
            .AppendFormatLine("UNION ALL")

            'Objetivo proporcional a lo que va del mes
            .AppendFormatLine("SELECT *")
            .AppendFormatLine("  FROM (")
            .AppendFormatLine("        SELECT 'OBJETIVO' NombreTipoEstadoNovedad, -10 Posicion, '____' + N.IdUsuario IdUsuarioObjetivo, N.Objetivo / {0} * {1} Objetivo", diasHabilesMes, diasHabilesHoy)
            If mostrarDetalleEstados Then
               .AppendFormatLine("             , '' NombreEstadoNovedad")
               .AppendFormatLine("             , 0 PosicionEstado")
            End If
            .AppendFormatLine("          FROM CRMTiposNovedadesObjetivosUsuarios N")
            .AppendFormatLine("         WHERE N.IdTipoNovedad = '{0}'", filtros.IdTipoNovedad)
            .AppendFormatLine("           AND N.PeriodoObjetivo = {0}", fechaDesde.ToPeriodo())
            .AppendFormatLine("       ) N")
            .AppendFormatLine(" PIVOT (SUM(Objetivo) FOR IdUsuarioObjetivo IN ({0})) AS N", pivotColumns)
            .AppendFormatLine("UNION ALL")

            'Objetivo Mínimo proporcional a lo que va del mes
            .AppendFormatLine("SELECT *")
            .AppendFormatLine("  FROM (")
            .AppendFormatLine("        SELECT 'MINIMO' NombreTipoEstadoNovedad, -20 Posicion, '____' + N.IdUsuario IdUsuarioObjetivo, N.ObjetivoMinimo / {0} * {1} ObjetivoMinimo", diasHabilesMes, diasHabilesHoy)
            If mostrarDetalleEstados Then
               .AppendFormatLine("             , '' NombreEstadoNovedad")
               .AppendFormatLine("             , 0 PosicionEstado")
            End If
            .AppendFormatLine("          FROM CRMTiposNovedadesObjetivosUsuarios N")
            .AppendFormatLine("         WHERE N.IdTipoNovedad = '{0}'", filtros.IdTipoNovedad)
            .AppendFormatLine("           AND N.PeriodoObjetivo = {0}", fechaDesde.ToPeriodo())
            .AppendFormatLine("       ) N")
            .AppendFormatLine(" PIVOT (SUM(ObjetivoMinimo) FOR IdUsuarioObjetivo IN ({0})) AS N", pivotColumns)
            .AppendFormatLine("UNION ALL")

            'Objetivo total del periodo
            .AppendFormatLine("SELECT *")
            .AppendFormatLine("  FROM (")
            .AppendFormatLine("        SELECT 'OBJETIVO' NombreTipoEstadoNovedad, -30 Posicion, '____' + N.IdUsuario IdUsuarioObjetivo, N.Objetivo")
            If mostrarDetalleEstados Then
               .AppendFormatLine("             , '' NombreEstadoNovedad")
               .AppendFormatLine("             , 0 PosicionEstado")
            End If
            .AppendFormatLine("          FROM CRMTiposNovedadesObjetivosUsuarios N")
            .AppendFormatLine("         WHERE N.IdTipoNovedad = '{0}'", filtros.IdTipoNovedad)
            .AppendFormatLine("           AND N.PeriodoObjetivo = {0}", fechaDesde.ToPeriodo())
            .AppendFormatLine("       ) N")
            .AppendFormatLine(" PIVOT (SUM(Objetivo) FOR IdUsuarioObjetivo IN ({0})) AS N", pivotColumns)
            .AppendFormatLine("UNION ALL")

            'Objetivo mínimo total del periodo
            .AppendFormatLine("SELECT *")
            .AppendFormatLine("  FROM (")
            .AppendFormatLine("        SELECT 'MINIMO' NombreTipoEstadoNovedad, -40 Posicion, '____' + N.IdUsuario IdUsuarioObjetivo, N.ObjetivoMinimo")
            If mostrarDetalleEstados Then
               .AppendFormatLine("             , '' NombreEstadoNovedad")
               .AppendFormatLine("             , 0 PosicionEstado")
            End If
            .AppendFormatLine("          FROM CRMTiposNovedadesObjetivosUsuarios N")
            .AppendFormatLine("         WHERE N.IdTipoNovedad = '{0}'", filtros.IdTipoNovedad)
            .AppendFormatLine("           AND N.PeriodoObjetivo = {0}", fechaDesde.ToPeriodo())
            .AppendFormatLine("       ) N")
            .AppendFormatLine(" PIVOT (SUM(ObjetivoMinimo) FOR IdUsuarioObjetivo IN ({0})) AS N", pivotColumns)

         End If

         .AppendFormatLine(" ORDER BY N.Posicion")
         If mostrarDetalleEstados Then
            .AppendFormatLine("        , N.PosicionEstado")
         End If

      End With

      Return GetDataTable(stb.ToString())
   End Function

   Public Function GetPerformanceParaCRMEntregadoMensual(fechaDesde As Date, fechaHasta As Date, filtros As Entidades.TablerosDeComando.FiltroTableros) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT DISTINCT QUOTENAME('____' + N.IdUsuarioEntregado) + ','")
         .AppendFormatLine("  FROM CRMNovedades N")
         .AppendFormatLine(" WHERE N.IdTipoNovedad = '{0}'", filtros.IdTipoNovedad)
         .AppendFormatLine("   AND N.FechaEntregado IS NOT NULL")
         .AppendFormatLine("   AND N.FechaEntregado BETWEEN '{0}' AND '{1}'", ObtenerFecha(fechaDesde, True), ObtenerFecha(fechaHasta, True))
         .AppendFormatLine(" ORDER BY 1")
         .AppendFormatLine(" FOR XML PATH('')")

      End With
      Dim dtColumnas = GetDataTable(stb.ToString())

      Dim pivotColumns As String = String.Empty
      If dtColumnas.Rows.Count > 0 Then
         Dim dr = dtColumnas.Rows(0)
         pivotColumns = dtColumnas.Rows(0)(0).ToString().Trim(","c)
      End If

      Dim periodos = New List(Of String)()
      Dim fechaRef = fechaDesde.PrimerDiaMes()
      While fechaRef < fechaHasta
         periodos.Add(fechaRef.ToString("yyyyMM"))
         fechaRef = fechaRef.AddMonths(1)
      End While
      Dim lst = String.Join(","c, periodos)

      stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT *")
         .AppendFormatLine("  FROM (")
         .AppendFormatLine("        SELECT 'OBJETIVO' NombreTipoEstadoNovedad, -10 Posicion, N.PeriodoObjetivo, '____' + N.IdUsuario IdUsuarioObjetivo, N.Objetivo / 21 * 10 Objetivo")
         .AppendFormatLine("          FROM CRMTiposNovedadesObjetivosUsuarios N")
         .AppendFormatLine("         WHERE N.IdTipoNovedad = '{0}'", filtros.IdTipoNovedad)
         .AppendFormatLine("           AND N.PeriodoObjetivo IN ({0})", lst)
         .AppendFormatLine("       ) N")
         If Not String.IsNullOrWhiteSpace(pivotColumns) Then
            .AppendFormatLine(" PIVOT (SUM(N.Objetivo) FOR IdUsuarioObjetivo IN ({0})) AS N", pivotColumns)
         End If
         .AppendFormatLine("UNION ALL")
         .AppendFormatLine("SELECT *")
         .AppendFormatLine("  FROM (")
         .AppendFormatLine("        SELECT 'MINIMO' NombreTipoEstadoNovedad, -20 Posicion, N.PeriodoObjetivo, '____' + N.IdUsuario IdUsuarioObjetivo, N.ObjetivoMinimo / 21 * 10 ObjetivoMinimo")
         .AppendFormatLine("          FROM CRMTiposNovedadesObjetivosUsuarios N")
         .AppendFormatLine("         WHERE N.IdTipoNovedad = '{0}'", filtros.IdTipoNovedad)
         .AppendFormatLine("           AND N.PeriodoObjetivo IN ({0})", lst)
         .AppendFormatLine("       ) N")
         If Not String.IsNullOrWhiteSpace(pivotColumns) Then
            .AppendFormatLine(" PIVOT (SUM(N.ObjetivoMinimo) FOR IdUsuarioObjetivo IN ({0})) AS N", pivotColumns)
         End If
         .AppendFormatLine("UNION ALL")
         .AppendFormatLine("SELECT *")
         .AppendFormatLine("  FROM (")
         .AppendFormatLine("        SELECT 'OBJETIVO' NombreTipoEstadoNovedad, -30 Posicion, N.PeriodoObjetivo, '____' + N.IdUsuario IdUsuarioObjetivo, N.Objetivo")
         .AppendFormatLine("          FROM CRMTiposNovedadesObjetivosUsuarios N")
         .AppendFormatLine("         WHERE N.IdTipoNovedad = '{0}'", filtros.IdTipoNovedad)
         .AppendFormatLine("           AND N.PeriodoObjetivo IN ({0})", lst)
         .AppendFormatLine("       ) N")
         If Not String.IsNullOrWhiteSpace(pivotColumns) Then
            .AppendFormatLine(" PIVOT (SUM(N.Objetivo) FOR IdUsuarioObjetivo IN ({0})) AS N", pivotColumns)
         End If
         .AppendFormatLine("UNION ALL")
         .AppendFormatLine("SELECT *")
         .AppendFormatLine("  FROM (")
         .AppendFormatLine("        SELECT 'MINIMO' NombreTipoEstadoNovedad, -40 Posicion, N.PeriodoObjetivo, '____' + N.IdUsuario IdUsuarioObjetivo, N.ObjetivoMinimo")
         .AppendFormatLine("          FROM CRMTiposNovedadesObjetivosUsuarios N")
         .AppendFormatLine("         WHERE N.IdTipoNovedad = '{0}'", filtros.IdTipoNovedad)
         .AppendFormatLine("           AND N.PeriodoObjetivo IN ({0})", lst)
         .AppendFormatLine("       ) N")
         If Not String.IsNullOrWhiteSpace(pivotColumns) Then
            .AppendFormatLine(" PIVOT (SUM(N.ObjetivoMinimo) FOR IdUsuarioObjetivo IN ({0})) AS N", pivotColumns)
         End If
         .AppendFormatLine(" ORDER BY N.Posicion")
      End With

      Return GetDataTable(stb.ToString())

   End Function

   Public Function GetCRMEntregadoMensual(fechaDesde As Date, fechaHasta As Date, filtros As Entidades.TablerosDeComando.FiltroTableros) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT DISTINCT QUOTENAME('____' + N.IdUsuarioEntregado) + ','")
         .AppendFormatLine("  FROM CRMNovedades N")
         .AppendFormatLine(" WHERE N.IdTipoNovedad = '{0}'", filtros.IdTipoNovedad)
         .AppendFormatLine("   AND N.FechaEntregado IS NOT NULL")
         .AppendFormatLine("   AND N.FechaEntregado BETWEEN '{0}' AND '{1}'", ObtenerFecha(fechaDesde, True), ObtenerFecha(fechaHasta, True))
         .AppendFormatLine(" ORDER BY 1")
         .AppendFormatLine(" FOR XML PATH('')")

      End With
      Dim dtColumnas = GetDataTable(stb.ToString())

      Dim pivotColumns As String = String.Empty
      If dtColumnas.Rows.Count > 0 Then
         Dim dr = dtColumnas.Rows(0)
         pivotColumns = dtColumnas.Rows(0)(0).ToString().Trim(","c)
      End If

      stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT N.*")
         .AppendFormatLine("  FROM (")
         .AppendFormatLine("        SELECT DATEADD(month, DATEDIFF(month, 0, N.FechaEntregado), 0) FechaEntregado, '____' + N.IdUsuarioEntregado IdUsuarioEntregado, COUNT(1) Cantidad")
         .AppendFormatLine("          FROM CRMNovedades N")
         .AppendFormatLine("         WHERE N.IdTipoNovedad = '{0}'", filtros.IdTipoNovedad)
         .AppendFormatLine("           AND N.FechaEntregado IS NOT NULL")
         .AppendFormatLine("           AND N.FechaEntregado BETWEEN '{0}' AND '{1}'", ObtenerFecha(fechaDesde, True), ObtenerFecha(fechaHasta, True))
         .AppendFormatLine("         GROUP BY DATEADD(month, DATEDIFF(month, 0, N.FechaEntregado), 0), N.IdUsuarioEntregado")
         .AppendFormatLine("       ) N")
         If Not String.IsNullOrWhiteSpace(pivotColumns) Then
            .AppendFormatLine(" PIVOT (SUM(N.Cantidad) FOR IdUsuarioEntregado IN ({0})) AS N", pivotColumns)
         End If
         .AppendFormatLine(" ORDER BY N.FechaEntregado")
      End With

      Return GetDataTable(stb.ToString())
   End Function

   Public Function CRMTotalEquiposReparados(filtros As Entidades.TablerosDeComando.FiltroTableros) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("select ")
         .AppendFormatLine("   IdUsuarioAsignado")
         .AppendFormatLine(" , SUM(CASE WHEN CONVERT (date, FechaNovedad) = CONVERT (date, GETDATE()) THEN 1 ELSE 0 END) Hoy")
         .AppendFormatLine(" , SUM(CASE WHEN CONVERT(DATE, FechaNovedad) BETWEEN DATEADD(month, DATEDIFF(month, -1, getdate()) - 1, 0) AND DATEADD(ss, -1, DATEADD(month, DATEDIFF(month, -1, getdate())   , 0)) THEN 1 ELSE 0 END)   mes___actual")
         .AppendFormatLine(" , SUM(CASE WHEN CONVERT(DATE, FechaNovedad) BETWEEN DATEADD(month, DATEDIFF(month, -1, getdate()) - 2, 0) AND DATEADD(ss, -1, DATEADD(month, DATEDIFF(month, -1, getdate()-30), 0)) THEN 1 ELSE 0 END)   mes___1")
         .AppendFormatLine(" , SUM(CASE WHEN CONVERT(DATE, FechaNovedad) BETWEEN DATEADD(month, DATEDIFF(month, -1, getdate()) - 3, 0) AND DATEADD(ss, -1, DATEADD(month, DATEDIFF(month, -1, getdate()-60), 0)) THEN 1 ELSE 0 END)   mes___2")
         .AppendFormatLine(" , SUM(CASE WHEN CONVERT(DATE, FechaNovedad) BETWEEN DATEADD(month, DATEDIFF(month, -1, getdate()) - 4, 0) AND DATEADD(ss, -1, DATEADD(month, DATEDIFF(month, -1, getdate()-90), 0)) THEN 1 ELSE 0 END)   mes___3")

         .AppendFormatLine("  from CRMNovedades")
         .AppendFormatLine(" where (IdEstadoNovedad=130 or IdEstadoNovedad=140 or IdEstadoNovedad=150) ")
         .AppendFormatLine(" group by IdUsuarioAsignado")
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetEntregasMensualesPorEstado(filtros As Entidades.TablerosDeComando.FiltroTableros) As DataTable
      Dim hoy = Today
      Dim desde = hoy.PrimerDiaMes().AddMonths(filtros.MesesHistoricos * -1)
      Dim desdeMes = hoy.PrimerDiaMes()
      Dim hastaMes = desdeMes.UltimoDiaMes()
      Dim mesesList = New List(Of String)
      For i = 0 To filtros.MesesHistoricos
         mesesList.Add(String.Format("[{0:yyyy-MM}]", desdeMes.AddMonths(i * -1)))
      Next
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT *")
         .AppendFormatLine("  FROM (")
         .AppendFormatLine("        SELECT EN.NombreEstadoNovedad, NCE.IdEstadoNovedad, NCE1.Periodo, EN.Posicion")
         If filtros.AgrupadoPorUsuario Then
            .AppendFormatLine("             , U.Id IdUsuarioAsignado")
         End If
         .AppendFormatLine("             , SUM(NCE1.Cantidad) AS Cantidad")
         .AppendFormatLine("            FROM (")
         .AppendFormatLine("                SELECT NCE.IdTipoNovedad, NCE.Letra, NCE.CentroEmisor, NCE.IdNovedad, NCE.IdCambioEstado")
         .AppendFormatLine("                        , MAX(NCE.FechaCambioEstado) FechaCambioEstado")
         .AppendFormatLine("                        , COUNT(1) Cantidad")
         .AppendFormatLine("                        , CONVERT(VARCHAR(MAX), YEAR(MAX(NCE.FechaCambioEstado))) + '-' + RIGHT('0' + CONVERT(VARCHAR(MAX), MONTH(MAX(NCE.FechaCambioEstado))), 2) Periodo")
         .AppendFormatLine("                    FROM CRMNovedadesCambiosEstados NCE")
         .AppendFormatLine("                    WHERE NCE.IdEstadoNovedad IN ({0})", String.Join(",", filtros.IdEstados))
         .AppendFormatLine("                      AND NCE.IdTipoNovedad = '{0}'", filtros.IdTipoNovedad)
         .AppendFormatLine("                    GROUP BY NCE.IdTipoNovedad, NCE.Letra, NCE.CentroEmisor, NCE.IdNovedad, NCE.IdCambioEstado")
         .AppendFormatLine("                ) NCE1")
         .AppendFormatLine("            INNER JOIN CRMNovedadesCambiosEstados NCE")
         .AppendFormatLine("                    ON NCE.IdTipoNovedad    = NCE1.IdTipoNovedad")
         .AppendFormatLine("                   AND NCE.Letra            = NCE1.Letra")
         .AppendFormatLine("                   AND NCE.CentroEmisor     = NCE1.CentroEmisor")
         .AppendFormatLine("                   AND NCE.IdNovedad        = NCE1.IdNovedad")
         .AppendFormatLine("                   AND NCE.IdCambioEstado   = NCE1.IdCambioEstado")
         .AppendFormatLine("            INNER JOIN CRMEstadosNovedades EN ON EN.IdEstadoNovedad = NCE.IdEstadoNovedad")
         .AppendFormatLine("            INNER JOIN Usuarios U ON U.Id = NCE.IdUsuarioAsignado")
         .AppendFormatLine("            GROUP BY NCE.IdEstadoNovedad, EN.NombreEstadoNovedad")
         If filtros.AgrupadoPorUsuario Then
            .AppendFormatLine("                , U.Id")
         End If
         .AppendFormatLine("                , NCE1.Periodo")
         .AppendFormatLine("                , EN.Posicion")
         .AppendFormatLine("        ) NCE")
         .AppendFormatLine(" PIVOT(SUM(NCE.Cantidad) FOR NCE.Periodo in ({0})) P1", String.Join(",", mesesList.ToArray()))

         If filtros.AgrupadoPorUsuario Then
            .AppendFormatLine(" ORDER BY P1.IdUsuarioAsignado, P1.Posicion")
         Else
            .AppendFormatLine(" ORDER BY P1.Posicion")
         End If
      End With

      Return GetDataTable(stb)
   End Function

   Public Function GetCRMGlobalEntrega(filtros As Entidades.TablerosDeComando.FiltroTableros, mesesHistoricos As Integer) As DataTable
      Dim hoy As Date = Today
      Dim desde As Date = hoy.PrimerDiaMes().AddMonths(mesesHistoricos * -1)
      Dim desdeMes As Date = hoy.PrimerDiaMes()
      Dim hastaMes As Date = desdeMes.UltimoDiaMes()
      Dim mesesList = New List(Of Tuple(Of Integer, Date, Date))
      For i = 1 To mesesHistoricos
         mesesList.Add(New Tuple(Of Integer, Date, Date)(i, desdeMes.AddMonths(i * -1), desdeMes.AddMonths(i * -1).UltimoDiaMes()))
      Next

      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT '{0}' Descripcion", filtros.DescripcionesGlobalEntregas(0))   ''INGRESADOS'
         .AppendFormatLine("     , SUM(CASE WHEN CONVERT(DATE, N.FechaNovedad) = '{0}' THEN 1 ELSE 0 END)    Hoy", ObtenerFecha(hoy, False))
         .AppendFormatLine("     , SUM(CASE WHEN CONVERT(DATE, N.FechaNovedad) BETWEEN '{0}' AND '{1}' THEN 1 ELSE 0 END)   Acumulado", ObtenerFecha(desdeMes, False), ObtenerFecha(hastaMes, False))
         For Each mes In mesesList
            .AppendFormatLine("     , SUM(CASE WHEN CONVERT(DATE, N.FechaNovedad) BETWEEN '{0}' AND '{1}' THEN 1 ELSE 0 END) [{2:MM/yyyy}]", ObtenerFecha(mes.Item2, False), ObtenerFecha(mes.Item3, False), mes.Item2)
         Next
         .AppendFormatLine("  FROM CRMNovedades N")
         .AppendFormatLine(" WHERE N.IdTipoNovedad = '{0}'", filtros.IdTipoNovedad)
         .AppendFormatLine("   AND N.FechaNovedad >= '{0}'", ObtenerFecha(desde, True))
         .AppendFormatLine("UNION ALL")
         .AppendFormatLine("SELECT '{0}'", filtros.DescripcionesGlobalEntregas(1))               'H: 'ENTREGADOS // B: 'REPARADOS'
         .AppendFormatLine("     , SUM(CASE WHEN CONVERT(DATE, N.FechaEntregado) = '{0}' THEN 1 ELSE 0 END)", ObtenerFecha(hoy, False))
         .AppendFormatLine("     , SUM(CASE WHEN CONVERT(DATE, N.FechaEntregado) BETWEEN '{0}' AND '{1}' THEN 1 ELSE 0 END)", ObtenerFecha(desdeMes, False), ObtenerFecha(hastaMes, False))
         For Each mes In mesesList
            .AppendFormatLine("     , SUM(CASE WHEN CONVERT(DATE, N.FechaEntregado) BETWEEN '{0}' AND '{1}' THEN 1 ELSE 0 END)", ObtenerFecha(mes.Item2, False), ObtenerFecha(mes.Item3, False))
         Next
         .AppendFormatLine("  FROM CRMNovedades N")
         .AppendFormatLine(" WHERE N.IdTipoNovedad = '{0}'", filtros.IdTipoNovedad)
         .AppendFormatLine("   AND N.FechaNovedad >= '{0}'", ObtenerFecha(desde, True))
         .AppendFormatLine("UNION ALL")
         .AppendFormatLine("SELECT '{0}'", filtros.DescripcionesGlobalEntregas(2))               'H: 'FINALIZADOS // B: 'ENTREGADOS'
         .AppendFormatLine("     , SUM(CASE WHEN CONVERT(DATE, N.FechaFinalizado) = '{0}' THEN 1 ELSE 0 END)", ObtenerFecha(hoy, False))
         .AppendFormatLine("     , SUM(CASE WHEN CONVERT(DATE, N.FechaFinalizado) BETWEEN '{0}' AND '{1}' THEN 1 ELSE 0 END)", ObtenerFecha(desdeMes, False), ObtenerFecha(hastaMes, False))
         For Each mes In mesesList
            .AppendFormatLine("     , SUM(CASE WHEN CONVERT(DATE, N.FechaFinalizado) BETWEEN '{0}' AND '{1}' THEN 1 ELSE 0 END)", ObtenerFecha(mes.Item2, False), ObtenerFecha(mes.Item3, False))
         Next
         .AppendFormatLine("  FROM CRMNovedades N")
         .AppendFormatLine(" WHERE N.IdTipoNovedad = '{0}'", filtros.IdTipoNovedad)
         .AppendFormatLine("   AND N.FechaFinalizado >= '{0}'", ObtenerFecha(desde, True))
         .AppendFormatLine("UNION ALL")
         .AppendFormatLine("SELECT '{0}'", filtros.DescripcionesGlobalEntregas(3))               'H: 'TEP' // B: 'TRP'      (Tasa Entrega/Reparacion Promedio)
         .AppendFormatLine("     , CONVERT(DECIMAL(12, 2), SUM(CASE WHEN CONVERT(DATE, N.FechaEntregado) = '{0}' THEN DATEDIFF(DAY, CONVERT(DATE, N.FechaNovedad), CONVERT(DATE, N.FechaEntregado)) + 1 ELSE 0 END)) /", ObtenerFecha(hoy, False))
         .AppendFormatLine("       NULLIF(CONVERT(DECIMAL(12, 2), SUM(CASE WHEN CONVERT(DATE, N.FechaEntregado) = '{0}' THEN 1 ELSE 0 END)), 0)", ObtenerFecha(hoy, False))
         .AppendFormatLine("     , CONVERT(DECIMAL(12, 2), SUM(CASE WHEN CONVERT(DATE, N.FechaEntregado) BETWEEN '{0}' AND '{1}' THEN DATEDIFF(DAY, CONVERT(DATE, N.FechaNovedad), CONVERT(DATE, N.FechaEntregado)) + 1 ELSE 0 END)) /", ObtenerFecha(desdeMes, False), ObtenerFecha(hastaMes, False))
         .AppendFormatLine("       NULLIF(CONVERT(DECIMAL(12, 2), SUM(CASE WHEN CONVERT(DATE, N.FechaEntregado) BETWEEN '{0}' AND '{1}' THEN 1 ELSE 0 END)), 0)", ObtenerFecha(desdeMes, False), ObtenerFecha(hastaMes, False))
         For Each mes In mesesList
            .AppendFormatLine("     , CONVERT(DECIMAL(12, 2), SUM(CASE WHEN CONVERT(DATE, N.FechaEntregado) BETWEEN '{0}' AND '{1}' THEN DATEDIFF(DAY, CONVERT(DATE, N.FechaNovedad), CONVERT(DATE, N.FechaEntregado)) + 1 ELSE 0 END)) /", ObtenerFecha(mes.Item2, False), ObtenerFecha(mes.Item3, False))
            .AppendFormatLine("       NULLIF(CONVERT(DECIMAL(12, 2), SUM(CASE WHEN CONVERT(DATE, N.FechaEntregado) BETWEEN '{0}' AND '{1}' THEN 1 ELSE 0 END)), 0)", ObtenerFecha(mes.Item2, False), ObtenerFecha(mes.Item3, False))
         Next
         .AppendFormatLine("  FROM CRMNovedades N")
         .AppendFormatLine(" WHERE N.IdTipoNovedad = '{0}'", filtros.IdTipoNovedad)
         .AppendFormatLine("   AND N.FechaNovedad >= '{0}'", ObtenerFecha(desde, True))
         .AppendFormatLine("UNION ALL")
         .AppendFormatLine("SELECT '{0}'", filtros.DescripcionesGlobalEntregas(4))               'H: 'TFP' // B: 'TEP'      (Tasa Finalizacion/Entrega Promedio)
         .AppendFormatLine("     , CONVERT(DECIMAL(12, 2), SUM(CASE WHEN CONVERT(DATE, N.FechaFinalizado) = '{0}' THEN DATEDIFF(DAY, CONVERT(DATE, N.FechaNovedad), CONVERT(DATE, N.FechaFinalizado)) + 1 ELSE 0 END)) /", ObtenerFecha(hoy, False))
         .AppendFormatLine("       NULLIF(CONVERT(DECIMAL(12, 2), SUM(CASE WHEN CONVERT(DATE, N.FechaFinalizado) = '{0}' THEN 1 ELSE 0 END)), 0)", ObtenerFecha(hoy, False))
         .AppendFormatLine("     , CONVERT(DECIMAL(12, 2), SUM(CASE WHEN CONVERT(DATE, N.FechaFinalizado) BETWEEN '{0}' AND '{1}' THEN DATEDIFF(DAY, CONVERT(DATE, N.FechaNovedad), CONVERT(DATE, N.FechaFinalizado)) + 1 ELSE 0 END)) /", ObtenerFecha(desdeMes, False), ObtenerFecha(hastaMes, False))
         .AppendFormatLine("       NULLIF(CONVERT(DECIMAL(12, 2), SUM(CASE WHEN CONVERT(DATE, N.FechaFinalizado) BETWEEN '{0}' AND '{1}' THEN 1 ELSE 0 END)), 0)", ObtenerFecha(desdeMes, False), ObtenerFecha(hastaMes, False))
         For Each mes In mesesList
            .AppendFormatLine("     , CONVERT(DECIMAL(12, 2), SUM(CASE WHEN CONVERT(DATE, N.FechaFinalizado) BETWEEN '{0}' AND '{1}' THEN DATEDIFF(DAY, CONVERT(DATE, N.FechaNovedad), CONVERT(DATE, N.FechaFinalizado)) + 1 ELSE 0 END)) /", ObtenerFecha(mes.Item2, False), ObtenerFecha(mes.Item3, False))
            .AppendFormatLine("       NULLIF(CONVERT(DECIMAL(12, 2), SUM(CASE WHEN CONVERT(DATE, N.FechaFinalizado) BETWEEN '{0}' AND '{1}' THEN 1 ELSE 0 END)), 0)", ObtenerFecha(mes.Item2, False), ObtenerFecha(mes.Item3, False))
         Next
         .AppendFormatLine("  FROM CRMNovedades N")
         .AppendFormatLine(" WHERE N.IdTipoNovedad = '{0}'", filtros.IdTipoNovedad)
         .AppendFormatLine("   AND N.FechaFinalizado >= '{0}'", ObtenerFecha(desde, True))
         If filtros.DescripcionesGlobalEntregas.Count > 5 OrElse Not String.IsNullOrWhiteSpace(filtros.DescripcionesGlobalEntregas(5)) Then
            .AppendFormatLine("UNION ALL")
            .AppendFormatLine("SELECT '{0}'", filtros.DescripcionesGlobalEntregas(5))               'H: '' // B: 'CRP'         (Costo Reparación Promedio)
            .AppendFormatLine("     , CONVERT(DECIMAL(12, 2), SUM(CASE WHEN CONVERT(DATE, N.FechaEntregado) = '{0}' THEN V.SubTotal ELSE 0 END)) /", ObtenerFecha(hoy, False))
            .AppendFormatLine("       NULLIF(CONVERT(DECIMAL(12, 2), SUM(CASE WHEN CONVERT(DATE, N.FechaEntregado) = '{0}' THEN 1 ELSE 0 END)), 0)", ObtenerFecha(hoy, False))
            .AppendFormatLine("     , CONVERT(DECIMAL(12, 2), SUM(CASE WHEN CONVERT(DATE, N.FechaEntregado) BETWEEN '{0}' AND '{1}' THEN V.SubTotal ELSE 0 END)) /", ObtenerFecha(desdeMes, False), ObtenerFecha(hastaMes, False))
            .AppendFormatLine("       NULLIF(CONVERT(DECIMAL(12, 2), SUM(CASE WHEN CONVERT(DATE, N.FechaEntregado) BETWEEN '{0}' AND '{1}' THEN 1 ELSE 0 END)), 0)", ObtenerFecha(desdeMes, False), ObtenerFecha(hastaMes, False))
            For Each mes In mesesList
               .AppendFormatLine("     , CONVERT(DECIMAL(12, 2), SUM(CASE WHEN CONVERT(DATE, N.FechaEntregado) BETWEEN '{0}' AND '{1}' THEN V.SubTotal ELSE 0 END)) /", ObtenerFecha(mes.Item2, False), ObtenerFecha(mes.Item3, False))
               .AppendFormatLine("       NULLIF(CONVERT(DECIMAL(12, 2), SUM(CASE WHEN CONVERT(DATE, N.FechaEntregado) BETWEEN '{0}' AND '{1}' THEN 1 ELSE 0 END)), 0)", ObtenerFecha(mes.Item2, False), ObtenerFecha(mes.Item3, False))
            Next
            .AppendFormatLine("  FROM CRMNovedades N")
            .AppendFormatLine(" INNER JOIN Ventas V ON V.IdSucursal = N.IdSucursalFact")
            .AppendFormatLine("                    AND V.IdTipoComprobante = N.IdTipoComprobanteFact")
            .AppendFormatLine("                    AND V.Letra = N.LetraFact")
            .AppendFormatLine("                    AND V.CentroEmisor = N.CentroEmisorFact")
            .AppendFormatLine("                    AND V.NumeroComprobante = N.NumeroComprobanteFact")
            .AppendFormatLine("                    AND (V.IdEstadoComprobante IS NULL OR V.IdEstadoComprobante <> 'ANULADO')")
            .AppendFormatLine(" WHERE N.IdTipoNovedad = '{0}'", filtros.IdTipoNovedad)
            .AppendFormatLine("   AND N.FechaNovedad >= '{0}'", ObtenerFecha(desde, True))
         End If

      End With
      Return GetDataTable(stb)
   End Function

   'DEBO TOMAR ESTE QUERY PARA EL CONTROLADOR DE GRILLA GENERAL Y ARMAR UN CONTROLADOR DE GRILLA RESUMIDO PARA EL GENERAL
   Public Function GetClientesActualizaciones(filtros As Entidades.TablerosDeComando.FiltroTableros) As DataTable  'categorias As Entidades.Categoria(), actualizarAplicacion As Entidades.Publicos.SiNoTodos) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("SELECT 'DarkGray' as Color ")
         .AppendLine("      ,C.IdCliente")
         .AppendLine("      ,C.CodigoCliente")
         .AppendLine("      ,C.NombreCliente")
         .AppendLine("      ,C.NombreDeFantasia")
         .AppendLine("      ,C.IdCategoria")
         .AppendLine("      ,CAT.NombreCategoria")
         .AppendLine("      ,CA.NombreServidor")
         .AppendLine("      ,CA.BaseDatos")
         .AppendLine("      ,C.IdAplicacion ")
         .AppendLine("      ,C.Edicion")
         .AppendLine("      ,CA.Estado")
         .AppendLine("      ,CA.Activo")
         .AppendFormatLine("       ,{0}", ConvertirBitSiNo("CA", "Activo"))
         .AppendLine("      ,CA.FechaInicioActualizacion")
         .AppendLine("      ,CA.FechaFinActualizacion")
         .AppendLine("      ,CA.FechaEjecucion")
         .AppendLine("      ,CAT.ActualizarAplicacion")
         .AppendFormatLine("      ,{0}", ConvertirBitSiNo("CAT", "ActualizarAplicacion"))
         .AppendLine("  FROM  Clientes AS C ")
         .AppendLine("  LEFT JOIN Categorias AS CAT ON CAT.IdCategoria = C.IdCategoria")
         .AppendLine("  LEFT JOIN (SELECT CA.*")
         .AppendLine("               FROM ClientesActualizaciones CA")
         .AppendLine("              INNER JOIN (SELECT IdCliente, NombreServidor, BaseDatos, MAX(FechaEjecucion) FechaEjecucion")
         .AppendLine("                            FROM ClientesActualizaciones")
         .AppendLine("                           GROUP BY IdCliente, NombreServidor, BaseDatos) CA1 ON CA1.IdCliente = CA.IdCliente")
         .AppendLine("                                                                             AND CA1.NombreServidor = CA.NombreServidor")
         .AppendLine("                                                                             AND CA1.BaseDatos = CA.BaseDatos")
         .AppendLine("                                                                             AND CA1.FechaEjecucion = CA.FechaEjecucion")
         .AppendLine("                          ) CA")
         .AppendLine("            ON CA.IdCliente = C.IdCliente")
         .AppendLine(" WHERE 1 = 1")
         GetListaCategoriasMultiples(stb, filtros.Categorias, "C")
         If filtros.ActualizarAplicacion <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormat("   AND CAT.ActualizarAplicacion='{0}'", filtros.ActualizarAplicacion = Entidades.Publicos.SiNoTodos.SI)
         End If
         '.AppendLine("   AND C.CodigoCliente = 197")
         .AppendLine(" ORDER BY CAT.ControlaBackup DESC, ISNULL(CA.Estado, 'zzzz'), C.NombreCliente")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Sub EliminarClientesBackups(idCliente As Long,
                                      nombreServidor As String,
                                      baseDatos As String)
      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendLine("UPDATE CB SET Activo = 0 FROM ClientesBackups CB")
         .AppendFormatLine("     INNER JOIN Clientes C ON C.IdCliente = CB.IdCliente")
         .AppendLine("WHERE 1=1")
         .AppendFormatLine("  AND C.IdCliente = {0}", idCliente)
         .AppendFormatLine("  AND CB.NombreServidor = '{0}'", nombreServidor)
         .AppendFormatLine("  AND CB.BaseDatos = '{0}'", baseDatos)
      End With

      Me.Execute(query.ToString())
   End Sub
End Class