Public Class AFIPTiposComprobantes
   Inherits Comunes

   Public Sub New(da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub


   Public Sub AFIPTiposComprobantes_I(idAFIPTipoComprobante As Integer,
                                      nombreAFIPTipoComprobante As String,
                                      idAFIPTipoDocumento As Integer?,
                                      incluyeFechaVencimiento As Boolean?)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0}", Entidades.AFIPTipoComprobante.NombreTabla)
         .AppendFormatLine("           ({0}, {1}, {2}, {3}, {4}, {5})",
                           Entidades.AFIPTipoComprobante.Columnas.IdAFIPTipoComprobante.ToString(),
                           Entidades.AFIPTipoComprobante.Columnas.NombreAFIPTipoComprobante.ToString(),
                           Entidades.AFIPTipoComprobante.Columnas.IdTipoComprobante.ToString(),
                           Entidades.AFIPTipoComprobante.Columnas.Letra.ToString(),
                           Entidades.AFIPTipoComprobante.Columnas.IdAFIPTipoDocumento.ToString(),
                           Entidades.AFIPTipoComprobante.Columnas.IncluyeFechaVencimiento.ToString())
         .AppendFormatLine("    VALUES ({0}, '{1}', NULL, NULL, {4}, {5}",
                           idAFIPTipoComprobante, nombreAFIPTipoComprobante,
                           GetStringFromNumber(idAFIPTipoDocumento), GetStringFromBoolean(incluyeFechaVencimiento))
         .AppendLine(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub AFIPTiposComprobantes_U(idAFIPTipoComprobante As Integer,
                                      nombreAFIPTipoComprobante As String,
                                      idAFIPTipoDocumento As Integer?,
                                      incluyeFechaVencimiento As Boolean?)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0} ", Entidades.AFIPTipoComprobante.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.AFIPTipoComprobante.Columnas.NombreAFIPTipoComprobante.ToString(), nombreAFIPTipoComprobante)
         .AppendFormatLine("     , {0} = NULL ", Entidades.AFIPTipoComprobante.Columnas.IdTipoComprobante.ToString())
         .AppendFormatLine("     , {0} = NULL ", Entidades.AFIPTipoComprobante.Columnas.Letra.ToString())
         .AppendFormatLine("     , {0} =  {1} ", Entidades.AFIPTipoComprobante.Columnas.IdAFIPTipoDocumento.ToString(), GetStringFromNumber(idAFIPTipoDocumento))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.AFIPTipoComprobante.Columnas.IncluyeFechaVencimiento.ToString(), GetStringFromBoolean(incluyeFechaVencimiento))

         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.AFIPTipoComprobante.Columnas.IdAFIPTipoComprobante.ToString(), idAFIPTipoComprobante)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub AFIPTiposComprobantes_D(idAFIPTipoComprobante As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0} WHERE {1} = {2}",
                           Entidades.AFIPTipoComprobante.NombreTabla, Entidades.AFIPTipoComprobante.Columnas.IdAFIPTipoComprobante.ToString(), idAFIPTipoComprobante)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("SELECT ATC.IdAFIPTipoComprobante")
         .AppendLine("      ,ATC.NombreAFIPTipoComprobante")
         .AppendLine("      ,ATC.IdAFIPTipoDocumento")
         .AppendLine("      ,ATD.NombreAFIPTipoDocumento")
         .AppendLine("      ,ATC.IncluyeFechaVencimiento")
         .AppendLine("      ,CASE WHEN ATC.IncluyeFechaVencimiento IS NULL THEN '' ELSE CASE WHEN ATC.IncluyeFechaVencimiento = 1 THEN 'SI' ELSE 'NO' END END IncluyeFechaVencimientoAsString")
         .AppendLine("  FROM AFIPTiposComprobantes ATC ")
         .AppendLine("  LEFT JOIN AFIPTiposDocumentos ATD ON ATD.IdAFIPTipoDocumento = ATC.IdAFIPTipoDocumento ")
      End With
   End Sub

   Public Function AFIPTiposComprobantes_GA() As DataTable
      Return AFIPTiposComprobantes_G(idAFIPTipoComprobante:=0)
   End Function

   Private Function AFIPTiposComprobantes_G(idAFIPTipoComprobante As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(" WHERE 1 = 1")
         If idAFIPTipoComprobante <> 0 Then
            .AppendFormatLine("   AND ATC.IdAFIPTipoComprobante = {0}", idAFIPTipoComprobante)
         End If
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function AFIPTiposComprobantes_G1(idAFIPTipoComprobante As Integer) As DataTable
      Return AFIPTiposComprobantes_G(idAFIPTipoComprobante)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      'If columna = "NombreVendedor" Then
      '   columna = "E.NombreEmpleado"
      'Else
      columna = "ATC." + columna
      'End If
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(" WHERE {0} LIKE '%{1}%'", columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function





   Private Sub SelectTextoJoinTiposCbtes(stb As StringBuilder)
      With stb
         .Append("SELECT ATC.IdAFIPTipoComprobante")
         .Append("      ,ATC.NombreAFIPTipoComprobante")
         .Append("      ,ATCTC.IdTipoComprobante")
         .Append("      ,ATCTC.Letra")
         .Append("      ,ATC.IdAFIPTipoDocumento")
         .Append("      ,ATC.IncluyeFechaVencimiento")
         .Append("  FROM AFIPTiposComprobantes ATC ")
         .Append("  LEFT JOIN AFIPTiposComprobantesTiposCbtes ATCTC ON ATC.IdAFIPTipoComprobante = ATCTC.IdAFIPTipoComprobante ")
      End With
   End Sub

   Public Function AFIPTiposComprobantes_G_PorTipoLetra(idTipoComprobante As String, letra As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTextoJoinTiposCbtes(stb)
         .AppendFormat(" WHERE ATCTC.IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormat(" AND ATCTC.Letra = '{0}'", letra)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetIdTipoComprobanteparaAFIP(idTipoComprobante As String, letra As String) As Integer
      Dim dt As DataTable = AFIPTiposComprobantes_G_PorTipoLetra(idTipoComprobante, letra)

      If dt.Rows.Count > 0 Then
         Return Int32.Parse(dt.Rows(0)("IdAFIPTipoComprobante").ToString())
      Else
         Throw New Exception("Falta cargar el Tipo de Comprobante (" + idTipoComprobante + ") en las tablas del AFIP.")
      End If

   End Function

   Public Function GetIdTipoComprobante(idTipoComprobanteAFIP As Integer) As String
      Dim dt As DataTable = AFIPTiposComprobantes_G1(idTipoComprobanteAFIP)

      If dt.Rows.Count > 0 Then
         Return dt.Rows(0)("IdAFIPTipoComprobante").ToString()
      Else
         Throw New Exception(String.Format("Falta cargar el Tipo de Comprobante {0} en las tablas del AFIP.", idTipoComprobanteAFIP))
      End If
   End Function

End Class