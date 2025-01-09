Public Class SubRubrosComisionesPorDescuento
   Inherits Comunes
   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub
   Public Sub SubRubrosComisionesPorDescuento_I(idSubRubro As Integer, descuentoRecargoHasta As Decimal, comision As Decimal)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0}", Entidades.SubRubroComisionPorDescuento.NombreTabla).AppendLine()
         .AppendFormatLine("           ({0}, {1}, {2})",
                           Entidades.SubRubroComisionPorDescuento.Columnas.IdSubRubro.ToString(),
                           Entidades.SubRubroComisionPorDescuento.Columnas.DescuentoRecargoHasta.ToString(),
                           Entidades.SubRubroComisionPorDescuento.Columnas.Comision.ToString())
         .AppendFormatLine("    VALUES ({0}, {1}, {2}",
                       idSubRubro, descuentoRecargoHasta, comision)
         .AppendLine(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub
   Public Sub SubRubrosComisionesPorDescuento_U(idSubRubro As Integer, descuentoRecargoHasta As Decimal, comision As Decimal)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0} ", Entidades.SubRubroComisionPorDescuento.NombreTabla)
         .AppendFormatLine("   SET {0} =  {1}", Entidades.SubRubroComisionPorDescuento.Columnas.Comision.ToString(), comision)
         .AppendFormatLine(" WHERE {0} =  {1}", Entidades.SubRubroComisionPorDescuento.Columnas.IdSubRubro.ToString(), idSubRubro)
         .AppendFormatLine("  AND  {0} =  {1}", Entidades.SubRubroComisionPorDescuento.Columnas.DescuentoRecargoHasta.ToString(), descuentoRecargoHasta)
      End With
      Me.Execute(myQuery.ToString())
   End Sub
   Public Sub SubRubrosComisionesPorDescuento_D(idSubRubro As Integer, descuentoRecargoHasta As Decimal)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0} WHERE {1} = {2}", Entidades.SubRubroComisionPorDescuento.NombreTabla, Entidades.SubRubroComisionPorDescuento.Columnas.IdSubRubro.ToString(), idSubRubro)
         If descuentoRecargoHasta <> 0 Then
            .AppendFormatLine("   AND   {0} =  {1}", Entidades.SubRubroComisionPorDescuento.Columnas.DescuentoRecargoHasta.ToString(), descuentoRecargoHasta)
         End If
      End With
      Me.Execute(myQuery.ToString())
   End Sub
   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT SRCD.*")
         .AppendFormatLine("  FROM {0} AS SRCD", Entidades.SubRubroComisionPorDescuento.NombreTabla)
      End With
   End Sub
   Public Function SubRubrosComisionesPorDescuento_G1(idSubRubro As Integer, descuentoRecargoHasta As Decimal) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE SRCD.idSubRubro = {0}", idSubRubro)
         .AppendFormatLine(" AND SRCD.DescuentoRecargoHasta = {0}", descuentoRecargoHasta)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function
   Public Function SubRubrosComisionesPorDescuento_GA(idSubRubro As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE SRCD.idSubRubro = {0}", idSubRubro)
         .AppendFormatLine(" ORDER BY SRCD.DescuentoRecargoHasta DESC")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function
End Class
