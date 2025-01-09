Public Class AnularPedidosProv
   Implements IConParametros

#Region "Campos"

   Private _publicos As Publicos

   Dim dtsMaster_detalle As DataSet
   'Dim primeraCarga As Boolean = True
   Dim dtDetalle As DataTable
   Dim dtPedidoDetalle As DataTable
   Private _tipoTipoComprobante As String

   Private _tit As Dictionary(Of String, String) = New Dictionary(Of String, String)()
   Private _tit1 As Dictionary(Of String, String) = New Dictionary(Of String, String)()

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try
         If String.IsNullOrWhiteSpace(_tipoTipoComprobante) Then _tipoTipoComprobante = "PEDIDOSPROV"

         _tit = GetColumnasVisiblesGrilla(ugDetalle.DisplayLayout.Bands("Cabecera"))
         _tit1 = GetColumnasVisiblesGrilla(ugDetalle.DisplayLayout.Bands("Detalle"))

         cmbTiposComprobantes.Initializar(False, True, True, False, _tipoTipoComprobante)
         Me.cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()

         Me._publicos = New Publicos()

         _publicos.CargaComboDesdeEnum(Me.cmbTodos, GetType(Reglas.Publicos.TodosEnumSI))

         Me.cmbEstados.Items.Insert(0, Reglas.Publicos.PedidoProveedorEstadoNuevo) ' "PENDIENTE")
         Me.cmbEstados.SelectedIndex = 0

         Me.dtpDesde.Value = Date.Today
         Me.dtpHasta.Value = Date.Today.AddHours(23).AddMinutes(59).AddSeconds(59)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub AnularPedidos_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
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

   Private Sub tsbAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAnular.Click

      If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

      Try

         ugDetalle.UpdateData()

         Dim tablaAnular As DataTable = DirectCast(Me.ugDetalle.DataSource, DataSet).Tables("Cabecera").Clone

         Dim oPedido As Reglas.PedidosProveedores = New Reglas.PedidosProveedores()

         For Each drCabecera As DataRow In DirectCast(Me.ugDetalle.DataSource, DataSet).Tables("Cabecera").Rows
            If Boolean.Parse(drCabecera("anula").ToString) Then

               oPedido.ValidaAnulacionPedido(Integer.Parse(drCabecera(Entidades.PedidoProveedor.Columnas.IdSucursal.ToString()).ToString()),
                                             drCabecera(Entidades.PedidoProveedor.Columnas.IdTipoComprobante.ToString()).ToString(),
                                             drCabecera(Entidades.PedidoProveedor.Columnas.Letra.ToString()).ToString(),
                                             Short.Parse(drCabecera(Entidades.PedidoProveedor.Columnas.CentroEmisor.ToString()).ToString()),
                                             Long.Parse(drCabecera(Entidades.PedidoProveedor.Columnas.NumeroPedido.ToString()).ToString()))

               tablaAnular.ImportRow(drCabecera)

            End If
         Next

         If tablaAnular.Rows.Count = 0 Then
            ShowMessage(Traducciones.TraducirTexto("ATENCION: NO Seleccionó Ningún Pedido para Anular!!", Me, "__NoSeleccionoPedido"))
            Exit Sub
         End If

         oPedido.AnularPedidos(tablaAnular, _tipoTipoComprobante, IdFuncion)

         ShowMessage(Traducciones.TraducirTexto("¡¡¡ Pedido/s Anulado/s Exitosamente !!!", Me, "__AnulacionPedidoExitosa"))

         Me.btnConsultar_Click(Me.btnConsultar, New EventArgs())

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
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

   Private Sub chbProducto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbProducto.CheckedChanged
      Me.bscCodigoProducto2.Enabled = Me.chbProducto.Checked
      Me.bscProducto2.Enabled = Me.chbProducto.Checked
      If Not Me.chbProducto.Checked Then
         Me.bscCodigoProducto2.Text = String.Empty
         Me.bscProducto2.Text = String.Empty
      Else
         Me.bscCodigoProducto2.Focus()
      End If
   End Sub

   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProducto2)

         Me.bscCodigoProducto2.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS", , , )
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscProducto2)
         Me.bscProducto2.Datos = oProductos.GetPorNombre(Me.bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS", , )
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      Dim codigoProveedor As Long = -1
      Try
         Me._publicos.PreparaGrillaProveedores(Me.bscCodigoProveedor)
         Dim rProveedores As Reglas.Proveedores = New Reglas.Proveedores()
         If Me.bscCodigoProveedor.Text.Trim.Length > 0 Then
            codigoProveedor = Long.Parse(Me.bscCodigoProveedor.Text.Trim())
         End If
         Me.bscCodigoProveedor.Datos = rProveedores.GetFiltradoPorCodigo(codigoProveedor, True)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCodigoProveedor_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion
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
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub bscProveedor_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         'Try
         '    Me.Nuevo()
         'Catch ex1 As Exception
         '    MessageBox.Show(ex1.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         'End Try
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

   Private Sub chbIdPedido_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbIdPedido.CheckedChanged

      Me.txtIdPedido.Enabled = Me.chbIdPedido.Checked

      If Not Me.chbIdPedido.Checked Then
         Me.txtIdPedido.Text = String.Empty
      Else
         Me.txtIdPedido.Focus()
      End If

   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         If Me.chbProducto.Checked And Not Me.bscCodigoProducto2.Selecciono And Not Me.bscProducto2.Selecciono Then
            MessageBox.Show("ATENCION: NO seleccionó un Producto aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoProducto2.Focus()
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

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If Me.ugDetalle.Rows.Count > 0 Then

            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("ATENCION: NO hay registros que cumplan con la selección!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Exit Sub
         End If
      Catch ex As Exception
         Me.tssRegistros.Text = "0 Registros"
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub ugDetalle_ClickCell(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles ugDetalle.ClickCell

      'If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

      'If Me.ugDetalle.ActiveCell Is Nothing Then Exit Sub

      'IdEstado = Me.ugDetalle.ActiveCell.Row.Cells("IdEstado").Value.ToString()

      '' Me.txtCantidad.Text = Me.ugDetalle.ActiveCell.Row.Cells("CantEstado").Value.ToString
      ''Me.txtobs.Text = Me.ugDetalle.ActiveCell.Row.Cells("Observacion").Value.ToString

      ''Me.lblLineaSeleccionada.Text = "Pedido: " & Me.ugDetalle.ActiveCell.Row.Cells("IdPedido").Value.ToString() & " - " & _
      ''                        Me.ugDetalle.ActiveCell.Row.Cells("FechaPedido").Value.ToString() & " Estado Actual: " & Me.ugDetalle.ActiveCell.Row.Cells("IdEstado").Value.ToString()

   End Sub

   Private Sub ugDetalle_ClickCellButton(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles ugDetalle.ClickCellButton
      Try

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub
         Dim reg As Reglas.PedidosProveedores = New Reglas.PedidosProveedores()
         Dim oReportePedido As New Entidades.PedidoProveedor

         If e.Cell.Column.Header.Caption = "Ver" Then

            Dim idTipoComprobante As String = e.Cell.Row.Cells(Entidades.PedidoProveedor.Columnas.IdTipoComprobante.ToString()).Value.ToString()
            Dim letra As String = e.Cell.Row.Cells(Entidades.PedidoProveedor.Columnas.Letra.ToString()).Value.ToString()
            Dim centroEmisor As Short = Short.Parse(e.Cell.Row.Cells(Entidades.PedidoProveedor.Columnas.CentroEmisor.ToString()).Value.ToString())
            Dim numeroPedido As Long = Long.Parse(e.Cell.Row.Cells(Entidades.PedidoProveedor.Columnas.NumeroPedido.ToString()).Value.ToString())

            Dim oPedido As Entidades.PedidoProveedor = New Reglas.PedidosProveedores().GetUno(actual.Sucursal.Id, idTipoComprobante, letra, centroEmisor, numeroPedido)
            Dim impresion As ImpresionPedidosProv = New ImpresionPedidosProv()

            If e.Cell.Column.Header.Caption = "Ver" Then
               'Reporte = "Eniac.Win.PedidoV2.rdlc"
               impresion.ImprimirPedido(oPedido, True, True)
            Else
               'Reporte = "Eniac.Win.PedidoV2Detalle.rdlc"
               impresion.ImprimirPedidoDetallado(oPedido, True, True)
            End If

         End If

      Catch ex As Exception
         Me.Cursor = Cursors.Default
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub ugDetalle_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles ugDetalle.InitializeLayout
      'e.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.SummaryRow
      'e.Layout.Override.SpecialRowSeparatorAppearance.BackColor = Color.FromArgb(218, 217, 241)
      'e.Layout.Override.SpecialRowSeparatorHeight = 6
      e.Layout.Override.BorderStyleSpecialRowSeparator = UIElementBorderStyle.RaisedSoft
      e.Layout.ViewStyle = ViewStyle.MultiBand
      e.Layout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
      e.Layout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True
      'e.Layout.Scrollbars = Scrollbars.Both
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarDatosProveedor(ByVal dr As DataGridViewRow)

      Me.bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
      Me.bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString().Trim()
      Me.bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()

      Me.bscProveedor.Enabled = False
      Me.bscCodigoProveedor.Enabled = False

   End Sub

   Private Sub CargarProducto(ByVal dr As DataGridViewRow)

      Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
      Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
      Me.bscProducto2.Enabled = False
      Me.bscCodigoProducto2.Enabled = False

   End Sub

   Private Sub RefrescarDatosGrilla()

      Me.cmbEstados.SelectedIndex = 0

      Me.chbFecha.Checked = False
      Me.chbProducto.Checked = False
      Me.chbProveedor.Checked = False
      Me.chbIdPedido.Checked = False
      Me.chbOrdenCompra.Checked = False
      Me.cmbTodos.SelectedIndex = 0

      Me.cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()

      dtsMaster_detalle.Clear()

      'Limpio la Grilla.
      'If Not Me.ugDetalle.DataSource Is Nothing Then
      '   DirectCast(Me.ugDetalle.DataSource, DataSet).Tables("Cabecera").Rows.Clear()
      '   DirectCast(Me.ugDetalle.DataSource, DataSet).Tables("detalle").Rows.Clear()
      '   'Lo otro da error, por ahora es lo mejor.
      '   'Me.ugDetalle.DataSource = Nothing
      '   'primeraCarga = True
      'End If

      'IdEstado = String.Empty

      Me.cmbEstados.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()

      Dim oPedidos As Reglas.PedidosProveedores = New Reglas.PedidosProveedores()

      Dim FechaDesde As Date = Nothing
      Dim FechaHasta As Date = Nothing

      Dim idProducto As String = String.Empty
      Dim IdMarca As Integer = 0
      Dim IdRubro As Integer = 0
      Dim idSubRubro As Integer = 0
      Dim lote As String = String.Empty

      Dim numeroPedido As Integer = -1
      Dim Tamanio As Decimal = 0
      Dim OrdenCompra As Long = 0

      Dim IdProveedor As Long = 0

      Dim TipoComprobante As String = String.Empty

      Dim IdVendedor As Integer = 0

      Dim IdFormaDePago As Integer = 0
      Dim IdUsuario As String = String.Empty
      Dim Cantidad As String = String.Empty

      Dim idPed_str As String = String.Empty
      'Dim colIdPedidos As New Collection

      If Me.chbFecha.Checked Then
         FechaDesde = Me.dtpDesde.Value
         FechaHasta = Me.dtpHasta.Value
      End If

      If Me.chbProveedor.Checked Then
         IdProveedor = Long.Parse(Me.bscCodigoProveedor.Tag.ToString())
      End If

      If Me.chbIdPedido.Checked Then
         numeroPedido = Integer.Parse(Me.txtIdPedido.Text)
      End If

      If Me.chbOrdenCompra.Checked Then
         OrdenCompra = Long.Parse(Me.txtOrdenCompra.Text.ToString())
      End If

      Me.dtsMaster_detalle = New DataSet()

      dtDetalle = oPedidos.pedidosCabecera(actual.Sucursal.Id,
                                           Me.cmbEstados.Text,
                                           FechaDesde, FechaHasta,
                                           numeroPedido,
                                           idProducto,
                                           IdMarca,
                                           IdRubro,
                                           lote,
                                           IdProveedor,
                                           IdUsuario,
                                           Tamanio,
                                           IdVendedor,
                                           OrdenCompra,
                                           _tipoTipoComprobante,
                                           cmbTiposComprobantes.GetTiposComprobantes(),
                                           String.Empty, 0)

      dtDetalle.TableName = "Cabecera"
      dtsMaster_detalle.Tables.Add(dtDetalle)

      dtPedidoDetalle = oPedidos.GetPedidosDetalladoXEstadosTodos(actual.Sucursal.Id,
                                                Me.cmbEstados.Text,
                                                FechaDesde, FechaHasta,
                                                numeroPedido,
                                                idProducto,
                                                IdMarca,
                                                IdRubro,
                                                lote,
                                                IdProveedor,
                                                IdUsuario,
                                                Tamanio,
                                                IdVendedor,
                                                OrdenCompra,
                                                _tipoTipoComprobante,
                                                cmbTiposComprobantes.GetTiposComprobantes())

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

      '############################3
      Me.ugDetalle.SetDataBinding(dtsMaster_detalle, "Cabecera")
      'Me.ugDetalle.SetDataBinding(dtsMaster_detalle, "Detalle")

      Me.ugDetalle.DataSource = dtsMaster_detalle

      If Not Me.ugDetalle.DisplayLayout.Bands(0).Columns.Exists("ImprimirCab") Then
         Me.ugDetalle.DisplayLayout.Bands(0).Columns.Add("ImprimirCab", "Ver").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
         Me.ugDetalle.DisplayLayout.Bands(0).Override.ButtonStyle = UIElementButtonStyle.Button3D
         Me.ugDetalle.DisplayLayout.Bands(0).Columns("ImprimirCab").ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
         Me.ugDetalle.DisplayLayout.Bands(0).Columns("ImprimirCab").Header.VisiblePosition = 0
         Me.ugDetalle.DisplayLayout.Bands(0).Columns("ImprimirCab").Width = 30

         _tit.Add("ImprimirCab", "")

         Me.ugDetalle.DisplayLayout.Bands(0).Columns("Anula").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
         Me.ugDetalle.DisplayLayout.Bands(0).Columns("Anula").Header.VisiblePosition = 1
         Me.ugDetalle.DisplayLayout.Bands(0).Columns("Anula").Width = 40
      End If

      AjustarColumnasGrilla()

      Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

   End Sub

   Private Sub FormatearGrilla()

      ' Me.ugDetalle.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

      With Me.ugDetalle.DisplayLayout.Bands(0)

         .Columns("ImprimirCab").Width = 30

         .Columns("anula").Header.Caption = "Anula"
         .Columns("anula").Header.VisiblePosition = 1
         .Columns("anula").Width = 40
         .Columns("anula").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox

         .Columns("IdPedido").Header.Caption = "Número"
         .Columns("IdPedido").Width = 60
         .Columns("IdPedido").CellAppearance.TextHAlign = HAlign.Right
         .Columns("IdPedido").CellActivation = Activation.NoEdit

         .Columns("fechaPedido").Header.Caption = "Fecha"
         .Columns("fechaPedido").Width = 100
         .Columns("fechaPedido").Format = "dd/MM/yyyy HH:mm"
         .Columns("fechaPedido").CellAppearance.TextHAlign = HAlign.Center
         .Columns("fechaPedido").CellActivation = Activation.NoEdit

         .Columns("NombreProveedor").Header.Caption = "Proveedor"
         .Columns("NombreProveedor").Width = 200
         .Columns("NombreProveedor").CellActivation = Activation.NoEdit

         .Columns("IdUsuario").Header.Caption = "Usuario"
         .Columns("IdUsuario").Width = 80
         .Columns("IdUsuario").CellActivation = Activation.NoEdit

         .Columns("Observacion").Header.Caption = "Observación"
         .Columns("Observacion").Width = 300
         .Columns("Observacion").CellActivation = Activation.NoEdit

      End With

   End Sub

   Private Sub FormatearGrilla2()

      With Me.ugDetalle.DisplayLayout.Bands(1)

         '.Override.AllowColSizing = AllowColSizing.Free
         '.Override.ColumnAutoSizeMode = ColumnAutoSizeMode.SiblingRowsOnly ' .AutoFitStyle = AutoFitStyle.ResizeAllColumns

         .Columns("IdSucursal").Hidden = True

         .Columns("idProducto").Header.Caption = "Nro.Prod."
         .Columns("idProducto").Width = 100
         .Columns("idProducto").CellAppearance.TextHAlign = HAlign.Right
         .Columns("idProducto").CellActivation = Activation.NoEdit

         .Columns("IdPedido").Hidden = True
         .Columns("fechaPedido").Hidden = True
         .Columns("IdProveedor").Hidden = True
         .Columns("NombreProveedor").Hidden = True

         .Columns("nombreProducto").Header.Caption = "Producto"
         .Columns("nombreProducto").Width = 250
         .Columns("nombreProducto").CellActivation = Activation.NoEdit

         .Columns("tamano").Header.Caption = "Tamaño"
         .Columns("tamano").Width = 60
         .Columns("tamano").CellAppearance.TextHAlign = HAlign.Right
         .Columns("tamano").CellActivation = Activation.NoEdit

         .Columns("Orden").Hidden = True

         .Columns("Cantidad").Header.Caption = "Cant. Pedida"
         .Columns("Cantidad").Width = 80
         .Columns("Cantidad").Format = "N2"
         .Columns("Cantidad").CellAppearance.TextHAlign = HAlign.Right
         .Columns("Cantidad").CellActivation = Activation.NoEdit

         .Columns("fechaestado").Header.Caption = "Fecha Estado"
         .Columns("fechaestado").Width = 100
         .Columns("fechaestado").Format = "dd/MM/yyyy HH:mm"
         .Columns("fechaestado").CellAppearance.TextHAlign = HAlign.Center
         .Columns("fechaestado").CellActivation = Activation.NoEdit

         .Columns("IdEstado").Header.Caption = "Estado"
         .Columns("IdEstado").Width = 80
         .Columns("IdEstado").CellActivation = Activation.NoEdit

         .Columns("CantEstado").Header.Caption = "Cant. Estado"
         .Columns("CantEstado").Width = 80
         .Columns("CantEstado").Format = "N2"
         .Columns("CantEstado").CellAppearance.TextHAlign = HAlign.Right
         .Columns("CantEstado").CellActivation = Activation.NoEdit

         .Columns("cantPendiente").Header.Caption = "Cant. Pendiente"
         .Columns("cantPendiente").Width = 80
         .Columns("cantPendiente").Format = "N2"
         .Columns("cantPendiente").CellAppearance.TextHAlign = HAlign.Right
         .Columns("cantPendiente").CellActivation = Activation.NoEdit

         .Columns("idTipoComprobante").Header.Caption = "Comprobante"
         .Columns("idTipoComprobante").Width = 90
         .Columns("idTipoComprobante").CellActivation = Activation.NoEdit

         .Columns("Letra").Header.Caption = "Let."
         .Columns("Letra").Width = 40
         .Columns("Letra").CellAppearance.TextHAlign = HAlign.Center
         .Columns("Letra").CellActivation = Activation.NoEdit

         .Columns("CentroEmisor").Header.Caption = "P.V."
         .Columns("CentroEmisor").Width = 40
         .Columns("CentroEmisor").CellAppearance.TextHAlign = HAlign.Right
         .Columns("CentroEmisor").CellActivation = Activation.NoEdit

         .Columns("NumeroComprobante").Header.Caption = "Nro.Comp."
         .Columns("NumeroComprobante").Width = 70
         .Columns("NumeroComprobante").CellAppearance.TextHAlign = HAlign.Right
         .Columns("NumeroComprobante").CellActivation = Activation.NoEdit

         .Columns("IdUsuario").Header.Caption = "Usuario"
         .Columns("IdUsuario").Width = 80
         .Columns("IdUsuario").CellActivation = Activation.NoEdit

         .Columns("Observacion").Header.Caption = "Observación"
         .Columns("Observacion").Width = 200
         .Columns("Observacion").CellActivation = Activation.NoEdit

      End With

   End Sub

#End Region

   Private Overloads Sub AjustarColumnasGrilla()
      AjustarColumnasGrilla(ugDetalle.DisplayLayout.Bands("Cabecera"), _tit)
      AjustarColumnasGrilla(ugDetalle.DisplayLayout.Bands("Detalle"), _tit1)
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

   Private Sub btnTodos_Click(sender As Object, e As EventArgs) Handles btnTodos.Click
      Try
         If cmbTodos.SelectedValue IsNot Nothing AndAlso TypeOf (cmbTodos.SelectedValue) Is Reglas.Publicos.TodosEnumSI Then

            Me.Cursor = Cursors.WaitCursor

            Select Case DirectCast(cmbTodos.SelectedValue, Reglas.Publicos.TodosEnumSI)
               Case Reglas.Publicos.TodosEnumSI.MarcarTodos
                  MarcarDesmarcar(True, ugDetalle.Rows.ToArray())
                  cmbTodos.SelectedValue = Reglas.Publicos.TodosEnumSI.DesmarcarTodos

               Case Reglas.Publicos.TodosEnumSI.DesmarcarTodos
                  MarcarDesmarcar(False, ugDetalle.Rows.ToArray())
                  cmbTodos.SelectedValue = Reglas.Publicos.TodosEnumSI.MarcarTodos

               Case Reglas.Publicos.TodosEnumSI.InvertirMarcasTodos
                  MarcarDesmarcar(Nothing, ugDetalle.Rows.ToArray())

               Case Else

            End Select
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
         ugDetalle.UpdateData()
      End Try
   End Sub

   Private Sub MarcarDesmarcar(marcar As Boolean?, rows As UltraGridRow())
      For Each dr As UltraGridRow In rows
         '  If dr.Cells("CorreoElectronico").Text <> "" Then
         If marcar.HasValue Then
            dr.Cells("Anula").Value = marcar.Value
         Else
            dr.Cells("Anula").Value = Not CBool(dr.Cells("Anula").Value)
         End If
         '   End If
      Next
   End Sub

End Class