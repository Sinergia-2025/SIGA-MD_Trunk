Public Class UnidadesDeMedidasConversiones
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub UnidadesDeMedidasConversiones_I(idUnidadMedidaDesde As String, idUnidadMedidaHacia As String,
                                              factorConversion As Decimal, fija As Boolean)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0} (", Entidades.UnidadDeMedidaConversion.NombreTabla)
         .AppendFormatLine("     {0}", Entidades.UnidadDeMedidaConversion.Columnas.IdUnidadMedidaDesde.ToString())
         .AppendFormatLine("   , {0}", Entidades.UnidadDeMedidaConversion.Columnas.IdUnidadMedidaHacia.ToString())
         .AppendFormatLine("   , {0}", Entidades.UnidadDeMedidaConversion.Columnas.FactorConversion.ToString())
         .AppendFormatLine("   , {0}", Entidades.UnidadDeMedidaConversion.Columnas.Fija.ToString())
         .AppendFormatLine(") VALUES (")
         .AppendFormatLine("	   '{0}'", idUnidadMedidaDesde)
         .AppendFormatLine("	 , '{0}'", idUnidadMedidaHacia)
         .AppendFormatLine("	 ,  {0} ", factorConversion)
         .AppendFormatLine("	 ,  {0} ", GetStringFromBoolean(fija))
         .AppendFormatLine(")")
      End With
      Execute(myQuery)
   End Sub

   Public Sub UnidadesDeMedidasConversiones_U(idUnidadMedidaDesde As String, idUnidadMedidaHacia As String,
                                              factorConversion As Decimal, fija As Boolean)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.UnidadDeMedidaConversion.NombreTabla)
         .AppendFormatLine("   SET {0} =  {1} ", Entidades.UnidadDeMedidaConversion.Columnas.FactorConversion.ToString(), factorConversion)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.UnidadDeMedidaConversion.Columnas.Fija.ToString(), GetStringFromBoolean(fija))

         .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.UnidadDeMedidaConversion.Columnas.IdUnidadMedidaDesde.ToString(), idUnidadMedidaDesde)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.UnidadDeMedidaConversion.Columnas.IdUnidadMedidaHacia.ToString(), idUnidadMedidaHacia)
      End With
      Execute(myQuery)
   End Sub

   Public Sub UnidadesDeMedidasConversiones_D(idUnidadMedidaDesde As String, idUnidadMedidaHacia As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0}", Entidades.UnidadDeMedidaConversion.NombreTabla)
         .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.UnidadDeMedidaConversion.Columnas.IdUnidadMedidaDesde.ToString(), idUnidadMedidaDesde)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.UnidadDeMedidaConversion.Columnas.IdUnidadMedidaHacia.ToString(), idUnidadMedidaHacia)
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT UMC.*")
         .AppendFormatLine("     , UMd.NombreUnidadDeMedida AS NombreUnidadDeMedidaDesde")
         .AppendFormatLine("     , UMh.NombreUnidadDeMedida AS NombreUnidadDeMedidaHacia")
         .AppendFormatLine("  FROM {0} AS UMC", Entidades.UnidadDeMedidaConversion.NombreTabla)
         .AppendFormatLine(" INNER JOIN UnidadesDeMedidas UMd ON UMd.IdUnidadDeMedida = UMC.IdUnidadMedidaDesde")
         .AppendFormatLine(" INNER JOIN UnidadesDeMedidas UMh ON UMh.IdUnidadDeMedida = UMC.IdUnidadMedidaHacia")
      End With
   End Sub

   Private Function UnidadesDeMedidasConversiones_G(idUnidadMedidaDesde As String, idUnidadMedidaHacia As String) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If Not String.IsNullOrWhiteSpace(idUnidadMedidaDesde) Then
            .AppendFormatLine("   AND UMC.{0} = '{1}'", Entidades.UnidadDeMedidaConversion.Columnas.IdUnidadMedidaDesde.ToString(), idUnidadMedidaDesde)
         End If
         If Not String.IsNullOrWhiteSpace(idUnidadMedidaHacia) Then
            .AppendFormatLine("   AND UMC.{0} = '{1}'", Entidades.UnidadDeMedidaConversion.Columnas.IdUnidadMedidaHacia.ToString(), idUnidadMedidaHacia)
         End If
         .AppendFormatLine(" ORDER BY UMC.{0}, UMC.{1}",
                           Entidades.UnidadDeMedidaConversion.Columnas.IdUnidadMedidaDesde.ToString(),
                           Entidades.UnidadDeMedidaConversion.Columnas.IdUnidadMedidaHacia.ToString())
      End With
      Return GetDataTable(myQuery)
   End Function
   Public Function UnidadesDeMedidasConversiones_GA() As DataTable
      Return UnidadesDeMedidasConversiones_G(idUnidadMedidaDesde:=String.Empty, idUnidadMedidaHacia:=String.Empty)
   End Function
   Public Function UnidadesDeMedidasConversiones_G1(idUnidadMedidaDesde As String, idUnidadMedidaHacia As String) As DataTable
      Return UnidadesDeMedidasConversiones_G(idUnidadMedidaDesde, idUnidadMedidaHacia)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "UMC.", New Dictionary(Of String, String) From {
                    {"NombreUnidadDeMedidaDesde", "UMd.NombreUnidadDeMedida"},
                    {"NombreUnidadDeMedidaHasta", "UMh.NombreUnidadDeMedida"}})
   End Function

End Class