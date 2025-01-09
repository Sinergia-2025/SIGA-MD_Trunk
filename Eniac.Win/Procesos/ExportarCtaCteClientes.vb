Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class ExportarCtaCteClientes

#Region "Campos"

   Private _publicos As Publicos
   Private IdUsuario As String = actual.Nombre
   Private _CtaCteClientesWeb As CtaCteClientesWeb

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         'Si el Usuario no tiene Vendedores asociados limpio la variable para que no filtre en el cargar combo.
         If New Reglas.Empleados().GetPorUsuario(IdUsuario).Rows.Count = 0 Then
            IdUsuario = ""
         End If

         Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR, IdUsuario)
         If IdUsuario = "" Then
            Me.cmbVendedor.SelectedIndex = -1
         Else
            Me.chbVendedor.Checked = True
            Me.chbVendedor.Enabled = False  'Para que no pueda modificarlo manualmente
         End If

         Me._publicos.CargaComboZonasGeograficas(Me.cmbZonaGeografica)
         Me.cmbZonaGeografica.SelectedIndex = -1

         Me._publicos.CargaComboCategorias(Me.cmbCategoria)

         Me.cmbGrabanLibro.Items.Insert(0, "TODOS")
         Me.cmbGrabanLibro.Items.Insert(1, "SI")
         Me.cmbGrabanLibro.Items.Insert(2, "NO")
         Me.cmbGrabanLibro.SelectedIndex = 0
         Me._publicos.CargaComboProvincias(Me.cmbProvincia)

         Me._publicos.CargaComboGrupos(Me.cmbGrupos)
         Me.cmbGrupos.SelectedIndex = -1

         cmbGrupos.Inicializar()
         Me.cmbGrupos.SelectedValue = Convert.ToInt32(Entidades.Grupo.ValoresFijosGrupos.Todos).ToString()

         '  Me.ugDetalle.DisplayLayout.Bands(0).Columns("NombreVendedor").Hidden = (Me.cmbVendedor.Items.Count = 1)

         Me.CargarColumnasASumar()

         'Da la posibilidad de que podamos elegir las columnas que queremos mostrar u ocultar con un botón a la izquierda de la cabecera.
         'Me.ugDetalle.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.ColumnChooserButton
         'Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True

         'Me._estaCargando = False

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub SaldosCtaCteClientes_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatos()

         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click

      Try

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim Filtros As String = String.Empty

         If Me.cmbVendedor.SelectedIndex >= 0 Then
            Filtros = "Vendedor: " & Me.cmbVendedor.Text
         End If

         If Me.cmbZonaGeografica.SelectedIndex >= 0 Then
            If Filtros.Length > 0 Then Filtros = Filtros & " - "
            Filtros = Filtros & "Zona G.: " & Me.cmbZonaGeografica.Text
         End If

         If Me.bscCodigoCliente.Text.Length > 0 And Me.bscCliente.Text.Length > 0 Then
            If Filtros.Length > 0 Then Filtros = Filtros & " - "
            Filtros = Filtros & "Cliente: " & Me.bscCodigoCliente.Text & " - " & Me.bscCliente.Text
         End If

         If Me.chbFecha.Checked Then
            If Filtros.Length > 0 Then Filtros = Filtros & " - "
            Filtros = Filtros & "Fecha: hasta " & Me.dtpHasta.Text
         End If

         If Me.chbExcluirSaldosNegativos.Checked Then
            If Filtros.Length > 0 Then Filtros = Filtros & " - "
            Filtros = Filtros & "Excluir Saldos Negativos"
         End If

         If Me.chbCategoria.Checked Then
            If Filtros.Length > 0 Then Filtros = Filtros & " - "
            Filtros = Filtros & "Categoría: " & Me.cmbCategoria.Text
         End If

         '0 Es TODOS
         If Me.cmbGrabanLibro.SelectedIndex > 0 Then
            If Filtros.Length > 0 Then Filtros = Filtros & " - "
            Filtros = Filtros & "Graban Libro: " & Me.cmbGrabanLibro.Text
         End If

         If Me.chbProvincia.Checked Then
            If Filtros.Length > 0 Then Filtros = Filtros & " - "
            Filtros = Filtros & "Provincia: " & Me.cmbProvincia.Text
         End If

         If Me.chbExcluirAnticipos.Checked Then
            If Filtros.Length > 0 Then Filtros = Filtros & " - "
            Filtros = Filtros & "Excluir Anticipos"
         End If

         Dim Titulo As String

         Titulo = Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Filtros

         Dim UltraPrintPreviewD As Infragistics.Win.Printing.UltraPrintPreviewDialog
         UltraPrintPreviewD = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
         UltraPrintPreviewD.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
         UltraPrintPreviewD.Name = "UltraPrintPreviewDialog1"

         UltraPrintPreviewD.Document = Me.UltraGridPrintDocument1
         UltraPrintPreviewD.Name = Me.Text

         Me.UltraGridPrintDocument1.Header.TextCenter = Titulo
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.Bold = DefaultableBoolean.True
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.SizeInPoints = 12
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
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub tsmiAExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAExcel.Click
      Try
         Me.sfdExportar.FileName = Me.Name & ".xls"
         Me.sfdExportar.Filter = "Archivos excel|*.xls"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Me.UltraGridExcelExporter1.Export(Me.ugDetalle, Me.sfdExportar.FileName, Infragistics.Documents.Excel.WorkbookFormat.Excel97To2003)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAPDF.Click
      Try
         Me.sfdExportar.FileName = Me.Name & ".pdf"
         Me.sfdExportar.Filter = "Archivos pdf|*.pdf"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Me.UltraGridDocumentExporter1.Export(Me.ugDetalle, Me.sfdExportar.FileName, DocumentExport.GridExportFileFormat.PDF)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub UltraGridPrintDocument1_PagePrinting(ByVal sender As System.Object, ByVal e As Infragistics.Win.Printing.PagePrintingEventArgs) Handles UltraGridPrintDocument1.PagePrinting
      Me.UltraGridPrintDocument1.Footer.TextRight = "Página: " + Me.UltraGridPrintDocument1.PageNumber.ToString()
   End Sub

   Private Sub tsbImprimir2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

      Try

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim Filtros As String = String.Empty

         Dim dt As DataTable

         Me.Cursor = Cursors.WaitCursor

         If Me.cmbVendedor.SelectedIndex >= 0 Then
            Filtros = "Vendedor: " & Me.cmbVendedor.Text
         End If

         If Me.cmbZonaGeografica.SelectedIndex >= 0 Then
            If Filtros.Length > 0 Then Filtros = Filtros & " - "
            Filtros = Filtros & "Zona G.: " & Me.cmbZonaGeografica.Text
         End If

         If Me.bscCodigoCliente.Text.Length > 0 And Me.bscCliente.Text.Length > 0 Then
            If Filtros.Length > 0 Then Filtros = Filtros & " - "
            Filtros = Filtros & "Cliente: " & Me.bscCodigoCliente.Text & " - " & Me.bscCliente.Text
         End If

         If Me.chbFecha.Checked Then
            If Filtros.Length > 0 Then Filtros = Filtros & " - "
            Filtros = Filtros & "Fecha: hasta " & Me.dtpHasta.Text
         End If

         If Me.chbExcluirSaldosNegativos.Checked Then
            If Filtros.Length > 0 Then Filtros = Filtros & " - "
            Filtros = Filtros & "Excluir Saldos Negativos"
         End If

         If Me.chbCategoria.Checked Then
            If Filtros.Length > 0 Then Filtros = Filtros & " - "
            Filtros = Filtros & "Categoría: " & Me.cmbCategoria.Text
         End If

         '0 Es TODOS
         If Me.cmbGrabanLibro.SelectedIndex > 0 Then
            If Filtros.Length > 0 Then Filtros = Filtros & " - "
            Filtros = Filtros & "Graban Libro: " & Me.cmbGrabanLibro.Text
         End If

         If Me.chbProvincia.Checked Then
            If Filtros.Length > 0 Then Filtros = Filtros & " - "
            Filtros = Filtros & "Provincia: " & Me.cmbProvincia.Text
         End If

         If Me.chbExcluirAnticipos.Checked Then
            If Filtros.Length > 0 Then Filtros = Filtros & " - "
            Filtros = Filtros & "Excluir Anticipos"
         End If

         dt = DirectCast(Me.ugDetalle.DataSource, DataTable)

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Eniac.Entidades.Usuario.Actual.Sucursal.Nombre))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", Filtros))

         Dim frmImprime As VisorReportes
         If Not Me.chbFecha.Checked Then
            If Me.cmbVendedor.SelectedIndex >= 0 Then
               frmImprime = New VisorReportes("Eniac.Win.SaldosCtaCteClientes.rdlc", "SistemaDataSet_SaldosCtaCteClientes", dt, parm, True, 1) '# 1 = Cantidad Copias
            Else
               frmImprime = New VisorReportes("Eniac.Win.SaldosCtaCteClientesPorVendedor.rdlc", "SistemaDataSet_SaldosCtaCteClientes", dt, parm, True, 1) '# 1 = Cantidad Copias
            End If
         Else
            If Me.cmbVendedor.SelectedIndex >= 0 Then
               frmImprime = New VisorReportes("Eniac.Win.SaldosCtaCteClientesT.rdlc", "SistemaDataSet_SaldosCtaCteClientes", dt, parm, True, 1) '# 1 = Cantidad Copias
            Else
               frmImprime = New VisorReportes("Eniac.Win.SaldosCtaCteClientesPorVendedorT.rdlc", "SistemaDataSet_SaldosCtaCteClientes", dt, parm, True, 1) '# 1 = Cantidad Copias
            End If
         End If

         frmImprime.Text = Me.Text
         frmImprime.WindowState = FormWindowState.Maximized
         frmImprime.Show()

         Me.Cursor = Cursors.Default

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub chbVendedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbVendedor.CheckedChanged

      Me.cmbVendedor.Enabled = Me.chbVendedor.Checked

      If Not Me.chbVendedor.Checked Then
         Me.cmbVendedor.SelectedIndex = -1
      Else
         If Me.cmbVendedor.Items.Count > 0 Then
            Me.cmbVendedor.SelectedIndex = 0
         End If

         Me.cmbVendedor.Focus()

      End If

   End Sub

   Private Sub chbZonaGeografica_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbZonaGeografica.CheckedChanged

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

   Private Sub chbFecha_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbFecha.CheckedChanged

      Me.dtpHasta.Enabled = Me.chbFecha.Checked

      If Me.chbFecha.Checked Then
         Me.dtpHasta.Value = Date.Now
      End If

      Me.dtpHasta.Focus()

   End Sub

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick, bscCodigoCliente.BuscadorClick
      Dim codigoCliente As Long = -1
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscCodigoCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         If Me.bscCodigoCliente.Text.Trim.Length > 0 Then
            codigoCliente = Long.Parse(Me.bscCodigoCliente.Text.Trim())
         End If
         Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCodigoCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         Me.bscCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCliente.CheckedChanged

      Me.bscCodigoCliente.Enabled = Me.chbCliente.Checked
      Me.bscCliente.Enabled = Me.chbCliente.Checked

      Me.bscCodigoCliente.Text = String.Empty
      Me.bscCodigoCliente.Tag = Nothing
      Me.bscCliente.Text = String.Empty

      Me.bscCodigoCliente.Focus()

   End Sub

   Private Sub chbCategoria_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCategoria.CheckedChanged

      Me.cmbCategoria.Enabled = Me.chbCategoria.Checked

      If Not Me.chbCategoria.Checked Then
         Me.cmbCategoria.SelectedIndex = -1
      Else
         If Me.cmbCategoria.Items.Count > 0 Then
            Me.cmbCategoria.SelectedIndex = 0
         End If

         Me.cmbCategoria.Focus()

      End If

   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         Me.tsbExportar.Enabled = True 'Nueva Linea

         If Me.chbCliente.Checked And Me.bscCodigoCliente.Text.Length = 0 Then
            MessageBox.Show("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If

         Me.chkExpandAll.Enabled = True
         Me.chkExpandAll.Checked = False

         Me.chbTodos.Checked = False

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If Me.ugDetalle.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("ATENCION: NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

      Catch ex As Exception
         Me.tssRegistros.Text = "0 Registros"
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub chkExpandAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkExpandAll.CheckedChanged
      If Me.chkExpandAll.Checked Then
         Me.ugDetalle.Rows.ExpandAll(True)
      Else
         Me.ugDetalle.Rows.CollapseAll(True)
      End If
   End Sub

   Private Sub chbProvincia_CheckedChanged(sender As Object, e As EventArgs) Handles chbProvincia.CheckedChanged

      Me.cmbProvincia.Enabled = Me.chbProvincia.Checked

      If Not Me.chbProvincia.Checked Then
         Me.cmbProvincia.SelectedIndex = -1
      Else
         If Me.cmbProvincia.Items.Count > 0 Then
            Me.cmbProvincia.SelectedIndex = 0
         End If
         Me.cmbProvincia.Focus()
      End If

   End Sub

   'NUEVO
   Private Sub tsbExportar_Click(sender As Object, e As EventArgs) Handles tsbExportar.Click
      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Me.Cursor = Cursors.WaitCursor

         Me.ExportarDatos()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   'NUEVO

   Private Sub btnExaminar_Click(sender As Object, e As EventArgs) Handles btnExaminar.Click
      Dim DialogoGuardarArchivo As New SaveFileDialog()

      DialogoGuardarArchivo.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
      DialogoGuardarArchivo.Filter = "Archivos de Texto (*.csv)|*.csv|Todos los Archivos (*.*)|*.*"
      DialogoGuardarArchivo.FilterIndex = 1
      DialogoGuardarArchivo.RestoreDirectory = True

      If DialogoGuardarArchivo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
         Try
            If DialogoGuardarArchivo.FileName <> "" Then

               Me.txtArchivoDestino.Text = DialogoGuardarArchivo.FileName

            End If

         Catch Ex As Exception
            MessageBox.Show(Ex.Message)
         End Try
      End If
   End Sub

   Private Sub chbTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTodos.CheckedChanged
      Try
         Me.Cursor = Cursors.WaitCursor
         For Each dr As UltraGridRow In Me.ugDetalle.Rows
            dr.Cells("Check").Value = Me.chbTodos.Checked
         Next
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarColumnasASumar()

      Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
      Me.ugDetalle.DisplayLayout.Override.SummaryValueAppearance.BackColor = Color.Yellow

      Dim columnToSummarize1 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("ImporteCuota")
      Dim summary1 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("ImporteCuota", SummaryType.Sum, columnToSummarize1)
      summary1.DisplayFormat = "{0:N2}"
      summary1.Appearance.TextHAlign = HAlign.Right

      Dim columnToSummarize2 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("SaldoCuota")
      Dim summary2 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("SaldoCuota", SummaryType.Sum, columnToSummarize2)
      summary2.DisplayFormat = "{0:N2}"
      summary2.Appearance.TextHAlign = HAlign.Right

      Me.ugDetalle.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales:"

   End Sub

   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False

   End Sub

   Private Sub RefrescarDatos()

      If IdUsuario = "" Then
         Me.chbVendedor.Checked = False
      End If

      Me.chbZonaGeografica.Checked = False
      Me.chbCliente.Checked = False
      Me.chbFecha.Checked = False
      Me.chbExcluirSaldosNegativos.Checked = False
      Me.chbCategoria.Checked = False
      Me.cmbGrabanLibro.SelectedIndex = 0
      Me.cmbGrupos.Refrescar()
      Me.chbExcluirAnticipos.Checked = False
      Me.chbExcluirPreComprobantes.Checked = False
      Me.chbProvincia.Checked = False

      Me.chkExpandAll.Checked = False
      Me.chkExpandAll.Enabled = False

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.btnConsultar.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()

      Dim oCtaCteDet As Reglas.CuentasCorrientesPagos = New Reglas.CuentasCorrientesPagos()

      Dim Total1 As Decimal = 0
      Dim Total2 As Decimal = 0

      Dim IdVendedor As Integer = 0

      Dim idZonaGeografica As String = String.Empty
      Dim FechaHasta As Date = Nothing
      Dim IdCliente As Long = 0
      Dim ExcluirSaldosNegativos As String = "NO"
      Dim IdCategoria As Integer = 0
      Dim Grupo As String = String.Empty
      Dim ExcluirAnticipos As String = "NO"
      Dim ExcluirPreComprobantes As String = "NO"
      Dim IdProvincia As String = String.Empty
      Dim IdEmbarcacion As Integer = 0
      Dim IdCama As Long = 0

      Try

         '---------------------------------------------------------------------------------------------

         If Me.chbFecha.Checked Then
            FechaHasta = Me.dtpHasta.Value
         End If

         If Me.cmbVendedor.Enabled Then
            IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado
         End If

         If Me.cmbZonaGeografica.Enabled Then
            idZonaGeografica = DirectCast(Me.cmbZonaGeografica.SelectedItem, Entidades.ZonaGeografica).IdZonaGeografica
         End If

         If Me.bscCodigoCliente.Text.Length > 0 Then
            IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
         End If

         If Me.chbExcluirSaldosNegativos.Checked Then
            ExcluirSaldosNegativos = "SI"
         End If

         If Me.cmbCategoria.Enabled Then
            IdCategoria = Integer.Parse(Me.cmbCategoria.SelectedValue.ToString())
         End If

         If Me.chbExcluirAnticipos.Checked Then
            ExcluirAnticipos = "SI"
         End If

         If Me.chbExcluirPreComprobantes.Checked Then
            ExcluirPreComprobantes = "SI"
         End If

         If Me.chbProvincia.Checked Then
            IdProvincia = Me.cmbProvincia.SelectedValue.ToString()
         End If

         Me.ugDetalle.DataSource = oCtaCteDet.GetDetalle({actual.Sucursal},
                                                         FechaHasta, FechaHasta, IdVendedor,
                                                         IdCliente, Nothing, "SOLOSALDO", "TODOS", idZonaGeografica,
                                                         IdCategoria, Me.cmbGrabanLibro.Text, cmbGrupos.GetGruposTiposComprobantes(False), ExcluirSaldosNegativos,
                                                         ExcluirAnticipos,
                                                         ExcluirPreComprobantes,
                                                         IdProvincia,
                                                         Entidades.OrigenFK.Actual, Entidades.OrigenFK.Actual, Entidades.Cliente.ClienteVinculado.Cliente, String.Empty, False,
                                                         0, Entidades.OrigenFK.Actual, Date.Now,
                                                         Entidades.Moneda.Peso, Entidades.Moneda_TipoConversion.Comprobante, cotizDolar:=1,
                                                         grupoCategoria:="",
                                                         idFormaDePago:=0,
                                                         IdEmbarcacion,
                                                         idLocalidad:=0,
                                                         muestraDetalle:=False,
                                                         IdCama)

         Me.txtArchivoDestino.Text = My.Computer.FileSystem.SpecialDirectories.Desktop & "\" & Publicos.CuitEmpresa & "_CtaCteClientes_" & Date.Today().ToString("yyyyMMdd") & ".csv"

         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub
   'NUEVO
   Private Sub ExportarDatos()

      Try
         Dim stb As System.Text.StringBuilder = New System.Text.StringBuilder()
         Dim cant As Integer = 0

         Me.ugDetalle.UpdateData()

         For Each dr As UltraGridRow In Me.ugDetalle.Rows
            If Boolean.Parse(dr.Cells("Check").Value.ToString()) Then
               cant += 1
            End If
         Next

         If cant = 0 Then
            MessageBox.Show("No selecciono ningún Comprobante", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
         End If

         stb.AppendFormat("Realmente desea generar el archivo para los {0} comprobantes?", cant)

         If MessageBox.Show(stb.ToString(), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.CrearCtaCteClientesWeb()
            Me._CtaCteClientesWeb.GrabarArchivo(Me.txtArchivoDestino.Text)
            MessageBox.Show("Se Exportaron " & cant.ToString() & " saldos EXITOSAMENTE !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         Else
            MessageBox.Show("Ha cancelado la exportación.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
      Catch ex As Exception
         Throw
      End Try

   End Sub
   'NUEVO

   Private Sub CrearCtaCteClientesWeb()
      Try
         Me._CtaCteClientesWeb = New CtaCteClientesWeb()

         Dim linea As CtaCteClientesWebLinea

         Me.tspBarra.Visible = True
         Me.tspBarra.Minimum = 0
         Me.tspBarra.Maximum = ugDetalle.Rows.Count
         Me.tspBarra.Value = 0

         For Each dr As UltraGridRow In ugDetalle.Rows
            Me.tspBarra.Value += 1
            If Boolean.Parse(dr.Cells("Check").Value.ToString()) Then

               linea = New CtaCteClientesWebLinea()

               'CodigoCliente;IdSucursal;IdTipoComprobante;Letra;CentroEmisor;NumeroComprobante;Cuota;FechaEmision;FechaVencimiento;ImporteCuota;SaldoCuota;Observacion


               '01 - CodigoCliente
               linea.CodigoCliente = Long.Parse(dr.Cells("CodigoCliente").Value.ToString())
               '02 - IdSucursal
               linea.IdSucursal = Integer.Parse(dr.Cells("IdSucursal").Value.ToString())
               '03 - IdTipoComprobante
               linea.TipoComprobante.IdTipoComprobante = dr.Cells("IdTipoComprobante").Value.ToString()
               '04 - Letra
               linea.Letra = dr.Cells("Letra").Value.ToString()
               '05 - CentroEmisor
               linea.CentroEmisor = Integer.Parse(dr.Cells("CentroEmisor").Value.ToString())
               '06 - NumeroComprobante
               linea.NumeroComprobante = Long.Parse(dr.Cells("NumeroComprobante").Value.ToString())
               '07 - Cuota 
               linea.Cuota = Integer.Parse(dr.Cells("CuotaNumero").Value.ToString())
               '08 - FechaEmision
               linea.FechaEmision = Date.Parse(dr.Cells("Fecha").Value.ToString())
               '09 - FechaVencimiento
               linea.FechaVencimiento = Date.Parse(dr.Cells("FechaVencimiento").Value.ToString())
               '10 - ImporteCuota
               linea.ImporteCuota = Decimal.Parse(dr.Cells("ImporteCuota").Value.ToString())
               '11 - SaldoCuota
               linea.SaldoCuota = Decimal.Parse(dr.Cells("SaldoCuota").Value.ToString())
               '12 - Observacion
               linea.Observacion = dr.Cells("Observacion").Value.ToString()

               Me._CtaCteClientesWeb.Lineas.Add(linea)

            End If

         Next

      Catch ex As Exception
         Throw
      Finally
         Me.tspBarra.Value = 0
         Me.tspBarra.Visible = False
      End Try


   End Sub

#End Region

End Class