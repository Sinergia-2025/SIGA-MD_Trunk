Public Class InfComprasPagosMensuales

   Private _publicos As Publicos

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicos = New Publicos()

            cmbSucursal.Initializar(False, IdFuncion)
            cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal

            _publicos.CargaComboCategoriasProveedores(cmbCategoria)

            _publicos.CargaComboUsuarios(cmbUsuario)
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
   Private Sub chbProveedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbProveedor.CheckedChanged
      TryCatched(Sub() chbProveedor.FiltroCheckedChanged(usaPermitido:=True, bscCodigoProveedor, bscProveedor))
   End Sub
   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaProveedores2(bscCodigoProveedor)
            Dim codigoProveedor = bscCodigoProveedor.Text.ValorNumericoPorDefecto(-1L)
            bscCodigoProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorCodigo(codigoProveedor, True)
         End Sub)
   End Sub
   Private Sub bscProveedor_BuscadorClick() Handles bscProveedor.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaProveedores2(bscProveedor)
            bscProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorNombre(bscProveedor.Text.Trim())
         End Sub)
   End Sub
   Private Sub bscCodigoProveedor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion, bscProveedor.BuscadorSeleccion
      TryCatched(
         Sub()
            If e.FilaDevuelta IsNot Nothing Then
               CargarDatosProveedor(e.FilaDevuelta, bscCodigoProveedor, bscProveedor)
            End If
         End Sub)
   End Sub

   Private Sub chbCategoria_CheckedChanged(sender As Object, e As EventArgs) Handles chbCategoria.CheckedChanged
      TryCatched(Sub() chbCategoria.FiltroCheckedChanged(cmbCategoria))
   End Sub
   Private Sub chbUsuario_CheckedChanged(sender As Object, e As EventArgs) Handles chbUsuario.CheckedChanged
      TryCatched(Sub() chbUsuario.FiltroCheckedChanged(cmbUsuario))
   End Sub
#End Region

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
         Sub()
            If chbProveedor.Checked And Not bscCodigoProveedor.Selecciono And Not bscProveedor.Selecciono Then
               ShowMessage("ATENCION: NO seleccionó un Proveedor aunque activó ese Filtro.")
               bscCodigoProveedor.Select()
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

      chbProveedor.Checked = False
      chbCategoria.Checked = False
      chbUsuario.Checked = False
      cmbGrabanLibro.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS


      ugDetalle.ClearFilas()

      dtpHasta.Select()

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar

   End Sub

   Private Sub CargaGrillaDetalle()

      Dim idCliente = If(chbProveedor.Checked, ObjectExtensions.ValorNumericoPorDefecto(bscCodigoProveedor.Tag, 0L), 0L)
      Dim idUsuario = If(cmbUsuario.Enabled, cmbUsuario.ValorSeleccionado(Of String), String.Empty)
      Dim idCategoria = If(cmbCategoria.Enabled, cmbCategoria.ValorSeleccionado(Of Integer), 0)

      Dim rVentas = New Reglas.Compras()
      Dim dtDetalle = rVentas.GetComprasPagosMensuales(cmbSucursal.GetSucursales(),
                                                          dtpDesde.Value, dtpHasta.Value, idCliente,
                                                          idCategoria,
                                                          idUsuario, cmbGrabanLibro.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos)())

      ugDetalle.DataSource = dtDetalle

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar()
   End Sub

   Private Function CargarFiltrosImpresion() As String

      Dim filtro = New StringBuilder()
      With filtro

         cmbSucursal.CargarFiltrosImpresionSucursales(filtro, True, False)

         .AppendFormat("- Fecha: Desde {0:dd/MM/yyyy} Hasta {1:dd/MM/yyyy}", dtpDesde.Value, dtpHasta.Value)

         If chbProveedor.Checked Then
            .AppendFormat(" - Cliente: {0} - {1}", bscCodigoProveedor.Text, bscProveedor.Text)
         End If

         If chbCategoria.Checked Then
            .AppendFormat(" - Categoría {0} ", cmbCategoria.SelectedText)
         End If

         If chbUsuario.Checked Then
            .AppendFormat(" - Usuario: {0}", cmbUsuario.SelectedText)
         End If

         If cmbGrabanLibro.SelectedIndex >= 0 Then     '0 Es TODOS
            .AppendFormat(" - Graban Libro: {0}", cmbGrabanLibro.Text)
         End If

      End With

      Return filtro.ToString()

   End Function

   Private Sub CargarDatosProveedor(dr As DataGridViewRow, controlCodigo As Eniac.Controles.Buscador2, controlNombre As Eniac.Controles.Buscador2)

      controlNombre.Text = dr.Cells("NombreProveedor").Value.ToString()
      controlCodigo.Text = dr.Cells("CodigoProveedor").Value.ToString()
      controlCodigo.Tag = dr.Cells("IdProveedor").Value.ToString()
      controlNombre.Permitido = False
      controlCodigo.Permitido = False
      controlNombre.Selecciono = True
      controlCodigo.Selecciono = True

      btnConsultar.Focus()

   End Sub

#End Region

End Class