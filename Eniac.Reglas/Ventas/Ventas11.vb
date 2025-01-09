Partial Class Ventas

   ''AFIP - Permisos de Embarques.-

   Public Function GetParaExportarAFIP(periodoFiscal As Integer) As DataTable
      Dim sql = New SqlServer.Ventas(da)
      Return sql.GetParaExportarAFIP(periodoFiscal, actual.Sucursal.IdEmpresa)
   End Function

   Public Function GetParaExportarAFIPAlicuotas(periodoFiscal As Integer) As DataTable
      Dim sql = New SqlServer.Ventas(da)
      Return sql.GetParaExportarAFIPAlicuotas(periodoFiscal, actual.Sucursal.IdEmpresa)
   End Function

   Public Function GetParaExportarAFIPComprobantesAnulados(periodoFiscal As Date) As DataTable
      Dim sql = New SqlServer.Ventas(da)
      Return sql.GetParaExportarAFIPComprobantesAnulados(periodoFiscal, actual.Sucursal.IdEmpresa)
   End Function

   Public Function GetLibroDeIVA(idEmpresa As Integer, periodoFiscal As Integer, orden As String, idVendedor As Integer) As DataTable
      Dim sql = New SqlServer.Ventas(da)
      Return sql.GetLibroDeIVA(idEmpresa, periodoFiscal, orden, idVendedor)
   End Function
   Public Function GetLibroDinamicoDeIVA(idEmpresa As Integer, periodoFiscal As Integer, orden As String, idVendedor As Integer) As DataTable
      Dim sql = New SqlServer.Ventas(da)
      Return sql.GetLibroDinamicoDeIVA(idEmpresa, periodoFiscal, orden, idVendedor)
   End Function

   Public Function GetLibroDeIVAUnificado(idEmpresa As Integer, periodoFiscal As Integer, orden As String, idVendedor As Integer) As DataTable
      Dim sql = New SqlServer.Ventas(da)
      Return sql.GetLibroDeIVAUnificado(idEmpresa, periodoFiscal, orden, idVendedor)
   End Function

   Public Sub GrabaPermisosEmbarquesExportacion(oVentas As Entidades.Venta)
      Dim sqlPermisosEmbarques = New SqlServer.VentasExportacionEmbarques(da)
      For Each tr In oVentas.ExportacionEmbarques
         sqlPermisosEmbarques.VentasExportacionEmbarques_I(oVentas.IdSucursal,
                                                           oVentas.TipoComprobante.IdTipoComprobante,
                                                           oVentas.LetraComprobante,
                                                           oVentas.CentroEmisor,
                                                           oVentas.NumeroComprobante,
                                                           tr.IdPermisoEmbarque,
                                                           tr.IdDestinoDespacho)
      Next
   End Sub

End Class