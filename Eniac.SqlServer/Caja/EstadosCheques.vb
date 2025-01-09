Public Class EstadosCheques
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Function EstadosCheques_GA() As DataTable
      Return EstadosCheques_G(idEstadoCheque:=String.Empty, nombreEstadoCheque:=String.Empty)
   End Function
   Public Function EstadosCheques_G1(codigo As String) As DataTable
      Return EstadosCheques_G(idEstadoCheque:=codigo, nombreEstadoCheque:=String.Empty)
   End Function

   Private Function EstadosCheques_G(idEstadoCheque As String, nombreEstadoCheque As String) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendLine("SELECT E.*")
         .AppendLine("  FROM EstadosCheques E ")
         .AppendLine(" WHERE 1 = 1")
         If idEstadoCheque <> "" Then
            .AppendFormatLine("  AND IdEstadoCheque = '{0}'", idEstadoCheque)
         End If
         If Not String.IsNullOrWhiteSpace(nombreEstadoCheque) Then
            .AppendFormatLine("  AND NombreEstadoCheque LIKE '%{0}%'", nombreEstadoCheque)
         End If
         .Append("	ORDER BY NombreEstadoCheque")
      End With

      Return Me.GetDataTable(myQuery.ToString())

   End Function

   Public Function GetPorCodigo(codigo As String) As DataTable
      Return EstadosCheques_G(idEstadoCheque:=codigo, nombreEstadoCheque:=String.Empty)
   End Function
   Public Function GetPorNombre(nombre As String) As DataTable
      Return EstadosCheques_G(idEstadoCheque:=String.Empty, nombreEstadoCheque:=nombre)
   End Function
End Class