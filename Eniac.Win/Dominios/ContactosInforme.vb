#Region "Option/Imports"
Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Documents.Excel
Imports Infragistics.Documents.Reports.Report
Imports Infragistics.Documents.Reports.Report.Section
#End Region
Public Class ContactosInforme

#Region "Campos"

   Private _publicos As Publicos
   Private IdUsuario As String = actual.Nombre
   Private _vieneDeOnLoad As Boolean = False


#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         _vieneDeOnLoad = True

         Me.CargaGrillaDetalle()

         _vieneDeOnLoad = False

         'Si el Usuario no tiene Vendedores asociados limpio la variable para que no filtre en el cargar combo.
         If New Reglas.Empleados().GetPorUsuario(IdUsuario).Rows.Count = 0 Then
            IdUsuario = ""
         End If

         Dim permiteMostrarTotalesImpresionExportacion As Boolean = New Reglas.Usuarios().TienePermisos(actual.Nombre, actual.Sucursal.IdSucursal, "InfDeVts-Totales+Toolbar")


         Ayudante.Grilla.AgregarFiltroEnLinea(ugDetalle, {"NombreCliente", "CodigoCliente", "CUIT", "Empresa"}, {"Ver", "VerEstandar", "Imprimir"})

         'Hay que colocarlo del CargarColumnasASumar porque sino da error.
         Me.LeerPreferencias()

         If Not permiteMostrarTotalesImpresionExportacion Then
            ugDetalle.DisplayLayout.Bands(0).Summaries.Clear()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub InfVentasDetallePorProductos_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

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

         Dim Filtros As String = Me.CargarFiltrosImpresion
         Dim Titulo As String

         Titulo = Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Filtros

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
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub tsmiAExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAExcel.Click
      Try

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim myWorkbook As New Workbook
         Dim myWorksheet As Worksheet
         myWorksheet = myWorkbook.Worksheets.Add("Hoja1")
         myWorksheet.Rows(0).Cells(0).Value = Publicos.NombreEmpresaImpresion
         myWorksheet.Rows(1).Cells(0).Value = Me.Text
         myWorksheet.Rows(2).Cells(0).Value = Me.CargarFiltrosImpresion()

         Me.sfdExportar.FileName = Me.Name & ".xls"
         Me.sfdExportar.Filter = "Archivos excel|*.xls"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Me.UltraGridExcelExporter1.Export(ugDetalle, myWorksheet, 4, 0)
               myWorkbook.Save(Me.sfdExportar.FileName)
            End If
         End If

         'Me.sfdExportar.FileName = Me.Name & ".xls"
         'Me.sfdExportar.Filter = "Archivos excel|*.xls"
         'If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
         '   If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
         '      Me.UltraGridExcelExporter1.Export(Me.ugDetalle, Me.sfdExportar.FileName, Infragistics.Documents.Excel.WorkbookFormat.Excel97To2003)
         '   End If
         'End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAPDF.Click
      Try

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Me.sfdExportar.FileName = Me.Name & ".pdf"
         Me.sfdExportar.Filter = "Archivos pdf|*.pdf"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Dim r As New Report()
               Dim sec As ISection = r.AddSection()
               sec.AddText.AddContent(Publicos.NombreEmpresaImpresion + System.Environment.NewLine)
               sec.AddText.AddContent(Me.Text + System.Environment.NewLine)
               sec.AddText.AddContent(Me.CargarFiltrosImpresion() + System.Environment.NewLine + System.Environment.NewLine)
               Me.UltraGridDocumentExporter1.Export(Me.ugDetalle, sec)
               r.Publish(Me.sfdExportar.FileName, FileFormat.PDF)
            End If
         End If

         'Me.sfdExportar.FileName = Me.Name & ".pdf"
         'Me.sfdExportar.Filter = "Archivos pdf|*.pdf"
         'If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
         '   If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
         '      Me.UltraGridDocumentExporter1.Export(Me.ugDetalle, Me.sfdExportar.FileName, DocumentExport.GridExportFileFormat.PDF)
         '   End If
         'End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub UltraGridPrintDocument1_PagePrinting(ByVal sender As System.Object, ByVal e As Infragistics.Win.Printing.PagePrintingEventArgs)
      Me.UltraGridPrintDocument1.Footer.TextRight = "Página: " + Me.UltraGridPrintDocument1.PageNumber.ToString()
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub chkExpandAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      'If Me.chkExpandAll.Checked Then
      '   Me.ugDetalle.Rows.ExpandAll(True)
      'Else
      '   Me.ugDetalle.Rows.CollapseAll(True)
      'End If
   End Sub

   Private Sub ugDetalle_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles ugDetalle.InitializeLayout

      e.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.SummaryRow

      e.Layout.Override.SpecialRowSeparatorAppearance.BackColor = Color.FromArgb(218, 217, 241)

      e.Layout.Override.SpecialRowSeparatorHeight = 6

      e.Layout.Override.BorderStyleSpecialRowSeparator = UIElementBorderStyle.RaisedSoft

      e.Layout.ViewStyle = ViewStyle.SingleBand

      e.Layout.ViewStyleBand = ViewStyleBand.OutlookGroupBy

   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         Dim pre As Preferencias = New Preferencias(Me.ugDetalle, True)
         pre.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbImprimirPrediseñado_Click(sender As Object, e As EventArgs)

      If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

      Try

         Dim Filtros As String = CargarFiltrosImpresion()

         Me.Cursor = Cursors.WaitCursor
         Dim dt As DataTable

         dt = DirectCast(Me.ugDetalle.DataSource, DataTable)

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Eniac.Entidades.Usuario.Actual.Sucursal.Nombre))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", Filtros))

         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.InformeDeVentas.rdlc", "SistemaDataSet_Ventas", dt, parm, True, 1) '# 1 = Cantidad Copias
         frmImprime.Text = Me.Text
         frmImprime.WindowState = FormWindowState.Maximized
         frmImprime.Show()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   'Private Sub ugDetalle_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles ugDetalle.DoubleClickCell
   '   Try
   '      Dim en As Entidades.ClienteDeuda = New Reglas.ClientesDeudas().GetUno(Long.Parse(Me.ugDetalle.ActiveRow.Cells("IdCliente").Value.ToString()), _
   '                                                                         Integer.Parse(Me.ugDetalle.ActiveRow.Cells("nro_prestamo").Value.ToString()))


   '      Me.Cursor = Cursors.Default
   '      Dim da As MutualDetalle = New MutualDetalle(en)
   '      da.StateForm = Eniac.Win.StateForm.Actualizar

   '      da.ShowDialog()

   '      If da.DialogResult = Windows.Forms.DialogResult.OK Then
   '         Me.CargaGrillaDetalle()
   '      End If

   '   Catch ex As Exception
   '      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '   End Try
   'End Sub


#End Region

#Region "Metodos"

   Private Sub RefrescarDatosGrilla()

      Me.CargaGrillaDetalle()

   End Sub

   Private Sub CargaGrillaDetalle()

      Dim oClientes As Reglas.Clientes = New Reglas.Clientes()

      Dim dtDetalle As DataTable

      dtDetalle = oClientes.GetContactosClientes()

      Me.ugDetalle.DataSource = dtDetalle

      Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

   End Sub

   Protected Overridable Sub LeerPreferencias()
      Try
         Dim nameGrid As String = Me.ugDetalle.FindForm().Name & "Grid.xml"

         If System.IO.File.Exists(nameGrid) Then
            Me.ugDetalle.DisplayLayout.LoadFromXml(nameGrid)
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Function CargarFiltrosImpresion() As String

      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      Dim Primero As Boolean = True
      With filtro

         'cmbSucursal.CargarFiltrosImpresionSucursales(filtro, True, False)

         'cmbTiposComprobantes.CargarFiltrosImpresionTiposComprobantes(filtro, True, False)

         'If Me.cboLetra.SelectedIndex >= 0 Then
         '   .AppendFormat(" Letra: {0} - ", Me.cboLetra.SelectedText)
         'End If

         'If Me.cmbEmisor.SelectedIndex >= 0 Then
         '   .AppendFormat(" Emisor: {0} -", Me.cmbEmisor.SelectedText)
         'End If

         'If Me.chbNumero.Checked Then
         '   .AppendFormat(" Número: {0} -", Me.txtNumero.Text)
         'End If

         'If Me.bscCodigoCliente.Text.Length > 0 And Me.bscCliente.Text.Length > 0 Then
         '   .AppendFormat(" Cliente: {0} - {1} - ", Me.bscCodigoCliente.Text, Me.bscCliente.Text)
         'End If


      End With

      Return filtro.ToString.Trim().Trim("-"c)

   End Function

#End Region

End Class