Partial Class Ventas

   ''CALCULOS
#Region "Percepciones de IIBB"
   Public Function GetMontoFacturadoPorCliente(ByVal IdCliente As Long, fecha As DateTime) As Decimal
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT sum(V.ImporteTotal) Monto ")
         .AppendFormatLine("  FROM Ventas V")
         .AppendFormatLine(" INNER JOIN Clientes C ON C.IdCliente = V.IdCliente")
         .AppendFormatLine("  LEFT JOIN TiposComprobantes TC ON V.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendFormatLine(" WHERE V.IdCLiente = {0}", IdCliente)
         .AppendFormatLine("   AND TC.GrabaLibro = 1")
         .AppendFormatLine("   AND V.Fecha BETWEEN '{0} 00:00:00' AND '{0} 23:59:59' ", fecha.ToString("yyyyMMdd"))
         .AppendFormatLine("   AND V.IdCategoriaFiscal = C.IdCategoriaFiscal")
      End With
      Dim dt As DataTable = Me.GetDataTable(stb.ToString())
      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("Monto").ToString()) Then
            Return Decimal.Parse(dt.Rows(0)("Monto").ToString())
         End If
      End If
      Return 0
   End Function
#End Region

End Class