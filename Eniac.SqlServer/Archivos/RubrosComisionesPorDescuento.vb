Public Class RubrosComisionesPorDescuento
   Inherits Comunes
   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub
   Public Sub RubrosComisionesPorDescuento_I(idRubro As Integer, descuentoRecargoHasta As Decimal, comision As Decimal)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0}", Entidades.RubroComisionPorDescuento.NombreTabla).AppendLine()
         .AppendFormatLine("           ({0}, {1}, {2})",
                           Entidades.RubroComisionPorDescuento.Columnas.IdRubro.ToString(),
                           Entidades.RubroComisionPorDescuento.Columnas.DescuentoRecargoHasta.ToString(),
                           Entidades.RubroComisionPorDescuento.Columnas.Comision.ToString())
         .AppendFormatLine("    VALUES ({0}, {1}, {2}",
                       idRubro, descuentoRecargoHasta, comision)
         .AppendLine(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub
   Public Sub RubrosComisionesPorDescuento_U(idRubro As Integer, descuentoRecargoHasta As Decimal, comision As Decimal)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0} ", Entidades.RubroComisionPorDescuento.NombreTabla)
         .AppendFormatLine("   SET {0} =  {1}", Entidades.RubroComisionPorDescuento.Columnas.Comision.ToString(), comision)
         .AppendFormatLine(" WHERE {0} =  {1}", Entidades.RubroComisionPorDescuento.Columnas.IdRubro.ToString(), idRubro)
         .AppendFormatLine("  AND  {0} =  {1}", Entidades.RubroComisionPorDescuento.Columnas.DescuentoRecargoHasta.ToString(), descuentoRecargoHasta)
      End With
      Me.Execute(myQuery.ToString())
   End Sub
   Public Sub RubrosComisionesPorDescuento_D(idRubro As Integer, descuentoRecargoHasta As Decimal)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0} WHERE {1} = {2}", Entidades.RubroComisionPorDescuento.NombreTabla, Entidades.RubroComisionPorDescuento.Columnas.IdRubro.ToString(), idRubro)
         If descuentoRecargoHasta <> 0 Then
            .AppendFormatLine("   AND   {0} =  {1}", Entidades.RubroComisionPorDescuento.Columnas.DescuentoRecargoHasta.ToString(), descuentoRecargoHasta)
         End If
      End With
      Me.Execute(myQuery.ToString())
   End Sub
   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT RCD.*")
         .AppendFormatLine("  FROM {0} AS RCD", Entidades.RubroComisionPorDescuento.NombreTabla)
      End With
   End Sub
   Public Function RubrosComisionesPorDescuento_G1(idRubro As Integer, descuentoRecargoHasta As Decimal) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE RCD.IdRubro = {0}", idRubro)
         .AppendFormatLine(" AND RCD.DescuentoRecargoHasta = {0}", descuentoRecargoHasta)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function
   Public Function RubrosComisionesPorDescuento_GA(idRubro As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE RCD.IdRubro = {0}", idRubro)
         .AppendFormatLine(" ORDER BY RCD.IdRubro, RCD.DescuentoRecargoHasta DESC")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function
End Class
