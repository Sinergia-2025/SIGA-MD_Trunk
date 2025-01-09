Public Class FichasFormasPago
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub FichasFormasPago_I(ByVal idFormasPago As Integer, _
                            ByVal descripcionFormasPago As String, _
                            ByVal dias As Integer)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("INSERT INTO  ")
         .Append("FichasFormasPago  ")
         .Append("(IdFormasPago, ")
         .Append("DescripcionFormasPago, ")
         .Append("Dias)  ")
         .Append("VALUES(")
         .Append(idFormasPago & ", ")
         .Append("'" & descripcionFormasPago & "', ")
         .Append(dias & ") ")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "FichasFormasPago")
   End Sub

   Public Sub FichasFormasPago_U(ByVal idFormasPago As Integer, _
                               ByVal descripcionFormasPago As String, _
                               ByVal dias As Integer)
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Append("UPDATE  ")
         .Append("FichasFormasPago  ")
         .Append("SET  ")

         .Append("DescripcionFormasPago = '" & descripcionFormasPago & "', ")
         .Append("Dias = " & dias)

         .Append("WHERE ")
         .Append("IdFormasPago = " & idFormasPago)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "FichasFormasPago")
   End Sub

   Public Sub FichasFormasPago_D(ByVal idFormasPago As Integer)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("DELETE FROM  ")
         .Append("FichasFormasPago  ")
         .Append("WHERE  ")
         .Append("IdFormasPago = " & idFormasPago)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "FichasFormasPago")
   End Sub

   Public Function FichasFormasPago_GA() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Append("SELECT  ")
         .Append("* ")
         .Append("FROM FichasFormasPago ")
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function

End Class
