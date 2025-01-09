Public Class TiposTurnos
   Inherits Comunes

   Public Sub New(da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub TiposTurnos_I(idTipoTurno As String,
                            nombreTipoTurno As String,
                            idTipoCalendario As Short)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO TiposTurnos ({0}, {1}, {2})",
                           Entidades.TipoTurno.Columnas.IdTipoTurno.ToString(),
                           Entidades.TipoTurno.Columnas.NombreTipoTurno.ToString(),
                           Entidades.TipoTurno.Columnas.IdTipoCalendario.ToString())
         .AppendFormatLine("     VALUES ('{0}', '{1}', {2})",
                       idTipoTurno, nombreTipoTurno, idTipoCalendario)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub TiposTurnos_U(idTipoTurno As String,
                            nombreTipoTurno As String,
                            idTipoCalendario As Short)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendLine("UPDATE TiposTurnos ")
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.TipoTurno.Columnas.NombreTipoTurno.ToString(), nombreTipoTurno)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.TipoTurno.Columnas.IdTipoCalendario.ToString(), idTipoCalendario)
         .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.TipoTurno.Columnas.IdTipoTurno.ToString(), idTipoTurno)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub TiposTurnos_D(idTipoTurno As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM TiposTurnos WHERE {0} = '{1}'", Entidades.TipoTurno.Columnas.IdTipoTurno.ToString(), idTipoTurno)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT TT.*, TC.NombreTipoCalendario")
         .AppendFormatLine("  FROM TiposTurnos AS TT")
         .AppendFormatLine(" INNER JOIN TiposCalendarios TC ON TC.IdTipoCalendario = TT.IdTipoCalendario")
      End With
   End Sub

   Public Function TiposTurnos_GA(idTipoCalendario As Short) As DataTable
      Return TiposTurnos_G(idTipoTurno:=String.Empty, idTipoCalendario:=idTipoCalendario, nombreTipoTurno:=String.Empty, nombreExacto:=False)
   End Function
   Private Function TiposTurnos_G(idTipoTurno As String, idTipoCalendario As Short, nombreTipoTurno As String, nombreExacto As Boolean) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If Not String.IsNullOrWhiteSpace(idTipoTurno) Then
            .AppendFormatLine("   AND TT.IdTipoTurno = '{0}'", idTipoTurno)
         End If
         If Not String.IsNullOrWhiteSpace(nombreTipoTurno) Then
            If nombreExacto Then
               .AppendFormatLine("   AND TT.NombreTipoTurno = '{0}'", nombreTipoTurno)
            Else
               .AppendFormatLine("   AND TT.NombreTipoTurno LIKE '%{0}%'", nombreTipoTurno)
            End If
         End If
         If idTipoCalendario > 0 Then
            .AppendFormatLine("   AND TT.IdTipoCalendario = {0}", idTipoCalendario)
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function TiposTurnos_GCombo() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE TT.IdTipoTurno <> 'T'")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function TiposTurnos_GxNombre(nombreTipoTurno As String) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendFormat("   WHERE TT.NombreTipoTurno = '{0}'", nombreTipoTurno).AppendLine()
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function TiposTurnos_G1(idTipoTurno As String) As DataTable
      Return TiposTurnos_G(idTipoTurno:=idTipoTurno, idTipoCalendario:=0, nombreTipoTurno:=String.Empty, nombreExacto:=False)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      If columna = "NombreTipoCalendario" Then
         columna = "TC." + columna
      Else
         columna = "TT." + columna
      End If
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(MyBase.GetCodigoMaximo(Entidades.TipoTurno.Columnas.IdTipoTurno.ToString(), "TiposTurnos"))
   End Function

End Class