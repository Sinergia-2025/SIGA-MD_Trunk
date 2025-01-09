Public Class RecepcionEstadosF
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Function RecepcionEstadosF_GA() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Append("SELECT  ")
         .Append("* ")
         .Append("FROM RecepcionEstadosF ")
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function


End Class
