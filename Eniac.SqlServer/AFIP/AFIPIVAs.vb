Public Class AFIPIVAs
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub


   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Append("SELECT AI.IdAFIPIVA")
         .Append("      ,AI.DescripcionAFIPIVA")
         .Append("      ,AI.IdTipoImpuesto")
         .Append("      ,AI.Alicuota")
         .Append("  FROM AFIPIVAs AI ")
      End With
   End Sub

   Public Function AFIPTiposComprobantes_GA() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         Me.SelectTexto(stb)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetIdIVAparaAFIP(ByVal IdTipoImpuesto As Entidades.TipoImpuesto.Tipos, ByVal Alicuota As Decimal) As Integer
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE AI.IdTipoImpuesto = '{0}'", IdTipoImpuesto.ToString())
         .AppendFormat(" AND AI.Alicuota = {0}", Alicuota)
      End With

      Dim dt As DataTable = Me.GetDataTable(stb.ToString())

      If dt.Rows.Count > 0 Then
         Return Int32.Parse(dt.Rows(0)("IdAFIPIVA").ToString())
      Else
         Throw New Exception("Falta cargar el Impuesto en las tablas del AFIP.")
      End If

   End Function

End Class
