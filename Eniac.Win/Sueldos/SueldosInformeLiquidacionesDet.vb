Option Explicit Off
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class SueldosInformeLiquidacionesDet

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         Me._publicos.CargaComboSueldosTiposRecibos(Me.cmbTipoRecibo)

         Me._publicos.CargaComboSueldosPeriodosLiquidacion(Me.cmbPeriodoLiquidacionDesde)

         Me._publicos.CargaComboSueldosPeriodosLiquidacion(Me.cmbPeriodoLiquidacionHasta)

         Me.CargarColumnasASumar()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub SueldosInformeLiquidacionesDet_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count & " Registros"

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


         If Filtros.Length > 0 Then Filtros = Filtros & " - "
         Filtros = Filtros & "Rango de Periodos: desde el " & Me.cmbPeriodoLiquidacionDesde.Text & " hasta el " & Me.cmbPeriodoLiquidacionHasta.Text
      
         If Filtros.Length > 0 Then Filtros = Filtros & " - "
         Filtros = Filtros & "Tipo de Recibo: " & Me.cmbTipoRecibo.Text


         If Me.chbConcepto.Checked Then
            If Filtros.Length > 0 Then Filtros = Filtros & " - "
            Filtros = Filtros & "Concepto: " & Me.bscNombreConcepto.Text
         End If

         If Me.ckbLegajo.Checked Then
            If Filtros.Length > 0 Then Filtros = Filtros & " - "
            Filtros = Filtros & "Legajo: " & Me.bscIdLegajo.Text & ": " & Me.bscNombrePersonal.Text
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

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         If Me.chbConcepto.Checked And Not Me.bscCodigoConcepto.Selecciono And Not Me.bscNombreConcepto.Selecciono Then
            MessageBox.Show("ATENCION: NO seleccionó un Concepto aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoConcepto.Focus()
            Exit Sub
         End If

         If Me.ckbLegajo.Checked And Not Me.bscIdLegajo.Selecciono And Not Me.bscNombrePersonal.Selecciono Then
            MessageBox.Show("ATENCION: NO seleccionó un Legajo aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscIdLegajo.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.chkExpandAll.Enabled = True

         Me.CargaGrillaDetalle()

         Me.ugDetalle.Rows.ExpandAll(True)
         Me.chkExpandAll.Checked = True

         If ugDetalle.Rows.Count > 0 Then
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

   Private Sub bscNroDoc_BuscadorClick() Handles bscIdLegajo.BuscadorClick

      Dim NroDoc As Integer = -1

      Try
         Me._publicos.PreparaGrillaPersonal(Me.bscIdLegajo)
         Dim oLegajos As Reglas.SueldosPersonal = New Reglas.SueldosPersonal
         If Me.bscIdLegajo.Text.Trim.Length > 0 Then
            NroDoc = Integer.Parse(Me.bscIdLegajo.Text.Trim())
         End If
         Me.bscIdLegajo.Datos = oLegajos.GetFiltradoPorLegajo(NroDoc)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNroDoc_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscIdLegajo.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosPersonal(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscPersonal_BuscadorClick() Handles bscNombrePersonal.BuscadorClick
      Try
         Me._publicos.PreparaGrillaPersonal(Me.bscNombrePersonal)
         Dim oLegajos As Reglas.SueldosPersonal = New Reglas.SueldosPersonal

         Me.bscNombrePersonal.Datos = oLegajos.GetFiltradoPorNombre(Me.bscNombrePersonal.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscPersonal_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscNombrePersonal.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosPersonal(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub ckbLegajo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbLegajo.CheckedChanged

      Me.bscIdLegajo.Enabled = Me.ckbLegajo.Checked
      Me.bscNombrePersonal.Enabled = Me.ckbLegajo.Checked

      If Not Me.ckbLegajo.Checked Then
         Me.bscIdLegajo.Text = ""
         Me.bscNombrePersonal.Text = ""
      Else
         Me.bscIdLegajo.Focus()
      End If
   End Sub

   Private Sub tsbRefrescar_Click_1(sender As System.Object, e As System.EventArgs) Handles tsbRefrescar.Click

   End Sub

   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      If Me.chkExpandAll.Checked Then
         Me.ugDetalle.Rows.ExpandAll(True)
      Else
         Me.ugDetalle.Rows.CollapseAll(True)
      End If
   End Sub

   Private Sub ugDetalle_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles ugDetalle.InitializeLayout

      e.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.SummaryRow

      e.Layout.Override.SpecialRowSeparatorAppearance.BackColor = Color.FromArgb(218, 217, 241)

      e.Layout.Override.SpecialRowSeparatorHeight = 6

      e.Layout.Override.BorderStyleSpecialRowSeparator = UIElementBorderStyle.RaisedSoft

      e.Layout.ViewStyle = ViewStyle.MultiBand

      e.Layout.ViewStyleBand = ViewStyleBand.OutlookGroupBy

   End Sub
   Private Sub chbConcepto_CheckedChanged(sender As Object, e As EventArgs) Handles chbConcepto.CheckedChanged

      Me.bscCodigoConcepto.Enabled = Me.chbConcepto.Checked
      Me.bscNombreConcepto.Enabled = Me.chbConcepto.Checked

      If Not Me.chbConcepto.Checked Then
         Me.bscCodigoConcepto.Text = ""
         Me.bscNombreConcepto.Text = ""
      Else
         Me.bscCodigoConcepto.Focus()
      End If
   End Sub

#End Region

#Region "Metodos"

   Private Sub RefrescarDatosGrilla()

      Me.cmbPeriodoLiquidacionDesde.SelectedIndex = 0
      Me.cmbPeriodoLiquidacionHasta.SelectedIndex = 0
      Me.cmbTipoRecibo.SelectedIndex = 0

      Me.chbConcepto.Checked = False
      Me.ckbLegajo.Checked = False

      Me.RadioModoNormal.Checked = True

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.chkExpandAll.Enabled = False

   End Sub

   Private Sub CargarDatosPersonal(ByVal dr As DataGridViewRow)

      Me.bscNombrePersonal.Text = dr.Cells("NombrePersonal").Value.ToString()
      Me.bscIdLegajo.Text = dr.Cells("idLegajo").Value.ToString()
      Me.bscNombrePersonal.Enabled = False
      Me.bscIdLegajo.Enabled = False

   End Sub

   Private Sub CargaGrillaDetalle()

      Dim oCtaCteDet As New Reglas.SueldosLiquidacion

      Dim Desde As Date = Nothing
      Dim Hasta As Date = Nothing

      Dim SoloActivos As String = String.Empty

      Try

         Dim tiporecibo As Integer

         Dim TablaLeida As DataTable
         Dim LegajoSeleccionado As String
         Dim CodigoConcepto As String = String.Empty

         LegajoSeleccionado = Me.bscIdLegajo.Text

         tiporecibo = Integer.Parse(cmbTipoRecibo.SelectedValue.ToString())

         If Me.chbConcepto.Checked Then
            CodigoConcepto = Me.bscCodigoConcepto.Tag.ToString()
         End If

         TablaLeida = oCtaCteDet.GetInformeLiquidacionesDetalladas(LegajoSeleccionado, tiporecibo,
                                                                   Integer.Parse(Me.cmbPeriodoLiquidacionDesde.Text.ToString()),
                                                                   Integer.Parse(Me.cmbPeriodoLiquidacionHasta.Text.ToString()),
                                                                   CodigoConcepto)



         Me.ugDetalle.DataSource = TablaLeida

         If Not Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Exists("Saldo") Then
            Dim summary4 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("Saldo", SummaryType.Sum, New SummarySaldo(DirectCast(ugDetalle.DataSource, DataTable)), Me.ugDetalle.DisplayLayout.Bands(0).Columns("saldo"), SummaryPosition.UseSummaryPositionColumn, Me.ugDetalle.DisplayLayout.Bands(0).Columns("saldo1"))
            summary4.DisplayFormat = "Total Recibo: {0:N2}"
            summary4.Appearance.TextHAlign = HAlign.Left
         End If


         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString("#,##0") & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub CargarColumnasASumar()
      If Not Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Exists("Haberes") Then
         '  Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed

         Me.ugDetalle.DisplayLayout.Override.SummaryValueAppearance.BackColor = Color.MediumSeaGreen

         Dim columnToSummarize1 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("Haberes")
         Dim summary1 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("Haberes", SummaryType.Sum, columnToSummarize1)
         summary1.DisplayFormat = "{0:N2}"
         summary1.Appearance.TextHAlign = HAlign.Right

         Dim columnToSummarize2 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("Deducciones")
         Dim summary2 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("Deducciones", SummaryType.Sum, columnToSummarize2)
         summary2.DisplayFormat = "{0:N2}"
         summary2.Appearance.TextHAlign = HAlign.Right

         'Dim columnToSummarize3 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("Saldo")
         'Dim summary3 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("Saldo", SummaryType.Sum, columnToSummarize3)
         'summary3.DisplayFormat = "Total a Cobrar:  {0:N2}"
         'summary3.Appearance.TextHAlign = HAlign.Left


         'Dim summary4 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("saldo", SummaryType.Custom, New SummarySaldo(DirectCast(ugDetalle.DataSource, DataTable)), Me.ugDetalle.DisplayLayout.Bands(0).Columns("saldo"), SummaryPosition.UseSummaryPositionColumn, Me.ugDetalle.DisplayLayout.Bands(0).Columns("saldo1"))
         'summary4.DisplayFormat = "Total a Cobrar:  {0:N2}"
         'summary4.Appearance.TextHAlign = HAlign.Left

         Me.ugDetalle.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales: "
         Me.ugDetalle.DisplayLayout.Bands(0).Override.GroupByRowDescriptionMask = "[Caption]: [value]"

      End If
   End Sub

   Public Class SummarySaldo
      Implements ICustomSummaryCalculator
      Public Property dt() As DataTable

      Public Sub New(dt As DataTable)
         _dt = dt
      End Sub

      Public Sub AggregateCustomSummary(summarySettings As SummarySettings, row As UltraGridRow) Implements ICustomSummaryCalculator.AggregateCustomSummary

      End Sub

      Public Sub BeginCustomSummary(summarySettings As SummarySettings, rows As RowsCollection) Implements ICustomSummaryCalculator.BeginCustomSummary

      End Sub

      Public Function EndCustomSummary(summarySettings As SummarySettings, rows As RowsCollection) As Object Implements ICustomSummaryCalculator.EndCustomSummary
         If dt.Rows.Count > 0 Then
            Return dt.Rows(dt.Rows.Count - 1)("saldo")
         End If
         Return 0
      End Function
   End Class


   Private Sub CargarDatosConcepto(ByVal dr As DataGridViewRow)

      Me.bscNombreConcepto.Text = dr.Cells("NombreConcepto").Value.ToString()
      Me.bscCodigoConcepto.Text = dr.Cells("CodigoConcepto").Value.ToString()
      Me.bscCodigoConcepto.Tag = dr.Cells("idConcepto").Value.ToString()
      Me.bscNombreConcepto.Enabled = False
      Me.bscCodigoConcepto.Enabled = False

   End Sub
   Private Sub bscCodigoConcepto_BuscadorClick() Handles bscCodigoConcepto.BuscadorClick

      Dim NroDoc As Integer = -1

      Try
         Me._publicos.PreparaGrillaSueldosConceptos(Me.bscCodigoConcepto)
         Dim oConceptos As Reglas.SueldosConceptos = New Reglas.SueldosConceptos
         If Me.bscCodigoConcepto.Text.Trim.Length > 0 Then
            NroDoc = Integer.Parse(Me.bscCodigoConcepto.Text.Trim())
         End If

         Dim Aguinaldo As Boolean = False
         If Me.RadioModoAguinaldo.Checked = True Then
            Aguinaldo = True
         End If

         Me.bscCodigoConcepto.Datos = oConceptos.GetPorCodigo(NroDoc.ToString(), Aguinaldo)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoConcepto_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoConcepto.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosConcepto(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombreConcepto_BuscadorClick() Handles bscNombreConcepto.BuscadorClick
      Try
         Me._publicos.PreparaGrillaSueldosConceptos(Me.bscNombreConcepto)
         Dim oClientes As Reglas.SueldosConceptos = New Reglas.SueldosConceptos

         Dim Aguinaldo As Boolean = False
         If Me.RadioModoAguinaldo.Checked = True Then
            Aguinaldo = True
         End If

         Me.bscNombreConcepto.Datos = oClientes.GetPorNombre(Me.bscNombreConcepto.Text.Trim(), Aguinaldo)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombreConcepto_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscNombreConcepto.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosConcepto(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub


#End Region


End Class