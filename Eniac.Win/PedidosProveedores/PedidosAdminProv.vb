Public Class PedidosAdminProv
   Implements IConParametros

#Region "Campos"

   Private _publicos As Publicos
   Private _idEstado As String = String.Empty
   Private _idTipoEstado As String = String.Empty
   Private _insertaEstado As Boolean = False
   Private _idCriticidad As String = String.Empty
   Private _fechaEntrega As Date? = Nothing
   Private _tipoTipoComprobante As String

   Private _puedeVerPrecios As Boolean

   Private _dtEstadosEscritura As DataTable

   Private _tit As Dictionary(Of String, String)

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         If String.IsNullOrWhiteSpace(_tipoTipoComprobante) Then _tipoTipoComprobante = "PEDIDOSPROV"

         _puedeVerPrecios = New Reglas.Usuarios().TienePermisos(actual.Nombre, actual.Sucursal.Id, IdFuncion + "-VerPre")

         cmbTiposComprobantes.Initializar(False, True, True, False, _tipoTipoComprobante)
         cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()

         _publicos = New Publicos()

         _publicos.CargaComboEstadosPedidosProv(cmbEstados, True, True, True, False, False, _tipoTipoComprobante, Entidades.Publicos.LecturaEscrituraTodos.LECTURA)
         cmbEstados.SelectedIndex = 1  'SOLO PENDIENTES

         _publicos.CargaComboMarcas(cmbMarca)
         _publicos.CargaComboRubros(cmbRubro)
         _publicos.CargaComboSubRubros(cmbSubRubro)
         _publicos.CargaComboCriticidades(cmbCriticidad)
         _publicos.CargaComboDesdeEnum(cmbTodos, GetType(Reglas.Publicos.TodosEnum))

         If Not Reglas.Publicos.ProductoTieneSubRubro Then
            chbSubRubro.Visible = False
            cmbSubRubro.Visible = False
         End If

         dtpDesde.Value = Date.Today
         dtpHasta.Value = Date.Today.UltimoSegundoDelDia()

         _publicos.CargaComboEstadosPedidosProv(cmbEstadoCambiar, False, False, False, False, False, _tipoTipoComprobante, Entidades.Publicos.LecturaEscrituraTodos.LECTURA)
         _dtEstadosEscritura = New Reglas.EstadosPedidosProveedores().GetAll(_tipoTipoComprobante, Entidades.Publicos.LecturaEscrituraTodos.ESCRITURA, activos:=Entidades.Publicos.SiNoTodos.SI)

         'Da la posibilidad de que podamos elegir las columnas que queremos mostrar u ocultar con un botón a la izquierda de la cabecera.
         ugDetalle.DisplayLayout.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.ColumnChooserButton

         ugDetalle.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
         cmbEstadoCambiar.SelectedIndex = 0

         If Not _puedeVerPrecios Then
            'ugDetalle.DisplayLayout.Bands(0).Columns("").Hidden = True
         End If

         ugDetalle.AgregarFiltroEnLinea({"NombreProveedor", "NombreProducto", "observacion"}, {"ClipArchivoAdjunto"})

         Dim rUsuario = New Eniac.Reglas.Usuarios()
         tsbModificarPedido.Visible = rUsuario.TienePermisos("PedidosAdminProv-Modif")
         ToolStripSeparator1.Visible = tsbModificarPedido.Visible Or tsbConvertirEnFactura.Visible

         chbGeneraUnPedidoPorProveedor.Visible = _tipoTipoComprobante = Entidades.TipoComprobante.Tipos.ORDENCOMPRAPROV.ToString()

         HabilitaDetalle()

         CargarColumnasASumar()

         PreferenciasLeer(ugDetalle, tsbPreferencias)
         _tit = GetColumnasVisiblesGrilla(ugDetalle)
      End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function

#End Region

#Region "Eventos"

   Private Sub chbMarca_CheckedChanged(sender As Object, e As EventArgs) Handles chbMarca.CheckedChanged
      TryCatched(Sub() chbMarca.FiltroCheckedChanged(cmbMarca))
   End Sub
   Private Sub chbRubro_CheckedChanged(sender As Object, e As EventArgs) Handles chbRubro.CheckedChanged
      TryCatched(Sub() chbRubro.FiltroCheckedChanged(cmbRubro))
   End Sub

   Private Sub chbSubRubro_CheckedChanged(sender As Object, e As EventArgs) Handles chbSubRubro.CheckedChanged
      TryCatched(Sub() chbSubRubro.FiltroCheckedChanged(cmbSubRubro))
   End Sub

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub
   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(Sub() ugDetalle.Imprimir(CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True, .FitWidthToPages = 1}))
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

   Private Sub chbFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chbFecha.CheckedChanged
      TryCatched(Sub() chbFecha.FiltroCheckedChanged(chkMesCompleto, dtpDesde, dtpHasta))
   End Sub

   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub

#Region "Eventos Buscadores Productos"
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

#Region "Eventos Buscadores Productos"
   Private Sub chbProveedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbProveedor.CheckedChanged
      TryCatched(Sub() chbProveedor.FiltroCheckedChanged(usaPermitido:=True, bscCodigoProveedor, bscProveedor))
   End Sub
   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProveedores2(bscCodigoProveedor)
         Dim codigoProveedor = bscCodigoProveedor.Text.ValorNumericoPorDefecto(-1L)
         bscCodigoProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorCodigo(codigoProveedor, True)
      End Sub)
   End Sub
   Private Sub bscProveedor_BuscadorClick() Handles bscProveedor.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProveedores2(bscProveedor)
         bscProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorNombre(bscProveedor.Text.Trim())
      End Sub)
   End Sub
   Private Sub bscCodigoProveedor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion, bscProveedor.BuscadorSeleccion
      TryCatched(Sub() CargarDatosProveedor(e.FilaDevuelta))
   End Sub
#End Region
   Private Sub chbIdPedido_CheckedChanged(sender As Object, e As EventArgs) Handles chbIdPedido.CheckedChanged
      TryCatched(Sub() chbIdPedido.FiltroCheckedChanged(txtIdPedido))
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         If chbProducto.Checked And Not bscCodigoProducto2.Selecciono And Not bscProducto2.Selecciono Then
            ShowMessage("ATENCION: NO seleccionó un Producto aunque activó ese Filtro.")
            bscCodigoProducto2.Focus()
            Exit Sub
         End If
         If chbProveedor.Checked And Not bscCodigoProveedor.Selecciono And Not bscProveedor.Selecciono Then
            ShowMessage("ATENCION: NO seleccionó un Proveedor aunque activó ese Filtro.")
            bscCodigoProveedor.Focus()
            Exit Sub
         End If
         If chbIdPedido.Checked AndAlso txtIdPedido.ValorNumericoPorDefecto(0I) = 0 Then
            ShowMessage(Traducciones.TraducirTexto("ATENCION: NO Ingresó un Número de Pedido aunque activó ese Filtro.", Me, "__FaltaNumeroPedido"))
            txtIdPedido.Focus()
            Exit Sub
         End If

         chkExpandAll.Enabled = True
         chkExpandAll.Checked = False

         CargaGrillaDetalle()
         HabilitaDetalle()

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

   'Ademas de tomar el CLIC sobre la fila, toma el desplazamiento con las flechas!!! 
   'Private Sub ugDetalle_ClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles ugDetalle.ClickCell
   Private Sub ugDetalle_AfterCellActivate(sender As Object, e As EventArgs) Handles ugDetalle.AfterCellActivate

      If ugDetalle.Rows.Count = 0 Then Exit Sub

      If ugDetalle.ActiveCell Is Nothing Then Exit Sub

      _idEstado = ugDetalle.ActiveCell.Row.Cells("IdEstado").Value.ToString()
      _idTipoEstado = ugDetalle.ActiveCell.Row.Cells("idTipoEstado").Value.ToString()
      _idCriticidad = ugDetalle.ActiveCell.Row.Cells("IdCriticidad").Value.ToString()

      Try
         _fechaEntrega = DirectCast(ugDetalle.ActiveCell.Row.Cells("FechaEntrega").Value, Date?)
      Catch ex As Exception
         _fechaEntrega = Nothing
      End Try

      txtCantidad.Text = ugDetalle.ActiveCell.Row.Cells("CantEntregada").Value.ToString
      cmbCriticidad.SelectedValue = _idCriticidad
      cmbEstadoCambiar.SelectedValue = _idEstado

      If _fechaEntrega IsNot Nothing Then
         dtpFechaEntrega.Value = _fechaEntrega.Value
      Else
         dtpFechaEntrega.Value = Today.Date
      End If
   End Sub

   Private Function AgregarMensajeError(stb As StringBuilder, mensaje As String) As Boolean
      stb.AppendLine(mensaje)
      Return False
   End Function

   Private Sub btnMasivo_Click(sender As Object, e As EventArgs) Handles btnMasivo.Click
      TryCatched(
      Sub()
         Dim mensage = New StringBuilder()
         Dim tablaGrabar = DirectCast(ugDetalle.DataSource, DataTable).Clone()
         Dim cantTotalProducto As Decimal = 0

         Dim tipoComprobanteEstadoCambia As Entidades.TipoComprobante = Nothing
         If Not String.IsNullOrWhiteSpace(DirectCast(cmbEstadoCambiar.SelectedItem, DataRowView).Row("IdTipoComprobante").ToString()) Then
            tipoComprobanteEstadoCambia = New Reglas.TiposComprobantes().GetUno(DirectCast(cmbEstadoCambiar.SelectedItem, DataRowView).Row("IdTipoComprobante").ToString())
         End If

         If Not _dtEstadosEscritura.Any(Function(dr) dr.Field(Of String)("IdEstado") = cmbEstadoCambiar.Text) Then
            Throw New Exception(String.Format("No tiene permisos para cambiar al estado {0}", cmbEstadoCambiar.Text))
         End If

         If ShowPregunta(String.Format(Traducciones.TraducirTexto("¿Desea cambiar masivamente el Estado actual de los Pedidos Seleccionados al Estado: {0}?", Me, "__CambioEstadoMasivo"),
                                       Me.cmbEstadoCambiar.Text)) = Windows.Forms.DialogResult.Yes Then
            Dim graba As Boolean = True
            Dim _cache As Reglas.BusquedasCacheadas = New Reglas.BusquedasCacheadas()
            For Each fila As DataRow In DirectCast(Me.ugDetalle.DataSource, DataTable).Rows
               graba = True
               If Boolean.Parse(fila("masivo").ToString) Then
                  If _idEstado = Me.cmbEstadoCambiar.Text Then
                     _idCriticidad = fila("IdCriticidad").ToString()
                     Try
                        _fechaEntrega = DirectCast(fila("FechaEntrega"), Date?)
                     Catch ex As Exception
                        _fechaEntrega = Nothing
                     End Try
                     If _idCriticidad = cmbCriticidad.Text AndAlso _fechaEntrega = dtpFechaEntrega.Value Then
                        graba = AgregarMensajeError(mensage, String.Format(Traducciones.TraducirTexto("Pedido: {0} --> El Estado a cambiar debe ser distinto al Estado Actual del Pedido o cambiar Criticidad/Fecha de Entrega.", Me, "__ErrorCambioMasivoNoPermitido"), fila("numeropedido")))
                     End If
                  End If

                  If _idTipoEstado = Entidades.EstadoPedidoProveedor.TipoEstado.ANULADO Or
                     _idTipoEstado = Entidades.EstadoPedidoProveedor.TipoEstado.RECHAZADO Or
                     _idTipoEstado = Entidades.EstadoPedidoProveedor.TipoEstado.ENTREGADO Then
                     graba = AgregarMensajeError(mensage, String.Format(Traducciones.TraducirTexto("Pedido: {0} --> El Estado Actual NO permite cambio.", Me, "__ErrorEstadoNoPermiteCambio"), fila("numeropedido")))
                  End If

                  Dim estado As Entidades.EstadoPedidoProveedor = _cache.BuscaEstadosPedidoProveedores(fila("IdEstado").ToString(), fila("TipoEstadoPedido").ToString())
                  If Not String.IsNullOrWhiteSpace(estado.IdEstadoDestino) Then
                     If estado.IdEstadoDestino <> cmbEstadoCambiar.SelectedValue.ToString() Then
                        graba = AgregarMensajeError(mensage, String.Format(Traducciones.TraducirTexto("Pedido: {0} --> El estado del pedido seleccionado seleccionado (´{2}´) no permite pasar al estado {1}.", Me, "__ErrorEstadoNoPermiteSiguiente"), fila("numeropedido"), cmbEstadoCambiar.SelectedValue.ToString(), fila("IdEstado").ToString()))
                     End If
                  End If

                  If tipoComprobanteEstadoCambia IsNot Nothing AndAlso tipoComprobanteEstadoCambia.Tipo = Entidades.TipoComprobante.Tipos.PRODUCCION.ToString() Then
                     If Not IsNumeric(fila("IdFormula")) Then
                        graba = AgregarMensajeError(mensage, String.Format(Traducciones.TraducirTexto("Pedido: {0} --> El Producto {1} - '{2}' no tiene definida una Formula de Producción. No es posible pasar al módulo de Producción.", Me, "__ErrorCambioMasivoNoPermitido"), fila("numeropedido"), fila("IdProducto"), fila("NombreProducto")))
                     End If
                  End If
                  If graba Then tablaGrabar.ImportRow(fila)
               End If         'If Boolean.Parse(fila("masivo").ToString) Then
            Next              'For Each fila As DataRow In DirectCast(Me.ugDetalle.DataSource, DataTable).Rows
            If Not String.IsNullOrEmpty(mensage.ToString()) Then
               MessageBox.Show(mensage.ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Exit Sub
            ElseIf tablaGrabar.Rows.Count = 0 Then
               MessageBox.Show("No se han seleccionado filas para el cambio masivo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Exit Sub
            End If

            Dim rPedidos = New Reglas.PedidosEstadosProveedores()
            Dim cantidad As Decimal? = Nothing
            If txtCantidad.Enabled AndAlso IsNumeric(txtCantidad.Text) Then cantidad = Decimal.Parse(txtCantidad.Text)

            Dim IdResponsable As Integer = 0

            rPedidos.ActualizarEstadoPedidoProveedorMasivo(actual.Sucursal.Id,
                                                           cmbEstadoCambiar.Text,
                                                           _tipoTipoComprobante,
                                                           actual.Nombre,
                                                           txtObservacion.Text,
                                                           cmbCriticidad.Text,
                                                           dtpFechaEntrega.Value,
                                                           cantidad,
                                                           IdResponsable,
                                                           Nothing,
                                                           tablaGrabar, chbGeneraUnPedidoPorProveedor.Checked,
                                                           Entidades.Entidad.MetodoGrabacion.Automatico,
                                                           IdFuncion)

            MessageBox.Show("Estado/s actualizado/s Exitosamente !!.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            CargaGrillaDetalle()
            HabilitaDetalle()
         End If
      End Sub)
   End Sub

   Private Sub txtObservacion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtObservacion.KeyDown
      PresionarTab(e)
   End Sub
   Private Sub cmbEstadoCambiar_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbEstadoCambiar.KeyDown
      PresionarTab(e)
   End Sub
   Private Sub cmbResponsable_KeyDown(sender As Object, e As KeyEventArgs)
      PresionarTab(e)
   End Sub
   Private Sub txtCantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidad.KeyDown
      PresionarTab(e)
   End Sub

   Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
      cmbEstadoCambiar.SelectedIndex = 0
   End Sub
   Private Sub txtCantidad_GotFocus(sender As Object, e As EventArgs) Handles txtCantidad.GotFocus
      txtCantidad.SelectAll()
   End Sub
   Private Sub ugDetalle_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles ugDetalle.InitializeLayout
      e.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.SummaryRow
      e.Layout.Override.SpecialRowSeparatorAppearance.BackColor = Color.FromArgb(218, 217, 241)
      e.Layout.Override.SpecialRowSeparatorHeight = 6
      e.Layout.Override.BorderStyleSpecialRowSeparator = UIElementBorderStyle.RaisedSoft
      e.Layout.ViewStyle = ViewStyle.SingleBand
      e.Layout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
   End Sub

#Region "Marcar/Desmarcar Todos"
   Private Sub btnTodos_Click(sender As Object, e As EventArgs) Handles btnTodos.Click
      TryCatched(
      Sub() ugDetalle.MarcarDesmarcar(cmbTodos, "masivo",
                                      Sub(marcar, dr)
                                         If Convert.ToBoolean(dr.Cells("masivo").Value) Then
                                            dr.Cells("CantidadNuevoEstado").Value = dr.Cells("CantEntregada").Value
                                         Else
                                            dr.Cells("CantidadNuevoEstado").Value = DBNull.Value
                                         End If
                                      End Sub),
      onFinallyAction:=Sub(owner) HabilitaDetalle())
   End Sub
#End Region

#End Region

#Region "Metodos"
   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro
         filtro.AppendFormat("Estado: {0}", cmbEstados.Text)
         If chbFecha.Checked Then
            filtro.AppendFormat(" - Fechas: desde {0:dd/MM/yyyy} hasta {1:dd/MM/yyyy}", dtpDesde.Value, dtpHasta.Value)
         End If
         filtro.AppendFormat(" - Tipo Comprob. {0}", cmbTiposComprobantes.Text)
         If chbIdPedido.Checked Then
            filtro.AppendFormat(" - Numero: {0}", txtIdPedido.Text)
         End If
         If chbProveedor.Checked Then
            filtro.AppendFormatLine(" - Proveedor: {0} - {1}", bscCodigoProveedor.Text, bscProveedor.Text)
         End If
         If chbOrdenCompra.Checked Then
            filtro.AppendFormat(" - O. Compra: {0}", txtOrdenCompra.Text)
         End If
         If chbProducto.Checked Then
            filtro.AppendFormat(" - Producto: {0} - {1}", bscCodigoProducto2.Text, bscProducto2.Text)
         End If
         If chbMarca.Checked Then
            filtro.AppendFormat(" - Marca: {0}", cmbMarca.Text)
         End If
         If chbRubro.Checked Then
            filtro.AppendFormat(" - Rubro: {0}", cmbRubro.Text)
         End If
         If chbSubRubro.Checked Then
            filtro.AppendFormat(" - SubRubro: {0}", cmbSubRubro.Text)
         End If
      End With
      Return filtro.ToString()
   End Function

   Private Sub CargarDatosProveedor(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
         bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString().Trim()
         bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()
         bscProveedor.Permitido = False
         bscCodigoProveedor.Permitido = False

         btnConsultar.Focus()
      End If
   End Sub

   Private Sub CargarProducto(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
         bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
         bscProducto2.Permitido = False
         bscCodigoProducto2.Permitido = False

         btnConsultar.Focus()
      End If
   End Sub

   Private Sub RefrescarDatosGrilla()
      cmbEstados.SelectedIndex = 1

      chbFecha.Checked = False
      chbProducto.Checked = False
      chbProveedor.Checked = False
      chbIdPedido.Checked = False
      chbOrdenCompra.Checked = False

      cmbEstadoCambiar.SelectedIndex = 0

      cmbTodos.SelectedIndex = 0
      txtObservacion.Text = String.Empty
      txtCantidad.Text = "0.00"

      chkExpandAll.Checked = False
      chkExpandAll.Enabled = False

      cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()

      chbGeneraUnPedidoPorProveedor.Visible = _tipoTipoComprobante = Entidades.TipoComprobante.Tipos.ORDENCOMPRAPROV.ToString()
      chbGeneraUnPedidoPorProveedor.Checked = False

      'Limpio la Grilla.
      ugDetalle.ClearFilas()

      _idEstado = String.Empty
      _idTipoEstado = String.Empty

      cmbEstados.Focus()

      HabilitaDetalle()
      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
   End Sub

   Private Sub CargaGrillaDetalle()
      Dim fechaDesde = dtpDesde.Valor(chbFecha).IfNull()
      Dim fechaHasta = dtpHasta.Valor(chbFecha).IfNull()
      Dim idProveedor = If(chbProveedor.Checked, Long.Parse(bscCodigoProveedor.Tag.ToString()), 0L)
      cmbEstadoCambiar.SelectedIndex = 0

      Dim idProducto = If(chbProducto.Checked, bscCodigoProducto2.Text, String.Empty)
      Dim idPedido = txtIdPedido.ValorSeleccionado(chbIdPedido, -1I)

      Dim idMarca = cmbMarca.ValorSeleccionado(chbMarca, 0I)
      Dim idRubro = cmbRubro.ValorSeleccionado(chbRubro, 0I)
      Dim idSubRubro = cmbSubRubro.ValorSeleccionado(chbSubRubro, 0I)
      Dim ordenCompra = txtOrdenCompra.ValorSeleccionado(chbOrdenCompra, 0L)

      Dim rPedidos = New Reglas.PedidosProveedores()
      Dim dtDetalle = rPedidos.GetPedidos(actual.Sucursal.IdSucursal, cmbEstados.Text,
                                          fechaDesde, fechaHasta,
                                          idPedido, idProducto, idProveedor,
                                          idMarca, idRubro, idSubRubro,
                                          ordenCompra, _tipoTipoComprobante, cmbTiposComprobantes.GetTiposComprobantes(),
                                          letra:="", centroEmisor:=0, orden:=0, fechaEstado:=Nothing,
                                          seguridadRol:=Entidades.Publicos.LecturaEscrituraTodos.LECTURA)
      ugDetalle.DataSource = dtDetalle
      AjustarColumnasGrilla(ugDetalle, _tit)

      For Each fila As Infragistics.Win.UltraWinGrid.UltraGridRow In Me.ugDetalle.Rows
         'TODO: Revisar posible problema de performance.
         Dim ColorEstado = New Reglas.EstadosPedidosProveedores().GetUno(fila.Cells("IdEstado").Value.ToString(), _tipoTipoComprobante).Color

         fila.Cells("Color").Color(Nothing, Color.FromArgb(ColorEstado))
      Next

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
   End Sub

   Private Sub FormatearGrilla()

      'Me.calcularSaldoPedido(DirectCast(Me.ugDetalle.DataSource, DataTable))

      ugDetalle.DisplayLayout.Override.MergedCellContentArea = Infragistics.Win.UltraWinGrid.MergedCellContentArea.Default

      With Me.ugDetalle.DisplayLayout.Bands(0)

         .Columns("color").Header.Caption = "  "
         .Columns("color").Width = 30
         .Columns("color").CellActivation = Activation.NoEdit

         .Columns("masivo").Width = 50
         '.Columns("masivo").MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always
         '.Columns("masivo").MergedCellEvaluationType = Infragistics.Win.UltraWinGrid.MergedCellEvaluationType.MergeSameValue
         '.Columns("masivo").MergedCellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
         '.Columns("masivo").MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Center

         .Columns("IdSucursal").Hidden = True

         .Columns("idPedido").Header.Caption = "Pedido"
         .Columns("idPedido").Width = 55
         .Columns("idPedido").CellAppearance.TextHAlign = HAlign.Right
         '.Columns("idPedido").MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always
         .Columns("idPedido").CellActivation = Activation.NoEdit

         .Columns("fechaPedido").Header.Caption = "Fecha Pedido"
         .Columns("fechaPedido").Width = 100
         .Columns("fechaPedido").CellAppearance.TextHAlign = HAlign.Center
         .Columns("fechaPedido").Format = "dd/MM/yyyy HH:mm"
         .Columns("fechaPedido").CellActivation = Activation.NoEdit

         .Columns("IdCriticidad").Header.Caption = "Criticidad"
         .Columns("IdCriticidad").Width = 100
         .Columns("IdCriticidad").CellAppearance.TextHAlign = HAlign.Left
         .Columns("IdCriticidad").CellActivation = Activation.NoEdit

         .Columns("FechaEntrega").Header.Caption = "Fecha Entrega"
         .Columns("FechaEntrega").Width = 100
         .Columns("FechaEntrega").CellAppearance.TextHAlign = HAlign.Center
         .Columns("FechaEntrega").Format = "dd/MM/yyyy"
         .Columns("FechaEntrega").CellActivation = Activation.NoEdit

         .Columns("IdProveedor").Hidden = True

         .Columns("NombreProveedor").Header.Caption = "Nombre Proveedor"
         .Columns("NombreProveedor").Width = 150
         .Columns("NombreProveedor").CellActivation = Activation.NoEdit

         '.Columns("idProducto").Header.Caption = "Producto"
         '.Columns("idProducto").Width = 100
         '.Columns("idProducto").CellAppearance.TextHAlign = HAlign.Right
         .Columns("idProducto").Hidden = True

         .Columns("NombreProducto").Header.Caption = "Nombre Producto"
         .Columns("NombreProducto").Width = 200
         .Columns("NombreProducto").CellActivation = Activation.NoEdit

         .Columns("Tamano").Header.Caption = "Tamaño"
         .Columns("Tamano").Width = 60
         .Columns("Tamano").CellAppearance.TextHAlign = HAlign.Right
         .Columns("Tamano").Format = "N4"
         .Columns("Tamano").CellActivation = Activation.NoEdit

         .Columns("Orden").Hidden = True

         .Columns("Cantidad").Header.Caption = "Cant.Pedida"
         .Columns("Cantidad").Width = 70
         .Columns("Cantidad").CellAppearance.TextHAlign = HAlign.Right
         .Columns("Cantidad").Format = "N2"
         .Columns("Cantidad").CellActivation = Activation.NoEdit

         .Columns("fechaEstado").Header.Caption = "Fecha Estado"
         .Columns("fechaEstado").Width = 100
         .Columns("fechaEstado").CellAppearance.TextHAlign = HAlign.Center
         .Columns("fechaEstado").Format = "dd/MM/yyyy HH:mm"
         .Columns("fechaEstado").CellActivation = Activation.NoEdit

         .Columns("idEstado").Header.Caption = "Estado"
         .Columns("idEstado").Width = 90
         .Columns("idEstado").CellActivation = Activation.NoEdit

         .Columns("IdTipoEstado").Hidden = True

         .Columns("CantEntregada").Header.Caption = "Cant.Involucrada"
         .Columns("CantEntregada").Width = 70
         .Columns("CantEntregada").CellAppearance.TextHAlign = HAlign.Right
         .Columns("CantEntregada").Format = "N2"
         .Columns("CantEntregada").CellActivation = Activation.NoEdit

         .Columns("CantPendiente").Header.Caption = "Cant.Pendiente"
         .Columns("CantPendiente").Width = 70
         .Columns("CantPendiente").CellAppearance.TextHAlign = HAlign.Right
         .Columns("CantPendiente").Format = "N2"
         .Columns("CantPendiente").CellAppearance.BackColor = Color.LightCyan
         .Columns("CantPendiente").CellAppearance.FontData.Bold = DefaultableBoolean.True
         .Columns("CantPendiente").CellActivation = Activation.NoEdit

         'pe.IdSucursal, pe.IdTipoComprobante, pe.Letra, pe.CentroEmisor, pe.NumeroComprobante

         .Columns("IdTipoComprobante").Header.Caption = "Comprobante"
         .Columns("IdTipoComprobante").Width = 90
         .Columns("IdTipoComprobante").CellActivation = Activation.NoEdit

         .Columns("Letra").Header.Caption = "Letra"
         .Columns("Letra").Width = 30
         .Columns("Letra").CellAppearance.TextHAlign = HAlign.Center
         .Columns("Letra").CellActivation = Activation.NoEdit

         .Columns("CentroEmisor").Header.Caption = "Emisor"
         .Columns("CentroEmisor").Width = 40
         .Columns("CentroEmisor").CellAppearance.TextHAlign = HAlign.Right
         .Columns("CentroEmisor").CellActivation = Activation.NoEdit

         .Columns("NumeroComprobante").Header.Caption = "Nro.Comprobante"
         .Columns("NumeroComprobante").Width = 55
         .Columns("NumeroComprobante").CellAppearance.TextHAlign = HAlign.Right
         .Columns("NumeroComprobante").CellActivation = Activation.NoEdit

         .Columns("IdUsuario").Header.Caption = "Usuario"
         .Columns("IdUsuario").Width = 75
         .Columns("IdUsuario").CellActivation = Activation.NoEdit

         .Columns("observacion").Header.Caption = "Observacion"
         .Columns("observacion").Width = 200
         .Columns("observacion").CellActivation = Activation.NoEdit

         '.Columns("saldo").Hidden = True
         '.Columns("cantOriginal").Hidden = True ' se usa para las cuentas...
         '.Columns("saldoFila").Hidden = True ' se usa para las cuentas...

      End With

   End Sub

   'Me.ugDetalle.DisplayLayout.Override.SummaryValueAppearance.BackColor = Color.Yellow
   Private Sub CargarColumnasASumar()
      ugDetalle.AgregarTotalesSuma({"cantEntregada", "cantPendiente"})
   End Sub

#End Region

   Private Sub cmbCriticidad_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbCriticidad.KeyDown
      TryCatched(Sub() PresionarTab(e))
   End Sub
   Private Sub dtpFechaEntrega_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpFechaEntrega.KeyDown
      TryCatched(Sub() PresionarTab(e))
   End Sub

   Private Sub tsbModificarPedido_Click(sender As Object, e As EventArgs) Handles tsbModificarPedido.Click
      TryCatched(
      Sub()
         Dim dr = ugDetalle.FilaSeleccionada(Of DataRow)
         If dr IsNot Nothing Then
            Dim oPedido = New Reglas.PedidosProveedores().GetUno(Integer.Parse(dr(Entidades.PedidoProveedor.Columnas.IdSucursal.ToString()).ToString()),
                                                                 dr(Entidades.PedidoProveedor.Columnas.IdTipoComprobante.ToString()).ToString(),
                                                                 dr(Entidades.PedidoProveedor.Columnas.Letra.ToString()).ToString(),
                                                                 Short.Parse(dr(Entidades.PedidoProveedor.Columnas.CentroEmisor.ToString()).ToString()),
                                                                 Long.Parse(dr(Entidades.PedidoProveedor.Columnas.NumeroPedido.ToString()).ToString()))
            Using frmPedidos = New PedidosProveedores()
               frmPedidos.IdFuncion = IdFuncion
               If Not String.IsNullOrWhiteSpace(_parametros) Then
                  frmPedidos.SetParametros(_parametros)
               End If
               frmPedidos.ModificarPedido(oPedido, Me)
            End Using
            btnConsultar.PerformClick()
         Else
            Throw New Exception(Traducciones.TraducirTexto("Por favor seleccione un pedido.", Me, "__NoSeleccionoPedidoModificar"))
         End If
      End Sub)
   End Sub

   Private Sub tsbConvertirEnFactura_Click(sender As Object, e As EventArgs) Handles tsbConvertirEnFactura.Click
      TryCatched(
      Sub()
         Dim dr = ugDetalle.FilaSeleccionada(Of DataRow)
         If dr IsNot Nothing Then
            Dim rPedido = New Reglas.PedidosProveedores()
            Dim rVenta = New Reglas.Ventas()
            Dim caja = New Reglas.CajasNombres().GetTodas(actual.Sucursal.IdSucursal)(0)
            Dim idReparto = rVenta.GetUltNumeroReparto()

            Dim oPedido = rPedido.GetUno(Integer.Parse(dr(Entidades.PedidoProveedor.Columnas.IdSucursal.ToString()).ToString()),
                                         dr(Entidades.PedidoProveedor.Columnas.IdTipoComprobante.ToString()).ToString(),
                                         dr(Entidades.PedidoProveedor.Columnas.Letra.ToString()).ToString(),
                                         Short.Parse(dr(Entidades.PedidoProveedor.Columnas.CentroEmisor.ToString()).ToString()),
                                         Long.Parse(dr(Entidades.PedidoProveedor.Columnas.NumeroPedido.ToString()).ToString()))
         End If
      End Sub)
   End Sub

   Private Sub chbOrdenCompra_CheckedChanged(sender As Object, e As EventArgs) Handles chbOrdenCompra.CheckedChanged
      TryCatched(Sub() chbOrdenCompra.FiltroCheckedChanged(txtOrdenCompra))
   End Sub

#Region "IConParametros"
   'Public Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
   '   _tipoTipoComprobante = parametros
   'End Sub
   'Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
   '   Return "Pendiente documentar"
   'End Function
   Private _parametros As String
   Public Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
      _parametros = parametros
      Dim paramFunc = New ParametrosFuncion()
      ConParametrosAyudante.Parse(parametros, GetType(PedidosProveedores.ParametrosPermitidos), paramFunc)

      _tipoTipoComprobante = paramFunc.GetValor(Of String)(PedidosProveedores.ParametrosPermitidos.TipoTipoComprobante)
      'Dim permitePrecioCero = _parametros.GetValor(Of String)(ParametrosPermitidos.PermitePrecioCero)
      '_permitePrecioCero = If(permitePrecioCero = "SI", True, If(permitePrecioCero = "NO", False, DirectCast(Nothing, Boolean?)))
   End Sub
   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Return ConParametrosAyudante.ParametrosDisponiblesAyuda(GetType(PedidosProveedores.ParametrosPermitidos))
   End Function

#End Region

   Private Sub HabilitaDetalle()
      Dim cantidadSeleccionados As Integer = 0
      Dim drCol As DataRow() = Nothing
      If TypeOf (ugDetalle.DataSource) Is DataTable Then
         drCol = DirectCast(ugDetalle.DataSource, DataTable).Select("masivo")
         cantidadSeleccionados = drCol.Length
      End If

      cmbCriticidad.Enabled = cantidadSeleccionados > 0
      cmbEstadoCambiar.Enabled = cantidadSeleccionados > 0
      dtpFechaEntrega.Enabled = cantidadSeleccionados > 0
      txtObservacion.Enabled = cantidadSeleccionados > 0
      txtCantidad.Enabled = cantidadSeleccionados = 1
      ugDetalle.DisplayLayout.Bands(0).Columns("CantidadNuevoEstado").Hidden = txtCantidad.Enabled
      lblCantidadObservaciones.Visible = Not txtCantidad.Enabled

      btnMasivo.Enabled = cantidadSeleccionados > 0

      If cantidadSeleccionados = 1 And drCol IsNot Nothing Then
         Dim dr As DataRow = drCol(0)

         _idEstado = dr("IdEstado").ToString()
         _idTipoEstado = dr("idTipoEstado").ToString()
         _idCriticidad = dr("IdCriticidad").ToString()

         Try
            _fechaEntrega = DirectCast(dr("FechaEntrega"), Date?)
         Catch ex As Exception
            _fechaEntrega = Nothing
         End Try

         Me.txtCantidad.Text = dr("CantEntregada").ToString()
         Me.cmbCriticidad.SelectedValue = _idCriticidad
         Me.cmbEstadoCambiar.SelectedValue = _idEstado

         If _fechaEntrega IsNot Nothing Then
            dtpFechaEntrega.Value = _fechaEntrega.Value
         Else
            dtpFechaEntrega.Value = Today.Date
         End If
      End If
   End Sub

   Private Sub ugDetalle_CellChange(sender As Object, e As CellEventArgs) Handles ugDetalle.CellChange
      TryCatched(
      Sub()
         If e.Cell.Column.Key = "masivo" Then
            ugDetalle.UpdateData()
            HabilitaDetalle()

            If Convert.ToBoolean(e.Cell.Value) Then
               e.Cell.Row.Cells("CantidadNuevoEstado").Value = e.Cell.Row.Cells("CantEntregada").Value
            Else
               e.Cell.Row.Cells("CantidadNuevoEstado").Value = DBNull.Value
            End If
         End If
      End Sub)
   End Sub
   Private Sub ugDetalle_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugDetalle.ClickCellButton
      TryCatched(
      Sub()
         Dim dr = e.Cell.Row.FilaSeleccionada(Of DataRow)
         If dr IsNot Nothing Then
            Dim urlPlano As String = dr("UrlPlano").ToString()
            If Not String.IsNullOrWhiteSpace(urlPlano) Then
               Try
                  Process.Start(urlPlano)
               Catch ex As Exception
                  ShowError(ex)
               End Try
            End If
         End If
      End Sub)
   End Sub
   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(
      Sub()
         PreferenciasCargar(ugDetalle, tsbPreferencias)
         _tit = GetColumnasVisiblesGrilla(ugDetalle)
      End Sub)
   End Sub
End Class