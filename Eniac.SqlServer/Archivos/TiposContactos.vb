Public Class TiposContactos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub TiposContactos_I(ByVal IdTipoContacto As Integer, _
                       ByVal NombreTipoContacto As String, _
                       ByVal NombreAbrevTipoContacto As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("INSERT INTO  ")
         .Append("TiposContactos  ")
         .Append("(IdTipoContacto, ")
         .Append("NombreTipoContacto, ")
         .Append("NombreAbrevTipoContacto ")
         .Append(") VALUES (")
         .Append(IdTipoContacto & ", ")
         .Append("'" & NombreTipoContacto & "', ")
         .Append("'" & NombreAbrevTipoContacto.ToString() & "') ")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "TiposContactos")
   End Sub

   Public Sub TiposContactos_U(ByVal IdTipoContacto As Integer, _
                       ByVal NombreTipoContacto As String, _
                       ByVal NombreAbrevTipoContacto As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("UPDATE  ")
         .Append("TiposContactos  ")
         .Append("SET  ")

         .Append("NombreTipoContacto = '" & NombreTipoContacto & "', ")
         .Append("NombreAbrevTipoContacto = '" & NombreAbrevTipoContacto.ToString() & "'")

         .Append("WHERE ")
         .Append("IdTipoContacto = " & IdTipoContacto)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "TiposContactos")
   End Sub

   Public Sub TiposContactos_D(ByVal IdTipoContacto As Integer)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("DELETE FROM  ")
         .Append("TiposContactos  ")
         .Append("WHERE  ")
         .Append("IdTipoContacto = " & IdTipoContacto)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "TiposContactos")
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Length = 0
         .AppendLine("SELECT TD.IdTipoContacto")
         .AppendLine("      ,TD.NombreTipoContacto")
         .AppendLine("      ,TD.NombreAbrevTipoContacto")
         .AppendLine("  FROM TiposContactos TD ")
      End With
   End Sub

   Public Function TiposContactos_GA() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" ORDER BY TD.NombreTipoContacto ")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function TiposContactos_G1(ByVal IdTipoContacto As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE TD.IdTipoContacto = " & IdTipoContacto.ToString())
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

End Class
