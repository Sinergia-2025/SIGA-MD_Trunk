#Region "Option/Imports"
Option Explicit On
Option Strict On
Imports actual = Eniac.Entidades.Usuario.Actual
Imports Eniac.Entidades
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Documents.Excel
Imports Infragistics.Documents.Reports.Report
Imports Infragistics.Documents.Reports.Report.Section
Imports Eniac.Win.UltraGridExportarExcel

#End Region
Public Class ResumenDetallePorComprobanteCompras


#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Me.cmbGrabanLibro.Items.Insert(0, "TODOS")
      Me.cmbGrabanLibro.Items.Insert(1, "SI")
      Me.cmbGrabanLibro.Items.Insert(2, "NO")
      Me.cmbGrabanLibro.SelectedIndex = 0

      Me.cmbAfectaCaja.Items.Insert(0, "TODOS")
      Me.cmbAfectaCaja.Items.Insert(1, "SI")
      Me.cmbAfectaCaja.Items.Insert(2, "NO")
      Me.cmbAfectaCaja.SelectedIndex = 0

      Me.cmbEsComercial.Items.Insert(0, "TODOS")
      Me.cmbEsComercial.Items.Insert(1, "SI")
      Me.cmbEsComercial.Items.Insert(2, "NO")
      Me.cmbEsComercial.SelectedIndex = 0

      Me.cmbInformaLibroIva.Items.Insert(0, "TODOS")
      Me.cmbInformaLibroIva.Items.Insert(1, "SI")
      Me.cmbInformaLibroIva.Items.Insert(2, "NO")
      Me.cmbInformaLibroIva.SelectedIndex = 1 ' Por default, va en SI.

      Me.dtpDesde.Value = Today.PrimerDiaMes()
      Me.dtpHasta.Value = Today.UltimoDiaMes()

      cmbTiposComprobantes.Initializar(False, "COMPRAS")
      Me.cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()

      Me.cmbRubroCompra.Inicializar(True, True, True)
      Me.cmbCategoriasFiscales.Inicializar(True, True, True)
      Me.cmbCategoriasFiscales.SelectedValue = Short.Parse(Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos).ToString())

      PreferenciasLeer(ugPorComprobante, tsbPreferencias)

   End Sub

#End Region

#Region "Eventos"

   Private Sub ResumenPorComprobanteCompras_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
      Try

         If ugPorComprobante.Rows.Count = 0 Then Exit Sub

         UltraGridPrintDocument1.Grid = ugPorComprobante

         Dim Filtros As String = Me.CargarFiltrosImpresion()
         Dim Titulo As String
         Titulo = String.Format("{1}{0}{0}{2} -{0}{0}{0}{3}", Environment.NewLine(), Publicos.NombreEmpresaImpresion, Text, Filtros)
         'Titulo = Publicos.NombreEmpresa + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Filtros

         Dim UltraPrintPreviewD As Infragistics.Win.Printing.UltraPrintPreviewDialog
         UltraPrintPreviewD = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
         UltraPrintPreviewD.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
         UltraPrintPreviewD.Name = "UltraPrintPreviewDialog1"

         UltraPrintPreviewD.Document = Me.UltraGridPrintDocument1
         UltraPrintPreviewD.Name = Me.Text

         Me.UltraPrintPreviewDialog1.Name = Me.Text
         Me.UltraGridPrintDocument1.Header.TextCenter = Titulo
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.Bold = DefaultableBoolean.True
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.SizeInPoints = 12
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 40
         Me.UltraGridPrintDocument1.DefaultPageSettings.Landscape = True
         Me.UltraGridPrintDocument1.Footer.TextLeft = "Sucursal: " + actual.Sucursal.Nombre
         Me.UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + DateTime.Today.ToString("dd/MM/yyyy")

         UltraPrintPreviewD.MdiParent = Me.MdiParent
         UltraPrintPreviewD.Show()
         UltraPrintPreviewD.Focus()

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub tsmiAExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         If ugPorComprobante.Rows.Count = 0 Then Exit Sub

         Dim excelExport As UltraGridExportarExcel = New UltraGridExportarExcel(UltraGridExcelExporter1, Publicos.NombreEmpresaImpresion)
         excelExport.Exportar(String.Format("{0}.xls", Me.Name), GetGrillasExportar(), CargarFiltrosImpresion())

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         If ugPorComprobante.Rows.Count = 0 Then Exit Sub

         Dim excelExport As UltraGridExportarPDF = New UltraGridExportarPDF(UltraGridDocumentExporter1, Publicos.NombreEmpresaImpresion)
         excelExport.Exportar(String.Format("{0}.pdf", Me.Name), GetGrillasExportar(), CargarFiltrosImpresion())

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Function GetGrillasExportar() As UltraGridExportTituloGrilla()
      Return {New UltraGridExportTituloGrilla() With {.Grilla = ugPorComprobante, .Titulo = String.Format("{0} - {1}", Me.Text, Text), .NombreHoja = Text}}
   End Function

   Private Sub UltraGridPrintDocument1_PagePrinting(ByVal sender As System.Object, ByVal e As Infragistics.Win.Printing.PagePrintingEventArgs)
      Me.UltraGridPrintDocument1.Footer.TextRight = "Página: " + Me.UltraGridPrintDocument1.PageNumber.ToString()
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try
         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If ugPorComprobante.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("NO hay registros que cumplan con la selección !", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.chkUltimoAno.Focus()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub FormatearGrilla(ug As UltraGrid)
      Dim col As Integer = 0
      ug.AgregarTotalesSuma({"NetoNoGravado", "Neto", "Total", "DerechoAduanero"})
      Dim dt As DataTable
      If TypeOf (ug.DataSource) Is DataTable Then
         dt = DirectCast(ug.DataSource, DataTable)
      End If

      ug.DisplayLayout.Bands(0).Columns("Neto").Width = 90
      ug.DisplayLayout.Bands(0).Columns("NetoNoGravado").Width = 90
      ug.DisplayLayout.Bands(0).Columns("Total").Width = 90
      ug.DisplayLayout.Bands(0).Columns("DerechoAduanero").Width = 110

      For Each dc As UltraGridColumn In ug.DisplayLayout.Bands(0).Columns
         If dc.Key.StartsWith("____") Then
            Dim caption As String
            Dim partes As String() = dc.Key.Replace("____", "").Split("_"c)
            If partes.Length > 1 Then
               caption = partes(1)
            End If
            If partes.Length > 2 Then
               caption += " " + partes(2).Replace("#", ".") + " %"
            End If
            dc.FormatearColumna(caption, col, If(dc.Key.Contains("NetoGravado"), 135, 90), HAlign.Right, , "N2")
            ug.AgregarTotalSumaColumna(dc)
            If dt IsNot Nothing AndAlso dt.Select(String.Format("[{0}] <> 0", dc.Key)).Length = 0 Then
               dc.Hidden = True
            End If
         Else
            col += Math.Max(col, dc.Header.VisiblePosition)
            If dc.Key = "Total" Then dc.Header.VisiblePosition = 9998
            If dc.Key = "DerechoAduanero" Then dc.Header.VisiblePosition = 9999
         End If
      Next

      'ug.DisplayLayout.Bands(0).PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand)
   End Sub

   Private Sub CargaGrillaDetalle()

      Dim Suc As List(Of Integer) = New List(Of Integer)
      Suc.Add(actual.Sucursal.Id)

      Dim periodoFiscalDesde As Integer = Integer.Parse(Me.dtpDesde.Value.ToString("yyyyMM"))
      Dim periodoFiscalhasta As Integer = Integer.Parse(Me.dtpHasta.Value.ToString("yyyyMM"))

      Dim separarNetos As Boolean = Me.chbSepararNetos.Checked
      Dim tiposDeComprobantes As Entidades.TipoComprobante() = Me.cmbTiposComprobantes.GetTiposComprobantes()
      Dim rubrosCompra As Entidades.RubroCompra() = Me.cmbRubroCompra.GetRubrosCompras()
      Dim categoriaFiscales As Entidades.CategoriaFiscal() = Me.cmbCategoriasFiscales.GetCategoriasFIscales()

      Dim dtDetalle = New Reglas.Compras().GetResumenDeComprasDetalle({actual.Sucursal}, actual.Sucursal.IdEmpresa, periodoFiscalDesde,
                                                           periodoFiscalhasta, Me.cmbGrabanLibro.Text, Me.cmbAfectaCaja.Text,
                                                           Me.cmbEsComercial.Text, Me.cmbInformaLibroIva.Text, False,
                                                           separarNetos, tiposDeComprobantes, rubrosCompra, categoriaFiscales)

      ugPorComprobante.DataSource = dtDetalle

      FormatearGrilla(ugPorComprobante)

      ugPorComprobante.AgregarFiltroEnLinea({"DescripcionComprobante", "NombreRubro", "NombreCategoriaFiscal"})

   End Sub

   Private Sub RefrescarDatosGrilla()

      Me.cmbGrabanLibro.SelectedIndex = 0
      Me.cmbAfectaCaja.SelectedIndex = 0
      Me.cmbEsComercial.SelectedIndex = 0
      Me.cmbInformaLibroIva.SelectedIndex = 1

      If TypeOf (Me.ugPorComprobante.DataSource) Is DataTable Then
         DirectCast(Me.ugPorComprobante.DataSource, DataTable).Rows.Clear()
      End If

      Me.chkUltimoAno.Checked = False
      dtpDesde.Value = dtpDesde.Value.PrimerDiaMes()
      dtpHasta.Value = dtpHasta.Value.PrimerDiaMes()

      cmbTiposComprobantes.Refrescar()
      cmbRubroCompra.Refrescar()
      cmbCategoriasFiscales.Refrescar()

      Me.chbSepararNetos.Checked = False
   End Sub

   Private Function CargarFiltrosImpresion() As String
      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      Dim Primero As Boolean = True
      With filtro
         .AppendFormat("Priodo Fiscal Desde: {0}  Hasta: {1} - ", Me.dtpDesde.Text, Me.dtpHasta.Text)
         .AppendFormat(" Graba Libro: {0} - ", Me.cmbGrabanLibro.Text)
         .AppendFormat(" Afecta Caja: {0} - ", Me.cmbAfectaCaja.Text)
         .AppendFormat(" Es Comercial: {0} - ", Me.cmbEsComercial.Text)
         .AppendFormat(" Informa Libro IVA: {0} - ", Me.cmbInformaLibroIva.Text)
         If Me.chbSepararNetos.Checked Then .AppendFormat(" Separar Netos: SI - ")

      End With

      Return filtro.ToString.Trim().Trim("-"c)
   End Function

#End Region

   Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
      Try

         If ugPorComprobante.Rows.Count = 0 Then Exit Sub

         Dim ugdetalle As UltraGrid
         ugdetalle = ugPorComprobante

         Dim myWorkbook As New Workbook()
         Dim myWorksheet As Worksheet
         myWorksheet = myWorkbook.Worksheets.Add("Hoja1")
         myWorksheet.Rows(0).Cells(0).Value = Publicos.NombreEmpresaImpresion
         myWorksheet.Rows(1).Cells(0).Value = String.Format("{0}", Me.Text)
         myWorksheet.Rows(2).Cells(0).Value = Me.CargarFiltrosImpresion()

         Me.sfdExportar.FileName = String.Format("{0}.xls", Me.Name)
         Me.sfdExportar.Filter = "Archivos excel|*.xls"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Me.UltraGridExcelExporter1.Export(ugdetalle, myWorksheet, 4, 0)
               myWorkbook.Save(Me.sfdExportar.FileName)
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
      Try

         If ugPorComprobante.Rows.Count = 0 Then Exit Sub

         Dim ugdetalle As UltraGrid
         ugdetalle = ugPorComprobante

         Me.sfdExportar.FileName = String.Format("{0}.pdf", Me.Name)
         Me.sfdExportar.Filter = "Archivos pdf|*.pdf"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Dim r As New Report()
               Dim sec As ISection = r.AddSection()
               sec.AddText.AddContent(Publicos.NombreEmpresaImpresion + System.Environment.NewLine)
               sec.AddText.AddContent(String.Format("{0}", Me.Text, Text) + System.Environment.NewLine)
               sec.AddText.AddContent(Me.CargarFiltrosImpresion() + System.Environment.NewLine + System.Environment.NewLine)
               Me.UltraGridDocumentExporter1.Export(ugdetalle, sec)
               r.Publish(Me.sfdExportar.FileName, FileFormat.PDF)
            End If
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub
   Private Sub chkPeridoCompleto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUltimoAno.CheckedChanged
      Try
         If chkUltimoAno.Checked Then

            dtpDesde.Value = dtpHasta.Value.AddYears(-1).AddMonths(1)
            dtpDesde.Enabled = Not chkUltimoAno.Checked
            dtpHasta.Enabled = Not chkUltimoAno.Checked
         Else
            dtpDesde.Enabled = Not chkUltimoAno.Checked
            dtpHasta.Enabled = Not chkUltimoAno.Checked
         End If

      Catch ex As Exception
         chkUltimoAno.Checked = False
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub dtpDesde_ValueChanged(sender As Object, e As EventArgs) Handles dtpDesde.ValueChanged
      If Not Me.chkUltimoAno.Checked Then
         Me.dtpHasta.Value = Me.dtpDesde.Value
      End If
      Me.dtpDesde.Value = Me.dtpDesde.Value.PrimerDiaMes
   End Sub

   Private Sub dtpHasta_ValueChanged(sender As Object, e As EventArgs) Handles dtpHasta.ValueChanged
      dtpHasta.Value = dtpHasta.Value.PrimerDiaMes()
   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugPorComprobante, tsbPreferencias))
   End Sub


End Class