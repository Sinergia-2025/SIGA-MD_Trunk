#Region "Option / Imports"
Option Explicit On
Option Strict On
Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Documents.Excel
Imports Infragistics.Documents.Reports.Report
Imports Infragistics.Documents.Reports.Report.Section
#End Region
Public Class RevertirPasajeMovimientos

#Region "Campos"

   Private _publicos As Publicos
   Private _tit As Dictionary(Of String, String) = New Dictionary(Of String, String)()
   Private _cache As Reglas.BusquedasCacheadas

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos

         Me._publicos.CargaComboTiposComprobantes(Me.cmbTiposComprobantes, False, "COMPRAS", "INGRESOS")

         Me.CargarColumnasASumar()
         Me.UltraGridPrintDocument1.DocumentName = Me.Text

         _tit = GetColumnasVisiblesGrilla(ugDetalle)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub InfLiquidacionDetallada_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
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

         Dim Filtros As String = CargarFiltrosImpresion()
         Dim Titulo As String = Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Filtros

         Me.UltraPrintPreviewDialog1.Document = Me.UltraGridPrintDocument1
         Me.UltraGridPrintDocument1.Header.TextCenter = Titulo
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.Bold = DefaultableBoolean.True
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.SizeInPoints = 12
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 40
         Me.UltraGridPrintDocument1.DefaultPageSettings.Landscape = True
         'Me.UltraGridPrintDocument1.Footer.TextLeft = "Sucursal: " + actual.Sucursal.Nombre
         'Me.UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + Date.Today.ToString("dd/MM/yyyy")
         Me.UltraGridPrintDocument1.Footer.TextLeft = "Impreso: " + Date.Today.ToString("dd/MM/yyyy")

         Me.UltraPrintPreviewDialog1.ShowDialog()
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

   Private Sub UltraGridPrintDocument1_PagePrinting(ByVal sender As System.Object, ByVal e As Infragistics.Win.Printing.PagePrintingEventArgs) Handles UltraGridPrintDocument1.PagePrinting
      Me.UltraGridPrintDocument1.Footer.TextRight = "Página: " + Me.UltraGridPrintDocument1.PageNumber.ToString()
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub chbConcepto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbConcepto.CheckedChanged

      Me.bscIdConcepto.Permitido = Me.chbConcepto.Checked
      Me.bscNombreConcepto.Permitido = Me.chbConcepto.Checked

      'Cuando quito el check del Concepto, limpio el Concepto seleccionado (hipoteticamente)
      If Not Me.chbConcepto.Checked Then
         Me.bscIdConcepto.Text = String.Empty
         Me.bscNombreConcepto.Text = String.Empty
      End If

      Me.bscIdConcepto.Focus()

   End Sub

   Private Sub bscIdConcepto_BuscadorClick() Handles bscIdConcepto.BuscadorClick

      If Not Me.chbConcepto.Checked Then Exit Sub

      Try
         Me._publicos.PreparaGrillaConceptos(Me.bscIdConcepto)

         Dim oConceptos As Eniac.Reglas.Conceptos = New Eniac.Reglas.Conceptos()

         Dim bus As Eniac.Entidades.Buscar = New Eniac.Entidades.Buscar()
         bus.Columna = Eniac.Entidades.Concepto.Columnas.IdConcepto.ToString()
         bus.Valor = Me.bscIdConcepto.Text.Trim()

         Me.bscIdConcepto.Datos = oConceptos.Buscar(bus)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscIdConcepto_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscIdConcepto.BuscadorSeleccion

      If Not Me.chbConcepto.Checked Then Exit Sub

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

      If Not Me.chbConcepto.Checked Then Exit Sub

      Try
         Me._publicos.PreparaGrillaConceptos(Me.bscNombreConcepto)

         Dim oConceptos As Eniac.Reglas.Conceptos = New Eniac.Reglas.Conceptos()

         Dim bus As Eniac.Entidades.Buscar = New Eniac.Entidades.Buscar()
         bus.Columna = Eniac.Entidades.Concepto.Columnas.NombreConcepto.ToString()
         bus.Valor = Me.bscNombreConcepto.Text.Trim()

         Me.bscNombreConcepto.Datos = oConceptos.Buscar(bus)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscNombreConcepto_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscNombreConcepto.BuscadorSeleccion

      If Not Me.chbConcepto.Checked Then Exit Sub

      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosConcepto(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbProveedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbProveedor.CheckedChanged

      Me.bscCodigoProveedor.Permitido = Me.chbProveedor.Checked
      Me.bscProveedor.Permitido = Me.chbProveedor.Checked

      Me.bscCodigoProveedor.Text = String.Empty
      Me.bscProveedor.Text = String.Empty

      Me.bscCodigoProveedor.Focus()

   End Sub

   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      Dim codigoProveedor As Long = -1
      Try
         Me._publicos.PreparaGrillaProveedores(Me.bscCodigoProveedor)
         Dim oProveedores As Eniac.Reglas.Proveedores = New Eniac.Reglas.Proveedores
         If Me.bscCodigoProveedor.Text.Trim.Length > 0 Then
            codigoProveedor = Long.Parse(Me.bscCodigoProveedor.Text.Trim())
         End If
         Me.bscCodigoProveedor.Datos = oProveedores.GetFiltradoPorCodigo(codigoProveedor)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoProveedor_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
            btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProveedor_BuscadorClick() Handles bscProveedor.BuscadorClick
      Try
         Dim oProveedor As Eniac.Reglas.Proveedores = New Eniac.Reglas.Proveedores
         Me._publicos.PreparaGrillaProveedores(Me.bscProveedor)
         Me.bscProveedor.Datos = oProveedor.GetFiltradoPorNombre(Me.bscProveedor.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProveedor_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
            btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub cboComprobante_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboComprobante.CheckedChanged

      Me.cmbTiposComprobantes.Enabled = Me.cboComprobante.Checked
      Me.txtLetra.Enabled = Me.cboComprobante.Checked
      Me.txtEmisorComprobante.Enabled = Me.cboComprobante.Checked
      Me.txtNumeroComprobante.Enabled = Me.cboComprobante.Checked

      If Me.cboComprobante.Checked Then
         Me.cmbTiposComprobantes.SelectedIndex = 0
      Else
         Me.cmbTiposComprobantes.SelectedIndex = -1
      End If

      Me.txtLetra.Text = String.Empty
      Me.txtEmisorComprobante.Text = String.Empty
      Me.txtNumeroComprobante.Text = String.Empty

      Me.cmbTiposComprobantes.Focus()

   End Sub

   Private Sub txtLetra_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLetra.LostFocus
      Me.txtLetra.Text = Me.txtLetra.Text.ToUpper()
   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         If Me.chbConcepto.Checked And Not Me.bscIdConcepto.Selecciono And Not Me.bscNombreConcepto.Selecciono Then
            MessageBox.Show("ATENCION: NO seleccionó un Producto aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscIdConcepto.Focus()
            Exit Sub
         End If

         If Me.chbProveedor.Checked And Not Me.bscCodigoProveedor.Selecciono And Not Me.bscProveedor.Selecciono Then
            MessageBox.Show("ATENCION: NO seleccionó un Proveedor aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoProveedor.Focus()
            Exit Sub
         End If

         Me.chkExpandAll.Enabled = True
         Me.chkExpandAll.Checked = False

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         Me.chkExpandAll.Checked = False
         Me.chkExpandAll.Checked = True

         If ugDetalle.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("NO hay registros que cumplan con la seleccion !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
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
      If chkExpandAll.Checked Then
         Me.ugDetalle.Rows.ExpandAll(True)
      Else
         Me.ugDetalle.Rows.CollapseAll(True)
      End If
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarColumnasASumar()
      With Me.ugDetalle.DisplayLayout.Bands(0)
         Dim summary As SummarySettings = .Summaries.Add("ImporteALiquidar", SummaryType.Sum, .Columns("ImporteALiquidar"))
         summary.DisplayFormat = "{0:N2}"
         summary.Appearance.TextHAlign = HAlign.Right
         .SummaryFooterCaption = "Total:"
      End With
   End Sub

   Private Sub CargarDatosConcepto(ByVal dr As DataGridViewRow)

      Me.bscNombreConcepto.Text = dr.Cells("NombreConcepto").Value.ToString()
      Me.bscNombreConcepto.Permitido = False
      Me.bscIdConcepto.Text = dr.Cells("IdConcepto").Value.ToString()
      Me.bscIdConcepto.Permitido = False

   End Sub

   Private Sub CargarDatosProveedor(ByVal dr As DataGridViewRow)

      Me.bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
      Me.bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()

      Me.bscProveedor.Tag = dr.Cells("IdProveedor").Value.ToString
      Me.bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString

      Me.bscProveedor.Permitido = False
      Me.bscCodigoProveedor.Permitido = False

   End Sub

   Protected Sub RefrescarDatosGrilla()

      Me.chbConcepto.Checked = False
      Me.chbProveedor.Checked = False

      Me.cboComprobante.Checked = False

      Me.chkExpandAll.Checked = False
      Me.chkExpandAll.Enabled = False

      Me.chbTodos.Checked = False

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      'Me.txtTotal.Text = "0.00"

      Me.chbConcepto.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()

      'Dim Total As Decimal = 0

      Dim IdConcepto As Integer = 0

      Dim IdProveedor As Long = 0

      Dim IdTipoComprobante As String = String.Empty
      Dim Letra As String = String.Empty
      Dim EmisorComprobante As Integer = 0
      Dim NumeroComprobante As Long = 0

      Try

         '' '' '' ''Dim UltimaLiquidacion As Integer
         '' '' '' ''UltimaLiquidacion = New Reglas.Liquidaciones().GetUltimaLiquidacion(actual.Sucursal.IdSucursal, CInt(Me.cmbTiposComprobantes.SelectedValue.ToString()))

         '' '' '' ''If UltimaLiquidacion > 1 And Integer.Parse(Me.dtpPeriodo.Value.ToString("yyyyMM")) <= UltimaLiquidacion Then
         '' '' '' ''   PeriodoLiquidacion = Integer.Parse(Me.dtpPeriodo.Value.ToString("yyyyMM"))
         '' '' '' ''End If

         If Me.chbConcepto.Checked Then
            IdConcepto = Integer.Parse(Me.bscIdConcepto.Text)
         End If

         If Me.chbProveedor.Checked Then
            IdProveedor = Long.Parse(Me.bscCodigoProveedor.Tag.ToString())
         End If

         If Me.cmbTiposComprobantes.SelectedIndex >= 0 Then
            IdTipoComprobante = Me.cmbTiposComprobantes.SelectedValue.ToString()
         End If

         If Not String.IsNullOrEmpty(Me.txtLetra.Text) Then
            Letra = Me.txtLetra.Text
         End If

         If Not Integer.TryParse(Me.txtEmisorComprobante.Text, EmisorComprobante) Then
            EmisorComprobante = 0
         End If

         If Not Long.TryParse(Me.txtNumeroComprobante.Text, NumeroComprobante) Then
            NumeroComprobante = 0
         End If

         Dim dtDetalle As DataTable ', dt As DataTable, drCl As DataRow

         dtDetalle = ObtieneDatosParaGrilla(IdConcepto,
                                            IdProveedor,
                                            IdTipoComprobante,
                                            Letra,
                                            EmisorComprobante,
                                            NumeroComprobante)

         ProcesaDT(dtDetalle)

         'dt = Me.CrearDT()

         'For Each dr As DataRow In dtDetalle.Rows
         '   AddRow(dt, dr)
         'Next

         Me.ugDetalle.DataSource = dtDetalle
         AjustarColumnasGrilla(ugDetalle, _tit)
         'FormatearGrilla()

         Me.tssRegistros.Text = dtDetalle.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Protected Function ProcesaDT(dt As DataTable) As DataTable

      dt.Columns.Add("seleccionado", GetType(Boolean))
      dt.Columns("seleccionado").Caption = String.Empty

      For Each dr As DataRow In dt.Rows
         dr("seleccionado") = False
      Next

      Return dt
   End Function

   'Protected Sub FormatearGrilla()

   '   ugDetalle.DisplayLayout.Override.CellClickAction = CellClickAction.Default
   '   ugDetalle.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.True

   '   With ugDetalle.DisplayLayout.Bands(0)
   '      For Each col As UltraGridColumn In .Columns
   '         col.CellActivation = Activation.ActivateOnly
   '      Next

   '      .Columns("seleccionado").Header.VisiblePosition = 0
   '      .Columns("seleccionado").Header.CheckBoxVisibility = HeaderCheckBoxVisibility.WhenUsingCheckEditor
   '      .Columns("seleccionado").Header.CheckBoxSynchronization = HeaderCheckBoxSynchronization.Band
   '      .Columns("seleccionado").CellActivation = Activation.AllowEdit
   '      .Columns("seleccionado").Hidden = False

   '      .Columns("Orden").Hidden = True
   '      .Columns("OrdenLiquidacion").Hidden = True

   '      .Columns("NombreProveedor").FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains

   '   End With

   '   chkExpandAll.Checked = True

   'End Sub

   Protected Function ObtieneDatosParaGrilla(IdConcepto As Integer,
                                                         IdProveedor As Long,
                                                         IdTipoComprobante As String,
                                                         Letra As String,
                                                         EmisorComprobante As Integer,
                                                         NumeroComprobante As Long) As DataTable
      Dim oExpensasAdic As Reglas.ComprasLiquidacion = New Reglas.ComprasLiquidacion()
      Return oExpensasAdic.GetLiquidacionDetallada(0,
                                                   IdConcepto,
                                                   IdProveedor,
                                                   IdTipoComprobante,
                                                   Letra,
                                                   EmisorComprobante,
                                                   NumeroComprobante)
   End Function

   Private Function CargarFiltrosImpresion() As String
      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      With filtro
         '' '' '' ''.AppendFormat("Periodo: {0:MM/yyyy} - ", dtpPeriodo.Value)

         If Me.chbConcepto.Checked Then
            .AppendFormat("Concepto: {0} - {1} - ", Me.bscIdConcepto.Text, Me.bscNombreConcepto.Text)
         End If
         If Me.chbProveedor.Checked Then
            .AppendFormat("Proveedor: {0} - {1} - ", Me.bscCodigoProveedor.Text.Trim(), Me.bscProveedor.Text.Trim())
         End If

         If Me.cmbTiposComprobantes.SelectedIndex >= 0 Then
            .AppendFormat("Comprobante: {0} {1}", Me.cmbTiposComprobantes.Text, txtLetra.Text)

            If IsNumeric(Me.txtEmisorComprobante.Text) Then
               .AppendFormat("Emisor: {0:0000}", Me.txtEmisorComprobante.Text)
            End If

            If IsNumeric(Me.txtNumeroComprobante.Text) Then
               .AppendFormat("Numero: {0:00000000}", Me.txtNumeroComprobante.Text)
            End If

         End If
      End With

      Return filtro.ToString.Trim().Trim("-"c).Trim()
   End Function


#End Region

   Private Sub AddRows(rows As DataRow(), movimientos As List(Of Entidades.ComprasLiquidacion))
      Dim oMovLiq As Entidades.ComprasLiquidacion

      For Each dr As DataRow In rows
         oMovLiq = New Entidades.ComprasLiquidacion()
         With oMovLiq
            .Sucursal = Integer.Parse(dr("IdSucursal").ToString())
            .TipoComprobante = _cache.BuscaTipoComprobante(dr("IdTipoComprobante").ToString())
            .Letra = dr("Letra").ToString()
            .CentroEmisor = Short.Parse(dr("CentroEmisor").ToString())
            .NumeroComprobante = Long.Parse(dr("NumeroComprobante").ToString())
            '.Proveedor.TipoDocProveedor = dr.Cells("TipoDocProveedor").Value.ToString()
            .Proveedor = New Entidades.Proveedor()
            .Proveedor.IdProveedor = Long.Parse(dr("idProveedor").ToString())
            .Orden = Long.Parse(dr("Orden").ToString())
            .OrdenLiquidacion = Long.Parse(dr("OrdenLiquidacion").ToString())
            .IdConcepto = Integer.Parse(dr("IdConcepto").ToString())
            .ImporteALiquidar = Decimal.Parse(dr("ImporteALiquidar").ToString())
         End With
         movimientos.Add(oMovLiq)

      Next
   End Sub

   Private Sub tsbRevertir_Click(sender As Object, e As EventArgs) Handles tsbRevertir.Click
      If Not TypeOf (ugDetalle.DataSource) Is DataTable Then Exit Sub
      Try
         Dim movimientos As List(Of Entidades.ComprasLiquidacion) = New List(Of Entidades.ComprasLiquidacion)()

         _cache = New Reglas.BusquedasCacheadas()

         ugDetalle.UpdateData()

         AddRows(DirectCast(ugDetalle.DataSource, DataTable).Select("seleccionado"), movimientos)

         If movimientos.Count = 0 Then
            MessageBox.Show("Debe seleccionar al menos un pasaje de movimiento para poder revertir.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Dim oMovimientosLiquidacion As Reglas.ComprasLiquidacion = New Reglas.ComprasLiquidacion()
         oMovimientosLiquidacion.RevierteMovimientosLiquidaciones(movimientos)

         MessageBox.Show("La Reversión del Pasaje de Movimientos se realizo con éxito!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

         RefrescarDatosGrilla()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

#Region "Marcar/Desmarcar Todos"
   Private Sub chbTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chbTodos.CheckedChanged
      If Not TypeOf (ugDetalle.DataSource) Is DataTable Then Exit Sub
      Try
         Me.Cursor = Cursors.WaitCursor
         For Each dr As DataRow In DirectCast(ugDetalle.DataSource, DataTable).Rows
            dr("seleccionado") = Me.chbTodos.Checked
         Next
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
#End Region
End Class