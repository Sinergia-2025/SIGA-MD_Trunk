Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Documents.Reports.Report
Imports Infragistics.Documents.Excel
Imports Infragistics.Documents.Reports.Report.Section
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Public Class ContabilidadListadoBalance

#Region "Campos"

   Private _publicosContabilidad As ContabilidadPublicos
   Private _publicos As Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try
         Me._publicosContabilidad = New ContabilidadPublicos()
         Me._publicos = New Publicos()

         Me._publicosContabilidad.CargaComboPlanes(Me.cmbPlan, True)
         Me._publicosContabilidad.CargarSucursalesACheckListBox(Me.clbSucursales)
         _publicos.CargaComboDesdeEnum(cmbColumnas, GetType(Entidades.ContabilidadReporte.ColumnasBalance))

         cmbColumnas.SelectedValue = Entidades.ContabilidadReporte.ColumnasBalance.CuatroColumnas

         Me.CargarValoresIniciales()
         Me.CargarColumnasASumar()
         Me.LeerPreferencias()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub ContabilidadListadoBalance_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Me.RefrescarDatos()
   End Sub

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click

      If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

      Try

         Me.Cursor = Cursors.WaitCursor

         Dim Sucursales As String = String.Empty
         For Each ite As Object In Me.clbSucursales.CheckedItems
            Sucursales += ", " + DirectCast(ite, Entidades.Sucursal).Nombre
         Next
         If Sucursales.Length > 0 Then Sucursales = Sucursales.Substring(2)

         Dim dt As DataTable = DirectCast(Me.ugDetalle.DataSource, DataTable)

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Eniac.Win.Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Sucursales))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", CargarFiltrosImpresion()))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TresColumnas", (DirectCast(cmbColumnas.SelectedValue, Entidades.ContabilidadReporte.ColumnasBalance) = Entidades.ContabilidadReporte.ColumnasBalance.TresColumnas).ToString()))

         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.rptBalanceNuevo.rdlc", "dtsBalanceNuevo_dtBalance", dt, parm, True, 1) '# 1 = Cantidad Copias

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

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
      Try

         'Me.chkExpandAll.Enabled = True
         'Me.chkExpandAll.Checked = False

         Me.Cursor = Cursors.WaitCursor

         'Me.CargaGrillaDetalle()
         Me.CargarGrillaDetalle_nuevo()
         Me.CargarColumnasASumar()

      Catch ex As Exception
         'Me.tssRegistros.Text = "0 Registros"
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   'Private Sub chkExpandAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
   '   If Me.chkExpandAll.Checked Then
   '      Me.ugDetalle.Rows.ExpandAll(True)
   '   Else
   '      Me.ugDetalle.Rows.CollapseAll(True)
   '   End If
   'End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         Dim pre As Preferencias = New Preferencias(Me.ugDetalle, True)
         pre.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodos"


   Private Sub CargarColumnasASumar()


      With Me.ugDetalle.DisplayLayout.Bands(0)
         If .Columns.Count = 0 Then
            Exit Sub
         End If

         If Not .Summaries.Count > 0 Then

            Dim columnToSummarize1 As UltraGridColumn = .Columns("haberSaldos")
            Dim summary1 As SummarySettings = .Summaries.Add(columnToSummarize1.Key, SummaryType.Sum, columnToSummarize1)
            summary1.DisplayFormat = "{0:N2}"
            summary1.Appearance.TextHAlign = HAlign.Right

            Dim columnToSummarize2 As UltraGridColumn = .Columns("debeSaldos")
            Dim summary2 As SummarySettings = .Summaries.Add(columnToSummarize2.Key, SummaryType.Sum, columnToSummarize2)
            summary2.DisplayFormat = "{0:N2}"
            summary2.Appearance.TextHAlign = HAlign.Right

            Dim columnToSummarize3 As UltraGridColumn = .Columns("haberSumas")
            Dim summary3 As SummarySettings = .Summaries.Add(columnToSummarize3.Key, SummaryType.Sum, columnToSummarize3)
            summary3.DisplayFormat = "{0:N2}"
            summary3.Appearance.TextHAlign = HAlign.Right

            Dim columnToSummarize4 As UltraGridColumn = .Columns("debeSumas")
            Dim summary4 As SummarySettings = .Summaries.Add(columnToSummarize4.Key, SummaryType.Sum, columnToSummarize4)
            summary4.DisplayFormat = "{0:N2}"
            summary4.Appearance.TextHAlign = HAlign.Right

            'GAR: 06/01/2017 - Agregado y quitado porque el total da cero (y siiii).
            'Dim columnToSummarize5 As UltraGridColumn = .Columns("saldos")
            'Dim summary5 As SummarySettings = .Summaries.Add(columnToSummarize5.Key, SummaryType.Sum, columnToSummarize5)
            'summary5.DisplayFormat = "{0:N2}"
            'summary5.Appearance.TextHAlign = HAlign.Right
            '----------------------------------------------------------------------

            .SummaryFooterCaption = "Totales:"
         End If
      End With

      Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
      Me.ugDetalle.DisplayLayout.Override.SummaryValueAppearance.BackColor = Color.Yellow

   End Sub

   '' ''Private Function AplicarJerarquia(ByVal codigo As String) As String

   '' ''   Return codigo.Substring(0, 1) & "." _
   '' ''                   & codigo.Substring(1, 2) & "." _
   '' ''                   & codigo.Substring(3, 2) & "." _
   '' ''                   & codigo.Substring(5, 3)
   '' ''End Function

   Private Sub CargarValoresIniciales()
      Me.dtpBalance.Value = Date.Now
   End Sub

   Private Sub CargarGrillaDetalle_nuevo()
      If ValidarBalance() Then

         Dim FechaDesde As Date? = Nothing
         Dim FechaHasta As Date = Me.dtpBalance.Value
         Dim idPlan As Integer? = Integer.Parse(Me.cmbPlan.SelectedValue.ToString())
         If idPlan < 1 Then idPlan = Nothing
         Dim Sucursales As List(Of Integer) = New List(Of Integer)

         For Each ite As Object In Me.clbSucursales.CheckedItems
            Sucursales.Add(DirectCast(ite, Entidades.Sucursal).Id)
         Next

         Dim reg As Reglas.ContabilidadReportes = New Reglas.ContabilidadReportes
         Dim oReporteBalance As New Entidades.ContabilidadReporte

         If dtpBalanceDesde.Checked Then
            FechaDesde = dtpBalanceDesde.Value
         End If

         Dim dtsBalance As New dtsBalance
         oReporteBalance = reg.balanceNuevo(FechaDesde, FechaHasta, idPlan, Sucursales.ToArray(), chbIncluirCuentasSinMovimientos.Checked)

         Me.tssRegistros.Text = oReporteBalance.Balance.Rows.Count.ToString() & " Registros"

         Me.ugDetalle.DataSource = oReporteBalance.Balance

         Me.formatearGrilla_nueva()

         If oReporteBalance.Balance Is Nothing OrElse oReporteBalance.Balance.Rows.Count = 0 Then
            MessageBox.Show("No se encontraron datos para los filtros seleccionados.", "Reportes", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

      End If
   End Sub

   '' ''Private Sub CargaGrillaDetalle()

   '' ''   If ValidarBalance() Then

   '' ''      Dim FechaHasta As Date = Me.dtpBalance.Value
   '' ''      Dim idPlan As Integer = Integer.Parse(Me.cmbPlan.SelectedValue.ToString())
   '' ''      Dim Sucursales As List(Of Integer) = New List(Of Integer)

   '' ''      For Each ite As Object In Me.clbSucursales.CheckedItems
   '' ''         Sucursales.Add(DirectCast(ite, Entidades.Sucursal).Id)
   '' ''      Next

   '' ''      Dim reg As Reglas.ContabilidadReportes = New Reglas.ContabilidadReportes
   '' ''      Dim oReporteBalance As New Entidades.ContabilidadReporte

   '' ''      Dim dtsBalance As New dtsBalance
   '' ''      oReporteBalance = reg.balance(FechaHasta, idPlan, Sucursales.ToArray())


   '' ''      Me.ugDetalle.DataSource = oReporteBalance.Balance

   '' ''      Me.formatearGrilla()

   '' ''      If oReporteBalance.Balance Is Nothing OrElse oReporteBalance.Balance.Rows.Count = 0 Then
   '' ''         MessageBox.Show("No se encontraron datos para los filtros seleccionados", "Reportes", MessageBoxButtons.OK, MessageBoxIcon.Information)
   '' ''         Exit Sub
   '' ''      End If

   '' ''   End If

   '' ''End Sub

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

      Me.dtpBalanceDesde.Checked = False
      Me.dtpBalance.Value = Now
      Me.cmbPlan.SelectedIndex = 0
      Me.cmbColumnas.SelectedIndex = 1

      'Me.chkExpandAll.Checked = False
      'Me.chkExpandAll.Enabled = False

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.tssRegistros.Text = " 0 Registros"

   End Sub
   Private Sub formatearGrilla_nueva()
      With Me.ugDetalle.DisplayLayout.Bands(0)

         For Each columna As UltraGridColumn In .Columns
            columna.CellActivation = Activation.ActivateOnly
         Next

         '.Columns("NombrePlanCuenta").Header.VisiblePosition = 0
         '.Columns("NombrePlanCuenta").Header.Caption = "Plan de Cuenta"
         '.Columns("NombrePlanCuenta").MaxWidth = 110
         '.Columns("NombrePlanCuenta").MinWidth = 90

         .Columns("idCuenta").Header.VisiblePosition = 1
         .Columns("idCuenta").Header.Caption = "Nro. Cuenta"
         .Columns("idCuenta").CellAppearance.TextHAlign = HAlign.Right
         .Columns("idCuenta").MaxWidth = 98
         .Columns("idCuenta").MinWidth = 73

         .Columns("NombreCuenta").Header.VisiblePosition = 2
         .Columns("NombreCuenta").Header.Caption = "Cuenta"
         .Columns("NombreCuenta").Width = 300

         .Columns("debeSumas").Header.VisiblePosition = 3
         .Columns("debeSumas").Header.Caption = "Sumas Debe"
         .Columns("debeSumas").Format = "N2"
         .Columns("debeSumas").CellAppearance.TextHAlign = HAlign.Right
         .Columns("debeSumas").MaxWidth = 98
         .Columns("debeSumas").MinWidth = 98

         .Columns("haberSumas").Header.VisiblePosition = 4
         .Columns("haberSumas").Header.Caption = "Sumas Haber"
         .Columns("haberSumas").Format = "N2"
         .Columns("haberSumas").CellAppearance.TextHAlign = HAlign.Right
         .Columns("haberSumas").MaxWidth = 98
         .Columns("haberSumas").MinWidth = 98

         .Columns("debeSaldos").Header.VisiblePosition = 5
         .Columns("debeSaldos").Header.Caption = "Saldos Debe"
         .Columns("debeSaldos").Format = "N2"
         .Columns("debeSaldos").CellAppearance.TextHAlign = HAlign.Right
         .Columns("debeSaldos").Hidden = DirectCast(cmbColumnas.SelectedValue, Entidades.ContabilidadReporte.ColumnasBalance) = Entidades.ContabilidadReporte.ColumnasBalance.TresColumnas
         .Columns("debeSaldos").MaxWidth = 98
         .Columns("debeSaldos").MinWidth = 98

         .Columns("haberSaldos").Header.VisiblePosition = 6
         .Columns("haberSaldos").Header.Caption = "Saldos Haber"
         .Columns("haberSaldos").Format = "N2"
         .Columns("haberSaldos").CellAppearance.TextHAlign = HAlign.Right
         .Columns("haberSaldos").Hidden = DirectCast(cmbColumnas.SelectedValue, Entidades.ContabilidadReporte.ColumnasBalance) = Entidades.ContabilidadReporte.ColumnasBalance.TresColumnas
         .Columns("haberSaldos").MaxWidth = 98
         .Columns("haberSaldos").MinWidth = 98

         .Columns("saldos").Header.VisiblePosition = 7
         .Columns("saldos").Header.Caption = "Saldos"
         .Columns("saldos").Format = "N2"
         .Columns("saldos").CellAppearance.TextHAlign = HAlign.Right
         .Columns("saldos").Hidden = DirectCast(cmbColumnas.SelectedValue, Entidades.ContabilidadReporte.ColumnasBalance) = Entidades.ContabilidadReporte.ColumnasBalance.CuatroColumnas
         .Columns("saldos").MaxWidth = 98
         .Columns("saldos").MinWidth = 98

         .Columns("IdCuentaPadre").Hidden = True
         If (cmbColumnas.SelectedIndex = 0) Then

         End If
      End With
      ugDetalle.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
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

   '' ''Private Sub formatearGrilla()

   '' ''   'Me.dgdDatos.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
   '' ''   'Me.dgdDatos.DisplayLayout.Bands(0).SortedColumns.Add("NombrePlanCuenta", False, True)

   '' ''   'Me.dgdDatos.DisplayLayout.Bands(0).Columns("nombreplancuenta").Band.SortedColumns.RefreshSort(False)

   '' ''   'Me.dgdDatos.Rows.ExpandAll(False)

   '' ''   With Me.ugDetalle.DisplayLayout.Bands(0)
   '' ''      '.Columns("IdPlanCuenta").Header.VisiblePosition = 0
   '' ''      '.Columns("nombreplancuenta").Header.VisiblePosition = 1
   '' ''      '.Columns("nombreplancuenta").Header.Caption = "Plan Cuenta"
   '' ''      .Columns("idCuenta").Header.VisiblePosition = 0
   '' ''      .Columns("idCuenta").Header.Caption = "Nro. Cuenta"
   '' ''      .Columns("idCuenta").CellAppearance.TextHAlign = HAlign.Right
   '' ''      .Columns("NombreCuenta").Header.VisiblePosition = 1
   '' ''      .Columns("NombreCuenta").Header.Caption = "Cuenta"
   '' ''      .Columns("NombreCuenta").Width = 300
   '' ''      .Columns("saldoCuenta").Header.VisiblePosition = 2
   '' ''      .Columns("saldoCuenta").Header.Caption = "Saldo"
   '' ''      .Columns("saldoCuenta").Format = "##,##0.00"
   '' ''      .Columns("saldoCuenta").CellAppearance.TextHAlign = HAlign.Right
   '' ''      If Me.cmbPlan.SelectedIndex > 0 Then
   '' ''         .Columns("IdPlanCuenta").Hidden = True
   '' ''         .Columns("NombrePlanCuenta").Hidden = True
   '' ''      End If
   '' ''   End With

   '' ''End Sub

#End Region

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

         .AppendFormat("Fecha hasta: {0:d} - ", dtpBalance.Value)
      End With

      Return filtro.ToString.Trim().Trim("-"c)
   End Function

   Private Sub dtpBalance_ValueChanged(sender As Object, e As EventArgs) Handles dtpBalance.ValueChanged
      Try
         If Not dtpBalanceDesde.Checked Then
            Dim rEjercicio As Reglas.ContabilidadEjercicios = New Reglas.ContabilidadEjercicios()
            Dim codEjeVigente As Entidades.ContabilidadEjercicio = rEjercicio.GetUna(dtpBalance.Value, False)
            dtpBalanceDesde.Value = codEjeVigente.FechaDesde
            dtpBalanceDesde.Checked = False
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

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

End Class