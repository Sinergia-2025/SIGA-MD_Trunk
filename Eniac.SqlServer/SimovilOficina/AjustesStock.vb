Namespace SimovilOficina
   Public Class AjustesStock
      Inherits Comunes

      Public Sub New(da As Datos.DataAccess)
         MyBase.New(da)
      End Sub

      Public Sub AjustesStock_U(idEjecucionAjusteStock As Guid, idSucursal As Integer, idProducto As String,
                                estado As Entidades.SimovilOficina.EstadosAjusteStock, mensajeError As String)
         Dim myQuery = New StringBuilder()
         With myQuery
            .AppendFormatLine("UPDATE dboOficina.AjustesStock")
            .AppendFormatLine("   SET Estado       = '{0}'", estado)
            .AppendFormatLine("     , MensajeError = '{0}'", mensajeError.Replace("'", """"))
            .AppendFormatLine(" WHERE IdEjecucionAjusteStock   = '{0}'", idEjecucionAjusteStock)
            .AppendFormatLine("   AND IdSucursal               =  {0} ", idSucursal)
            .AppendFormatLine("   AND IdProducto               = '{0}'", idProducto)
         End With
         Execute(myQuery)
      End Sub
      Private Sub SelectTexto(stb As StringBuilder)
         With stb
            .AppendFormatLine("SELECT AJS.*")
            .AppendFormatLine("  FROM dboOficina.AjustesStock AS AJS")
         End With
      End Sub
      Public Function AjustesStock_GA(idEjecucionAjusteStock As Guid, idSucursal As Integer) As DataTable
         Return AjustesStock_G(idEjecucionAjusteStock, idSucursal)
      End Function
      Private Function AjustesStock_G(idEjecucionAjusteStock As Guid, idSucursal As Integer) As DataTable
         Dim myQuery = New StringBuilder()
         With myQuery
            SelectTexto(myQuery)
            .AppendFormatLine(" WHERE AJS.IdEjecucionAjusteStock  = '{0}'", idEjecucionAjusteStock)
            .AppendFormatLine("   AND AJS.IdSucursal              =  {0} ", idSucursal)
            .AppendFormatLine(" ORDER BY AJS.FechaAlta")
         End With
         Return GetDataTable(myQuery)
      End Function
   End Class
End Namespace