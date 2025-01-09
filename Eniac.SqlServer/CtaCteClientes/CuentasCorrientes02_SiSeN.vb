Partial Class CuentasCorrientes
   Public Function GetLoMasViejoDatos(idSucursal As Integer, idCliente As Long, saldoMinimoSemaforo As Decimal) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendFormatLine("SELECT MIN(cc.Fecha) as LoMasViejo")
         .AppendFormatLine("  FROM CuentasCorrientes cc")
         .AppendFormatLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CC.IdTipoComprobante")
         .AppendFormatLine(" WHERE cc.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND cc.IdCliente = {0}", idCliente)
         .AppendFormatLine("   AND TC.EsRecibo = 'False'")
         .AppendFormatLine("   AND TC.EsAnticipo = 'False'")
         .AppendFormatLine("   AND cc.Saldo > {0}", saldoMinimoSemaforo) 'Evita NC, etc.
      End With
      Return GetDataTable(stbQuery)
   End Function

End Class