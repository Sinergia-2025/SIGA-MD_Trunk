Imports System.ComponentModel
Public Class PedidosInvocacionMasiva

#Region "Campos"
   Private ultraGridTMP As DataTable = Nothing
   Private _publicos As Publicos
   Private _dtDetalle As DataTable
   Private PedidosConError As Integer
   Private Const selecColumnName As String = "Proceso"

   Private _blnMiraUsuario As Boolean = True
   Private _blnMiraPC As Boolean = Not Publicos.FacturacionIgnorarPCdeCaja
   Private _blnCajasModificables As Boolean = True

   Private _titFacturas As Dictionary(Of String, String) = New Dictionary(Of String, String)()

   Public Enum ModoCambioMasivo As Integer
      <Description("Solo Actual")>
      SoloActual = 0
      Seleccionados = 1
      Todos = 2
   End Enum
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Try
         _publicos = New Publicos()
         '-- Proceso de inicializacion de Objetos.- --------------------------------
         Inicializacion()
         '--------------------------------------------------------------------------
         _publicos.CargaComboDesdeEnum(cmbTodos, GetType(Reglas.Publicos.TodosEnum))
         '--------------------------------------------------------------------------
         tbpGeneracion.Tabs("utcComprobantes").Visible = False
         '--------------------------------------------------------------------------
         gpbDatosFacturaRemitoProveedor.Visible = Reglas.Publicos.PedidosValidaFacturaRemitoProveedor
         '--------------------------------------------------------------------------
         _publicos.CargaComboCajas(cmbCajas, actual.Sucursal.IdSucursal, _blnMiraUsuario, _blnMiraPC, _blnCajasModificables)
         '--------------------------------------------------------------------------
         _titFacturas = GetColumnasVisiblesGrilla(ugvFacturas)
      Catch ex As Exception

      End Try
   End Sub
#End Region

#Region "Eventos"
   ''' <summary>
   ''' Buscador de Cliente.-
   ''' </summary>
   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      Try
         _publicos.PreparaGrillaClientes2(bscCliente)
         Dim oClientes = New Reglas.Clientes
         bscCliente.Datos = oClientes.GetFiltradoPorNombre(bscCliente.Text.Trim(), False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub bscCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         If e.FilaDevuelta IsNot Nothing Then
            CargarDatosCliente(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      Dim codigoCliente As Long = -1
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscCodigoCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         If Me.bscCodigoCliente.Text.Trim.Length > 0 Then
            codigoCliente = Long.Parse(Me.bscCodigoCliente.Text.Trim())
         End If
         Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub bscCodigoCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   ''' <summary>
   ''' Buscador de Transportista.-
   ''' </summary>
   Private Sub bscCodigoTransportista_BuscadorClick() Handles bscCodigoTransportista.BuscadorClick
      Try
         Dim vIdTrans As Long = 0
         Dim oTransportistas = New Reglas.Transportistas
         Me._publicos.PreparaGrillaTransportistas(bscCodigoTransportista)
         If Not String.IsNullOrEmpty(bscCodigoTransportista.Text) Then
            vIdTrans = Long.Parse(bscCodigoTransportista.Text)
         End If
         Me.bscCodigoTransportista.Datos = oTransportistas.GetFiltradoPorCodigo(vIdTrans, False)
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub
   Private Sub bscCodigoTransportista_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoTransportista.BuscadorSeleccion
      Try
         If e.FilaDevuelta IsNot Nothing Then
            Me.CargarDatosTransportista(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub bscNombreTransportista_BuscadorClick() Handles bscNombreTransportista.BuscadorClick
      Try
         Me._publicos.PreparaGrillaTransportistas(Me.bscNombreTransportista)
         Dim oTransportistas As Reglas.Transportistas = New Reglas.Transportistas
         Me.bscNombreTransportista.Datos = oTransportistas.GetFiltradoPorNombre(Me.bscNombreTransportista.Text.Trim(), True)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub bscNombreTransportista_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscNombreTransportista.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosTransportista(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chbFecha.CheckedChanged
      chkMesCompleto.Enabled = chbFecha.Checked
      dtpFechaDesde.Enabled = chbFecha.Checked
      dtpFechaHasta.Enabled = chbFecha.Checked
   End Sub
   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkMesCompleto.CheckedChanged
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpFechaDesde, dtpFechaHasta))
   End Sub

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      '-- Proceso de inicializacion de Objetos.- -----
      Inicializacion()
      '-----------------------------------------------
   End Sub

   Private Sub chbCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCliente.CheckedChanged
      bscCliente.Enabled = chbCliente.Checked
      bscCliente.Text = String.Empty

      bscCodigoCliente.Enabled = chbCliente.Checked
      bscCodigoCliente.Text = String.Empty
      bscCodigoCliente.Tag = Nothing
      bscCodigoCliente.Focus()
   End Sub
   Private Sub chbTransportista_CheckedChanged(sender As Object, e As EventArgs) Handles chbTransportista.CheckedChanged
      bscNombreTransportista.Enabled = chbTransportista.Checked
      bscNombreTransportista.Text = String.Empty

      bscCodigoTransportista.Enabled = chbTransportista.Checked
      bscCodigoTransportista.Text = String.Empty
      bscCodigoTransportista.Tag = Nothing
      bscCodigoTransportista.Focus()
   End Sub
   Private Sub chbOrdenCompra_CheckedChanged(sender As Object, e As EventArgs) Handles chbOrdenCompra.CheckedChanged
      txtNroOrdenCompra.Enabled = chbOrdenCompra.Checked
      txtNroOrdenCompra.Text = String.Empty
      txtNroOrdenCompra.Focus()
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      Try
         If chbOrdenCompra.Checked And String.IsNullOrWhiteSpace(txtNroOrdenCompra.Text) Then
            ShowMessage("Debe indicar el Nro. de Orden de Compra")
            txtNroOrdenCompra.Focus()
            Exit Sub
         End If

         If chbCliente.Checked And Not bscCodigoCliente.Selecciono And Not bscCliente.Selecciono Then
            ShowMessage("Debe seleccionar un Cliente")
            txtNroOrdenCompra.Focus()
            Exit Sub
         End If

         If chbTransportista.Checked And Not bscCodigoTransportista.Selecciono And Not bscNombreTransportista.Selecciono Then
            ShowMessage("Debe seleccionar un Cliente")
            txtNroOrdenCompra.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor
         tbpGeneracion.Tabs("utcPedidos").Selected = True
         '-- Invoca Proceso de Pedidos.- --
         GetInvocacionMasivaPedidos(True)
         '---------------------------------
         If Me.ugDetallePedidos.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("ATENCION: NO hay registros que cumplan con la seleccion !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
         '-------------------------------------------------------
         txtNroFacturaProveedor.Focus()
         '-------------------------------------------------------
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Close()
   End Sub

   Private Sub tsbCambiar_Click(sender As Object, e As EventArgs) Handles tsbCambiar.Click
      Try
         '-- Procedimiento para Cambio de Transportista-Comprobantes.- ----
         CambioTransportistaComprobante()
         '-----------------------------------------------------------------
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbGenerar_Click(sender As Object, e As EventArgs) Handles tsbGenerar.Click
      Try
         '-- Validacion de registros Correctos.- --------------------------
         If DirectCast(ugDetallePedidos.DataSource, DataTable).Select("Proceso = 1 AND Accion = 'X'").Count() > 0 Then
            Throw New Exception("Atencion!!! Debe verificar. Una o más filas para procesar contienen errores.")
            Exit Sub
         End If
         '-- Valida ingreso de Remito y Factura Proveedor.- ---------------
         If Reglas.Publicos.PedidosValidaFacturaRemitoProveedor Then
            '-- Valida Nro de Factura Proveedor.- -------------------------
            If String.IsNullOrEmpty(txtNroFacturaProveedor.Text) Then
               Throw New Exception("Debe Ingresar Nro de Factura de Proveedor")
               txtNroFacturaProveedor.Focus()
               Exit Sub
            End If
            '-- Valida Nro de Remito Proveedor.- --------------------------
            If String.IsNullOrEmpty(txtNroRemitoProveedor.Text) Then
               Throw New Exception("Debe Ingresar Nro de Remito de Proveedor")
               txtNroRemitoProveedor.Focus()
               Exit Sub
            End If
            '-- Valida seleccion de Caja.- --------------------------
            If cmbCajas.SelectedIndex = -1 Then
               Throw New Exception("Debe seleccionar una caja")
               cmbCajas.Focus()
               Exit Sub
            End If
         End If
         '-- Procedimiento para generacion de Comprobantes.- --------------
         GenerarPedidosInvocadosMasivos()
         '-----------------------------------------------------------------
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub ugDetallePedidos_CellChange(sender As Object, e As CellEventArgs) Handles ugDetallePedidos.CellChange
      Try
         AgregarNovedadesSeleccionadas()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub ugDetallePedidos_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugDetallePedidos.InitializeRow
      TryCatched(
         Sub()
            If e.Row.Cells("Accion").Value.ToString() = "X" Then
               e.Row.Cells("Accion").Color(Color.Yellow, Color.Yellow)
            End If
         End Sub)
   End Sub
   Private Sub btnsolicitarCAE_Click(sender As Object, e As EventArgs) Handles btnSolicitarCAE.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Using frm As SolicitarCAE = New SolicitarCAE(Integer.Parse(txtNroReparto.Text),
                                                      Integer.Parse(txtNroReparto.Text))
            '-- Carga Fecha Seleccionada.- -----
            frm._fechaDesde = dtpFechaImputacion.Value
            frm._fechaHasta = dtpFechaImputacion.Value
            '-----------------------------------
            frm.ConsultarAutomaticamente = True
            frm.IdFuncion = IdFuncion
            frm.ShowDialog(Me)
         End Using
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub btnImprimirComprobantes_Click(sender As Object, e As EventArgs) Handles btnImprimirComprobantes.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         Using frm = New ImpresionMasiva(Integer.Parse(txtNroReparto.Text),
                                         Integer.Parse(txtNroReparto.Text),
                                         Reglas.Publicos.OrganizarEntregaFiltroImpreso,
                                         dtpFechaImputacion.Value.AddDays(Reglas.Publicos.OrganizarEntregaFiltroFechaDesde),
                                         dtpFechaImputacion.Value.UltimoSegundoDelDia())

            frm.ConsultarAutomaticamente = True
            frm.ShowDialog(Me)
         End Using
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

#End Region

#Region "Marcar/Desmarcar Todos"
   Private Sub btnTodos_Click(sender As Object, e As EventArgs) Handles btnTodos.Click
      TryCatched(Sub() ugDetallePedidos.MarcarDesmarcar(cmbTodos, selecColumnName), Sub(owner) AgregarNovedadesSeleccionadas())
   End Sub
#End Region

#Region "Metodos"
   Private Sub AjustarColumnasGrillaFacturas()
      AjustarColumnasGrilla(ugvFacturas, _titFacturas)
      _titFacturas = GetColumnasVisiblesGrilla(ugvFacturas)
   End Sub

   Public Sub GenerarPedidosInvocadosMasivos()
      Try
         Dim nroReparto = New Reglas.Ventas().GenerarPedidosInvocadosMasivos(DirectCast(ugDetallePedidos.DataSource, DataTable).Select("Proceso = 1"),
                                                                             Integer.Parse(cmbCajas.SelectedValue.ToString()),
                                                                             IdFuncion:=IdFuncion,
                                                                             txtNroFacturaProveedor.Text,
                                                                             txtNroRemitoProveedor.Text,
                                                                             dtpFechaImputacion.Value)
         '-----------------------------------------------------------------------------
         tbpGeneracion.Tabs("utcComprobantes").Visible = True
         tbpGeneracion.Tabs("utcComprobantes").Selected = True
         txtNroReparto.Text = nroReparto.ToString()
         '--------------------------------------------------------------------------
         Inicializacion()
         '-- Invoca Proceso de Pedidos.- --
         GetInvocacionMasivaPedidos(False)
         '---------------------------------
         ugvFacturas.DataSource = New Reglas.Ventas().GetConsolidadoComprobantePorReparto(actual.Sucursal.IdSucursal, nroReparto, 0)
         '-- Verifica Localizar Electronicos.- ---
         btnSolicitarCAE.Visible = DirectCast(ugvFacturas.DataSource, DataTable).Select("EsElectronico= True").Count() > 0
         '---------------------------------
         AjustarColumnasGrillaFacturas()
         '---------------------------------
         MessageBox.Show("Proceso de Invocacion Masiva Finalizado Exitosamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         '-----------------------------------------------------------------------------
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Function GetRowsParaModificar(cambioMasivo As ModoCambioMasivo, cambiaReenvio As Boolean) As DataRow()
      ugDetallePedidos.UpdateData()
      If cambioMasivo = ModoCambioMasivo.SoloActual Then
         Return New DataRow() {DirectCast(ugDetallePedidos.ActiveRow.ListObject, DataRowView).Row}
      ElseIf cambioMasivo = ModoCambioMasivo.Seleccionados Then
         Return DirectCast(ugDetallePedidos.DataSource, DataTable).Select(IIf(cambiaReenvio, "Proceso = 1", "").ToString())
      ElseIf cambioMasivo = ModoCambioMasivo.Todos Then
         Dim list As New List(Of DataRow)
         ugDetallePedidos.UpdateData()
         For Each dr As UltraGridRow In ugDetallePedidos.Rows
            If dr.ListObject IsNot Nothing AndAlso TypeOf (dr.ListObject) Is DataRowView AndAlso
               DirectCast(dr.ListObject, DataRowView).Row IsNot Nothing Then
               list.Add(DirectCast(dr.ListObject, DataRowView).Row)
            End If
         Next
         Return list.ToArray()
      End If
      Return Nothing
   End Function
   ''' <summary>
   ''' Procedimiento de Cambio de Tipo de Comprobante o Transportista.- ---
   ''' </summary>
   Private Sub CambioTransportistaComprobante()
      Try
         '-- Recupera los Pedidos seleccionados.- ------------
         Dim dr As DataRow = GetDrPedidoSeleccionado()
         'DirectCast(Me.ugDetallePedidos.DataSource, DataTable).Select("Proceso = 0").Count()
         If dr Is Nothing Then
            Throw New Exception("Debe seleccionar una o más filas.")
         End If
         '----------------------------------------------------
         Me.Cursor = Cursors.WaitCursor
         '----------------------------------------------------
         Using ctc = New CambiarTransportistaComprobante()
            ctc.IdTipoComprobante = dr("IdTipoComprobante").ToString()
            ctc.Letra = dr("Letra").ToString()
            ctc.CentroEmisor = Short.Parse(dr("CentroEmisor").ToString())
            ctc.NumeroPedido = Long.Parse(dr("NumeroPedido").ToString())
            '-- Cantidad Total de Registros.- -------------------
            ctc.TotaldePedidos = ugDetallePedidos.Rows.Count()
            ctc.PedidosSeleccionados = DirectCast(Me.ugDetallePedidos.DataSource, DataTable).Select("Proceso = 1").Count()
            '----------------------------------------------------
            If ctc.PedidosSeleccionados <= 1 Then
               ctc.ComprobanteAct = dr("IdTipoComprobanteFact").ToString().IfNull
               If Not String.IsNullOrEmpty(dr("IdTransportista").ToString()) Then
                  ctc.IdRespDistAct = Integer.Parse(dr("IdTransportista").ToString())
               End If
            End If
            '-- Invoca Formulario.- -----------------------------
            If ctc.ShowDialog() = DialogResult.Cancel Then Return
            '-- Cargo los registros seleccionados.- ----------------------------------------------
            If DirectCast(ugDetallePedidos.DataSource, DataTable).Select("Proceso = 1").Count() > 0 Then
               ultraGridTMP = DirectCast(ugDetallePedidos.DataSource, DataTable).Select("Proceso = 1").CopyToDataTable()
            End If
            '-------------------------------------------------------------------------------------
            ModificaTransportistaComprobante(GetRowsParaModificar(CType(ctc.CambiosMasivos, ModoCambioMasivo), True), ctc.IdRespDist, ctc.NomTransport, ctc.Comprobante)
            '-- Invoca Proceso de Pedidos.- --
            GetInvocacionMasivaPedidos(False)
            '---------------------------------
         End Using

      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub ModificaTransportistaComprobante(filas As DataRow(), idRespDist As Integer, nomTransp As String, idTipoComprobante As String)
      Dim oPedidos = New Reglas.Pedidos()
      If idRespDist > 0 Then
         oPedidos.ModificaRespDistribucion(filas, idRespDist, nomTransp)
      End If
      If Not String.IsNullOrEmpty(idTipoComprobante) Then
         oPedidos.ModificarTComp(filas, idTipoComprobante)
      End If
   End Sub
   ''' <summary>
   ''' Recupera los Pedidos seleccionados en la grilla.-
   ''' </summary>
   ''' <returns></returns>
   Private Function GetDrPedidoSeleccionado() As DataRow
      Return ugDetallePedidos.FilaSeleccionada(Of DataRow)()
   End Function
   ''' <summary>
   ''' Procedimiento de MArcado de Grilla.- 
   ''' </summary>
   Private Sub AgregarNovedadesSeleccionadas()
      ugDetallePedidos.UpdateData()
   End Sub
   ''' <summary>
   ''' Consulta de Pedidos A Remitar.- 
   ''' </summary>
   Private Sub GetInvocacionMasivaPedidos(carga As Boolean)
      Try
         '-- Establece Formato de cursor.- --
         Me.Cursor = Cursors.WaitCursor
         '-----------------------------------
         PedidosConError = 0
         '-----------------------------------
         Dim dtResultado = New Reglas.Ventas().GetInvocacionMasivaPedidos(Reglas.Publicos.EstadoPedidoPendiente,
                                                                          If(chbOrdenCompra.Checked, Long.Parse(txtNroOrdenCompra.Text), 0),
                                                                          If(chbCliente.Checked, Long.Parse(bscCodigoCliente.Text), 0),
                                                                          If(chbTransportista.Checked, Long.Parse(bscCodigoTransportista.Text), 0),
                                                                          dtpFechaDesde.Valor(chbFecha),
                                                                          dtpFechaHasta.Valor(chbFecha))
         '-------------------------------------------
         For Each dr As DataRow In dtResultado.Rows
            Dim Accion As String = "A"
            Dim Proceso As Boolean = True
            Dim Mensaje = New StringBuilder()
            '-----------------------------------------------
            dr("ImporteNeto") = dr.Field(Of Decimal)("ImporteNeto").ToString("N2")
            '-- Valida Id de Tipo Comprobante Fact.- ------------------------------------------------------------------------
            If String.IsNullOrEmpty(dr(Entidades.Pedido.Columnas.IdTipoComprobanteFact.ToString()).ToString()) Then
               Accion = "X"
               Mensaje.AppendFormat("Pedido sin Comprobante Asociado.- ")
            End If
            '-- Valida Id de Transportista.- ------------------------------------------------------------------------
            If String.IsNullOrEmpty(dr(Entidades.Pedido.Columnas.IdTransportista.ToString()).ToString()) Then
               Accion = "X"
               Mensaje.AppendFormat("Pedido sin Transportista Asociado.- ")
            End If
            '-----------------------------------------------
            Proceso = True
            dr("Accion") = Accion
            If Accion = "X" Or Accion = "E" Then
               Proceso = False
               dr("Mensaje") = Mensaje.ToString()
               PedidosConError += 1
            End If
            If Not carga Then
               If ultraGridTMP IsNot Nothing Then
                  Proceso = ultraGridTMP.Select(String.Format("Proceso = True AND IdSucursal = {0} 
                                                                              AND IdTipoComprobante = '{1}' 
                                                                              AND Letra = '{2}' 
                                                                              AND CentroEmisor = {3} 
                                                                              AND NumeroPedido = {4}",
                                                               dr(Entidades.Pedido.Columnas.IdSucursal.ToString()),
                                                               dr(Entidades.Pedido.Columnas.IdTipoComprobante.ToString()),
                                                               dr(Entidades.Pedido.Columnas.Letra.ToString()),
                                                               dr(Entidades.Pedido.Columnas.CentroEmisor.ToString()),
                                                               dr(Entidades.Pedido.Columnas.NumeroPedido.ToString())
                                                               )).Count() > 0
               Else
                  Proceso = False
               End If
            End If
            dr("Proceso") = Proceso
         Next
         '---------------------------------------
         ugDetallePedidos.DataSource = dtResultado
         '---------------------------------------
         FormatearGrilla()
         '-- Reinicio DataRowTemporal.- -------------------------------------
         ultraGridTMP = Nothing
         '-------------------------------------------------------------------
         tssRegistros.Text = dtResultado.Rows.Count.ToString() & " Registros"
         '-- Activa Filtrado.- ----------------------------------------------
         cmbTodos.Visible = (dtResultado.Rows.Count > 0)
         btnTodos.Visible = (dtResultado.Rows.Count > 0)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   ''' <summary>
   ''' Proceso de Formateo de Grilla.- 
   ''' </summary>
   Private Sub FormatearGrilla()
      ugDetallePedidos.DisplayLayout.Bands(0).Columns("Mensaje").PerformAutoResize(PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
      With ugDetallePedidos.DisplayLayout.Bands(0)
         .Columns("IdCliente").Hidden = True
         .Columns("IdCategoriaFiscal").Hidden = True
         .Columns("IdTransportista").Hidden = True
      End With
      ugDetallePedidos.AgregarFiltroEnLinea({"IdTipoComprobante", "IdSucursal"})
   End Sub
   ''' <summary>
   ''' Proceso de inicializacion de Variables.-
   ''' </summary>
   Public Sub Inicializacion()
      '-- Desmarca todos Check.- -----------------------------
      chbFecha.Checked = False
      chkMesCompleto.Checked = False
      chbOrdenCompra.Checked = False
      chbCliente.Checked = False
      chbTransportista.Checked = False
      '-- Limpia los Buscadores.- ----------------------------
      bscCliente.Text = String.Empty
      bscCodigoCliente.Text = String.Empty
      bscCodigoTransportista.Text = String.Empty
      bscNombreTransportista.Text = String.Empty
      '-- Limpia los Text.- ------------------------
      txtNroOrdenCompra.Text = String.Empty
      '-- Establece fecha de Inicio.- ------------------------
      dtpFechaDesde.Value = Date.Today
      dtpFechaHasta.Value = Date.Today.UltimoSegundoDelDia()
      '-- Inicializa Nro de Factura y Nro de Remito.- --------
      txtNroRemitoProveedor.Text = String.Empty
      txtNroFacturaProveedor.Text = String.Empty
      '-------------------------------------------------------
      If TypeOf (ugDetallePedidos.DataSource) Is DataTable Then
         DirectCast(ugDetallePedidos.DataSource, DataTable).Rows.Clear()
      End If
      '-------------------------------------------------------
   End Sub
   ''' <summary>
   ''' Carga deatos de Buscador Transportista.-
   ''' </summary>
   ''' <param name="dr"></param>
   Private Sub CargarDatosTransportista(dr As DataGridViewRow)
      bscCodigoTransportista.Text = dr.Cells("IdTransportista").Value.ToString()
      bscNombreTransportista.Text = dr.Cells("NombreTransportista").Value.ToString()
   End Sub
   ''' <summary>
   ''' Carga datos de Buscador Clientes.- 
   ''' </summary>
   ''' <param name="dr"></param>
   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)
      bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
   End Sub



#End Region

End Class