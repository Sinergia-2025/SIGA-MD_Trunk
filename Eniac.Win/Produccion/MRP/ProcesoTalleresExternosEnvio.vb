Public Class ProcesoTalleresExternosEnvio
#Region "Campos"
   Private Const SeleccionMasivoColumnName As String = "Masivo"
   Private _publicos As Publicos

   Private _titOperaciones As Dictionary(Of String, String)
   Private _titResultantes As Dictionary(Of String, String)
   Private _titNecesarios As Dictionary(Of String, String)

   ''''Private eOperMRP As Entidades.OrdenProduccionMRPOperacion

   ''''Public Property NovedadesProduccion As Entidades.NovedadProduccionMRP
   ''''Public Property ListNovProduccion As List(Of Entidades.NovedadProduccionMRP)


   ''''Public Property novProduccion As Entidades.NovedadProduccionMRP
   ''''Public Property novNecesarios As Entidades.ListConBorrados(Of Entidades.NovedadProduccionMRPProducto)
   ''''Public Property novResultante As Entidades.ListConBorrados(Of Entidades.NovedadProduccionMRPProducto)
#End Region

#Region "New"
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         _publicos.CargaComboTiposComprobantes(cmbTipoComprobanteOP, True, "PRODUCCION", , , , True)
         _publicos.CargaComboTiposComprobantes(cmbTipoComprobantePedido, True, "PEDIDOSCLIE", , , , True)

         _publicos.CargaComboTiposComprobantes(cmbTiposComprobantes, True, Entidades.TipoComprobante.Tipos.COMPRAS.ToString(), AfectaCaja:=Entidades.Publicos.SiNoTodos.NO.ToString(), coeficionesStock:=-1)

         _publicos.CargaComboDesdeEnum(cmbTodos, Reglas.Publicos.TodosEnum.MararTodos)

         If cmbTiposComprobantes.Items.Count = 0 Then
            Throw New Exception("No Existe la PC en Configuraciones/Impresoras")
         ElseIf cmbTiposComprobantes.Items.Count = 1 Then
            cmbTiposComprobantes.SelectedIndex = 0
         End If

         ugOperaciones.AgregarFiltroEnLinea({"NombreProducto", "NombreProductoResultante", "NombreProveedor", "NombreCliente"})
         ugOperaciones.AgregarTotalesSuma({"CantidadSolicitada", "CantidadProcesada", "CantidadPendiente", "CantidadSeleccionada"})

         RefrescarDatosGrilla()

         tbcGeneral.SelectedTab = tbpGenerar

         _titOperaciones = GetColumnasVisiblesGrilla(ugOperaciones)
         _titResultantes = GetColumnasVisiblesGrilla(ugProductosResultantes)
         _titNecesarios = GetColumnasVisiblesGrilla(ugProductosNecesarios)

         tbcGeneral.SelectedTab = tbpSeleccion

         PreferenciasLeer(ugOperaciones, tsbPreferencias)

         ''''ListNovProduccion = New List(Of Entidades.NovedadProduccionMRP)
      End Sub,
      onErrorAction:=
      Sub(owner, ex)
         ShowError(ex)
         FormEnabled(False)
      End Sub)
   End Sub
   Protected Overrides Sub OnShown(e As EventArgs)
      MyBase.OnShown(e)
      TryCatched(Sub() EvaluaHabilitarToolbar())
      TryCatched(Sub() bscCodigoProveedor.Focus())
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F3 Then
         btnConsultar.PerformClick()
      ElseIf keyData = Keys.F4 Then
         tsbGrabar.PerformClick()
         tsbCalcular.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
#End Region

#Region "Eventos"

#Region "Eventos Filtros"
#Region "Eventos Buscador Proveedor"
   Private Sub chbProveedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbProveedor.CheckedChanged
      TryCatched(
      Sub()
         chbProveedor.FiltroCheckedChanged(usaPermitido:=True, bscCodigoProveedor, bscNombreProveedor)
         EvaluaHabilitarToolbar()
         'If Not chbProveedor.Checked Then
         '   tsbGrabar.Enabled = False
         'End If
         ugOperaciones.ClearFilas()
         LimpiaCalculados()
      End Sub)
   End Sub
   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProveedores2(Me.bscCodigoProveedor)
         Dim codigoProveedor = bscCodigoProveedor.Text.ValorNumericoPorDefecto(-1L)
         bscCodigoProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorCodigo(codigoProveedor)
      End Sub)
   End Sub
   Private Sub bscProveedor_BuscadorClick() Handles bscNombreProveedor.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProveedores2(bscNombreProveedor)
         bscNombreProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorNombre(bscNombreProveedor.Text.Trim())
      End Sub)
   End Sub
   Private Sub BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion, bscNombreProveedor.BuscadorSeleccion
      TryCatched(Sub() CargarDatosProveedor(e.FilaDevuelta))
   End Sub

#End Region
   Private Sub chbFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chbFecha.CheckedChanged
      TryCatched(Sub() chbFecha.FiltroCheckedChanged(chkMesCompleto, dtpDesde, dtpHasta))
   End Sub
   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub
#Region "Eventos Buscador Centro Productor"
   Private Sub chbCentroProductor_CheckedChanged(sender As Object, e As EventArgs) Handles chbCentroProductor.CheckedChanged
      TryCatched(Sub() chbCentroProductor.FiltroCheckedChanged(usaPermitido:=True, bscCodigoCentroProductor, bscNombreCentrosProductores))
   End Sub
   Private Sub bscCodigoCentroProductor_BuscadorClick() Handles bscCodigoCentroProductor.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaMRPCentrosProductores(bscCodigoCentroProductor)
         bscCodigoCentroProductor.Datos = New Reglas.MRPCentrosProductores().GetFiltradoPorCodigo(bscCodigoCentroProductor.Text.Trim(), Entidades.Publicos.SiNoTodos.NO, True)
      End Sub)
   End Sub
   Private Sub bscNombreCentrosProductores_BuscadorClick() Handles bscNombreCentrosProductores.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaMRPCentrosProductores(bscNombreCentrosProductores)
         bscNombreCentrosProductores.Datos = New Reglas.MRPCentrosProductores().GetFiltradoPorNombre(bscNombreCentrosProductores.Text.Trim(), Entidades.Publicos.SiNoTodos.SI, Entidades.Publicos.SiNoTodos.NO)
      End Sub)
   End Sub
   Private Sub bscCodigoCentroProductor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCentroProductor.BuscadorSeleccion, bscNombreCentrosProductores.BuscadorSeleccion
      TryCatched(Sub() CargarDatosCentroProductor(e.FilaDevuelta))
   End Sub
#End Region
   Private Sub chbOrdenProduccion_CheckedChanged(sender As Object, e As EventArgs) Handles chbOrdenProduccion.CheckedChanged
      TryCatched(Sub() chbOrdenProduccion.FiltroCheckedChanged(cmbTipoComprobanteOP))
      TryCatched(Sub() chbOrdenProduccion.FiltroCheckedChanged(txtIdOrdenProduccion))
   End Sub
#Region "Eventos Buscador Tareas"
   Private Sub chbTarea_CheckedChanged(sender As Object, e As EventArgs) Handles chbTarea.CheckedChanged
      TryCatched(Sub() chbTarea.FiltroCheckedChanged(usaPermitido:=True, bscNombreTareas))
   End Sub
   Private Sub bscNombreTareas_BuscadorClick() Handles bscNombreTareas.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaMRPTareas(bscNombreTareas)
         bscNombreTareas.Datos = New Reglas.MRPTareas().GetFiltradoPorNombre(bscNombreTareas.Text.Trim(), Entidades.Publicos.SiNoTodos.SI)
      End Sub)
   End Sub
   Private Sub bscNombreTareas_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscNombreTareas.BuscadorSeleccion
      TryCatched(Sub() CargarDatosTareas(e.FilaDevuelta))
   End Sub
   Private Sub chbPedidoVta_CheckedChanged(sender As Object, e As EventArgs) Handles chbPedidoVta.CheckedChanged
      TryCatched(Sub() chbPedidoVta.FiltroCheckedChanged(cmbTipoComprobantePedido))
      TryCatched(Sub() chbPedidoVta.FiltroCheckedChanged(txtLineaPedido))
      TryCatched(Sub() chbPedidoVta.FiltroCheckedChanged(txtNroPedido))
   End Sub
#End Region
#End Region

#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub
   Private Sub tsbCalcular_Click(sender As Object, e As EventArgs) Handles tsbCalcular.Click
      TryCatched(Sub() Calcular())
   End Sub
   Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
      TryCatched(Sub() Grabar())
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

   Private Sub tbcGeneral_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbcGeneral.SelectedIndexChanged
      TryCatched(Sub() EvaluaHabilitarToolbar())
   End Sub

#Region "Eventos Grillas"
   Private Sub ugOperaciones_CellChange(sender As Object, e As CellEventArgs) Handles ugOperaciones.CellChange
      TryCatched(
      Sub()
         If e.Cell.Column.Key = SeleccionMasivoColumnName Then
            e.Cell.UpdateData()
            SeleccionarFila(e.Cell.Row)
         End If
         EvaluaHabilitarToolbar()
         LimpiaCalculados()
      End Sub)
   End Sub

   Private Sub SeleccionarFila(row As UltraGridRow)
      Dim drActual = row.FilaSeleccionada(Of DataRow)()
      If drActual IsNot Nothing Then
         Dim drCol = ugOperaciones.DataSource(Of DataTable).Where(Function(x) x.Field(Of Integer)("IdSucursal") = drActual.Field(Of Integer)("IdSucursal") AndAlso
                                                                              x.Field(Of String)("IdTipoComprobante") = drActual.Field(Of String)("IdTipoComprobante") AndAlso
                                                                              x.Field(Of String)("LetraComprobante") = drActual.Field(Of String)("LetraComprobante") AndAlso
                                                                              x.Field(Of Integer)("CentroEmisor") = drActual.Field(Of Integer)("CentroEmisor") AndAlso
                                                                              x.Field(Of Integer)("NumeroOrdenProduccion") = drActual.Field(Of Integer)("NumeroOrdenProduccion") AndAlso
                                                                              x.Field(Of Integer)("Orden") = drActual.Field(Of Integer)("Orden") AndAlso
                                                                              x.Field(Of String)("IdProducto") = drActual.Field(Of String)("IdProducto") AndAlso
                                                                              x.Field(Of Long)("IdProcesoProductivo") = drActual.Field(Of Long)("IdProcesoProductivo"))
         For Each dr In drCol
            If drActual.Field(Of Boolean)(SeleccionMasivoColumnName) Then
               dr(SeleccionMasivoColumnName) = True
               dr("CantidadSeleccionada") = dr.Field(Of Decimal)("CantidadPendiente")
               ugOperaciones.Rows.GetRowWithListIndex(ugOperaciones.DataSource(Of DataTable).Rows.IndexOf(dr)).Cells("CantidadSeleccionada").Activation = If(drCol.Count < 2, Activation.AllowEdit, Activation.ActivateOnly)
            Else
               dr(SeleccionMasivoColumnName) = False
               dr("CantidadSeleccionada") = 0D
               ugOperaciones.Rows.GetRowWithListIndex(ugOperaciones.DataSource(Of DataTable).Rows.IndexOf(dr)).Cells("CantidadSeleccionada").Activation = Activation.ActivateOnly
            End If
         Next
         ugOperaciones.Rows.Refresh(RefreshRow.FireInitializeRow)
      End If
   End Sub

   Private Sub ugOperaciones_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugOperaciones.InitializeRow
      TryCatched(
      Sub()
         Dim dr = e.Row.FilaSeleccionada(Of DataRow)
         If dr IsNot Nothing Then
            If dr.Field(Of Boolean)(SeleccionMasivoColumnName) Then ' dr.Field(Of Decimal)("CantidadSeleccionada") <> 0 Then
               If e.Row.Cells("CantidadSeleccionada").Activation = Activation.AllowEdit Then
                  e.Row.Cells("CantidadSeleccionada").Color(Color.Black, Color.Cyan)
               Else
                  e.Row.Cells("CantidadSeleccionada").Color(Color.Black, Color.LightCyan)
               End If
            Else
               e.Row.Cells("CantidadSeleccionada").Color(Nothing, Nothing)
            End If
         End If
      End Sub)
   End Sub
   Private Sub ugProductosNecesarios_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugProductosNecesarios.InitializeRow
      TryCatched(
      Sub()
         Dim dr = e.Row.FilaSeleccionada(Of DataRow)()
         If dr IsNot Nothing Then
            'Dim prod = DirectCast(dr("Producto"), Entidades.ProductoLivianoParaImportarProducto)
            With e.Row
               If Not dr.Field(Of Boolean)("LoteProductoProceso") Then
                  .Cells("LoteSeleccionado").Activation = Activation.Disabled
               End If
               If Not dr.Field(Of Boolean)("NroSerieProductoProceso") Then
                  .Cells("NroSerieSeleccionado").Activation = Activation.Disabled
               End If
            End With
         End If
         e.Row.Cells("CantidadSeleccionadaCompra").Value = Math.Round(Convert.ToDecimal(e.Row.Cells("CantidadSeleccionadaCompra").Value), Reglas.Publicos.Compras.Redondeo.ComprasDecimalesRedondeoEnCantidad)

      End Sub)
   End Sub
   Private Sub ugProductosNecesarios_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugProductosNecesarios.ClickCellButton
      TryCatched(
      Sub()
         Dim dr = ugProductosNecesarios.FilaSeleccionada(Of DataRow)
         If dr IsNot Nothing Then
            Dim tipoComp = cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante)

            If tipoComp IsNot Nothing Then
               Dim selectedColumn = e.Cell.Column.Key
               Select Case selectedColumn
                  Case "NombreDepositoUbicacion"
                     Using frm = New SeleccionMultipleUbicacion()
                        If frm.ShowDialog(Me, tipoComp.CoeficienteStock, tipoComp.SolicitaInformeCalidad,
                                          dr.Field(Of String)("IdProductoProceso"), actual.Sucursal.Id, dr.Field(Of List(Of Entidades.SeleccionMultipleUbicaciones))("SeleccionMultiple"),
                                          dr.Field(Of Decimal)("CantidadSeleccionada"),
                                          SeleccionMultipleUbicacion.ModosUbicacion.MultiplesUbicaciones, SeleccionMultipleUbicacion.ModosLoteSerie.Invisible) = DialogResult.OK Then
                           dr("SeleccionMultiple") = frm.UbicacionesSeleccionadas
                           EvaluaColecciones(dr)
                        End If
                     End Using
                  Case "LoteSeleccionado"
                     Using frm = New SeleccionMultipleUbicacion()
                        If frm.ShowDialog(Me, tipoComp.CoeficienteStock, tipoComp.SolicitaInformeCalidad,
                                          dr.Field(Of String)("IdProducto"), actual.Sucursal.Id, dr.Field(Of List(Of Entidades.SeleccionMultipleUbicaciones))("SeleccionMultiple"),
                                          dr.Field(Of Decimal)("CantidadSeleccionada"),
                                          SeleccionMultipleUbicacion.ModosUbicacion.MultiplesUbicaciones, SeleccionMultipleUbicacion.ModosLoteSerie.Visible) = DialogResult.OK Then
                           dr("SeleccionMultiple") = frm.UbicacionesSeleccionadas
                           EvaluaColecciones(dr)
                        End If
                     End Using

                  Case "NroSerieSeleccionado"
                     Using frm = New SeleccionMultipleUbicacion()
                        If frm.ShowDialog(Me, tipoComp.CoeficienteStock, tipoComp.SolicitaInformeCalidad,
                                          dr.Field(Of String)("IdProducto"), actual.Sucursal.Id, dr.Field(Of List(Of Entidades.SeleccionMultipleUbicaciones))("SeleccionMultiple"),
                                          dr.Field(Of Decimal)("CantidadSeleccionada"),
                                          SeleccionMultipleUbicacion.ModosUbicacion.MultiplesUbicaciones, SeleccionMultipleUbicacion.ModosLoteSerie.Visible) = DialogResult.OK Then
                           dr("SeleccionMultiple") = frm.UbicacionesSeleccionadas
                           EvaluaColecciones(dr)
                        End If
                     End Using

                  Case Else

               End Select
            End If
         End If
      End Sub)
   End Sub

   Private Sub ugProductosResultantes_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugProductosResultantes.ClickCellButton
      TryCatched(
      Sub()
         Dim dr = ugProductosResultantes.FilaSeleccionada(Of DataRow)
         If dr IsNot Nothing Then
            Using frm = New ProcesoTalleresExternosEnvioVincularOC()
               frm.ShowDialog(Me, dr, ugProductosResultantes.DataSource(Of DataTable)())
               ugProductosResultantes.Rows.Refresh(RefreshRow.FireInitializeRow)
            End Using
         End If
      End Sub)

   End Sub

#End Region
   Private Sub cmbTiposComprobantes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTiposComprobantes.SelectedIndexChanged
      TryCatched(Sub() EvaluaMostrarBotonesProductosNecesario())
   End Sub
   Private Sub bscTransportista_BuscadorClick() Handles bscTransportista.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaTransportistas(bscTransportista)
         bscTransportista.Datos = New Reglas.Transportistas().GetFiltradoPorNombre(bscTransportista.Text.Trim())
      End Sub)
   End Sub
   Private Sub bscTransportista_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscTransportista.BuscadorSeleccion
      TryCatched(Sub() CargarDatosTransportista(e.FilaDevuelta))
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         If ValidaDatosConsulta() Then
            cmbTodos.SelectedValue = Reglas.Publicos.TodosEnum.MararTodos
            CargaGrillaDetalle()
            If ugOperaciones.Rows.Count = 0 Then
               ShowMessage("ATENCION: NO hay registros que cumplan con la selección!")
            End If
         End If
      End Sub)
   End Sub

   Private Sub controlRemitoTransporte_KeyDown(sender As Object, e As KeyEventArgs) Handles txtValorDeclarado.KeyDown, txtNumeroLote.KeyDown, txtBultos.KeyDown, cmbTiposComprobantes.KeyDown
      PresionarTab(e)
   End Sub

#Region "Marcar/Desmarcar Todos"
   Private Sub btnTodos_Click(sender As Object, e As EventArgs) Handles btnTodos.Click
      TryCatched(
      Sub()
         ugOperaciones.MarcarDesmarcar(cmbTodos, SeleccionMasivoColumnName, accionAdicional:=Sub(selec, dr) SeleccionarFila(dr))
      End Sub)
   End Sub
#End Region

#End Region

#Region "Metodos"
   Private Sub CargarDatosProveedor(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscNombreProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
         bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
         bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString
         bscNombreProveedor.Permitido = False
         bscCodigoProveedor.Permitido = False
         btnConsultar.Focus()
      End If
   End Sub
   Private Sub CargarDatosCentroProductor(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscCodigoCentroProductor.Text = dr.Cells("CodigoCentroProductor").Value.ToString()
         bscCodigoCentroProductor.Tag = dr.Cells("IdCentroProductor").Value.ToString()
         bscNombreCentrosProductores.Text = dr.Cells("Descripcion").Value.ToString()
         bscCodigoCentroProductor.Permitido = False
         bscNombreCentrosProductores.Permitido = False
         btnConsultar.Focus()
      End If
   End Sub
   Private Sub CargarDatosTareas(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscNombreTareas.Text = dr.Cells("Descripcion").Value.ToString()
         bscNombreTareas.Tag = Integer.Parse(dr.Cells("IdTarea").Value.ToString())
         bscNombreTareas.Permitido = False
         btnConsultar.Focus()
      End If
   End Sub
   Private Sub CargarDatosTransportista(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscTransportista.Text = dr.Cells("NombreTransportista").Value.ToString()
         bscTransportista.Tag = Long.Parse(dr.Cells("IdTransportista").Value.ToString())
         txtNumeroLote.Focus()
      End If
   End Sub

   Private Sub RefrescarDatosGrilla()

      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today.UltimoSegundoDelDia()

      chbProveedor.Checked = False
      chbProveedor.Checked = True

      bscCodigoProveedor.Text = String.Empty
      bscNombreProveedor.Text = String.Empty

      chbCentroProductor.Checked = False
      chbTarea.Checked = False

      chkMesCompleto.Checked = False
      chbOrdenProduccion.Checked = False
      chbPedidoVta.Checked = False

      '-- Limpio la Grilla Operaciones.- ------------------------------
      ugOperaciones.ClearFilas()
      LimpiaCalculados()
      tbcGeneral.SelectedTab = tbpSeleccion
      EvaluaHabilitarToolbar()
      '----------------------------------------------------------------

      cmbTodos.SelectedValue = Reglas.Publicos.TodosEnum.MararTodos

      bscCodigoProveedor.Focus()
   End Sub

   Private Function ValidaDatosConsulta() As Boolean
      '------------------------------------------------
      If chbProveedor.Checked AndAlso Not bscCodigoProveedor.Selecciono AndAlso Not bscNombreProveedor.Selecciono Then
         ShowMessage("Debe seleccionar un Proveedor para realizar la consulta!!!")
         bscCodigoProveedor.Focus()
         Return False
      End If
      '------------------------------------------------
      If chbCentroProductor.Checked AndAlso Not bscCodigoCentroProductor.Selecciono AndAlso Not bscNombreCentrosProductores.Selecciono Then
         ShowMessage("Debe seleccionar un Centro Productor para realizar la consulta!!!")
         bscCodigoCentroProductor.Focus()
         Return False
      End If
      '------------------------------------------------
      If chbTarea.Checked AndAlso Not bscNombreTareas.Selecciono Then
         ShowMessage("Debe seleccionar una Tarea para realizar la consulta!!!")
         bscNombreTareas.Focus()
         Return False
      End If
      If chbOrdenProduccion.Checked AndAlso txtIdOrdenProduccion.Text.ValorNumericoPorDefecto(0I) = 0 Then
         ShowMessage("ATENCION: NO Ingresó un Número de Orden de Produccion aunque activó ese Filtro.")
         txtIdOrdenProduccion.Focus()
         Return False
      End If
      Return True
   End Function
   Private Sub CargaGrillaDetalle()
      Dim idProveedor = If(chbProveedor.Checked, Long.Parse(bscCodigoProveedor.Tag.ToString()), 0L)
      Dim fechaDesde = dtpDesde.Valor(chbFecha)
      Dim fechaHasta = dtpHasta.Valor(chbFecha)
      Dim idCentroProductor = If(chbCentroProductor.Checked, Integer.Parse(bscCodigoCentroProductor.Tag.ToString()), 0I)

      Dim idTipocomprobanteOP = cmbTipoComprobanteOP.ValorSeleccionado(chbOrdenProduccion, String.Empty)
      Dim numeroOrdenProduccion = txtIdOrdenProduccion.ValorSeleccionado(chbOrdenProduccion, 0L)

      Dim numeroPedido = If(chbPedidoVta.Checked, txtNroPedido.ValorNumericoPorDefecto(0I), 0I)
      Dim ordenPedido = If(chbPedidoVta.Checked, txtLineaPedido.ValorNumericoPorDefecto(0I), 0I)
      Dim idTipocomprobantePe = If(chbPedidoVta.Checked, cmbTipoComprobantePedido.SelectedValue.ToString(), String.Empty)

      Dim rOP = New Reglas.OrdenesProduccionMRPOperaciones()
      ugOperaciones.DataSource = rOP.GetOperacionesEnvioTalleresExternos(idProveedor, fechaDesde, fechaHasta, idCentroProductor, idTipocomprobanteOP, numeroOrdenProduccion, idTipocomprobantePe, numeroPedido, ordenPedido)
      AjustarColumnasGrilla(ugOperaciones, _titOperaciones)
      PreferenciasLeer(ugOperaciones, tsbPreferencias)

      ugProductosNecesarios.DisplayLayout.Bands(0).Columns("CantidadSeleccionadaCompra").Format = String.Format("N{0}", Reglas.Publicos.Compras.Redondeo.ComprasDecimalesMostrarEnCantidad)

      EvaluaHabilitarToolbar()
      LimpiaCalculados()
      tbcGeneral.SelectedTab = tbpSeleccion
   End Sub


   Private Sub EvaluaHabilitarToolbar()
      tsbCalcular.Visible = tbcGeneral.SelectedTab IsNot Nothing AndAlso tbcGeneral.SelectedTab.Equals(tbpSeleccion)
      tsbGrabar.Visible = tbcGeneral.SelectedTab IsNot Nothing AndAlso tbcGeneral.SelectedTab.Equals(tbpGenerar)

      If ugOperaciones.DataSource(Of DataTable) IsNot Nothing Then
         tsbCalcular.Enabled = chbProveedor.Checked AndAlso ugOperaciones.DataSource(Of DataTable).Any(Function(dr) dr.Field(Of Boolean)(SeleccionMasivoColumnName))
      End If
      If ugProductosResultantes.DataSource(Of DataTable) IsNot Nothing Then
         tsbGrabar.Enabled = ugOperaciones.DataSource(Of DataTable).Any()
      End If
   End Sub

   Public Sub EvaluaMostrarBotonesProductosNecesario()
      If ugProductosNecesarios.DataSource IsNot Nothing Then
         Dim tipoComp = cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante)()
         If tipoComp IsNot Nothing Then
            With ugProductosNecesarios.DisplayLayout.Bands(0)
               .Columns("NombreDepositoUbicacion").Hidden = True
               .Columns("LoteSeleccionado").Hidden = True
               .Columns("NroSerieSeleccionado").Hidden = True

               'Si el comprobante afecta stock
               If tipoComp.CoeficienteStock <> 0 Then
                  Dim _dtProductosNecesarios = ugProductosNecesarios.DataSource(Of DataTable)()
                  'Si hay al menos un producto que AfectaStock muestro la columna 
                  If _dtProductosNecesarios.Any(Function(dr) dr.Field(Of Boolean)("AfectaStockProductoProceso")) Then
                     .Columns("NombreDepositoUbicacion").Hidden = False
                  End If
                  'Si hay al menos un producto que usa Lote muestro la columna 
                  If _dtProductosNecesarios.Any(Function(dr) dr.Field(Of Boolean)("LoteProductoProceso")) Then
                     .Columns("LoteSeleccionado").Hidden = False
                  End If
                  'Si hay al menos un producto que usa Nro de Serie muestro la columna 
                  If _dtProductosNecesarios.Any(Function(dr) dr.Field(Of Boolean)("NroSerieProductoProceso")) Then
                     .Columns("NroSerieSeleccionado").Hidden = False
                  End If
               End If
            End With
         End If
      End If
   End Sub

   Private Function EvaluaColecciones(dr As DataRow) As DataRow

      Dim ubicAdmin = dr.Field(Of List(Of Entidades.SeleccionMultipleUbicaciones))("SeleccionMultiple") ' _ubicaciones(dr)
      If ubicAdmin Is Nothing Then
         ubicAdmin = New List(Of Entidades.SeleccionMultipleUbicaciones)()
         'dr("SeleccionMultiple") = ubicAdmin
      End If

      If Not ubicAdmin.AnySecure() Then
         dr("NombreDepositoUbicacion") = "(Sin seleccionar)" ' String.Format("{0}/{1}", dr.Field(Of String)("NombreDepositoDefecto"), dr.Field(Of String)("NombreUbicacionDefecto"))
      Else
         If ubicAdmin.Count = 1 Then
            Dim u = ubicAdmin.First()
            dr("NombreDepositoUbicacion") = String.Format("{0}/{1}", u.NombreDeposito, u.NombreUbicacion)
         Else
            dr("NombreDepositoUbicacion") = "(multiples)"
         End If
      End If

      Return dr
   End Function


   Private Sub Calcular()
      ugOperaciones.UpdateData()
      Dim rOP = New Reglas.OrdenesProduccionMRPOperaciones()
      '-- REQ-42438.- ------------------------------------------------------------------------------
      Dim idProveedor = If(chbProveedor.Checked, Long.Parse(bscCodigoProveedor.Tag.ToString()), 0L)

      Dim ds = rOP.CalculaProductosEnvioTalleresExternos(ugOperaciones.DataSource(Of DataTable).Where(Function(dr) dr.Field(Of Boolean)(SeleccionMasivoColumnName)).CopyToDataTable(), idProveedor)
      ugProductosResultantes.DataSource = ds.Tables("ProductosResultantes")
      ugProductosNecesarios.DataSource = ds.Tables("ProductosNecesarios")

      AjustarColumnasGrilla(ugProductosResultantes, _titResultantes)
      AjustarColumnasGrilla(ugProductosNecesarios, _titNecesarios)

      tbcGeneral.SelectedTab = tbpGenerar
      EvaluaMostrarBotonesProductosNecesario()

      ugProductosNecesarios.DataSource(Of DataTable).ForEach(Sub(dr) EvaluaColecciones(dr))

   End Sub
   Private Sub Grabar()
      If ValidarGrabacion() Then
         'Definición de la grabación:
         '1. Generar Remito Compra de Salida con la mercadería enviada al proveedor.
         '2. Cambiar el estado de las OC vinculadas al estado definido (definir donde). Dicho estado debe estar configurado para que genere el PP.
         '3. Vincular 'de alguna manera' la OC con la OP

         Dim rOP = New Reglas.OrdenesProduccionMRPOperaciones()
         Dim prov = New Reglas.Proveedores().GetUno(Long.Parse(bscCodigoProveedor.Tag.ToString()))
         Dim tran = New Reglas.Transportistas().GetUno(Long.Parse(bscTransportista.Tag.ToString()))
         rOP.GrabarProductosEnvioTalleresExternos(ugProductosResultantes.DataSource(Of DataTable), ugProductosNecesarios.DataSource(Of DataTable),
                                                  cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante), prov,
                                                  tran, txtBultos.ValorNumericoPorDefecto(0I), txtValorDeclarado.ValorNumericoPorDefecto(0D), txtNumeroLote.ValorNumericoPorDefecto(0I),
                                                  IdFuncion)
         ShowMessage("El envio a Talleres Externos fue existoso.")
         RefrescarDatosGrilla()
      End If
   End Sub
   Private Function ValidarGrabacion() As Boolean
      'Validaciones especiales si es Remito Transportista
      Dim tipoComprobante = cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante)()
      If tipoComprobante.EsRemitoTransportista Then
         If txtBultos.ValorNumericoPorDefecto(0L) <= 0 Then
            ShowMessage("ATENCION: Debe ingresar el Total de Bultos del Remito.")
            tbcGeneral.SelectedTab = tbpGenerar
            txtBultos.Focus()
            Return False
         End If

         If Not bscTransportista.Selecciono Then
            ShowMessage("Debe ingresar el Transportista del Remito.")
            tbcGeneral.SelectedTab = tbpGenerar
            bscTransportista.Focus()
            Return False
         End If

         If Not IsNumeric(txtNumeroLote.Text) Then
            ShowMessage("El Lote del Remito debe ser numérico.")
            tbcGeneral.SelectedTab = tbpGenerar
            txtNumeroLote.Focus()
            Return False
         End If

         If Reglas.Publicos.Facturacion.FacturacionRemitoTranspUtilizaLote AndAlso txtNumeroLote.ValorNumericoPorDefecto(0L) <= 0 Then
            ShowMessage("Debe ingresar el Lote del Remito.")
            tbcGeneral.SelectedTab = tbpGenerar
            txtNumeroLote.Focus()
            Return False
         End If
      End If

      Return True
   End Function

   Private Sub LimpiaCalculados()
      ugProductosResultantes.ClearFilas()
      ugProductosNecesarios.ClearFilas()
   End Sub

   Private Sub FormEnabled(value As Boolean)
      grpFiltros.Enabled = value
      tbcGeneral.Enabled = value
      tspBarra.Items.OfType(Of ToolStripButton).ToList().ForEach(
         Sub(tsb)
            If Not tsb.Equals(tsbSalir) Then
               If value Then
                  tsb.Enabled = tsb.TagAs(Of Boolean)()
                  tsb.Tag = Nothing
               Else
                  tsb.Tag = tsb.Enabled
                  tsb.Enabled = value
               End If
            End If
         End Sub)
   End Sub

   Private Sub ugProductosNecesarios_CellChange(sender As Object, e As CellEventArgs) Handles ugProductosNecesarios.CellChange
      TryCatched(Sub() ugProductosNecesarios.UpdateData())
   End Sub

   Private Sub ugProductosNecesarios_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles ugProductosNecesarios.AfterCellUpdate
      TryCatched(
    Sub()
       Dim dr = e.Cell.Row.FilaSeleccionada(Of DataRow)()
       If dr IsNot Nothing AndAlso e.Cell.Column.Key = "CantidadSeleccionada" Then
          dr("CantidadSeleccionadaCompra") = dr.Field(Of Decimal)("CantidadSeleccionada") * dr.Field(Of Decimal)("FactorConversionCompra")
       End If
    End Sub)
   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugOperaciones, tsbPreferencias))
   End Sub



   ''''Private Sub LimpiaEntidadesNovedad()
   ''''   novNecesarios = New Entidades.ListConBorrados(Of Entidades.NovedadProduccionMRPProducto)
   ''''   '-- Refresca los Datos de la Grilla.- ---------------------
   ''''   ugProductosNecesarios.DataSource = novNecesarios
   ''''   ugProductosNecesarios.Rows.Refresh(RefreshRow.FireInitializeRow)
   ''''   '-- Formate Grilla.- --------------------------------------
   ''''   FormateGrillaNecesarios()

   ''''   novResultante = New Entidades.ListConBorrados(Of Entidades.NovedadProduccionMRPProducto)
   ''''   '-- Refresca los Datos de la Grilla.- ---------------------
   ''''   ugProductosResultantes.DataSource = novResultante
   ''''   ugProductosResultantes.Rows.Refresh(RefreshRow.FireInitializeRow)
   ''''   '-- Formate Grilla.- --------------------------------------
   ''''   FormateGrillaResultantes()

   ''''End Sub
#End Region
End Class