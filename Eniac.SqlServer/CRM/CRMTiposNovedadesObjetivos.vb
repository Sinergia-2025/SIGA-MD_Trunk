Public Class CRMTiposNovedadesObjetivos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CRMTiposNovedadesObjetivos_I(idTipoNovedad As String,
                                           periodoObjetivo As DateTime,
                                           idUsuarioActualizacion As String,
                                           fechaActualizacion As DateTime)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0} ", Entidades.CRMTipoNovedadObjetivo.NombreTabla)
         .AppendFormatLine("           ({0}, {1}, {2}, {3})",
                           Entidades.CRMTipoNovedadObjetivo.Columnas.IdTipoNovedad.ToString(),
                           Entidades.CRMTipoNovedadObjetivo.Columnas.PeriodoObjetivo.ToString(),
                           Entidades.CRMTipoNovedadObjetivo.Columnas.IdUsuarioActualizacion.ToString(),
                           Entidades.CRMTipoNovedadObjetivo.Columnas.FechaActualizacion.ToString())
         .AppendFormatLine("    VALUES ('{0}', {1}, '{2}', '{3}'",
                           idTipoNovedad,
                           periodoObjetivo.ToPeriodo(),
                           idUsuarioActualizacion,
                           ObtenerFecha(fechaActualizacion, True))
         .AppendLine(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub CRMTiposNovedadesObjetivos_U(idTipoNovedad As String,
                                           periodoObjetivo As DateTime,
                                           idUsuarioActualizacion As String,
                                           fechaActualizacion As DateTime)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0} ", Entidades.CRMTipoNovedadObjetivo.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.CRMTipoNovedadObjetivo.Columnas.IdUsuarioActualizacion.ToString(), idUsuarioActualizacion)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMTipoNovedadObjetivo.Columnas.FechaActualizacion.ToString(), ObtenerFecha(fechaActualizacion, True))
         .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.CRMTipoNovedadObjetivo.Columnas.IdTipoNovedad.ToString(), idTipoNovedad)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CRMTipoNovedadObjetivo.Columnas.PeriodoObjetivo.ToString(), periodoObjetivo.ToPeriodo())
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub CRMTiposNovedadesObjetivos_D(idTipoNovedad As String, periodoObjetivo As DateTime?)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormatLine("DELETE FROM {0}", Entidades.CRMTipoNovedadObjetivo.NombreTabla)
         .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.CRMTipoNovedadObjetivo.Columnas.IdTipoNovedad.ToString(), idTipoNovedad)
         If periodoObjetivo.HasValue Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.CRMTipoNovedadObjetivo.Columnas.PeriodoObjetivo.ToString(), periodoObjetivo.Value.ToPeriodo())
         End If
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT O.*")
         .AppendFormatLine("     , TN.NombreTipoNovedad")
         .AppendFormatLine("  FROM {0} AS O", Entidades.CRMTipoNovedadObjetivo.NombreTabla)
         .AppendFormatLine(" INNER JOIN CRMTiposNovedades AS TN ON TN.IdTipoNovedad = O.IdTipoNovedad")
      End With
   End Sub

   Public Function CRMTiposNovedadesObjetivos_GA() As DataTable
      Return CRMTiposNovedadesObjetivos_G(idTipoNovedad:=String.Empty, periodoObjetivo:=Nothing)
   End Function
   Public Function CRMTiposNovedadesObjetivos_GA(idTipoNovedad As String) As DataTable
      Return CRMTiposNovedadesObjetivos_G(idTipoNovedad, periodoObjetivo:=Nothing)
   End Function
   Public Function CRMTiposNovedadesObjetivos_GA(periodoObjetivo As DateTime?) As DataTable
      Return CRMTiposNovedadesObjetivos_G(idTipoNovedad:=String.Empty, periodoObjetivo:=periodoObjetivo)
   End Function
   Private Function CRMTiposNovedadesObjetivos_G(idTipoNovedad As String, periodoObjetivo As DateTime?) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendFormatLine(" WHERE 1 = 1")

         If Not String.IsNullOrWhiteSpace(idTipoNovedad) Then
            .AppendFormatLine("   AND O.{0} = '{1}'", Entidades.CRMTipoNovedadObjetivo.Columnas.IdTipoNovedad.ToString(), idTipoNovedad)
         End If
         If periodoObjetivo.HasValue Then
            .AppendFormatLine("   AND O.{0} =  {1} ", Entidades.CRMTipoNovedadObjetivo.Columnas.PeriodoObjetivo.ToString(), periodoObjetivo.Value.ToPeriodo())
         End If

      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function CRMTiposNovedadesObjetivos_G1(idTipoNovedad As String, periodoObjetivo As DateTime) As DataTable
      Return CRMTiposNovedadesObjetivos_G(idTipoNovedad, periodoObjetivo)
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable

      'If columna = "NombreTipoNovedad" Then
      '   columna = "TN." + columna
      columna = "O." + columna
      ''End If

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

End Class