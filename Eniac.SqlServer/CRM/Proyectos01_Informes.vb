Option Infer On

Partial Class Proyectos

   Private Function GetColumnasPivot(formatoCampos As String,
                                     idTipoNovedad As String(),
                                     finalizado As Entidades.Publicos.SiNoTodos,
                                     idEstadoProyecto As Integer,
                                     idProyecto As Integer,
                                     idCliente As Long,
                                     idClasificacionProyecto As Integer,
                                     soloConNovedades As Boolean) As String
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT {0}", formatoCampos)
         .AppendFormatLine("  FROM (SELECT NP.IdTipoNovedad, NP.IdEstadoNovedad, EN.Posicion")
         .AppendFormatLine("          FROM CRMNovedades NP")
         .AppendFormatLine("         INNER JOIN CRMEstadosNovedades EN ON EN.IdEstadoNovedad = NP.IdEstadoNovedad")
         .AppendFormatLine("         INNER JOIN CRMTiposNovedades TN ON TN.IdTipoNovedad = NP.IdTipoNovedad")
         .AppendFormatLine("         {0} JOIN Proyectos P ON P.IdProyecto = NP.IdProyecto", If(soloConNovedades, "INNER", "LEFT"))
         .AppendFormatLine("         WHERE 1 = 1")

         GetListaMultiples(stb, idTipoNovedad, "NP", "IdTipoNovedad")

         If idEstadoProyecto <> 0 Then
            .AppendFormatLine("          AND P.IdEstado = {0}", idEstadoProyecto)
         End If
         If idClasificacionProyecto <> 0 Then
            .AppendFormatLine("          AND P.IdClasificacion = {0}", idClasificacionProyecto)
         End If
         If finalizado <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("           AND EN.Finalizado = '{0}'", finalizado = Entidades.Publicos.SiNoTodos.SI)
         End If
         If idProyecto > 0 Then
            .AppendFormatLine("           AND NP.IdProyecto = {0}", idProyecto)
         End If
         If idCliente > 0 Then
            .AppendFormatLine("           AND NP.IdCliente = {0}", idCliente)
         End If

         .AppendFormatLine("         GROUP BY NP.IdTipoNovedad, NP.IdEstadoNovedad, EN.Posicion")
         .AppendFormatLine("        ) NP")
         .AppendFormatLine("         ORDER BY NP.IdTipoNovedad, NP.Posicion")
         .AppendFormatLine("           FOR XML PATH('')")

         'Dim dt = GetDataTable(.ToString())

         Dim campos = DirectCast(ExecuteScalar(.ToString()), String)

         Return If(campos Is Nothing, campos, DirectCast(ExecuteScalar(.ToString()), String).Trim(","c))

      End With
   End Function

   Public Function GetNovedadesPorProyecto(idTipoNovedad As String(),
                                           proyectoFinalizado As Entidades.Publicos.SiNoTodos,
                                           finalizado As Entidades.Publicos.SiNoTodos,
                                           idEstadoProyecto As Integer,
                                           idProyecto As Integer,
                                           idCliente As Long,
                                           idClasificacionProyecto As Integer,
                                           soloConNovedades As Boolean,
                                           tipoUsuario As Integer) As DataTable

      Dim columnasPivot As String = GetColumnasPivot("QUOTENAME(NP.IdTipoNovedad + '/' + CONVERT(VARCHAR(MAX), NP.IdEstadoNovedad)) + ','",
                                                     idTipoNovedad, finalizado, idEstadoProyecto, idProyecto, idCliente, idClasificacionProyecto, soloConNovedades)
      Dim columnasPivotSum As String = GetColumnasPivot("'SUM(' + QUOTENAME(NP.IdTipoNovedad + '/' + CONVERT(VARCHAR(MAX), NP.IdEstadoNovedad)) + ') AS ' + QUOTENAME(NP.IdTipoNovedad + '/' + CONVERT(VARCHAR(MAX), NP.IdEstadoNovedad)) + ','",
                                                        idTipoNovedad, finalizado, idEstadoProyecto, idProyecto, idCliente, idClasificacionProyecto, soloConNovedades)

      'If String.IsNullOrWhiteSpace(columnasPivot) Then
      '   Throw New Exception("No hay novedades para evaluar")
      'End If

      Dim columnasPivotTipo = String.Join(",", idTipoNovedad.ToList().ConvertAll(Function(x) String.Format("[___{0}]", x)))
      Dim columnasPivotTipoSum = String.Join(",", idTipoNovedad.ToList().ConvertAll(Function(x) String.Format("SUM([___{0}]) AS [___{0}]", x)))

      Dim stb = New StringBuilder()

      With stb
         .Length = 0
         .AppendFormatLine("SELECT *")
         .AppendFormatLine("  FROM (")
         .AppendFormatLine("SELECT P.IdProyecto")
         .AppendFormatLine("     , P.NombreProyecto")
         .AppendFormatLine("     , P.IdEstado")
         .AppendFormatLine("     , P.IdPrioridadProyecto")
         .AppendFormatLine("     , E.NombreEstado")
         .AppendFormatLine("     , C.IdCliente")
         .AppendFormatLine("     , C.CodigoCliente")
         .AppendFormatLine("     , C.NombreCliente")
         .AppendFormatLine("     , C.NombreDeFantasia")
         .AppendFormatLine("     , CL.IdClasificacion")
         .AppendFormatLine("     , CL.NombreClasificacion")
         .AppendFormatLine("     , NP.TipoEstadoNovedad")

         .AppendFormatLine("      ,P.FechaInicio")
         .AppendFormatLine("      ,P.FechaFin")
         .AppendFormatLine("      ,P.FechaFinReal")
         .AppendFormatLine("      ,P.Estimado")
         .AppendFormatLine("      ,P.HsRealEstimadas")
         .AppendFormatLine("      ,P.HsInformadas")
         .AppendFormatLine("      ,ISNULL((SELECT SUM(H.Cantidad) FROM CRMNovedades H WHERE H.IdProyecto   = P.IdProyecto), 0) CantidadHorasHijos")
         .AppendFormatLine("      ,P.Estimado - ISNULL((SELECT SUM(H.Cantidad) FROM CRMNovedades H WHERE H.IdProyecto   = P.IdProyecto), 0) AS DifHSCobradas")
         .AppendFormatLine("      ,P.HsInformadas - ISNULL((SELECT SUM(H.Cantidad) FROM CRMNovedades H WHERE H.IdProyecto   = P.IdProyecto), 0) AS DifHSInformadas")

         .AppendFormatLine("     , NP.Cantidad")
         For Each item In idTipoNovedad
            .AppendFormatLine("     , (SELECT COUNT(1) FROM CRMNovedades WHERE IdProyecto = NP.IdProyecto AND IdTipoNovedad = '{0}') AS ___{0}_TOTALES_", item)
         Next
         .AppendFormatLine("  FROM Proyectos P")
         .AppendFormatLine(" INNER JOIN Clientes C ON C.IdCliente = P.IdCliente")
         .AppendFormatLine(" INNER JOIN Clasificaciones CL ON CL.IdClasificacion = P.IdClasificacion")
         .AppendFormatLine(" INNER JOIN ProyectosEstados E ON E.IdEstado = P.IdEstado")
         .AppendFormatLine(" {0} JOIN (SELECT NP.IdProyecto, NP.IdEstadoNovedad, NP.IdTipoNovedad + '/' + CONVERT(VARCHAR(MAX), NP.IdEstadoNovedad) AS TipoEstadoNovedad, COUNT(1) Cantidad",
                           If(soloConNovedades, "INNER", "LEFT"))
         .AppendFormatLine("               FROM CRMNovedades NP")
         .AppendFormatLine("              INNER JOIN CRMEstadosNovedades EN ON EN.IdEstadoNovedad = NP.IdEstadoNovedad")

         '-- REQ-30963 --
         If tipoUsuario > 0 Then
            .AppendFormatLine("           INNER JOIN Usuarios AS UG ON UG.Id = NP.IdUsuarioAsignado")

         End If

         .AppendFormatLine("              INNER JOIN CRMTiposNovedades TN ON TN.IdTipoNovedad = NP.IdTipoNovedad")
         .AppendFormatLine("               LEFT JOIN Proyectos P ON P.IdProyecto = NP.IdProyecto")
         .AppendFormatLine("              WHERE 1 = 1")

         GetListaMultiples(stb, idTipoNovedad, "NP", "IdTipoNovedad")

         If idEstadoProyecto <> 0 Then
            .AppendFormatLine("                AND P.IdEstado = {0}", idEstadoProyecto)
         End If
         If idClasificacionProyecto <> 0 Then
            .AppendFormatLine("                AND P.IdClasificacion = {0}", idClasificacionProyecto)
         End If
         If finalizado <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("                AND EN.Finalizado = '{0}'", finalizado = Entidades.Publicos.SiNoTodos.SI)
         End If
         If idProyecto > 0 Then
            .AppendFormatLine("                AND NP.IdProyecto = {0}", idProyecto)
         End If
         If idCliente > 0 Then
            .AppendFormatLine("                AND NP.IdCliente = {0}", idCliente)
         End If

         '-- REQ-30963 --
         If tipoUsuario > 0 Then
            .AppendFormatLine("                AND UG.TipoUsuario = {0}", tipoUsuario)
         End If


         .AppendFormatLine("              GROUP BY NP.IdProyecto, NP.IdEstadoNovedad, NP.IdTipoNovedad, NP.IdEstadoNovedad) NP ON NP.IdProyecto = P.IdProyecto")
         .AppendFormatLine(" WHERE 1 = 1")

         If proyectoFinalizado <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("   And E.Finalizado = '{0}'", proyectoFinalizado = Entidades.Publicos.SiNoTodos.SI)
         End If

         If idEstadoProyecto <> 0 Then
            .AppendFormatLine("   AND P.IdEstado = {0}", idEstadoProyecto)
         End If
         If idClasificacionProyecto <> 0 Then
            .AppendFormatLine("   AND P.IdClasificacion = {0}", idClasificacionProyecto)
         End If
         If idProyecto > 0 Then
            .AppendFormatLine("   AND P.IdProyecto = {0}", idProyecto)
         End If
         If idCliente > 0 Then
            .AppendFormatLine("   AND P.IdCliente = {0}", idCliente)
         End If
         .AppendFormatLine(" ) AS NP")
         If Not String.IsNullOrWhiteSpace(columnasPivot) Then
            .AppendFormatLine(" PIVOT(SUM(NP.Cantidad) FOR NP.TipoEstadoNovedad IN ({0})) AS NP", columnasPivot)
         End If

         .AppendFormatLine(" ORDER BY NP.IdPrioridadProyecto, NP.NombreDeFantasia")

      End With

      Return GetDataTable(stb.ToString())

   End Function

End Class