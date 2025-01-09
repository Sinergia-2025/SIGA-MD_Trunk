#Region "Option/Imports"
Option Explicit On
Option Strict On
Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Documents.Excel
Imports Infragistics.Documents.Reports.Report
Imports Infragistics.Documents.Reports.Report.Section
Imports Infragistics.Win
#End Region
Public Class LibrodeIvaComprasV2

#Region "Campos"
   Private dtLibroDetalle As DataTable = New DataTable()
   Private _publicos As Publicos
   Private NumeroDeHoja As Integer = 0
   Private Filtros As String
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Me._publicos = New Publicos()

      Me.dtpPeriodoFiscal.Value = Today.PrimerDiaMes()

      Me._publicos.CargaComboEmpleados(Me.cmbCompradores, Entidades.Publicos.TiposEmpleados.COMPRADOR)

      Ayudante.Grilla.AgregarFiltroEnLinea(ugDetalle, {"IdTipoComprobante", " ", "NombreProveedor", "NombreCategoriaFiscal", "CUIT"})
      PreferenciasLeer(ugDetalle, tsbPreferencias)
   End Sub

#End Region

#Region "Eventos"

   Private Sub chkVersionFinal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVersionFinal.CheckedChanged

      Try

         If chkVersionFinal.Checked Then
            Me.txtNumeroInicialHoja.Text = Reglas.Publicos.NroHojaLibroIvaCompras.ToString()
            Me.chkConVendedor.Checked = False
         Else
            Me.txtNumeroInicialHoja.Clear()
         End If

         Me.txtNumeroInicialHoja.Enabled = Me.chkVersionFinal.Checked
         Me.txtNumeroInicialHoja.IsRequired = Me.chkVersionFinal.Checked

         'Me.dtpPeriodoFiscal.Enabled = Not chkVersionFinal.Checked
         Me.chkConVendedor.Enabled = Not chkVersionFinal.Checked

      Catch ex As Exception

         Me.Cursor = Cursors.Default
         chkVersionFinal.Checked = False
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub

   Private Sub InfResumenDeVentas_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
      If e.KeyCode = Keys.F5 Then
         tsbRefrescar.PerformClick()
      End If
   End Sub

#Region "Eventos ToolBar"
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

         Me.UltraGridPrintDocument1.Header.TextCenter = Titulo
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.Bold = DefaultableBoolean.True
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.SizeInPoints = 12
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 10
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 10
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 10
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Landscape = True
         Me.UltraGridPrintDocument1.Footer.TextLeft = "Sucursal: " + actual.Sucursal.Nombre
         Me.UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + DateTime.Today.ToString("dd/MM/yyyy")
         Me.UltraGridPrintDocument1.Grid = ugDetalle

         UltraPrintPreviewD.MdiParent = Me.MdiParent
         UltraPrintPreviewD.Show()
         UltraPrintPreviewD.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try


   End Sub
   Private Sub tsbImprimir2_Click(sender As Object, e As EventArgs) Handles tsbImprimir2.Click
      Try

         If ugDetalle.Rows.Count > 0 Then

            If chkVersionFinal.Checked Then
               If Not String.IsNullOrEmpty(txtNumeroInicialHoja.Text.ToString()) Then
                  NumeroDeHoja = Integer.Parse(txtNumeroInicialHoja.Text)
               End If
            End If

            If NumeroDeHoja <= 0 Then
               Me.Cursor = Cursors.Default
               MessageBox.Show("Numero de Hoja Inicial es INVALIDO !!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Exit Sub
            End If

            Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresaImpresion))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Eniac.Entidades.Usuario.Actual.Sucursal.Nombre))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", CargarFiltrosImpresion()))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("PaginaInicial", NumeroDeHoja.ToString()))


            Dim frmImprime As VisorReportes
            Dim strReporte As String = String.Empty


            If Me.optPorFecha.Checked Then
               If Me.chbFormatoHorizontal.Checked Then
                  Dim dt As New DataTable
                  dt = dtLibroDetalle.Copy
                  dt.Columns.Add("Iva1050", GetType(Decimal), "____IVA_IVA_10¿50")
                  dt.Columns.Add("Iva2100", GetType(Decimal), "____IVA_IVA_21¿00")
                  dt.Columns.Add("Iva2700", GetType(Decimal), "____IVA_IVA_27¿00")


                  strReporte = "LibrodeIvaComprasHorizontal.rdlc"
                  frmImprime = New VisorReportes("Eniac.Win." & strReporte, "SistemaDataSet_Compras", dt, parm, True, 1) '# 1 = Cantidad Copias
               Else
                  strReporte = "LibrodeIvaCompras.rdlc"
                  frmImprime = New VisorReportes("Eniac.Win." & strReporte, "SistemaDataSet_Compras", dtLibroDetalle, parm, True, 1) '# 1 = Cantidad Copias
               End If
            Else
               strReporte = "LibrodeIvaCompras_PorProvincias.rdlc"
               frmImprime = New VisorReportes("Eniac.Win." & strReporte, "SistemaDataSet_Compras", dtLibroDetalle, parm, True, 1) '# 1 = Cantidad Copias
            End If

            frmImprime.Text = Me.Text
            frmImprime.WindowState = FormWindowState.Maximized
            frmImprime.DisplayModeInicial = Microsoft.Reporting.WinForms.DisplayMode.PrintLayout
            frmImprime.ShowDialog()

            If chkVersionFinal.Checked Then
               Me.Cursor = Cursors.Default
               If MessageBox.Show("El Libro Mensual de I.V.A. fue impreso correctamente ?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                  Reglas.Publicos.NroHojaLibroIvaCompras = NumeroDeHoja + frmImprime.GetTotalPages
                  Me.RefrescarDatosGrilla()
               End If
            End If

         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub tsmiAExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAExcel.Click
      Try

         If ugDetalle.Rows.Count = 0 Then Exit Sub


         Dim myWorkbook As New Workbook
         Dim myWorksheet As Worksheet
         myWorksheet = myWorkbook.Worksheets.Add("Hoja1")
         myWorksheet.Rows(0).Cells(0).Value = Publicos.NombreEmpresaImpresion
         myWorksheet.Rows(1).Cells(0).Value = Me.Text
         myWorksheet.Rows(2).Cells(0).Value = CargarFiltrosImpresion()
         Me.sfdExportar.FileName = Me.Name & ".xls"
         Me.sfdExportar.Filter = "Archivos excel|*.xls"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Me.UltraGridExcelExporter1.Export(ugDetalle, myWorksheet, 4, 0)
               myWorkbook.Save(Me.sfdExportar.FileName)
            End If
         End If
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
               sec.AddText.AddContent(CargarFiltrosImpresion() + System.Environment.NewLine + System.Environment.NewLine)
               Me.UltraGridDocumentExporter1.Export(Me.ugDetalle, sec)
               r.Publish(Me.sfdExportar.FileName, FileFormat.PDF)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub
#End Region

   Private Sub UltraGridPrintDocument1_PagePrinting(ByVal sender As System.Object, ByVal e As Infragistics.Win.Printing.PagePrintingEventArgs)
      Me.UltraGridPrintDocument1.Footer.TextRight = "Página: " + Me.UltraGridPrintDocument1.PageNumber.ToString()
   End Sub


   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try
         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         Me.tssRegistros.Text = ugDetalle.Rows.Count & " Registros"

         If dtLibroDetalle.Rows.Count > 0 Then
            btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugDetalle, tsbPreferencias))
   End Sub

   Private Sub chkConVendedor_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkConVendedor.CheckedChanged
      Me.cmbCompradores.Enabled = Me.chkConVendedor.Checked
   End Sub

   Private Sub chbFormatoHorizontal_CheckedChanged(sender As Object, e As EventArgs) Handles chbFormatoHorizontal.CheckedChanged
      If Me.chbFormatoHorizontal.Checked Then
         Me.chbAgrupar.Enabled = True
      Else
         Me.chbAgrupar.Enabled = False
         Me.chbAgrupar.Checked = False
      End If
   End Sub

#End Region

#Region "Metodos"



   Private Sub CargaGrillaDetalle()
      Dim idEmpresa As Integer = actual.Sucursal.IdEmpresa
      Dim PeriodoFiscal As Integer = Integer.Parse(Me.dtpPeriodoFiscal.Value.ToString("yyyyMM"))

      Dim IdComprador As Integer = 0

      Dim nombreComprador As String = String.Empty
      Dim oCompras As Reglas.Compras = New Reglas.Compras()

      NumeroDeHoja = 1

      If Me.chkConVendedor.Checked And Me.cmbCompradores.SelectedIndex <> -1 Then
         IdComprador = DirectCast(Me.cmbCompradores.SelectedItem, Entidades.Empleado).IdEmpleado
         nombreComprador = Me.cmbCompradores.Text
      End If


      Dim Orden As String
      If optPorFecha.Checked Then
         Orden = "FECHA"
      Else
         Orden = "PROVINCIA"
      End If

      If Me.chbFormatoHorizontal.Checked Then
         dtLibroDetalle = oCompras.GetLibroDeIVADinamico(idEmpresa, PeriodoFiscal, Orden, IdComprador, Me.chbAgrupar.Checked)

      Else
         dtLibroDetalle = oCompras.GetLibroDeIVA(idEmpresa, PeriodoFiscal, Orden, IdComprador)
      End If


      If dtLibroDetalle.Rows.Count = 0 Then
         MessageBox.Show("NO hay registros que cumplan con la seleccion")
         Me.dtpPeriodoFiscal.Focus()
         Exit Sub
      End If

      ugDetalle.DisplayLayout.Bands(0).Summaries.Clear()
      If Me.chbFormatoHorizontal.Checked Then
         Me.ugDetalle.DataSource = dtLibroDetalle
         ugDetalle.AgregarTotalesSuma({"BaseImponibleNoGrabado", "BaseImponible", "ImporteTotal"})
         FormatearGrillaHorizontal()
      Else
         Me.ugDetalle.DataSource = dtLibroDetalle
         ugDetalle.AgregarTotalesSuma({"BaseImponibleNoGrabado", "BaseImponible", "Importe", "ImportePercepcion", "ImporteTotal"})
         FormatearGrillaVertical()
      End If

      PreferenciasLeer(ugDetalle, tsbPreferencias)

      If Not chbAgrupar.Checked Then
         ugDetalle.DisplayLayout.Bands(0).Columns("Alicuota").Hidden = True
         ugDetalle.DisplayLayout.Bands(0).Columns("Importe").Hidden = True
      End If

   End Sub
   Public Sub FormatearGrillaHorizontal()


      Dim dt As DataTable
      If TypeOf (ugDetalle.DataSource) Is DataTable Then
         dt = DirectCast(ugDetalle.DataSource, DataTable)
      End If


      ugDetalle.DisplayLayout.UseFixedHeaders = True
      ugDetalle.DisplayLayout.Override.FixedHeaderIndicator = FixedHeaderIndicator.None

      '     FormatearColumna(Me.ugDetalle.DisplayLayout.Bands(0).Columns("ImportePercepcion"), "Percepcion", 0, 75, HAlign.Right, True)
      Dim col As Integer = 0


      For Each dc As UltraGridColumn In ugDetalle.DisplayLayout.Bands(0).Columns
         If dc.Key.StartsWith("____") Then
            Dim caption As String
            Dim partes As String() = dc.Key.Replace("____", "").Split("_"c)
            If partes.Length > 1 Then
               caption = partes(1)
            End If
            If partes.Length > 2 Then
               caption += " " + partes(2).Replace("¿", ".") + "%"
            End If
            dc.FormatearColumna(caption, col, 90, HAlign.Right, , "N2")
            ugDetalle.AgregarTotalSumaColumna(dc)
            If dt IsNot Nothing AndAlso dt.Select(String.Format("[{0}] <> 0", dc.Key)).Length = 0 Then
               dc.Hidden = True
            End If

         Else
            col += Math.Max(col, dc.Header.VisiblePosition)
            If dc.Key = "ImporteTotal" Then dc.Header.VisiblePosition = 9999
         End If
      Next


   End Sub

   Public Sub FormatearGrillaVertical()
      ugDetalle.DisplayLayout.UseFixedHeaders = True
      ugDetalle.DisplayLayout.Override.FixedHeaderIndicator = FixedHeaderIndicator.None
      Dim pos As Integer = 0
      With Me.ugDetalle.DisplayLayout.Bands(0)

         For Each columna As UltraGridColumn In .Columns
            columna.Hidden = True
            columna.CellActivation = Activation.NoEdit
         Next

         FormatearColumna(.Columns("Fecha"), "Fecha", pos, 80, HAlign.Left, False)
         FormatearColumna(.Columns("NombreTipoComprobante"), "Tipo", pos, 70)
         FormatearColumna(.Columns("Letra"), " ", pos, 20)
         FormatearColumna(.Columns("CentroEmisor"), "Emisor", pos, 50, HAlign.Right, True)
         FormatearColumna(.Columns("NumeroComprobante"), "Numero", pos, 70, HAlign.Right, True)
         FormatearColumna(.Columns("ComprobanteFormat"), "Comprobante", pos, 110, HAlign.Right)
         FormatearColumna(.Columns("NombreProveedor"), "Proveedor", pos, 130)
         FormatearColumna(.Columns("NombreRubro"), "Rubro", pos, 130)
         FormatearColumna(.Columns("NombreCategoriaFiscal"), "Categoria", pos, 70)
         FormatearColumna(.Columns("CUIT"), "C.U.I.T.", pos, 85)
         FormatearColumna(.Columns("IdTipoImpuesto"), "Impuesto", pos, 55, HAlign.Left)
         FormatearColumna(.Columns("BaseImponibleNoGrabado"), "Neto No Gravado", pos, 75, HAlign.Right, False, "N2")
         FormatearColumna(.Columns("BaseImponible"), "Neto Gravado", pos, 75, HAlign.Right, False, "N2")
         FormatearColumna(.Columns("Alicuota"), "Alicuota", pos, 75, HAlign.Right, False, "N2")
         FormatearColumna(.Columns("Importe"), "Importe", pos, 75, HAlign.Right, False, "N2")
         FormatearColumna(.Columns("ImportePercepcion"), "Percepcion", pos, 75, HAlign.Right, False, "N2")
         FormatearColumna(.Columns("ImporteTotal"), "Total", pos, 75, HAlign.Right, False, "N2")

      End With


   End Sub
   Private Sub RefrescarDatosGrilla()

      If TypeOf (Me.ugDetalle.DataSource) Is DataTable Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If
      chkConVendedor.Checked = False
      Me.chkVersionFinal.Checked = False
      optPorFecha.Checked = True
      chbFormatoHorizontal.Checked = True

   End Sub

   Private Function CargarFiltrosImpresion() As String
      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      Dim Primero As Boolean = True
      With filtro
         .AppendFormat("Filtros: Periodo: " & Me.dtpPeriodoFiscal.Value.GetMesEnEspanol & " " & Me.dtpPeriodoFiscal.Value.ToString("yyyy"))
         If Me.chkConVendedor.Checked And Me.cmbCompradores.SelectedIndex <> -1 Then
            .AppendFormat(" // Comprador: " & DirectCast(Me.cmbCompradores.SelectedItem, Entidades.Empleado).IdEmpleado & " - " & Me.cmbCompradores.Text)
         End If
      End With

      Return filtro.ToString.Trim().Trim("-"c)
   End Function
#End Region
End Class