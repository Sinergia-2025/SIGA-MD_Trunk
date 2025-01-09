Public Class PCs
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Function GetPCsHabilitadas() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Append("SELECT NombrePC")
         .Append("      ,Mac")
         .Append("  FROM PCs")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

End Class
