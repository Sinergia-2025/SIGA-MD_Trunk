Public Class VentasPeriodos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub VentasPeriodos_I(ByVal idPeriodo As Integer, _
                                  ByVal descripcionPeriodo As String, _
                                  ByVal dias As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("INSERT INTO  ")
         .Append("VentasPeriodos ")
         .Append("(IdPeriodo, ")
         .Append("DescripcionPeriodo, ")
         .Append("Dias )")
         .Append("VALUES(")
         .Append(idPeriodo & ", ")
         .Append("'" & descripcionPeriodo & "', ")
         .Append(dias & ")")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "VentasPeriodos")
   End Sub

   Public Sub VentasPeriodos_U(ByVal idPeriodo As Integer, _
                               ByVal descripcionPeriodo As String, _
                               ByVal dias As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("UPDATE  ")
         .Append("VentasPeriodos  ")
         .Append("SET  ")

         .Append("DescripcionPeriodo = '" & descripcionPeriodo & "', ")
         .Append("Dias = " & dias & "")
         .Append("WHERE ")
         .Append("IdPeriodo = " & idPeriodo)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "VentasPeriodos")
   End Sub

   Public Sub VentasPeriodos_D(ByVal idPeriodo As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("DELETE FROM  ")
         .Append("VentasPeriodos  ")
         .Append("WHERE  ")
         .Append("IdPeriodo = " & idPeriodo)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "VentasPeriodo")
   End Sub

   Public Function VentasPeriodos_GA() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Append("SELECT  ")
         .Append("* ")
         .Append("FROM VentasPeriodos ")
         .Append("ORDER BY DescripcionPeriodo ")
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function

End Class
