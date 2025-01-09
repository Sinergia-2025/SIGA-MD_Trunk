Partial Class CuentasCorrientes
   Public Function GetMesesDeudaCliente(idSucursal As Integer, idCliente As Long) As Long
      Dim fecha = GetLoMasViejoFecha(idSucursal, idCliente)
      If fecha.HasValue Then
         Return DateDiff(DateInterval.Month, fecha.Value, Date.Now)
      Else
         Return 0
      End If
   End Function

   Public Function GetLoMasViejoFecha(idSucursal As Integer, idCliente As Long) As Date?
      Dim dt = New SqlServer.CuentasCorrientes(da).GetLoMasViejoDatos(idSucursal, idCliente, Publicos.SiSeN.ReservaSaldoMinimoSemaforo)
      If dt.Rows.Count > 0 Then
         Return dt.Rows(0).Field(Of DateTime?)("LoMasViejo")
      Else
         Return Nothing
      End If
   End Function

End Class