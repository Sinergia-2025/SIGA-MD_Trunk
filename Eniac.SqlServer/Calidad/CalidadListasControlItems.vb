Public Class CalidadListasControlItems
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CalidadListasControlItems_I(idListaControlItem As Integer, nombreListaControlItem As String,
                                          idListaControlItemGrupo As String, idListaControlItemSubGrupo As String,
                                          nivelInspeccion As Entidades.NivelInspeccionMRP, valorAQL As Decimal, observacion As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0} (", Entidades.CalidadListaControlItem.NombreTabla)
         .AppendFormatLine("     {0}", Entidades.CalidadListaControlItem.Columnas.IdListaControlItem.ToString())
         .AppendFormatLine("   , {0}", Entidades.CalidadListaControlItem.Columnas.NombreListaControlItem.ToString())
         .AppendFormatLine("   , {0}", Entidades.CalidadListaControlItem.Columnas.IdListaControlItemGrupo.ToString())
         .AppendFormatLine("   , {0}", Entidades.CalidadListaControlItem.Columnas.IdListaControlItemSubGrupo.ToString())
         .AppendFormatLine("   , {0}", Entidades.CalidadListaControlItem.Columnas.NivelInspeccion.ToString())
         .AppendFormatLine("   , {0}", Entidades.CalidadListaControlItem.Columnas.ValorAQL.ToString())
         .AppendFormatLine("   , {0}", Entidades.CalidadListaControlItem.Columnas.Observacion.ToString())
         .AppendFormatLine(") VALUES (")
         .AppendFormatLine("	    {0} ", idListaControlItem)
         .AppendFormatLine("	 , '{0}'", nombreListaControlItem)
         .AppendFormatLine("	 , '{0}'", idListaControlItemGrupo)
         .AppendFormatLine("	 ,  {0} ", GetStringParaQueryConComillas(idListaControlItemSubGrupo))
         .AppendFormatLine("	 , '{0}'", nivelInspeccion.ToString())
         .AppendFormatLine("	 ,  {0} ", valorAQL)
         .AppendFormatLine("	 , '{0}'", observacion)
         .AppendFormatLine(")")
      End With
      Execute(myQuery)
   End Sub

   Public Sub CalidadListasControlItems_U(idListaControlItem As Integer, nombreListaControlItem As String,
                                          idListaControlItemGrupo As String, idListaControlItemSubGrupo As String,
                                          nivelInspeccion As Entidades.NivelInspeccionMRP, valorAQL As Decimal, observacion As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE CalidadListasControlItems ")
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.CalidadListaControlItem.Columnas.NombreListaControlItem.ToString(), nombreListaControlItem.Trim())
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CalidadListaControlItem.Columnas.IdListaControlItemGrupo.ToString(), idListaControlItemGrupo)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CalidadListaControlItem.Columnas.IdListaControlItemSubGrupo.ToString(), GetStringParaQueryConComillas(idListaControlItemSubGrupo))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CalidadListaControlItem.Columnas.NivelInspeccion.ToString(), nivelInspeccion.ToString())
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CalidadListaControlItem.Columnas.ValorAQL.ToString(), valorAQL)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CalidadListaControlItem.Columnas.Observacion.ToString(), observacion)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.CalidadListaControlItem.Columnas.IdListaControlItem.ToString(), idListaControlItem)
      End With
      Execute(myQuery)
   End Sub

   Public Sub CalidadListasControlItems_D(idListaControlItem As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0}", Entidades.CalidadListaControlItem.NombreTabla)
         .AppendFormat(" WHERE {0} = '{1}'", Entidades.CalidadListaControlItem.Columnas.IdListaControlItem.ToString(), idListaControlItem)
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("SELECT TA.*")
         .AppendLine("     , LCG.NombreListaControlItemGrupo")
         .AppendLine("     , LCSG.NombreListaControlItemSubGrupo")
         .AppendLine("  FROM CalidadListasControlItems AS TA")
         .AppendLine("  LEFT JOIN CalidadListasControlItemsGrupos LCG ON LCG.IdListaControlItemGrupo = TA.IdListaControlItemGrupo")
         .AppendLine("  LEFT JOIN CalidadListasControlItemsSubGrupos LCSG")
         .AppendLine("         ON LCSG.IdListaControlItemGrupo = TA.IdListaControlItemGrupo")
         .AppendLine("        AND LCSG.IdListaControlItemSubGrupo = TA.IdListaControlItemSubGrupo")
      End With
   End Sub

   Public Function CalidadListasControlItems_GA() As DataTable
      Return CalidadListasControlItems_G(idListaControlItem:=Nothing, nombreListaControlItem:=String.Empty, nombreExacto:=False)
   End Function
   Public Function CalidadListasControlItems_G1(idListaControlItem As Integer) As DataTable
      Return CalidadListasControlItems_G(idListaControlItem, nombreListaControlItem:=String.Empty, nombreExacto:=False)
   End Function
   Private Function CalidadListasControlItems_G(idListaControlItem As Integer, nombreListaControlItem As String, nombreExacto As Boolean) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendFormatLine(" WHERE 1 = 1")
         If idListaControlItem <> 0 Then
            .AppendFormatLine("   AND TA.idListaControlItem = '{0}'", idListaControlItem)
         End If
         If Not String.IsNullOrWhiteSpace(nombreListaControlItem) Then
            If nombreExacto Then
               .AppendFormatLine("   AND TA.NombreListaControlItem = '{0}'", nombreListaControlItem)
            Else
               .AppendFormatLine("   AND TA.NombreListaControlItem LIKE '%{0}%'", nombreListaControlItem)
            End If
         End If
         .AppendLine(" ORDER BY TA.NombreListaControlItem")
      End With
      Return GetDataTable(myQuery)
   End Function


   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb1) SelectTexto(stb1), "TA.",
                    New Dictionary(Of String, String) From {{"NombreListaControlItemGrupo", "LCG.NombreListaControlItemGrupo"},
                                                            {"NombreListaControlItemSubGrupo", "LCSG.NombreListaControlItemSubGrupo"}})
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return GetCodigoMaximo(Entidades.CalidadListaControlItem.Columnas.IdListaControlItem.ToString(), Entidades.CalidadListaControlItem.NombreTabla).ToInteger()
   End Function

End Class