Public Class CRMTiposNovedadesObjetivosUsuarios
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CRMTiposNovedadesObjetivosUsuarios_I(idTipoNovedad As String,
                                                   periodoObjetivo As DateTime,
                                                   idUsuario As String,
                                                   objetivo As Decimal,
                                                   objetivoMinimo As Decimal)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0} ", Entidades.CRMTipoNovedadObjetivoUsuario.NombreTabla)
         .AppendFormatLine("           ({0}, {1}, {2}, {3}, {4})",
                           Entidades.CRMTipoNovedadObjetivoUsuario.Columnas.IdTipoNovedad.ToString(),
                           Entidades.CRMTipoNovedadObjetivoUsuario.Columnas.PeriodoObjetivo.ToString(),
                           Entidades.CRMTipoNovedadObjetivoUsuario.Columnas.IdUsuario.ToString(),
                           Entidades.CRMTipoNovedadObjetivoUsuario.Columnas.Objetivo.ToString(),
                           Entidades.CRMTipoNovedadObjetivoUsuario.Columnas.ObjetivoMinimo.ToString())
         .AppendFormatLine("    VALUES ('{0}', {1}, '{2}', {3}, {4}",
                           idTipoNovedad,
                           periodoObjetivo.ToPeriodo(),
                           idUsuario,
                           objetivo,
                           objetivoMinimo)
         .AppendLine(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub CRMTiposNovedadesObjetivosUsuarios_U(idTipoNovedad As String,
                                                   periodoObjetivo As DateTime,
                                                   idUsuario As String,
                                                   objetivo As Decimal,
                                                   objetivoMinimo As Decimal)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0} ", Entidades.CRMTipoNovedadObjetivoUsuario.NombreTabla)
         .AppendFormatLine("   SET {0} =  {1} ", Entidades.CRMTipoNovedadObjetivoUsuario.Columnas.Objetivo.ToString(), objetivo)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMTipoNovedadObjetivoUsuario.Columnas.ObjetivoMinimo.ToString(), objetivoMinimo)
         .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.CRMTipoNovedadObjetivoUsuario.Columnas.IdTipoNovedad.ToString(), idTipoNovedad)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CRMTipoNovedadObjetivoUsuario.Columnas.PeriodoObjetivo.ToString(), periodoObjetivo.ToPeriodo())
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.CRMTipoNovedadObjetivoUsuario.Columnas.IdUsuario.ToString(), idUsuario)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub CRMTiposNovedadesObjetivosUsuarios_D(idTipoNovedad As String, periodoObjetivo As DateTime?, idUsuario As String)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormatLine("DELETE FROM {0}", Entidades.CRMTipoNovedadObjetivoUsuario.NombreTabla)
         .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.CRMTipoNovedadObjetivoUsuario.Columnas.IdTipoNovedad.ToString(), idTipoNovedad)
         If periodoObjetivo.HasValue Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.CRMTipoNovedadObjetivoUsuario.Columnas.PeriodoObjetivo.ToString(), periodoObjetivo.Value.ToPeriodo())
         End If
         If Not String.IsNullOrWhiteSpace(idUsuario) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.CRMTipoNovedadObjetivoUsuario.Columnas.IdUsuario.ToString(), idUsuario)
         End If
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT OU.*")
         .AppendFormatLine("     , U.Nombre NombreUsuario")
         .AppendFormatLine("  FROM {0} AS OU", Entidades.CRMTipoNovedadObjetivoUsuario.NombreTabla)
         .AppendFormatLine(" INNER JOIN Usuarios U ON U.Id = OU.IdUsuario")
      End With
   End Sub

   Public Function CRMTiposNovedadesObjetivosUsuarios_GA() As DataTable
      Return CRMTiposNovedadesObjetivosUsuarios_G(idTipoNovedad:=String.Empty, periodoObjetivo:=Nothing, idUsuario:=String.Empty)
   End Function
   Public Function CRMTiposNovedadesObjetivosUsuarios_GA(idTipoNovedad As String) As DataTable
      Return CRMTiposNovedadesObjetivosUsuarios_G(idTipoNovedad, periodoObjetivo:=Nothing, idUsuario:=String.Empty)
   End Function
   Public Function CRMTiposNovedadesObjetivosUsuarios_GA(periodoObjetivo As DateTime?) As DataTable
      Return CRMTiposNovedadesObjetivosUsuarios_G(idTipoNovedad:=String.Empty, periodoObjetivo:=periodoObjetivo, idUsuario:=String.Empty)
   End Function
   Public Function CRMTiposNovedadesObjetivosUsuarios_GA(idTipoNovedad As String, periodoObjetivo As DateTime?) As DataTable
      Return CRMTiposNovedadesObjetivosUsuarios_G(idTipoNovedad, periodoObjetivo, idUsuario:=String.Empty)
   End Function
   Private Function CRMTiposNovedadesObjetivosUsuarios_G(idTipoNovedad As String, periodoObjetivo As DateTime?, idUsuario As String) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendFormatLine(" WHERE 1 = 1")

         If Not String.IsNullOrWhiteSpace(idTipoNovedad) Then
            .AppendFormatLine("   AND OU.{0} = '{1}'", Entidades.CRMTipoNovedadObjetivoUsuario.Columnas.IdTipoNovedad.ToString(), idTipoNovedad)
         End If
         If periodoObjetivo.HasValue Then
            .AppendFormatLine("   AND OU.{0} =  {1} ", Entidades.CRMTipoNovedadObjetivoUsuario.Columnas.PeriodoObjetivo.ToString(), periodoObjetivo.Value.ToPeriodo())
         End If
         If Not String.IsNullOrWhiteSpace(idUsuario) Then
            .AppendFormatLine("   AND OU.{0} = '{1}'", Entidades.CRMTipoNovedadObjetivoUsuario.Columnas.IdUsuario.ToString(), idUsuario)
         End If

      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function CRMTiposNovedadesObjetivosUsuarios_G1(idTipoNovedad As String, periodoObjetivo As DateTime, idUsuario As String) As DataTable
      Return CRMTiposNovedadesObjetivosUsuarios_G(idTipoNovedad, periodoObjetivo, idUsuario)
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable

      'If columna = "NombreTipoNovedad" Then
      '   columna = "TN." + columna
      columna = "OU." + columna
      ''End If

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

End Class