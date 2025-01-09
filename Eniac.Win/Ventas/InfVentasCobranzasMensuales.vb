Public Class InfVentasCobranzasMensuales

   Private _publicos As Publicos

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicos = New Publicos()

            cmbSucursal.Initializar(False, IdFuncion)
            cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal

            _publicos.CargaComboCategorias(cmbCategoria)
            _publicos.CargaComboDesdeEnum(cmbOrigenCategoria, GetType(Entidades.OrigenFK))
            cmbOrigenCategoria.SelectedValue = Entidades.OrigenFK.Actual

            _publicos.CargaComboEmpleados(cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR, IdUsuario:=String.Empty)
            _publicos.CargaComboDesdeEnum(cmbOrigenVendedor, GetType(Entidades.OrigenFK))
            cmbOrigenVendedor.SelectedValue = Entidades.OrigenFK.Actual

            _publicos.CargaComboUsuarios(cmbUsuario)
            _publicos.CargaComboZonasGeograficas(cmbZonaGeografica)
            _publicos.CargaComboDesdeEnum(cmbGrabanLibro, GetType(Entidades.Publicos.SiNoTodos))

            ugDetalle.AgregarTotalesSuma({"Contado", "CtaCte", "Cobros", "ContadoAnterior", "CtaCteAnterior", "CobrosAnterior"})
            ugDetalle.AgregarTotalCustomColumna("PorcCobro", New CustomSummaries.SummaryMargen("Cobros", "CtaCte", "PorcCobro"))
            ugDetalle.AgregarTotalCustomColumna("PorcCobroAnterior", New CustomSummaries.SummaryMargen("CobrosAnterior", "CtaCteAnterior", "PorcCobroAnterior"))
            ugDetalle.AgregarTotalCustomColumna("ContadoPorc", New CustomSummaries.SummaryMargen("Contado", "ContadoAnterior", "ContadoPorc"))
            ugDetalle.AgregarTotalCustomColumna("CtaCtePorc", New CustomSummaries.SummaryMargen("CtaCte", "CtaCteAnterior", "CtaCtePorc"))
            ugDetalle.AgregarTotalCustomColumna("CobrosPorc", New CustomSummaries.SummaryMargen("Cobros", "CobrosAnterior", "CobrosPorc"))

            'Hay que colocarlo del CargarColumnasASumar porque sino da error.
            PreferenciasLeer(ugDetalle, tsbPreferencias)

            RefrescarDatosGrilla()

            tsbImprimirPrediseñado.Visible = False
            tssImprimirPrediseñado.Visible = False

         End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F4 Then
         btnConsultar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
#End Region

#Region "Eventos"

#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub
   'Private Sub tsbImprimirPrediseñado_Click(sender As Object, e As EventArgs) Handles tsbImprimirPrediseñado.Click

   '   If ugDetalle.Rows.Count = 0 Then Exit Sub

   '   Try

   '      Dim Filtros As String = CargarFiltrosImpresion()

   '      Me.Cursor = Cursors.WaitCursor
   '      Dim dt As DataTable

   '      dt = DirectCast(ugDetalle.DataSource, DataTable)

   '      Dim parm = New List(Of Microsoft.Reporting.WinForms.ReportParameter)()

   '      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Reglas.Publicos.NombreEmpresa))
   '      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Eniac.Entidades.Usuario.Actual.Sucursal.Nombre))
   '      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", Filtros))

   '      Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.InformeDeVentas.rdlc", "SistemaDataSet_Ventas", dt, parm, True, 1) '# 1 = Cantidad Copias
   '      frmImprime.Text = Me.Text
   '      frmImprime.WindowState = FormWindowState.Maximized
   '      frmImprime.Show()

   '   Catch ex As Exception
   '      ShowError(ex)
   '   Finally
   '      Me.Cursor = Cursors.Default
   '   End Try
   'End Sub
   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(Sub() ugDetalle.Imprimir(Text, CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True, .FitWidthToPages = 1}))
   End Sub
   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(String.Format("{0}.xls", Name), Text, UltraGridExcelExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(String.Format("{0}.pdf", Name), Text, UltraGridDocumentExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugDetalle, tsbPreferencias))
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

#Region "Eventos Filtros"
   Private Sub dtpHasta_ValueChanged(sender As Object, e As EventArgs) Handles dtpHasta.ValueChanged
      TryCatched(
         Sub()
            dtpHasta.Value = dtpHasta.Value.UltimoDiaMes()
            dtpDesde.Value = dtpHasta.Value.PrimerDiaMes().AddMonths(-24).AddMonths(1)
         End Sub)
   End Sub
   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      TryCatched(Sub() chbCliente.FiltroCheckedChanged(usaPermitido:=True, bscCodigoCliente, bscCliente))
   End Sub
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaClientes2(bscCodigoCliente)
            Dim codigoCliente = bscCodigoCliente.Text.ValorNumericoPorDefecto(-1L)
            bscCodigoCliente.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(codigoCliente, True, False)
         End Sub)
   End Sub
   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaClientes2(bscCliente)
            bscCliente.Datos = New Reglas.Clientes().GetFiltradoPorNombre(bscCliente.Text.Trim(), False)
         End Sub)
   End Sub
   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCliente.BuscadorSeleccion
      TryCatched(
         Sub()
            If e.FilaDevuelta IsNot Nothing Then
               CargarDatosCliente(e.FilaDevuelta, bscCodigoCliente, bscCliente)
            End If
         End Sub)
   End Sub

   Private Sub chbCategoria_CheckedChanged(sender As Object, e As EventArgs) Handles chbCategoria.CheckedChanged
      TryCatched(Sub() chbCategoria.FiltroCheckedChanged(cmbCategoria))
   End Sub
   Private Sub chbVendedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbVendedor.CheckedChanged
      TryCatched(Sub() chbVendedor.FiltroCheckedChanged(cmbVendedor))
   End Sub
   Private Sub chbUsuario_CheckedChanged(sender As Object, e As EventArgs) Handles chbUsuario.CheckedChanged
      TryCatched(Sub() chbUsuario.FiltroCheckedChanged(cmbUsuario))
   End Sub
   Private Sub chbZonaGeografica_CheckedChanged(sender As Object, e As EventArgs) Handles chbZonaGeografica.CheckedChanged
      TryCatched(Sub() chbZonaGeografica.FiltroCheckedChanged(cmbZonaGeografica))
   End Sub
#End Region

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
         Sub()
            If chbCliente.Checked And Not bscCodigoCliente.Selecciono And Not bscCliente.Selecciono Then
               ShowMessage("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro.")
               bscCodigoCliente.Select()
               Exit Sub
            End If

            CargaGrillaDetalle()

            If ugDetalle.Rows.Count > 0 Then
               btnConsultar.Focus()
            Else
               ShowMessage("NO hay registros que cumplan con la seleccion !!!")
            End If
         End Sub)
   End Sub

#End Region

#Region "Metodos"

   Private Sub RefrescarDatosGrilla()

      cmbSucursal.Refrescar()

      'dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today.UltimoDiaMes(ultimoSegundo:=True)

      chbCliente.Checked = False
      chbCategoria.Checked = False
      cmbOrigenCategoria.SelectedValue = Entidades.OrigenFK.Actual
      chbVendedor.Checked = False
      cmbOrigenVendedor.SelectedValue = Entidades.OrigenFK.Actual
      chbUsuario.Checked = False
      chbZonaGeografica.Checked = False
      cmbGrabanLibro.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS


      ugDetalle.ClearFilas()

      dtpHasta.Select()

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar

   End Sub

   Private Sub CargaGrillaDetalle()

      Dim idCliente = If(chbCliente.Checked, ObjectExtensions.ValorNumericoPorDefecto(bscCodigoCliente.Tag, 0L), 0L)
      Dim idVendedor = If(chbVendedor.Checked, cmbVendedor.ItemSeleccionado(Of Entidades.Empleado).IdEmpleado, 0)
      Dim idZonaGeografica = If(cmbZonaGeografica.Enabled, cmbZonaGeografica.ItemSeleccionado(Of Entidades.ZonaGeografica).IdZonaGeografica, String.Empty)
      Dim idUsuario = If(cmbUsuario.Enabled, cmbUsuario.ValorSeleccionado(Of String), String.Empty)
      Dim idCategoria = If(cmbCategoria.Enabled, cmbCategoria.ValorSeleccionado(Of Integer), 0)

      Dim rVentas = New Reglas.Ventas()
      Dim dtDetalle = rVentas.GetVentasCobranzasMensuales(cmbSucursal.GetSucursales(),
                                                          dtpDesde.Value, dtpHasta.Value, idCliente,
                                                          idCategoria, cmbOrigenCategoria.ValorSeleccionado(Of Entidades.OrigenFK),
                                                          idVendedor, cmbOrigenVendedor.ValorSeleccionado(Of Entidades.OrigenFK),
                                                          idUsuario, idZonaGeografica, cmbGrabanLibro.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos)())

      ugDetalle.DataSource = dtDetalle

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar()
   End Sub

   Private Function CargarFiltrosImpresion() As String

      Dim filtro = New StringBuilder()
      With filtro

         cmbSucursal.CargarFiltrosImpresionSucursales(filtro, True, False)

         .AppendFormat("- Fecha: Desde {0:dd/MM/yyyy} Hasta {1:dd/MM/yyyy}", dtpDesde.Value, dtpHasta.Value)

         If chbCliente.Checked Then
            .AppendFormat(" - Cliente: {0} - {1}", bscCodigoCliente.Text, bscCliente.Text)
         End If

         If chbCategoria.Checked Then
            .AppendFormat(" - Categoría {0} {1}", cmbCategoria.SelectedText, cmbOrigenCategoria.Text)
         End If

         If chbVendedor.Checked Then
            .AppendFormat(" - Vendedor: {0} {1}", cmbVendedor.SelectedText, cmbOrigenVendedor.Text)
         End If

         If chbUsuario.Checked Then
            .AppendFormat(" - Usuario: {0}", cmbUsuario.SelectedText)
         End If

         If chbZonaGeografica.Checked Then
            .AppendFormat(" - Zona G.: {0}", cmbZonaGeografica.SelectedText)
         End If

         If cmbGrabanLibro.SelectedIndex >= 0 Then     '0 Es TODOS
            .AppendFormat(" - Graban Libro: {0}", cmbGrabanLibro.Text)
         End If

      End With

      Return filtro.ToString()

   End Function

   Private Sub CargarDatosCliente(dr As DataGridViewRow, controlCodigo As Eniac.Controles.Buscador2, controlNombre As Eniac.Controles.Buscador2)

      controlNombre.Text = dr.Cells("NombreCliente").Value.ToString()
      controlCodigo.Text = dr.Cells("CodigoCliente").Value.ToString()
      controlCodigo.Tag = dr.Cells("IdCliente").Value.ToString()
      controlNombre.Permitido = False
      controlCodigo.Permitido = False
      controlNombre.Selecciono = True
      controlCodigo.Selecciono = True

      btnConsultar.Focus()

   End Sub

#End Region

End Class