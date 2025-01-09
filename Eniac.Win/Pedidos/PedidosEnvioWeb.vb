Public Class PedidosEnvioWeb
   Implements IConParametros

#Region "Campos"

   Private _publicos As Publicos
   Private _tipoTipoComprobante As String
   Private _tit As Dictionary(Of String, String) = New Dictionary(Of String, String)()
   Private _idUsuario As String = actual.Nombre

   Private _dtPedidos As DataTable

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try
         If String.IsNullOrWhiteSpace(_tipoTipoComprobante) Then _tipoTipoComprobante = "PEDIDOSCLIE"

         _tit = GetColumnasVisiblesGrilla(ugDetalle)

         cmbTiposComprobantes.Initializar(False, True, True, False, _tipoTipoComprobante)
         Me.cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()

         Me._publicos = New Publicos()

         Me._publicos.CargaComboEstadosPedidos(cmbEstados, True, True, True, True, False, _tipoTipoComprobante)
         Me.cmbEstados.SelectedIndex = 1

         cmbEstados.SelectedValue = Reglas.Publicos.EstadoPedidoPendienteWebPOST
         cmbEstados.Enabled = False

         chbFecha.Checked = True
         Me.dtpDesde.Value = Date.Today
         Me.dtpHasta.Value = Date.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)

         Me._publicos.CargaComboUsuarios(Me.cmbUsuario)

         'Si el Usuario no tiene Vendedores asociados limpio la variable para que no filtre en el cargar combo.
         If New Reglas.Empleados().GetPorUsuario(_idUsuario).Rows.Count = 0 Then
            _idUsuario = ""
         End If

         Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR, _idUsuario)
         If _idUsuario = "" Then
            Me.cmbVendedor.SelectedIndex = -1
         Else
            Me.chbVendedor.Checked = True
            Me.chbVendedor.Enabled = False  'Para que no pueda modificarlo manualmente
         End If

         Ayudante.Grilla.AgregarTotalesSuma(ugDetalle, {"ImporteTotal", "ImporteTotalSelec"})
         Ayudante.Grilla.AgregarFiltroEnLinea(ugDetalle, {"NombreCliente", "Observacion"}, {"Ver"})

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      Try
         If keyData = Keys.F5 Then
            Me.tsbRefrescar_Click(Me.tsbRefrescar, Nothing)
            Return True
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function

#End Region

#Region "Eventos"


   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

         Me.tssRegistros.Text = _dtPedidos.Rows.Count.ToString() & " Registros"
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   '' '' '' ''Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
   '' '' '' ''   Try

   '' '' '' ''      If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

   '' '' '' ''      Dim Filtros As String = String.Empty

   '' '' '' ''      Filtros = "Filtros: Estado: " & Me.cmbEstados.Text

   '' '' '' ''      If Me.chbFecha.Checked Then
   '' '' '' ''         Filtros = Filtros & " / Rango de Fechas: desde el " & Me.dtpDesde.Text & " hasta el " & Me.dtpHasta.Text
   '' '' '' ''      End If

   '' '' '' ''      If Me.chbCliente.Checked Then
   '' '' '' ''         Filtros = Filtros & " / Cliente: " & Me.bscCodigoCliente.Text.Trim() & " - " & Me.bscCliente.Text.Trim()
   '' '' '' ''      End If

   '' '' '' ''      If Me.cmbUsuario.Enabled Then
   '' '' '' ''         Filtros = Filtros & " / Usuario: " & Me.cmbUsuario.SelectedValue.ToString()
   '' '' '' ''      End If

   '' '' '' ''      Dim Titulo As String

   '' '' '' ''      Titulo = Publicos.NombreEmpresa + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Filtros

   '' '' '' ''      Dim UltraPrintPreviewD As Infragistics.Win.Printing.UltraPrintPreviewDialog
   '' '' '' ''      UltraPrintPreviewD = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
   '' '' '' ''      UltraPrintPreviewD.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
   '' '' '' ''      UltraPrintPreviewD.Name = "UltraPrintPreviewDialog1"

   '' '' '' ''      UltraPrintPreviewD.Document = Me.UltraGridPrintDocument1
   '' '' '' ''      UltraPrintPreviewD.Name = Me.Text

   '' '' '' ''      Me.UltraGridPrintDocument1.Header.TextCenter = Titulo
   '' '' '' ''      Me.UltraGridPrintDocument1.Header.Appearance.FontData.Bold = DefaultableBoolean.True
   '' '' '' ''      Me.UltraGridPrintDocument1.Header.Appearance.FontData.SizeInPoints = 12
   '' '' '' ''      Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 20
   '' '' '' ''      Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 20
   '' '' '' ''      Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 20
   '' '' '' ''      Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 40
   '' '' '' ''      Me.UltraGridPrintDocument1.DefaultPageSettings.Landscape = True
   '' '' '' ''      Me.UltraGridPrintDocument1.Footer.TextLeft = "Sucursal: " + actual.Sucursal.Nombre
   '' '' '' ''      Me.UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + DateTime.Today.ToString("dd/MM/yyyy")

   '' '' '' ''      UltraPrintPreviewD.MdiParent = Me.MdiParent
   '' '' '' ''      UltraPrintPreviewD.Show()
   '' '' '' ''      UltraPrintPreviewD.Focus()

   '' '' '' ''   Catch ex As Exception
   '' '' '' ''      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '' '' '' ''   End Try

   '' '' '' ''End Sub

   '' '' '' ''Private Sub tsmiAExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAExcel.Click
   '' '' '' ''   Try
   '' '' '' ''      Me.sfdExportar.FileName = Me.Name & ".xls"
   '' '' '' ''      Me.sfdExportar.Filter = "Archivos excel|*.xls"
   '' '' '' ''      If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
   '' '' '' ''         If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
   '' '' '' ''            Me.UltraGridExcelExporter1.Export(Me.ugDetalle, Me.sfdExportar.FileName, Infragistics.Documents.Excel.WorkbookFormat.Excel97To2003)
   '' '' '' ''         End If
   '' '' '' ''      End If
   '' '' '' ''   Catch ex As Exception
   '' '' '' ''      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '' '' '' ''   End Try
   '' '' '' ''End Sub

   '' '' '' ''Private Sub tsmiAPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAPDF.Click
   '' '' '' ''   Try
   '' '' '' ''      Me.sfdExportar.FileName = Me.Name & ".pdf"
   '' '' '' ''      Me.sfdExportar.Filter = "Archivos pdf|*.pdf"
   '' '' '' ''      If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
   '' '' '' ''         If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
   '' '' '' ''            Me.UltraGridDocumentExporter1.Export(Me.ugDetalle, Me.sfdExportar.FileName, DocumentExport.GridExportFileFormat.PDF)
   '' '' '' ''         End If
   '' '' '' ''      End If
   '' '' '' ''   Catch ex As Exception
   '' '' '' ''      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '' '' '' ''   End Try

   '' '' '' ''End Sub

   '' '' '' ''Private Sub UltraGridPrintDocument1_PagePrinting(ByVal sender As System.Object, ByVal e As Infragistics.Win.Printing.PagePrintingEventArgs) Handles UltraGridPrintDocument1.PagePrinting
   '' '' '' ''   Me.UltraGridPrintDocument1.Footer.TextRight = "Página: " + Me.UltraGridPrintDocument1.PageNumber.ToString()
   '' '' '' ''End Sub

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
         Me.dtpHasta.Value = DateTime.Today.Date.AddDays(1).AddSeconds(-1)
      Else
         Me.dtpDesde.Focus()
      End If

   End Sub

   Private Sub chkMesCompleto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMesCompleto.CheckedChanged
      Try
         If chkMesCompleto.Checked Then
            Me.dtpDesde.Value = dtpDesde.Value.PrimerDiaMes()
            dtpHasta.Value = dtpDesde.Value.UltimoDiaMes(True)
         End If
         Me.dtpDesde.Enabled = Not Me.chkMesCompleto.Checked
         Me.dtpHasta.Enabled = Not Me.chkMesCompleto.Checked
      Catch ex As Exception
         chkMesCompleto.Checked = False
         ShowError(ex)
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

#Region "Busqueda Cliente"
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick, bscCodigoCliente.BuscadorClick
      Dim codigoCliente As Long = -1
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscCodigoCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes()
         If IsNumeric(Me.bscCodigoCliente.Text.Trim()) Then
            codigoCliente = Long.Parse(Me.bscCodigoCliente.Text.Trim())
         End If
         Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, False)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         Me.bscCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), False)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region

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
         ShowError(ex)
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
            MessageBox.Show("ATENCION: NO seleccionó un VENDEDOR aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbVendedor.Focus()
            Exit Sub
         End If

         If Me.chbCliente.Checked And Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
            MessageBox.Show("ATENCION: NO seleccionó un CLIENTE aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If

         If Me.chbIdPedido.Checked AndAlso Integer.Parse("0" & Me.txtIdPedido.Text) = 0 Then
            ShowMessage(Traducciones.TraducirTexto("ATENCION: NO Ingresó un NÚMERO DE PEDIDO aunque activó ese Filtro.", Me, "__FaltaNumeroPedido"))
            Me.txtIdPedido.Focus()
            Exit Sub
         End If

         Me.chkExpandAll.Enabled = True
         Me.chkExpandAll.Checked = False

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         chbTodos.Checked = False

         If ugDetalle.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("NO hay registros que cumplan con la seleccion !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If
      Catch ex As Exception
         Me.tssRegistros.Text = "0 Registros"
         ShowError(ex)
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

   Private Sub chbTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chbTodos.CheckedChanged
      Try
         Me.Cursor = Cursors.WaitCursor
         If _dtPedidos IsNot Nothing Then
            For Each dr As DataRow In _dtPedidos.Rows
               dr("Selec") = Me.chbTodos.Checked
               If chbTodos.Checked Then
                  dr("ImporteTotalSelec") = dr("ImporteTotal")
               Else
                  dr("ImporteTotalSelec") = 0
               End If
            Next
         End If

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub


   '' '' '' ''Private Sub ugDetalle_ClickCellButton(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles ugDetalle.ClickCellButton
   '' '' '' ''   Try

   '' '' '' ''      If Me.ugDetalle.Rows.Count = 0 Then Exit Sub
   '' '' '' ''      Dim reg As Reglas.Pedidos = New Reglas.Pedidos
   '' '' '' ''      Dim oReportePedido As New Entidades.Pedido
   '' '' '' ''      'Dim dtsPedido As New dtsPedido

   '' '' '' ''      If e.Cell.Column.Key = "ImprimirComp" Then

   '' '' '' ''         Dim oVentas As Reglas.Ventas = New Reglas.Ventas()

   '' '' '' ''         Dim letra As String = String.Empty
   '' '' '' ''         Dim IdTipoComprobante As String = String.Empty
   '' '' '' ''         Dim CentroEmisor As Short = 0
   '' '' '' ''         Dim NumeroComprobante As Long = 0


   '' '' '' ''         'Dim rowTypes As GridRowType = GridRowType.DataRow
   '' '' '' ''         'Dim band As UltraGridBand = Me.ugDetalle.DisplayLayout.Bands(1)
   '' '' '' ''         'Dim enumerator As IEnumerable = band.GetRowEnumerator(rowTypes)
   '' '' '' ''         'Dim row As UltraGridRow
   '' '' '' ''         'For Each row In enumerator
   '' '' '' ''         'If row.Index = e.Cell.Row.Index Then
   '' '' '' ''         If String.IsNullOrWhiteSpace(e.Cell.Row.Cells("letraFact").Value.ToString()) Then
   '' '' '' ''            ShowMessage(Traducciones.TraducirTexto("Esta linea de Pedido NO Tiene Comprobante Relacionado.", Me, "__"))
   '' '' '' ''            Exit Sub
   '' '' '' ''         End If
   '' '' '' ''         letra = e.Cell.Row.Cells("letraFact").Value.ToString
   '' '' '' ''         IdTipoComprobante = e.Cell.Row.Cells("IdTipoComprobanteFact").Value.ToString
   '' '' '' ''         CentroEmisor = Short.Parse(e.Cell.Row.Cells("CentroEmisorFact").Value.ToString)
   '' '' '' ''         NumeroComprobante = Long.Parse(e.Cell.Row.Cells("NumeroComprobanteFact").Value.ToString)
   '' '' '' ''         'Exit For
   '' '' '' ''         'End If

   '' '' '' ''         'Next

   '' '' '' ''         Dim Comprobante As Entidades.Venta = oVentas.GetUna(actual.Sucursal.Id, _
   '' '' '' ''                                                            IdTipoComprobante, _
   '' '' '' ''                                                            letra, _
   '' '' '' ''                                                            CentroEmisor, _
   '' '' '' ''                                                            NumeroComprobante)

   '' '' '' ''         Dim oImpr As Impresion = New Impresion(Comprobante)
   '' '' '' ''         Dim ReporteEstandar As Boolean = True

   '' '' '' ''         oImpr.ImprimirComprobanteNoFiscal(True, ReporteEstandar)

   '' '' '' ''      End If

   '' '' '' ''      If e.Cell.Column.Key = "ImprimirCab" Or e.Cell.Column.Key = "ImprimirCabConCantidad" Then
   '' '' '' ''         Dim idTipoComprobante As String = e.Cell.Row.Cells(Entidades.Pedido.Columnas.IdTipoComprobante.ToString()).Value.ToString()
   '' '' '' ''         Dim letra As String = e.Cell.Row.Cells(Entidades.Pedido.Columnas.Letra.ToString()).Value.ToString()
   '' '' '' ''         Dim centroEmisor As Short = Short.Parse(e.Cell.Row.Cells(Entidades.Pedido.Columnas.CentroEmisor.ToString()).Value.ToString())
   '' '' '' ''         Dim numeroPedido As Long = Long.Parse(e.Cell.Row.Cells(Entidades.Pedido.Columnas.NumeroPedido.ToString()).Value.ToString())

   '' '' '' ''         Dim oPedido As Entidades.Pedido = New Reglas.Pedidos().GetUno(actual.Sucursal.Id, idTipoComprobante, letra, centroEmisor, numeroPedido)
   '' '' '' ''         Dim impresion As ImpresionPedidos = New ImpresionPedidos()

   '' '' '' ''         If e.Cell.Column.Header.Caption = "Ver" Then
   '' '' '' ''            'Reporte = "Eniac.Win.PedidoV2.rdlc"
   '' '' '' ''            impresion.ImprimirPedido(oPedido, True)
   '' '' '' ''         Else
   '' '' '' ''            'Reporte = "Eniac.Win.PedidoV2Detalle.rdlc"
   '' '' '' ''            impresion.ImprimirPedidoDetallado(oPedido, True)
   '' '' '' ''         End If
   '' '' '' ''      End If

   '' '' '' ''      If e.Cell.Column.Key = "comp" Then

   '' '' '' ''         Dim oVentas As Reglas.Ventas = New Reglas.Ventas()

   '' '' '' ''         Dim letra As String = String.Empty
   '' '' '' ''         Dim IdTipoComprobante As String = String.Empty
   '' '' '' ''         Dim CentroEmisor As Short = 0
   '' '' '' ''         Dim NumeroComprobante As Long = 0

   '' '' '' ''         'Dim rowTypes As GridRowType = GridRowType.DataRow
   '' '' '' ''         'Dim band As UltraGridBand = Me.ugDetalle.DisplayLayout.Bands(1)
   '' '' '' ''         'Dim enumerator As IEnumerable = band.GetRowEnumerator(rowTypes)
   '' '' '' ''         'Dim row As UltraGridRow

   '' '' '' ''         'For Each row In enumerator
   '' '' '' ''         'If row.Index = e.Cell.Row.Index Then
   '' '' '' ''         If e.Cell.Row.Cells("letraFact").Value Is System.DBNull.Value Then
   '' '' '' ''            MessageBox.Show("No hay comprobantes en esta linea para informar", Me.Text)
   '' '' '' ''            Exit Sub
   '' '' '' ''         End If
   '' '' '' ''         letra = e.Cell.Row.Cells("letraFact").Value.ToString
   '' '' '' ''         IdTipoComprobante = e.Cell.Row.Cells("IdTipoComprobanteFact").Value.ToString
   '' '' '' ''         CentroEmisor = Short.Parse(e.Cell.Row.Cells("CentroEmisorFact").Value.ToString)
   '' '' '' ''         NumeroComprobante = Long.Parse(e.Cell.Row.Cells("NumeroComprobanteFact").Value.ToString)
   '' '' '' ''         'Exit For
   '' '' '' ''         'End If
   '' '' '' ''         'Next

   '' '' '' ''         dtPedidoDetalleComprobante = reg.GetPedidosDetalleComprobante(actual.Sucursal.Id, _
   '' '' '' ''                                                                  IdTipoComprobante, _
   '' '' '' ''                                                                  letra, _
   '' '' '' ''                                                                  CentroEmisor, _
   '' '' '' ''                                                                  NumeroComprobante)

   '' '' '' ''         dtPedidoDetalleComprobante.TableName = "dtPedidoDetalleComp"

   '' '' '' ''         DirectCast(Me.dtsMaster_detalle.Tables("dtPedidoDetalleComp"), DataTable).Rows.Clear()

   '' '' '' ''         Me.dtsMaster_detalle.Merge(dtPedidoDetalleComprobante)
   '' '' '' ''         '  Me.ugDetalle.SetDataBinding(dtsMaster_detalle, "datos.ConstEnum.ConstEnum4")

   '' '' '' ''         ' Me.ugDetalle.DataSource = dtsMaster_detalle

   '' '' '' ''         ' Me.ugDetalle.DataBind() ' = dtsMaster_detalle

   '' '' '' ''         ' Exit Sub

   '' '' '' ''      End If

   '' '' '' ''      If e.Cell.Column.Key = "CantidadContactos" Then
   '' '' '' ''         If String.IsNullOrEmpty(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("CantidadContactos").Value.ToString()) Then Exit Sub

   '' '' '' ''         Dim Pedido As Entidades.Pedido = New Reglas.Pedidos().GetUno(Integer.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("IdSucursal").Value.ToString()), _
   '' '' '' ''                     Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("IdTipoComprobante").Value.ToString(), _
   '' '' '' ''                     Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("Letra").Value.ToString(), _
   '' '' '' ''                     Short.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("CentroEmisor").Value.ToString()), _
   '' '' '' ''                     Long.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("NumeroPedido").Value.ToString()))

   '' '' '' ''         Dim cl As ConsultarContactos = New ConsultarContactos(Pedido.TipoComprobante.IdTipoComprobante, _
   '' '' '' ''                                                       Pedido.LetraComprobante, _
   '' '' '' ''                                                       Pedido.CentroEmisor, _
   '' '' '' ''                                                       Pedido.NumeroPedido, _
   '' '' '' ''                                                       1)

   '' '' '' ''         cl.ShowDialog()

   '' '' '' ''      End If

   '' '' '' ''   Catch ex As Exception
   '' '' '' ''      Me.Cursor = Cursors.Default
   '' '' '' ''      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '' '' '' ''   Finally
   '' '' '' ''      Me.Cursor = Cursors.Default
   '' '' '' ''   End Try

   '' '' '' ''End Sub

#End Region

#Region "Metodos"
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
      If String.IsNullOrWhiteSpace(_idUsuario) Then
         Me.chbVendedor.Checked = False
      End If

      Me.cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()

      Me.chkExpandAll.Checked = False
      Me.chkExpandAll.Enabled = False

      Me.chbFecha.Checked = True

      _dtPedidos.Clear()

      Me.cmbEstados.Focus()
   End Sub


   Private Sub CargaGrillaDetalle()
      Dim oPedidos As Reglas.Pedidos = New Reglas.Pedidos()

      Dim FechaDesde As Date = Nothing
      Dim FechaHasta As Date = Nothing

      Dim IdPedido As Integer = -1
      Dim IdCliente As Long = 0

      Dim IdVendedor As Integer = 0

      Dim IdUsuario As String = String.Empty

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

      If Me.chbVendedor.Checked Then
         IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado
      End If

      _dtPedidos = oPedidos.pedidosCabecera(actual.Sucursal.Id,
                                            Me.cmbEstados.Text, alMenosUno_TodosSean:=True,
                                            FechaDesde, FechaHasta,
                                            cmbTiposComprobantes.GetTiposComprobantes(),
                                            letra:="", centroEmisor:=0,
                                            numeroPedidoDesde:=IdPedido,
                                            numeroPedidoHasta:=IdPedido,
                                            idProducto:=String.Empty,
                                            idCliente:=IdCliente,
                                            idUsuario:=IdUsuario,
                                            idVendedor:=IdVendedor,
                                            tipoVendedor:=Entidades.OrigenFK.Actual,
                                            ordenCompra:=0,
                                            tipoTipoComprobante:=_tipoTipoComprobante,
                                            idProveedor:=0,
                                            categorias:={},
                                            origenCategorias:=Entidades.OrigenFK.Actual,
                                            numeroReparto:=0,
                                            numeroRepartoHasta:=0,
                                            idFormasPago:=0,
                                            idListaPrecios:=-1,
                                            impreso:=Entidades.Publicos.SiNoTodos.TODOS)

      _dtPedidos.Columns.Add("Selec", GetType(Boolean))
      _dtPedidos.Columns.Add("ImporteTotalSelec", GetType(Decimal))
      For Each dr As DataRow In _dtPedidos.Rows
         dr("Selec") = False
         dr("ImporteTotalSelec") = 0
      Next

      ugDetalle.DataSource = _dtPedidos

      AjustarColumnasGrilla(ugDetalle, _tit)
      Me.tssRegistros.Text = _dtPedidos.Rows.Count.ToString() & " Registros"
   End Sub

#End Region

#Region "Implements IConParametros"
   Public Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
      _tipoTipoComprobante = parametros
   End Sub
   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Dim stb = New StringBuilder()
      stb.AppendFormatLine("Definir el tipo de Tipo de Comprobante para usar en la pantalla.")
      stb.AppendFormatLine("Por defecto: PEDIDOSCLIE")
      stb.AppendFormatLine("El valor se carga directamente.")
      Return stb.ToString()
   End Function
#End Region

   Private Sub ugDetalle_CellChange(sender As Object, e As UltraWinGrid.CellEventArgs) Handles ugDetalle.CellChange
      Try
         ugDetalle.UpdateData()
         If e.Cell.Value.Equals(True) Then
            e.Cell.Row.Cells("ImporteTotalSelec").Value = e.Cell.Row.Cells("ImporteTotal").Value
         Else
            e.Cell.Row.Cells("ImporteTotalSelec").Value = 0
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub


   Private Sub tsbEnviarWeb_Click(sender As Object, e As EventArgs) Handles tsbEnviarWeb.Click
      Try
         ugDetalle.UpdateData()
         Dim drCol As DataRow() = _dtPedidos.Select("Selec")

         If drCol.Length = 0 Then
            ShowMessage("No ha seleccionado ningún registro a enviar.")
            Exit Sub
         End If

         If ShowPregunta(String.Format("Está por enviar {0} pedidos a la Web." + Environment.NewLine() + "¿Desea continuar?", drCol.Length)) = Windows.Forms.DialogResult.Yes Then

            Dim rPedidos As Reglas.Pedidos = New Reglas.Pedidos()
            Dim pedidosJ As List(Of Entidades.JSonEntidades.Pedidos.PedidoJSon) = rPedidos.GetPedidosJSon(drCol)

            rPedidos.EnviarPedidosWeb(pedidosJ, _tipoTipoComprobante, IdFuncion)

            ShowMessage("Envio realizado exitosamente.")

            btnConsultar.PerformClick()
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
End Class