Public Class RubrosConceptos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub RubrosConceptos_I(ByVal idRubroConcepto As Integer, _
                                ByVal nombreRubroConcepto As String)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("INSERT INTO RubrosConceptos  ")
         .AppendLine("  (IdRubroConcepto, ")
         .AppendLine("   NombreRubroConcepto)  ")
         .AppendLine(" VALUES (")
         .AppendLine(idRubroConcepto & ", ")
         .AppendLine("'" & nombreRubroConcepto & "') ")
      End With

      Me.Execute(myQuery.ToString())
      'Me.Sincroniza_I(myQuery.ToString(), "RubrosConceptos")
   End Sub

   Public Sub RubrosConceptos_U(ByVal idRubroConcepto As Integer, _
                                ByVal nombreRubroConcepto As String)
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Length = 0
         .AppendLine("UPDATE RubrosConceptos SET ")
         .AppendLine("   nombreRubroConcepto = '" & nombreRubroConcepto & "' ")
         .AppendLine(" WHERE idRubroConcepto = " & idRubroConcepto)
      End With

      Me.Execute(myQuery.ToString())
      'Me.Sincroniza_I(myQuery.ToString(), "RubrosConceptos")
   End Sub

   Public Sub RubrosConceptos_D(ByVal idRubroConcepto As Integer)
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Length = 0
         .AppendLine("DELETE FROM RubrosConceptos  ")
         .AppendLine(" WHERE idRubroConcepto = " & idRubroConcepto)
      End With
      Me.Execute(myQuery.ToString())
      'Me.Sincroniza_I(myQuery.ToString(), "RubrosConceptos")
   End Sub

   Public Function RubrosConceptos_GA() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Length = 0
         .AppendLine("SELECT R.IdRubroConcepto, ")
         .AppendLine("       R.NombreRubroConcepto ")
         .AppendLine("  FROM RubrosConceptos R ")
         .AppendLine(" ORDER BY R.NombreRubroConcepto ")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

End Class
