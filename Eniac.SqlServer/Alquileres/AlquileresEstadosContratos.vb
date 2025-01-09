Public Class AlquileresEstadosContratos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Function AlquilerEstados_GA() As DataTable

      Dim stbQuery As StringBuilder = New StringBuilder("")
      Dim dt As New DataTable

      With stbQuery
         .AppendLine("SELECT * FROM AlquileresEstadosContratos")
      End With

      dt = Me.GetDataTable(stbQuery.ToString())

      Return dt

   End Function

   Public Function AlquilerEstados_G1(ByVal IdEstado As Integer) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .AppendLine("SELECT * FROM AlquileresEstadosContratos")
         .AppendLine(" WHERE IdEstado = " & IdEstado.ToString())
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

End Class
