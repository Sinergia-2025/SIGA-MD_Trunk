Public Class RubrosCompras
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub RubrosCompras_I(ByVal idRubro As Integer, _
                              ByVal nombreRubro As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("INSERT INTO RubrosCompras")
         .AppendLine(" (IdRubro")
         .AppendLine(" ,NombreRubro")
         .AppendLine(" ) VALUES ( ")
         .AppendLine(idRubro.ToString())
         .AppendLine(" ,'" & nombreRubro & "'")
         .AppendLine(" )")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "RubrosCompras")

   End Sub

   Public Sub RubrosCompras_U(ByVal idRubro As Integer, _
                              ByVal nombreRubro As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("UPDATE RubrosCompras ")
         .AppendLine("  SET nombreRubro = '" & nombreRubro & "' ")
         .AppendLine(" WHERE idRubro = " & idRubro.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "RubrosCompras")

   End Sub

   Public Sub RubrosCompras_D(ByVal idRubro As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("DELETE FROM RubrosCompras  ")
         .Append(" WHERE idRubro = " & idRubro.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "RubrosCompras")

   End Sub

   Public Function RubrosCompras_GA() As DataTable

      Dim myQuery As StringBuilder = New StringBuilder("")

      Me.SelectFiltrado(myQuery)

      With myQuery
         .AppendLine(" ORDER BY R.NombreRubro")
      End With

      Return Me.GetDataTable(myQuery.ToString())

   End Function

   Private Sub SelectFiltrado(ByRef stb As StringBuilder)

      With stb
         .Length = 0
         .AppendLine("SELECT R.IdRubro")
         .AppendLine("      ,R.NombreRubro")
         .AppendLine("  FROM RubrosCompras R")
      End With

   End Sub

End Class
