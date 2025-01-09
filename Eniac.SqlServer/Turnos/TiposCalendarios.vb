Public Class TiposCalendarios
   Inherits Comunes

   Public Sub New(da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub TiposCalendarios_I(idTipoCalendario As Short,
                                 nombreTipoCalendario As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO TiposCalendarios ({0}, {1})",
                           Entidades.TipoCalendario.Columnas.IdTipoCalendario.ToString(),
                           Entidades.TipoCalendario.Columnas.NombreTipoCalendario.ToString())
         .AppendFormatLine("     VALUES ({0}, '{1}')",
                           idTipoCalendario, nombreTipoCalendario)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub TiposCalendarios_U(idTipoCalendario As Short,
                                 nombreTipoCalendario As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE TiposCalendarios ")
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.TipoCalendario.Columnas.NombreTipoCalendario.ToString(), nombreTipoCalendario)
         .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.TipoCalendario.Columnas.IdTipoCalendario.ToString(), idTipoCalendario)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub TiposCalendarios_D(idTipoCalendario As Short)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM TiposCalendarios WHERE {0} = {1}", Entidades.TipoCalendario.Columnas.IdTipoCalendario.ToString(), idTipoCalendario)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT TC.* FROM TiposCalendarios AS TC")
      End With
   End Sub

   Public Function TiposCalendarios_GA() As DataTable
      Return TiposCalendarios_G(idTipoCalendario:=0, nombreTipoCalendario:=String.Empty, nombreExacto:=False)
   End Function
   Private Function TiposCalendarios_G(idTipoCalendario As Short, nombreTipoCalendario As String, nombreExacto As Boolean) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendFormatLine(" WHERE 1 = 1")
         If idTipoCalendario > 0 Then
            .AppendFormatLine("   AND TC.IdTipoCalendario = {0}", idTipoCalendario)
         End If
         If Not String.IsNullOrWhiteSpace(nombreTipoCalendario) Then
            If nombreExacto Then
               .AppendFormatLine("   AND TC.NombreTipoCalendario = '{0}'", nombreTipoCalendario)
            Else
               .AppendFormatLine("   AND TC.NombreTipoCalendario LIKE '%{0}%'", nombreTipoCalendario)
            End If
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function TiposCalendarios_G1(idTipoCalendario As Short) As DataTable
      Return TiposCalendarios_G(idTipoCalendario:=idTipoCalendario, nombreTipoCalendario:=String.Empty, nombreExacto:=False)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      'If columna = "NombreSucursal" Then
      '   columna = "S." + columna
      'Else
      columna = "TC." + columna
      'End If
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo() As Short
      Return Convert.ToInt16(MyBase.GetCodigoMaximo(Entidades.TipoCalendario.Columnas.IdTipoCalendario.ToString(), "TiposCalendarios"))
   End Function
End Class
