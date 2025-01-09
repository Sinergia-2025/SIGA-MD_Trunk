Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Documents.Reports.Report
Imports Infragistics.Documents.Reports.Report.Section
Imports Infragistics.Documents.Excel

Public Class ContabilidadListadoBceGral

#Region "Campos"

   Private _publicos As ContabilidadPublicos
   'Private _idCuenta As Long
   'Private _nombreCuenta As String

   'Dim idPlan As Integer = 1 'default
   'Dim SucursalesSelect As String = String.Empty
   'Dim suc As List(Of Integer) = New List(Of Integer)

#End Region

#Region "Propiedades"

   'Public Property IdCuenta() As Long
   '   Get
   '      Return _idCuenta
   '   End Get
   '   Set(ByVal value As Long)
   '      _idCuenta = value
   '   End Set
   'End Property

   'Public Property NombreCuenta() As String
   '   Get
   '      Return _nombreCuenta
   '   End Get
   '   Set(ByVal value As String)
   '      _nombreCuenta = value
   '   End Set
   'End Property

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Me._publicos = New ContabilidadPublicos()

      Me._publicos.CargaComboPlanes(Me.cmbPlan, True)
      Me._publicos.CargarSucursalesACheckListBox(Me.clbSucursales)

      Me.CargarValoresIniciales()

   End Sub

   'Public Function GetReglas() As Eniac.Reglas.Base
   '   Return New Reglas.ContabilidadReportes()
   'End Function

#End Region

#Region "Eventos"

   Private Sub ContabilidadListadoBceGral_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.RefrescarDatos()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbImprimirPredefinido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimirPredefinido.Click

      If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

      Try

         Me.Cursor = Cursors.WaitCursor

         Dim Sucursales As String = String.Empty
         For Each ite As Object In Me.clbSucursales.CheckedItems
            Sucursales += ", " + DirectCast(ite, Entidades.Sucursal).Nombre
         Next
         If Sucursales.Length > 0 Then Sucursales = Sucursales.Substring(2)

         Dim FechaHasta As Date = Me.dtpBalanceHasta.Value

         'Dim Filtros As String

         'Filtros = "Filtros: Rango de Fechas: desde el " & Me.dtpDesde.Text & " hasta el " & Me.dtpHasta.Text

         'If Me.cmbTipoDoc.SelectedIndex >= 0 And Me.bscNroDoc.Text.Length > 0 Then
         '   Filtros = Filtros & " / Cliente: " & Me.cmbTipoDoc.Text & " " & Me.bscNroDoc.Text.Trim() & " - " & Me.bscCliente.Text.Trim()
         'End If

         Dim dt As DataTable

         dt = DirectCast(Me.ugDetalle.DataSource, DataTable)

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Eniac.Win.Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("fechaHasta", FechaHasta.ToShortDateString))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("PlanCta", Me.cmbPlan.Text))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Sucursal", Sucursales))

         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.rptBalanceGral.rdlc", "dtsBalanceGral_dtBalanceGral", dt, parm, True, 1) '# 1 = Cantidad Copias

         frmImprime.Text = Me.Text
         frmImprime.rvReporte.DocumentMapCollapsed = True
         frmImprime.Size = New Size(780, 600)
         frmImprime.StartPosition = FormStartPosition.CenterScreen
         frmImprime.WindowState = FormWindowState.Maximized
         frmImprime.Show()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
      Try
         Me.CargaGrillaDetalle()
         CargarColumnasASumar()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Function AplicarJerarquia(ByVal codigo As String) As String

      Return codigo.Substring(0, 1) & "." _
                      & codigo.Substring(1, 2) & "." _
                      & codigo.Substring(3, 2) & "." _
                      & codigo.Substring(5, 3)
   End Function

   Private Sub CargarValoresIniciales()
      Me.dtpBalanceHasta.Value = Date.Now
   End Sub

   Private Sub CargaGrillaDetalle()
      If ValidarBalance() Then

         Dim FechaHasta As Date = Me.dtpBalanceHasta.Value
         Dim idPlan As Integer? = Integer.Parse(Me.cmbPlan.SelectedValue.ToString())
         If idPlan < 1 Then idPlan = Nothing
         Dim Sucursales As List(Of Integer) = New List(Of Integer)

         For Each ite As Object In Me.clbSucursales.CheckedItems
            Sucursales.Add(DirectCast(ite, Entidades.Sucursal).Id)
         Next

         Dim reg As Reglas.ContabilidadReportes = New Reglas.ContabilidadReportes
         Dim oReporteBalance As New Entidades.ContabilidadReporte

         Dim dtsBalance As New dtsBalanceGral
         oReporteBalance = reg.BalanceGeneral(FechaHasta, idPlan, Sucursales.ToArray())


         Me.ugDetalle.DataSource = oReporteBalance.Balance

         Me.formatearGrilla()

         If oReporteBalance.Balance Is Nothing OrElse oReporteBalance.Balance.Rows.Count = 0 Then
            MessageBox.Show("No se encontraron datos para los filtros seleccionados.", "Reportes", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

      End If
   End Sub

   Private Function ValidarBalance() As Boolean
      Return True
   End Function

   Private Sub RefrescarDatos()

      Dim Cont As Integer

      For Cont = 0 To clbSucursales.Items.Count - 1
         'Siempre marco la actual
         If DirectCast(Me.clbSucursales.Items.Item(Cont), Entidades.Sucursal).Id = actual.Sucursal.Id Then
            Me.clbSucursales.SetItemChecked(Cont, True)
         Else
            Me.clbSucursales.SetItemChecked(Cont, False)
         End If
      Next

      Me.dtpBalanceHasta.Value = Now
      Me.cmbPlan.SelectedIndex = 0

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      ugDetalle.DisplayLayout.Bands(0).SortedColumns.Clear()
      ugDetalle.DisplayLayout.Bands(0).SortedColumns.Add(ugDetalle.DisplayLayout.Bands(0).Columns("rn"), False)

      Me.tssRegistros.Text = " 0 Registros"

   End Sub

   Private Sub formatearGrilla()

      With Me.ugDetalle.DisplayLayout.Bands(0)

         For Each columna As UltraGridColumn In .Columns
            columna.CellActivation = Activation.ActivateOnly
            columna.Hidden = True
         Next

         '.Columns("NombrePlanCuenta").Hidden = False
         '.Columns("NombrePlanCuenta").Header.VisiblePosition = 0
         '.Columns("NombrePlanCuenta").Header.Caption = "Plan de Cuenta"
         '.Columns("NombrePlanCuenta").Width = 100
         '.Columns("NombrePlanCuenta").MinWidth = 100
         '.Columns("NombrePlanCuenta").MaxWidth = 100

         .Columns("idCuenta").Hidden = False
         .Columns("idCuenta").Header.VisiblePosition = 1
         .Columns("idCuenta").Header.Caption = "Nro. Cuenta"
         .Columns("idCuenta").CellAppearance.TextHAlign = HAlign.Right
         .Columns("idCuenta").Width = 80
         .Columns("idCuenta").MinWidth = 80
         .Columns("idCuenta").MaxWidth = 80

         .Columns("NombreCuenta").Hidden = False
         .Columns("NombreCuenta").Header.VisiblePosition = 2
         .Columns("NombreCuenta").Header.Caption = "Cuenta"
         .Columns("NombreCuenta").Width = 300

         .Columns("debeSumas").Hidden = False
         .Columns("debeSumas").Header.VisiblePosition = 3
         .Columns("debeSumas").Header.Caption = "Sumas Debe"
         .Columns("debeSumas").Format = "N2"
         .Columns("debeSumas").CellAppearance.TextHAlign = HAlign.Right
         .Columns("debeSumas").Width = 100
         .Columns("debeSumas").MinWidth = 100
         .Columns("debeSumas").MaxWidth = 120

         .Columns("haberSumas").Hidden = False
         .Columns("haberSumas").Header.VisiblePosition = 4
         .Columns("haberSumas").Header.Caption = "Sumas Haber"
         .Columns("haberSumas").Format = "N2"
         .Columns("haberSumas").CellAppearance.TextHAlign = HAlign.Right
         .Columns("haberSumas").Width = 100
         .Columns("haberSumas").MinWidth = 100
         .Columns("haberSumas").MaxWidth = 120

         .Columns("debeSaldos").Hidden = False
         .Columns("debeSaldos").Header.VisiblePosition = 5
         .Columns("debeSaldos").Header.Caption = "Saldos Debe"
         .Columns("debeSaldos").Format = "N2"
         .Columns("debeSaldos").CellAppearance.TextHAlign = HAlign.Right
         .Columns("debeSaldos").Width = 100
         .Columns("debeSaldos").MinWidth = 100
         .Columns("debeSaldos").MaxWidth = 120

         .Columns("haberSaldos").Hidden = False
         .Columns("haberSaldos").Header.VisiblePosition = 6
         .Columns("haberSaldos").Header.Caption = "Saldos Haber"
         .Columns("haberSaldos").Format = "N2"
         .Columns("haberSaldos").CellAppearance.TextHAlign = HAlign.Right
         .Columns("haberSaldos").Width = 100
         .Columns("haberSaldos").MinWidth = 100
         .Columns("haberSaldos").MaxWidth = 120

         '.Columns("rn").Hidden = False

         'If Me.cmbPlan.SelectedIndex > 0 Then
         '   .Columns("NombrePlanCuenta").Hidden = True
         'End If

         If .SortedColumns.Count = 0 Then
            .SortedColumns.Add(.Columns("rn"), False)
         End If

      End With

      ugDetalle.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

   End Sub

   Private Sub CargarColumnasASumar()


      With Me.ugDetalle.DisplayLayout.Bands(0)
         .Summaries.Clear()
         'If .Columns.Count = 0 Then
         '   Exit Sub
         'End If

         'If Not .Summaries.Count > 0 Then

         '   Dim columnToSummarize1 As UltraGridColumn = .Columns("haberSaldos")
         '   Dim summary1 As SummarySettings = .Summaries.Add(columnToSummarize1.Key, SummaryType.Sum, columnToSummarize1)
         '   summary1.DisplayFormat = "{0:N2}"
         '   summary1.Appearance.TextHAlign = HAlign.Right

         '   Dim columnToSummarize2 As UltraGridColumn = .Columns("debeSaldos")
         '   Dim summary2 As SummarySettings = .Summaries.Add(columnToSummarize2.Key, SummaryType.Sum, columnToSummarize2)
         '   summary2.DisplayFormat = "{0:N2}"
         '   summary2.Appearance.TextHAlign = HAlign.Right

         '   Dim columnToSummarize3 As UltraGridColumn = .Columns("haberSumas")
         '   Dim summary3 As SummarySettings = .Summaries.Add(columnToSummarize3.Key, SummaryType.Sum, columnToSummarize3)
         '   summary3.DisplayFormat = "{0:N2}"
         '   summary3.Appearance.TextHAlign = HAlign.Right

         '   Dim columnToSummarize4 As UltraGridColumn = .Columns("debeSumas")
         '   Dim summary4 As SummarySettings = .Summaries.Add(columnToSummarize4.Key, SummaryType.Sum, columnToSummarize4)
         '   summary4.DisplayFormat = "{0:N2}"
         '   summary4.Appearance.TextHAlign = HAlign.Right

         '   .SummaryFooterCaption = "Totales:"
         'End If
      End With

      'Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
      'Me.ugDetalle.DisplayLayout.Override.SummaryValueAppearance.BackColor = Color.Yellow

   End Sub

#End Region

   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
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
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click

      Try

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim Titulo As String

         Titulo = Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Me.CargarFiltrosImpresion()

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


         Dim UltraPrintPreviewD As Infragistics.Win.Printing.UltraPrintPreviewDialog
         UltraPrintPreviewD = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
         UltraPrintPreviewD.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
         UltraPrintPreviewD.Name = "UltraPrintPreviewDialog1"
         UltraPrintPreviewD.Document = Me.UltraGridPrintDocument1
         UltraPrintPreviewD.Name = Me.Text
         UltraPrintPreviewD.MdiParent = Me.MdiParent
         UltraPrintPreviewD.Show()
         UltraPrintPreviewD.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Function CargarFiltrosImpresion() As String
      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()

      With filtro
         If clbSucursales.CheckedItems.Count > 0 Then
            Dim Sucursales As String = String.Empty
            For Each ite As Object In Me.clbSucursales.CheckedItems
               Sucursales += ", " + DirectCast(ite, Entidades.Sucursal).Nombre
            Next
            Sucursales = Sucursales.Trim().Trim(","c)
            .AppendFormat("Suc.: {0} - ", Sucursales)
         End If

         If cmbPlan.SelectedIndex >= 0 Then
            .AppendFormat("Plan: {0} - ", cmbPlan.Text)
         End If

         .AppendFormat("Fecha hasta: {0:d} - ", dtpBalanceHasta.Value)
      End With

      Return filtro.ToString.Trim().Trim("-"c)
   End Function

   Private Sub dtpBalanceHasta_ValueChanged(sender As Object, e As EventArgs) Handles dtpBalanceHasta.ValueChanged
      Try
         Dim fechaDesde As Date?
         Dim fechaHasta As Date? = dtpBalanceHasta.Value
         Dim rEjercicio As Reglas.ContabilidadEjercicios = New Reglas.ContabilidadEjercicios()
         rEjercicio.CompletaFechasSegunEjercicio(fechaDesde, fechaHasta)
         If fechaDesde.HasValue Then
            dtpBalanceDesde.Value = fechaDesde.Value
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
End Class