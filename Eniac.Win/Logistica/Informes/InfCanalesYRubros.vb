Public Class InfCanalesYRubros

   Private _filtroProductos As MFProductos
   Private _publicos As Publicos

   Protected Overrides Sub OnLoad(e As System.EventArgs)
      MyBase.OnLoad(e)
      Try
         Me._filtroProductos = New MFProductos()
         Me._publicos = New Publicos()
         'Me.dgvDetalle.DataSource = Nothing
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub RefrescarDatosGrilla()

      Me.chkMesCompleto.Checked = False
      Me.dtpDesde.Value = DateTime.Today
      Me.dtpHasta.Value = DateTime.Today.AddHours(23).AddMinutes(59).AddSeconds(59)

      If Not Me.dgvDetalle.DataSource Is Nothing Then
         DirectCast(Me.dgvDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.dtpDesde.Focus()

   End Sub

   Private Sub tsbSalir_Click(sender As System.Object, e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub


   Private Sub btnConsultar_Click(sender As System.Object, e As System.EventArgs) Handles btnConsultar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         'If Me.dgvDetalle.DataSource IsNot Nothing Then
         '   DirectCast(Me.dgvDetalle.DataSource, DataTable).Rows.Clear()
         '   Me.dgvDetalle.DisplayLayout.Bands(0).Summaries.Clear()
         'End If

         Me.CargarDatos()
      Catch ex As Exception
         Me.Cursor = Cursors.Default
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub CargarDatos()

      Dim oVentas As Reglas.Ventas = New Reglas.Ventas()
      Dim dt As DataTable = oVentas.GetCanalesYRubros(Me.dtpDesde.Value, Me.dtpHasta.Value, Me._filtroProductos.Filtros)

      Me.dgvDetalle.DataSource = dt

   End Sub

   Private Sub InfVentasDetallePorProductos_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(sender As System.Object, e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbImprimir_Click(sender As System.Object, e As System.EventArgs) Handles tsbImprimir.Click
      Try

         If Me.dgvDetalle.Rows.Count = 0 Then Exit Sub

         Dim Filtros As String = String.Empty

         Filtros = "Filtros: Rango de Fechas: desde el " & Me.dtpDesde.Text & " hasta el " & Me.dtpHasta.Text

         Dim Titulo As String

         Titulo = Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Filtros

         Me.UltraPrintPreviewDialog1.Document = Me.UltraGridPrintDocument1
         Me.UltraGridPrintDocument1.Header.TextCenter = Titulo
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.SizeInPoints = 12
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 40
         Me.UltraGridPrintDocument1.DefaultPageSettings.Landscape = True
         Me.UltraGridPrintDocument1.Footer.TextLeft = "Sucursal: " + Eniac.Entidades.Usuario.Actual.Sucursal.Nombre
         Me.UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + DateTime.Today.ToString("dd/MM/yyyy")

         Me.UltraPrintPreviewDialog1.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub tsmiAExcel_Click(sender As System.Object, e As System.EventArgs) Handles tsmiAExcel.Click
      Try
         Dim nombreWS As String = "InfCanalesYRubros"
         Me.sfdExportar.FileName = Me.Name & ".xls"
         Me.sfdExportar.Filter = "Archivos excel|*.xls"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Dim wb As Infragistics.Documents.Excel.Workbook = New Infragistics.Documents.Excel.Workbook(Infragistics.Documents.Excel.WorkbookFormat.Excel97To2003)
               wb.Worksheets.Add(nombreWS)
               wb.Worksheets(nombreWS).Rows(0).Cells(0).Value = Me.Text +
                                                                           " desde el " +
                                                                           Me.dtpDesde.Text +
                                                                           " hasta el " + Me.dtpHasta.Text
               Me.UltraGridExcelExporter1.Export(Me.dgvDetalle, wb.Worksheets(nombreWS), 4, 0)
               wb.Save(Me.sfdExportar.FileName)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(sender As System.Object, e As System.EventArgs) Handles tsmiAPDF.Click
      Try
         Me.sfdExportar.FileName = Me.Name & ".pdf"
         Me.sfdExportar.Filter = "Archivos pdf|*.pdf"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Me.UltraGridDocumentExporter1.Export(Me.dgvDetalle, Me.sfdExportar.FileName, Infragistics.Win.UltraWinGrid.DocumentExport.GridExportFileFormat.PDF)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub


   Private Sub chkMesCompleto_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkMesCompleto.CheckedChanged
      Try

         If chkMesCompleto.Checked Then
            Me.dtpDesde.Value = New Date(Me.dtpDesde.Value.Year, Me.dtpDesde.Value.Month, 1)

            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 dia.
            Me.dtpHasta.Value = Me.dtpDesde.Value.AddMonths(1).AddSeconds(-1)
         End If

         Me.dtpDesde.Enabled = Not Me.chkMesCompleto.Checked
         Me.dtpHasta.Enabled = Not Me.chkMesCompleto.Checked

      Catch ex As Exception
         Me.chkMesCompleto.Checked = False
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbVista_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chbVista.CheckedChanged
      Try
         Me.dgvDetalle.DisplayLayout.Bands(0).CardView = Me.chbVista.Checked
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub lnkFiltroPorProductos_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkFiltroPorProductos.LinkClicked
      Try
         Me._filtroProductos.ShowDialog()
         If Me._filtroProductos.Filtros.Count = 0 Then
            Me.lnkFiltroPorProductos.Text = "Todos los productos"
         Else
            Me.lnkFiltroPorProductos.Text = "Algunos productos"
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

End Class