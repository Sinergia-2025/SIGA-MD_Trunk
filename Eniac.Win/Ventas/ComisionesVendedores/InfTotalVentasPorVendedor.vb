Public Class InfTotalVentasPorVendedor

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As System.EventArgs)

      MyBase.OnLoad(e)

      Try
         Me._publicos = New Publicos()

         Me.dtpDesde.Value = Date.Today
         Me.dtpHasta.Value = Date.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)

         Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
         Me.cmbVendedor.SelectedIndex = -1
         Me._publicos.CargaComboDesdeEnum(cmbTipoVendedor, GetType(Entidades.OrigenFK))
         Me.cmbTipoVendedor.SelectedValue = Entidades.OrigenFK.Movimiento

         Me.cmbConComision.Items.Insert(0, "TODOS")
         Me.cmbConComision.Items.Insert(1, "SI")
         Me.cmbConComision.Items.Insert(2, "NO")
         Me.cmbConComision.SelectedIndex = 1

         Me._publicos.CargaComboZonasGeograficas(Me.cmbZonaGeografica)
         Me.cmbZonaGeografica.SelectedIndex = -1

         Me.cmbAfectaCaja.Items.Insert(0, "TODOS")
         Me.cmbAfectaCaja.Items.Insert(1, "SI")
         Me.cmbAfectaCaja.Items.Insert(2, "NO")
         Me.cmbAfectaCaja.SelectedIndex = 1

         Me.cmbSucursal.Initializar(False, IdFuncion)
         Me.cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal

         chbUnificar.Enabled = cmbSucursal.Enabled

         Me.chbConIVA.Checked = Reglas.Publicos.ConsultarPreciosConIVA

         cmbGrupos.Inicializar()

         Me._publicos.CargaComboDesdeEnum(cmbGrabanLibro, GetType(Entidades.Publicos.SiNoTodos))

         cmbTiposComprobantes.Initializar(False, "VENTAS")
         Me.cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()

         dgvDetalle.AgregarFiltroEnLinea({"NombreVendedor"})
         dgvDetalle.AgregarTotalesSuma({"CantComprobantes", "CantItems", "TotalContado", "TotalCtaCte", "Total", "Comision"})

         Me.PreferenciasLeer(dgvDetalle, tsbPreferencias)

         MostrarConfiguracion()

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#End Region

#Region "Eventos"

   Private Sub InfTotalVentasPorVendedor_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(sender As System.Object, e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

      Catch ex As Exception
         ShowError(ex)

      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbImprimir_Click(sender As System.Object, e As System.EventArgs) Handles tsbImprimir.Click
      Try

         If Me.dgvDetalle.Rows.Count = 0 Then Exit Sub

         Dim Filtros As String = Me.CargarFiltrosImpresion

         Dim Titulo As String

         Titulo = Reglas.Publicos.NombreEmpresa + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Filtros

         Dim UltraPrintPreviewD As Infragistics.Win.Printing.UltraPrintPreviewDialog
         UltraPrintPreviewD = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
         UltraPrintPreviewD.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
         UltraPrintPreviewD.Name = "UltraPrintPreviewDialog1"

         UltraPrintPreviewD.Document = Me.UltraGridPrintDocument1
         UltraPrintPreviewD.Name = Me.Text

         Me.UltraGridPrintDocument1.Header.TextCenter = Titulo
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.Bold = DefaultableBoolean.True
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.SizeInPoints = 10
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 40
         Me.UltraGridPrintDocument1.DefaultPageSettings.Landscape = False
         Me.UltraGridPrintDocument1.Footer.TextLeft = "Sucursal: " + actual.Sucursal.Nombre
         Me.UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + DateTime.Today.ToString("dd/MM/yyyy")

         UltraPrintPreviewD.MdiParent = Me.MdiParent
         UltraPrintPreviewD.Show()
         UltraPrintPreviewD.Focus()

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub tsbImprimir2_Click(sender As Object, e As EventArgs) Handles tsbImprimir2.Click
      Try

         If Me.dgvDetalle.Rows.Count = 0 Then Exit Sub

         Me.Cursor = Cursors.WaitCursor

         Dim Filtros As String = Me.CargarFiltrosImpresion

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Reglas.Publicos.NombreEmpresa))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Eniac.Entidades.Usuario.Actual.Sucursal.Nombre))

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", Filtros))

         Dim dt As DataTable

         dt = DirectCast(Me.dgvDetalle.DataSource, DataTable)

         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.InfTotalVentasPorVendedor.rdlc", "dsVentas_InfTotalVentasPorVendedor", dt, parm, True, 1) '# 1 = Cantidad Copias

         'Porque en la impresion sale la barra Horizonzal?? en algun lado quedo apaisada ??
         frmImprime.Text = Me.Text
         frmImprime.Show()

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub tsbSalir_Click(sender As System.Object, e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub chbZonaGeografica_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chbZonaGeografica.CheckedChanged

      Me.cmbZonaGeografica.Enabled = Me.chbZonaGeografica.Checked

      If Not Me.chbZonaGeografica.Checked Then
         Me.cmbZonaGeografica.SelectedIndex = -1
      Else
         If Me.cmbZonaGeografica.Items.Count > 0 Then
            Me.cmbZonaGeografica.SelectedIndex = 0
         End If

         Me.cmbZonaGeografica.Focus()

      End If

   End Sub

   Private Sub chbCliente_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chbCliente.CheckedChanged

      Me.bscCodigoCliente.Enabled = Me.chbCliente.Checked
      Me.bscCliente.Enabled = Me.chbCliente.Checked


      Me.bscCodigoCliente.Text = String.Empty
      Me.bscCodigoCliente.Tag = Nothing
      Me.bscCliente.Text = String.Empty

      Me.bscCodigoCliente.Focus()

   End Sub

   Private Sub chbVendedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbVendedor.CheckedChanged
      Me.cmbVendedor.Enabled = Me.chbVendedor.Checked

      If Not Me.chbVendedor.Checked Then
         Me.cmbVendedor.SelectedIndex = -1
         Me.cmbTipoVendedor.SelectedValue = Entidades.OrigenFK.Movimiento
      Else
         If Me.cmbVendedor.Items.Count > 0 Then
            Me.cmbVendedor.SelectedIndex = 0
         End If
      End If

      Me.cmbVendedor.Focus()
   End Sub

   Private Sub chbMesCompleto_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chbMesCompleto.CheckedChanged

      Dim FechaTemp As Date

      Try

         If Me.chbMesCompleto.Checked Then

            FechaTemp = New Date(Me.dtpDesde.Value.Year, Me.dtpDesde.Value.Month, 1)
            Me.dtpDesde.Value = FechaTemp

            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 Segundo.
            FechaTemp = Me.dtpDesde.Value.AddMonths(1).AddSeconds(-1)
            dtpHasta.Value = FechaTemp

         End If

         Me.dtpDesde.Enabled = Not Me.chbMesCompleto.Checked
         Me.dtpHasta.Enabled = Not Me.chbMesCompleto.Checked

      Catch ex As Exception

         Me.chbMesCompleto.Checked = False

         ShowError(ex)

      End Try

   End Sub

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick, bscCodigoCliente.BuscadorClick
      Dim codigoCliente As Long = -1
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscCodigoCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         If Me.bscCodigoCliente.Text.Trim.Length > 0 Then
            codigoCliente = Long.Parse(Me.bscCodigoCliente.Text.Trim())
         End If
         Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, False)
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCodigoCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         Me.bscCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), False)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnConsultar_Click(sender As System.Object, e As System.EventArgs) Handles btnConsultar.Click
      Try

         Me.Cursor = Cursors.WaitCursor

         If Me.chbVendedor.Checked And Me.cmbVendedor.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO seleccionó un Vendedor aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbVendedor.Focus()
            Exit Sub
         End If

         If Me.chbCliente.Checked And Not (Me.bscCodigoCliente.Selecciono Or Me.bscCliente.Selecciono) Then
            MessageBox.Show("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If

         If Me.chbZonaGeografica.Checked And cmbZonaGeografica.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO seleccionó una Zona Geográfica aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbZonaGeografica.Focus()
            Exit Sub
         End If
         If Me.chbTipoComprobante.Checked And cmbTiposComprobantes.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO Informó un tipo de comprobante aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.cmbTiposComprobantes.Focus()
            Exit Sub
         End If


         Me.CargaGrillaDetalle()

         If dgvDetalle.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("ATENCION: NO hay registros que cumplan con la seleccion !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub
   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         PreferenciasCargar(dgvDetalle, tsbPreferencias)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      Try
         If Me.dgvDetalle.Rows.Count = 0 Then Exit Sub
         dgvDetalle.Exportar(Me.Name & ".xls", Me.Text, UltraGridExcelExporter1, Me.CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      Try
         If Me.dgvDetalle.Rows.Count = 0 Then Exit Sub
         dgvDetalle.Exportar(Me.Name & ".pdf", Me.Text, UltraGridDocumentExporter1, Me.CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub chbTipoComprobante_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chbTipoComprobante.CheckedChanged
      Try
         Me.cmbTiposComprobantes.Enabled = Me.chbTipoComprobante.Checked

         If Not Me.chbTipoComprobante.Checked Then
            Me.cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()
         Else
            Me.cmbTiposComprobantes.SelectedIndex = -1
            Me.cmbTiposComprobantes.Focus()
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarDatosCliente(dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False

   End Sub

   Private Sub RefrescarDatosGrilla()

      Me.chbMesCompleto.Checked = False

      Me.dtpDesde.Value = Date.Today
      Me.dtpHasta.Value = Date.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)

      Me.cmbConComision.SelectedIndex = 1 'SI

      Me.chbCliente.Checked = False

      Me.cmbAfectaCaja.SelectedIndex = 1  'SI

      Me.chbConIVA.Checked = Reglas.Publicos.ConsultarPreciosConIVA

      'Limpio la Grilla.
      If Not Me.dgvDetalle.DataSource Is Nothing Then
         DirectCast(Me.dgvDetalle.DataSource, DataTable).Rows.Clear()
      End If

      cmbSucursal.Refrescar()

      chbUnificar.Checked = True

      chbVendedor.Checked = False

      Me.chbTipoComprobante.Checked = False

      Me.cmbGrabanLibro.SelectedIndex = 0

      Me.cmbGrupos.Refrescar()

      Me.dtpDesde.Focus()

   End Sub

   Private Sub MostrarConfiguracion()
      txtCalculoComisionVendedor.Text = Reglas.Publicos.CalculoComisionVendedor
      txtComisionVendedor.Text = If(Reglas.Publicos.ComisionVendedor = "VENDEDORRUBROMARCA", "Vendedor-Rubro-Marca", "Vendedor-Marca-Rubro")
   End Sub

   Private Sub CargaGrillaDetalle()

      Dim idZonaGeografica = If(chbZonaGeografica.Checked, cmbZonaGeografica.ValorSeleccionado(Of String), String.Empty)
      Dim idCliente = If(chbCliente.Checked, Long.Parse(Me.bscCodigoCliente.Tag.ToString()), 0L)
      Dim idVendedor = If(Me.chbVendedor.Checked, Me.cmbVendedor.ValorSeleccionado(Of Integer), 0I)
      Dim activaObjetivo = Me.dtpDesde.Value.Year = Me.dtpHasta.Value.Year AndAlso Me.dtpDesde.Value.Month = Me.dtpHasta.Value.Month

      Dim oVentas As Reglas.Ventas = New Reglas.Ventas()
      Me.dgvDetalle.DataSource = oVentas.GetComisionesTotalesPorVendedor(cmbSucursal.GetSucursales(),
                                                                           Me.dtpDesde.Value, Me.dtpHasta.Value,
                                                                           Me.cmbConComision.Text,
                                                                           idCliente,
                                                                           idZonaGeografica,
                                                                           Me.cmbAfectaCaja.Text, Me.chbConIVA.Checked,
                                                                           Me.chbUnificar.Checked, activaObjetivo,
                                                                           cmbTiposComprobantes.GetTiposComprobantes(),
                                                                           Me.cmbGrabanLibro.Text,
                                                                           Me.cmbGrupos.GetGruposTiposComprobantes(),
                                                                           idVendedor,
                                                                           cmbTipoVendedor.ValorSeleccionado(Of Entidades.OrigenFK))

      Me.dgvDetalle.DisplayLayout.Bands(0).Columns("PorcObjetivo").Hidden = Not activaObjetivo
      Me.dgvDetalle.DisplayLayout.Bands(0).Columns("ImporteObjetivo").Hidden = Not activaObjetivo

      MostrarConfiguracion()

      Me.dgvDetalle.DisplayLayout.Bands(0).Columns("IdSucursal").Hidden = Me.chbUnificar.Checked

   End Sub

   Private Function CargarFiltrosImpresion() As String

      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      Dim Primero As Boolean = True

      With filtro

         If Me.cmbSucursal.Enabled Then
            Me.cmbSucursal.CargarFiltrosImpresionSucursales(filtro, muestraId:=False, muestraNombre:=True)
            .AppendFormat(" - ")
         End If

         cmbTiposComprobantes.CargarFiltrosImpresionTiposComprobantes(filtro, True, False)

         .AppendFormat("  Fecha: Desde {0} Hasta {1} - ", Me.dtpDesde.Text, dtpHasta.Text)

         If Me.chbZonaGeografica.Checked Then
            .AppendFormat(" Zona Geografica: {0} - ", Me.cmbZonaGeografica.Text)
         End If

         If Me.chbCliente.Checked Then
            .AppendFormat(" Cliente: {0} - {1} - ", Me.bscCodigoCliente.Text, Me.bscCliente.Text)
         End If

         If Me.cmbConComision.Text <> "TODOS" Then
            .AppendFormat(" Con Comisión: {0} - ", Me.cmbConComision.Text)
         End If

         If Me.cmbAfectaCaja.Text <> "TODOS" Then
            .AppendFormat("  Afecta Caja: {0} - ", Me.cmbAfectaCaja.Text)
         End If

         If Me.chbConIVA.Checked Then
            .AppendFormat("  Con IVA - ")
         End If

         If Me.cmbGrabanLibro.SelectedIndex >= 0 Then
            .AppendFormat("  Graban Libro: {0} - ", Me.cmbGrabanLibro.Text)
         End If

         Me.cmbGrupos.CargarFiltrosImpresionTiposComprobantes(filtro, False, True)

         If Me.chbVendedor.Checked Then
            .AppendFormat(" - Vendedor({0}): {1}", Me.cmbTipoVendedor.Text, Me.cmbVendedor.Text)
         End If

      End With

      Return filtro.ToString.Trim().Trim("-"c)

   End Function
#End Region

End Class