Public Class TiposImpresionesFiscales
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub


   Public Function TiposImpresionesFiscales_GA() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .AppendFormatLine("SELECT * FROM {0} ", Entidades.TipoImpresionFiscal.NombreTabla)
         .AppendFormatLine(" ORDER BY {0}", Entidades.TipoImpresionFiscal.Columnas.IdTipoImpresionFiscal.ToString())
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendLine("  WHERE 1=1 ")
         For Each palabra As String In valor.ToString().Split(" "c)
            .AppendFormat("   AND {0} LIKE '%{1}%'", columna, palabra)
         Next
         .AppendLine()
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT ")
         .AppendFormatLine("   {0},", Entidades.TipoImpresionFiscal.Columnas.IdTipoImpresionFiscal.ToString())
         .AppendFormatLine("   {0}", Entidades.TipoImpresionFiscal.Columnas.NombreTipoImpresionFiscal.ToString())
         .AppendFormatLine("FROM {0}", Entidades.TipoImpresionFiscal.NombreTabla)
      End With
   End Sub
End Class
