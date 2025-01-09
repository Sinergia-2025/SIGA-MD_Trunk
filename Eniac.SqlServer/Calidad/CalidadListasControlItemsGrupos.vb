Public Class CalidadListasControlItemsGrupos
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CalidadListasControlItemsGrupos_I(idListaControlItemGrupo As String, nombreListaControlItemGrupo As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0} (", Entidades.CalidadListaControlItemGrupo.NombreTabla)
         .AppendFormatLine("     {0}", Entidades.CalidadListaControlItemGrupo.Columnas.IdListaControlItemGrupo.ToString())
         .AppendFormatLine("   , {0}", Entidades.CalidadListaControlItemGrupo.Columnas.NombreListaControlItemGrupo.ToString())
         .AppendFormatLine(") VALUES (")
         .AppendFormatLine("	   '{0}'", idListaControlItemGrupo)
         .AppendFormatLine("	 , '{0}'", nombreListaControlItemGrupo)
         .AppendFormatLine(")")
      End With
      Execute(myQuery)
   End Sub

   Public Sub CalidadListasControlItemsGrupos_U(idListaControlItemGrupo As String, nombreListaControlItemGrupo As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.CalidadListaControlItemGrupo.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.CalidadListaControlItemGrupo.Columnas.NombreListaControlItemGrupo.ToString(), nombreListaControlItemGrupo)
         .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.CalidadListaControlItemGrupo.Columnas.IdListaControlItemGrupo.ToString(), idListaControlItemGrupo)
      End With
      Execute(myQuery)
   End Sub

   Public Sub CalidadListasControlItemsGrupos_D(idListaControlItemGrupo As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0}", Entidades.CalidadListaControlItemGrupo.NombreTabla)
         .AppendFormat(" WHERE {0} = '{1}'", Entidades.CalidadListaControlItemGrupo.Columnas.IdListaControlItemGrupo.ToString(), idListaControlItemGrupo)
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT TA.*")
         .AppendFormatLine("  FROM {0} AS TA", Entidades.CalidadListaControlItemGrupo.NombreTabla)
      End With
   End Sub

   Public Function CalidadListasControlItemsGrupos_GA() As DataTable
      Return CalidadListasControlItemsGrupos_G(idListaControlItemGrupo:=Nothing, nombreListaControlItemGrupo:=String.Empty, nombreExacto:=False)
   End Function
   Private Function CalidadListasControlItemsGrupos_G(idListaControlItemGrupo As String, nombreListaControlItemGrupo As String, nombreExacto As Boolean) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendFormatLine(" WHERE 1 = 1")
         If Not String.IsNullOrWhiteSpace(idListaControlItemGrupo) Then
            .AppendFormatLine("   AND TA.{0} = '{1}'", Entidades.CalidadListaControlItemGrupo.Columnas.IdListaControlItemGrupo.ToString(), idListaControlItemGrupo)
         End If
         If Not String.IsNullOrWhiteSpace(nombreListaControlItemGrupo) Then
            If nombreExacto Then
               .AppendFormatLine("   AND TA.{0} = '{0}'", Entidades.CalidadListaControlItemGrupo.Columnas.NombreListaControlItemGrupo.ToString(), nombreListaControlItemGrupo)
            Else
               .AppendFormatLine("   AND TA.{0} LIKE '%{0}%'", Entidades.CalidadListaControlItemGrupo.Columnas.NombreListaControlItemGrupo.ToString(), nombreListaControlItemGrupo)
            End If
         End If
         .AppendFormatLine(" ORDER BY TA.NombreListaControlItemGrupo")
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function CalidadListasControlItemsGrupos_G1(idGrupoListaControlItem As String) As DataTable
      Return CalidadListasControlItemsGrupos_G(idListaControlItemGrupo:=idGrupoListaControlItem, nombreListaControlItemGrupo:=String.Empty, nombreExacto:=False)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "TA.")
   End Function

End Class