Public Class InfOrdenesProduccionMRPProductos
#Region "Campos"
   Private _publicos As Publicos
   Private _prevNumeroDesde As Long
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         '-- Carga Tipos de comprobantes.- 
         _publicos.CargaComboTiposComprobantes(cmbTipoComprobante, MiraPC:=False, Entidades.TipoComprobante.Tipos.PRODUCCION.ToString())
         _publicos.CargaComboTiposComprobantes(cmbTipoComprobantePedido, MiraPC:=False, Entidades.TipoComprobante.Tipos.PEDIDOSCLIE.ToString())
         _publicos.CargaComboLetrasFiscales(cmbLetraFiscal, Entidades.TipoComprobante.Tipos.PRODUCCION)
         _publicos.CargaComboCentrosEmisores(cmbCentroEmisor, Entidades.TipoComprobante.Tipos.PRODUCCION)

         _publicos.CargaComboLetrasFiscales(cmbLetraFiscalPedido, Entidades.TipoComprobante.Tipos.PEDIDOSCLIE)
         _publicos.CargaComboCentrosEmisores(cmbCentroEmisorPedido, Entidades.TipoComprobante.Tipos.PEDIDOSCLIE)

         _publicos.CargaComboEstadosOrdenesProduccion(cmbEstados, AgregarTODOS:=False, AgregarSOLOPendientes:=False, AgregarSOLOEnProceso:=False, AgregarAnulado:=False, tipoEstado:=Entidades.TipoComprobante.Tipos.ORDENCOMPRAPROV.ToString())
         _publicos.CargaComboDesdeEnum(cmbEstados, Reglas.Publicos.EstadoAsignaTarea.PENDIENTE)
         _publicos.CargaComboDesdeEnum(cmbEsResultante, Entidades.Publicos.SiNoTodos.TODOS)

         '-- Inicializa Campos de Busqueda.- --
         RefrescarDatos()

         ugDetalle.AgregarFiltroEnLinea({"NombreProducto", "NombreCliente", "NombreProductoProceso"})
         ugDetalle.AgregarTotalesSuma({"CantidadSolicitada", "CantidadProcesada", "CantidadPendiente"})

         PreferenciasLeer(ugDetalle, tsbPreferencias)

      End Sub)
   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F3 Then
         btnConsultar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function

#End Region

#Region "Eventos"
#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatos())
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
   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugDetalle, tsbPreferencias))
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

#Region "Eventos Filtros"
   Private Sub chbEstado_CheckedChanged(sender As Object, e As EventArgs) Handles chbEstado.CheckedChanged
      TryCatched(Sub() chbEstado.FiltroCheckedChanged(cmbEstados))
   End Sub
   Private Sub chbCodigoOperacion_CheckedChanged(sender As Object, e As EventArgs) Handles chbCodigoOperacion.CheckedChanged
      TryCatched(Sub() chbCodigoOperacion.FiltroCheckedChanged(txtCodigoOperacion))
   End Sub
   Private Sub chbFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chbFecha.CheckedChanged
      TryCatched(Sub() chbFecha.FiltroCheckedChanged(chkMesCompleto, dtpDesde, dtpHasta))
   End Sub
   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub
   Private Sub chbTipoComprobante_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoComprobante.CheckedChanged
      TryCatched(Sub() chbTipoComprobante.FiltroCheckedChanged(cmbTipoComprobante))
   End Sub
   Private Sub chbLetraFiscal_CheckedChanged(sender As Object, e As EventArgs) Handles chbLetraFiscal.CheckedChanged
      TryCatched(Sub() chbLetraFiscal.FiltroCheckedChanged(cmbLetraFiscal))
   End Sub
   Private Sub chbCentroEmisor_CheckedChanged(sender As Object, e As EventArgs) Handles chbCentroEmisor.CheckedChanged
      TryCatched(Sub() chbCentroEmisor.FiltroCheckedChanged(cmbCentroEmisor))
   End Sub
   Private Sub chbOrdenProduccion_CheckedChanged(sender As Object, e As EventArgs) Handles chbOrdenProduccion.CheckedChanged
      TryCatched(Sub() chbOrdenProduccion.FiltroCheckedChanged(txtNumeroHasta, "0"))
      TryCatched(Sub() chbOrdenProduccion.FiltroCheckedChanged(txtNumeroDesde, "0"))
   End Sub
   Private Sub txtNumeroDesde_Enter(sender As Object, e As EventArgs) Handles txtNumeroDesde.Enter
      TryCatched(Sub() _prevNumeroDesde = txtNumeroDesde.ValorNumericoPorDefecto(0L))
   End Sub
   Private Sub txtNumeroDesde_Leave(sender As Object, e As EventArgs) Handles txtNumeroDesde.Leave
      TryCatched(Sub() txtNumeroHasta.SetValor(txtNumeroHasta.ValorNumericoPorDefecto(0L) + txtNumeroDesde.ValorNumericoPorDefecto(0L) - _prevNumeroDesde))
   End Sub
   Private Sub chbPlanMaestroNumero_CheckedChanged(sender As Object, e As EventArgs) Handles chbPlanMaestroNumero.CheckedChanged
      TryCatched(Sub() chbPlanMaestroNumero.FiltroCheckedChanged(txtPlanMaestroNumero, "0"))
   End Sub

#Region "Eventos Buscador Productos"
   Private Sub chbProducto_CheckedChanged(sender As Object, e As EventArgs) Handles chbProducto.CheckedChanged
      TryCatched(Sub() chbProducto.FiltroCheckedChanged(usaPermitido:=True, bscCodigoProducto, bscNombreProducto))
   End Sub
   Private Sub bscCodigoProducto_BuscadorClick() Handles bscCodigoProducto.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscCodigoProducto)
         bscCodigoProducto.Datos = New Reglas.Productos().GetPorCodigo(bscCodigoProducto.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS", True)
      End Sub)
   End Sub
   Private Sub bscNombreProducto_BuscadorClick() Handles bscNombreProducto.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscNombreProducto)
         bscNombreProducto.Datos = New Reglas.Productos().GetPorNombre(bscNombreProducto.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS", True)
      End Sub)
   End Sub
   Private Sub Producto_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscNombreProducto.BuscadorSeleccion, bscCodigoProducto.BuscadorSeleccion
      TryCatched(Sub() CargarDatosProducto(e.FilaDevuelta))
   End Sub
#End Region

#Region "Eventos Buscador Clientes"
   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      TryCatched(Sub() chbCliente.FiltroCheckedChanged(usaPermitido:=True, bscCodigoCliente, bscNombreCliente))
   End Sub
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes2(bscCodigoCliente)
         Dim codigoCliente = bscCodigoCliente.Text.ValorNumericoPorDefecto(-1L)
         bscCodigoCliente.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(codigoCliente, True, False)
      End Sub)
   End Sub
   Private Sub bscNombreCliente_BuscadorClick() Handles bscNombreCliente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes2(bscNombreCliente)
         bscNombreCliente.Datos = New Reglas.Clientes().GetFiltradoPorNombre(bscNombreCliente.Text.Trim(), True)
      End Sub)
   End Sub
   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscNombreCliente.BuscadorSeleccion
      TryCatched(Sub() CargarDatosCliente(e.FilaDevuelta))
   End Sub
#End Region

   Private Sub chbTipoComprobantePedido_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoComprobantePedido.CheckedChanged
      TryCatched(Sub() chbTipoComprobantePedido.FiltroCheckedChanged(cmbTipoComprobantePedido))
   End Sub
   Private Sub chbLetraFiscalPedido_CheckedChanged(sender As Object, e As EventArgs) Handles chbLetraFiscalPedido.CheckedChanged
      TryCatched(Sub() chbLetraFiscalPedido.FiltroCheckedChanged(cmbLetraFiscalPedido))
   End Sub
   Private Sub chbCentroEmisorPedido_CheckedChanged(sender As Object, e As EventArgs) Handles chbCentroEmisorPedido.CheckedChanged
      TryCatched(Sub() chbCentroEmisorPedido.FiltroCheckedChanged(cmbCentroEmisorPedido))
   End Sub
   Private Sub chbNumeroPedido_CheckedChanged(sender As Object, e As EventArgs) Handles chbNumeroPedido.CheckedChanged
      TryCatched(Sub() chbNumeroPedido.FiltroCheckedChanged(txtNumeroPedidoHasta, "0"))
      TryCatched(Sub() chbNumeroPedido.FiltroCheckedChanged(txtNumeroPedidoDesde, "0"))
   End Sub
   Private Sub txtNumeroPedidoDesde_Enter(sender As Object, e As EventArgs) Handles txtNumeroPedidoDesde.Enter
      TryCatched(Sub() _prevNumeroDesde = txtNumeroPedidoDesde.ValorNumericoPorDefecto(0L))
   End Sub
   Private Sub txtNumeroPedidoDesde_Leave(sender As Object, e As EventArgs) Handles txtNumeroPedidoDesde.Leave
      TryCatched(Sub() txtNumeroPedidoHasta.SetValor(txtNumeroPedidoHasta.ValorNumericoPorDefecto(0L) + txtNumeroPedidoDesde.ValorNumericoPorDefecto(0L) - _prevNumeroDesde))
   End Sub
   Private Sub chbLineaPedido_CheckedChanged(sender As Object, e As EventArgs) Handles chbLineaPedido.CheckedChanged
      TryCatched(Sub() chbLineaPedido.FiltroCheckedChanged(txtLineaPedido, "0"))
   End Sub
#End Region

   Private Sub ugDetalle_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugDetalle.InitializeRow
      TryCatched(
      Sub()
         Dim dr = e.Row.FilaSeleccionada(Of DataRow)
         If dr IsNot Nothing Then
            If dr.Field(Of Boolean)("EsProductoNecesario") Then
               e.Row.Cells("DescriptionEsProductoNecesario").Color(foreColor:=Color.Black, backColor:=Color.CadetBlue)
            Else
               e.Row.Cells("DescriptionEsProductoNecesario").Color(foreColor:=Color.Black, backColor:=Color.DarkOrange)
            End If
         End If
      End Sub)
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         'If ValidaConErrorBuilder(AddressOf ValidaCargaGrillaDetalle) Then
         CargaGrillaDetalle()
         PreferenciasLeer(ugDetalle, tsbPreferencias)

         If ugDetalle.Rows.Count = 0 Then
            ShowMessage("ATENCION: NO hay registros que cumplan con la selección!")
         End If
         'End If
      End Sub)
   End Sub

#End Region

#Region "Metodos"
   Private Sub RefrescarDatos()
      chbEstado.Checked = False
      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today.UltimoSegundoDelDia()
      chbFecha.Checked = False
      chkMesCompleto.Enabled = False

      chbTipoComprobante.Checked = False
      chbLetraFiscal.Checked = False
      chbCentroEmisor.Checked = False
      chbOrdenProduccion.Checked = False

      chbProducto.Checked = False
      chbCliente.Checked = False

      chbTipoComprobantePedido.Checked = False
      chbLetraFiscalPedido.Checked = False
      chbCentroEmisorPedido.Checked = False
      chbNumeroPedido.Checked = False
      chbLineaPedido.Checked = False

      cmbEsResultante.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS

      '-- Limpio la Grilla.-
      ugDetalle.ClearFilas()
   End Sub
   Private Sub CargarDatosProducto(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscNombreProducto.Text = dr.Cells("NombreProducto").Value.ToString()
         bscCodigoProducto.Text = dr.Cells("IdProducto").Value.ToString.Trim()
         bscNombreProducto.Permitido = False
         bscCodigoProducto.Permitido = False
         btnConsultar.Focus()
      End If
   End Sub
   Private Sub CargarDatosCliente(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscNombreCliente.Text = dr.Cells("NombreCliente").Value.ToString()
         bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString().Trim()
         bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
         bscNombreCliente.Permitido = False
         bscCodigoCliente.Permitido = False
         btnConsultar.Focus()
      End If
   End Sub

   Private Sub ValidaCargaGrillaDetalle(err As Entidades.ErrorBuilder)
      If chbEstado.Checked AndAlso cmbEstados.SelectedIndex < 0 Then
         err.AddError("ATENCION: NO seleccionó un Estado aunque activó ese Filtro.", cmbEstados)
      End If
      If chbCodigoOperacion.Checked AndAlso String.IsNullOrWhiteSpace(txtCodigoOperacion.Text) Then
         err.AddError("ATENCION: NO seleccionó una Operación aunque activó ese Filtro.", txtCodigoOperacion)
      End If
      If chbTipoComprobante.Checked AndAlso cmbTipoComprobante.SelectedIndex < 0 Then
         err.AddError("ATENCION: NO seleccionó un Tipo de Comprobante aunque activó ese Filtro.", cmbTipoComprobante)
      End If
      If chbLetraFiscal.Checked AndAlso cmbLetraFiscal.SelectedIndex < 0 Then
         err.AddError("ATENCION: NO seleccionó una Letra aunque activó ese Filtro.", cmbLetraFiscal)
      End If
      If chbCentroEmisor.Checked AndAlso cmbCentroEmisor.SelectedIndex < 0 Then
         err.AddError("ATENCION: NO seleccionó un Centro Emisor aunque activó ese Filtro.", cmbCentroEmisor)
      End If
      If chbOrdenProduccion.Checked AndAlso txtNumeroDesde.ValorNumericoPorDefecto(0L) = 0 Then
         err.AddError("ATENCION: NO seleccionó un Número Desde aunque activó ese Filtro.", txtNumeroDesde)
      End If
      If chbOrdenProduccion.Checked AndAlso txtNumeroHasta.ValorNumericoPorDefecto(0L) = 0 Then
         err.AddError("ATENCION: NO seleccionó un Número Hasta aunque activó ese Filtro.", txtNumeroHasta)
      End If
      If chbPlanMaestroNumero.Checked AndAlso txtPlanMaestroNumero.ValorNumericoPorDefecto(0L) = 0 Then
         err.AddError("ATENCION: NO seleccionó un Plan Maestro aunque activó ese Filtro.", txtPlanMaestroNumero)
      End If
      If chbProducto.Checked And Not bscCodigoProducto.Selecciono And Not bscNombreProducto.Selecciono Then
         err.AddError("ATENCION: NO seleccionó un Producto aunque activó ese Filtro.", bscCodigoProducto)
      End If
      If chbCliente.Checked And Not bscCodigoCliente.Selecciono And Not bscNombreCliente.Selecciono Then
         err.AddError("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro.", bscCodigoCliente)
      End If
      If chbTipoComprobantePedido.Checked AndAlso cmbTipoComprobantePedido.SelectedIndex < 0 Then
         err.AddError("ATENCION: NO seleccionó un Tipo de Comprobante de Pedido aunque activó ese Filtro.", cmbTipoComprobantePedido)
      End If
      If chbLetraFiscalPedido.Checked AndAlso cmbLetraFiscalPedido.SelectedIndex < 0 Then
         err.AddError("ATENCION: NO seleccionó una Letra de Pedido aunque activó ese Filtro.", cmbLetraFiscalPedido)
      End If
      If chbCentroEmisorPedido.Checked AndAlso cmbCentroEmisorPedido.SelectedIndex < 0 Then
         err.AddError("ATENCION: NO seleccionó un Centro Emisor de Pedido aunque activó ese Filtro.", cmbCentroEmisorPedido)
      End If
      If chbNumeroPedido.Checked AndAlso txtNumeroPedidoDesde.ValorNumericoPorDefecto(0L) = 0 Then
         err.AddError("ATENCION: NO seleccionó un Número de Pedido Desde aunque activó ese Filtro.", txtNumeroPedidoDesde)
      End If
      If chbNumeroPedido.Checked AndAlso txtNumeroPedidoHasta.ValorNumericoPorDefecto(0L) = 0 Then
         err.AddError("ATENCION: NO seleccionó un Número de Pedido Hasta aunque activó ese Filtro.", txtNumeroPedidoHasta)
      End If
      If chbLineaPedido.Checked AndAlso txtLineaPedido.ValorNumericoPorDefecto(0L) = 0 Then
         err.AddError("ATENCION: NO seleccionó una Línea de Pedido aunque activó ese Filtro.", txtLineaPedido)
      End If
   End Sub
   Private Sub CargaGrillaDetalle()
      Dim idEstado As Reglas.Publicos.EstadoAsignaTarea? = Nothing
      If chbEstado.Checked Then
         idEstado = cmbEstados.ValorSeleccionado(Of Reglas.Publicos.EstadoAsignaTarea)
      End If
      Dim codigoProcProdOperacion = txtCodigoOperacion.ValorSeleccionado(chbCodigoOperacion, String.Empty)
      Dim fechaDesde = dtpDesde.Valor(chbFecha)
      Dim fechaHasta = dtpHasta.Valor(chbFecha)

      Dim idTipocomprobante = cmbTipoComprobante.ValorSeleccionado(chbTipoComprobante, String.Empty)
      Dim letraFiscal = cmbLetraFiscal.ValorSeleccionado(chbLetraFiscal, String.Empty)
      Dim centroEmisor = cmbCentroEmisor.ValorSeleccionado(chbCentroEmisor, 0I)
      Dim numeroDesde = txtNumeroDesde.ValorSeleccionado(chbOrdenProduccion, 0L)
      Dim numeroHasta = txtNumeroHasta.ValorSeleccionado(chbOrdenProduccion, 0L)
      Dim planMaestroNumero = txtPlanMaestroNumero.ValorSeleccionado(chbPlanMaestroNumero, 0I)

      Dim idProducto = If(chbProducto.Checked, bscCodigoProducto.Text, String.Empty)
      Dim idCliente = If(chbCliente.Checked, Long.Parse(bscCodigoCliente.Tag.ToString()), 0L)

      Dim idTipocomprobantePedido = cmbTipoComprobantePedido.ValorSeleccionado(chbTipoComprobantePedido, String.Empty)
      Dim letraFiscalPedido = cmbLetraFiscalPedido.ValorSeleccionado(chbLetraFiscalPedido, String.Empty)
      Dim centroEmisorPedido = cmbCentroEmisorPedido.ValorSeleccionado(chbCentroEmisorPedido, 0I)
      Dim numeroPedidoDesde = txtNumeroPedidoDesde.ValorSeleccionado(chbNumeroPedido, 0L)
      Dim numeroPedidoHasta = txtNumeroPedidoHasta.ValorSeleccionado(chbNumeroPedido, 0L)
      Dim lineaPedido = txtLineaPedido.ValorSeleccionado(chbNumeroPedido, 0I)

      Dim esResultante = cmbEsResultante.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos)

      Dim rOP = New Reglas.OrdenesProduccionMRPProductos()
      Dim dtDetalle = rOP.GetInformeProductos(idEstado, codigoProcProdOperacion, fechaDesde, fechaHasta,
                                              idTipocomprobante, letraFiscal, centroEmisor, numeroDesde, numeroHasta,
                                              idProducto, idCliente,
                                              idTipocomprobantePedido, letraFiscalPedido, centroEmisorPedido, numeroPedidoDesde, numeroPedidoHasta, lineaPedido,
                                              planMaestroNumero, esResultante)

      ugDetalle.DataSource = dtDetalle
   End Sub

   Private Function AgregarFiltro(stb As StringBuilder, label As CheckBox, value As Control) As StringBuilder
      Return AgregarFiltro(stb, label.Text, label.Checked, Function() value.Text)
   End Function
   Private Function AgregarFiltro(stb As StringBuilder, label As CheckBox, value As Func(Of String)) As StringBuilder
      Return AgregarFiltro(stb, label.Text, label.Checked, value)
   End Function
   Private Function AgregarFiltro(stb As StringBuilder, labelText As String, agregar As Boolean, value As Func(Of String)) As StringBuilder
      Return AgregarFiltro(stb, agregar, Function() String.Format("{0}: {1} - ", labelText, value.Invoke()))
   End Function
   Private Function AgregarFiltro(stb As StringBuilder, agregar As Boolean, mensaje As Func(Of String)) As StringBuilder
      If agregar Then
         stb.AppendFormat(mensaje.Invoke())
      End If
      Return stb
   End Function
   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro
         AgregarFiltro(filtro, chbEstado, cmbEstados)
         AgregarFiltro(filtro, chbCodigoOperacion, txtCodigoOperacion)
         AgregarFiltro(filtro, chbFecha, Function() String.Format("{0}: {1} Hasta {2} - ", chbFecha.Text, dtpDesde.Text, dtpHasta.Text))

         AgregarFiltro(filtro, chbTipoComprobante, cmbTipoComprobante)
         AgregarFiltro(filtro, chbLetraFiscal, cmbLetraFiscal)
         AgregarFiltro(filtro, chbCentroEmisor, cmbCentroEmisor)
         AgregarFiltro(filtro, chbOrdenProduccion, Function() String.Format("{0}: {1} Hasta {2} - ", chbOrdenProduccion.Text, txtNumeroDesde.Text, txtNumeroHasta.Text))
         AgregarFiltro(filtro, chbPlanMaestroNumero, txtPlanMaestroNumero)

         AgregarFiltro(filtro, chbProducto, Function() String.Format("{0}: {1} - {2} - ", chbProducto.Text, bscCodigoProducto.Text, bscNombreProducto.Text))
         AgregarFiltro(filtro, chbCliente, Function() String.Format("{0}: {1} - {2} - ", chbCliente.Text, bscCodigoCliente.Text, bscNombreCliente.Text))

         AgregarFiltro(filtro, chbTipoComprobantePedido, cmbTipoComprobantePedido)
         AgregarFiltro(filtro, chbLetraFiscalPedido, cmbLetraFiscalPedido)
         AgregarFiltro(filtro, chbCentroEmisorPedido, cmbCentroEmisorPedido)
         AgregarFiltro(filtro, chbNumeroPedido, Function() String.Format("{0}: {1} Hasta {2} - ", chbNumeroPedido.Text, txtNumeroPedidoDesde.Text, txtNumeroPedidoHasta.Text))
         AgregarFiltro(filtro, chbLineaPedido, txtLineaPedido)
         AgregarFiltro(filtro, agregar:=cmbEsResultante.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos) <> Entidades.Publicos.SiNoTodos.TODOS,
                       Function() String.Format("{0}: {1} - ", lblEsResultante.Text, cmbEsResultante.Text))
      End With
      Return filtro.ToString().Trim().Trim("-"c)
   End Function

#End Region

End Class