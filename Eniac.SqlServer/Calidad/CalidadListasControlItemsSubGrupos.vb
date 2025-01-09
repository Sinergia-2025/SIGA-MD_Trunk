Public Class CalidadListasControlItemsSubGrupos
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CalidadListasControlItemsSubGrupos_I(idListaControlItemGrupo As String, idListaControlItemSubGrupo As String, nombreListaControlItemSubGrupo As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0} (", Entidades.CalidadListaControlItemSubGrupo.NombreTabla)
         .AppendFormatLine("     {0}", Entidades.CalidadListaControlItemSubGrupo.Columnas.IdListaControlItemGrupo.ToString())
         .AppendFormatLine("   , {0}", Entidades.CalidadListaControlItemSubGrupo.Columnas.IdListaControlItemSubGrupo.ToString())
         .AppendFormatLine("   , {0}", Entidades.CalidadListaControlItemSubGrupo.Columnas.NombreListaControlItemSubGrupo.ToString())
         .AppendFormatLine(") VALUES (")
         .AppendFormatLine("	   '{0}'", idListaControlItemGrupo)
         .AppendFormatLine("	 , '{0}'", idListaControlItemSubGrupo)
         .AppendFormatLine("	 , '{0}'", nombreListaControlItemSubGrupo)
         .AppendFormatLine(")")
      End With
      Execute(myQuery)
   End Sub
   Public Sub CalidadListasControlItemsSubGrupos_U(idListaControlItemGrupo As String, idListaControlItemSubGrupo As String, nombreListaControlItemSubGrupo As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.CalidadListaControlItemSubGrupo.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.CalidadListaControlItemSubGrupo.Columnas.NombreListaControlItemSubGrupo.ToString(), nombreListaControlItemSubGrupo)
         .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.CalidadListaControlItemSubGrupo.Columnas.IdListaControlItemGrupo.ToString(), idListaControlItemGrupo)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.CalidadListaControlItemSubGrupo.Columnas.IdListaControlItemSubGrupo.ToString(), idListaControlItemSubGrupo)
      End With
      Execute(myQuery)
   End Sub
   Public Sub CalidadListasControlItemsSubGrupos_D(idListaControlItemGrupo As String, idListaControlItemSubGrupo As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0}", Entidades.CalidadListaControlItemSubGrupo.NombreTabla)
         .AppendFormat(" WHERE {0} = '{1}'", Entidades.CalidadListaControlItemSubGrupo.Columnas.IdListaControlItemGrupo.ToString(), idListaControlItemGrupo)
         .AppendFormat("   AND {0} = '{1}'", Entidades.CalidadListaControlItemSubGrupo.Columnas.IdListaControlItemSubGrupo.ToString(), idListaControlItemSubGrupo)
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT CSG.*")
         .AppendFormatLine("     , CG.NombreListaControlItemGrupo")
         .AppendFormatLine("  FROM {0} AS CSG", Entidades.CalidadListaControlItemSubGrupo.NombreTabla)
         .AppendFormatLine(" INNER JOIN CalidadListasControlItemsGrupos AS CG ON CG.IdListaControlItemGrupo = CSG.IdListaControlItemGrupo")
      End With
   End Sub

   Public Function CalidadListasControlItemsSubGrupos_GA() As DataTable
      Return CalidadListasControlItemsSubGrupos_G(idListaControlItemGrupo:=String.Empty, idListaControlItemSubGrupo:=String.Empty, nombreListaControlItemSubGrupo:=String.Empty, nombreExacto:=False)
   End Function
   Public Function CalidadListasControlItemsSubGrupos_GA(idListaControlItemGrupo As String) As DataTable
      Return CalidadListasControlItemsSubGrupos_G(idListaControlItemGrupo, idListaControlItemSubGrupo:=String.Empty, nombreListaControlItemSubGrupo:=String.Empty, nombreExacto:=False)
   End Function
   Public Function CalidadListasControlItemsSubGrupos_G1(idGrupoListaControlItem As String, idSubGrupoListaControlItem As String) As DataTable
      Return CalidadListasControlItemsSubGrupos_G(idGrupoListaControlItem, idSubGrupoListaControlItem, nombreListaControlItemSubGrupo:=String.Empty, nombreExacto:=False)
   End Function
   Private Function CalidadListasControlItemsSubGrupos_G(idListaControlItemGrupo As String, idListaControlItemSubGrupo As String, nombreListaControlItemSubGrupo As String, nombreExacto As Boolean) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendFormatLine(" WHERE 1 = 1")
         If Not String.IsNullOrWhiteSpace(idListaControlItemGrupo) Then
            .AppendFormatLine("   AND CSG.{0} = '{1}'", Entidades.CalidadListaControlItemSubGrupo.Columnas.IdListaControlItemGrupo.ToString(), idListaControlItemGrupo)
         End If
         If Not String.IsNullOrWhiteSpace(idListaControlItemSubGrupo) Then
            .AppendFormatLine("   AND CSG.{0} = '{1}'", Entidades.CalidadListaControlItemSubGrupo.Columnas.IdListaControlItemSubGrupo.ToString(), idListaControlItemSubGrupo)
         End If
         If Not String.IsNullOrWhiteSpace(nombreListaControlItemSubGrupo) Then
            If nombreExacto Then
               .AppendFormatLine("   AND CSG.{0} = '{1}'", Entidades.CalidadListaControlItemSubGrupo.Columnas.NombreListaControlItemSubGrupo.ToString(), nombreListaControlItemSubGrupo)
            Else
               .AppendFormatLine("   AND CSG.{0} LIKE '%{1}%'", Entidades.CalidadListaControlItemSubGrupo.Columnas.NombreListaControlItemSubGrupo.ToString(), nombreListaControlItemSubGrupo)
            End If
         End If
         .AppendFormatLine(" ORDER BY CG.NombreListaControlItemGrupo, CSG.NombreListaControlItemSubGrupo")
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb1) SelectTexto(stb1), "CSG.",
                    New Dictionary(Of String, String) From {{"NombreListaControlItemGrupo", "CG.NombreListaControlItemGrupo"}})
   End Function

End Class