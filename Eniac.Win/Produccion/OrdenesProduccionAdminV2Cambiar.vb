Public Class OrdenesProduccionAdminV2Cambiar
   Private Const seleccionMasivoColumnName As String = "masivo"

#Region "Campos"

   Private _publicos As Publicos
   ''''Private _idEstado As String = String.Empty
   ''''Private _idTipoEstado As String = String.Empty
   Private _idCriticidad As String = String.Empty
   Private _fechaEntrega As Date? = Nothing

   Private _tipoTipoComprobante As String

   Private _dsDetalle As DataSet
   Private _dtDetalle As DataTable
   Private _dtComponentes As DataTable
   Private _dtDetalleOrigen As DataTable

   Private _cache As Reglas.BusquedasCacheadas
   Private _tit As Dictionary(Of String, String)
   Private _ubicaciones As Dictionary(Of DataRow, List(Of Entidades.SeleccionMultipleUbicaciones))
   Private _ubicacionesComponentes As Dictionary(Of DataRow, List(Of Entidades.SeleccionMultipleUbicaciones))
   Private _ubicacionesComponentesDestino As Dictionary(Of DataRow, List(Of Entidades.SeleccionMultipleUbicaciones))

   Private _cargaComboDestino As Boolean = True

#End Region

   Public Sub New()
      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
      _cache = New Reglas.BusquedasCacheadas()
   End Sub
   Public Sub New(cache As Reglas.BusquedasCacheadas)
      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
      _cache = cache
   End Sub

#Region "Overrides/Overloads"
   Public Overloads Function ShowDialog(owner As BaseForm, tipoTipoComprobante As String, dt As DataTable) As DialogResult
      _tipoTipoComprobante = tipoTipoComprobante

      ''_dsDetalle = New DataSet()

      _dtDetalleOrigen = dt

      ''''RefrescarDatosGrilla(dt)

      Return ShowDialog(owner)
   End Function

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()

         If String.IsNullOrWhiteSpace(_tipoTipoComprobante) Then _tipoTipoComprobante = Entidades.TipoComprobante.Tipos.PRODUCCION.ToString()

         _publicos = New Publicos()

         ''''_publicos.CargaComboEstadosOrdenesProduccion(cmbEstados, True, True, True, False, String.Empty)
         ''''cmbEstados.SelectedIndex = 1  'SOLO PENDIENTES


         ''''_publicos.CargaComboMarcas(cmbMarca)
         ''''_publicos.CargaComboRubros(cmbRubro)
         ''''_publicos.CargaComboSubRubros(cmbSubRubro)
         _publicos.CargaComboCriticidades(cmbCriticidad)
         _publicos.CargaComboCriticidades(cmbCriticidadEditor)

         _publicos.CargaComboEmpleados(cmbResponsable, Entidades.Publicos.TiposEmpleados.RESPPROD)
         _publicos.CargaComboEmpleados(cmbResponsableEditor, Entidades.Publicos.TiposEmpleados.RESPPROD)

         ''''_publicos.CargaComboDesdeEnum(cmbTodos, GetType(Reglas.Publicos.TodosEnum))
         ''''_publicos.CargaComboEmpleados(cmbResponsable, Entidades.Publicos.TiposEmpleados.RESPPROD)
         '''''cmbResponsable.SelectedIndex = -1

         ''''If Not Reglas.Publicos.ProductoTieneSubRubro Then
         ''''   chbSubRubro.Visible = False
         ''''   cmbSubRubro.Visible = False
         ''''End If

         ''''dtpDesde.Value = Date.Today
         ''''dtpHasta.Value = Date.Today.UltimoSegundoDelDia()

         With ugDetalle.DisplayLayout.Bands(0)
            '.Columns("NombreModelo").Hidden = Not Reglas.Publicos.ProductoTieneModelo
            '.Columns("NombreSubRubro").Hidden = Not Reglas.Publicos.ProductoTieneSubRubro
            '.Columns("NombreSubSubRubro").Hidden = Not Reglas.Publicos.ProductoTieneSubSubRubro
         End With



         _cargaComboDestino = True
         _publicos.CargaComboEstadosOrdenesProduccion(cmbEstadoCambiar, False, False, False, False, String.Empty)
         '-- Carga Combos de Depositos-Ubicaciones.-
         ''''_publicos.CargaComboDepositos(cmbDepositos, actual.Sucursal.IdSucursal, miraUsuario:=True, PermiteEscritura:=True, disponibleventa:=True)
         ''''_cargaComboDestino = False
         ''''If cmbDepositos.Items.Count > 0 Then cmbDepositos.SelectedIndex = 0
         ''''_publicos.CargaComboUbicaciones(cmbUbicacion, cmbDepositos.ValorSeleccionado(Of Integer), actual.Sucursal.IdSucursal)
         ''''If cmbUbicacion.Items.Count > 0 Then cmbUbicacion.SelectedIndex = 0

         'Da la posibilidad de que podamos elegir las columnas que queremos mostrar u ocultar con un botón a la izquierda de la cabecera.
         ugDetalle.DisplayLayout.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.ColumnChooserButton

         ugDetalle.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
         cmbEstadoCambiar.SelectedIndex = 0

         '_tit = GetColumnasVisiblesGrilla(ugDetalle)

         ugDetalle.AgregarFiltroEnLinea({"NombreCliente", "NombreProducto", "observacion"}, {"ClipArchivoAdjunto"})

         ugDetalle.AgregarTotalesSuma({"cantEntregada", "cantPendiente"})

         'PreferenciasLeer(ugDetalle, tsbPreferencias)
         _tit = GetColumnasVisiblesGrilla(ugDetalle)
         RefrescarDatosGrilla(_dtDetalleOrigen)
         ''''ugDetalle.DataSource = _dsDetalle
         ''''ugDetalle.DataMember = "DetalleProducto"
         ''''AjustarColumnasGrilla(ugDetalle, _tit)
         ''''FormatearGrillaDetalleComponentes()

      End Sub)
   End Sub
   Protected Overrides Sub OnShown(e As EventArgs)
      MyBase.OnShown(e)
      FormatearGrillaDetalleComponentes()
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F4 Then
         btnAceptar.PerformClick()
      ElseIf keyData = Keys.Escape AndAlso (ugDetalle.ActiveCell Is Nothing OrElse Not ugDetalle.ActiveCell.IsInEditMode) Then
         btnCancelar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
   Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
      If DialogResult = DialogResult.Cancel Then
         If ShowPregunta("¿Desea cancelar el cambio de estado?", MessageBoxDefaultButton.Button2) = DialogResult.No Then
            e.Cancel = True
         End If
      End If
      MyBase.OnFormClosing(e)
   End Sub
#End Region

#Region "Eventos"

#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla(_dtDetalleOrigen))
   End Sub
   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      'TryCatched(Sub() ugDetalle.Imprimir(CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True, .FitWidthToPages = 1}))
      TryCatched(Sub() ugDetalle.Imprimir("", New ImprimirUltraGridParams() With {.Landscape = True, .FitWidthToPages = 1}))
   End Sub
   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridExcelExporter1, String.Empty))
   End Sub
   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridDocumentExporter1, String.Empty))
   End Sub

#End Region

#Region "Eventos Aceptar/Cancelar"
   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      TryCatched(Sub() Aceptar())
   End Sub

   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      TryCatched(Sub() Cancelar())
   End Sub
#End Region

#Region "Eventos Aplicar Masivo"
   Private Sub btnAplicaCriticidad_Click(sender As Object, e As EventArgs) Handles btnAplicaCriticidad.Click
      TryCatched(Sub() If cmbCriticidad.SelectedIndex > -1 Then AplicarDatosMasivos("IdCriticidad", cmbCriticidad.SelectedValue))
   End Sub
   Private Sub btnAplicaFechaEntrega_Click(sender As Object, e As EventArgs) Handles btnAplicaFechaEntrega.Click
      TryCatched(Sub() AplicarDatosMasivos("FechaEntrega", dtpFechaEntrega.Value))
   End Sub
   Private Sub btnAplicaCantidad_Click(sender As Object, e As EventArgs) Handles btnAplicaCantidad.Click
      TryCatched(
      Sub()
         If txtCantidad.ValorNumericoPorDefecto(0D) > -0 Then
            AplicarDatosMasivos("CantidadNuevoEstado", Function(dr) Math.Min(txtCantidad.ValorNumericoPorDefecto(0D), dr.Field(Of Decimal)("CantidadNuevoEstado")))
         End If
      End Sub)
   End Sub
   Private Sub btnAplicaResponsable_Click(sender As Object, e As EventArgs) Handles btnAplicaResponsable.Click
      TryCatched(Sub() If cmbResponsable.SelectedIndex > -1 Then AplicarDatosMasivos("IdResponsable", cmbResponsable.SelectedValue))
   End Sub
#End Region

   Private Sub controles_KeyDown(sender As Object, e As KeyEventArgs) Handles txtObservacion.KeyDown, cmbEstadoCambiar.KeyDown, cmbCriticidad.KeyDown, dtpFechaEntrega.KeyDown, txtCantidad.KeyDown, cmbResponsable.KeyDown
      PresionarTab(e)
   End Sub
   Private Sub txtCantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidad.KeyDown, dtpFechaEntrega.KeyDown, cmbCriticidad.KeyDown
      TryCatched(
      Sub()
         If e.KeyCode = Keys.Enter Then
            If sender.Equals(cmbCriticidad) Then
               btnAplicaCriticidad.PerformClick()
            ElseIf sender.Equals(dtpFechaEntrega) Then
               btnAplicaFechaEntrega.PerformClick()
            ElseIf sender.Equals(txtCantidad) Then
               btnAplicaCantidad.PerformClick()
            End If
            PresionarTab(e)
         End If
      End Sub)
   End Sub
   Private Sub txtCantidad_GotFocus(sender As Object, e As EventArgs)
      TryCatched(Sub() txtCantidad.SelectAll())
   End Sub
   'Private Sub cmbEstadoCambiar_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbEstadoCambiar.SelectedValueChanged
   '   TryCatched(
   '   Sub()
   '      If Not _cargaComboDestino Then
   '         Dim cache = New Reglas.BusquedasCacheadas()
   '         Dim estadoSeleccionado = cache.BuscaEstadosOrdenesProduccion(cmbEstadoCambiar.Text)
   '         pnlDepositoUbicacion.Visible = estadoSeleccionado.GeneraProductoTerminado
   '      End If
   '   End Sub)
   'End Sub
   Private Sub cmbEstadoCambiar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEstadoCambiar.SelectedIndexChanged
      TryCatched(
      Sub()
         If cmbEstadoCambiar.SelectedIndex > -1 Then
            Dim idEstadoNuevo = cmbEstadoCambiar.ValorSeleccionado(Of String)()
            Dim estadoNuevo = New Reglas.EstadosOrdenesProduccion().GetUno(idEstadoNuevo, Reglas.Base.AccionesSiNoExisteRegistro.Nulo)

            'Dim idEstadoAnterior = dr.Field(Of String)("IdEstado")
            'Dim estadoAnterior = _cache.BuscaEstadosOrdenesProduccion(idEstadoAnterior)

            If estadoNuevo IsNot Nothing Then
               With ugDetalle.DisplayLayout.Bands(0)
                  .Columns("NombreDepositoUbicacion").Hidden = True
                  .Columns("LoteSeleccionado").Hidden = True
                  .Columns("NroSerieSeleccionado").Hidden = True

                  Dim tipoComp = New Reglas.TiposComprobantes().GetUno(estadoNuevo.IdTipoComprobante, Reglas.Base.AccionesSiNoExisteRegistro.Nulo)
                  'Si el comprobante afecta stock
                  If (tipoComp IsNot Nothing AndAlso tipoComp.CoeficienteStock <> 0) Or estadoNuevo.GeneraProductoTerminado Then
                     'Si hay al menos un producto que AfectaStock muestro la columna 
                     If _dtDetalle.Any(Function(dr) DirectCast(dr("Producto"), Entidades.ProductoLivianoParaImportarProducto).AfectaStock) Then
                        .Columns("NombreDepositoUbicacion").Hidden = False
                     End If
                     'Si hay al menos un producto que usa Lote muestro la columna 
                     If _dtDetalle.Any(Function(dr) DirectCast(dr("Producto"), Entidades.ProductoLivianoParaImportarProducto).Lote) Then
                        .Columns("LoteSeleccionado").Hidden = False
                     End If
                     'Si hay al menos un producto que usa Nro de Serie muestro la columna 
                     If _dtDetalle.Any(Function(dr) DirectCast(dr("Producto"), Entidades.ProductoLivianoParaImportarProducto).NroSerie) Then
                        .Columns("NroSerieSeleccionado").Hidden = False
                     End If
                  End If
               End With

               If ugDetalle.DisplayLayout.Bands.Count > 1 Then
                  With ugDetalle.DisplayLayout.Bands(1)
                     .Columns("NombreDepositoUbicacion").Hidden = True
                     .Columns("LoteSeleccionado").Hidden = True
                     .Columns("NroSerieSeleccionado").Hidden = True
                     .Columns("NombreDepositoUbicacionDestino").Hidden = True
                     'If estadoNuevo.ReservaMateriaPrima Or estadoNuevo.GeneraProductoTerminado Then
                     '   'Si hay al menos un producto que AfectaStock muestro la columna 
                     '   If _dtComponentes.Any(Function(dr) DirectCast(dr("Producto"), Entidades.ProductoLivianoParaImportarProducto).AfectaStock) Then
                     '      .Columns("NombreDepositoUbicacion").Hidden = False
                     '   End If
                     '   'Si hay al menos un producto que usa Lote muestro la columna 
                     '   If _dtComponentes.Any(Function(dr) DirectCast(dr("Producto"), Entidades.ProductoLivianoParaImportarProducto).Lote) Then
                     '      .Columns("LoteSeleccionado").Hidden = False
                     '   End If
                     '   'Si hay al menos un producto que usa Nro de Serie muestro la columna 
                     '   If _dtComponentes.Any(Function(dr) DirectCast(dr("Producto"), Entidades.ProductoLivianoParaImportarProducto).NroSerie) Then
                     '      .Columns("NroSerieSeleccionado").Hidden = False
                     '   End If
                     'End If
                     'ugDetalle.Rows.Refresh(RefreshRow.FireInitializeRow, recursive:=True)

                  End With
               End If
            End If
         End If
         ugDetalle.Rows.Refresh(RefreshRow.FireInitializeRow, recursive:=True)
      End Sub)
   End Sub


   Private Sub ugDetalle_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugDetalle.ClickCellButton
      TryCatched(
      Sub()
         Dim dr = e.Cell.Row.FilaSeleccionada(Of DataRow)
         If dr IsNot Nothing Then
            Dim idEstadoNuevo = cmbEstadoCambiar.ValorSeleccionado(Of String)()
            Dim estadoNuevo = _cache.BuscaEstadosOrdenesProduccion(idEstadoNuevo)

            Dim idEstadoAnterior = dr.Field(Of String)("IdEstado")
            Dim estadoAnterior = _cache.BuscaEstadosOrdenesProduccion(idEstadoAnterior)

            Dim tipoComp = New Reglas.TiposComprobantes().GetUno(estadoNuevo.IdTipoComprobante, Reglas.Base.AccionesSiNoExisteRegistro.Nulo)

            Dim coeficienteStock As Integer = 0
            Dim solicitaInformeCalidad As Boolean = False

            If tipoComp IsNot Nothing Then
               coeficienteStock = tipoComp.CoeficienteStock
               solicitaInformeCalidad = tipoComp.SolicitaInformeCalidad
            Else
               If Not estadoAnterior.ReservaMateriaPrima And estadoNuevo.ReservaMateriaPrima Then
                  coeficienteStock = -1
               ElseIf estadoAnterior.ReservaMateriaPrima And Not estadoNuevo.ReservaMateriaPrima Then
                  coeficienteStock = 1
               Else
                  If estadoNuevo.GeneraProductoTerminado Then
                     If e.Cell.Row.Band.Index = 0 Then
                        coeficienteStock = 1
                     Else
                        coeficienteStock = -1
                     End If
                  End If
               End If
            End If

            Dim ubicCol = If(e.Cell.Row.Band.Index = 0, _ubicaciones, If(e.Cell.Column.Key = "NombreDepositoUbicacionDestino", _ubicacionesComponentesDestino, _ubicacionesComponentes))
            Dim idProducto = If(e.Cell.Row.Band.Index = 0, dr.Field(Of String)("IdProducto"), dr.Field(Of String)("IdProductoComponente"))

            Dim modoUbicacion = SeleccionMultipleUbicacion.ModosUbicacion.MultiplesUbicaciones
            If estadoNuevo.GeneraProductoTerminado Then
               modoUbicacion = SeleccionMultipleUbicacion.ModosUbicacion.UbicacionUnica
            End If
            If estadoAnterior.ReservaMateriaPrima AndAlso Not estadoNuevo.ReservaMateriaPrima Then
               modoUbicacion = SeleccionMultipleUbicacion.ModosUbicacion.UbicacionFija
            End If

            Dim selectedColumn = e.Cell.Column.Key
            Select Case selectedColumn
               Case "NombreDepositoUbicacion"
                  Using frm = New SeleccionMultipleUbicacion()
                     If frm.ShowDialog(Me, coeficienteStock, solicitaInformeCalidad, idProducto,
                                       actual.Sucursal.Id, ubicCol(dr), dr.Field(Of Decimal)("CantidadNuevoEstado"),
                                       modoUbicacion, SeleccionMultipleUbicacion.ModosLoteSerie.Invisible) = DialogResult.OK Then
                        ubicCol(dr) = frm.UbicacionesSeleccionadas
                        EvaluaColecciones(dr, e.Cell.Row.Band.Index)
                     End If
                  End Using
               Case "LoteSeleccionado", "NroSerieSeleccionado"
                  If estadoAnterior.ReservaMateriaPrima AndAlso Not estadoNuevo.ReservaMateriaPrima Then
                     If ubicCol(dr).Count <> 1 Then
                        ubicCol(dr).Clear()
                     ElseIf ubicCol(dr)(0).IdDeposito <> estadoAnterior.IdDeposito Or ubicCol(dr)(0).IdUbicacion <> estadoAnterior.IdUbicacion Then
                        ubicCol(dr).Clear()
                     End If
                     If ubicCol(dr).Count = 0 Then
                        ubicCol(dr).Add(New Entidades.SeleccionMultipleUbicaciones() With {
                                                .Producto = dr.Field(Of Entidades.ProductoLivianoParaImportarProducto)("Producto"),
                                                .Ubicacion = New Reglas.SucursalesUbicaciones().GetUno(estadoAnterior.IdDeposito, actual.Sucursal.Id, estadoAnterior.IdUbicacion),
                                                .Cantidad = dr.Field(Of Decimal)("CantidadNuevoEstado")
                                        })
                     Else
                        ubicCol(dr)(0).Cantidad = dr.Field(Of Decimal)("CantidadNuevoEstado")
                     End If
                     coeficienteStock = -1
                  End If
                  Using frm = New SeleccionMultipleUbicacion()
                     If frm.ShowDialog(Me, coeficienteStock, solicitaInformeCalidad, idProducto,
                                       actual.Sucursal.Id, ubicCol(dr), dr.Field(Of Decimal)("CantidadNuevoEstado"),
                                       modoUbicacion, SeleccionMultipleUbicacion.ModosLoteSerie.Visible) = DialogResult.OK Then
                        ubicCol(dr) = frm.UbicacionesSeleccionadas
                        EvaluaColecciones(dr, e.Cell.Row.Band.Index)
                     End If
                  End Using

               Case "NombreDepositoUbicacionDestino"
                  Using frm = New SeleccionMultipleUbicacion()
                     If frm.ShowDialog(Me, coeficienteStock, solicitaInformeCalidad, idProducto,
                                       actual.Sucursal.Id, ubicCol(dr), dr.Field(Of Decimal)("CantidadNuevoEstado"),
                                       SeleccionMultipleUbicacion.ModosUbicacion.UbicacionUnica, SeleccionMultipleUbicacion.ModosLoteSerie.Invisible) = DialogResult.OK Then
                        ubicCol(dr) = frm.UbicacionesSeleccionadas
                        EvaluaColecciones(dr, e.Cell.Row.Band.Index)
                     End If
                  End Using

               Case Else

            End Select
         End If
      End Sub)
   End Sub
   Private Sub ugDetalle_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugDetalle.InitializeRow
      TryCatched(
      Sub()
         Dim dr = e.Row.FilaSeleccionada(Of DataRow)()
         If dr IsNot Nothing Then
            If e.Row.Band.Index = 0 Then
               Dim prod = DirectCast(dr("Producto"), Entidades.ProductoLivianoParaImportarProducto)
               With e.Row
                  If Not prod.Lote Then
                     .Cells("LoteSeleccionado").Activation = Activation.Disabled
                  End If
                  If Not prod.NroSerie Then
                     .Cells("NroSerieSeleccionado").Activation = Activation.Disabled
                  End If
                  If .Cells("CantidadNuevoEstado").ValorAs(0D) <= 0 Or
                     .Cells("CantidadNuevoEstado").ValorAs(0D) > .Cells("CantEntregada").ValorAs(0D) Then
                     .Cells("CantidadNuevoEstado").Color(Color.White, Color.Red)
                  Else
                     .Cells("CantidadNuevoEstado").Color(Color.Black, Color.Cyan)
                  End If
               End With
            ElseIf e.Row.Band.Index = 1 Then
               Dim idEstadoNuevo = cmbEstadoCambiar.ValorSeleccionado(Of String)()
               Dim estadoNuevo = _cache.BuscaEstadosOrdenesProduccion(idEstadoNuevo)

               Dim idEstadoAnterior = dr.Field(Of String)("IdEstado")
               Dim estadoAnterior = _cache.BuscaEstadosOrdenesProduccion(idEstadoAnterior)

               Dim prod = DirectCast(dr("Producto"), Entidades.ProductoLivianoParaImportarProducto)

               With e.Row
                  .Cells("NombreDepositoUbicacionDestino").Activation = Activation.Disabled

                  Dim reserva = estadoAnterior.EvaluaReserva(estadoNuevo)   ' Reserva / DesReserva / NoMueveReserva (sin cambio)
                  Dim muestraLoteSerie = False

                  If reserva = Entidades.TipoReservaStock.NoMueveReserva And Not estadoNuevo.GeneraProductoTerminado Then
                     'Si no mueve Reserva ni genera PT no cambia nada. Dejo el IF para documentación.

                  ElseIf reserva = Entidades.TipoReservaStock.Reserva And estadoNuevo.GeneraProductoTerminado Then
                     'Si RESERVA y Genera PT deberiamos controlarlo porque es una condicion ireal. Dejo el IF para documentación.
                     'No es una condicion valida. Ver que vamos a hacer. Si estamos reservando la MP porque la estamos consumiento (por reserva se entiende que pasa de False a True)

                  ElseIf reserva = Entidades.TipoReservaStock.Reserva And Not estadoNuevo.GeneraProductoTerminado AndAlso prod.AfectaStock Then
                     'Si RESERVA y NO Genera PT debe solicitar el Deposito/Ubicacion Origen junto a Lote/Serie si aplica
                     .Band.Columns("NombreDepositoUbicacion").Hidden = False
                     muestraLoteSerie = True

                  ElseIf reserva = Entidades.TipoReservaStock.NoMueveReserva And estadoNuevo.GeneraProductoTerminado AndAlso prod.AfectaStock Then
                     'Si Genera PT y no mueve Reserva debe solicitar el Deposito/Ubicacion Origen junto a Lote/Serie si aplica
                     .Band.Columns("NombreDepositoUbicacion").Hidden = False
                     muestraLoteSerie = True

                  ElseIf reserva = Entidades.TipoReservaStock.DesReserva And Not estadoNuevo.GeneraProductoTerminado AndAlso prod.AfectaStock Then
                     'Si DES-RESERVA y no Genera PT debe solicitar el Deposito/Ubicacion Destino junto a Lote/Serie si aplica
                     .Band.Columns("NombreDepositoUbicacionDestino").Hidden = False
                     .Cells("NombreDepositoUbicacionDestino").Activation = Activation.AllowEdit
                     muestraLoteSerie = True

                  ElseIf reserva = Entidades.TipoReservaStock.DesReserva And estadoNuevo.GeneraProductoTerminado AndAlso prod.AfectaStock Then
                     'Si DES-RESERVA y no Genera PT solo debe solicitar Lote/Serie si aplica ya que el Deposito/Ubicacion Origen es el deposito de Reserva y de Destino no existe
                     muestraLoteSerie = True
                  End If

                  If muestraLoteSerie Then
                     If prod.Lote Then
                        .Band.Columns("LoteSeleccionado").Hidden = False
                     End If
                     If prod.NroSerie Then
                        .Band.Columns("NroSerieSeleccionado").Hidden = False
                     End If
                  End If

                  If Not prod.Lote Then
                     .Cells("LoteSeleccionado").Activation = Activation.Disabled
                  End If
                  If Not prod.NroSerie Then
                     .Cells("NroSerieSeleccionado").Activation = Activation.Disabled
                  End If
               End With

            End If
         End If
      End Sub)
   End Sub
   Private Sub ugDetalle_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles ugDetalle.AfterCellUpdate
      TryCatched(
      Sub()
         Dim dr = e.Cell.Row.FilaSeleccionada(Of DataRow)()
         If e IsNot Nothing Then
            If e.Cell.Row.Band.Index = 0 Then
               If e.Cell.Column.Key = "CantidadNuevoEstado" Then
                  Dim cantidad = dr.Field(Of Decimal?)("CantEntregada").IfNull()
                  Dim cantidadNuevoEstado = dr.Field(Of Decimal?)("CantidadNuevoEstado").IfNull()

                  For Each drHija In dr.GetChildRows(Reglas.OrdenesProduccionEstados.AdminV2_DetalleProducto_DetalleComponentes_RelationName)
                     Dim cantidadHija = drHija.Field(Of Decimal?)("CantidadFormula").IfNull()
                     drHija.SetField("CantidadNuevoEstado", cantidadHija / cantidad * cantidadNuevoEstado)
                  Next
                  ugDetalle.Rows.Refresh(RefreshRow.ReloadData)
               End If
            End If
         End If
      End Sub)
   End Sub

#End Region

#Region "Metodos"

   Private Sub RefrescarDatosGrilla(dt As DataTable)
      Dim dsTemp = New Reglas.OrdenesProduccionEstados().GetDataSetCambioMasivo(dt)
      _dsDetalle = dsTemp.Item1
      _dtDetalle = _dsDetalle.Tables("DetalleProducto")
      _dtComponentes = _dsDetalle.Tables("DetalleComponentes")
      _ubicaciones = dsTemp.Item2
      _ubicacionesComponentes = dsTemp.Item3
      _ubicacionesComponentesDestino = dsTemp.Item4

      _dtDetalle.ForEach(Function(dr) EvaluaColecciones(dr, 0))
      _dtComponentes.ForEach(Function(dr) EvaluaColecciones(dr, 1))

      RefrescarDatosGrilla()

      ugDetalle.DataSource = _dsDetalle
      ugDetalle.DataMember = "DetalleProducto"
      AjustarColumnasGrilla(ugDetalle, _tit)
      FormatearGrillaDetalleComponentes()

   End Sub
   Public Sub FormatearGrillaDetalleComponentes()
      If ugDetalle.DisplayLayout.Bands.Count > 1 Then
         With ugDetalle.DisplayLayout.Bands(1)
            '.OcultaTodasLasColumnas()
            Dim pos = 0I
            .Columns("IdSucursal").OcultoPosicion(hidden:=True, pos)
            .Columns("IdTipoComprobante").OcultoPosicion(hidden:=True, pos)
            .Columns("Letra").OcultoPosicion(hidden:=True, pos)
            .Columns("CentroEmisor").OcultoPosicion(hidden:=True, pos)
            .Columns("NumeroOrdenProduccion").OcultoPosicion(hidden:=True, pos)
            .Columns("Orden").OcultoPosicion(hidden:=True, pos)
            .Columns("IdProducto").OcultoPosicion(hidden:=True, pos)
            .Columns("NombreProducto").OcultoPosicion(hidden:=True, pos)
            .Columns("IdFormula").OcultoPosicion(hidden:=True, pos)
            .Columns("IdProcesoProductivo").OcultoPosicion(hidden:=True, pos)

            .Columns("IdEstado").OcultoPosicion(hidden:=True, pos)

            .Columns("IdProductoComponente").FormatearColumna("Código Componente", pos, 80)
            .Columns("NombreProductoComponente").FormatearColumna("Componente", pos, 200)
            .Columns("CantidadFormula").FormatearColumna("Cantidad", pos, 80, HAlign.Right, , "N2", Formatos.MaskInput.Decimales9_2)
            .Columns("CantidadNuevoEstado").FormatearColumna("Cantidad Nuevo Estado", pos, 80, HAlign.Right, , "N2", Formatos.MaskInput.Decimales9_2).Color(Color.Black, Color.Yellow)

            .Columns("Producto").OcultoPosicion(hidden:=True, pos)

            .Columns("IdDepositoDefecto").OcultoPosicion(hidden:=True, pos)
            .Columns("IdUbicacionDefecto").OcultoPosicion(hidden:=True, pos)
            .Columns("NombreDepositoDefecto").OcultoPosicion(hidden:=True, pos)
            .Columns("NombreUbicacionDefecto").OcultoPosicion(hidden:=True, pos)

            Dim col = .Columns("NombreDepositoUbicacion").FormatearColumna("Depósito / Ubicación", pos, 130,, True)
            col.Style = UltraWinGrid.ColumnStyle.Button
            col.ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
            col = .Columns("LoteSeleccionado").FormatearColumna("Lotes", pos, 90,, True)
            col.Style = UltraWinGrid.ColumnStyle.Button
            col.ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
            col = .Columns("NroSerieSeleccionado").FormatearColumna("Nros. Serie", pos, 90,, True)
            col.Style = UltraWinGrid.ColumnStyle.Button
            col.ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always


            col = .Columns("NombreDepositoUbicacionDestino").FormatearColumna("Depósito / Ubicación Destino", pos, 130,, True)
            col.Style = UltraWinGrid.ColumnStyle.Button
            col.ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always

            .Columns("ProductoFormula").OcultoPosicion(hidden:=True, pos)

         End With
      End If
   End Sub

   Private Sub RefrescarDatosGrilla()

      ''''cmbEstados.SelectedIndex = 1

      ''''chbFecha.Checked = False
      ''''chbProducto.Checked = False
      ''''chbCliente.Checked = False
      ''''chbIdPedido.Checked = False
      ''''chbTamanio.Checked = False
      ''''chbOrdenCompra.Checked = False

      cmbEstadoCambiar.SelectedIndexIfAny(0)
      ''''cmbResponsable.SelectedIndexIfAny(0)

      ''''cmbTodos.SelectedIndex = 0
      txtObservacion.Clear()
      txtCantidad.SetValor(0D)

      ''''chkExpandAll.Checked = False
      ''''chkExpandAll.Enabled = False

      If _dtDetalle.Any() Then
         cmbEstadoCambiar.SelectedValue = _dtDetalle.First().Field(Of String)("IdEstado")
         cmbCriticidad.SelectedValue = _dtDetalle.First().Field(Of String)("IdCriticidad")
         dtpFechaEntrega.Value = _dtDetalle.First().Field(Of Date)("FechaEntrega")
      End If


      '' 'Limpio la Grilla.
      ''ugDetalle.ClearFilas()

      ''''_idEstado = String.Empty
      ''''_idTipoEstado = String.Empty

      ''''cmbEstados.Focus()

      ''''HabilitaDetalle()

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
   End Sub

   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro
      End With
      Return filtro.ToString()
   End Function

   Private Function EvaluaColecciones(dr As DataRow, banda As Integer) As DataRow

      Dim ubicAdmin = If(banda = 0, _ubicaciones(dr), _ubicacionesComponentes(dr))

      If ubicAdmin.Count = 0 Then
         dr("NombreDepositoUbicacion") = String.Format("{0}/{1}", dr.Field(Of String)("NombreDepositoDefecto"), dr.Field(Of String)("NombreUbicacionDefecto"))
      Else
         If ubicAdmin.Count = 1 Then
            Dim u = ubicAdmin.First()
            dr("NombreDepositoUbicacion") = String.Format("{0}/{1}", u.NombreDeposito, u.NombreUbicacion)
         Else
            dr("NombreDepositoUbicacion") = "(multiples)"
         End If
      End If

      If banda = 1 Then
         ubicAdmin = _ubicacionesComponentesDestino(dr)
         If ubicAdmin.Count = 0 Then
            dr("NombreDepositoUbicacionDestino") = String.Format("{0}/{1}", dr.Field(Of String)("NombreDepositoDefecto"), dr.Field(Of String)("NombreUbicacionDefecto"))
         Else
            If ubicAdmin.Count = 1 Then
               Dim u = ubicAdmin.First()
               dr("NombreDepositoUbicacionDestino") = String.Format("{0}/{1}", u.NombreDeposito, u.NombreUbicacion)
            Else
               dr("NombreDepositoUbicacionDestino") = "(multiples)"
            End If
         End If
      End If

      Return dr
   End Function
   Private Sub AplicarDatosMasivos(columna As String, valor As Object)
      AplicarDatosMasivos(columna, Function(dr) valor)
   End Sub
   Private Sub AplicarDatosMasivos(columna As String, accion As Func(Of DataRow, Object))
      ugDetalle.DataSource(Of DataSet).Tables(0).ForEach(
         Sub(dr)
            dr(columna) = accion(dr)
         End Sub)
      ugDetalle.Rows.Refresh(RefreshRow.ReloadData)
   End Sub

   Private Sub Aceptar()
      ugDetalle.UpdateData()
      If Validar() Then

         Dim rPE = New Reglas.OrdenesProduccionEstados(_cache)
         rPE.ActualizarEstadoOrdenProduccionMasivo(ConvertirACambioEstado(ugDetalle.DataSource(Of DataSet).Tables(Reglas.OrdenesProduccionEstados.AdminV2_DetalleProducto_TableName)), IdFuncion)

         Close(DialogResult.OK)

         ShowMessage("¡¡ Estado/s actualizado/s Exitosamente !!.")
      End If
   End Sub
   Private Sub Cancelar()
      Close(DialogResult.Cancel)
   End Sub

   Private Function ConvertirACambioEstado(dt As DataTable) As Entidades.OrdenesProduccionAdminCambioEstado
      Return New Reglas.OrdenesProduccionEstados().ConvertirACambioEstado(dt, _ubicaciones, _ubicacionesComponentes, _ubicacionesComponentesDestino,
                                                                          _tipoTipoComprobante, cmbEstadoCambiar.ValorSeleccionado(Of String),
                                                                          txtObservacion.Text)
   End Function

   Private Function Validar() As Boolean
      Using errBuilder = New Entidades.ErrorBuilder()

         For Each fila In _dtDetalle.AsEnumerable()

            Dim idEstado = cmbEstadoCambiar.ValorSeleccionado(Of String)
            Dim idCriticidad = fila.Field(Of String)("IdCriticidad")
            Dim fechaEntrega = fila.Field(Of Date)("FechaEntrega")
            Dim idResponsable = fila.Field(Of Integer)("IdResponsable")

            Dim idEstadoOriginal = fila.Field(Of String)("IdEstado")
            Dim idCriticidadOriginal = fila.Field(Of String)("IdCriticidad", DataRowVersion.Original)
            Dim fechaEntregaOriginal = fila.Field(Of Date)("FechaEntrega", DataRowVersion.Original)
            Dim idResponsableOriginal = fila.Field(Of Integer)("IdResponsable", DataRowVersion.Original)

            If idEstado = idEstadoOriginal AndAlso idCriticidad = idCriticidadOriginal AndAlso fechaEntrega = fechaEntregaOriginal AndAlso idResponsable = idResponsableOriginal Then
               errBuilder.AddError(String.Format(Traducciones.TraducirTexto("Pedido: {0} --> El Estado a cambiar debe ser distinto al Estado Actual del Pedido o cambiar Criticidad/Fecha de Entrega/Responsable.",
                                                                            Me, "__ErrorCambioMasivoNoPermitido"),
                                                 fila("NumeroOrdenProduccion")), cmbEstadoCambiar)
            End If

            Dim estado = _cache.BuscaEstadosOrdenesProduccion(idEstado)
            Dim estadoOriginal = _cache.BuscaEstadosOrdenesProduccion(idEstadoOriginal)

            'If Not String.IsNullOrWhiteSpace(estadoOriginal.IdEstadoDestino) Then
            '   If estadoOriginal.IdEstadoDestino <> estado.IdEstado Then
            '      errBuilder.AddError(String.Format(Traducciones.TraducirTexto("Pedido: {0} --> El estado del pedido seleccionado seleccionado (´{2}´) no permite pasar al estado {1}.",
            '                                                                   Me, "__ErrorEstadoNoPermiteSiguiente"),
            '                                        fila("NumeroOrdenProduccion"), cmbEstadoCambiar.SelectedValue.ToString(), fila("IdEstado").ToString()), cmbEstadoCambiar)
            '   End If

            'End If

            If Not String.IsNullOrWhiteSpace(estado.IdTipoComprobante) Then
               Dim tipoComprobante = _cache.BuscaTipoComprobante(estado.IdTipoComprobante)
               If tipoComprobante.Tipo = Entidades.TipoComprobante.Tipos.PRODUCCION.ToString() AndAlso Not fila.Field(Of Integer?)("IdFormula").HasValue Then
                  errBuilder.AddError(String.Format(Traducciones.TraducirTexto("Pedido: {0} --> El Producto {1} - '{2}' no tiene definida una Formula de Producción. No es posible pasar al módulo de Producción.",
                                                                               Me, "__ErrorCambioMasivoNoPermitido"),
                                                    fila("NumeroOrdenProduccion"), fila("IdProducto"), fila("NombreProducto")), cmbEstadoCambiar)

               End If
            End If
         Next

         If errBuilder.AnyError Then
            errBuilder.PerformFocusOnError()
            ShowMessage(errBuilder.ErrorToString)
            Return False
         End If
      End Using
      Return True
   End Function

#End Region

End Class