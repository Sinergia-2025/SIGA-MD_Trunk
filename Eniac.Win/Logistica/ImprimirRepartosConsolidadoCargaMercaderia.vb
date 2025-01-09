Public Class ImprimirRepartosConsolidadoCargaMercaderia
   Public Sub Imprimir(filtros As String,
                       idSucursal As Integer,
                       fechaDesde As Date?, fechaHasta As Date?,
                       numeroReparto As Integer(),
                       distribucion As Integer,
                       IdVendedor As Integer,
                       titulo As String,
                       porTipoOperacion As Boolean)
      Dim cl = New Reglas.OrganizarEntregas()
      Dim dt = cl.ConsolidadoCargaMercaderia(idSucursal, Nothing, Nothing, numeroReparto, distribucion, IdVendedor).Copy()

      Imprimir(filtros, dt, titulo, porTipoOperacion)
   End Sub
   Public Sub Imprimir(filtros As String,
                       dt As DataTable,
                       titulo As String,
                       porTipoOperacion As Boolean)

      Dim reporte As Entidades.InformePersonalizadoResuelto

      If porTipoOperacion Then
         reporte = New Reglas.PersonalizacionDeInformes().ResolverInformePersonalizado(Entidades.PersonalizacionDeInforme.Informes.SiLIVE_ConsolidadoDeCargaOperacion, "Eniac.Win.ConsolidadoCargaOperacion.rdlc")
      Else
         reporte = New Reglas.PersonalizacionDeInformes().ResolverInformePersonalizado(Entidades.PersonalizacionDeInforme.Informes.SiLIVE_ConsolidadoDeCarga, "Eniac.Win.ListadoConsolidadoCargaMercaderia.rdlc")
      End If


      Imprimir(filtros, dt, titulo, reporte.NombreArchivo, reporte.ReporteEmbebido)
   End Sub
   Private Sub Imprimir(filtros As String,
                        dt As DataTable,
                        titulo As String,
                        nombreArchivo As String,
                        reporteEmbebido As Boolean)
      Dim dtComp As DsOrganizarEntregas.DtComposicionMercaderiaDataTable = New DsOrganizarEntregas.DtComposicionMercaderiaDataTable()

      Dim dtProductos As New DataTable
      dtProductos.Columns.Add("IdProducto", System.Type.GetType("System.String"))
      'PE-31264
      dtProductos.Columns.Add("CodigoDeBarras", System.Type.GetType("System.String"))
      'PE-31579
      dtProductos.Columns.Add("Kilos", System.Type.GetType("System.Decimal"))

      dtProductos.Columns.Add("Cantidad", System.Type.GetType("System.Decimal"))
      dtProductos.Columns.Add("IdFormula", System.Type.GetType("System.Int32"))
      Dim prevIdTransportista As Integer = 0
      Dim prevNombreTransportista As String = String.Empty
      For Each dr As DataRow In dt.Rows
         'If True Then
         '   dr("Orden") = dr("IdProducto")
         'Else
         '   dr("Orden") = dr("NombreProducto").ToString() + dr("IdProducto").ToString()
         'End If
         If prevIdTransportista = 0 Then
            prevIdTransportista = CInt(dr("IdTransportista"))
            prevNombreTransportista = dr("NombreTransportista").ToString()
         End If
         If prevIdTransportista <> CInt(dr("IdTransportista")) Then
            dtComp.Merge(New Eniac.Reglas.ProductosComponentes().GetComponentesProduccion(dtProductos, Eniac.Entidades.Usuario.Actual.Sucursal.IdSucursal))
            For Each drComp As DsOrganizarEntregas.DtComposicionMercaderiaRow In dtComp.Rows
               If drComp.IsIdTransportistaNull Then
                  drComp.IdTransportista = prevIdTransportista
                  drComp.NombreTransportista = prevNombreTransportista
               End If
            Next
            dtProductos.Clear()
            prevIdTransportista = CInt(dr("IdTransportista"))
            prevNombreTransportista = dr("NombreTransportista").ToString()
         End If

         Dim drcol() As DataRow = dtProductos.Select("IdProducto = '" + dr("IdProducto").ToString().Trim() + "'")
         Dim drProducto As DataRow
         If drcol.Length = 0 Then
            drProducto = dtProductos.NewRow()
            drProducto("IdProducto") = dr("IdProducto").ToString().Trim()
            drProducto("Cantidad") = 0
            drProducto("IdFormula") = 1

            'PE-31264
            drProducto("CodigoDeBarras") = dr("CodigoDeBarras").ToString()
            'PE-31579
            drProducto("Kilos") = dr("Kilos").ToString()
            dtProductos.Rows.Add(drProducto)
         Else
            drProducto = drcol(0)
         End If

         drProducto("Cantidad") = CDec(drProducto("Cantidad")) + CDec(dr("Cantidad"))

      Next
      If dtProductos.Rows.Count > 0 Then
         dtComp.Merge(New Eniac.Reglas.ProductosComponentes().GetComponentesProduccion(dtProductos, Eniac.Entidades.Usuario.Actual.Sucursal.IdSucursal))
         For Each drComp As DsOrganizarEntregas.DtComposicionMercaderiaRow In dtComp.Rows
            If drComp.IsIdTransportistaNull Then
               drComp.IdTransportista = prevIdTransportista
               drComp.NombreTransportista = prevNombreTransportista
            End If
         Next
      End If
      dtProductos.Clear()

      Dim parm = New List(Of Microsoft.Reporting.WinForms.ReportParameter)

      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Reglas.Publicos.NombreEmpresa))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Eniac.Entidades.Usuario.Actual.Sucursal.Nombre))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", filtros))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("MuestraEsqueletos", (dtComp.Rows.Count > 0).ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("OrdenarPorID", Reglas.Publicos.Logistica.ConsolidadoCargaOrdenIdProducto.ToString()))


      Using frmImprime = New VisorReportes(nombreArchivo, "DsOrganizarEntregas", dt, "DtComposicionMercaderia", dtComp, parm, reporteEmbebido, 1) '# 1 = Cantidad Copias
         frmImprime.Text = titulo
         frmImprime.WindowState = FormWindowState.Maximized
         frmImprime.ShowDialog()
      End Using
   End Sub
End Class