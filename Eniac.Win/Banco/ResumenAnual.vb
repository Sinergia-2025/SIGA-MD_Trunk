Option Explicit On
Option Strict Off

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Eniac.Win
Imports Eniac.Reglas
Imports Eniac.Entidades
Imports System.Windows.Forms
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class ResumenAnual

#Region "Campos"

   Private _publicos As Eniac.Win.Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         Me._publicos.CargaComboMonedas(Me.cmbMonedas)
         Me.cmbMonedas.SelectedValue = 1  'Pesos

         Me.dtpAnio.Value = Date.Now
         Me.FormatearColumnas()
         Me.CargarColumnasASumar()
         Me.RefrescarFiltros()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub ResumenAnual_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   'Private Sub chbMoneda_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
   '   If chbMoneda.Checked Then
   '      chbCuenta.Checked = False
   '      cmbMonedas.Enabled = True
   '      Me.cmbMonedas.SelectedValue = 1  'Pesos
   '   Else
   '      cmbMonedas.Enabled = False
   '      cmbMonedas.SelectedIndex = -1
   '   End If
   'End Sub

   Private Sub chbCuentaBancaria_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCuentaBancaria.CheckedChanged
      If Me.chbCuentaBancaria.Checked Then
         Me.bscCuentaBancaria.Enabled = True
      Else
         Me.bscCuentaBancaria.Datos = Nothing
         Me.bscCuentaBancaria.Enabled = False
         Me.bscCuentaBancaria.Text = String.Empty
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarFiltros()

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

         Filtros = "Año: " & Me.dtpAnio.Text

         Filtros = Filtros & " - " & "Moneda: " & Me.cmbMonedas.Text

         If Me.chbCuentaBancaria.Checked Then
            Filtros = Filtros & " - " & "Cuenta Bancaria: " & Me.bscCuentaBancaria.Text
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

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub bscCuentaBancaria_BuscadorClick() Handles bscCuentaBancaria.BuscadorClick

      Try

         Me._publicos.PreparaGrillaCuentasBancarias(Me.bscCuentaBancaria)
         Dim oCBancarias As Reglas.CuentasBancarias = New Reglas.CuentasBancarias()
         Me.bscCuentaBancaria.Datos = oCBancarias.GetFiltradoPorNombre(Me.bscCuentaBancaria.Text.Trim())

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCuentaBancaria_BuscadorSeleccion(ByVal sender As System.Object, ByVal e As Eniac.Controles.BuscadorEventArgs) Handles bscCuentaBancaria.BuscadorSeleccion

      Try

         If Not e.FilaDevuelta Is Nothing Then
            Me.bscCuentaBancaria.Text = e.FilaDevuelta.Cells("NombreCuenta").Value
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try
         If chbCuentaBancaria.Checked AndAlso bscCuentaBancaria.Text = String.Empty Then
            MessageBox.Show("Debe seleccionar una Cuenta Bancaria !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor
         Me.CargaGrillaDetalle()
         Me.Cursor = Cursors.Default

         If ugDetalle.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

      Catch ex As Exception
         Me.tssRegistros.Text = "0 Registros"
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

#End Region

#Region "Metodos"

   Private Sub FormatearColumnas()

      For Each cl As UltraWinGrid.UltraGridColumn In Me.ugDetalle.DisplayLayout.Bands(0).Columns
         cl.CellActivation = Activation.NoEdit
         cl.Hidden = True
      Next

      With Me.ugDetalle.DisplayLayout.Bands(0)
         '.Columns("IdCuentaBanco").Header.Caption = "Cuenta"
         '.Columns("IdCuentaBanco").Width = 50
         '.Columns("IdCuentaBanco").Hidden = False

         .Columns("NombreCuentaBanco").Header.Caption = "Nombre Cuenta"
         .Columns("NombreCuentaBanco").Width = 210
         .Columns("NombreCuentaBanco").Hidden = False

         .Columns("Enero").Header.Caption = "Enero"
         .Columns("Enero").Width = 75
         .Columns("Enero").Hidden = False
         .Columns("Enero").CellAppearance.TextHAlign = HAlign.Right

         .Columns("Febrero").Header.Caption = "Febrero"
         .Columns("Febrero").Width = 75
         .Columns("Febrero").Hidden = False
         .Columns("Febrero").CellAppearance.TextHAlign = HAlign.Right

         .Columns("Marzo").Header.Caption = "Marzo"
         .Columns("Marzo").Width = 75
         .Columns("Marzo").Hidden = False
         .Columns("Marzo").CellAppearance.TextHAlign = HAlign.Right

         .Columns("Abril").Header.Caption = "Abril"
         .Columns("Abril").Width = 75
         .Columns("Abril").Hidden = False
         .Columns("Abril").CellAppearance.TextHAlign = HAlign.Right

         .Columns("Mayo").Header.Caption = "Mayo"
         .Columns("Mayo").Width = 75
         .Columns("Mayo").Hidden = False
         .Columns("Mayo").CellAppearance.TextHAlign = HAlign.Right

         .Columns("Junio").Header.Caption = "Junio"
         .Columns("Junio").Width = 75
         .Columns("Junio").Hidden = False
         .Columns("Junio").CellAppearance.TextHAlign = HAlign.Right

         .Columns("Julio").Header.Caption = "Julio"
         .Columns("Julio").Width = 75
         .Columns("Julio").Hidden = False
         .Columns("Julio").CellAppearance.TextHAlign = HAlign.Right

         .Columns("Agosto").Header.Caption = "Agosto"
         .Columns("Agosto").Width = 75
         .Columns("Agosto").Hidden = False
         .Columns("Agosto").CellAppearance.TextHAlign = HAlign.Right

         .Columns("Septiembre").Header.Caption = "Septiembre"
         .Columns("Septiembre").Width = 75
         .Columns("Septiembre").Hidden = False
         .Columns("Septiembre").CellAppearance.TextHAlign = HAlign.Right

         .Columns("Octubre").Header.Caption = "Octubre"
         .Columns("Octubre").Width = 75
         .Columns("Octubre").Hidden = False
         .Columns("Octubre").CellAppearance.TextHAlign = HAlign.Right

         .Columns("Noviembre").Header.Caption = "Noviembre"
         .Columns("Noviembre").Width = 75
         .Columns("Noviembre").Hidden = False
         .Columns("Noviembre").CellAppearance.TextHAlign = HAlign.Right

         .Columns("Diciembre").Header.Caption = "Diciembre"
         .Columns("Diciembre").Width = 75
         .Columns("Diciembre").Hidden = False
         .Columns("Diciembre").CellAppearance.TextHAlign = HAlign.Right

         .Columns("Total").Header.Caption = "Total"
         .Columns("Total").Width = 80
         .Columns("Total").Hidden = False
         .Columns("Total").CellAppearance.TextHAlign = HAlign.Right

      End With

   End Sub

   Private Sub RefrescarFiltros()

      Me.dtpAnio.Value = Date.Now

      Me.cmbMonedas.SelectedValue = 1  'Pesos

      Me.chbCuentaBancaria.Checked = False

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.dtpAnio.Focus()

   End Sub

   Private Sub CargarColumnasASumar()

      Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
      Me.ugDetalle.DisplayLayout.Override.SummaryValueAppearance.BackColor = Color.Yellow

      Dim columnToSummarize1 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("Enero")
      Dim summary1 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("Enero", SummaryType.Sum, columnToSummarize1)
      summary1.DisplayFormat = "{0:N2}"
      summary1.Appearance.TextHAlign = HAlign.Right

      Dim columnToSummarize2 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("Febrero")
      Dim summary2 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("Febrero", SummaryType.Sum, columnToSummarize2)
      summary2.DisplayFormat = "{0:N2}"
      summary2.Appearance.TextHAlign = HAlign.Right

      Dim columnToSummarize3 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("Marzo")
      Dim summary3 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("Marzo", SummaryType.Sum, columnToSummarize3)
      summary3.DisplayFormat = "{0:N2}"
      summary3.Appearance.TextHAlign = HAlign.Right

      Dim columnToSummarize4 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("Abril")
      Dim summary4 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("Abril", SummaryType.Sum, columnToSummarize4)
      summary4.DisplayFormat = "{0:N2}"
      summary4.Appearance.TextHAlign = HAlign.Right

      Dim columnToSummarize5 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("Mayo")
      Dim summary5 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("Mayo", SummaryType.Sum, columnToSummarize5)
      summary5.DisplayFormat = "{0:N2}"
      summary5.Appearance.TextHAlign = HAlign.Right

      Dim columnToSummarize6 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("Junio")
      Dim summary6 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("Junio", SummaryType.Sum, columnToSummarize6)
      summary6.DisplayFormat = "{0:N2}"
      summary6.Appearance.TextHAlign = HAlign.Right

      Dim columnToSummarize7 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("Julio")
      Dim summary7 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("Julio", SummaryType.Sum, columnToSummarize7)
      summary7.DisplayFormat = "{0:N2}"
      summary7.Appearance.TextHAlign = HAlign.Right

      Dim columnToSummarize8 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("Agosto")
      Dim summary8 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("Agosto", SummaryType.Sum, columnToSummarize8)
      summary8.DisplayFormat = "{0:N2}"
      summary8.Appearance.TextHAlign = HAlign.Right

      Dim columnToSummarize9 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("Septiembre")
      Dim summary9 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("Septiembre", SummaryType.Sum, columnToSummarize9)
      summary9.DisplayFormat = "{0:N2}"
      summary9.Appearance.TextHAlign = HAlign.Right

      Dim columnToSummarize10 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("Octubre")
      Dim summary10 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("Octubre", SummaryType.Sum, columnToSummarize10)
      summary10.DisplayFormat = "{0:N2}"
      summary10.Appearance.TextHAlign = HAlign.Right

      Dim columnToSummarize11 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("Noviembre")
      Dim summary11 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("Noviembre", SummaryType.Sum, columnToSummarize11)
      summary11.DisplayFormat = "{0:N2}"
      summary11.Appearance.TextHAlign = HAlign.Right

      Dim columnToSummarize12 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("Diciembre")
      Dim summary12 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("Diciembre", SummaryType.Sum, columnToSummarize12)
      summary12.DisplayFormat = "{0:N2}"
      summary12.Appearance.TextHAlign = HAlign.Right

      Dim columnToSummarize13 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("Total")
      Dim summary13 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("Total", SummaryType.Sum, columnToSummarize13)
      summary13.DisplayFormat = "{0:N2}"
      summary13.Appearance.TextHAlign = HAlign.Right

      Me.ugDetalle.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales:"

   End Sub


   Private Sub CargaGrillaDetalle()

      Try

         Dim sConciliado As String = "Todos"
         Dim sPosdatado As String = "Todos"
         Dim IdCuentaBancaria As Integer = 0

         Dim rLibroBancos As Reglas.LibroBancos = New Reglas.LibroBancos()
         Dim dt As New DataTable

         If Me.chbCuentaBancaria.Checked Then
            IdCuentaBancaria = Integer.Parse(Me.bscCuentaBancaria.FilaDevuelta.Cells("IdCuentaBancaria").Value.ToString())
         End If

         dt = rLibroBancos.ResumenAnual(actual.Sucursal.Id, _
                                        Integer.Parse(dtpAnio.Text), _
                                        Integer.Parse(Me.cmbMonedas.SelectedValue.ToString()), _
                                        IdCuentaBancaria)

         'If dt.Rows.Count = 0 Then
         '   Me.Cursor = Cursors.Default
         '   MessageBox.Show("NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         '   Me.dtpAnio.Focus()
         '   Exit Sub
         'End If

         Me.ugDetalle.DataSource = dt

         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

#End Region

End Class