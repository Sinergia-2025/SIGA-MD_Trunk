Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinDataSource

Public Class ConsultarOrdenesProduccion

#Region "Campos"

   Private _publicos As Publicos
   Dim dtsMaster_detalle As DataSet
   'Dim primeraCarga As Boolean = True
   Dim dtDetalle As DataTable
   Dim dtOrdenProduccionDetalle As DataTable
   Dim dtOrdenProduccionDetalleComprobante As DataTable

   Private _tit As Dictionary(Of String, String) = New Dictionary(Of String, String)()
   Private _tit1 As Dictionary(Of String, String) = New Dictionary(Of String, String)()
   Private _tit2 As Dictionary(Of String, String) = New Dictionary(Of String, String)()

   Private IdUsuario As String = actual.Nombre

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try
         _tit = New Dictionary(Of String, String)()
         For Each col As UltraGridColumn In ugDetalle.DisplayLayout.Bands("Cabecera").Columns
            If Not col.Hidden Then
               _tit.Add(col.Key, String.Empty)
            End If
         Next

         _tit1 = New Dictionary(Of String, String)()
         For Each col As UltraGridColumn In ugDetalle.DisplayLayout.Bands("Detalle").Columns
            If Not col.Hidden Then
               _tit1.Add(col.Key, String.Empty)
            End If
         Next

         _tit2 = New Dictionary(Of String, String)()
         For Each col As UltraGridColumn In ugDetalle.DisplayLayout.Bands("Comprobante").Columns
            If Not col.Hidden Then
               _tit2.Add(col.Key, String.Empty)
            End If
         Next

         Me._publicos = New Publicos()

         Me._publicos.CargaComboEstadosOrdenesProduccion(cmbEstados, True, True, True, True, String.Empty)

         'Me.cmbEstados.Items.Insert(0, "TODOS")
         'Me.cmbEstados.Items.Insert(1, "SOLO PENDIENTES")
         'Me.cmbEstados.Items.Insert(2, "PENDIENTE")
         'Me.cmbEstados.Items.Insert(3, "EN PROCESO")
         'Me.cmbEstados.Items.Insert(4, "ANULADO")
         'Me.cmbEstados.Items.Insert(5, "FINALIZADO")
         Me.cmbEstados.SelectedIndex = 1

         chbFecha.Checked = True
         Me.dtpDesde.Value = Date.Today
         Me.dtpHasta.Value = Date.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)

         Me._publicos.CargaComboUsuarios(Me.cmbUsuario)

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
         'Me.ugDetalle.DisplayLayout.Bands(0).Columns("NombreVendedor").Hidden = (Me.cmbVendedor.Items.Count = 1)

         '  Me.CargarColumnasASumar()

         '-- REG-41940.- --------------------------------------------------------------------------
         dtpDesdePlanMaestro.Value = DateTime.Today
         dtpHastaPlanMaestro.Value = DateTime.Today.UltimoSegundoDelDia()
         '-----------------------------------------------------------------------------------------

         Me.PreferenciasLeer(ugDetalle, tsbPreferencias)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub ConsultarPedidos_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
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

         Dim Filtros As String = String.Empty

         Filtros = "Filtros: Estado: " & Me.cmbEstados.Text

         If Me.chbFecha.Checked Then
            Filtros = Filtros & " / Rango de Fechas: desde el " & Me.dtpDesde.Text & " hasta el " & Me.dtpHasta.Text
         End If

         If Me.chbCliente.Checked Then
            Filtros = Filtros & " / Cliente: " & Me.bscCodigoCliente.Text.Trim() & " - " & Me.bscCliente.Text.Trim()
         End If

         If Me.cmbUsuario.Enabled Then
            Filtros = Filtros & " / Usuario: " & Me.cmbUsuario.SelectedValue.ToString()
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

   Private Sub chbFecha_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbFecha.CheckedChanged

      Me.chkMesCompleto.Enabled = Me.chbFecha.Checked
      Me.dtpDesde.Enabled = Me.chbFecha.Checked
      Me.dtpHasta.Enabled = Me.chbFecha.Checked

      If Not Me.chbFecha.Checked Then
         Me.chkMesCompleto.Checked = False
         Me.dtpDesde.Value = DateTime.Today
         Me.dtpHasta.Value = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
      Else
         Me.dtpDesde.Focus()
      End If

   End Sub

   Private Sub chkMesCompleto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMesCompleto.CheckedChanged

      Dim FechaTemp As Date

      Try

         If chkMesCompleto.Checked Then

            FechaTemp = New Date(Me.dtpDesde.Value.Year, Me.dtpDesde.Value.Month, 1)
            Me.dtpDesde.Value = FechaTemp

            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 Segundo.
            FechaTemp = Me.dtpDesde.Value.AddMonths(1).AddSeconds(-1)
            dtpHasta.Value = FechaTemp

         End If

         Me.dtpDesde.Enabled = Not Me.chkMesCompleto.Checked
         Me.dtpHasta.Enabled = Not Me.chkMesCompleto.Checked

      Catch ex As Exception

         chkMesCompleto.Checked = False

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

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick, bscCodigoCliente.BuscadorClick
      Dim codigoCliente As Long = -1
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscCodigoCliente)
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
         Me._publicos.PreparaGrillaClientes(Me.bscCliente)
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

   Private Sub chbUsuario_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbUsuario.CheckedChanged
      Try
         Me.cmbUsuario.Enabled = Me.chbUsuario.Checked

         If Not Me.chbUsuario.Checked Then
            Me.cmbUsuario.SelectedIndex = -1
         Else
            If Me.cmbUsuario.Items.Count > 0 Then
               Me.cmbUsuario.SelectedIndex = 0
            End If
         End If

         Me.cmbUsuario.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub chbIdPedido_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbIdPedido.CheckedChanged

      Me.txtIdPedido.Enabled = Me.chbIdPedido.Checked

      If Not Me.chbIdPedido.Checked Then
         Me.txtIdPedido.Text = String.Empty
      Else
         Me.txtIdPedido.Focus()
      End If

   End Sub

   Private Sub chbVendedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbVendedor.CheckedChanged

      Me.cmbVendedor.Enabled = Me.chbVendedor.Checked

      If Not Me.chbVendedor.Checked Then
         Me.cmbVendedor.SelectedIndex = -1
      Else
         If Me.cmbVendedor.Items.Count > 0 Then
            Me.cmbVendedor.SelectedIndex = 0
         End If
      End If

      Me.cmbVendedor.Focus()

   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         If Me.chbVendedor.Checked And Me.cmbVendedor.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Debe seleccionar un VENDEDOR.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbVendedor.Focus()
            Exit Sub
         End If

         If Me.chbCliente.Checked And Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
            MessageBox.Show("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If

         If Me.chbIdPedido.Checked AndAlso Integer.Parse("0" & Me.txtIdPedido.Text) = 0 Then
            MessageBox.Show("ATENCION: NO Ingresó un Número de Pedido aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtIdPedido.Focus()
            Exit Sub
         End If

         Me.chkExpandAll.Enabled = True
         Me.chkExpandAll.Checked = False

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

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
      If Me.chkExpandAll.Checked Then
         Me.ugDetalle.Rows.ExpandAll(True)
      Else
         Me.ugDetalle.Rows.CollapseAll(True)
      End If
   End Sub

   Private Sub ugDetalle_ClickCellButton(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles ugDetalle.ClickCellButton
      Try

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub
         Dim reg As Reglas.OrdenesProduccion = New Reglas.OrdenesProduccion
         Dim oReportePedido As New Entidades.Pedido
         'Dim dtsPedido As New dtsPedido

         If e.Cell.Column.Key = "ImprimirComp" Then

            Dim oVentas As Reglas.Ventas = New Reglas.Ventas()

            Dim letra As String = String.Empty
            Dim IdTipoComprobante As String = String.Empty
            Dim CentroEmisor As Short = 0
            Dim NumeroComprobante As Long = 0


            'Dim rowTypes As GridRowType = GridRowType.DataRow
            'Dim band As UltraGridBand = Me.ugDetalle.DisplayLayout.Bands(1)
            'Dim enumerator As IEnumerable = band.GetRowEnumerator(rowTypes)
            'Dim row As UltraGridRow
            'For Each row In enumerator
            'If row.Index = e.Cell.Row.Index Then
            If String.IsNullOrWhiteSpace(e.Cell.Row.Cells("letraFact").Value.ToString()) Then
               MessageBox.Show("Esta linea de Pedido NO Tiene Comprobante Relacionado.", Me.Text)
               Exit Sub
            End If
            letra = e.Cell.Row.Cells("letraFact").Value.ToString
            IdTipoComprobante = e.Cell.Row.Cells("IdTipoComprobanteFact").Value.ToString
            CentroEmisor = Short.Parse(e.Cell.Row.Cells("CentroEmisorFact").Value.ToString)
            NumeroComprobante = Long.Parse(e.Cell.Row.Cells("NumeroComprobanteFact").Value.ToString)
            'Exit For
            'End If

            'Next

            Dim Comprobante As Entidades.Venta = oVentas.GetUna(actual.Sucursal.Id, _
                                                               IdTipoComprobante, _
                                                               letra, _
                                                               CentroEmisor, _
                                                               NumeroComprobante)

            Dim oImpr As Impresion = New Impresion(Comprobante)
            Dim ReporteEstandar As Boolean = True

            oImpr.ImprimirComprobanteNoFiscal(True, ReporteEstandar)

         End If

         If e.Cell.Column.Key = "ImprimirCab" Or e.Cell.Column.Key = "ImprimirCabConCantidad" Then
            Dim idTipoComprobante As String = e.Cell.Row.Cells(Entidades.OrdenProduccion.Columnas.IdTipoComprobante.ToString()).Value.ToString()
            Dim letra As String = e.Cell.Row.Cells(Entidades.OrdenProduccion.Columnas.Letra.ToString()).Value.ToString()
            Dim centroEmisor As Short = Short.Parse(e.Cell.Row.Cells(Entidades.OrdenProduccion.Columnas.CentroEmisor.ToString()).Value.ToString())
            Dim numeroOrdenProduccion As Long = Long.Parse(e.Cell.Row.Cells(Entidades.OrdenProduccion.Columnas.NumeroOrdenProduccion.ToString()).Value.ToString())

            Dim oOrdenProduccion As Entidades.OrdenProduccion = New Reglas.OrdenesProduccion().GetUno(actual.Sucursal.Id, idTipoComprobante, letra, centroEmisor, numeroOrdenProduccion)
            Dim impresion As ImpresionOrdenesProduccion = New ImpresionOrdenesProduccion()

            If e.Cell.Column.Header.Caption = "Ver" Then
               'Reporte = "Eniac.Win.PedidoV2.rdlc"
               impresion.ImprimirOrdenProduccion(oOrdenProduccion, True)
            Else
               'Reporte = "Eniac.Win.PedidoV2Detalle.rdlc"
               impresion.ImprimirOrdenProduccionDetallado(oOrdenProduccion, True)
            End If
         End If

         If e.Cell.Column.Key = "comp" Then

            Dim oVentas As Reglas.Ventas = New Reglas.Ventas()

            Dim letra As String = String.Empty
            Dim IdTipoComprobante As String = String.Empty
            Dim CentroEmisor As Short = 0
            Dim NumeroComprobante As Long = 0

            'Dim rowTypes As GridRowType = GridRowType.DataRow
            'Dim band As UltraGridBand = Me.ugDetalle.DisplayLayout.Bands(1)
            'Dim enumerator As IEnumerable = band.GetRowEnumerator(rowTypes)
            'Dim row As UltraGridRow

            'For Each row In enumerator
            'If row.Index = e.Cell.Row.Index Then
            If e.Cell.Row.Cells("letraFact").Value Is System.DBNull.Value Then
               MessageBox.Show("No hay comprobantes en esta linea para informar", Me.Text)
               Exit Sub
            End If
            letra = e.Cell.Row.Cells("letraFact").Value.ToString
            IdTipoComprobante = e.Cell.Row.Cells("IdTipoComprobanteFact").Value.ToString
            CentroEmisor = Short.Parse(e.Cell.Row.Cells("CentroEmisorFact").Value.ToString)
            NumeroComprobante = Long.Parse(e.Cell.Row.Cells("NumeroComprobanteFact").Value.ToString)
            'Exit For
            'End If
            'Next

            dtOrdenProduccionDetalleComprobante = reg.GetOrdenesProduccionDetalleComprobante(actual.Sucursal.Id, _
                                                                     IdTipoComprobante, _
                                                                     letra, _
                                                                     CentroEmisor, _
                                                                     NumeroComprobante)

            dtOrdenProduccionDetalleComprobante.TableName = "dtOrdenProduccionDetalleComp"

            DirectCast(Me.dtsMaster_detalle.Tables("dtOrdenProduccionDetalleComp"), DataTable).Rows.Clear()

            Me.dtsMaster_detalle.Merge(dtOrdenProduccionDetalleComprobante)
            '  Me.ugDetalle.SetDataBinding(dtsMaster_detalle, "datos.ConstEnum.ConstEnum4")

            ' Me.ugDetalle.DataSource = dtsMaster_detalle

            ' Me.ugDetalle.DataBind() ' = dtsMaster_detalle

            ' Exit Sub

         End If

      Catch ex As Exception
         Me.Cursor = Cursors.Default
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub ugDetalle_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles ugDetalle.InitializeLayout
      e.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.SummaryRow
      e.Layout.Override.SpecialRowSeparatorAppearance.BackColor = Color.FromArgb(218, 217, 241)
      e.Layout.Override.SpecialRowSeparatorHeight = 6
      e.Layout.Override.BorderStyleSpecialRowSeparator = UIElementBorderStyle.RaisedSoft
      e.Layout.ViewStyle = ViewStyle.MultiBand

      e.Layout.ViewStyleBand = ViewStyleBand.OutlookGroupBy

      For Each banda As UltraGridBand In e.Layout.Bands
         banda.HeaderVisible = True
         banda.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left
      Next

   End Sub

   Private Sub grdComprobante_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs)

      For Each banda As UltraGridBand In e.Layout.Bands
         banda.HeaderVisible = True
         banda.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left
      Next

   End Sub

#End Region

#Region "Metodos"

   'Me.ugDetalle.DisplayLayout.Override.SummaryValueAppearance.BackColor = Color.Yellow
   Private Sub CargarColumnasASumar()

      Dim columnToSummarize1 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("CantEstado")
      Dim summary1 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("CantEstado", SummaryType.Sum, columnToSummarize1)
      summary1.DisplayFormat = "{0:N2}"
      summary1.Appearance.TextHAlign = HAlign.Right

      Dim columnToSummarize2 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("cantPendiente")
      Dim summary2 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("cantPendiente", SummaryType.Sum, columnToSummarize2)
      summary2.DisplayFormat = "{0:N2}"
      summary2.Appearance.TextHAlign = HAlign.Right
      summary2.Appearance.BackColor = Color.LightCyan
      summary2.Appearance.FontData.Bold = DefaultableBoolean.True

      Me.ugDetalle.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales:"

      Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed

   End Sub

   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False

   End Sub

   Private Sub RefrescarDatosGrilla()
      Me.cmbEstados.SelectedIndex = 1

      Me.chbFecha.Checked = False
      Me.chbCliente.Checked = False
      Me.chbUsuario.Checked = False

      Me.chbIdPedido.Checked = False
      Me.chbOrdenCompra.Checked = False
      If IdUsuario = "" Then
         Me.chbVendedor.Checked = False
      End If

      Me.chkExpandAll.Checked = False
      Me.chkExpandAll.Enabled = False

      chbFecha.Checked = True

      If Me.ugDetalle.DataSource IsNot Nothing AndAlso TypeOf (ugDetalle.DataSource) Is DataSet Then
         DirectCast(Me.ugDetalle.DataSource, DataSet).Clear()
      End If

      Me.cmbEstados.Focus()
   End Sub

   Private Sub CargaGrillaDetalle()

      Dim oOrdenesProduccion As Reglas.OrdenesProduccion = New Reglas.OrdenesProduccion()

      Dim FechaDesde As Date = Nothing
      Dim FechaHasta As Date = Nothing

      Dim idProducto As String = String.Empty
      Dim IdMarca As Integer = 0
      Dim IdRubro As Integer = 0
      Dim idSubRubro As Integer = 0
      Dim lote As String = String.Empty

      Dim IdPedido As Integer = -1
      Dim OrdenCompra As Long = 0
      Dim Tamanio As Decimal = 0

      Dim IdCliente As Long = 0

      Dim TipoComprobante As String = String.Empty

      Dim IdVendedor As Integer = 0

      Dim IdFormaDePago As Integer = 0
      Dim IdUsuario As String = String.Empty
      Dim Cantidad As String = String.Empty

      Dim idPed_str As String = String.Empty

      If Me.chbFecha.Checked Then
         FechaDesde = Me.dtpDesde.Value
         FechaHasta = Me.dtpHasta.Value
      End If

      If Me.chbCliente.Checked Then
         IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
      End If

      If Me.cmbUsuario.Enabled Then
         IdUsuario = Me.cmbUsuario.SelectedValue.ToString()
      End If

      If Me.chbIdPedido.Checked Then
         IdPedido = Integer.Parse(Me.txtIdPedido.Text)
      End If

      If Me.chbOrdenCompra.Checked Then
         OrdenCompra = Long.Parse(Me.txtOrdenCompra.Text.ToString())
      End If

      If Me.chbVendedor.Checked Then
         IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado
      End If

      Dim nroPlanMaestro = If(chbPlanMaestro.Checked, txtPlanMaestro.ValorNumericoPorDefecto(0I), 0I)
      Dim fechaDesdePlan = dtpDesdePlanMaestro.Valor(chbFechaPlanMaestro)
      Dim fechaHastaPlan = dtpHastaPlanMaestro.Valor(chbFechaPlanMaestro)

      dtsMaster_detalle = New DataSet()

      dtDetalle = oOrdenesProduccion.OrdenesProduccionCabecera(actual.Sucursal.Id,
                                          Me.cmbEstados.Text,
                                          FechaDesde, FechaHasta,
                                          IdPedido,
                                          idProducto,
                                          IdMarca,
                                          IdRubro,
                                          lote,
                                          IdCliente,
                                          IdUsuario,
                                          Tamanio,
                                          IdVendedor,
                                          OrdenCompra, nroPlanMaestro, fechaDesdePlan, fechaHastaPlan)

      If dtDetalle.Rows.Count = 0 Then
         'If Me.ugDetalle.Rows.Count > 0 Then Me.ugDetalle.DataSource = Nothing ' (Me.ugDetalle.DataSource, DataSet).Tables.Clear()
         If TypeOf (ugDetalle.DataSource) Is DataSet Then DirectCast(ugDetalle.DataSource, DataSet).Clear()
         If TypeOf (ugDetalle.DataSource) Is DataTable Then DirectCast(ugDetalle.DataSource, DataTable).Clear()
         'End If
         Exit Sub
      End If

      dtDetalle.TableName = "Cabecera"

      dtsMaster_detalle.Tables.Add(dtDetalle)

      dtOrdenProduccionDetalle = oOrdenesProduccion.GetOrdenesProduccionDetalladoXEstadosTodos(actual.Sucursal.Id,
                                                Me.cmbEstados.Text,
                                                FechaDesde, FechaHasta,
                                                IdPedido,
                                                idProducto,
                                                IdMarca,
                                                IdRubro,
                                                lote,
                                                IdCliente,
                                                IdUsuario,
                                                Tamanio,
                                                IdVendedor,
                                                OrdenCompra, nroPlanMaestro, fechaDesdePlan, fechaHastaPlan)

      dtOrdenProduccionDetalle.TableName = "detalle"
      dtsMaster_detalle.Tables.Add(dtOrdenProduccionDetalle)

      Dim ColumnasPadre(4) As DataColumn
      Dim ColumnasHijo(4) As DataColumn
      ColumnasPadre(0) = dtsMaster_detalle.Tables("Cabecera").Columns("IdSucursal")
      ColumnasPadre(1) = dtsMaster_detalle.Tables("Cabecera").Columns("IdTipoComprobante")
      ColumnasPadre(2) = dtsMaster_detalle.Tables("Cabecera").Columns("CentroEmisor")
      ColumnasPadre(3) = dtsMaster_detalle.Tables("Cabecera").Columns("Letra")
      ColumnasPadre(4) = dtsMaster_detalle.Tables("Cabecera").Columns("NumeroOrdenProduccion")
      ColumnasHijo(0) = dtsMaster_detalle.Tables("detalle").Columns("IdSucursal")
      ColumnasHijo(1) = dtsMaster_detalle.Tables("detalle").Columns("IdTipoComprobante")
      ColumnasHijo(2) = dtsMaster_detalle.Tables("detalle").Columns("CentroEmisor")
      ColumnasHijo(3) = dtsMaster_detalle.Tables("detalle").Columns("Letra")
      ColumnasHijo(4) = dtsMaster_detalle.Tables("detalle").Columns("NumeroOrdenProduccion")

      Dim relConstEnum As DataRelation = New DataRelation("Detalle", ColumnasPadre, ColumnasHijo, True)
      dtsMaster_detalle.Relations.Add(relConstEnum)

      dtOrdenProduccionDetalleComprobante = oOrdenesProduccion.GetOrdenesProduccionDetalleComprobante(actual.Sucursal.Id, _
                                                                         Me.cmbEstados.Text, _
                                                                         FechaDesde, FechaHasta, _
                                                                         IdPedido, _
                                                                         idProducto, _
                                                                         IdMarca, _
                                                                         IdRubro, _
                                                                         lote, _
                                                                         IdCliente, _
                                                                         IdUsuario, _
                                                                         Tamanio, _
                                                                         IdVendedor,
                                                                         OrdenCompra)

      dtOrdenProduccionDetalleComprobante.TableName = "dtPedidoDetalleComp"
      dtsMaster_detalle.Tables.Add(dtOrdenProduccionDetalleComprobante)

      Dim ColumnasPadre1(7) As DataColumn
      Dim ColumnasHijo1(7) As DataColumn
      ColumnasPadre1(0) = dtsMaster_detalle.Tables("detalle").Columns("IdSucursal")
      ColumnasPadre1(1) = dtsMaster_detalle.Tables("detalle").Columns("IdTipoComprobante")
      ColumnasPadre1(2) = dtsMaster_detalle.Tables("detalle").Columns("CentroEmisor")
      ColumnasPadre1(3) = dtsMaster_detalle.Tables("detalle").Columns("Letra")
      ColumnasPadre1(4) = dtsMaster_detalle.Tables("detalle").Columns("NumeroOrdenProduccion")
      ColumnasPadre1(5) = dtsMaster_detalle.Tables("detalle").Columns("IdProducto")
      ColumnasPadre1(6) = dtsMaster_detalle.Tables("detalle").Columns("FechaEstado")
      ColumnasPadre1(7) = dtsMaster_detalle.Tables("detalle").Columns("Orden")

      ColumnasHijo1(0) = dtsMaster_detalle.Tables("dtPedidoDetalleComp").Columns("IdSucursal")
      ColumnasHijo1(1) = dtsMaster_detalle.Tables("dtPedidoDetalleComp").Columns("IdTipoComprobanteP")
      ColumnasHijo1(2) = dtsMaster_detalle.Tables("dtPedidoDetalleComp").Columns("CentroEmisorP")
      ColumnasHijo1(3) = dtsMaster_detalle.Tables("dtPedidoDetalleComp").Columns("LetraP")
      ColumnasHijo1(4) = dtsMaster_detalle.Tables("dtPedidoDetalleComp").Columns("NumeroOrdenProduccion")
      ColumnasHijo1(5) = dtsMaster_detalle.Tables("dtPedidoDetalleComp").Columns("IdProducto")
      ColumnasHijo1(6) = dtsMaster_detalle.Tables("dtPedidoDetalleComp").Columns("FechaEstado")
      ColumnasHijo1(7) = dtsMaster_detalle.Tables("dtPedidoDetalleComp").Columns("Orden")

      relConstEnum = New DataRelation("Comprobante", ColumnasPadre1, ColumnasHijo1, False)
      dtsMaster_detalle.Relations.Add(relConstEnum)

      Me.ugDetalle.SetDataBinding(dtsMaster_detalle, "Cabecera")

      Me.ugDetalle.DataSource = dtsMaster_detalle

      If Not Me.ugDetalle.DisplayLayout.Bands(0).Columns.Exists("ImprimirCab") Then
         Me.ugDetalle.DisplayLayout.Bands(0).Columns.Add("ImprimirCab", "Ver").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
         Me.ugDetalle.DisplayLayout.Bands(0).Override.ButtonStyle = UIElementButtonStyle.Button3D
         Me.ugDetalle.DisplayLayout.Bands(0).Columns("ImprimirCab").ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
         Me.ugDetalle.DisplayLayout.Bands(0).Columns("ImprimirCab").Header.VisiblePosition = 0
         Me.ugDetalle.DisplayLayout.Bands(0).Columns("ImprimirCab").Width = 30
         If Not _tit.ContainsKey("ImprimirCab") Then _tit.Add("ImprimirCab", "")
      End If

      If Not Me.ugDetalle.DisplayLayout.Bands(0).Columns.Exists("ImprimirCabConCantidad") Then
         Me.ugDetalle.DisplayLayout.Bands(0).Columns.Add("ImprimirCabConCantidad", "Ver/Cant.").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
         Me.ugDetalle.DisplayLayout.Bands(0).Override.ButtonStyle = UIElementButtonStyle.Button3D
         Me.ugDetalle.DisplayLayout.Bands(0).Columns("ImprimirCabConCantidad").ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
         Me.ugDetalle.DisplayLayout.Bands(0).Columns("ImprimirCabConCantidad").Header.VisiblePosition = 1
         Me.ugDetalle.DisplayLayout.Bands(0).Columns("ImprimirCabConCantidad").Width = 60
         If Not _tit.ContainsKey("ImprimirCabConCantidad") Then _tit.Add("ImprimirCabConCantidad", "")
      End If

      If Not Me.ugDetalle.DisplayLayout.Bands(1).Columns.Exists("ImprimirComp") Then
         Me.ugDetalle.DisplayLayout.Bands(1).Columns.Add("ImprimirComp", "Ver").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
         Me.ugDetalle.DisplayLayout.Bands(1).Override.ButtonStyle = UIElementButtonStyle.Button3D
         Me.ugDetalle.DisplayLayout.Bands(1).Columns("ImprimirComp").ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
         Me.ugDetalle.DisplayLayout.Bands(1).Columns("ImprimirComp").Header.VisiblePosition = 0
         Me.ugDetalle.DisplayLayout.Bands(1).Columns("ImprimirComp").Width = 30
         If Not _tit1.ContainsKey("ImprimirComp") Then _tit1.Add("ImprimirComp", "")
      End If

      AjustarColumnasGrilla()
      Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

   End Sub

   Private Sub FormatearGrilla()

      With Me.ugDetalle.DisplayLayout.Bands(0)

         '.Columns("IdSucursal").Hidden = True

         .Columns("ImprimirCab").Width = 30
         .Columns("ImprimirCabConCantidad").Width = 40


         .Columns("anula").Hidden = True

         .Columns("IdPedido").Header.Caption = "Número"
         .Columns("IdPedido").Width = 60
         .Columns("IdPedido").CellAppearance.TextHAlign = HAlign.Right
         .Columns("IdPedido").CellActivation = Activation.NoEdit

         .Columns("fechaPedido").Header.Caption = "Fecha"
         .Columns("fechaPedido").Width = 100
         .Columns("fechaPedido").Format = "dd/MM/yyyy HH:mm"
         .Columns("fechaPedido").CellAppearance.TextHAlign = HAlign.Center
         .Columns("fechaPedido").CellActivation = Activation.NoEdit

         .Columns("NombreCliente").Header.Caption = "Cliente"
         .Columns("NombreCliente").Width = 200
         .Columns("NombreCliente").CellActivation = Activation.NoEdit

         .Columns("IdUsuario").Header.Caption = "Usuario"
         .Columns("IdUsuario").Width = 80
         .Columns("IdUsuario").CellActivation = Activation.NoEdit

         .Columns("Observacion").Header.Caption = "Observación"
         .Columns("Observacion").Width = 300
         .Columns("Observacion").CellActivation = Activation.NoEdit

      End With

   End Sub

   Private Sub FormatearBanda2()

      With Me.ugDetalle.DisplayLayout.Bands(1)
         .Columns("IdSucursal").Hidden = True
         .Columns("IdPedido").Hidden = True
         .Columns("fechaPedido").Hidden = True
         .Columns("IdCliente").Hidden = True
         .Columns("NombreCliente").Hidden = True
         .Columns("IdTipoEstado").Hidden = True
         .Columns("Cantidad").Hidden = True
         .Columns("Comprobante").Hidden = True
         .Columns("CentroEmisor").Hidden = True
         .Columns("NumeroComprobante").Hidden = True
         .Columns("IdUsuario").Hidden = True
         .Columns("Observacion").Hidden = True
         .Columns("IdCriticidad").Hidden = True
         .Columns("FechaEntrega").Hidden = True

         .Columns("ImprimirComp").Width = 70
         .Columns("Comp").Width = 40

         .Columns("nombreProducto").Header.Caption = "Producto"
         .Columns("nombreProducto").Width = 150
         .Columns("nombreProducto").CellAppearance.TextHAlign = HAlign.Left

         .Columns("idProducto").Header.Caption = "Nro.Prod."
         .Columns("idProducto").Width = 100
         .Columns("idProducto").CellAppearance.TextHAlign = HAlign.Right

         .Columns("Tamano").Header.Caption = "Tamaño"
         .Columns("Tamano").Width = 60
         .Columns("Tamano").CellAppearance.TextHAlign = HAlign.Right

         .Columns("Orden").Hidden = True

         .Columns("fechaestado").Header.Caption = "Fecha Estado"
         .Columns("fechaestado").Width = 100
         .Columns("fechaestado").CellAppearance.TextHAlign = HAlign.Right

         .Columns("idEstado").Header.Caption = "Estado"
         .Columns("idEstado").Width = 90
         .Columns("idEstado").CellAppearance.TextHAlign = HAlign.Right

         .Columns("CantEstado").Header.Caption = "Cant. Estado"
         .Columns("CantEstado").Width = 90
         .Columns("CantEstado").CellAppearance.TextHAlign = HAlign.Right

         .Columns("cantPendiente").Header.Caption = "Cant. Pendiente"
         .Columns("cantPendiente").Width = 90
         .Columns("cantPendiente").CellAppearance.TextHAlign = HAlign.Right

         .Columns("idTipoComprobante").Header.Caption = "Comprobante"
         .Columns("idTipoComprobante").Width = 90
         .Columns("idTipoComprobante").CellAppearance.TextHAlign = HAlign.Right

      End With

      Dim rowTypes As GridRowType = GridRowType.DataRow
      Dim band As UltraGridBand = Me.ugDetalle.DisplayLayout.Bands(1)
      Dim enumerator As IEnumerable = band.GetRowEnumerator(rowTypes)
      Dim row As UltraGridRow
      For Each row In enumerator
         If row.Cells("letra").Value Is System.DBNull.Value Then
            row.Cells("ImprimirComp").Hidden = True
            row.Cells("comp").Hidden = True
         End If
      Next

   End Sub

   'Private Function CrearDT() As DataTable

   '   Dim dtTemp As DataTable = New DataTable()

   '   With dtTemp
   '      .Columns.Add("Fecha", System.Type.GetType("System.DateTime"))
   '      .Columns.Add("IdTipoComprobante", System.Type.GetType("System.String"))
   '      .Columns.Add("TipoComprobante", System.Type.GetType("System.String"))
   '      .Columns.Add("Letra", System.Type.GetType("System.String"))
   '      .Columns.Add("CentroEmisor", System.Type.GetType("System.Int32"))
   '      .Columns.Add("NumeroComprobante", System.Type.GetType("System.Int64"))
   '      '.AppendLine("      ,V.TipoDocVendedor ")
   '      '.AppendLine("      ,V.NroDocVendedor ")
   '      .Columns.Add("TipoDocCliente", System.Type.GetType("System.String"))
   '      .Columns.Add("NroDocCliente", System.Type.GetType("System.Int64"))
   '      .Columns.Add("NombreCliente", System.Type.GetType("System.String"))
   '      .Columns.Add("NombreCategoriaFiscal", System.Type.GetType("System.String"))
   '      .Columns.Add("FormaDePago", System.Type.GetType("System.String"))
   '      .Columns.Add("IdProducto", System.Type.GetType("System.String"))
   '      .Columns.Add("NombreProducto", System.Type.GetType("System.String"))
   '      .Columns.Add("NombreMarca", System.Type.GetType("System.String"))
   '      .Columns.Add("NombreRubro", System.Type.GetType("System.String"))
   '      .Columns.Add("Cantidad", System.Type.GetType("System.Decimal"))
   '      '.AppendLine("      ,VP.Costo")
   '      .Columns.Add("PrecioLista", System.Type.GetType("System.Decimal"))
   '      .Columns.Add("Precio", System.Type.GetType("System.Decimal"))
   '      .Columns.Add("DescuentoRecargoPorc", System.Type.GetType("System.Decimal"))
   '      .Columns.Add("DescuentoRecargoPorc2", System.Type.GetType("System.Decimal"))
   '      .Columns.Add("DescuentoRecargoPorcGral", System.Type.GetType("System.Decimal"))
   '      .Columns.Add("PrecioNeto", System.Type.GetType("System.Decimal"))
   '      '.AppendLine("      ,VP.Utilidad")
   '      .Columns.Add("AlicuotaImpuesto", System.Type.GetType("System.Decimal"))
   '      .Columns.Add("ImporteTotalNeto", System.Type.GetType("System.Decimal"))
   '      .Columns.Add("ImporteImpuesto", System.Type.GetType("System.Decimal"))
   '      .Columns.Add("ImporteTotal", System.Type.GetType("System.Decimal"))
   '      .Columns.Add("Usuario", System.Type.GetType("System.String"))
   '   End With

   '   Return dtTemp

   'End Function

#End Region

   Private Sub AjustarColumnasGrilla()
      'SI SE DESEA CAMBIAR EL TITULO DE ALGUNA COLUMNA EN PARTICULAR
      'tit("NOMBRECOLUMNA") = "NUEVO HEADER"

      For Each col As UltraGridColumn In ugDetalle.DisplayLayout.Bands("Cabecera").Columns
         col.Hidden = Not _tit.ContainsKey(col.Key)
         If _tit.ContainsKey(col.Key) Then
            If Not String.IsNullOrWhiteSpace(_tit(col.Key)) Then
               col.Header.Caption = _tit(col.Key)
            End If
         End If
      Next

      For Each col As UltraGridColumn In ugDetalle.DisplayLayout.Bands("Detalle").Columns
         col.Hidden = Not _tit1.ContainsKey(col.Key)
         If _tit1.ContainsKey(col.Key) Then
            If Not String.IsNullOrWhiteSpace(_tit1(col.Key)) Then
               col.Header.Caption = _tit1(col.Key)
            End If
         End If
      Next

      For Each col As UltraGridColumn In ugDetalle.DisplayLayout.Bands("Comprobante").Columns
         col.Hidden = Not _tit2.ContainsKey(col.Key)
         If _tit2.ContainsKey(col.Key) Then
            If Not String.IsNullOrWhiteSpace(_tit2(col.Key)) Then
               col.Header.Caption = _tit2(col.Key)
            End If
         End If
      Next
   End Sub

   Private Sub chbOrdenCompra_CheckedChanged(sender As Object, e As EventArgs) Handles chbOrdenCompra.CheckedChanged
      Try
         Me.txtOrdenCompra.Enabled = Me.chbOrdenCompra.Checked

         If Not Me.chbOrdenCompra.Checked Then
            Me.txtOrdenCompra.Text = String.Empty
         Else
            Me.txtOrdenCompra.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         PreferenciasCargar(ugDetalle, tsbPreferencias)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   '-- REG-41940.- --------------------------------------------------------------------------------------------------------------
   Private Sub chbPlanMaestro_CheckedChanged(sender As Object, e As EventArgs) Handles chbPlanMaestro.CheckedChanged
      '-- Inicializa los campos de Filtro.- ------------------------------------------------
      txtPlanMaestro.Enabled = chbPlanMaestro.Checked
      txtPlanMaestro.Text = "0"
      txtPlanMaestro.Select()
      '-------------------------------------------------------------------------------------
   End Sub

   Private Sub chbFechaPlanMaestro_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaPlanMaestro.CheckedChanged
      dtpDesdePlanMaestro.Enabled = chbFechaPlanMaestro.Checked
      dtpHastaPlanMaestro.Enabled = chbFechaPlanMaestro.Checked

      dtpDesdePlanMaestro.Value = Date.Today
      dtpHastaPlanMaestro.Value = Date.Today.UltimoSegundoDelDia()
   End Sub
   '--------------------------------------------------------------------------------------------------------------------------

End Class