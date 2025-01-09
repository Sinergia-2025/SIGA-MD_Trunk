Public Class RecepcionEstados
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Function RecepcionEstados_GA() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Append("SELECT  ")
         .Append("* ")
         .Append("FROM RecepcionEstados ")
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function


End Class
