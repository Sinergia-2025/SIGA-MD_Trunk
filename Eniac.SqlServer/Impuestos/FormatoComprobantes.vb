Public Class FormatoComprobantes
   Public Shared Function ObtenerNumeroDespachoCompleto(aliasTablaCompras As String) As String
      Const formatoCampo As String = "{0}.{1}"
      Return ObtenerNumeroDespachoCompleto(String.Format(formatoCampo, aliasTablaCompras, "FechaOficializacionDespacho"),
                                           String.Format(formatoCampo, aliasTablaCompras, "IdAduana"),
                                           String.Format(formatoCampo, aliasTablaCompras, "IdDestinacion"),
                                           String.Format(formatoCampo, aliasTablaCompras, "NumeroDespacho"),
                                           String.Format(formatoCampo, aliasTablaCompras, "DigitoVerificadorDespacho"))
   End Function

   Public Shared Function ObtenerNumeroDespachoCompleto(aliasCampoFechaOficializacionDespacho As String,
                                                        aliasCampoIdAduana As String,
                                                        aliasCampoIdDestinacion As String,
                                                        aliasCampoNumeroDespacho As String,
                                                        aliasCampoDigitoVerificadorDespacho As String) As String
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("CONVERT(VARCHAR(MAX),YEAR({0}) % 100) +", aliasCampoFechaOficializacionDespacho)
         .AppendFormatLine("RIGHT('000' + ISNULL(CONVERT(VARCHAR(MAX), {0}), ''), 3) +", aliasCampoIdAduana)
         .AppendFormatLine("{0} +", aliasCampoIdDestinacion)
         .AppendFormatLine("RIGHT('000000' + ISNULL(CONVERT(VARCHAR(MAX), {0}), ''), 6) +", aliasCampoNumeroDespacho)
         .AppendFormatLine("{0}", aliasCampoDigitoVerificadorDespacho)
      End With
      Return stb.ToString()
   End Function

   Public Shared Function ObtenerEmisorNumeroComprobante(aliasTablaCompras As String) As String
      Const formatoCampo As String = "{0}.{1}"
      Return ObtenerEmisorNumeroComprobante(String.Format(formatoCampo, aliasTablaCompras, "CentroEmisor"),
                                            String.Format(formatoCampo, aliasTablaCompras, "NumeroComprobante"))
   End Function

   Public Shared Function ObtenerEmisorNumeroComprobante(aliasCampoCentroEmisor As String,
                                                         aliasCampoNumeroComprobante As String) As String
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("RIGHT('0000' + CONVERT(VARCHAR(MAX), {0}), 4) + '-' + RIGHT('00000000' + CONVERT(VARCHAR(MAX), {1}), 8)", aliasCampoCentroEmisor, aliasCampoNumeroComprobante)
      End With
      Return stb.ToString()
   End Function

End Class