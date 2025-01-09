Public Class ImprimirRepartosListadoDeClientes
   Public Sub Imprimir(filtros As String,
                       idSucursal As Integer,
                       fechaDesde As Date, fechaHasta As Date,
                       numeroReparto As Integer, numeroRepartoHasta As Integer,
                       distribucion As Integer, idVendedor As Integer, titulo As String)

      Dim regla = New Reglas.OrganizarEntregas()
      Dim dt = regla.ListadoDeClientes(idSucursal, Nothing, Nothing, numeroReparto, numeroRepartoHasta, distribucion, idVendedor).Copy()

      Dim reporte As Entidades.InformePersonalizadoResuelto
      reporte = New Reglas.PersonalizacionDeInformes().ResolverInformePersonalizado(Entidades.PersonalizacionDeInforme.Informes.SiLIVE_ListadoDeClientes, "Eniac.Win.ListadoDeClientes.rdlc")

      Imprimir(dt, filtros, titulo, reporte.NombreArchivo, reporte.ReporteEmbebido)
   End Sub


   Public Sub ImprimirConEnvases(filtros As String,
                                 idSucursal As Integer,
                                 fechaDesde As Date, fechaHasta As Date,
                                 numeroReparto As Integer, numeroRepartoHasta As Integer,
                                 distribucion As Integer, IdVendedor As Integer, titulo As String)
      Dim regla = New Reglas.OrganizarEntregas()
      Dim dt = regla.ListadoDeClientesConEnvases(idSucursal, Nothing, Nothing, numeroReparto, numeroRepartoHasta, distribucion, IdVendedor).Copy()

      Dim reporte As Entidades.InformePersonalizadoResuelto
      reporte = New Reglas.PersonalizacionDeInformes().ResolverInformePersonalizado(Entidades.PersonalizacionDeInforme.Informes.SiLIVE_ListadoDeClientesConEnvases, "Eniac.Win.ListadoDeClientesConEnvases.rdlc")

      Imprimir(dt, filtros, titulo, reporte.NombreArchivo, reporte.ReporteEmbebido)
   End Sub

   Private Sub Imprimir(dt As DataTable, filtros As String, titulo As String, nombreReporte As String, embebido As Boolean)
      Dim parm As List(Of Microsoft.Reporting.WinForms.ReportParameter) = New List(Of Microsoft.Reporting.WinForms.ReportParameter)

      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Reglas.Publicos.NombreEmpresaImpresion))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", actual.Sucursal.Nombre))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", filtros))

      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TituloCantidadEnvase1", Traducciones.TraducirTexto("1", "ListadoDeClientesConEnvases_TituloCantidadEnvase1")))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TituloCantidadEnvase2", Traducciones.TraducirTexto("2", "ListadoDeClientesConEnvases_TituloCantidadEnvase2")))

      Dim frmImprime As VisorReportes = New VisorReportes(nombreReporte, "DsOrganizarEntregas", dt, parm, embebido, 1) '# 1 = Cantidad Copias
      frmImprime.Text = titulo
      frmImprime.WindowState = FormWindowState.Maximized
      frmImprime.ShowDialog()
   End Sub

   Private Function PreparaDataTable(dt As DataTable) As DataTable
      AgregarColumnaOrden(dt, orden:=1)
      AgregarColumnaOrden(dt, orden:=2)
      Return dt
   End Function
   Private Sub AgregarColumnaOrden(dt As DataTable, orden As Integer)
      Dim nombreColumnaOrden As String = String.Format("orden_{0}", orden)
      If Not dt.Columns.Contains(nombreColumnaOrden) Then
         dt.Columns.Add(nombreColumnaOrden, GetType(Decimal))
      End If
   End Sub

End Class