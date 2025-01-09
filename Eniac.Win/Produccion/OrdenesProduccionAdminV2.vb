Public Class OrdenesProduccionAdminV2
   Private Const seleccionMasivoColumnName As String = "masivo"

#Region "Campos"

   Private _publicos As Publicos
   Private _idEstado As String = String.Empty
   Private _idTipoEstado As String = String.Empty
   Private _idCriticidad As String = String.Empty
   Private _fechaEntrega As Date? = Nothing

   Private _tipoTipoComprobante As String

   Private _cache As Reglas.BusquedasCacheadas

   Private _tit As Dictionary(Of String, String)

   Private _cargaComboDestino As Boolean = True

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         _cache = New Reglas.BusquedasCacheadas()

         _publicos.CargaComboEstadosOrdenesProduccion(cmbEstados, True, True, True, False, String.Empty)
         cmbEstados.SelectedIndex = 1  'SOLO PENDIENTES

         If String.IsNullOrWhiteSpace(_tipoTipoComprobante) Then _tipoTipoComprobante = Entidades.TipoComprobante.Tipos.PRODUCCION.ToString()

         ''''_publicos.CargaComboCriticidadesOP(cmbCriticidad)
         _publicos.CargaComboDesdeEnum(cmbTodos, GetType(Reglas.Publicos.TodosEnum))
         _publicos.CargaComboEmpleados(cmbResponsable, Entidades.Publicos.TiposEmpleados.RESPPROD)
         'cmbResponsable.SelectedIndex = -1

         cmbTiposComprobantes.Initializar(False, True, True, False, _tipoTipoComprobante, defaultValue:=Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString())

         cmbMarcas.Inicializar(permiteSinSeleccion:=False, seleccionMultiple:=True, seleccionTodos:=True)
         cmbRubros.Inicializar(permiteSinSeleccion:=False, seleccionMultiple:=True, seleccionTodos:=True)

         pnlModelos.Visible = Reglas.Publicos.ProductoTieneModelo
         pnlSubRubros.Visible = Reglas.Publicos.ProductoTieneSubRubro
         pnlSubSubRubros.Visible = Reglas.Publicos.ProductoTieneSubSubRubro

         With ugDetalle.DisplayLayout.Bands(0)
            '.Columns("NombreModelo").Hidden = Not Reglas.Publicos.ProductoTieneModelo
            '.Columns("NombreSubRubro").Hidden = Not Reglas.Publicos.ProductoTieneSubRubro
            '.Columns("NombreSubSubRubro").Hidden = Not Reglas.Publicos.ProductoTieneSubSubRubro
         End With

         dtpDesde.Value = Date.Today
         dtpHasta.Value = Date.Today.UltimoSegundoDelDia()

         _cargaComboDestino = True
         ''''_publicos.CargaComboEstadosOrdenesProduccion(cmbEstadoCambiar, False, False, False, False, String.Empty)
         '''''-- Carga Combos de Depositos-Ubicaciones.-
         ''''_publicos.CargaComboDepositos(cmbDepositos, actual.Sucursal.IdSucursal, miraUsuario:=True, PermiteEscritura:=True, disponibleventa:=True)
         _cargaComboDestino = False
         ''''If cmbDepositos.Items.Count > 0 Then cmbDepositos.SelectedIndex = 0
         ''''_publicos.CargaComboUbicaciones(cmbUbicacion, cmbDepositos.ValorSeleccionado(Of Integer), actual.Sucursal.IdSucursal)
         ''''If cmbUbicacion.Items.Count > 0 Then cmbUbicacion.SelectedIndex = 0

         'Da la posibilidad de que podamos elegir las columnas que queremos mostrar u ocultar con un botón a la izquierda de la cabecera.
         ugDetalle.DisplayLayout.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.ColumnChooserButton

         ugDetalle.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
         ''''cmbEstadoCambiar.SelectedIndex = 0

         _tit = GetColumnasVisiblesGrilla(ugDetalle)

         ugDetalle.AgregarFiltroEnLinea({"NombreCliente", "NombreProducto", "observacion"}, {"ClipArchivoAdjunto"})

         ''''HabilitaDetalle()

         ugDetalle.AgregarTotalesSuma({"cantEntregada", "cantPendiente"})
      End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F3 Then
         btnConsultar.PerformClick()
      ElseIf keyData = Keys.F4 Then
         tsbCambiar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
#End Region

#Region "Eventos"

#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub
   Private Sub tsbCambiar_Click(sender As Object, e As EventArgs) Handles tsbCambiar.Click
      TryCatched(
      Sub()
         ugDetalle.UpdateData()
         If True Then 'Validar() Then
            Using frm = New OrdenesProduccionAdminV2Cambiar(_cache)
               Dim drs = ugDetalle.DataSource(Of DataTable).Where(Function(dr) CBool(dr.Field(Of Boolean)("Masivo")))
               If drs.AnySecure() Then
                  If frm.ShowDialog(Me, _tipoTipoComprobante, drs.CopyToDataTable()) = DialogResult.OK Then
                     btnConsultar.PerformClick()
                  End If
               Else
                  ShowMessage("Debe seleccionar al menos un Pedido.")
               End If
            End Using
         End If
      End Sub)
   End Sub
   Private Sub tsbModificarOrdenProduccion_Click(sender As Object, e As EventArgs) Handles tsbModificarPedido.Click
      TryCatched(
      Sub()
         Dim dr = ugDetalle.FilaSeleccionada(Of DataRow)
         If dr IsNot Nothing Then
            Dim ordProduccion = New Reglas.OrdenesProduccion().GetUno(dr.Field(Of Integer)(Entidades.OrdenProduccion.Columnas.IdSucursal.ToString()),
                                                                      dr.Field(Of String)(Entidades.OrdenProduccion.Columnas.IdTipoComprobante.ToString()),
                                                                      dr.Field(Of String)(Entidades.OrdenProduccion.Columnas.Letra.ToString()),
                                                                      dr.Field(Of Integer)(Entidades.OrdenProduccion.Columnas.CentroEmisor.ToString()),
                                                                      dr.Field(Of Integer)(Entidades.OrdenProduccion.Columnas.NumeroOrdenProduccion.ToString()))
            Using frmOrdenesProduccion = New OrdenesDeProduccion()
               frmOrdenesProduccion.ModificarOrdenProduccion(ordProduccion, Me)
            End Using

            btnConsultar.PerformClick()
         Else
            Throw New Exception("Por favor seleccione una Orden Producción.")
         End If
      End Sub)
   End Sub
   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(Sub() ugDetalle.Imprimir(CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True}))
   End Sub
   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridExcelExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridDocumentExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

#Region "Eventos Filtros"
   Private Sub chbResponsable_CheckedChanged(sender As Object, e As EventArgs) Handles chbResponsable.CheckedChanged
      TryCatched(Sub() chbResponsable.FiltroCheckedChanged(cmbResponsable))
   End Sub
   Private Sub chbFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chbFecha.CheckedChanged
      TryCatched(Sub() chbFecha.FiltroCheckedChanged(chkMesCompleto, dtpDesde, dtpHasta))
   End Sub
   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub
   Private Sub chbOrdenCompra_CheckedChanged(sender As Object, e As EventArgs) Handles chbOrdenCompra.CheckedChanged
      TryCatched(Sub() chbOrdenCompra.FiltroCheckedChanged(txtOrdenCompra))
   End Sub
#Region "Eventos Buscador Clientes"
   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      TryCatched(Sub() chbCliente.FiltroCheckedChanged(usaPermitido:=True, bscCodigoCliente, bscCliente))
   End Sub
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick, bscCodigoCliente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes(bscCodigoCliente)
         Dim codigoCliente = bscCodigoCliente.Text.ValorNumericoPorDefecto(-1L)
         bscCodigoCliente.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(codigoCliente, True, False)
      End Sub)
   End Sub
   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes(bscCliente)
         bscCliente.Datos = New Reglas.Clientes().GetFiltradoPorNombre(bscCliente.Text.Trim(), True)
      End Sub)
   End Sub
   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCliente.BuscadorSeleccion
      TryCatched(Sub() CargarDatosCliente(e.FilaDevuelta))
   End Sub
#End Region
   Private Sub chbIdPedido_CheckedChanged(sender As Object, e As EventArgs) Handles chbIdPedido.CheckedChanged
      TryCatched(Sub() chbIdPedido.FiltroCheckedChanged(txtIdPedido))
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
   Private Sub chbTamanio_CheckedChanged(sender As Object, e As EventArgs) Handles chbTamanio.CheckedChanged
      TryCatched(Sub() chbTamanio.FiltroCheckedChanged(txtTamanio, String.Empty, "0.000"))
   End Sub

   Private Sub cmbMarcas_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMarcas.AfterSelectedIndexChanged
      TryCatched(
      Sub()
         Dim marcas = cmbMarcas.GetMarcas(todosVacio:=True)
         cmbModelos.ConcatenarNombreMarca = marcas.CountSecure() <> 1
         cmbModelos.Inicializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=True, marcas:=marcas)
      End Sub)
   End Sub
   Private Sub cmbRubros_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRubros.AfterSelectedIndexChanged
      TryCatched(
      Sub()
         Dim rubros = cmbRubros.GetRubros(todosVacio:=True)
         cmbSubRubros.ConcatenarNombreRubro = rubros.CountSecure() <> 1
         cmbSubRubros.Inicializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=True, rubros:=rubros)
      End Sub)
   End Sub
   Private Sub cmbSubRubros_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSubRubros.AfterSelectedIndexChanged
      TryCatched(
      Sub()
         Dim subRubros = cmbSubRubros.GetSubRubros(todosVacio:=True)
         cmbSubSubRubros.ConcatenarNombreSubRubro = subRubros.CountSecure() <> 1
         cmbSubSubRubros.Inicializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=True, subRubro:=subRubros)
      End Sub)

   End Sub
#End Region

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         If chbProducto.Checked And Not bscCodigoProducto2.Selecciono And Not bscProducto2.Selecciono Then
            ShowMessage("ATENCION: NO seleccionó un Producto aunque activó ese Filtro.")
            bscCodigoProducto2.Focus()
            Exit Sub
         End If
         If chbCliente.Checked And Not bscCodigoCliente.Selecciono And Not bscCliente.Selecciono Then
            ShowMessage("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro.")
            bscCodigoCliente.Focus()
            Exit Sub
         End If
         If chbIdPedido.Checked AndAlso txtIdPedido.ValorNumericoPorDefecto(0I) = 0 Then
            ShowMessage("ATENCION: NO Ingresó un Número de Orden de Produccion aunque activó ese Filtro.")
            txtIdPedido.Focus()
            Exit Sub
         End If
         If chbTamanio.Checked AndAlso txtTamanio.ValorNumericoPorDefecto(0L) = 0 Then
            ShowMessage("ATENCION: NO Ingresó un Tamaño aunque activó ese Filtro.")
            txtTamanio.Focus()
            Exit Sub
         End If

         chkExpandAll.Enabled = True
         chkExpandAll.Checked = False

         CargaGrillaDetalle()
         ''''HabilitaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            ugDetalle.ActiveRow = ugDetalle.Rows(0)
            ugDetalle.ActiveCell = ugDetalle.ActiveRow.Cells("IdEstado")
            btnConsultar.Focus()
         Else
            ShowMessage("ATENCION: NO hay registros que cumplan con la selección!")
         End If
      End Sub)
   End Sub

   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      TryCatched(Sub() ugDetalle.ColapsarExpandir(chkExpandAll))
   End Sub

#Region "Marcar/Desmarcar Todos"
   Private Sub btnTodos_Click(sender As Object, e As EventArgs) Handles btnTodos.Click
      TryCatched(Sub() ugDetalle.MarcarDesmarcar(cmbTodos, seleccionMasivoColumnName)) '''',
      ''''onFinallyAction:=Sub(owner) HabilitaDetalle())
   End Sub
#End Region
   Private Sub ugDetalle_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugDetalle.InitializeRow
      TryCatched(
      Sub()
         Dim dr = e.Row.FilaSeleccionada(Of DataRow)
         If dr IsNot Nothing Then
            Select Case dr.Field(Of String)("IdTipoEstado")

               Case Entidades.EstadoOrdenProduccion.TipoEstado.PENDIENTE
                  e.Row.Cells("Color").Color(Color.Red, Color.Red)
               Case Entidades.EstadoOrdenProduccion.TipoEstado.ENPROCESO
                  e.Row.Cells("Color").Color(Color.Blue, Color.Blue)
               Case Entidades.EstadoOrdenProduccion.TipoEstado.ANULADO
                  e.Row.Cells("Color").Color(Color.Yellow, Color.Yellow)
               Case Entidades.EstadoOrdenProduccion.TipoEstado.FINALIZADO
                  e.Row.Cells("Color").Color(Color.Green, Color.Green)

            End Select
         End If
      End Sub)
   End Sub

   '''''Ademas de tomar el CLIC sobre la fila, toma el desplazamiento con las flechas!!! 
   '''''Private Sub ugDetalle_ClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles ugDetalle.ClickCell
   ''''Private Sub ugDetalle_AfterCellActivate(sender As Object, e As EventArgs) Handles ugDetalle.AfterCellActivate
   ''''   TryCatched(
   ''''   Sub()

   ''''      If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

   ''''      If Me.ugDetalle.ActiveCell Is Nothing Then Exit Sub

   ''''      _idEstado = Me.ugDetalle.ActiveCell.Row.Cells("IdEstado").Value.ToString()
   ''''      _idTipoEstado = Me.ugDetalle.ActiveCell.Row.Cells("idTipoEstado").Value.ToString()
   ''''      _idCriticidad = Me.ugDetalle.ActiveCell.Row.Cells("IdCriticidad").Value.ToString()

   ''''      Try
   ''''         _fechaEntrega = DirectCast(Me.ugDetalle.ActiveCell.Row.Cells("FechaEntrega").Value, Date?)
   ''''      Catch ex As Exception
   ''''         _fechaEntrega = Nothing
   ''''      End Try

   ''''      ''''Me.txtCantidad.Text = Me.ugDetalle.ActiveCell.Row.Cells("CantEntregada").Value.ToString
   ''''      ''''Me.cmbCriticidad.SelectedValue = _idCriticidad
   ''''      ''''Me.cmbEstadoCambiar.SelectedValue = _idEstado


   ''''      ''''If _fechaEntrega IsNot Nothing Then
   ''''      ''''   dtpFechaEntrega.Value = _fechaEntrega.Value
   ''''      ''''Else
   ''''      ''''   dtpFechaEntrega.Value = Today.Date
   ''''      ''''End If
   ''''   End Sub)

   ''''End Sub

   ''''Private Sub cmdMasivo_Click(sender As Object, e As EventArgs)
   ''''   TryCatched(
   ''''   Sub()

   ''''      Dim cache = New Reglas.BusquedasCacheadas()

   ''''      Dim mensage As String = String.Empty
   ''''      Dim tablaGrabar As DataTable = DirectCast(Me.ugDetalle.DataSource, DataTable).Clone
   ''''      Dim graba As Boolean = True
   ''''      Dim cantTotalProducto As Decimal = 0

   ''''      Dim estadoSeleccionado As Entidades.EstadoOrdenProduccion
   ''''      estadoSeleccionado = cache.BuscaEstadosOrdenesProduccion(cmbEstadoCambiar.Text)

   ''''      If cmbResponsable.SelectedIndex = -1 Then
   ''''         ShowMessage("Debe seleccionar un responsable de Producción, por Favor Verificar!!!")
   ''''         Exit Sub
   ''''      End If
   ''''      'If cmbResponsable.Items.Count = 0 Then
   ''''      '   MessageBox.Show("No se ha asignado un responsable de Produccion, por Favor Verificar!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   ''''      '   Exit Sub
   ''''      'End If


   ''''      If estadoSeleccionado.ReservaMateriaPrima And estadoSeleccionado.IdDeposito = 0 Then
   ''''         ShowMessage(String.Format("El estado {0}, reserva materia Prima. Debe seleccionar Deposito y Ubicacion Por Defecto.", cmbEstadoCambiar.Text))
   ''''         Exit Sub
   ''''      End If

   ''''      Dim estadoPedido As Entidades.EstadoPedido
   ''''      estadoPedido = cache.BuscaEstadosPedido(estadoSeleccionado.IdEstadoPedido, "PEDIDOSCLIE")

   ''''      If estadoSeleccionado.GeneraProductoTerminado And estadoPedido Is Nothing Then
   ''''         ShowMessage(String.Format("El estado pedido {0}, no existe en la tabla Estados Pedidos.", estadoSeleccionado.IdEstadoPedido))
   ''''         Exit Sub
   ''''      End If

   ''''      For Each fila As DataRow In DirectCast(Me.ugDetalle.DataSource, DataTable).Rows
   ''''         If Boolean.Parse(fila(seleccionMasivoColumnName).ToString) Then


   ''''            ''idem cambiar comun!!!
   ''''            If _idEstado = Me.cmbEstadoCambiar.Text Then

   ''''               _idCriticidad = fila("IdCriticidad").ToString()

   ''''               Try
   ''''                  _fechaEntrega = DirectCast(fila("FechaEntrega"), Date?)
   ''''               Catch ex As Exception
   ''''                  _fechaEntrega = Nothing
   ''''               End Try

   ''''               If _idCriticidad = cmbCriticidad.Text AndAlso _fechaEntrega = dtpFechaEntrega.Value Then
   ''''                  mensage += "Orden de Produccion: " & fila("numeroOrdenProduccion").ToString & " -->El Estado a cambiar debe ser distinto al Estado Actual del OrdenProduccion o cambiar Criticidad/Fecha de Entrega." & vbCrLf
   ''''                  graba = False
   ''''               End If

   ''''            End If

   ''''            If txtCantidad.Enabled Then
   ''''               Dim cantidadNueva As Decimal = 0
   ''''               Dim cantidadEstado As Decimal = 0
   ''''               If IsNumeric(txtCantidad.Text) Then cantidadNueva = Decimal.Parse(txtCantidad.Text)
   ''''               If IsNumeric(fila("CantPendiente")) Then cantidadEstado = Decimal.Parse(fila("CantPendiente").ToString())
   ''''               If cantidadNueva > cantidadEstado Then
   ''''                  mensage += String.Format("Orden de Produccion: {0} --> La cantidad Involucrada supera la Cantidad Pendiente.", fila("NumeroOrdenProduccion")) & vbCrLf
   ''''                  graba = False
   ''''               End If
   ''''            End If

   ''''            'idEstado = oEstado.GetIdEstadosXTipo(fila("IdEstado").ToString).Rows(0)("idEstado").ToString

   ''''            If _idTipoEstado = Entidades.EstadoOrdenProduccion.TipoEstado.ANULADO Or _idTipoEstado = Entidades.EstadoOrdenProduccion.TipoEstado.FINALIZADO Then
   ''''               mensage += "Orden Produccion: " & fila("numeroOrdenProduccion").ToString & " --> El Estado Actual NO permite cambio." & vbCrLf
   ''''               graba = False
   ''''            End If

   ''''            'Se toma la cantidad Pendiente.
   ''''            'If idTipoEstado = "PENDIENTE" And Decimal.Parse(Me.txtCantidad.Text) > Decimal.Parse(fila("CantPendiente").ToString()) Then
   ''''            '   mensage += "Pedido: " & fila("idpedido").ToString & " --> La Cantidad Involucrada supera la Cantidad Pendiente." & vbCrLf
   ''''            '   graba = False
   ''''            'End If

   ''''            'If idTipoEstado <> "PENDIENTE" And Decimal.Parse(Me.txtCantidad.Text) <> Decimal.Parse(fila("CantEntregada").ToString()) Then
   ''''            '   mensage += "Pedido: " & fila("idpedido").ToString & " --> La Cantidad Involucrada es Distinta a la Seleccionada." & vbCrLf
   ''''            '   graba = False
   ''''            'End If
   ''''            If estadoSeleccionado.GeneraProductoTerminado Then
   ''''               fila.SetField("IdDepositoDefecto", Integer.Parse(cmbDepositos.SelectedValue.ToString()))
   ''''               fila.SetField("NombreDeposito", String.Empty)
   ''''               fila.SetField("IdUbicacionDefecto", Integer.Parse(cmbUbicacion.SelectedValue.ToString()))
   ''''               fila.SetField("NombreUbicacion", String.Empty)
   ''''            End If

   ''''            If graba Then tablaGrabar.ImportRow(fila)

   ''''            graba = True

   ''''         End If
   ''''      Next
   ''''      If Not String.IsNullOrEmpty(mensage) Then
   ''''         MessageBox.Show(mensage, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   ''''         Exit Sub
   ''''      ElseIf tablaGrabar.Rows.Count = 0 Then
   ''''         MessageBox.Show("No se han seleccionado filas para el cambio masivo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   ''''         Exit Sub
   ''''      End If

   ''''      Dim respuesta As DialogResult

   ''''      respuesta = ShowPregunta(String.Format(Traducciones.TraducirTexto("¿Desea cambiar masivamente el Estado actual de los Pedidos Seleccionados al Estado: {0}?", Me, "__CambioEstadoMasivo"),
   ''''                                             Me.cmbEstadoCambiar.Text))

   ''''      'If MessageBox.Show("Desea cambiar masivamente el Estado actual de los OrdenesProduccion Seleccionados al Estado: " & Me.cmbEstadoCambiar.Text, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
   ''''      If respuesta = Windows.Forms.DialogResult.Yes Then

   ''''         Dim regla As Reglas.OrdenesProduccionEstados = New Reglas.OrdenesProduccionEstados()

   ''''         Dim cantidad As Decimal? = Nothing
   ''''         If txtCantidad.Enabled AndAlso IsNumeric(txtCantidad.Text) Then cantidad = Decimal.Parse(txtCantidad.Text)

   ''''         regla.ActualizarEstadoOrdenProduccionMasivo(actual.Sucursal.Id,
   ''''                                                     cmbEstadoCambiar.Text,
   ''''                                                     actual.Nombre,
   ''''                                                     txtObservacion.Text,
   ''''                                                     cmbCriticidad.Text,
   ''''                                                     dtpFechaEntrega.Value,
   ''''                                                     cantidad,
   ''''                                                     tablaGrabar,
   ''''                                                     Entidades.Entidad.MetodoGrabacion.Automatico,
   ''''                                                     IdFuncion)

   ''''         MessageBox.Show("Estado/s actualizado/s Exitosamente !!.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

   ''''         CargaGrillaDetalle()
   ''''         HabilitaDetalle()
   ''''      End If
   ''''   End Sub)
   ''''End Sub

   ''''Private Sub txtObservacion_KeyDown(sender As Object, e As KeyEventArgs)
   ''''   PresionarTab(e)
   ''''End Sub

   ''''Private Sub cmdCancel_Click(sender As Object, e As EventArgs)
   ''''   cmbEstadoCambiar.SelectedIndex = 0
   ''''End Sub

   ''''Private Sub txtCantidad_GotFocus(sender As Object, e As EventArgs)
   ''''   txtCantidad.SelectAll()
   ''''End Sub

   ''''Private Sub ugDetalle_CellChange(sender As Object, e As CellEventArgs) Handles ugDetalle.CellChange
   ''''   ugDetalle.UpdateData()
   ''''   HabilitaDetalle()
   ''''End Sub




   ''''Private Sub cmbEstadoCambiar_SelectedValueChanged(sender As Object, e As EventArgs)
   ''''   TryCatched(
   ''''   Sub()
   ''''      If Not _cargaComboDestino Then
   ''''         Dim cache = New Reglas.BusquedasCacheadas()
   ''''         Dim estadoSeleccionado = cache.BuscaEstadosOrdenesProduccion(cmbEstadoCambiar.Text)
   ''''         pnlDepositoUbicacion.Visible = estadoSeleccionado.GeneraProductoTerminado
   ''''      End If
   ''''   End Sub)
   ''''End Sub

   ''''Private Sub cmbDepositos_SelectedIndexChanged(sender As Object, e As EventArgs)
   ''''   TryCatched(
   ''''   Sub()
   ''''      If Not _cargaComboDestino Then
   ''''         Dim dr = cmbDepositos.ItemSeleccionado(Of DataRow)()
   ''''         If dr IsNot Nothing Then
   ''''            _publicos.CargaComboUbicaciones(cmbUbicacion, dr.Field(Of Integer)("IdDeposito"), dr.Field(Of Integer)("IdSucursal"))
   ''''            cmbUbicacion.SelectedIndex = 0
   ''''         End If
   ''''      End If
   ''''   End Sub)
   ''''End Sub

   'Private Sub ugDetalle_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles ugDetalle.InitializeLayout
   '   e.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.SummaryRow
   '   e.Layout.Override.SpecialRowSeparatorAppearance.BackColor = Color.FromArgb(218, 217, 241)
   '   e.Layout.Override.SpecialRowSeparatorHeight = 6
   '   e.Layout.Override.BorderStyleSpecialRowSeparator = UIElementBorderStyle.RaisedSoft
   '   e.Layout.ViewStyle = ViewStyle.SingleBand
   '   e.Layout.ViewStyleBand = ViewStyleBand.OutlookGroupBy

   'End Sub

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
         bscProducto2.Permitido = False
         bscCodigoProducto2.Permitido = False
      End If
   End Sub

   Private Sub RefrescarDatosGrilla()

      cmbEstados.SelectedIndex = 1

      chbFecha.Checked = False
      chbProducto.Checked = False
      chbCliente.Checked = False
      chbIdPedido.Checked = False
      chbTamanio.Checked = False
      chbOrdenCompra.Checked = False

      chbResponsable.Checked = False
      cmbTodos.SelectedIndex = 0

      cmbMarcas.Refrescar()
      cmbModelos.Refrescar()
      cmbRubros.Refrescar()
      cmbSubRubros.Refrescar()
      cmbSubSubRubros.Refrescar()

      ''''cmbEstadoCambiar.SelectedIndex = 0
      ''''txtObservacion.Text = String.Empty
      ''''txtCantidad.Text = "0.00"

      chkExpandAll.Checked = False
      chkExpandAll.Enabled = False

      'Limpio la Grilla.
      ugDetalle.ClearFilas()

      _idEstado = String.Empty
      _idTipoEstado = String.Empty

      cmbEstados.Focus()

      ''''HabilitaDetalle()

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
   End Sub

   Private Sub CargaGrillaDetalle()
      Dim responsable = cmbResponsable.ValorSeleccionado(chbResponsable, 0I)
      Dim fechaDesde = dtpDesde.Valor(chbFecha).IfNull()
      Dim fechaHasta = dtpHasta.Valor(chbFecha).IfNull()
      Dim idCliente = If(chbCliente.Checked, Long.Parse(bscCodigoCliente.Tag.ToString()), 0L)

      Dim idProducto = If(chbProducto.Checked, bscCodigoProducto2.Text, String.Empty)
      Dim idOrdenProduccion = If(chbIdPedido.Checked, txtIdPedido.ValorNumericoPorDefecto(0I), -0I)
      Dim tamanio = If(chbTamanio.Checked, txtTamanio.ValorNumericoPorDefecto(0D), 0D)

      Dim ordenCompra = If(chbOrdenCompra.Checked, txtOrdenCompra.ValorNumericoPorDefecto(0L), 0L)

      Dim nroPlanMaestro = If(chbPlanMaestro.Checked, txtPlanMaestro.ValorNumericoPorDefecto(0I), 0I)
      Dim fechaDesdePlan = dtpDesdePlanMaestro.Valor(chbFechaPlanMaestro)
      Dim fechaHastaPlan = dtpHastaPlanMaestro.Valor(chbFechaPlanMaestro)

      Dim rOP = New Reglas.OrdenesProduccion()
      Dim dtDetalle = rOP.GetOrdenesProduccion(actual.Sucursal.IdSucursal, cmbTiposComprobantes.GetTiposComprobantes(),
                              cmbEstados.Text,
                              fechaDesde, fechaHasta, idOrdenProduccion,
                              idProducto, idCliente, tamanio,
                              cmbMarcas.GetMarcas(todosVacio:=True), cmbModelos.GetModelos(todosVacio:=True),
                              cmbRubros.GetRubros(todosVacio:=True), cmbSubRubros.GetSubRubros(todosVacio:=True), cmbSubSubRubros.GetSubSubRubros(todosVacio:=True),
                              ordenCompra, responsable, String.Empty, String.Empty, 0, nroPlanMaestro, fechaDesdePlan, fechaHastaPlan)

      ugDetalle.DataSource = dtDetalle
      AjustarColumnasGrilla(ugDetalle, _tit)
      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar

      ''''cmbEstadoCambiar.SelectedIndex = 0
   End Sub

   ''''''''Private Sub FormatearGrilla()

   ''''''''   'Me.calcularSaldoPedido(DirectCast(Me.ugDetalle.DataSource, DataTable))

   ''''''''   ugDetalle.DisplayLayout.Override.MergedCellContentArea = MergedCellContentArea.Default

   ''''''''   With ugDetalle.DisplayLayout.Bands(0)
   ''''''''      .Columns.OfType(Of UltraGridColumn).ToList().ForEach(Sub(ur) ur.CellActivation = Activation.NoEdit)
   ''''''''      Dim pos = 0I

   ''''''''      .Columns("color").FormatearColumna("  ", pos, 30)
   ''''''''      .Columns(seleccionMasivoColumnName).FormatearColumna("", pos, 50,,,,, Activation.AllowEdit)
   ''''''''      .Columns("IdSucursal").OcultoPosicion(hidden:=True, pos)
   ''''''''      .Columns("idOrdenProduccion").FormatearColumna("Orden Produccion", pos, 55, HAlign.Right)

   ''''''''      .Columns("fechaOrdenProduccion").FormatearColumna("Fecha Orden Produccion", pos, 100, HAlign.Center, , "dd/MM/yyyy HH:mm")
   ''''''''      .Columns("IdCriticidad").FormatearColumna("Criticidad", pos, 100)
   ''''''''      .Columns("FechaEntrega").FormatearColumna("Fecha Entrega", pos, 100, HAlign.Center,, "dd/MM/yyyy")

   ''''''''      .Columns("IdCliente").OcultoPosicion(hidden:=True, pos)
   ''''''''      .Columns("NombreCliente").FormatearColumna("Nombre Cliente", pos, 150)

   ''''''''      .Columns("idProducto").OcultoPosicion(hidden:=True, pos)
   ''''''''      .Columns("NombreProducto").FormatearColumna("Nombre Producto", pos, 200)
   ''''''''      .Columns("Tamano").FormatearColumna("Tamaño", pos, 60, HAlign.Right, , "N4")
   ''''''''      .Columns("Orden").OcultoPosicion(hidden:=True, pos)
   ''''''''      .Columns("Cantidad").FormatearColumna("Cant.Pedida", pos, 70, HAlign.Right, , "N2")

   ''''''''      .Columns("fechaEstado").FormatearColumna("Fecha Estado", pos, 100, HAlign.Center, , "dd/MM/yyyy HH:mm")
   ''''''''      .Columns("idEstado").FormatearColumna("Estado", pos, 90)
   ''''''''      .Columns("IdTipoEstado").OcultoPosicion(hidden:=True, pos)
   ''''''''      .Columns("CantEntregada").FormatearColumna("Cant.Involucrada", pos, 70, HAlign.Right,, "N2")
   ''''''''      .Columns("CantPendiente").FormatearColumna("Cant.Pendiente", pos, 70, HAlign.Right, , "N2").Color(Color.Black, Color.LightCyan).CellAppearance.FontData.Bold = DefaultableBoolean.True

   ''''''''      .Columns("IdTipoComprobante").FormatearColumna("Comprobante", pos, 90)
   ''''''''      .Columns("Letra").FormatearColumna("Letra", pos, 30, HAlign.Center)
   ''''''''      .Columns("CentroEmisor").FormatearColumna("Emisor", pos, 40, HAlign.Right)
   ''''''''      .Columns("NumeroComprobante").FormatearColumna("Nro.Comprobante", pos, 55, HAlign.Right)

   ''''''''      .Columns("IdUsuario").FormatearColumna("Usuario", pos, 75)
   ''''''''      .Columns("observacion").FormatearColumna("Observacion", pos, 200)

   ''''''''   End With

   ''''''''End Sub

   ''''Private Sub HabilitaDetalle()
   ''''   Dim cantidadSeleccionados = ugDetalle.DataSource(Of DataTable).Count(Function(dr) dr.Field(Of Boolean)(seleccionMasivoColumnName))

   ''''   ''''cmbCriticidad.Enabled = cantidadSeleccionados > 0
   ''''   ''''cmbEstadoCambiar.Enabled = cantidadSeleccionados > 0
   ''''   ''''dtpFechaEntrega.Enabled = cantidadSeleccionados > 0
   ''''   ''''txtObservacion.Enabled = cantidadSeleccionados > 0
   ''''   ''''txtCantidad.Enabled = cantidadSeleccionados = 1

   ''''   ''''cmdMasivo.Enabled = cantidadSeleccionados > 0
   ''''End Sub

   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro
         If chbResponsable.Checked Then
            filtro.AppendFormat("Responsable: {0} - ", cmbResponsable.Text)
         End If
         filtro.AppendFormat("Estado: {0}", cmbEstados.Text)
         If chbFecha.Checked Then
            filtro.AppendFormat(" - Fechas: desde {0:dd/MM/yyyy} hasta {1:dd/MM/yyyy}", dtpDesde.Value, dtpHasta.Value)
         End If
         If chbOrdenCompra.Checked Then
            filtro.AppendFormat(" - O. Compra: {0}", txtOrdenCompra.Text)
         End If
         If chbCliente.Checked Then
            filtro.AppendFormatLine(" - Cliente: {0} - {1}", bscCodigoCliente.Text, bscCliente.Text)
         End If
         cmbTiposComprobantes.CargarFiltrosImpresionTiposComprobantes(filtro, muestraId:=False, muestraNombre:=True)
         If chbIdPedido.Checked Then
            filtro.AppendFormat(" - Numero: {0}", txtIdPedido.Text)
         End If
         If chbProducto.Checked Then
            filtro.AppendFormat(" - Producto: {0} - {1}", bscCodigoProducto2.Text, bscProducto2.Text)
         End If
         If chbTamanio.Checked Then
            filtro.AppendFormat(" - Tamaño: {0}", txtTamanio.Text)
         End If
         If cmbMarcas.Visible Then cmbMarcas.CargarFiltrosImpresionMarcas(filtro, muestraId:=False, muestraNombre:=True)
         If cmbModelos.Visible Then cmbModelos.CargarFiltrosImpresionModelos(filtro, muestraId:=False, muestraNombre:=True)
         If cmbRubros.Visible Then cmbRubros.CargarFiltrosImpresionRubros(filtro, muestraId:=False, muestraNombre:=True)
         If cmbSubRubros.Visible Then cmbSubRubros.CargarFiltrosImpresionSubRubros(filtro, muestraId:=False, muestraNombre:=True)
         If cmbSubSubRubros.Visible Then cmbSubSubRubros.CargarFiltrosImpresionSubSubRubros(filtro, muestraId:=False, muestraNombre:=True)
      End With
      Return filtro.ToString()
   End Function

   '-- REG-41949.- --------------------------------------------------------------------------------------------------------------
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

#End Region

End Class