Public Class AnularPedidos
   Implements IConParametros

#Region "Campos"

   Private _publicos As Publicos

   Dim dtsMaster_detalle As DataSet
   'Dim primeraCarga As Boolean = True
   Dim dtDetalle As DataTable
   Dim dtPedidoDetalle As DataTable
   Private _tipoTipoComprobante As String
   Private _modalidadPantalla As Entidades.ModalidadPantalla = Entidades.ModalidadPantalla.Anular

   Private _tit As Dictionary(Of String, String) = New Dictionary(Of String, String)()
   Private _tit1 As Dictionary(Of String, String) = New Dictionary(Of String, String)()
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         If String.IsNullOrWhiteSpace(_tipoTipoComprobante) Then _tipoTipoComprobante = "PEDIDOSCLIE"

         cmbTiposComprobantes.Initializar(False, True, True, False, _tipoTipoComprobante)
         cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()

         _publicos = New Publicos()

         _publicos.CargaComboEmpleados(cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR, "")
         cmbVendedor.SelectedIndex = -1

         _publicos.CargaComboDesdeEnum(Me.cmbTodos, GetType(Reglas.Publicos.TodosEnumSI))

         tsbAnular.Visible = _modalidadPantalla = Entidades.ModalidadPantalla.Anular
         tsbEliminar.Visible = _modalidadPantalla = Entidades.ModalidadPantalla.Eliminar
         tsbRenumerar.Visible = _modalidadPantalla = Entidades.ModalidadPantalla.Renumerar
         tsbModificar.Visible = _modalidadPantalla = Entidades.ModalidadPantalla.Modificar

         If _modalidadPantalla = Entidades.ModalidadPantalla.Anular Then
            Me.cmbEstados.Items.Insert(0, Entidades.EstadoPedido.ESTADO_ALTA) ' "PENDIENTE")
            ugDetalle.DisplayLayout.Bands(0).Columns("anula").Header.Caption = "Anula"
         ElseIf _modalidadPantalla = Entidades.ModalidadPantalla.Eliminar Then
            Me.cmbEstados.Items.Insert(0, Entidades.EstadoPedido.ESTADO_ANULADO) ' "ANULADO")
            ugDetalle.DisplayLayout.Bands(0).Columns("anula").Header.Caption = "Elimina"
            Text = Text.Replace("Anular", "Eliminar")
         ElseIf _modalidadPantalla = Entidades.ModalidadPantalla.Renumerar Then
            Me._publicos.CargaComboEstadosPedidos(cmbEstados, True, True, True, True, False, _tipoTipoComprobante)
            ugDetalle.DisplayLayout.Bands(0).Columns("anula").Hidden = True
            Text = Text.Replace("Anular", "Renumerar")
         ElseIf _modalidadPantalla = Entidades.ModalidadPantalla.Modificar Then
            Me._publicos.CargaComboEstadosPedidos(cmbEstados, True, True, True, True, False, _tipoTipoComprobante)
            ugDetalle.DisplayLayout.Bands(0).Columns("anula").Hidden = True
            ugDetalle.DisplayLayout.Bands(0).Columns(Entidades.Pedido.Columnas.ObservacionInterna.ToString()).CellActivation = Activation.AllowEdit
            Text = Text.Replace("Anular", "Modificar")
         Else
            Throw New NotImplementedException(String.Format("Modo {0} no implementado", _modalidadPantalla.ToString()))
         End If

         Me.cmbEstados.SelectedIndex = 0

         ' Si la pantalla está en Modalidad Modificar, por default arranca en PENDIENTE
         If _modalidadPantalla = Entidades.ModalidadPantalla.Modificar Then
            Me.cmbEstados.SelectedValue = Entidades.EstadoPedido.ESTADO_ALTA
         End If

         dtpDesde.Value = Date.Today
         dtpHasta.Value = Date.Today.UltimoSegundoDelDia()

         _tit = GetColumnasVisiblesGrilla(ugDetalle.DisplayLayout.Bands("Cabecera"))
         _tit1 = GetColumnasVisiblesGrilla(ugDetalle.DisplayLayout.Bands("Detalle"))
         chbFecha.Checked = True
      End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F2 Then
         btnConsultar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function

#End Region

#Region "Eventos"

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         If chbProducto.Checked And Not bscCodigoProducto2.Selecciono And Not bscProducto2.Selecciono Then
            ShowMessage("ATENCION: NO seleccionó un Producto aunque activó ese Filtro.")
            bscCodigoProducto2.Select()
            Exit Sub
         End If

         If chbCliente.Checked And Not bscCodigoCliente.Selecciono And Not bscCliente.Selecciono Then
            ShowMessage("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro.")
            bscCodigoCliente.Select()
            Exit Sub
         End If

         If chbIdPedido.Checked AndAlso txtIdPedido.ValorNumericoPorDefecto(0I) = 0 Then
            ShowMessage(Traducciones.TraducirTexto("ATENCION: NO Ingresó un Número de Pedido aunque activó ese Filtro.", Me, "__FaltaNumeroPedido"))
            txtIdPedido.Select()
            Exit Sub
         End If

         If chbVendedor.Checked And cmbVendedor.SelectedIndex = -1 Then
            ShowMessage("ATENCION: Debe seleccionar un VENDEDOR.")
            cmbVendedor.Select()
            Exit Sub
         End If

         CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            btnConsultar.Select()
         Else
            ShowMessage("ATENCION: NO hay registros que cumplan con la selección!")
            Exit Sub
         End If
      End Sub)
   End Sub

#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub

   Private Sub tsbAnular_Click(sender As Object, e As EventArgs) Handles tsbAnular.Click
      TryCatched(
      Sub()
         If ugDetalle.Rows.Count = 0 Then Exit Sub
         ugDetalle.UpdateData()

         Dim tablaAnular = DirectCast(Me.ugDetalle.DataSource, DataSet).Tables("Cabecera").Clone

         Dim oPedido = New Reglas.Pedidos()

         For Each drCabecera As DataRow In DirectCast(ugDetalle.DataSource, DataSet).Tables("Cabecera").Rows
            If Boolean.Parse(drCabecera("anula").ToString) Then
               oPedido.ValidaAnulacionPedido(Integer.Parse(drCabecera(Entidades.Pedido.Columnas.IdSucursal.ToString()).ToString()),
                                                drCabecera(Entidades.Pedido.Columnas.IdTipoComprobante.ToString()).ToString(),
                                                drCabecera(Entidades.Pedido.Columnas.Letra.ToString()).ToString(),
                                                Short.Parse(drCabecera(Entidades.Pedido.Columnas.CentroEmisor.ToString()).ToString()),
                                                Long.Parse(drCabecera(Entidades.Pedido.Columnas.NumeroPedido.ToString()).ToString()))
               tablaAnular.ImportRow(drCabecera)
            End If
         Next

         If tablaAnular.Rows.Count = 0 Then
            ShowMessage(Traducciones.TraducirTexto("ATENCION: NO Seleccionó Ningún Pedido para Anular!!", Me, "__NoSeleccionoPedido"))
            Exit Sub
         End If

         oPedido.AnularPedidos(tablaAnular, _tipoTipoComprobante, IdFuncion)

         ShowMessage(Traducciones.TraducirTexto("¡¡¡ Pedido/s Anulado/s Exitosamente !!!", Me, "__AnulacionPedidoExitosa"))

         btnConsultar.PerformClick()
      End Sub)
   End Sub

   Private Sub tsbEliminar_Click(sender As Object, e As EventArgs) Handles tsbEliminar.Click
      TryCatched(
      Sub()
         If ugDetalle.Rows.Count = 0 Then Exit Sub
         ugDetalle.UpdateData()

         Dim tablaAnular As DataTable = DirectCast(Me.ugDetalle.DataSource, DataSet).Tables("Cabecera").Clone()
         Dim rPedido As Reglas.Pedidos = New Reglas.Pedidos()

         For Each drCabecera As DataRow In DirectCast(Me.ugDetalle.DataSource, DataSet).Tables("Cabecera").Select("anula")
            'If Boolean.Parse(drCabecera("anula").ToString) Then
            rPedido.ValidaEliminarPedido(Integer.Parse(drCabecera(Entidades.Pedido.Columnas.IdSucursal.ToString()).ToString()),
                                            drCabecera(Entidades.Pedido.Columnas.IdTipoComprobante.ToString()).ToString(),
                                            drCabecera(Entidades.Pedido.Columnas.Letra.ToString()).ToString(),
                                            Short.Parse(drCabecera(Entidades.Pedido.Columnas.CentroEmisor.ToString()).ToString()),
                                            Long.Parse(drCabecera(Entidades.Pedido.Columnas.NumeroPedido.ToString()).ToString()))

            tablaAnular.ImportRow(drCabecera)
            'End If
         Next

         If tablaAnular.Rows.Count = 0 Then
            ShowMessage(Traducciones.TraducirTexto("ATENCION: NO Seleccionó Ningún Pedido para Eliminar!!", Me, "__NoSeleccionoPedido"))
            Exit Sub
         End If

         rPedido.EliminarPedidos(tablaAnular, _tipoTipoComprobante, IdFuncion)
         ShowMessage(Traducciones.TraducirTexto("¡¡¡ Pedido/s Eliminado/s Exitosamente !!!", Me, "__AnulacionPedidoExitosa"))
         btnConsultar.PerformClick()
      End Sub)
   End Sub

   Private Sub tsbRenumerar_Click(sender As Object, e As EventArgs) Handles tsbRenumerar.Click
      TryCatched(
      Sub()
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub
         ugDetalle.UpdateData()

         Dim drCabecera = GetSelectedPedido()
         Using frm As New RenumerarPedidos()
            If frm.ShowDialog(Integer.Parse(drCabecera(Entidades.Pedido.Columnas.IdSucursal.ToString()).ToString()),
                                 drCabecera(Entidades.Pedido.Columnas.IdTipoComprobante.ToString()).ToString(),
                                 drCabecera(Entidades.Pedido.Columnas.Letra.ToString()).ToString(),
                                 Short.Parse(drCabecera(Entidades.Pedido.Columnas.CentroEmisor.ToString()).ToString()),
                                 Long.Parse(drCabecera(Entidades.Pedido.Columnas.NumeroPedido.ToString()).ToString())) = Windows.Forms.DialogResult.OK Then

               Dim rPedido = New Reglas.Pedidos()
               rPedido.RenumerarPedidos({drCabecera}, frm.NumeroComprobante, _tipoTipoComprobante, IdFuncion)

               ShowMessage(Traducciones.TraducirTexto("¡¡¡ Pedido Renumerado Exitosamente !!!", Me, "__AnulacionPedidoExitosa"))
               btnConsultar.PerformClick()
            End If
         End Using
      End Sub)
   End Sub

   Private Sub tsbModificar_Click(sender As Object, e As EventArgs) Handles tsbModificar.Click
      TryCatched(Sub() AbrePedidoParaModificar())
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub

#End Region

#Region "Eventos Filtros"
   Private Sub chbFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chbFecha.CheckedChanged
      TryCatched(Sub() chbFecha.FiltroCheckedChanged(chkMesCompleto, dtpDesde, dtpHasta))
   End Sub
   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub
   Private Sub chbIdPedido_CheckedChanged(sender As Object, e As EventArgs) Handles chbIdPedido.CheckedChanged
      TryCatched(Sub() chbIdPedido.FiltroCheckedChanged(txtIdPedido))
   End Sub

#Region "Eventos Buscador Clientes"
   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      TryCatched(Sub() chbCliente.FiltroCheckedChanged(usaPermitido:=True, bscCodigoCliente, bscCliente))
   End Sub
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick, bscCodigoCliente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes2(bscCodigoCliente)
         Dim codigoCliente = bscCodigoCliente.Text.ValorNumericoPorDefecto(-1L)
         bscCodigoCliente.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(codigoCliente, True, False)
      End Sub)
   End Sub
   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes2(bscCliente)
         bscCliente.Datos = New Reglas.Clientes().GetFiltradoPorNombre(bscCliente.Text.Trim(), False)
      End Sub)
   End Sub
   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCliente.BuscadorSeleccion
      TryCatched(Sub() CargarDatosCliente(e.FilaDevuelta))
   End Sub
#End Region

   Private Sub chbOrdenCompra_CheckedChanged(sender As Object, e As EventArgs) Handles chbOrdenCompra.CheckedChanged
      TryCatched(Sub() chbOrdenCompra.FiltroCheckedChanged(txtOrdenCompra))
   End Sub

#Region "Eventos Buscador Productos"
   Private Sub chbProducto_CheckedChanged(sender As Object, e As EventArgs) Handles chbProducto.CheckedChanged
      TryCatched(Sub() chbProducto.FiltroCheckedChanged(usaPermitido:=True, bscCodigoProducto2, bscProducto2))
   End Sub
   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscCodigoProducto2)
         bscCodigoProducto2.Datos = New Reglas.Productos().GetPorCodigo(bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS", , , )
      End Sub)
   End Sub
   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscProducto2)
         bscProducto2.Datos = New Reglas.Productos().GetPorNombre(bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS", , )
      End Sub)
   End Sub
   Private Sub bscCodigoProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion, bscProducto2.BuscadorSeleccion
      TryCatched(Sub() CargarProducto(e.FilaDevuelta))
   End Sub
#End Region

   Private Sub chbVendedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbVendedor.CheckedChanged
      TryCatched(Sub() chbVendedor.FiltroCheckedChanged(cmbVendedor))
   End Sub

#End Region

#Region "Eventos Grilla"
   Private Sub ugDetalle_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugDetalle.ClickCellButton
      TryCatched(
      Sub()
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub
         Dim reg As Reglas.Pedidos = New Reglas.Pedidos
         Dim oReportePedido As New Entidades.Pedido

         If e.Cell.Column.Header.Caption = "Ver" Then

            Dim idTipoComprobante As String = e.Cell.Row.Cells(Entidades.Pedido.Columnas.IdTipoComprobante.ToString()).Value.ToString()
            Dim letra As String = e.Cell.Row.Cells(Entidades.Pedido.Columnas.Letra.ToString()).Value.ToString()
            Dim centroEmisor As Short = Short.Parse(e.Cell.Row.Cells(Entidades.Pedido.Columnas.CentroEmisor.ToString()).Value.ToString())
            Dim numeroPedido As Long = Long.Parse(e.Cell.Row.Cells(Entidades.Pedido.Columnas.NumeroPedido.ToString()).Value.ToString())

            Dim oPedido = New Reglas.Pedidos().GetUno(actual.Sucursal.Id, idTipoComprobante, letra, centroEmisor, numeroPedido, estadoPedido:=Nothing)
            Dim impresion As ImpresionPedidos = New ImpresionPedidos()

            If e.Cell.Column.Header.Caption = "Ver" Then
               'Reporte = "Eniac.Win.PedidoV2.rdlc"
               impresion.ImprimirPedido(oPedido, True)
            Else
               'Reporte = "Eniac.Win.PedidoV2Detalle.rdlc"
               impresion.ImprimirPedidoDetallado(oPedido, True)
            End If

         End If
      End Sub)
   End Sub

   Private Sub ugDetalle_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles ugDetalle.InitializeLayout
      e.Layout.Override.BorderStyleSpecialRowSeparator = UIElementBorderStyle.RaisedSoft
      e.Layout.ViewStyle = ViewStyle.MultiBand
      e.Layout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
      e.Layout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True
   End Sub

   Private Sub ugDetalle_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles ugDetalle.AfterCellUpdate
      TryCatched(
      Sub()
         If e.Cell.Column.Key = Entidades.Pedido.Columnas.ObservacionInterna.ToString() Then
            Dim dr As DataRow = ugDetalle.FilaSeleccionada(Of DataRow)(e.Cell.Row)
            If dr IsNot Nothing Then
               If dr("ObservacionInterna").ToString() <> dr("ObservacionInterna_Original").ToString() Then
                  Dim rPedido As Reglas.Pedidos = New Reglas.Pedidos()
                  rPedido.ActualizarObservacionInterna(Integer.Parse(dr(Entidades.Pedido.Columnas.IdSucursal.ToString()).ToString()),
                                                       dr(Entidades.Pedido.Columnas.IdTipoComprobante.ToString()).ToString(),
                                                       dr(Entidades.Pedido.Columnas.Letra.ToString()).ToString(),
                                                       Short.Parse(dr(Entidades.Pedido.Columnas.CentroEmisor.ToString()).ToString()),
                                                       Long.Parse(dr(Entidades.Pedido.Columnas.NumeroPedido.ToString()).ToString()),
                                                       dr(Entidades.Pedido.Columnas.ObservacionInterna.ToString()).ToString())
                  dr("ObservacionInterna_Original") = dr("ObservacionInterna")
                  dr.Table.AcceptChanges()
               End If
            End If
         End If
      End Sub)
   End Sub
#End Region

#End Region

#Region "Metodos"

   Private Sub CargarDatosCliente(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
         bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString().Trim()
         bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()

         bscCliente.Permitido = False
         bscCodigoCliente.Permitido = False
         btnConsultar.Focus()
      End If
   End Sub

   Private Sub CargarProducto(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
         bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
         bscProducto2.Enabled = False
         bscCodigoProducto2.Enabled = False
         btnConsultar.Focus()
      End If
   End Sub

   Private Sub RefrescarDatosGrilla()

      cmbEstados.SelectedIndex = 0

      ' Si la pantalla está en Modalidad Modificar, por default arranca en PENDIENTE
      If _modalidadPantalla = Entidades.ModalidadPantalla.Modificar Then
         cmbEstados.SelectedValue = Entidades.EstadoPedido.ESTADO_ALTA
      End If

      chbFecha.Checked = True
      chbProducto.Checked = False
      chbCliente.Checked = False
      chbIdPedido.Checked = False
      chbOrdenCompra.Checked = False
      Me.cmbTodos.SelectedIndex = 0

      cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()

      chbVendedor.Checked = False

      If dtsMaster_detalle IsNot Nothing Then
         dtsMaster_detalle.Clear()
      End If

      cmbEstados.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()


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

      Dim IdCliente As Long = 0

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

      If Me.chbCliente.Checked Then
         IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
      End If

      If Me.chbIdPedido.Checked Then
         numeroPedido = Integer.Parse(Me.txtIdPedido.Text)
      End If

      If Me.chbOrdenCompra.Checked Then
         OrdenCompra = Long.Parse(Me.txtOrdenCompra.Text.ToString())
      End If


      If Me.chbVendedor.Checked Then
         IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado
      End If

      dtsMaster_detalle = New DataSet()

      Dim rPedidos = New Reglas.Pedidos()
      dtDetalle = rPedidos.pedidosCabecera(actual.Sucursal.Id,
                                           cmbEstados.Text, alMenosUno_TodosSean:=_modalidadPantalla <> Entidades.ModalidadPantalla.Eliminar,
                                           FechaDesde, FechaHasta,
                                           cmbTiposComprobantes.GetTiposComprobantes(),
                                           letra:="",
                                           centroEmisor:=0,
                                           numeroPedidoDesde:=numeroPedido,
                                           numeroPedidoHasta:=numeroPedido,
                                           idProducto:=idProducto,
                                           idCliente:=IdCliente,
                                           idUsuario:=IdUsuario,
                                           idVendedor:=IdVendedor,
                                           tipoVendedor:=Entidades.OrigenFK.Actual,
                                           ordenCompra:=OrdenCompra,
                                           tipoTipoComprobante:=_tipoTipoComprobante,
                                           idProveedor:=0,
                                           categorias:={},
                                           origenCategorias:=Entidades.OrigenFK.Actual,
                                           numeroReparto:=0,
                                           numeroRepartoHasta:=0,
                                           idFormasPago:=0,
                                           idListaPrecios:=-1,
                                           impreso:=Entidades.Publicos.SiNoTodos.TODOS)

      dtDetalle.TableName = "Cabecera"
      dtsMaster_detalle.Tables.Add(dtDetalle)


      dtPedidoDetalle = rPedidos.GetPedidosDetalladoXEstadosTodos(actual.Sucursal.Id,
                                                cmbEstados.Text,
                                                If(_modalidadPantalla = Entidades.ModalidadPantalla.Eliminar, FechaHasta.AddDays(1), FechaDesde), FechaHasta,
                                                cmbTiposComprobantes.GetTiposComprobantes(),
                                                "", 0,
                                                numeroPedido,
                                                numeroPedido,
                                                idProducto,
                                                IdMarca,
                                                IdRubro,
                                                lote,
                                                IdCliente,
                                                IdUsuario,
                                                Tamanio,
                                                IdVendedor,
                                                Entidades.OrigenFK.Actual,
                                                OrdenCompra,
                                                _tipoTipoComprobante,
                                                0,
                                                categorias:={},
                                                origenCategorias:=Entidades.OrigenFK.Actual,
                                                numeroReparto:=0,
                                                numeroRepartoHasta:=0,
                                                idFormasPago:=0,
                                                idListaPrecios:=-1,
                                                mostrarAnulacionesPorModificacion:=False)

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
      ugDetalle.SetDataBinding(dtsMaster_detalle, "Cabecera")
      'Me.ugDetalle.SetDataBinding(dtsMaster_detalle, "Detalle")

      ugDetalle.DataSource = dtsMaster_detalle

      If Not ugDetalle.DisplayLayout.Bands(0).Columns.Exists("ImprimirCab") Then
         ugDetalle.DisplayLayout.Bands(0).Columns.Add("ImprimirCab", "Ver").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
         ugDetalle.DisplayLayout.Bands(0).Override.ButtonStyle = UIElementButtonStyle.Button3D
         ugDetalle.DisplayLayout.Bands(0).Columns("ImprimirCab").ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
         ugDetalle.DisplayLayout.Bands(0).Columns("ImprimirCab").Header.VisiblePosition = 0
         ugDetalle.DisplayLayout.Bands(0).Columns("ImprimirCab").Width = 30

         _tit.Add("ImprimirCab", "")

         ugDetalle.DisplayLayout.Bands(0).Columns("Anula").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
         ugDetalle.DisplayLayout.Bands(0).Columns("Anula").Header.VisiblePosition = 1
         ugDetalle.DisplayLayout.Bands(0).Columns("Anula").Width = 40
      End If

      AjustarColumnasGrilla()

      Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

   End Sub

   Private Overloads Sub AjustarColumnasGrilla()
      AjustarColumnasGrilla(ugDetalle.DisplayLayout.Bands("Cabecera"), _tit)
      AjustarColumnasGrilla(ugDetalle.DisplayLayout.Bands("Detalle"), _tit1)
   End Sub

   Private Function GetSelectedPedido() As DataRow
      Dim result As DataRow = Nothing

      If ugDetalle.Rows.Count > 0 Then
         Dim ugr As UltraGridRow = ugDetalle.ActiveRow

         While ugr.Band.Index > 0
            ugr = ugr.ParentRow
         End While

         If ugr IsNot Nothing AndAlso
            ugr.ListObject IsNot Nothing AndAlso
            TypeOf (ugr.ListObject) Is DataRowView AndAlso
            DirectCast(ugr.ListObject, DataRowView).Row IsNot Nothing Then
            result = DirectCast(ugr.ListObject, DataRowView).Row
         End If
      End If
      Return result
   End Function

   Private Sub AbrePedidoParaModificar()
      Dim dr As DataRow = GetSelectedPedido()
      If dr IsNot Nothing Then
         Dim oPedido = New Reglas.Pedidos().GetUno(Integer.Parse(dr(Entidades.Pedido.Columnas.IdSucursal.ToString()).ToString()),
                                                   dr(Entidades.Pedido.Columnas.IdTipoComprobante.ToString()).ToString(),
                                                   dr(Entidades.Pedido.Columnas.Letra.ToString()).ToString(),
                                                   Short.Parse(dr(Entidades.Pedido.Columnas.CentroEmisor.ToString()).ToString()),
                                                   Long.Parse(dr(Entidades.Pedido.Columnas.NumeroPedido.ToString()).ToString()),
                                                   estadoPedido:=Nothing)
         Using frmPedidos As PedidosClientesV2 = New PedidosClientesV2()
            frmPedidos.IdFuncion = IdFuncion
            frmPedidos.SetParametros(_tipoTipoComprobante)
            frmPedidos.ModificarPedido(oPedido, False, Me, Nothing)
         End Using
         Me.btnConsultar.PerformClick()
      Else
         Throw New Exception(Traducciones.TraducirTexto("Por favor seleccione un pedido.", Me, "__NoSeleccionoPedidoModificar"))
      End If
   End Sub

#End Region

   Public Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
      Dim split As String() = parametros.Split("|"c)
      _tipoTipoComprobante = split(0)
      If split.Length > 1 Then
         Select Case split(1)
            Case "ANULAR"
               _modalidadPantalla = Entidades.ModalidadPantalla.Anular
            Case "ELIMINAR"
               _modalidadPantalla = Entidades.ModalidadPantalla.Eliminar
            Case "RENUMERAR"
               _modalidadPantalla = Entidades.ModalidadPantalla.Renumerar
            Case "MODIFICAR"
               _modalidadPantalla = Entidades.ModalidadPantalla.Modificar
            Case Else
               'No cambiamos comportamiento estandar
         End Select
      End If
   End Sub
   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Return "Pendiente documentar"
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