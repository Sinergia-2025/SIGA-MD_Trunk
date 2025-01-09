Partial Class Categorias
   Public Function GetPorCliente(idCliente As Long) As DataTable
      Return New SqlServer.Categorias(da).Categorias_GA_PorCliente(idCliente)
   End Function
   Public Function GetLimiteMesesDeudaBotado(idCliente As Long) As Integer?
      Dim dt = GetPorCliente(idCliente)
      If dt.Rows.Count > 0 Then
         If dt.Columns.Contains("LimiteMesesDeudaBotado") Then
            Return dt.Rows(0).Field(Of Integer?)("LimiteMesesDeudaBotado")
         End If
      End If
      Return Nothing
   End Function
End Class