#Region "Option/Imports"
Option Explicit On
Option Strict On
Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinDataSource
#End Region
Public Class ConsultarOrdenesCompra
   Implements IConParametros

#Region "Campos"

   Private _publicos As Publicos
   Dim dtsMaster_detalle As DataSet
   'Dim primeraCarga As Boolean = True
   Dim dtDetalle As DataTable
   Dim dtPedidoDetalle As DataTable
   Dim dtPedidoDetalleComprobante As DataTable
   Private _tipoTipoComprobante As String
   Private _estaCargando As Boolean = True

   Private _tit As Dictionary(Of String, String) = New Dictionary(Of String, String)()
   Private _tit1 As Dictionary(Of String, String) = New Dictionary(Of String, String)()
   Private _tit2 As Dictionary(Of String, String) = New Dictionary(Of String, String)()

   Private _puedeVerPrecios As Boolean

   Private IdUsuario As String = actual.Nombre
   Private _cabecera As DataTable = New DataTable()
#End Region

   Private Const imprimirCompColumnKey As String = "ImprimirComp"
   Private Const imprimirCabConCantidadColumnKey As String = "ImprimirCabConCantidad"
   Private Const imprimirCabColumnKey As String = "VerCabecera"
   Private Const detalleColumnKey As String = "Ver"


#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try
         If String.IsNullOrWhiteSpace(_tipoTipoComprobante) Then _tipoTipoComprobante = "PEDIDOSPROV"

         _puedeVerPrecios = True

         cmbTiposComprobantes.Initializar(False, True, True, False, _tipoTipoComprobante)
         Me.cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()
         Me.cmbActivadas.SelectedIndex = 2

         Me._publicos = New Publicos()

         Me._publicos.CargaComboEstadosPedidosProvCalidad(cmbEstados, True, True, False, True, False, _tipoTipoComprobante)
         Me.cmbEstados.SelectedIndex = 1

         '   chbFecha.Checked = True
         Me.dtpDesde.Value = Date.Today
         Me.dtpHasta.Value = Date.Today.AddDays(1).AddSeconds(-1)

         Me._publicos.CargaComboUsuarios(Me.cmbUsuario)

         'Si el Usuario no tiene Compradores asociados limpio la variable para que no filtre en el cargar combo.
         If New Reglas.Empleados().GetPorUsuario(IdUsuario).Rows.Count = 0 Then
            IdUsuario = ""
         End If

         Me._publicos.CargaComboEmpleados(Me.cmbComprador, Entidades.Publicos.TiposEmpleados.COMPRADOR, IdUsuario)
         If IdUsuario = "" Then
            Me.cmbComprador.SelectedIndex = -1
         Else
            Me.chbComprador.Checked = True
            Me.chbComprador.Enabled = False  'Para que no pueda modificarlo manualmente
         End If

         'Me.ugDetalle.DisplayLayout.Bands("Detalle").Columns("ClipArchivoAdjunto").Hidden = Not Publicos.DetallePedido.PedidosMostrarUrlPlanoDetalle

         If Not _puedeVerPrecios Then
            ugDetalle.DisplayLayout.Bands("Cabecera").Columns("ImporteTotal").Hidden = True
            'ugDetalle.DisplayLayout.Bands("Comprobante").Columns("ImporteTotal").Hidden = True
            ' ugDetalle.DisplayLayout.Bands("Comprobante").Columns("ImportePesos").Hidden = True
         End If

         _tit = GetColumnasVisiblesGrilla(ugDetalle.DisplayLayout.Bands("Cabecera"))
         _tit1 = GetColumnasVisiblesGrilla(ugDetalle.DisplayLayout.Bands("Detalle"))
         '  _tit2 = GetColumnasVisiblesGrilla(ugDetalle.DisplayLayout.Bands("Comprobante"))

         Me.ugDetalle.AgregarFiltroEnLinea({"Act"})
         Me.CargarColumnasASumar()
         Me._estaCargando = False

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

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try
         If Me.chbComprador.Checked And Me.cmbComprador.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Debe seleccionar un COMPRADOR.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbComprador.Focus()
            Exit Sub
         End If

         If Me.chbProveedor.Checked And Not Me.bscCodigoProveedor.Selecciono And Not Me.bscProveedor.Selecciono Then
            MessageBox.Show("ATENCION: NO seleccionó un Proveedor aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoProveedor.Focus()
            Exit Sub
         End If

         If Me.chbIdPedido.Checked AndAlso Integer.Parse("0" & Me.txtIdPedido.Text) = 0 Then
            ShowMessage(Traducciones.TraducirTexto("ATENCION: NO Ingresó un Número de Pedido aunque activó ese Filtro.", Me, "__FaltaNumeroPedido"))
            Me.txtIdPedido.Focus()
            Exit Sub
         End If

         Me.chkExpandAll.Enabled = True
         Me.chkExpandAll.Checked = False

         Me.Cursor = Cursors.WaitCursor

         If Me.ugDetalle.DataSource IsNot Nothing AndAlso TypeOf (ugDetalle.DataSource) Is DataSet Then
            DirectCast(Me.ugDetalle.DataSource, DataSet).Clear()
         End If

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

#Region "Eventos Toolbar"
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

         If Me.chbProveedor.Checked Then
            Filtros = Filtros & " / Proveedor: " & Me.bscCodigoProveedor.Text.Trim() & " - " & Me.bscProveedor.Text.Trim()
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

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub
#End Region

#Region "Eventos Filtros"
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

   Private Sub chbProveedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbProveedor.CheckedChanged

      Me.bscCodigoProveedor.Enabled = Me.chbProveedor.Checked
      Me.bscProveedor.Enabled = Me.chbProveedor.Checked

      Me.bscCodigoProveedor.Text = String.Empty
      Me.bscCodigoProveedor.Tag = Nothing
      Me.bscProveedor.Text = String.Empty

      Me.bscCodigoProveedor.Focus()

   End Sub

   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick, bscCodigoProveedor.BuscadorClick
      'Dim codigoProveedor As Long = -1
      Dim codigoProveedor As String = String.Empty

      Try
         Me._publicos.PreparaGrillaProveedores(Me.bscCodigoProveedor)
         Dim rProveedores As Reglas.Proveedores = New Reglas.Proveedores()
         If Me.bscCodigoProveedor.Text.Trim.Length > 0 Then
            'codigoProveedor = Long.Parse(Me.bscCodigoProveedor.Text.Trim())
            codigoProveedor = Me.bscCodigoProveedor.Text.Trim()
         End If
         Me.bscCodigoProveedor.Datos = rProveedores.GetFiltradoPorCodigoLetras(codigoProveedor, True)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCodigoProveedor_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion, bscCodigoProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProveedor_BuscadorClick() Handles bscProveedor.BuscadorClick
      Try
         Me._publicos.PreparaGrillaProveedores(Me.bscProveedor)
         Dim rProveedores As Reglas.Proveedores = New Reglas.Proveedores()
         Me.bscProveedor.Datos = rProveedores.GetFiltradoPorNombre(Me.bscProveedor.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProveedor_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
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

   Private Sub chbVendedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbComprador.CheckedChanged

      Me.cmbComprador.Enabled = Me.chbComprador.Checked

      If Not Me.chbComprador.Checked Then
         Me.cmbComprador.SelectedIndex = -1
      Else
         If Me.cmbComprador.Items.Count > 0 Then
            Me.cmbComprador.SelectedIndex = 0
         End If
      End If

      Me.cmbComprador.Focus()

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
#End Region

#Region "Eventos Grilla"
   Private Sub ugDetalle_ClickCellButton(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles ugDetalle.ClickCellButton
      Try

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub
         'Imprimer el comprobante Fact o Remito según corresponda.
         If e.Cell.Column.Key = imprimirCabColumnKey Or e.Cell.Column.Key = detalleColumnKey Then

            Dim letra As String = String.Empty
            Dim IdTipoComprobante As String = String.Empty
            Dim CentroEmisor As Short = 0
            Dim NumeroComprobante As Long = 0
            Dim idProducto As String = String.Empty
            Dim orden As Integer = 0


            IdTipoComprobante = e.Cell.Row.Cells(Entidades.PedidoProveedor.Columnas.IdTipoComprobante.ToString()).Value.ToString
            letra = e.Cell.Row.Cells(Entidades.PedidoProveedor.Columnas.Letra.ToString()).Value.ToString
            CentroEmisor = Short.Parse(e.Cell.Row.Cells(Entidades.PedidoProveedor.Columnas.CentroEmisor.ToString()).Value.ToString)
            NumeroComprobante = Long.Parse(e.Cell.Row.Cells("NumeroPedido").Value.ToString)

            If e.Cell.Column.Key = detalleColumnKey Then
               orden = Integer.Parse(e.Cell.Row.Cells("Orden").Value.ToString)
               idProducto = e.Cell.Row.Cells("IdProducto").Value.ToString

            End If
            Dim OC As Entidades.PedidoProveedor = New Reglas.PedidosProveedores().GetUno(actual.Sucursal.Id, IdTipoComprobante,
                                                         letra, CentroEmisor, NumeroComprobante)

            Using oActOC As ActivacionesOCABM = New ActivacionesOCABM(OC, orden, idProducto)
               oActOC.ShowDialog()
            End Using

            Me.Cursor = Cursors.WaitCursor

            Me.CargaGrillaDetalle()

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
      '  e.Layout.Override.FixedRowStyle = FixedRowStyle.Top

      For Each banda As UltraGridBand In e.Layout.Bands
         If banda.Key <> "Detalle" Then
            banda.HeaderVisible = True
            banda.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left
            banda.Header.Appearance.FontData.Bold = DefaultableBoolean.True
         Else
            banda.HeaderVisible = False
         End If
      Next

      Me.ugDetalle.DisplayLayout.Bands(0).Columns("Dif").Hidden = Not Me.chbDiferenciasFechas.Checked

      ' ugDetalle.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.False

   End Sub

   Private Sub ugDetalle_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugDetalle.InitializeRow
      Try
         If e.Row IsNot Nothing AndAlso
            e.Row.ListObject IsNot Nothing AndAlso
            TypeOf (e.Row.ListObject) Is DataRowView AndAlso
            DirectCast(e.Row.ListObject, DataRowView).Row IsNot Nothing Then
            Dim row As DataRow = DirectCast(e.Row.ListObject, DataRowView).Row

            If row.Table.Columns.Contains("Color") AndAlso IsNumeric(e.Row.Cells("Color").Value) Then
               e.Row.Cells("IdEstado").Appearance.BackColor = Color.FromArgb(Integer.Parse(e.Row.Cells("Color").Value.ToString()))
               e.Row.Cells("IdEstado").Appearance.AlphaLevel = 128
               e.Row.Cells("IdEstado").Appearance.ForegroundAlpha = Alpha.Opaque

               e.Row.Cells("IdEstado").ActiveAppearance.BackColor = Color.FromArgb(Integer.Parse(e.Row.Cells("Color").Value.ToString()))
               e.Row.Cells("IdEstado").ActiveAppearance.BackColorAlpha = Alpha.Opaque
               e.Row.Cells("IdEstado").ActiveAppearance.ForegroundAlpha = Alpha.Opaque
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub UltraGridPrintDocument1_PagePrinting(ByVal sender As System.Object, ByVal e As Infragistics.Win.Printing.PagePrintingEventArgs) Handles UltraGridPrintDocument1.PagePrinting
      Me.UltraGridPrintDocument1.Footer.TextRight = "Página: " + Me.UltraGridPrintDocument1.PageNumber.ToString()
   End Sub
#End Region

#End Region

#Region "Metodos"

   Private Sub CargarColumnasASumar()
      Ayudante.Grilla.AgregarTotalesSuma(ugDetalle, {"ImporteTotal", "ImportePendiente"})
   End Sub

   Private Sub CargarDatosProveedor(ByVal dr As DataGridViewRow)

      Me.bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
      Me.bscCodigoProveedor.Text = dr.Cells("CodigoProveedorLetras").Value.ToString()
      Me.bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()
      Me.bscProveedor.Enabled = False
      Me.bscCodigoProveedor.Enabled = False

   End Sub

   Private Sub RefrescarDatosGrilla()

      Me.cmbEstados.SelectedIndex = 1
      Me.cmbActivadas.SelectedIndex = 2

      Me.chbFecha.Checked = False
      Me.chbProveedor.Checked = False
      Me.chbUsuario.Checked = False

      Me.chbIdPedido.Checked = False
      Me.chbOrdenCompra.Checked = False
      If IdUsuario = "" Then
         Me.chbComprador.Checked = False
      End If

      Me.cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()

      Me.chkExpandAll.Checked = False
      Me.chkExpandAll.Enabled = False

      Me.chbFechaEntrega.Checked = False
      Me.chbFechaAutorizacion.Checked = False
      Me.chbRangoImporte.Checked = False

      Me.txtTipo.Text = String.Empty
      Me.txtOC.Text = String.Empty
      Me.txtFechaE.Text = String.Empty
      Me.txtFechaEnt.Text = String.Empty
      Me.txtCodProv.Text = String.Empty
      Me.txtTotal.Text = String.Empty
      Me.txtProveedor.Text = String.Empty
      Me.txtPorcImpPendiente.Text = String.Empty

      Me.chbDiferenciasFechas.Checked = True

      If Me.ugDetalle.DataSource IsNot Nothing AndAlso TypeOf (ugDetalle.DataSource) Is DataSet Then
         DirectCast(Me.ugDetalle.DataSource, DataSet).Clear()
      End If

      Me.cmbEstados.Focus()
   End Sub

   Private Sub CargaGrillaDetalle()

      Dim oPedidos As Reglas.PedidosProveedores = New Reglas.PedidosProveedores()

      Dim FechaDesde As Date = Nothing
      Dim FechaHasta As Date = Nothing

      Dim FechaDesdeEntrega As Date = Nothing
      Dim FechaHastaEntrega As Date = Nothing

      Dim FechaDesdeAutorizacion As Date = Nothing
      Dim FechaHastaAutorizacion As Date = Nothing

      Dim importeMinimo As Decimal = 0
      Dim importeMaximo As Decimal = 0

      Dim idProducto As String = String.Empty
      Dim IdMarca As Integer = 0
      Dim IdRubro As Integer = 0
      Dim idSubRubro As Integer = 0
      Dim lote As String = String.Empty

      Dim IdPedido As Integer = -1
      Dim OrdenCompra As Long = 0
      Dim Tamanio As Decimal = 0

      Dim IdProveedor As Long = 0

      Dim TipoComprobante As String = String.Empty

      Dim IdComprador As Integer = 0

      Dim IdFormaDePago As Integer = 0
      Dim IdUsuario As String = String.Empty
      Dim Cantidad As String = String.Empty

      Dim idPed_str As String = String.Empty

      If Me.chbFecha.Checked Then
         FechaDesde = Me.dtpDesde.Value
         FechaHasta = Me.dtpHasta.Value
      End If

      If Me.chbFechaEntrega.Checked Then
         FechaDesdeEntrega = Me.dtpFechaEntregaDesde.Value
         FechaHastaEntrega = Me.dtpFechaEntregaHasta.Value
      End If

      If Me.chbFechaAutorizacion.Checked Then
         FechaDesdeAutorizacion = Me.dtpFechaAutorizacionDesde.Value
         FechaHastaAutorizacion = Me.dtpFechaAutorizacionHasta.Value
      End If

      If Me.chbProveedor.Checked Then
         IdProveedor = Long.Parse(Me.bscCodigoProveedor.Tag.ToString())
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

      If Me.chbComprador.Checked Then
         IdComprador = DirectCast(Me.cmbComprador.SelectedItem, Entidades.Empleado).IdEmpleado
      End If

      If chbRangoImporte.Checked Then

         importeMinimo = Decimal.Parse(Me.txtMinRango.Text.ToString())
         importeMaximo = Decimal.Parse(Me.txtMaxRango.Text.ToString())
      End If

      dtsMaster_detalle = New DataSet()

      dtDetalle = oPedidos.OCCabecera(actual.Sucursal.Id,
                                           Me.cmbEstados.Text,
                                           FechaDesde, FechaHasta,
                                           IdPedido,
                                           IdPedido,
                                           idProducto,
                                           IdMarca,
                                           IdRubro,
                                           lote,
                                           IdProveedor,
                                           IdUsuario,
                                           Tamanio,
                                           IdComprador,
                                           OrdenCompra,
                                           _tipoTipoComprobante,
                                           cmbTiposComprobantes.GetTiposComprobantes(),
                                           String.Empty, 0,
                                           FechaDesdeEntrega,
                                           FechaHastaEntrega,
                                           importeMinimo,
                                           importeMaximo,
                                           FechaDesdeAutorizacion,
                                           FechaHastaAutorizacion,
                                           "TODOS",
                                           fechaDesdeEnvio:=Nothing, fechaHastaEnvio:=Nothing,
                                           False)

      If dtDetalle.Rows.Count = 0 Then
         If TypeOf (ugDetalle.DataSource) Is DataSet Then DirectCast(ugDetalle.DataSource, DataSet).Clear()
         If TypeOf (ugDetalle.DataSource) Is DataTable Then DirectCast(ugDetalle.DataSource, DataTable).Clear()
         Exit Sub
      End If

      _cabecera = dtDetalle

      dtDetalle.TableName = "Cabecera"

      dtsMaster_detalle.Tables.Add(dtDetalle)

      dtPedidoDetalle = oPedidos.GetOCDetalladoXEstadosTodos(actual.Sucursal.Id,
                                                Me.cmbEstados.Text,
                                                FechaDesde, FechaHasta,
                                                IdPedido,
                                                idProducto,
                                                IdMarca,
                                                IdRubro,
                                                lote,
                                                IdProveedor,
                                                IdUsuario,
                                                Tamanio,
                                                IdComprador,
                                                OrdenCompra,
                                                _tipoTipoComprobante,
                                                cmbTiposComprobantes.GetTiposComprobantes(),
                                                FechaDesdeEntrega,
                                                FechaHastaEntrega,
                                                importeMinimo,
                                                importeMaximo,
                                                FechaDesdeAutorizacion,
                                                FechaHastaAutorizacion)

      dtPedidoDetalle.TableName = "detalle"
      dtsMaster_detalle.Tables.Add(dtPedidoDetalle)

      Dim ColumnasPadre(4) As DataColumn
      Dim ColumnasHijo(4) As DataColumn
      ColumnasPadre(0) = dtsMaster_detalle.Tables("Cabecera").Columns("IdSucursal")
      ColumnasPadre(1) = dtsMaster_detalle.Tables("Cabecera").Columns("IdTipoComprobante")
      ColumnasPadre(2) = dtsMaster_detalle.Tables("Cabecera").Columns("CentroEmisor")
      ColumnasPadre(3) = dtsMaster_detalle.Tables("Cabecera").Columns("Letra")
      ColumnasPadre(4) = dtsMaster_detalle.Tables("Cabecera").Columns("NumeroPedido")
      ColumnasHijo(0) = dtsMaster_detalle.Tables("detalle").Columns("IdSucursal")
      ColumnasHijo(1) = dtsMaster_detalle.Tables("detalle").Columns("IdTipoComprobante")
      ColumnasHijo(2) = dtsMaster_detalle.Tables("detalle").Columns("CentroEmisor")
      ColumnasHijo(3) = dtsMaster_detalle.Tables("detalle").Columns("Letra")
      ColumnasHijo(4) = dtsMaster_detalle.Tables("detalle").Columns("NumeroPedido")

      Dim relConstEnum As DataRelation = New DataRelation("Detalle", ColumnasPadre, ColumnasHijo, True)
      dtsMaster_detalle.Relations.Add(relConstEnum)

      Me.ugDetalle.SetDataBinding(dtsMaster_detalle, "Cabecera")

      Me.ugDetalle.DataSource = dtsMaster_detalle

      AjustarColumnasGrilla()

      Me.Activadas()

      Me.SetearColumnas()

      Me.ugDetalle.DisplayLayout.Bands(0).ColumnFilters("Acti").FilterConditions.Clear()

      If Me.cmbActivadas.SelectedIndex <> 2 Then
         If Me.cmbActivadas.SelectedIndex = 0 Then
            Me.ugDetalle.DisplayLayout.Bands(0).ColumnFilters("Acti").FilterConditions.Add(FilterComparisionOperator.Equals, True)
         Else
            Me.ugDetalle.DisplayLayout.Bands(0).ColumnFilters("Acti").FilterConditions.Add(FilterComparisionOperator.Equals, False)
         End If
      End If

      Me.tssRegistros.Text = Me.ugDetalle.Rows.FilteredInRowCount.ToString() & " Registros"

   End Sub

   Private Overloads Sub AjustarColumnasGrilla()
      AjustarColumnasGrilla(ugDetalle.DisplayLayout.Bands("Cabecera"), _tit)
      AjustarColumnasGrilla(ugDetalle.DisplayLayout.Bands("Detalle"), _tit1)
      '  AjustarColumnasGrilla(ugDetalle.DisplayLayout.Bands("Comprobante"), _tit2)
   End Sub

   Private Sub Activadas()
      Try
         Dim producto As String = String.Empty
         Dim Orden As Integer = 0
         ' For Each band As UltraGridBand In Me.ugDetalle.DisplayLayout.Bands
         ' Dim ActOC As List(Of Entidades.ActivacionOC) = New List(Of Entidades.ActivacionOC)
         Dim ActiOC As DataTable = New DataTable()
         Dim oActiOC As Reglas.ActivacionesOC = New Reglas.ActivacionesOC()

         For Each dr As UltraGridRow In Me.ugDetalle.Rows


            ActiOC = oActiOC.GetAll(Integer.Parse(dr.Cells("IdSucursal").Value.ToString()),
                                                            dr.Cells("IdTipoComprobante").Value.ToString(),
                                                            dr.Cells("letra").Value.ToString(),
                                                            Integer.Parse(dr.Cells("CentroEmisor").Value.ToString()),
                                                            Long.Parse(dr.Cells("NumeroPedido").Value.ToString()),
                                                            producto)

            If ActiOC.Count <> 0 Then
               ' dr.Cells("Act").Value = True
               If ActiOC.Rows(0).Item("Criticidad").ToString() = "Normal" Then
                  dr.Cells("Acti").Appearance.BackColor = Color.Green
               ElseIf ActiOC.Rows(0).Item("Criticidad").ToString() = "Crítica" Then
                  dr.Cells("Acti").Appearance.BackColor = Color.Red
                  'Else
                  '   dr.Cells("Act").Appearance.BackColor = Color.White
               End If
            Else
               '   dr.Cells("Act").Value = False
               ' dr.Cells("Act").Appearance.BackColor = Color.White
            End If

            If Date.Parse(dr.Cells("FechaEntrega").Value.ToString()) = Date.Today Then
               dr.Cells("FechaEntrega").Appearance.BackColor = Color.Khaki
            ElseIf Date.Parse(dr.Cells("FechaEntrega").Value.ToString()) < Date.Now Then
               dr.Cells("FechaEntrega").Appearance.BackColor = Color.LightCoral
            Else
               dr.Cells("FechaEntrega").Appearance.BackColor = Color.LightGreen
            End If

            If IsDate(dr.Cells("FechaReprogEntrega").Value.ToString()) Then
               If Date.Parse(dr.Cells("FechaReprogEntrega").Value.ToString()).ToShortDateString() = Date.Today.ToShortDateString() Then
                  dr.Cells("FechaReprogEntrega").Appearance.BackColor = Color.Khaki
               ElseIf Date.Parse(dr.Cells("FechaReprogEntrega").Value.ToString()) < Date.Today Then
                  dr.Cells("FechaReprogEntrega").Appearance.BackColor = Color.LightCoral
               Else
                  dr.Cells("FechaReprogEntrega").Appearance.BackColor = Color.LightGreen
               End If
            End If

            Dim Dif As Long = 0

            If IsDate(dr.Cells("FechaEntrega").Value) And IsDate(dr.Cells("FechaReprogEntrega").Value) Then
               Dif = DateDiff(DateInterval.Day, Date.Parse(dr.Cells("FechaEntrega").Value.ToString()), Date.Parse(dr.Cells("FechaReprogEntrega").Value.ToString()))
               dr.Cells("Dif").Value = Dif
            End If

            If IsDate(dr.Cells("FechaEntrega").Value) And IsDate(dr.Cells("FechaPedido").Value) Then
               Dif = DateDiff(DateInterval.Day, Date.Parse(dr.Cells("FechaPedido").Value.ToString()), Date.Parse(dr.Cells("FechaEntrega").Value.ToString()))
               dr.Cells("Dif1").Value = Dif
            End If

            If IsDate(dr.Cells("FechaEntrega").Value) Then
               Dif = DateDiff(DateInterval.Day, Date.Parse(dr.Cells("FechaEntrega").Value.ToString()), Date.Today)
               If Dif > 0 Then
                  dr.Cells("Dif2").Value = Dif
               End If

            End If

            dr.Cells("ImportePendiente").Value = Decimal.Round((Decimal.Parse(dr.Cells("ImporteTotal").Value.ToString()) * Decimal.Parse(dr.Cells("PorcPendienteImporte").Value.ToString())) / 100, 2)

         Next
         'Next
         Dim band As UltraGridBand = Me.ugDetalle.DisplayLayout.Bands(1)
         'Dim row As UltraGridRow
         'For Each row In band.GetRowEnumerator(GridRowType.DataRow)

         '   ActiOC = oActiOC.GetAll(Integer.Parse(row.Cells("IdSucursal").Value.ToString()),
         '                                                 row.Cells("IdTipoComprobante").Value.ToString(),
         '                                                 row.Cells("letra").Value.ToString(),
         '                                                 Integer.Parse(row.Cells("CentroEmisor").Value.ToString()),
         '                                                 Long.Parse(row.Cells("NumeroPedido").Value.ToString()),
         '                                                 row.Cells("IdProducto").Value.ToString())

         '   If ActiOC.Count <> 0 Then
         '      row.Cells("Act").Value = True
         '      'row.Cells("Act").Appearance.BackColor = Color.Green
         '   Else
         '      row.Cells("Act").Value = False
         '   End If

         'Next row

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Public Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
      _tipoTipoComprobante = parametros
   End Sub
   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Dim stb = New StringBuilder()
      stb.AppendFormatLine("Definir el tipo de Tipo de Comprobante para usar en la pantalla.")
      stb.AppendFormatLine("Por defecto: PEDIDOSPROV")
      stb.AppendFormatLine("El valor se carga directamente.")
      Return stb.ToString()
   End Function

   Private Sub chbFechaEntrega_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaEntrega.CheckedChanged
      Try
         Me.dtpFechaEntregaDesde.Enabled = Me.chbFechaEntrega.Checked
         Me.dtpFechaEntregaHasta.Enabled = Me.chbFechaEntrega.Checked

         If Not Me.chbFechaEntrega.Checked Then
            Me.dtpFechaEntregaDesde.Value = DateTime.Today
            Me.dtpFechaEntregaHasta.Value = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
         Else
            Me.dtpFechaEntregaDesde.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub ugDetalle_AfterRowActivate(sender As Object, e As EventArgs) Handles ugDetalle.AfterRowActivate
      Try
         Dim OC As DataTable = New Reglas.PedidosProveedores()._GetUno(actual.Sucursal.IdSucursal, Me.ugDetalle.ActiveRow.Cells("IdtipoComprobante").Value.ToString(),
                                                                       Me.ugDetalle.ActiveRow.Cells("Letra").Value.ToString(),
                                                                       Integer.Parse(Me.ugDetalle.ActiveRow.Cells("CentroEmisor").Value.ToString()),
                                                                       Long.Parse(Me.ugDetalle.ActiveRow.Cells("NumeroPedido").Value.ToString()))

         Me.txtTipo.Text = OC.Rows(0).Item("IdTipoComprobante").ToString()
         Me.txtOC.Text = OC.Rows(0).Item("NumeroPedido").ToString()
         Dim Prov As Entidades.Proveedor = New Reglas.Proveedores().GetUno(Long.Parse(OC.Rows(0).Item("Idproveedor").ToString()))
         Me.txtCodProv.Text = Prov.CodigoProveedorLetras.ToString()
         Me.txtProveedor.Text = Prov.NombreProveedor
         Me.txtFechaE.Text = Date.Parse(OC.Rows(0).Item("FechaPedido").ToString()).ToString("dd/MM/yyyy")
         Me.txtFechaEnt.Text = Date.Parse(Me.ugDetalle.ActiveRow.Cells("FechaEntrega").Value.ToString()).ToString("dd/MM/yyyy")
         Me.txtTotal.Text = Decimal.Parse(OC.Rows(0).Item("ImporteTotal").ToString()).ToString("C2")
         If Me.ugDetalle.ActiveRow.Band.Index = 0 Then
            Me.txtPorcImpPendiente.Text = Decimal.Parse(Me.ugDetalle.ActiveRow.Cells("PorcPendienteImporte").Value.ToString()).ToString()
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbRangoImporte_CheckedChanged(sender As Object, e As EventArgs) Handles chbRangoImporte.CheckedChanged
      Try
         Me.txtMinRango.Enabled = Me.chbRangoImporte.Checked
         Me.txtMaxRango.Enabled = Me.chbRangoImporte.Checked
         If Not Me.chbRangoImporte.Checked Then
            Me.txtMinRango.Text = String.Empty
            Me.txtMaxRango.Text = String.Empty
         Else
            Me.txtMaxRango.Focus()
            Me.txtMinRango.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbDiferenciasFechas_CheckedChanged(sender As Object, e As EventArgs) Handles chbDiferenciasFechas.CheckedChanged
      Try
         If Me._estaCargando Then Exit Sub
         Me.SetearColumnas()
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

#End Region
   Private Sub SetearColumnas()

      Me.ugDetalle.DisplayLayout.Bands(0).Columns("Dif").Hidden = Not Me.chbDiferenciasFechas.Checked
      Me.ugDetalle.DisplayLayout.Bands(0).Columns("Dif1").Hidden = Not Me.chbDiferenciasFechas.Checked
      Me.ugDetalle.DisplayLayout.Bands(0).Columns("Dif2").Hidden = Not Me.chbDiferenciasFechas.Checked

   End Sub

   Private Sub ugDetalle_AfterRowExpanded(sender As Object, e As RowEventArgs) Handles ugDetalle.AfterRowExpanded
      Try
         Me.ugDetalle.Selected.Rows.Clear()
         Me.ugDetalle.ActiveRow = e.Row
         Me.ugDetalle.Selected.Rows.Add(e.Row)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbOcultarFiltros_CheckedChanged(sender As Object, e As EventArgs) Handles chbOcultarFiltros.CheckedChanged
      Try
         Me.SplitContainer1.Panel1Collapsed = Not Me.chbOcultarFiltros.Checked
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub ugDetalle_AfterRowCollapsed(sender As Object, e As RowEventArgs) Handles ugDetalle.AfterRowCollapsed
      Me.ugDetalle.Selected.Rows.Clear()
      Me.ugDetalle.ActiveRow = e.Row
      Me.ugDetalle.Selected.Rows.Add(e.Row)
   End Sub

   Private Sub chbFechaAutorizacion_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaAutorizacion.CheckedChanged
      Try
         Me.dtpFechaAutorizacionDesde.Enabled = Me.chbFechaAutorizacion.Checked
         Me.dtpFechaAutorizacionHasta.Enabled = Me.chbFechaAutorizacion.Checked

         If Not Me.chbFechaAutorizacion.Checked Then
            Me.dtpFechaAutorizacionDesde.Value = DateTime.Today
            Me.dtpFechaAutorizacionHasta.Value = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
         Else
            Me.dtpFechaAutorizacionDesde.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub UltraGridExcelExporter1_ExportStarted(sender As Object, e As ExcelExport.ExportStartedEventArgs) Handles UltraGridExcelExporter1.ExportStarted
      e.Layout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
   End Sub


End Class